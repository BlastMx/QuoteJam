using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    [Header("list ingrediant")]
    public GameObject[] ingredientOnOff;
    public ingredient[] ingredients;
    public List<string> ingredientName;

    [Header("count ordred")]
    public int min;
    public int max;

    [Header("time switch color")]
    public float time;

    int nIngredient;


    public static OrderManager instance;

    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        nIngredient = Random.Range(1, 4);

        for (int i = 0;i< nIngredient; i++)
        {
            ingredientOnOff[i].SetActive(true); 

            int randomIngrediant = Random.Range(0, ingredientName.Count);
            ingredients[i].name = ingredientName[randomIngrediant];
            ingredientName.RemoveAt(randomIngrediant);
            ingredients[i].text[0].text = ingredients[i].name + " :";

            ingredients[i].ordredInt = Random.Range(min, max + 1);
            ingredients[i].text[1].text = ingredients[i].ordredInt.ToString();
            ingredients[i].countInt = 0;

        }
    }

    public void CheckNewOrded(GameObject check)
    {
        for(int i = 0;i<ingredients.Length;i++)
        {
            if(ingredients[i].name+"(Clone)" == check.name)
            {
                if (ingredients[i].ordredInt > ingredients[i].countInt)
                    ingredients[i].text[3].text = (++ingredients[i].countInt).ToString();

                if (ingredients[i].ordredInt == ingredients[i].countInt)
                {
                    for (int y = 0; y < ingredients[i].text.Length; y++)
                        ingredients[i].text[y].color = Color.green;

                    ingredients[i].valid = true;
                }
            }         
        }
    }

    public void CheckFallOrder(GameObject check)
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            if(check.name== ingredients[i].name + "(Clone)" )
            {
                if (ingredients[i].ordredInt == ingredients[i].countInt)
                {
                    for (int y = 0; y < ingredients[i].text.Length; y++)
                        StartCoroutine(SwitchColor(i, y));
                }

                if(ingredients[i].countInt > 0)
                    ingredients[i].text[3].text = (--ingredients[i].countInt).ToString();
            }

        }
    }

    public IEnumerator SwitchColor(int i,int y)
    {
        ingredients[i].text[y].color = Color.red;
        yield return new WaitForSeconds(time);
        ingredients[i].text[y].color = Color.black;
    }
}



[System.Serializable]
public struct ingredient
{
    public string name;
    public Text[] text;
    public int ordredInt;
    public int countInt;
    public bool valid;
}
