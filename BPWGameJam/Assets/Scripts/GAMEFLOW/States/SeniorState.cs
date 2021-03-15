using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeniorState : BaseState
{
    public override void OnEnter()
    {
        Debug.Log("SeniorState");
    }
    public override void OnExit()
    {

    }
    public override void OnUpdate()
    {
        if (GameManager.Instance.infant)
        {
            owner.SwitchState(typeof(InfantState));
        }
        else if (GameManager.Instance.child)
        {
            owner.SwitchState(typeof(ChildState));
        }
        else if (GameManager.Instance.adult)
        {
            owner.SwitchState(typeof(AdultState));
        }
    }
}
