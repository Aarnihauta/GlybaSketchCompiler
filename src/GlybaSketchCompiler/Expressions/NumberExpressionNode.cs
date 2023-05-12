using GlybaSketchCompiler.Tokinization;

namespace GlybaSketchCompiler.Expressions;
public class NumberExpressionNode : ExpressionSyntaxNode
{

    public NumberExpressionNode(SyntaxToken numberToken)
    {
        NumberToken = numberToken;
    }

    public override SyntaxKind Kind => SyntaxKind.NumberExpression;
    public SyntaxToken NumberToken { get; }
}
