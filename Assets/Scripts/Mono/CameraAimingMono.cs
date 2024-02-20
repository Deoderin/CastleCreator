using Components;
using Unity.Entities;
using UnityEngine;

namespace Mono
{
    public class CameraAimingMono : MonoBehaviour
    {
        public Camera mainCamera;
        public Transform shootCameraTransform;

        public class CameraAimingBaker : Baker<CameraAimingMono>
        {
            public override void Bake(CameraAimingMono authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);

                AddComponent(entity,new CameraMovementProperties
                {
                    camera = GetEntity(authoring.mainCamera, TransformUsageFlags.Dynamic),
                    startCameraPosition = authoring.mainCamera.transform.position,
                    startCameraRotation = authoring.mainCamera.transform.rotation.eulerAngles,
                    //shootCameraPosition = authoring.shootCameraPosition.position
                });
            }
        }
    }
}