using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliment : MonoBehaviour
{
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
        {
            SandwichManager.instance.RemoveIngredient(gameObject);

            if(TimerManager.instance.reset)
            {
                TimerManager.instance.reset = false;
                TimerManager.instance.TimeLess(TimerManager.instance.timeLess);
            }

        }


    }
}
