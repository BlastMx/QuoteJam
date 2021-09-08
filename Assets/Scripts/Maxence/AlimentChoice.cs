using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlimentChoice : MonoBehaviour
{
    [SerializeField] private Text alimentName;
    public GameObject aliment;

    AlimentsChoiceSpawner alimentsChoice;

    private void Awake()
    {
        alimentsChoice = AlimentsChoiceSpawner.instance;
    }

    public void AttributionIngredient()
    {
        AlimentsChoiceSpawner alimentsChoice = AlimentsChoiceSpawner.instance;

        int value = Random.Range(0, alimentsChoice.prefabsAliments.Count);

        alimentName.text = alimentsChoice.prefabsAliments[value].name;

        aliment = alimentsChoice.prefabsAliments[value];
    }
}
