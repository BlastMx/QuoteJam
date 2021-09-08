using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed = 7f;

    [Header("AccelertionEvent")]
    [SerializeField] private float eventSpeed = 10f;
    [SerializeField] private float timeOfAcceleration = 3f;
    [SerializeField] private float timeBetweenEvent = 10f;

    [Space]
    [SerializeField] private Transform[] waypoints = new Transform[0];

    public const string HORIZONTAL_NAME = "Horizontal";

    private int index;
    private int moveIndex = 1;
    private float elaspedTime;

    private Coroutine currentCoroutine = null;
    //private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        MoveBetweenWaypoints();
        AccelerateEvent();
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
        elaspedTime += Time.deltaTime;
        if (elaspedTime >= timeBetweenEvent && currentCoroutine == null)
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
        elaspedTime = 0f;

    }
}
