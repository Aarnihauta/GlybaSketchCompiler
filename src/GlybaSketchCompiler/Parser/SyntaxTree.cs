using GlybaSketchCompiler.Expressions;
using GlybaSketchCompiler.Tokinization;

namespace GlybaSketchCompiler.Parser;
public class SyntaxTree
{
    public SyntaxTree(ExpressionSyntax root, SyntaxToken endOfFileToken)
    {
        Root = root;
        EndOfFileToken = endOfFileToken;
    }

    public ExpressionSyntax Root { get; }
    public SyntaxToken EndOfFileToken { get; }
}
