using Components;
using Unity.Entities;
using UnityEngine;

namespace Mono
{
    public class AimingPropertiesMono : MonoBehaviour
    {
        [SerializeField]
        private GameObject _arrow;
        [SerializeField]
        private Vector2 _aimingLimitation;
        
        public class AimingPropertiesBaker : Baker<AimingPropertiesMono>
        {
            public override void Bake(AimingPropertiesMono authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);

                AddComponent(entity,new AimingProperties
                {
                    arrow = GetEntity(authoring._arrow, TransformUsageFlags.Dynamic),
                    aimingLimitation = authoring._aimingLimitation
                });
            }
        }
    }
}