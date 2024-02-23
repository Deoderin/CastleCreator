using Unity.Entities;
using UnityEngine;

namespace Mono
{
    public class InputProvider : MonoBehaviour
    {
        public Joystick _horizontalJoystick;
        public Joystick _verticalJoystick;
        
        public static InputProvider Instance;
        
        private void Awake()
        {
            Instance = this;
        }
    }
}