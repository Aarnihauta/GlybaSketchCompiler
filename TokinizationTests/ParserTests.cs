using GlybaSketchCompiler.Expressions;
using GlybaSketchCompiler.Parser;
using GlybaSketchCompiler.Tokinization;

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
        Assert.IsType<BinaryExpressionSyntax>(syntax);
        Assert.IsType<NumberExpressionSyntax>(children[0]);
        Assert.IsType<SyntaxToken>(children[1]);
        Assert.IsType<NumberExpressionSyntax>(children[2]);
    }

    [Fact]
    public void BinaryExpressionTest2()
    {
        var parser = new Parser("1-2+3*7");
        var syntax = parser.Parse();

        var children = syntax.Root.GetChildren().ToList();
    }
}
