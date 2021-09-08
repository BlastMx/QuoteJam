using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningAliment : MonoBehaviour
{
    private int moveCount;

    public Transform arrow;
    public CameraFollow cameraScript;

    public static SpawningAliment instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        Spawning();
    }

    private void Spawning()
    {
        if (!AlimentsChoiceSpawner.instance.canLandAliments)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AlimentsChoiceSpawner.instance.canLandAliments = false;

            GameObject aliment = Instantiate(AlimentsChoiceSpawner.instance.currentAliment);

            aliment.transform.position = arrow.position;
            aliment.SetActive(true);
            MoveCamera();
        }

    }


    public void MoveCamera()
    {
        moveCount++;


        if (moveCount == 5)
        {
            moveCount = 0;
            cameraScript.targetPos.y += 2f;
        }
    }
}
