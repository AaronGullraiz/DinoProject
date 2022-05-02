using NeoFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class DinoBase : MonoBehaviour, IDamageHandler
{
    #region Attributes

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private Collider collider;

    [Space]
    [SerializeField]
    private NavMeshAgent navAgent;
    [SerializeField]
    private float rotationSpeed, runSpeed;
    [SerializeField]
    private float walkSpeed;

    [Space]
    [SerializeField]
    private bool informOthers;
    [SerializeField]
    private float dinoHealthDamageMultiplier = 0.25f;
    [SerializeField]
    private float dinoHealthValue;

    public Transform[] waypoints;

    #endregion

    #region Variables

    private DinoAnimState currentAnimState = DinoAnimState.IDLE;
    private bool isBulletHit = false;
    private IEnumerator routine;
    private int currentTarget = 0;
    private Transform currentNavTarget;
    private bool isAlive = true;
    private bool isHit = false;

    private float hitWaitTime = 2;
    private float hitWait;

    #endregion

    #region MonoBehaviour
    protected void Start()
    {
    }
    #endregion

    #region Animations
    public void SetAnimationState(DinoAnimState state)
    {
        currentAnimState = state;
        anim.SetInteger("State", (int)state);
    }
    #endregion

    #region NavMesh
    public void SetNavmeshTarget(Transform target)
    {
        if (isAlive)
        {
            currentNavTarget = target;
            navAgent.SetDestination(target.position);
            SetAnimationState(DinoAnimState.WALK);

            if (routine != null)
            {
                StopCoroutine(routine);
            }
            routine = Move();
            StartCoroutine(routine);
        }
    }

    protected void SetNavAgentStopingDistance(float distance)
    {
        navAgent.stoppingDistance = distance;
    }

    IEnumerator Move()
    {
        yield return new WaitForEndOfFrame();
        while (isAlive)
        {
            if (isHit)
            {
                hitWait -= Time.deltaTime;
                if (!navAgent.isStopped)
                {
                    navAgent.isStopped = true;
                }
                if(hitWait <= 0)
                {
                    navAgent.isStopped = false;
                    isHit = false;
                }
                continue;
            }
            yield return new WaitForEndOfFrame();
            if (!float.IsInfinity(navAgent.remainingDistance))
            {
                if(navAgent.remainingDistance > 4)
                {
                    navAgent.speed = runSpeed;
                    if (currentAnimState != DinoAnimState.RUN)
                    {
                        SetAnimationState(DinoAnimState.RUN);
                    }
                }
                else
                {
                    navAgent.speed = walkSpeed;
                    if (currentAnimState != DinoAnimState.WALK)
                    {
                        SetAnimationState(DinoAnimState.WALK);
                    }
                }
                if (navAgent.remainingDistance < navAgent.stoppingDistance)
                {
                    yield return new WaitForEndOfFrame();
                    break;
                }
            }
        }
        while (isAlive && Vector3.Angle(transform.forward, currentNavTarget.position - transform.position) > 10f)
        {
            SetAnimationState(DinoAnimState.IDLE);
            yield return new WaitForEndOfFrame();
            transform.forward = Vector3.Lerp(transform.forward, currentNavTarget.position - transform.position, Time.deltaTime*rotationSpeed);
        }

        if (isAlive)
        {
            OnTargetReached();
            routine = null;
        }
    }

    protected virtual void OnTargetReached()
    {
        if (isAlive)
        {
            SetAnimationState(DinoAnimState.IDLE);
            if (!isLastPointReached())
            {
                Invoke("WalkToNextTarget", 2);
            }
        }
    }

    private void WalkToNextTarget()
    {
        if (waypoints.Length > 0)
        {
            SetNavmeshTarget(waypoints[currentTarget]);
        }
        currentTarget ++;
        //currentTarget = (currentTarget + 1) % waypoints.Length;
    }

    protected void StopDino()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
            navAgent.isStopped = true;
            navAgent.enabled = false;
            var angle = transform.localEulerAngles;
            angle.x = angle.z = 0;
            transform.localEulerAngles = angle;
            collider.enabled = false;
        }
    }
    #endregion

    #region Collision
    private void OnCollisionEnter(Collision collision)
    {
        if (isBulletHit)
        {
            return;
        }
        if (collision.gameObject.CompareTag(Tags.Bullets.ToString()))
        {
            isBulletHit = true;
            SetAnimationState(DinoAnimState.DEATH);
            if (informOthers)
            {
                DinosManager.Instance.InformOthers(this);
            }
            BehaviourAfterHit();
        }
        else if (collision.gameObject.CompareTag(Tags.Player.ToString()))
        {
            AttackPlayer();
        }
    }

    protected bool isLastPointReached()
    {
        return currentTarget >= waypoints.Length;
    }

    protected void AttackPlayer()
    {
        SetAnimationState(DinoAnimState.BITE);
    }

    private void BehaviourAfterHit()
    {

    }
    #endregion

    #region Others

    public abstract void OnOtherDinoHit();

    #endregion

    #region DamageHandler

    public DamageFilter inDamageFilter { get; set; }

    public DamageResult AddDamage(float damage)
    {
        OnDinoHit(damage);
        return DamageResult.Ignored;
    }

    public DamageResult AddDamage(float damage, RaycastHit hit)
    {
        OnDinoHit(damage);
        return DamageResult.Ignored;
    }

    public DamageResult AddDamage(float damage, IDamageSource source)
    {
        OnDinoHit(damage);
        return DamageResult.Ignored;
    }

    public DamageResult AddDamage(float damage, RaycastHit hit, IDamageSource source)
    {
        OnDinoHit(damage);
        return DamageResult.Ignored;
    }

    private void OnDinoHit(float damage)
    {
        if (isAlive)
        {
            isHit = true;
            DinosManager.Instance.InformOthers(this);
            dinoHealthValue -= (damage * dinoHealthDamageMultiplier);
            HUD.Instance.UpdateDinoFillerValue(dinoHealthValue);
            if (dinoHealthValue <= 0)
            {
                isAlive = false;
                SetAnimationState(DinoAnimState.DEATH);
                StopDino();
                DinosManager.Instance.DinoDied(this);
                return;
            }
            else
            {
                SetAnimationState(DinoAnimState.BITE);
            }
        }
    }

    #endregion
}