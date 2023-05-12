using GlybaSketchCompiler.Tokinization;

namespace GlybaSketchCompiler.Expressions;
public class NumberExpressionSyntaxNode : ExpressionSyntaxNode
{

    public NumberExpressionSyntaxNode(SyntaxToken numberToken)
    {
        NumberToken = numberToken;
    }

    public override SyntaxKind Kind => SyntaxKind.NumberExpression;
    public SyntaxToken NumberToken { get; }
}
