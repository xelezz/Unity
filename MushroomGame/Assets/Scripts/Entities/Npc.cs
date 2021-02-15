using UnityEngine;
using UnityEngine.AI;

public class Npc : MonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField] private float NpcCounter = 0.0f;
    public NpcStateMachine npcStateMachine = new NpcStateMachine();

    void Start()
    {
        NpcCounter = 5.0f;
        npcStateMachine.Configure(this, new NpcStateMachine.NpcIdle());
    }

    void Update()
    {
        #region NpcMovement
        NpcMovement();
        #endregion NpcMovement
    }

    private void NpcMovement()
    {
            int rand = Random.Range(0, 3);
        #region Movement
        NpcCounter -= Time.deltaTime;
        if (NpcCounter < 0.0f)
        {
            #region Walk
            if (rand == 0) //walk
            {
                npcStateMachine.ChangeState(new NpcStateMachine.NpcWalk());
            }
            #endregion Walk
            #region Run
            if (rand == 1) //run
            {
                npcStateMachine.ChangeState(new NpcStateMachine.NpcRun());
            }
            #endregion Run
            #region Stop
            if (rand == 2) //stop
            {
                npcStateMachine.ChangeState(new NpcStateMachine.NpcIdle());
            }
            NpcCounter = 5.0f;
            #endregion Stop
        }
    }
    #endregion Movement
}


