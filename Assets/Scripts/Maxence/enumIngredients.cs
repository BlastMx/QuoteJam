using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enumIngredients : MonoBehaviour
{
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
