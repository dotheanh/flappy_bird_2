using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResumeController : MonoBehaviour
{
    public GameObject btnPause;
    public GameObject btnResume;
    public GameManager gameManager;

    public void Show()
    {
        btnPause.gameObject.SetActive(true);
        btnResume.gameObject.SetActive(false);
    }
    public void OnClickPause()
    {
        btnPause.gameObject.SetActive(false);
        btnResume.gameObject.SetActive(true);
        gameManager.PauseGame();
    }
    public void OnClickResume()
    {
        btnPause.gameObject.SetActive(true);
        btnResume.gameObject.SetActive(false);
        gameManager.ResumeGame();
    }
    public void Hide()
    {
        btnPause.gameObject.SetActive(false);
        btnResume.gameObject.SetActive(false);
    }
}
