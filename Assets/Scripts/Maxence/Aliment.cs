using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliment : MonoBehaviour
{
    public float points = 0f;

    [SerializeField] private Rigidbody rigidbodyAliment;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("touch");
        AlimentsChoiceSpawner.instance.AttributionIngredients();

        /* Si touche élément du sandwich
         * AlimentsChoiceSpawner.instance.lastAlimentDrop = gameObject;
         * ScoreManager.instance.score = ScoreManager.instance.score + (points * ScoreManager.instance.combo);
         */
    }
}
