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
                ExceptionHelper.ThrowInvalidToken(token);
            }

            if (token.Kind != SyntaxKind.WhitespaceToken)
            {
                tokens.Add(token);
            }

        } while (token.Kind != SyntaxKind.EndOfFileToken);

        _tokens = tokens.ToArray();
    }

    public SyntaxToken Current => Peek(0);


    public SyntaxTree Parse()
   {
        var expression = ParseExpression();
        var endOfFileToken = Match(SyntaxKind.EndOfFileToken);

        return new SyntaxTree(expression, endOfFileToken);
    }

    private ExpressionSyntax ParseExpression()
   {
        var left = ParsePrimaryExpression();

        while (
            Current.Kind == SyntaxKind.PlusToken ||
            Current.Kind == SyntaxKind.MinusToken ||
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
        if (Current.Kind != kind)
        {
            ExceptionHelper.ThrowInvalidToken(Current);
        }

        return NextToken();
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
