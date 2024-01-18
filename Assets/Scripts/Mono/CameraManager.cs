using UnityEngine;

namespace Mono
{
    public class CameraManager : MonoBehaviour
    {
        public static CameraManager Instantiate;
        [SerializeField] private Camera Camera;
        public Camera GetMainCamera => Camera;
        void Awake() => Instantiate = this;
    }
}