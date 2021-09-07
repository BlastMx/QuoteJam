using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlimentChoice : MonoBehaviour
{
    [SerializeField] private Text alimentName;

    public enum IngredientsDisponible
    {
        Salade,
        Fromage,
        Steak,
        Jambon,
        Pain,
        Beurre,
        Saucisson
    }

    public IngredientsDisponible ingredientsDisponible;

    public void AttributionIngredient()
    {
        ingredientsDisponible = (IngredientsDisponible)Random.Range(0, 7);
    }

    private void Update()
    {
        alimentName.text = ingredientsDisponible.ToString();
    }
}
