using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwichManager : MonoBehaviour
{
    public static SandwichManager instance;

    [HideInInspector]
    public int comboIngredients = 0;

    public CameraFollow cameraScript;

    public List<GameObject> sandwich;

    private int moveCount;

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

        if (fall.GetComponent<Aliment>().ingredientsDisponible != enumIngredients.IngredientsDisponible.Salade)
        {
            ScoreManager.instance.combo = 1f;
            comboIngredients = 0;
        }
    }

    public void AddIngredient(GameObject up)
    {
        sandwich.Add(up);
        up.tag = "sandwich";
        OrderManager.instance.CheckNewOrded(up);

        AlimentsChoiceSpawner.instance.lastAlimentDrop = up;
        
        if(up.GetComponent<Aliment>().ingredientsDisponible != enumIngredients.IngredientsDisponible.Salade)
        {
            ScoreManager.instance.score += (up.GetComponent<Aliment>().points * ScoreManager.instance.combo);

            if (up.GetComponent<Aliment>().ingredientsDisponible == enumIngredients.IngredientsDisponible.Pain)
            {
                ScoreManager.instance.combo = 1f;
                comboIngredients = 0;

                foreach(GameObject aliment in sandwich)
                {
                    Rigidbody rigidbody = aliment.GetComponent<Rigidbody>();
                    rigidbody.constraints = RigidbodyConstraints.FreezeAll;

                }
            }
            else
            {

                if (comboIngredients < 4)
                    comboIngredients++;
                else
                {
                    comboIngredients = 0;
                    ScoreManager.instance.combo += 0.5f;
                }
            }

        }

        MoveCamera();
    }

    public void MoveCamera()
    {
        cameraScript.targetPos.y = sandwich[sandwich.Count - 1].transform.position.y - sandwich[0].transform.position.y;
    }
}
