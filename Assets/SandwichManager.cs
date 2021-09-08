using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwichManager : MonoBehaviour
{
    public static SandwichManager instance;

    [HideInInspector]
    public int comboIngredients = 0;

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

        ScoreManager.instance.combo = 1f;
        comboIngredients = 0;
    }

    public void AddIngredient(GameObject up)
    {
        sandwich.Add(up);
        up.tag = "sandwich";
        OrderManager.instance.CheckNewOrded(up);

        AlimentsChoiceSpawner.instance.lastAlimentDrop = up;
        ScoreManager.instance.score += (up.GetComponent<Aliment>().points * ScoreManager.instance.combo);

        if (comboIngredients < 4)
            comboIngredients++;
        else
        {
            comboIngredients = 0;
            ScoreManager.instance.combo += 0.5f;
        }
    }


}
