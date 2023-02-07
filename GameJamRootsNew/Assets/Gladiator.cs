using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gladiator : MonoBehaviour
{
    StateMachine stateMachine = new StateMachine();

    public void Start()
    {
        stateMachine.ChangeState(new Idle());
    }

    public void Update()
    {
        
        //if (Dictation.wordsQueue.Count > 0)
        //{

        //}
    }
}


