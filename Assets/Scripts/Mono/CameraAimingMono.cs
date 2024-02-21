using Components;
using Unity.Entities;
using UnityEngine;

namespace Mono
{
    public class CameraAimingMono : MonoBehaviour
    {
        public Transform shootCameraTransform;
        public float animationTime;

        public class CameraAimingBaker : Baker<CameraAimingMono>
        {
            public override void Bake(CameraAimingMono authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);
                Transform cameraTransform = CameraSingleton.Instance.transform;
                
                AddComponent(entity,new CameraMovementProperties
                {
                    startCameraPosition = cameraTransform.position,
                    startCameraRotation = cameraTransform.rotation.eulerAngles,
                    shootCameraPosition = authoring.shootCameraTransform.position,
                    shootCameraRotation = authoring.shootCameraTransform.rotation.eulerAngles,
                    animationTime = authoring.animationTime
                });
                AddComponent<CameraShootTag>(entity);
                AddComponent<CameraUpgradeTag>(entity);
            }
        }
    }
}