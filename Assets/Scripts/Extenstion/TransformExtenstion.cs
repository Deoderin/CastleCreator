using Unity.Mathematics;
using Unity.Transforms;

namespace Components
{
    public static class TransformExtenstion
    {
        public static LocalTransform GetBollTransform(float3 position)
        {
            return new LocalTransform()
            {
                Position = new float3(position.x, position.y, position.z), Rotation = quaternion.identity, Scale = 1,
            };
        }
    }
}