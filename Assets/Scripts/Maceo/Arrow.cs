using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed = 7f;

    public const string HORIZONTAL_NAME = "Horizontal";

    private Vector3 velocity = Vector3.zero;

    //private void Start()
    //{
    //}

    private void Update()
    {
        //Debug.Log(Input.GetAxis(HORIZONTAL_NAME));
        velocity.x += Input.GetAxis(HORIZONTAL_NAME) * speed * Time.deltaTime;
        velocity.y = 6f;

        velocity.x = Mathf.Clamp(velocity.x, -7f, 7f);
        transform.position = velocity;

        
        
    }
}
