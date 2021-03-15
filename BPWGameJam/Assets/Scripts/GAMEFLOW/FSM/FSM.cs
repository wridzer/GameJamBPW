using System.Collections;
using System.Collections.Generic;

public class FSM
{
    private Dictionary<System.Type, BaseState> stateDictionary = new Dictionary<System.Type, BaseState>();
    private BaseState currentState;
    public FSM(System.Type startState, params BaseState[] states)
    {
        foreach (BaseState state in states)
        {
            state.Initalize(this);
            stateDictionary.Add(state.GetType(), state);
        }
        SwitchState(startState);
    }
    public void OnUpdate()
    {
        currentState?.OnUpdate();
    }
    public void SwitchState(System.Type newStateType)
    {
        currentState?.OnExit();
        currentState = stateDictionary[newStateType];
        currentState?.OnEnter();
    }
}