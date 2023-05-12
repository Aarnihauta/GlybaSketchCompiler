using GlybaSketchCompiler.Tokinization;

namespace GlybaSketchCompiler.Expressions;
public class BinaryExpressionSyntaxNode : ExpressionSyntaxNode
{
    public BinaryExpressionSyntaxNode(ExpressionSyntaxNode left, SyntaxNode operatorNode, ExpressionSyntaxNode right)
    {
        Left = left;
        OperatorNode = operatorNode;
        Right = right;
    }
    public override SyntaxKind Kind => SyntaxKind.BinaryExpression;

    public ExpressionSyntaxNode Left { get; }
    public SyntaxNode OperatorNode { get; }
    public ExpressionSyntaxNode Right { get; }
}
