using GlybaSketchCompiler.Tokinization;

namespace GlybaSketchCompiler.Expressions;
public class BinaryExpressionSyntaxNode : ExpressionSyntaxNode
{
    public BinaryExpressionSyntaxNode(ExpressionSyntaxNode left, SyntaxToken operatorToken, ExpressionSyntaxNode right)
    {
        Left = left;
        OperatorNode = operatorToken;
        Right = right;
    }
    public override SyntaxKind Kind => SyntaxKind.BinaryExpression;

    public ExpressionSyntaxNode Left { get; }
    public SyntaxToken OperatorNode { get; }
    public ExpressionSyntaxNode Right { get; }
}
