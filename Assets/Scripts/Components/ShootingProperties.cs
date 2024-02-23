using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    public struct ShootingProperties : IComponentData
    {
        public float2 pointPosition;
    }

    public struct AimingProperties : IComponentData
    {
        public Entity arrow;
        public float2 aimingLimitation;
    }

    public struct AimingTag : IComponentData, IEnableableComponent{}
}