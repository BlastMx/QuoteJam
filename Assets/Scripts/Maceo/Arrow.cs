using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private Transform[] waypoints = new Transform[0];

    public const string HORIZONTAL_NAME = "Horizontal";

    private int index;
    private int moveIndex = 1;
    //private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        MoveBetweenWaypoints();
    }

    private void MoveBetweenWaypoints()
    {
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
}
