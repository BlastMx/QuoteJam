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
    private List<AlimentChoice> alimentChoices = new List<AlimentChoice>();

    public List<GameObject> prefabsAliments = new List<GameObject>();

    [HideInInspector]
    public GameObject currentAliment, lastAlimentDrop;

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
        if (canChooseAliments)
            ChooseAliments();
    }

    public void AttributionIngredients()
    {
        SpawningAliment.instance.arrow.gameObject.GetComponent<Image>().DOFade(0, 0.5f).OnComplete(()=> {

            gameObject.SetActive(true);
            foreach (AlimentChoice aliment in alimentChoices)
                aliment.AttributionIngredient();

            gameObject.GetComponent<CanvasGroup>().DOFade(1, 1f);

            canChooseAliments = true;

        });
    }

    void ChooseAliments()
    {
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
        canChooseAliments = false;

        currentAliment = alimentChoices[value].aliment;
        //prochain aliment devient celui-ci
        Debug.Log(currentAliment.name);

        gameObject.GetComponent<CanvasGroup>().DOFade(0, 1f).OnComplete(()=> {
            SpawningAliment.instance.arrow.gameObject.GetComponent<Image>().DOFade(1, 0.5f);
            canLandAliments = true;
            gameObject.SetActive(false);
        });
    }
}
