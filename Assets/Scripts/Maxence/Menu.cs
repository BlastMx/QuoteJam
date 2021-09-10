using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [SerializeField]
    private CanvasGroup PanelMenu;

    public CanvasGroup WinLosePanel, UiGame, orderPanel;

    [SerializeField]
    private List<Button> menuButtons = new List<Button>();

    [SerializeField]
    private List<GameObject> menusHowToPlay = new List<GameObject>();

    public Transform mainCam;

    [SerializeField]
    private CanvasGroup mainmenu, howToPlayMenu;

    private Vector3 startPos = new Vector3(0, 3f, -2.5f);
    private Vector3 targetPosCam = new Vector3(0, 1.75f, 0.9f);

    [HideInInspector]
    public bool onMenu = true;
    
    public bool gameOver = false;

    public static Menu instance;

    [SerializeField] private AudioSource source;

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

        howToPlayMenu.DOFade(0, 0.1f).OnComplete(() =>
        {
            howToPlayMenu.gameObject.SetActive(false);
        });
    }

    public void PlayGame()
    {
        foreach (Button button in menuButtons)
            button.interactable = false;

        PanelMenu.DOFade(0, 0.5f).OnComplete(()=>
        {
            source.DOFade(0, 0.5f);
            mainCam.DOMove(targetPosCam, 2f).OnComplete(()=> {
                source.DOFade(1, 0.5f);
                onMenu = false;
                UiGame.DOFade(1, 1f);
                orderPanel.DOFade(1, 1f);

                PanelMenu.blocksRaycasts = false;

                SandwichManager.instance.UpFork();
                OrderManager.instance.StartOrder();
            });
        });
    }

    public void HowToPlay()
    {
        mainmenu.DOFade(0, 0.5f).OnComplete(() =>
        {
            mainmenu.gameObject.SetActive(false);
            howToPlayMenu.gameObject.SetActive(true);
            howToPlayMenu.DOFade(1, 0.5f);
        });
    }

    public void BackMenu()
    {
        howToPlayMenu.DOFade(0, 0.5f).OnComplete(()=> 
        {
            howToPlayMenu.gameObject.SetActive(false);
            mainmenu.gameObject.SetActive(true);
            mainmenu.DOFade(1, 0.5f);
        });
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void changeHowToPlay(int value)
    {
        foreach (GameObject menu in menusHowToPlay)
            menu.SetActive(false);

        menusHowToPlay[value].SetActive(true);
    }
}
