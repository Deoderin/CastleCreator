using Unity.Mathematics;

namespace Extenstion
{
    public static class MathInterpolation
    {
        public static float QuadraticInterpolation(float t) => t * t;
        public static float CubicInterpolation(float t) => t * t * t;
        public static float SigmoidInterpolation(float t) => 1 / (1 + math.exp(-t));
        public static float InverseQuadraticInterpolation(float t) => 1 - (1 - t) * (1 - t);
        public static float SquareRootInterpolation(float t) => math.sqrt(t);
        public static float HyperbolicCosineInterpolation(float t) => (math.cosh(t) - 1) / (math.cosh(1) - 1);
        public static float LogarithmicInterpolation(float t) => math.log10(9 * t + 1) / math.log10(10);
        public static float ExponentialInterpolation(float t) => math.exp(t) / math.exp(1);
    }
}