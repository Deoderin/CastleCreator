using System;
using Mono;
using TMPro;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace Systems
{
    public partial struct GameUiInitSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            state.Enabled = false;
            GameObject go = GameObject.Find("TestArea");
            
            if(go == null)
            {
                throw new Exception("gm NOT FOUND");
            }

            TestPhysicsArea gameUi = go.GetComponent<TestPhysicsArea>();
            GameUiData gameUiDataData = new GameUiData()
            {
                stepName = gameUi.GetNumText,
                nextButton = gameUi.GetNextButton,
                previousButton = gameUi.GetPreviousButton
            };

            Entity entity = state.EntityManager.CreateEntity();
            state.EntityManager.AddComponentData(entity, gameUiDataData);
        }
    }

    public class GameUiData : IComponentData
    {
        public TextMeshProUGUI stepName;
        public Button nextButton;
        public Button previousButton;
    }
}