using GlybaSketchCompiler.Exceptions;
using GlybaSketchCompiler.Expressions;
using GlybaSketchCompiler.Tokinization;

namespace GlybaSketchCompiler.Parser;
public class Parser
{
    private readonly SyntaxToken[] _tokens;
    private int _position;

    public Parser(string text)
    {
        var tokens = new List<SyntaxToken>();

        var lexer = new Lexer(text);
        SyntaxToken token;
        do
        {
            token = lexer.NextToken();

            if (token.Kind == SyntaxKind.BadToken)
            {
                throw new InvalidTokenException(token);
            }

            if (token.Kind != SyntaxKind.WhitespaceToken)
            {
                tokens.Add(token);
            }

        } while (token.Kind != SyntaxKind.EndOfFileToken);

        _tokens = tokens.ToArray();
    }

    public SyntaxToken Current => Peek(0);

    public ExpressionSyntax Parse()
    {
        var left = ParsePrimaryExpression();

        if (Current.Kind == SyntaxKind.PlusToken || Current.Kind == SyntaxKind.MinusToken)
        {
            var operatorToken = NextToken();
            var right = ParsePrimaryExpression();
            left = new BinaryExpressionSyntax(left, operatorToken, right);
        }

        return left;
    }

    private ExpressionSyntax ParsePrimaryExpression()
    {
        var numberToken = Match(SyntaxKind.NumberToken);
        return new NumberExpressionSyntax(numberToken);
    }

    private SyntaxToken NextToken()
    {
        var current = Current;
        _position++;
        return current;
    }

    private SyntaxToken Match(SyntaxKind kind)
    {
        if(Current.Kind == kind)
        {
            return NextToken();
        }

        return new SyntaxToken(kind, Current.Position, null, null);
    }

    private SyntaxToken Peek(int offset)
    {
        int index = _position + offset;

        if (index >= _tokens.Length)
        {
            return _tokens[index ^ 1];
        }

        return _tokens[index];
    }



}
