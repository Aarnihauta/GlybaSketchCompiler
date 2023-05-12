namespace GlybaSketchCompiler.Tokinization.Syntax;
public class BinaryExpressionSyntaxNode : ExpressionSyntaxNode
{
	public BinaryExpressionSyntaxNode(ExpressionSyntaxNode left, SyntaxNodeBase operatorNode, ExpressionSyntaxNode right)
	{
        Left = left;
        OperatorNode = operatorNode;
        Right = right;
    }
    public override SyntaxKind Kind => SyntaxKind.BinaryExpression;

    public ExpressionSyntaxNode Left { get; }
    public SyntaxNodeBase OperatorNode { get; }
    public ExpressionSyntaxNode Right { get; }
}
