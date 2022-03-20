using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : State
{
    public IdleState(GameObject _npc, NavMeshAgent _navMeshAgent, Animator _anim, Transform _player) : base(_npc, _navMeshAgent, _anim, _player)
    {
        name = STATES.IDLE;
    }
}
