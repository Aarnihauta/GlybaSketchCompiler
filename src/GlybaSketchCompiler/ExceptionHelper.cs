using GlybaSketchCompiler.Exceptions;
using GlybaSketchCompiler.Tokinization;

namespace GlybaSketchCompiler;
public class ExceptionHelper
{
    public static InvalidTokenException ThrowInvalidToken(SyntaxToken token)
    {
        throw new InvalidTokenException(token);
    }
}
