using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public NavMeshAgent agent;
    public int mushrooms = 0;
    public PlayerStateMachine stateMachine = new PlayerStateMachine();

    private void Start()
    {
        stateMachine.Configure(this, new PlayerStateMachine.Idle());
    }
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        #region Movement
        #region Walk
        if (Input.GetMouseButton(0)) //walk
        {
            stateMachine.ChangeState(new PlayerStateMachine.Walk());
        }
        #endregion Walk
        #region Run
        if (Input.GetMouseButton(1)) //run
        {
            stateMachine.ChangeState(new PlayerStateMachine.Walk());
        }
        #endregion Run
        #region Stop
        if (Input.GetKeyDown(KeyCode.Space)) //stop
        {
       
            stateMachine.ChangeState(new PlayerStateMachine.Idle());
           
        }
    }
    #endregion Stop
    #endregion Movement
}

