using UnityEngine;

public class NpcStateMachine : StateMachine<Npc>
{
    public class NpcIdle : FSMState<Npc>
    {
        public override void Enter(Npc entity)
        {
            entity.agent.ResetPath();
            entity.agent.isStopped = true;
        }

        #region Execute and Exit
        public override void Execute(Npc entity)
        {

        }

        public override void Exit(Npc entity)
        {

        }
        #endregion Execute and Exit

    }

    public class NpcWalk : FSMState<Npc>
    {
        public override void Enter(Npc entity)
        {

            Terrain terrain = new Terrain();
            Vector3 pos = new Vector3(Random.Range(terrain.GetPosition().x, terrain.GetPosition().x + terrain.terrainData.bounds.size.x), 0.0f, Random.Range(terrain.GetPosition().z, terrain.GetPosition().z + terrain.terrainData.bounds.size.z));

            entity.agent.speed = 3.0f;
            entity.agent.isStopped = false;
            entity.agent.SetDestination(pos);
            entity.npcStateMachine.ChangeState(new NpcStateMachine.NpcWalk());

        }

        #region Execute and Exit
        public override void Execute(Npc entity)
        {

        }

        public override void Exit(Npc entity)
        {

        }
        #endregion Execute and Exit

    }

    public class NpcRun : FSMState<Npc>
    {
        public override void Enter(Npc entity)
        {

            Terrain terrain = new Terrain();
            Vector3 pos = new Vector3(Random.Range(terrain.GetPosition().x, terrain.GetPosition().x + terrain.terrainData.bounds.size.x), 0.0f, Random.Range(terrain.GetPosition().z, terrain.GetPosition().z + terrain.terrainData.bounds.size.z));

            entity.agent.speed = 8.0f;
            entity.agent.isStopped = false;
            entity.agent.SetDestination(pos);

        }

        #region Execute and Exit
        public override void Execute(Npc entity)
        {

        }

        public override void Exit(Npc entity)
        {

        }
        #endregion Execute and Exit

    }
}
