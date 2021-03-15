using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowAgent : MonoBehaviour
{
    private FSM fsm;

    void Start()
    {
        fsm = new FSM(typeof(StartState), GetComponents<BaseState>()); //Starting state, with getcomponentSSS because multiple states are being used
    }

    void Update()
    {
        fsm.OnUpdate();
    }
}
