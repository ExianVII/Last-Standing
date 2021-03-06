using NUnit.Framework;
using Unity.Mathematics;

namespace Burst.Compiler.IL.Tests
{
    [TestFixture]
    internal partial class Vectors
    {
        public class Quaternions
        {
            [TestCompiler]
            public static float Normalize()
            {
                var v4 = new quaternion(1.0f, 2.0f, 3.0f, 4.0f);
                var result = math.normalize(v4);
                return ConvertToFloat(result.value);
            }

            [TestCompiler]
            public static float IdentityValue()
            {
                // Force ldsflda
                return ConvertToFloat(PassByRef(quaternion.identity.value));
            }

            private static float4 PassByRef(in float4 x)
            {
                return x;
            }
        }
    }
}