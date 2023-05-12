using GlybaSketchCompiler.Tokinization;

namespace GlybaSketchCompiler.Expressions;
public abstract class SyntaxNode
{
    public abstract SyntaxKind Kind { get; }
}
