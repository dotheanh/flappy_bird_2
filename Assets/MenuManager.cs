using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject floatCanvas;
    public GuiRanking guiRanking;
    void Start()
    {
        Screen.autorotateToLandscapeLeft = true;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        HideGUIRanking();
    }
    
    public void PlayGame()
	{
		SceneManager.LoadScene("GameScene");
	}
    public void ShowGUIRanking()
	{
        floatCanvas.gameObject.SetActive(false);
        guiRanking.gameObject.SetActive(true);
        guiRanking.ShowRanking();
	}
    public void HideGUIRanking()
	{
        floatCanvas.gameObject.SetActive(true);
        guiRanking.gameObject.SetActive(false);
	}
}
