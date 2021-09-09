using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    [SerializeField]
    private CanvasGroup PanelMenu;

    public CanvasGroup WinLosePanel, UiGame, orderPanel;

    [SerializeField]
    private List<Button> menuButtons = new List<Button>();

    public Transform mainCam;

    private Vector3 startPos = new Vector3(0, 3f, -2.5f);
    private Vector3 targetPosCam = new Vector3(0, 1.75f, 0.9f);

    [HideInInspector]
    public bool onMenu = true;

    public static Menu instance;

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

        UiGame.DOFade(0, 0.1f);
        WinLosePanel.DOFade(0, 0.1f);
        orderPanel.DOFade(0, 0.1f);

        mainCam.position = startPos;
    }

    public void PlayGame()
    {
        foreach (Button button in menuButtons)
            button.interactable = false;

        PanelMenu.DOFade(0, 0.5f).OnComplete(()=>
        {
            mainCam.DOMove(targetPosCam, 2f).OnComplete(()=> {
                onMenu = false;
                UiGame.DOFade(1, 1f);
                orderPanel.DOFade(1, 1f);

                SandwichManager.instance.UpFork();
                OrderManager.instance.StartOrder();
            });
        });
    }

    public void HowToPlay()
    {
        Debug.Log("here");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
