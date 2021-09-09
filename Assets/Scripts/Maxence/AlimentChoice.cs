using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlimentChoice : MonoBehaviour
{
    public Image icon;
    public GameObject aliment;

    public void AttributionIngredient()
    {
        AlimentsChoiceSpawner alimentsChoice = AlimentsChoiceSpawner.instance;

        int randomNumber = Random.Range(0, 100);

        if(randomNumber <= 70)
        {
            int value = Random.Range(0, alimentsChoice.prefabsAliments.Count);

            aliment = alimentsChoice.prefabsAliments[value];
        }
        else
            aliment = alimentsChoice.middleBread;

        icon.sprite = aliment.GetComponent<Aliment>().icon;
    }
}
