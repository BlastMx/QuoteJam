using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlimentChoice : enumIngredients
{
    [SerializeField] private Text alimentName;

    public void AttributionIngredient()
    {
        ingredientsDisponible = (IngredientsDisponible)Random.Range(0, 7);
    }

    private void Update()
    {
        alimentName.text = ingredientsDisponible.ToString();
    }
}
