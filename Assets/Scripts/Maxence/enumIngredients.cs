using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enumIngredients : MonoBehaviour
{
    public static enumIngredients instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

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
}
