namespace GlybaSketchCompiler.Tokinization.Syntax;
public class NumberSyntaxNode : ExpressionSyntaxNode
{

    public NumberSyntaxNode(SyntaxToken numberToken)
    {
        NumberToken = numberToken;
    }

    public override SyntaxKind Kind => SyntaxKind.NumberExpression;
    public SyntaxToken NumberToken { get; }
}
