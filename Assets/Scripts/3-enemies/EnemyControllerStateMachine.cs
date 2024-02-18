using UnityEngine;

/**
 * This component patrols between given points, chases a given target object when it sees it, and rotates from time to time.
 */
[RequireComponent(typeof(Patroller))]
[RequireComponent(typeof(Chaser))]
[RequireComponent(typeof(Rotator))]
[RequireComponent(typeof(Booster))]
[RequireComponent(typeof(Invisibility))]
public class EnemyControllerStateMachine: StateMachine {
    [SerializeField] float radiusToWatch = 5f;
    [SerializeField] float radiusToBoostSpeed = 3f;
    [SerializeField] float probabilityToRotate = 0.2f;
    [SerializeField] float probabilityToStopRotating = 0.2f;
    [SerializeField] float probabilityToBeInvisible = 0.3f;
    [SerializeField] float probabilityToStopBeInvisible = 0.5f;


    private Chaser chaser;
    private Patroller patroller;
    private Rotator rotator;
    private Booster booster;
    private Invisibility invisibillity;

    private float DistanceToTarget() {
        return Vector3.Distance(transform.position, chaser.TargetObjectPosition());
    }

    private void Awake() {
        chaser = GetComponent<Chaser>();
        patroller = GetComponent<Patroller>();
        rotator = GetComponent<Rotator>();
        booster = GetComponent<Booster>();
        invisibillity = GetComponent<Invisibility>();
        base
        .AddState(patroller)     // This would be the first active state.
        .AddState(chaser)
        .AddState(rotator)
        .AddState(booster)
        .AddState(invisibillity)
        .AddTransition(patroller, () => DistanceToTarget()<=radiusToWatch, chaser)
        .AddTransition(rotator,   () => DistanceToTarget()<=radiusToWatch, chaser)
        .AddTransition(patroller,   () => Random.Range(0f, 1f) < probabilityToBeInvisible * Time.deltaTime, invisibillity)
        .AddTransition(rotator,   () => Random.Range(0f, 1f) < probabilityToBeInvisible * Time.deltaTime, invisibillity)
        .AddTransition(invisibillity ,   () => Random.Range(0f, 1f) < probabilityToStopBeInvisible * Time.deltaTime, rotator)
        .AddTransition(invisibillity ,   () => Random.Range(0f, 1f) < probabilityToStopBeInvisible * Time.deltaTime, patroller)
        .AddTransition(invisibillity ,   () => DistanceToTarget()<=radiusToWatch, chaser)
        .AddTransition(chaser ,   () => DistanceToTarget()>=radiusToWatch, invisibillity)
        .AddTransition(chaser,   () => DistanceToTarget()<=radiusToBoostSpeed, booster)
        .AddTransition(booster,   () => DistanceToTarget()>=radiusToBoostSpeed && DistanceToTarget()<=radiusToWatch, chaser)
        .AddTransition(chaser,    () => DistanceToTarget() > radiusToWatch,  patroller)
        .AddTransition(rotator,   () => Random.Range(0f, 1f) < probabilityToStopRotating * Time.deltaTime, patroller)
        .AddTransition(patroller, () => Random.Range(0f, 1f) < probabilityToRotate       * Time.deltaTime, rotator)
        ;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusToWatch);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radiusToBoostSpeed);
    }
}
 