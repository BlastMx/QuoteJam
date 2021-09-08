using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private float eventSpeed = 10f;
    [SerializeField] private float timeOfAcceleration = 3f;
    [SerializeField] private Transform[] waypoints = new Transform[0];

    public const string HORIZONTAL_NAME = "Horizontal";

    private int index;
    private int moveIndex = 1;
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
        //if randomEvent 

        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(AccelerationCoroutine());
        }
    }

    private IEnumerator AccelerationCoroutine()
    {
        float currentSpeed = speed;
        speed = eventSpeed;

        yield return new WaitForSeconds(timeOfAcceleration);

        speed = currentSpeed;
    }
}
