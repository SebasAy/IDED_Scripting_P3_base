using System.Xml;
using UnityEngine;
using UnityEngine.Events;

public class RefactoredGameController : GameControllerBase
{
    public static RefactoredGameController Instance { get; private set; }

    [SerializeField]
    public RefactoredPlayerController playerController;

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

    private void Update()
    {
        CheckGameOver();
    }

    
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