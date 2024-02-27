using Components;
using Mono;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Systems
{
    public partial struct DirectionCalculationSystem : ISystem
    {
        
        public void OnCreate(ref SystemState state)
        {
            Entity entity = state.EntityManager.CreateEntity();
            state.EntityManager.AddComponent<ShootingProperties>(entity);
            state.EntityManager.AddComponent<AimingTag>(entity);
            state.EntityManager.SetComponentEnabled<AimingTag>(entity, false);
        }
        
        public void OnUpdate(ref SystemState state)
        {
            var inputProvider = InputProvider.Instance;

            if(inputProvider == null)
            {
                return;
            }
            
            if(inputProvider._horizontalJoystick.IsChanged || inputProvider._verticalJoystick.IsChanged)
            {
                foreach (var prop in SystemAPI.Query<RefRW<ShootingProperties>>().WithEntityAccess())
                {
                    prop.Item1.ValueRW.pointPosition = new float2(-inputProvider._verticalJoystick.Vertical, inputProvider._horizontalJoystick.Horizontal) * Time.deltaTime;
                    state.EntityManager.SetComponentEnabled<AimingTag>(prop.Item2, true);
                }
            }
            else
            {
                foreach (var aimingTagEntity in SystemAPI.Query<AimingTag>().WithEntityAccess())
                {
                    state.EntityManager.SetComponentEnabled<AimingTag>(aimingTagEntity.Item2, false);
                }
            }
        }
    }
}