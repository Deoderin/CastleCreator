using Unity.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Systems
{
    public partial struct RestartSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                //CleanAndRestartECS();
            }
        }
        
        public void CleanAndRestartECS()
        {
            var defaultWorld = World.DefaultGameObjectInjectionWorld;
            defaultWorld.EntityManager.CompleteAllTrackedJobs();
            foreach (var system in defaultWorld.Systems)
            {
                system.Enabled = false;
            }
            defaultWorld.Dispose();
            DefaultWorldInitialization.Initialize("Tower", false);
            if (!ScriptBehaviourUpdateOrder.IsWorldInCurrentPlayerLoop(World.DefaultGameObjectInjectionWorld))
            {
                ScriptBehaviourUpdateOrder.AppendWorldToCurrentPlayerLoop(World.DefaultGameObjectInjectionWorld);
            }  
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
    }
}