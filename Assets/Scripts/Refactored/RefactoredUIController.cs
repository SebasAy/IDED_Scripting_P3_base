using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefactoredUIController : UIControllerBase
{
    public RefactoredGameController gameController; // Asegúrate de asignar una instancia de RefactoredGameController en el Inspector.

    protected override GameControllerBase GameController => gameController;

    // Añade referencias a los elementos del UI en el Inspector.
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

    // Suscribe los métodos a los eventos de RefactoredGameController.
    private void OnEnable()
    {
        gameController.OnGameOver.AddListener(ShowGameOverOverlay);
        gameController.OnArrowShot.AddListener(UpdateUI);
    }

    // Desuscribe los métodos de los eventos al deshabilitar el objeto.
    private void OnDisable()
    {
        gameController.OnGameOver.RemoveListener(ShowGameOverOverlay);
        gameController.OnArrowShot.RemoveListener(UpdateUI);
    }

    // Método para mostrar el overlay de Game Over.
    private void ShowGameOverOverlay()
    {
        if (gameOverOverlay != null)
        {
            gameOverOverlay.SetActive(true);
        }
    }

    // Método para actualizar los elementos del UI.
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
