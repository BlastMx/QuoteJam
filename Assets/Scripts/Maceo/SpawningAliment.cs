using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningAliment : MonoBehaviour
{
    public Transform arrow;

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
            GameObject aliment = Instantiate(AlimentsChoiceSpawner.instance.currentAliment);

            aliment.transform.position = arrow.position;
            aliment.SetActive(true);

            TimerManager.instance.reset = true;
        }
    }
}
