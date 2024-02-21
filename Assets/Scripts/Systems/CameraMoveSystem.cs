using Components;
using Extenstion;
using Mono;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Systems
{
    public partial struct CameraMoveSystem : ISystem
    {
        private float _timeLeft;

        public void OnUpdate(ref SystemState state)
        {
            float dt = SystemAPI.Time.DeltaTime;

            foreach (var cameraProp in SystemAPI
                                            .Query<RefRW<CameraMovementProperties>>()
                                            .WithEntityAccess()
                                            .WithAll<CameraShootTag>())
            {
                Transform cam = CameraSingleton.Instance.transform;
                _timeLeft += dt;
                
                float completionPercentage = _timeLeft / cameraProp.Item1.ValueRO.animationTime;
                float process = MathInterpolation.InverseQuadraticInterpolation(completionPercentage);
                
                cam.position = math.lerp(cameraProp.Item1.ValueRO.startCameraPosition, cameraProp.Item1.ValueRO.shootCameraPosition, process);
                cam.eulerAngles = math.lerp(cameraProp.Item1.ValueRO.startCameraRotation, cameraProp.Item1.ValueRO.shootCameraRotation, process);

                if(cameraProp.Item1.ValueRO.animationTime <= _timeLeft)
                {
                    state.EntityManager.SetComponentEnabled<CameraShootTag>(cameraProp.Item2, false);
                    _timeLeft = 0;
                }
            }
        }
    }
}