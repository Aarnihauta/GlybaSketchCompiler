namespace GlybaSketchCompiler.Tokinization;
public class Lexer
{
    private readonly string _text;
    private int _position;

    public Lexer(string text)
    {
        _text = text;
    }

    private char Current
    {
        get
        {
            if (_position >= _text.Length)
            {
                return '\0';
            }

            return _text[_position];
        }
    }

    public SyntaxToken NextToken()
    {
        if (_position >= _text.Length)
        {
            return new SyntaxToken(SyntaxKind.EndOfFileToken, _position, "\0", null);
        }

        if (char.IsDigit(Current))
        {
            var start = _position;

            while (char.IsDigit(Current))
            {
                Next();
            }

            var length = _position - start;
            var text = _text.Substring(start, length);
            decimal.TryParse(text, out var value);
            return new SyntaxToken(SyntaxKind.NumberToken, _position, text, value);
        }

        if (char.IsWhiteSpace(Current))
        {
            var start = _position;

            while (char.IsWhiteSpace(Current))
            {
                Next();
            }

            var length = _position - start;
            var text = _text.Substring(start, length);
            decimal.TryParse(text, out var value);
            return new SyntaxToken(SyntaxKind.WhitespaceToken, _position, text, value);
        }

        if (Current == '+')
        {
            return new SyntaxToken(SyntaxKind.PlusToken, _position++, "+", null);
        }
        else if (Current == '-')
        {
            return new SyntaxToken(SyntaxKind.MinusToken, _position++, "-", null);
        }
        else if (Current == '*')
        {
            return new SyntaxToken(SyntaxKind.StartToken, _position++, "*", null);
        }
        else if (Current == '/')
        {
            return new SyntaxToken(SyntaxKind.SlashToken, _position++, "/", null);
        }
        else if (Current == '(')
        {
            return new SyntaxToken(SyntaxKind.OpenParenthesisToken, _position++, "(", null);
        }
        else if (Current == ')')
        {
            return new SyntaxToken(SyntaxKind.CloseParenthesisToken, _position++, ")", null);
        }

        return new SyntaxToken(SyntaxKind.BadToken, _position++, _text.Substring(_position - 1, 1), null);
    }

    public void Next()
    {
        _position++;
    }
}
