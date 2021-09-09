using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlimentChoice : MonoBehaviour
{
    [SerializeField] private Text alimentName;
    public GameObject aliment;

    private int total;
    private int randomNumber;

    public void AttributionIngredient()
    {
        AlimentsChoiceSpawner alimentsChoice = AlimentsChoiceSpawner.instance;

        foreach (var item in alimentsChoice.table)
        {
            total += item;
        }

        randomNumber = Random.Range(0, total);

        for(int i = 0; i < alimentsChoice.table.Length; i++)
        {
            if(randomNumber <= alimentsChoice.table[i])
            {
                if(alimentsChoice.table[i] == 70)
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
                return;
            }
            else
            {
                randomNumber -= alimentsChoice.table[i];
            }
        }
    }
}
