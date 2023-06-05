using GlybaSketchCompiler.Tokenization;

namespace GlybaSketchCompiler.Expressions;
public sealed class NumberExpressionSyntax : ExpressionSyntax
{

    public NumberExpressionSyntax(SyntaxToken numberToken)
    {
        NumberToken = numberToken;
    }

    public override SyntaxKind Kind => SyntaxKind.NumberExpressionToken;
    public SyntaxToken NumberToken { get; }

    public override IEnumerable<SyntaxNode> GetChildren()
    {
        yield return NumberToken;
    }

    public override string ToString()
    {
        return NumberToken.Text;
    }
}
