using UnityEngine;
using UnityEngine.Serialization;

namespace Mono
{
    public class CameraSingleton : MonoBehaviour
    {
        [SerializeField]
        private Camera _mainCamera;
        public static Camera Instance;
        
        public void Awake()
        {
            Instance = _mainCamera;
        }
    }
}