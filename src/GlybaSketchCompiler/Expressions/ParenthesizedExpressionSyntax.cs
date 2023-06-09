﻿using GlybaSketchCompiler.Tokenization;

namespace GlybaSketchCompiler.Expressions;
public sealed class ParenthesizedExpressionSyntax : ExpressionSyntax
{
    public ParenthesizedExpressionSyntax(SyntaxToken openToken, ExpressionSyntax expression, SyntaxToken closeToken)
    {
        OpenParenthesisToken = openToken;
        Expression = expression;
        CloseParenthesisToken = closeToken;
    }

    public SyntaxToken OpenParenthesisToken { get; }
    public ExpressionSyntax Expression { get; }
    public SyntaxToken CloseParenthesisToken { get; }

    public override SyntaxKind Kind => SyntaxKind.ParenthesizedExpression;

    public override IEnumerable<SyntaxNode> GetChildren()
    {
        yield return OpenParenthesisToken;
        yield return Expression; 
        yield return CloseParenthesisToken;
    }

    public override string ToString()
    {
        return Expression.ToString();
    }
}
