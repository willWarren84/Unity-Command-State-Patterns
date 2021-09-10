using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Game view class.
/// Passes button events.
/// </summary>
public class GameView : BaseView
{
    // Events to attach to.
    public UnityAction OnPauseClicked;
    public UnityAction OnFinishClicked;

    public UnityAction OnDoneClicked;
    public UnityAction OnResetClicked;
    public UnityAction OnUndoClicked;
    public UnityAction OnRedoClicked;
    public UnityAction OnPlayAllClicked;
    public UnityAction OnRewindAllClicked;
    
    
    /// <summary>
    /// Method called by Pause Button.
    /// </summary>
    public void PauseClick()
    {
        OnPauseClicked?.Invoke();
    }

    /// <summary>
    /// Method called by Finish Button.
    /// </summary>
    public void FinishClick()
    {
        OnFinishClicked?.Invoke();
    }
    
    /// <summary>
    /// Method called by Done Button.
    /// </summary>
    public void DoneClick()
    {
        OnDoneClicked?.Invoke();
    }
    
    /// <summary>
    /// Method called by Reset Button.
    /// </summary>
    public void ResetClick()
    {
        OnResetClicked?.Invoke();
    }
    
    /// <summary>
    /// Method called by Play Button.
    /// </summary>
    public void PlayClick()
    {
        OnPlayAllClicked?.Invoke();
    }
    
    /// <summary>
    /// Method called by Rewind Button.
    /// </summary>
    public void RewindClick()
    {
        OnRewindAllClicked?.Invoke();
    }
    
    /// <summary>
    /// Method called by Undo Button.
    /// </summary>
    public void UndoClicked()
    {
        OnUndoClicked?.Invoke();
    }
    
    /// <summary>
    /// Method called by Redo Button.
    /// </summary>
    public void RedoClick()
    {
        OnRedoClicked?.Invoke();
    }
}