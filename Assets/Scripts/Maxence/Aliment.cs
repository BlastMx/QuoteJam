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

        if (collision.gameObject.tag == "sandwich" && gameObject.tag != "sandwich")
        {
            SandwichManager.instance.AddIngredient(gameObject);
            gameObject.tag = "sandwich";
        }
        else if (collision.gameObject.tag == "Untagged")
            SandwichManager.instance.RemoveIngredient(gameObject);


        /* Si touche �l�ment du sandwich
         * AlimentsChoiceSpawner.instance.lastAlimentDrop = gameObject;
         * ScoreManager.instance.score = ScoreManager.instance.score + (points * ScoreManager.instance.combo);
         */
    }
}
