namespace GlybaSketchCompiler.Expressions;
public abstract class ExpressionSyntax : SyntaxNode
{
    protected ExpressionSyntax()
    {
    }

    public override string ToString()
    {
        return Kind.ToString();
    }
}
