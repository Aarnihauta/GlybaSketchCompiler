using GlybaSketchCompiler.Tokenization;

namespace TokinizationTests;

public class LexerTests
{
    [Fact]
    public void NextTokenTest_1()
    {
        var kinds = new List<SyntaxKind>
        {
            SyntaxKind.NumberToken,
            SyntaxKind.PlusToken,
            SyntaxKind.NumberToken,
            SyntaxKind.WhitespaceToken,
            SyntaxKind.StarToken,
            SyntaxKind.WhitespaceToken,
            SyntaxKind.NumberToken,
            SyntaxKind.EndOfFileToken,
        };

        string line = "2+2 * 2";
        var result = GetSyntaxKinds(line);

        Assert.Equal(kinds, result);
    }

    [Fact]
    public void NextToken_BadToken_Test()
    {
        var kinds = new List<SyntaxKind>
        {
            SyntaxKind.BadToken,
            SyntaxKind.BadToken,
            SyntaxKind.BadToken,
            SyntaxKind.EndOfFileToken
        };

        string line = "bad";
        var result = GetSyntaxKinds(line);

        Assert.Equal(kinds, result);
    }

    [Fact]
    public void NextToken_Numbers_Test()
    {
        string line = "1598-250+14";

        var tokens = GetTokens(line);

        Assert.Equal(1598, (decimal)tokens[0].Value);
        Assert.Equal(250, (decimal)tokens[2].Value);
        Assert.Equal(14, (decimal)tokens[4].Value);
    }

    private List<SyntaxKind> GetSyntaxKinds(string text)
    {
        var result = new List<SyntaxKind>();
        var lexer = new Lexer(text);
        while (true)
        {
            var token = lexer.NextToken();
            result.Add(token.Kind);
            if (token.Kind == SyntaxKind.EndOfFileToken)
            {
                break;
            }
        }

        return result;
    }

    private List<SyntaxToken> GetTokens(string text)
    {
        var result = new List<SyntaxToken>();
        var lexer = new Lexer(text);

        while (true)
        {
            var token = lexer.NextToken();
            result.Add(token);

            if (token.Kind == SyntaxKind.EndOfFileToken)
            {
                break;
            }
        }

        return result;
    }
}