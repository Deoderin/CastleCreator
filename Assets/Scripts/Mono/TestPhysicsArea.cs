using TMPro;
using UnityEngine;
using UnityEngine.Events;
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
        
        public Button GetNextButton {get;private set;}        
        public Button GetPreviousButton {get;private set;}
        public TextMeshProUGUI GetNumText {get;private set;}

        private void Awake()
        {
            GetNextButton = _nextButton;
            GetPreviousButton = _previousButton;
            GetNumText = _numText;
        }
    }
}