using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliment : enumIngredients
{
    public float points = 0f;

    [SerializeField] private Rigidbody rigidbodyAliment;

    private bool move = true;
    private bool alreadyFallen = false;

    private void Awake()
    {
        rigidbodyAliment = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        AfterCollisionImpact();
        Debug.Log(gameObject.name + " " + move);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "sandwich" && gameObject.tag != "sandwich")
        {
            gameObject.tag = "sandwich";
        }
        else if (collision.gameObject.tag == "Untagged")
        {
            gameObject.tag = "Untagged";

            if(alreadyFallen)
                SandwichManager.instance.RemoveIngredient(gameObject);

            StartCoroutine(DestroyObject());
        }
    }

    void AfterCollisionImpact()
    {
        if (rigidbodyAliment.IsSleeping() && move)
        {
            move = false;
            alreadyFallen = true;

            if (gameObject.CompareTag("sandwich"))
            {
                SandwichManager.instance.AddIngredient(gameObject);
            }
            else if (gameObject.CompareTag("Untagged"))
            {
                SandwichManager.instance.RemoveIngredient(gameObject);
            }

            AlimentsChoiceSpawner.instance.AttributionIngredients();
        }
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
