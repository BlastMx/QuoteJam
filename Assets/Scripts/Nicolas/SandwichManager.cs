using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwichManager : MonoBehaviour
{
    public static SandwichManager instance;

    public List<GameObject> sandwich;

    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }

    public void RemoveIngredient(GameObject fall)
    {
        sandwich.Remove(fall);
        fall.tag = "Untagged";
        OrderManager.instance.CheckFallOrder(fall);
    }

    public void AddIngredient(GameObject up)
    {
        sandwich.Add(up);
        up.tag = "sandwich";
        OrderManager.instance.CheckNewOrded(up);
    }


}
