using GlybaSketchCompiler.Tokenization;

namespace GlybaSketchCompiler.Expressions;
public sealed class UnaryExpressionSyntax : ExpressionSyntax
{
    public UnaryExpressionSyntax(SyntaxToken token, ExpressionSyntax operand)
    {
        OperatorToken = token;
        Operand = operand;
    }

    public override SyntaxKind Kind => SyntaxKind.UnaryExpression;

    public ExpressionSyntax Operand { get; }
    public SyntaxToken OperatorToken { get; }

    public override IEnumerable<SyntaxNode> GetChildren()
    {
        yield return OperatorToken;
        yield return Operand;
    }
}
