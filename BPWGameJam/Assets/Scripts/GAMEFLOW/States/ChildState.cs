using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildState : BaseState
{
    public override void OnEnter()
    {
        Debug.Log("ChildState");
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
