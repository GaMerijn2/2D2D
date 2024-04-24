using UnityEngine;
using DG.Tweening;
using UnityEditor;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public RectTransform[] Menus;
    public float menuAnimTime;
    public VolumeProfile profile;
    
    private bool isLoadingMenu;
    private int currentMenu = -1, lastMenu = -1;

    private void Start()
    {
        LoadMenu(0);
        
        if (profile.TryGet<ColorAdjustments>(out var colorAdjustments))
        {
            colorAdjustments.colorFilter.Override(new Color(0.8f, 0.8f, 0.8f));
        }
    }

    public void LoadMenu(int menuID)
    {
        if (isLoadingMenu)
            return;

        isLoadingMenu = true;
        lastMenu = currentMenu;
        currentMenu = menuID;
        
        Time.timeScale = SceneManager.GetActiveScene().name == "JonasTestScene" && menuID == 1 ? 0 : 1; // pause

        Menus[currentMenu].GetComponent<CanvasGroup>().DOFade(0, 0f).SetUpdate(true);
        Menus[currentMenu].DOScale(2, 0f).SetUpdate(true);

        for (int i = 0; i < Menus.Length; i++)
        {
            if (i == currentMenu)
            {
                Menus[i].DOScale(1, 0).SetUpdate(true);
                Menus[i].DOLocalMoveY(100, 0).SetUpdate(true);
                Menus[i].DOLocalMoveY(0, menuAnimTime).SetUpdate(true);
                Menus[i].GetComponent<CanvasGroup>().DOFade(1, menuAnimTime).SetUpdate(true).OnComplete(() =>
                {
                    isLoadingMenu = false;
                });
                Menus[i].GetComponent<CanvasGroup>().interactable= true;
                Menus[i].GetComponent<CanvasGroup>().blocksRaycasts= true;
            }
            else if (i == lastMenu)
            {
                Menus[i].DOScale(1, 0).SetUpdate(true);
                Menus[i].GetComponent<CanvasGroup>().interactable = false;
                Menus[i].GetComponent<CanvasGroup>().blocksRaycasts = false;
                Menus[i].DOLocalMoveY(-100, menuAnimTime).SetUpdate(true);
                Menus[i].GetComponent<CanvasGroup>().DOFade(0, menuAnimTime * 0.6f).SetUpdate(true).OnComplete(() =>
                {
                    Menus[lastMenu].transform.DOScale(0, 0f).SetUpdate(true);
                });
            }
            else
            {
                Menus[i].DOScale(0.0f, 0).SetUpdate(true);
                Menus[i].GetComponent<CanvasGroup>().DOFade(0, 0).SetUpdate(true);
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

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    [MenuItem("JAM/Clear PlayerPrefs Data")]
    public static void ClearData()
    {
        PlayerPrefs.DeleteAll();
    }
}