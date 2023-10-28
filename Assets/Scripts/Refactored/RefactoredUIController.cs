using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefactoredUIController : UIControllerBase
{
    public RefactoredGameController gameController; 

    protected override GameControllerBase GameController => gameController;

    [SerializeField]
    private GameObject gameOverOverlay;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text arrowCountText;

    private void Start()
    {
        if (gameOverOverlay != null)
        {
            gameOverOverlay.SetActive(false);
        }
    }


    private void OnEnable()
    {
        gameController.OnGameOver.AddListener(ShowGameOverOverlay);
        gameController.OnArrowShot.AddListener(UpdateUI);
    }

  
    private void OnDisable()
    {
        gameController.OnGameOver.RemoveListener(ShowGameOverOverlay);
        gameController.OnArrowShot.RemoveListener(UpdateUI);
    }

   
    private void ShowGameOverOverlay()
    {
        if (gameOverOverlay != null)
        {
            gameOverOverlay.SetActive(true);
        }
    }

   
    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text =  GameController.Score.ToString();
        }

        if (arrowCountText != null)
        {
            arrowCountText.text =  GameController.RemainingArrows.ToString();
        }
    }
}
