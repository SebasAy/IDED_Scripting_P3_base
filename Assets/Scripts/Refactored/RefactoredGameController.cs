using System.Xml;
using UnityEngine;
using UnityEngine.Events;

public class RefactoredGameController : GameControllerBase
{
    public static RefactoredGameController Instance { get; private set; }

    [SerializeField]
    private RefactoredPlayerController playerController;

    // Eventos para notificar el fin del juego y los disparos de flechas.
    public UnityEvent OnGameOver { get; private set; } = new UnityEvent();
    public UnityEvent OnArrowShot { get; private set; } = new UnityEvent();

    public override PlayerControllerBase PlayerController => playerController;

    protected override void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        base.Awake();
    }

    /*private void Update()
    {
        // L�gica de actualizaci�n del juego
    }

    public override void ProcessShot(Vector3 aimPosition)
    {
        // L�gica para procesar el disparo
        // Actualiza el marcador de puntaje, calcula el puntaje, y determina el Game Over.
        UpdateScore(aimPosition);
        CalculateScore(aimPosition);
        CheckGameOver();
    }

    // Actualiza el marcador de puntaje.
    private void UpdateScore(Vector3 aimPosition)
    {
        // Implementa la l�gica de actualizaci�n del puntaje aqu�.
    }

    // Calcula el puntaje del disparo.
    private void CalculateScore(Vector3 shotPosition)
    {
        // Implementa la l�gica de c�lculo de puntaje aqu�.
    }*/

    // Verifica si el juego ha terminado.
    private bool CheckGameOver()
    {
        if (RemainingArrows <= 0)
        {
            OnGameOver.Invoke();
            return true;
        }

        return false;
    }
}