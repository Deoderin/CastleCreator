using Unity.Entities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Mono
{
    public class InputProvider : MonoBehaviour
    {
        public static UnityAction shoot;
        
        public Joystick _horizontalJoystick;
        public Joystick _verticalJoystick;

        public Button _shootButton;
        
        public static InputProvider Instance;
        
        private void Awake()
        {
            Instance = this;
            _shootButton.onClick.AddListener(shoot.Invoke);
        }
    }
}