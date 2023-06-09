﻿using GlybaSketchCompiler.Parser;

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

    [Fact]
    public void EvaluatorTest2()
    {
        var parser = new Parser("1+2*3");
        var evaluator = new Evaluator(parser.Parse());

        decimal result = evaluator.Evaluate();

        Assert.Equal(7, result);
    }

    [Fact]
    public void ParenthesisTest()
    {
        var parser = new Parser("(1+2)*3");
        var evaluator = new Evaluator(parser.Parse());

        decimal result = evaluator.Evaluate();

        Assert.Equal(9, result);
    }

    [Fact]
    public void ParenthesisTest2()
    {
        var parser = new Parser("(1 + (2 + 2)) *  3");
        var evaluator = new Evaluator(parser.Parse());

        decimal result = evaluator.Evaluate();

        Assert.Equal(15, result);
    }

    [Fact]
    public void ParenthesisTest3()
    {
        var parser = new Parser("3 * (2 + 1)");
        var evaluator = new Evaluator(parser.Parse());

        decimal result = evaluator.Evaluate();

        Assert.Equal(9, result);
    }

    [Fact]
    public void UnaryExpressionTest()
    {
        var parser = new Parser("-1");
        var evaluator = new Evaluator(parser.Parse());

        decimal result = evaluator.Evaluate();

        Assert.Equal(-1, result);
    }

    [Fact]
    public void UnaryExpressionTest2()
    {
        var parser = new Parser("-1 * -2");
        var evaluator = new Evaluator(parser.Parse());

        decimal result = evaluator.Evaluate();

        Assert.Equal(2, result);
    }

    [Fact]
    public void UnaryExpressionTest3()
    {
        var parser = new Parser("--1");
        var evaluator = new Evaluator(parser.Parse());

        decimal result = evaluator.Evaluate();

        Assert.Equal(1, result);
    }

    [Fact]
    public void UnaryExpressionTest4()
    {
        var parser = new Parser("--+-1");
        var evaluator = new Evaluator(parser.Parse());

        decimal result = evaluator.Evaluate();

        Assert.Equal(-1, result);
    }
}
