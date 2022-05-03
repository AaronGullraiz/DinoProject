using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingDino : DinoBase
{

    private bool isWalkingToPlayer = false;

    private void Start()
    {
        base.Start();
    }

    protected override void OnTargetReached()
    {
        base.OnTargetReached();
        if (isWalkingToPlayer)
        {
            SetAnimationState(DinoAnimState.BITE);
            DinosManager.Instance.DinoAttackedPlayer(this);
            StopDino();
        }
        else if (isLastPointReached())
        {
            Invoke("WalkTowardsPlayer", 3);
        }
    }

    private void WalkTowardsPlayer()
    {
        isWalkingToPlayer = true;
        SetNavAgentStopingDistance(5);
        SetNavmeshTarget(DinosManager.Instance.player.transform);
    }

    public override void OnOtherDinoHit()
    {
        SetAnimationState(DinoAnimState.BITE);
        Invoke("StartMoving", 2.5f);
    }

    private void StartMoving()
    {
        base.SetNavmeshTarget(waypoints[0]);
    }

    protected override void OnDinoBulletHit()
    {
        Invoke("StartMoving", 4);
    }
}