using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private IState currentState;

    public void ChangeState(IState newState)
    {
        currentState = newState;
        currentState.Enter();
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }
}

public interface IState
{
    Task Enter();
    void Update();
}

public class Idle : IState
{
    public async Task Enter()
    {
        Debug.Log("IDLE");
    }

    public void Update()
    {
        Debug.Log("Updating State Idle");
    }
}

public class Move : IState
{
    public async Task Enter()
    {
        Debug.Log("MOVE");
        // await till the action is complete
    }

    public void Update()
    {
        Debug.Log("Updating State Move");
    }

}

public class Stab : IState
{
    public async Task Enter()
    {
        Debug.Log("STAB");
    }
    public void Update()
    {
        Debug.Log("Updating State Stab");
    }
}

public class Slash : IState
{
    public async Task Enter()
    {
        Debug.Log("SLASH");
    }
    public void Update()
    {
        Debug.Log("Updating State Slash");
    }
}

public class Bash : IState
{
    public async Task Enter()
    {
        Debug.Log("BASH");
    }
    public void Update()
    {
        Debug.Log("Updating State Bash");
    }
}
public class Block : IState
{
    public async Task Enter()
    {
        Debug.Log("BLOCK");
    }
    public void Update()
    {
        Debug.Log("Updating State Block");
    }
}

public class KillHim : IState
{
    public async Task Enter()
    {
        Debug.Log("KILL FINISH");
    }
    public void Update()
    {
        Debug.Log("Updating State kill finish");
    }
}

public class SpareHim : IState
{
    public async Task Enter()
    {
        Debug.Log("SPARE FINISH");
    }
    public void Update()
    {
        Debug.Log("Updating State spare finish");
    }
}
