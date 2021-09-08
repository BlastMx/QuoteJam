using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed = 7f;

    [Header("AccelertionEvent")]
    [SerializeField] private float eventSpeed = 10f;
    [SerializeField] private float timeOfAcceleration = 3f;
    [SerializeField] private float timeBetweenSpeedEvent = 10f;

    [Header("StopEvent")]
    [SerializeField] private float timeOfStop = 1f;
    [SerializeField] private float timeBetweenStopEvent = 25f;

    [Space]
    [SerializeField] private Transform[] waypoints = new Transform[0];

    public const string HORIZONTAL_NAME = "Horizontal";

    private int index;
    private int moveIndex = 1;
    private float speedEventCounter;
    private float  stopEventCounter;

    private Coroutine currentCoroutine = null;
    //private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        MoveBetweenWaypoints();
        AccelerateEvent();
        StopEvent();
    }

    private void MoveBetweenWaypoints()
    {
        if (!AlimentsChoiceSpawner.instance.canLandAliments)
            return;

        Vector3 nextPosition = waypoints[index].position;

        // TO DO -> accelerate the speed with time 
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);

        if (transform.position == nextPosition)
        {
            index += moveIndex;

            if (index == 0 || index == waypoints.Length - 1)
                moveIndex *= -1;
        }
    }


    private void AccelerateEvent()
    {
        //il faudrait que elapsedTime ne s'incremente que quand la fléche est visible et pas quand on doit choisir
        speedEventCounter += Time.deltaTime;
        if (speedEventCounter >= timeBetweenSpeedEvent && currentCoroutine == null)
        {
            currentCoroutine = StartCoroutine(AccelerationCoroutine());
        }
    }

    private IEnumerator AccelerationCoroutine()
    {
        float currentSpeed = speed;
        speed = eventSpeed;
        yield return new WaitForSeconds(timeOfAcceleration);

        speed = currentSpeed;
        currentCoroutine = null;
        speedEventCounter = 0f;
    }


    private void StopEvent()
    {
        stopEventCounter += Time.deltaTime;
        if (stopEventCounter >= timeBetweenStopEvent && currentCoroutine == null)
        {
            currentCoroutine = StartCoroutine(StopCoroutine());
        }
    }

    private IEnumerator StopCoroutine()
    {
        float currentSpeed = speed;
        speed = 0f;
        yield return new WaitForSeconds(timeOfStop);

        speed = currentSpeed;
        currentCoroutine = null;
        stopEventCounter = 0f;
    }
}
