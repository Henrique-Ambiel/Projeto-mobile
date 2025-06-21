using UnityEngine;

public class StateMachine
{
    public IState CurrentState { get; private set; }

    private MonoBehaviour owner;

    public StateMachine(MonoBehaviour owner)
    {
        this.owner = owner;
    }

    public void ChangeState(IState newState)
    {
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }

    public void Update()
    {
        CurrentState?.Update();
    }
}
