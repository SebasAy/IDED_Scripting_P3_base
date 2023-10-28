using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefactoredUIController : UIControllerBase
{
    public RefactoredGameController gameController; // Aseg�rate de asignar una instancia de RefactoredGameController en el Inspector.

    protected override GameControllerBase GameController => gameController;

    // A�ade referencias a los elementos del UI en el Inspector.
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

    // Suscribe los m�todos a los eventos de RefactoredGameController.
    private void OnEnable()
    {
        gameController.OnGameOver.AddListener(ShowGameOverOverlay);
        gameController.OnArrowShot.AddListener(UpdateUI);
    }

    // Desuscribe los m�todos de los eventos al deshabilitar el objeto.
    private void OnDisable()
    {
        gameController.OnGameOver.RemoveListener(ShowGameOverOverlay);
        gameController.OnArrowShot.RemoveListener(UpdateUI);
    }

    // M�todo para mostrar el overlay de Game Over.
    private void ShowGameOverOverlay()
    {
        if (gameOverOverlay != null)
        {
            gameOverOverlay.SetActive(true);
        }
    }

    // M�todo para actualizar los elementos del UI.
    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + GameController.Score.ToString();
        }

        if (arrowCountText != null)
        {
            arrowCountText.text = "Arrows: " + GameController.RemainingArrows.ToString();
        }
    }
}
