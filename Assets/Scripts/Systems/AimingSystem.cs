using Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Systems
{
    public partial struct AimingSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            foreach (var tag in SystemAPI.Query<AimingTag>())
            {
                foreach (var arrowTransform in SystemAPI.Query<RefRW<LocalTransform>>().WithAll<AimingProperties>())
                {
                    foreach (var aimingProp in SystemAPI.Query<ShootingProperties>())
                    {
                        arrowTransform.ValueRW = arrowTransform.ValueRO.Rotate(quaternion.Euler(new Vector3(aimingProp.pointPosition.x, aimingProp.pointPosition.y, 0f)));
                    }
                }
            }
        }
    }
}