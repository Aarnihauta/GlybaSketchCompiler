using GlybaSketchCompiler.Tokenization;

namespace GlybaSketchCompiler.Expressions;
public sealed class LiteralExpressionSyntax : ExpressionSyntax
{

    public LiteralExpressionSyntax(SyntaxToken literalToken)
    {
        LiteralToken = literalToken;
    }

    public override SyntaxKind Kind => SyntaxKind.LiteralExpressionToken;
    public SyntaxToken LiteralToken { get; }

    public override IEnumerable<SyntaxNode> GetChildren()
    {
        yield return LiteralToken;
    }

    public override string ToString()
    {
        return LiteralToken.Text;
    }
}
