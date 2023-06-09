﻿using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TokinizationTests")]

namespace GlybaSketchCompiler.Tokenization;

internal sealed class Lexer
{
    private List<string> _diagnostics = new List<string>();
    private readonly string _text;
    private int _position;

    public Lexer(string text)
    {
        _text = text;
    }

    public IEnumerable<string> Diagnostics => _diagnostics;

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

    public SyntaxToken Lex()
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
            
            if (!decimal.TryParse(text, out var value))
            {
                _diagnostics.Add($"Unexpected token {text}");
            }

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
            
            if (!decimal.TryParse(text, out var value))
            {
                _diagnostics.Add($"Unexpected token {text}");
            }

            return new SyntaxToken(SyntaxKind.WhitespaceToken, _position, text, value);
        }

        switch (Current)
        {
            case '+':
                return new SyntaxToken(SyntaxKind.PlusToken, _position++, "+", null);
            case '-':
                return new SyntaxToken(SyntaxKind.MinusToken, _position++, "-", null);
            case '*':
                return new SyntaxToken(SyntaxKind.StarToken, _position++, "*", null);
            case '/':
                return new SyntaxToken(SyntaxKind.SlashToken, _position++, "/", null);
            case '(':
                return new SyntaxToken(SyntaxKind.OpenParenthesisToken, _position++, "(", null);
            case ')':
                return new SyntaxToken(SyntaxKind.CloseParenthesisToken, _position++, ")", null);
        }

        _diagnostics.Add($"Unexpected token. Position: {_position}, Token: {Current}");
        return new SyntaxToken(SyntaxKind.BadToken, _position++, _text.Substring(_position - 1, 1), null);
    }

    public void Next()
    {
        _position++;
    }
}
