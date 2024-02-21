using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    public struct CameraMovementProperties : IComponentData
    {
        public float3 shootCameraPosition;
        public float3 shootCameraRotation;
        public float3 startCameraPosition;
        public float3 startCameraRotation;        
        public float animationTime;
    }
    public struct CameraShootTag : IComponentData, IEnableableComponent {}    
    public struct CameraUpgradeTag : IComponentData, IEnableableComponent {}
}