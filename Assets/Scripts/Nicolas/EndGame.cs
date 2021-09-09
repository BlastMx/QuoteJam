using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

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
        if (Menu.instance.onMenu)
            return;

        if (TimerManager.instance.end && bread == null)
        {
            
            if (SandwichManager.instance.sandwich.Count-1 > 0)
                bread = Instantiate(breadTop, new Vector3(SandwichManager.instance.sandwich[SandwichManager.instance.sandwich.Count - 1].transform.position.x, GameObject.Find("ForkWaypointsParent").transform.position.y, SandwichManager.instance.sandwich[SandwichManager.instance.sandwich.Count - 1].transform.position.z), Quaternion.identity);
            else
                bread = Instantiate(breadTop, new Vector3(GameObject.Find("LowerBread").transform.position.x, GameObject.Find("ForkWaypointsParent").transform.position.y, GameObject.Find("LowerBread").transform.position.z), Quaternion.identity);
        }
        if(bread!=null)
        {
            Menu.instance.gameOver = true;

            Menu.instance.UiGame.DOFade(0, 1f);
            Menu.instance.orderPanel.DOFade(0, 1f).OnComplete(()=> 
            {
                Menu.instance.mainCam.DOMoveY(SandwichManager.instance.sandwich[0].transform.position.y, 3f).SetDelay(2).OnComplete(() =>
                {
                    if (UpperBread.instance.stop)
                    {
                        winLosePanel.SetActive(true);
                        Menu.instance.WinLosePanel.DOFade(1, 1f);

                        Menu.instance.onMenu = true;

                        for (int i = 0; i < OrderManager.instance.nIngredient; i++)
                        {
                            if (!OrderManager.instance.ingredients[i].valid) { }
                            losePanel.SetActive(true);
                        }
                        if (!losePanel.active)
                            winPanel.SetActive(true);

                        Menu.instance.WinLosePanel.blocksRaycasts = true;
                    }
                });
            });
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
