using GlybaSketchCompiler.Exceptions;
using GlybaSketchCompiler.Expressions;
using GlybaSketchCompiler.Tokinization;

namespace GlybaSketchCompiler.Parser;
public class Evaluator
{
    private readonly SyntaxTree _root;

    public Evaluator(SyntaxTree root)
	{
        _root = root;
    }

    public decimal Evaluate()
    {
        return EvaluateExpression(_root.Root);
    }

    private decimal EvaluateExpression(ExpressionSyntax root)
    {
        if(root is NumberExpressionSyntax n)
        {
            return (decimal)n.NumberToken.Value;
        }

        if(root is BinaryExpressionSyntax b)
        {
            var left = EvaluateExpression(b.Left);
            var right = EvaluateExpression(b.Right);

            return b.OperatorToken.Kind switch
            {
                SyntaxKind.PlusToken => left + right,
                SyntaxKind.MinusToken => left - right,
                SyntaxKind.StartToken => left * right,
                SyntaxKind.SlashToken => left / right,
                _ => throw new InvalidTokenException(b.OperatorToken)
            };
        }

        if(root is ParenthesizedExpressionSyntax p)
        {
            return EvaluateExpression(p.Expression);
        }

        throw new ArgumentException("Unexpected node");
    }
}
