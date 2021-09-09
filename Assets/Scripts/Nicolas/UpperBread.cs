using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperBread : MonoBehaviour
{
    Vector3 set;
    public bool stop = false;

    public static UpperBread instance;

    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    private void Update()
    {
        if (stop)
        {
           gameObject.transform.position = set;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!stop)
        {
            set = gameObject.transform.position;
            stop = true;
        }

    }
}
