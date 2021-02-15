using UnityEngine;

public class PlayerStateMachine : StateMachine<Player>
{
    public class Idle : FSMState<Player>
    {
        public override void Enter(Player entity)
        {
            entity.agent.ResetPath();
        }
        #region Execute and Exit
        public override void Execute(Player entity)
        {
            
        }

        public override void Exit(Player entity)
        {
            
        }
        #endregion Execute and Exit

    }
    public class Walk : FSMState<Player>
        {
        public override void Enter(Player entity)
        {
            RaycastHit groundHit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out groundHit, Mathf.Infinity))
            {
                entity.agent.speed = 3.0f;
                entity.agent.isStopped = false;
                entity.agent.SetDestination(groundHit.point);
            }
        }
        #region Execute and Exit
        public override void Execute(Player entity)
        {

        }

        public override void Exit(Player entity)
        {

        }
        #endregion Execute and Exit

    }


    public class Run : FSMState<Player>
    {
        public override void Enter(Player entity)
        {

            RaycastHit groundHit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out groundHit, Mathf.Infinity))
            {
                entity.agent.speed = 8.0f;
                entity.agent.isStopped = false;
                entity.agent.SetDestination(groundHit.point);
            }

        }

        #region Execute and Exit
        public override void Execute(Player entity)
        {

        }

        public override void Exit(Player entity)
        {

        }
        #endregion Execute and Exit 

    }

}