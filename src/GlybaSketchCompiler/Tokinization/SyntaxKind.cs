namespace GlybaSketchCompiler.Tokinization;
public enum SyntaxKind
{
    NumberToken,
    WhitespaceToken,
    PlusToken,
    MinusToken,
    StartToken,
    SlashToken,
    OpenParenthesisToken,
    CloseParenthesisToken,
    SketchToken,
    GlybaToken,
    BadToken,
    EndOfFileToken,
    NumberExpressionToken,
    BinaryExpressionToken,
    ParenthesizedExpressionToken
}
