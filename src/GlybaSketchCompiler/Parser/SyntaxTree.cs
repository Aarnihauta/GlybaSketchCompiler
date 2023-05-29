using GlybaSketchCompiler.Expressions;
using GlybaSketchCompiler.Tokenization;

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
