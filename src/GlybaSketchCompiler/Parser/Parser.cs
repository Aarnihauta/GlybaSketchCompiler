using GlybaSketchCompiler.Expressions;
using GlybaSketchCompiler.Tokenization;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TokinizationTests")]

namespace GlybaSketchCompiler.Parser;
internal sealed class Parser
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
            token = lexer.Lex();

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
        var expression = ParseExpression();
        var endOfFileToken = Match(SyntaxKind.EndOfFileToken);

        return new SyntaxTree(expression, endOfFileToken);
    }

    private ExpressionSyntax ParseExpression(int parentPrecedence = 0)
    {
        var left = ParsePrimaryExpression();

        while (true)
        {
            var precedence = GetBinaryOperatorPrecedence(Current.Kind);
            if(precedence == 0 || precedence <= parentPrecedence)
            {
                break;
            }

            var operatorToken = NextToken();
            var right = ParseExpression(parentPrecedence);
            left = new BinaryExpressionSyntax(left, operatorToken, right);
        }

        return left;
    }

    private int GetBinaryOperatorPrecedence(SyntaxKind kind)
    {
        switch (kind)
        {
            case SyntaxKind.StarToken:
            case SyntaxKind.SlashToken:
                return 2;
            case SyntaxKind.PlusToken:
            case SyntaxKind.MinusToken:
                return 1;
            default:
                return 0;
        }
    }

    private ExpressionSyntax ParsePrimaryExpression()
    {
        if(Current.Kind == SyntaxKind.OpenParenthesisToken)
        {
            var left = NextToken();
            var expression = ParseExpression();
            var right = Match(SyntaxKind.CloseParenthesisToken);

            return new ParenthesizedExpressionSyntax(left, expression, right);
        }
        var numberToken = Match(SyntaxKind.NumberToken);
        return new LiteralExpressionSyntax(numberToken);
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
