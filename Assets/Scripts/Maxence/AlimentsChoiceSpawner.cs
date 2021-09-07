using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AlimentsChoiceSpawner : enumIngredients
{
    [HideInInspector]
    public bool canChooseAliments = true;

    [SerializeField]
    private List<AlimentChoice> alimentChoices = new List<AlimentChoice>();

    public static AlimentsChoiceSpawner instance;

    // Start is called before the first frame update
    void Awake()
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

    private void Start()
    {
        AttributionIngredients();
    }

    // Update is called once per frame
    void Update()
    {
        if (canChooseAliments)
            ChooseAliments();
    }

    void AttributionIngredients()
    {
        gameObject.SetActive(true);
        foreach (AlimentChoice aliment in alimentChoices)
            aliment.AttributionIngredient();

        gameObject.GetComponent<CanvasGroup>().DOFade(1, 1f);
    }

    void ChooseAliments()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AlimentChosen(0);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            AlimentChosen(1);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            AlimentChosen(2);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            AlimentChosen(3);
        }
    }

    void AlimentChosen(int value)
    {
        canChooseAliments = false;

        //prochain aliment devient celui-ci
        Debug.Log(alimentChoices[value].ingredientsDisponible);

        ingredientsDisponible = alimentChoices[value].ingredientsDisponible;

        gameObject.GetComponent<CanvasGroup>().DOFade(0, 1f).OnComplete(()=> {
            gameObject.SetActive(false);
        });
    }
}
