using GlybaSketchCompiler.Tokenization;

namespace GlybaSketchCompiler.Expressions;
public abstract class SyntaxNode
{
    public abstract SyntaxKind Kind { get; }
    public abstract IEnumerable<SyntaxNode> GetChildren();
    public virtual List<SyntaxNode> Children => GetChildren().ToList();

    public override string ToString()
    {
        return Kind.ToString();
    }
}
