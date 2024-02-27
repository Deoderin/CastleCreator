using System;
using UnityEngine;
using UnityEngine.UI;

namespace Mono
{
    public class ShootButton : MonoBehaviour
    {
        public static Action shoot;
        [SerializeField]
        private Button _shootButton;
        
        private void Awake()
        {
            _shootButton.onClick.AddListener(shoot.Invoke);
        }
    }
}