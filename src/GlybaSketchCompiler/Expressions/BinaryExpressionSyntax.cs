using GlybaSketchCompiler.Tokinization;

namespace GlybaSketchCompiler.Expressions;
public class BinaryExpressionSyntax : ExpressionSyntax
{
    public BinaryExpressionSyntax(ExpressionSyntax left, SyntaxToken operatorToken, ExpressionSyntax right)
    {
        Left = left;
        OperatorNode = operatorToken;
        Right = right;
    }
    public override SyntaxKind Kind => SyntaxKind.BinaryExpression;

    public ExpressionSyntax Left { get; }
    public SyntaxToken OperatorNode { get; }
    public ExpressionSyntax Right { get; }
}
