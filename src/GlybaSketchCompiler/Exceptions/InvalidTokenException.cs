using GlybaSketchCompiler.Tokinization;

namespace GlybaSketchCompiler.Exceptions;
public class InvalidTokenException : Exception
{
	public InvalidTokenException(SyntaxToken token) : base()
	{
		Data.Add("token", token);
	}
}
