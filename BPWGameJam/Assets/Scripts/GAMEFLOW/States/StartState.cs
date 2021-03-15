using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : BaseState
{
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
        else if (GameManager.Instance.senior)
        {
            owner.SwitchState(typeof(SeniorState));
        }
    }
    public override void OnEnter()
    {

    }

    public override void OnExit()
    {

    }
}
