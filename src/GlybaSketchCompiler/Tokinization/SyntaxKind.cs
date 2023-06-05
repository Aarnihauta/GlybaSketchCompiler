namespace GlybaSketchCompiler.Tokenization;
public enum SyntaxKind
{
    //Tokens
    EndOfFileToken,
    WhitespaceToken,
    BadToken,

    NumberToken,
    PlusToken,
    MinusToken,
    StarToken,
    SlashToken,
    OpenParenthesisToken,
    CloseParenthesisToken,

    //Expressions
    NumberExpressionToken,
    BinaryExpressionToken,
    ParenthesizedExpressionToken
}
