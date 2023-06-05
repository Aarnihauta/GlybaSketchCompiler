using GlybaSketchCompiler.Expressions;
using GlybaSketchCompiler.Parser;
using GlybaSketchCompiler.Tokenization;

namespace TokinizationTests;
public class ParserTests
{
    [Fact]
    public void Parse()
    {
        var parser = new Parser("1*2-3");
        var syntax = parser.Parse();
        Assert.NotNull(syntax);
    }
    
    [Fact]
    public void BinaryExpressionTest1()
    {
        var parser = new Parser("1-2");
        var syntax = parser.Parse();

        var children = syntax.Root.GetChildren().ToList();

        Assert.Equal(3, children.Count);
        Assert.IsType<BinaryExpressionSyntax>(syntax.Root);
        Assert.IsType<LiteralExpressionSyntax>(children[0]);
        Assert.IsType<SyntaxToken>(children[1]);
        Assert.IsType<LiteralExpressionSyntax>(children[2]);
    }

    [Fact]
    public void DiagnosticTest1()
    {
        var parser = new Parser("1-f");
        parser.Parse();
        Assert.NotEmpty(parser.Diagnostics);
    }

    [Fact]
    public void ParenthesisTest1()
    {
        var parser = new Parser("(2+2");
        parser.Parse();
        Assert.NotEmpty(parser.Diagnostics);
    }
}
