using GlybaSketchCompiler.Parser;

namespace TokinizationTests;
public class EvaluatorTests
{
    [Fact]
    public void EvaluatorTest()
    {
        var parser = new Parser("1+1+1");
        var evaluator = new Evaluator(parser.Parse());

        decimal result = evaluator.Evaluate();

        Assert.Equal(3, result);
    }
}
