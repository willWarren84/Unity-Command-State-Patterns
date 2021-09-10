using UnityEngine;

/// <summary>
/// This is example of game state.
/// It shows game view and can load some content related to gameplay.
/// </summary>
public class GameState : BaseState
{
    // Variables used for loading and destroying game content
    public bool loadGameContent = true;
    public bool destroyGameContent = true;

    // Used when player decide to go to menu from pause state
    public bool skipToFinish = false;

    public override void PrepareState()
    {
        base.PrepareState();

        // Skip to finish game
        if (skipToFinish)
        {
            owner.ChangeState(new GameOverState { gameResult = GameResult.GetRandomResult() });
            return;
        }

        // Attach functions to view events
        owner.UI.GameView.OnPauseClicked += PauseClicked;
        owner.UI.GameView.OnFinishClicked += FinishClicked;
        owner.UI.GameView.OnDoneClicked += DoneClicked;
        owner.UI.GameView.OnResetClicked += ResetClicked;
        owner.UI.GameView.OnPlayAllClicked += PlayClicked;
        owner.UI.GameView.OnRewindAllClicked += RewindClicked;
        owner.UI.GameView.OnRedoClicked += OnRedoClicked;
        owner.UI.GameView.OnUndoClicked += OnUndoClicked;

        // Show game view
        owner.UI.GameView.ShowView();

        if (loadGameContent)
        {
            // here we would load game content
        }
    }

    public override void DestroyState()
    {
        if (destroyGameContent)
        {
            // here we would destroy loaded game content
        }

        // Hide game view
        owner.UI.GameView.HideView();

        // Detach functions from view events
        owner.UI.GameView.OnPauseClicked -= PauseClicked;
        owner.UI.GameView.OnFinishClicked -= FinishClicked;
        owner.UI.GameView.OnDoneClicked -= DoneClicked;
        owner.UI.GameView.OnPlayAllClicked -= PlayClicked;
        owner.UI.GameView.OnRewindAllClicked -= RewindClicked;
        
        base.DestroyState();
    }

    /// <summary>
    /// Function called when Pause button is clicked in Game view.
    /// </summary>
    private void PauseClicked()
    {
        destroyGameContent = false;

        owner.ChangeState(new PauseState());
    }

    /// <summary>
    /// Function called when Finish Game button is clicked in Game view.
    /// </summary>
    private void FinishClicked()
    {
        owner.ChangeState(new GameOverState { gameResult = GameResult.GetRandomResult() });
    }

    private void DoneClicked()
    {
        CommandManager.instance.Done();
    }
    
    private void ResetClicked()
    {
        CommandManager.instance.Reset();
    }
    
    private void PlayClicked()
    {
        CommandManager.instance.PlayAll();
    }
    
    private void RewindClicked()
    {
        CommandManager.instance.RewindAll();
    }
    
    private void OnUndoClicked()
    {
        CommandManager.instance.Undo();
    }

    private void OnRedoClicked()
    {
        CommandManager.instance.Redo();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (!Input.GetMouseButtonDown(0)) return;
        
        
        var origin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(origin, out hit)) return;

        if (!hit.collider.CompareTag("Cube")) return;
        
        //execute click command
        ICommand click = new ClickCommand(hit.collider.gameObject, 
            new Color(Random.value, Random.value,Random.value));
            
        CommandManager.instance.AddCommand(click);
        click.Execute();
    }
}