using GlybaSketchCompiler.Expressions;
using GlybaSketchCompiler.Tokenization;

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
        if(root is LiteralExpressionSyntax n)
        {
            return (decimal)n.LiteralToken.Value;
        }

        if(root is BinaryExpressionSyntax b)
        {
            var left = EvaluateExpression(b.Left);
            var right = EvaluateExpression(b.Right);

            return b.OperatorToken.Kind switch
            {
                SyntaxKind.PlusToken => left + right,
                SyntaxKind.MinusToken => left - right,
                SyntaxKind.StarToken => left * right,
                SyntaxKind.SlashToken => left / right
            };
        }

        if(root is ParenthesizedExpressionSyntax p)
        {
            return EvaluateExpression(p.Expression);
        }

        if(root is UnaryExpressionSyntax u)
        {
            var operand = EvaluateExpression(u.Operand);

            if (u.Operand.Kind == SyntaxKind.PlusToken)
            {
                return operand;
            }
            else if (u.OperatorToken.Kind == SyntaxKind.MinusToken)
            {
                return -operand;
            }
            else
            {
                throw new Exception($"Unexpected unary operator {u.OperatorToken.Kind}");
            }
        }

        throw new ArgumentException("Unexpected node");
    }
}
