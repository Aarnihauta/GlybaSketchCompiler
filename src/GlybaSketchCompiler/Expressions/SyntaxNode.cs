using GlybaSketchCompiler.Tokinization;

namespace GlybaSketchCompiler.Expressions;
public abstract class SyntaxExpressionNode
{
    public abstract SyntaxKind Kind { get; }
}
