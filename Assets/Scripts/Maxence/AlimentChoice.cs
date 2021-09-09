using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlimentChoice : MonoBehaviour
{
    [SerializeField] public Text alimentName;
    public GameObject aliment;

    public void AttributionIngredient()
    {
        AlimentsChoiceSpawner alimentsChoice = AlimentsChoiceSpawner.instance;

        int randomNumber = Random.Range(0, 100);

        if(randomNumber <= 70)
        {
            int value = Random.Range(0, alimentsChoice.prefabsAliments.Count);

            aliment = alimentsChoice.prefabsAliments[value];
            alimentName.text = aliment.name;
        }
        else
        {
            aliment = alimentsChoice.middleBread;
            alimentName.text = aliment.name;
        }
    }
}
