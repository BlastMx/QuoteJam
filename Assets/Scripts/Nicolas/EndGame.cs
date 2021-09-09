using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject breadTop;

    [Header("panel win/lose")]
    public GameObject winLosePanel;
    public GameObject winPanel;
    public GameObject losePanel;
    GameObject bread;



    // Update is called once per frame
    void Update()
    {
        if(TimerManager.instance.end && bread == null)
        {
            
            if (SandwichManager.instance.sandwich.Count-1 >= 0)
                bread = Instantiate(breadTop, new Vector3(SandwichManager.instance.sandwich[SandwichManager.instance.sandwich.Count - 1].transform.position.x, GameObject.Find("WaypointsParent").transform.position.y, SandwichManager.instance.sandwich[SandwichManager.instance.sandwich.Count - 1].transform.position.z), Quaternion.identity);
            else
                bread = Instantiate(breadTop, new Vector3(GameObject.Find("LowerBread").transform.position.x, GameObject.Find("WaypointsParent").transform.position.y, GameObject.Find("LowerBread").transform.position.z), Quaternion.identity);
        }
        if(bread!=null)
        {
            if(UpperBread.instance.stop)
            {
                winLosePanel.SetActive(true);

                for (int i = 0; i<OrderManager.instance.nIngredient;i++)
                {
                    if (!OrderManager.instance.ingredients[i].valid)
                        losePanel.SetActive(true);
                }
                if (!losePanel.active)
                    winPanel.SetActive(true);

            }
        }


    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
