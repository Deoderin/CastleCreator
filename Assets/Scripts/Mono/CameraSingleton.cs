using UnityEngine;

namespace Mono
{
    public class CameraSingleton : MonoBehaviour
    {
        [SerializeField]
        private Camera _mainCamera;
        public static Camera Instance;
        
        public void Awake()
        {
            if(Instance == null)
            {
                Instance = _mainCamera;
            }
        }
    }
}