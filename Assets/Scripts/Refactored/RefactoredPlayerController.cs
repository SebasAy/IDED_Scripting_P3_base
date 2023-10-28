using System.Windows.Input;
using UnityEngine;

public class RefactoredPlayerController : PlayerControllerBase
{
    public static RefactoredPlayerController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected override void ProcessShot(Vector3 point)
    {
        // Crea un comando y ejecútalo.
        ICommand shotCommand = new ProcessShotCommand(point);
        shotCommand.Execute();
    }

    // Implementa la interfaz ICommand.
    private class ProcessShotCommand : ICommand
    {
        private Vector3 aimPosition;

        public ProcessShotCommand(Vector3 aimPosition)
        {
            this.aimPosition = aimPosition;
        }

        public void Execute()
        {
            RefactoredGameController.Instance.ProcessShot(aimPosition);
            RefactoredGameController.Instance.OnArrowShot.Invoke();
        }
    }
}
public interface ICommand
{
    void Execute();
}