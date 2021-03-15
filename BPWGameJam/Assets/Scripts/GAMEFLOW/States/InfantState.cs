using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfantState : BaseState
{
    public override void OnEnter()
    {
        Debug.Log("InfantState");
    }

    public override void OnExit()
    {
        
    }

    public override void OnUpdate()
    {
        if (GameManager.Instance.child)
        {
            owner.SwitchState(typeof(ChildState));
        }
        else if (GameManager.Instance.adult)
        {
            owner.SwitchState(typeof(AdultState));
        }
        else if (GameManager.Instance.senior)
        {
            owner.SwitchState(typeof(SeniorState));
        }
    }
}
