using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AlimentsChoiceSpawner : MonoBehaviour
{
    [HideInInspector]
    public bool canChooseAliments = true;
    [HideInInspector]
    public bool canLandAliments = false;

    [SerializeField]
    private Transform arrow;

    [SerializeField]
    private List<AlimentChoice> alimentChoices = new List<AlimentChoice>();

    public List<GameObject> prefabsAliments = new List<GameObject>();

    [HideInInspector]
    public GameObject currentAliment, lastAlimentDrop;

    public GameObject middleBread;

    public static AlimentsChoiceSpawner instance;

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

        ChooseAliments();
    }

    public void AttributionIngredients()
    {
        int nbMiddleBread = 0;
        foreach (AlimentChoice aliment in alimentChoices)
        {
            aliment.AttributionIngredient();

            if(aliment.aliment == middleBread)
            {
                nbMiddleBread++;
            }
        }

        if (nbMiddleBread == 4)
        {
            int randomAlimentChoice = Random.Range(0, prefabsAliments.Count);
            int randomPrefabAliment = Random.Range(0, prefabsAliments.Count);
            alimentChoices[randomAlimentChoice].aliment = prefabsAliments[randomPrefabAliment];
            alimentChoices[randomAlimentChoice].icon.sprite = prefabsAliments[randomPrefabAliment].GetComponent<Aliment>().icon;
        }

        canChooseAliments = true;
        canLandAliments = true;
    }

    void ChooseAliments()
    {
        if (!canLandAliments)
            return;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            AlimentChosen(0);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            AlimentChosen(1);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            AlimentChosen(2);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            AlimentChosen(3);
        }
    }

    void AlimentChosen(int value)
    {
        canLandAliments = false;
        canChooseAliments = false;

        currentAliment = alimentChoices[value].aliment; 
        
        GameObject aliment = Instantiate(currentAliment);

        aliment.transform.position = arrow.position;
        aliment.SetActive(true);

        TimerManager.instance.reset = true;
    }
}
