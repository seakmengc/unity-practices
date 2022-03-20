using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State
{
    public enum STATES { IDLE, PATROL, PURSUE, ATTACK, SLEEP}

    public enum EVENTS { ENTER, UPDATE, EXIT }

    public STATES name;

    protected EVENTS stage;
    protected GameObject npc;
    protected NavMeshAgent navMeshAgent;
    protected Animator anim;
    protected Transform player;
    protected State nextState;

    float visDistance = 10;
    float visAngle = 30;
    float shootDistance = 7;

    public State(GameObject _npc, NavMeshAgent _navMeshAgent, Animator _anim, Transform _player)
    {
        npc = _npc;
        navMeshAgent = _navMeshAgent;
        anim = _anim;
        player = _player;
        stage = EVENTS.ENTER;
    }

    public virtual void Enter()
    {
        stage = EVENTS.ENTER;
    }

    public virtual void Update()
    {
        stage = EVENTS.UPDATE;
    }

    public virtual void Exit()
    {
        stage = EVENTS.EXIT;
    }

    public State Process()
    {
        switch(stage)
        {
            case EVENTS.ENTER:
                Enter();
                break;
            case EVENTS.UPDATE:
                Update();
                break;
            case EVENTS.EXIT:
                Exit();
                return nextState;
        }

        return this;
    }
}
