using Unity.Entities;
using Unity.Physics;

namespace Systems
{
    public partial class TestPhysicsAreaSystem : SystemBase
    {
        private GameUiData _uiData;

        protected override void OnUpdate()
        {
            foreach (var uiData in SystemAPI.Query<GameUiData>())
            {
                CheckedStateRef.Enabled = false;
                
                _uiData = uiData;
                
                uiData.nextButton.onClick.AddListener(NextStepPhysics);
                uiData.previousButton.onClick.AddListener(PreviousStepPhysics);
                
                UpdateCurrentNumber();
            }
        }

        private void UpdateCurrentNumber()
        {
            foreach (var physicsData in SystemAPI.Query<RefRW<PhysicsStep>>())
            {
                _uiData.stepName.text = physicsData.ValueRW.SolverIterationCount.ToString();
            }
        }

        private void NextStepPhysics()
        {
            foreach (var physicsData in SystemAPI.Query<RefRW<PhysicsStep>>())
            {
                physicsData.ValueRW.SolverIterationCount++;
            }
            
            UpdateCurrentNumber();
        }

        private void PreviousStepPhysics()
        {
            foreach (var physicsData in SystemAPI.Query<RefRW<PhysicsStep>>())
            {
                physicsData.ValueRW.SolverIterationCount--;
            }
            
            UpdateCurrentNumber();
        }
    }
}