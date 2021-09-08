using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [HideInInspector]
    public Vector3 targetPos;

    public Transform lowerBread;

    private void Start()
    {
        targetPos = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, 1f * Time.deltaTime);
    }
}
