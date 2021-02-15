public class StateMachine<T>
{
    #region Variables
    private T owner;
    private FSMState<T> currentState = null;
    #endregion

    #region Properties
    public FSMState<T> CurrentState { get { return currentState; } }
    public T Owner { get { return owner; } }
    #endregion

    #region Methods
    public void Configure(T owner, FSMState<T> state)
    {
        this.owner = owner;
        ChangeState(state);
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.Execute(owner);
        }
    }

    public void ChangeState(FSMState<T> newState)
    {
        if (currentState != null)
        {
            currentState.Exit(owner);
        }
        currentState = newState;
        if (newState != null)
        {
            currentState.Enter(owner);
        }
    }
    #endregion
}