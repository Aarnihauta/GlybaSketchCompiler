﻿namespace GlybaSketchCompiler.Tokinization;
public class SyntaxToken
{
    public SyntaxToken(SyntaxKind kind, int position, string text, object value)
	{
        Kind = kind;
        Position = position;
        Text = text;
        Value = value;
        Kind = kind;
    }

    public SyntaxKind Kind { get; }
    public int Position { get; }
    public string Text { get; }
    public object Value { get; }

}
