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
            LevelsManager.Instance.dinosManager.DinoAttackedPlayer(this);
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
        SetNavmeshTarget(LevelsManager.Instance.player.transform);
    }

    public override void OnOtherDinoHit()
    {
        SetAnimationState(DinoAnimState.BITE);
        Invoke("StartMoving", 2.5f);
    }

    private void StartMoving()
    {
        if (waypoints.Length > 0)
        {
            base.SetNavmeshTarget(waypoints[0]);
        }
        else
        {
            base.SetNavmeshTarget(LevelsManager.Instance.player.transform);
        }
    }

    protected override void OnDinoBulletHit()
    {
        Invoke("StartMoving", 4);
    }
}