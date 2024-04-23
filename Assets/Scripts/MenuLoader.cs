using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public RectTransform[] Menus;
    public float menuAnimTime;
    
    private bool isLoadingMenu;
    private int currentMenu = -1, lastMenu = -1;
    
    private void Start() => LoadMenu(0);

    public void LoadMenu(int menuID)
    {
        if (isLoadingMenu)
            return;

        isLoadingMenu = true;
        lastMenu = currentMenu;
        currentMenu = menuID;

        Menus[currentMenu].GetComponent<CanvasGroup>().DOFade(0, 0f);
        Menus[currentMenu].DOScale(2, 0f);

        for (int i = 0; i < Menus.Length; i++)
        {
            if (i == currentMenu)
            {
                Menus[i].DOScale(1, 0);
                Menus[i].DOLocalMoveY(100, 0);
                Menus[i].DOLocalMoveY(0, menuAnimTime);
                Menus[i].GetComponent<CanvasGroup>().DOFade(1, menuAnimTime).OnComplete(() =>
                {
                    isLoadingMenu = false;
                });
                Menus[i].GetComponent<CanvasGroup>().interactable= true;
                Menus[i].GetComponent<CanvasGroup>().blocksRaycasts= true;
            }
            else if (i == lastMenu)
            {
                Menus[i].DOScale(1, 0);
                Menus[i].GetComponent<CanvasGroup>().interactable = false;
                Menus[i].GetComponent<CanvasGroup>().blocksRaycasts = false;
                Menus[i].DOLocalMoveY(-100, menuAnimTime);
                Menus[i].GetComponent<CanvasGroup>().DOFade(0, menuAnimTime * 0.6f).OnComplete(() =>
                {
                    Menus[lastMenu].transform.DOScale(0, 0f);
                });
            }
            else
            {
                Menus[i].DOScale(0.0f, 0);
                Menus[i].GetComponent<CanvasGroup>().DOFade(0, 0);
                Menus[i].GetComponent<CanvasGroup>().interactable = false;
                Menus[i].GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }
    }

    public void OpenLinkToBrowser(string link)
    {
        Application.OpenURL(link);
    }

    public void LoadLevel(int id)
    {
        StaticData.CurrentLevel = id;
        SceneManager.LoadScene("JonasTestScene");
    }
}