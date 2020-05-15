using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        IAction currentAction;

        public void StartAction(IAction action)
        {
            if(currentAction == action) return;

            CancelCurrentAction();
            currentAction = action;            
        }

        public void CancelCurrentAction()
        {
            if(currentAction != null) 
            {
                currentAction.Cancel();
            }
        }
    }
}
