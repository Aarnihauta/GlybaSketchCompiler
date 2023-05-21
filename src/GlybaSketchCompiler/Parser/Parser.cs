using GlybaSketchCompiler.Expressions;
using GlybaSketchCompiler.Tokinization;
using System.Collections.ObjectModel;

namespace GlybaSketchCompiler.Parser;
public class Parser
{
    private readonly SyntaxToken[] _tokens;
    private List<string> _diagnostics = new List<string>();
    private int _position;

    public Parser(string text)
    {
        var tokens = new List<SyntaxToken>();
        var lexer = new Lexer(text);
        SyntaxToken token;
        do
        {
            token = lexer.NextToken();

            if (token.Kind != SyntaxKind.WhitespaceToken)
            {
                tokens.Add(token);
            }

        } while (token.Kind != SyntaxKind.EndOfFileToken);

        _tokens = tokens.ToArray();
        _diagnostics.AddRange(lexer.Diagnostics);
    }

    public SyntaxToken Current => Peek(0);
    public ReadOnlyCollection<string> Diagnostics => _diagnostics.AsReadOnly();

    public SyntaxTree Parse()
    {
        var expression = ParseTerm();
        var endOfFileToken = Match(SyntaxKind.EndOfFileToken);

        return new SyntaxTree(expression, endOfFileToken);
    }

    private ExpressionSyntax ParseTerm()
    {
        var left = ParseFactor();

        while (
            Current.Kind == SyntaxKind.PlusToken ||
            Current.Kind == SyntaxKind.MinusToken)
        {
            var operatorToken = NextToken();
            var right = ParseFactor();
            left = new BinaryExpressionSyntax(left, operatorToken, right);
        }

        return left;
    }

    private ExpressionSyntax ParseFactor()
    {
        var left = ParsePrimaryExpression();

        while (
            Current.Kind == SyntaxKind.StartToken ||
            Current.Kind == SyntaxKind.SlashToken)
        {
            var operatorToken = NextToken();
            var right = ParsePrimaryExpression();
            left = new BinaryExpressionSyntax(left, operatorToken, right);
        }

        return left;
    }

    private ExpressionSyntax ParsePrimaryExpression()
    {
        if(Current.Kind == SyntaxKind.ParenthesizedExpressionToken)
        {
            var left = NextToken();
            var expression = ParseExpression();
            var right = Match(SyntaxKind.CloseParenthesisToken);
            return new ParenthesizedExpressionSyntax(left, expression, right);
        }
        var numberToken = Match(SyntaxKind.NumberToken);
        return new NumberExpressionSyntax(numberToken);
    }

    private ExpressionSyntax ParseExpression()
    {
        return ParseTerm();
    }

    private SyntaxToken NextToken()
    {
        var current = Current;
        _position++;
        return current;
    }

    private SyntaxToken Match(SyntaxKind kind)
    {
        if (Current.Kind != kind)
        {
            _diagnostics.Add($"Unexpected token <{Current.Kind}>, expected {kind}");
        }

        return NextToken();
    }

    private SyntaxToken Peek(int offset)
    {
        int index = _position + offset;

        if (index >= _tokens.Length)
        {
            return _tokens[^1];
        }

        return _tokens[index];
    }
}
