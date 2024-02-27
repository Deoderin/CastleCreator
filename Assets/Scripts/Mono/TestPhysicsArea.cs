using TMPro;
using Unity.Entities;
using Unity.Physics;
using UnityEngine;
using UnityEngine.UI;

namespace Mono
{
    public class TestPhysicsArea : MonoBehaviour
    {
        [SerializeField]
        private Button _nextButton;        
        [SerializeField]
        private Button _previousButton;

        [SerializeField]
        private TextMeshProUGUI _numText;

        public void Awake()
        {
            _nextButton.onClick.AddListener(AddPhysicStep); 
            _previousButton.onClick.AddListener(MinusPhysicStep);
        }

        private void AddPhysicStep()
        {
            foreach (var datas in SystemAPI.Query<PhysicsStep>())
            {
                
            }
        }        
        
        private void MinusPhysicStep()
        {
            
        }
    }
}