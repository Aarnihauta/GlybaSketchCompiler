using GlybaSketchCompiler.Parser;

namespace TokinizationTests;
public class ParserTests
{
    [Fact]
    public void Parse()
    {
        var parser = new Parser("1*2-3");
        var syntax = parser.Parse();
        Assert.NotNull(syntax);
    }
}
