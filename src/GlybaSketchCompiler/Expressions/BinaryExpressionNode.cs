using GlybaSketchCompiler.Tokinization;

namespace GlybaSketchCompiler.Expressions;
public class BinaryExpressionSyntaxNode : ExpressionNode
{
    public BinaryExpressionSyntaxNode(ExpressionNode left, SyntaxToken operatorToken, ExpressionNode right)
    {
        Left = left;
        OperatorNode = operatorToken;
        Right = right;
    }
    public override SyntaxKind Kind => SyntaxKind.BinaryExpression;

    public ExpressionNode Left { get; }
    public SyntaxToken OperatorNode { get; }
    public ExpressionNode Right { get; }
}
