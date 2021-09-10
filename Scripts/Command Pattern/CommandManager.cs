using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    private static CommandManager _instance;

    private List<ICommand> commandList = new List<ICommand>();

    private int currentIndex = 0;

    public float delay = 1f;
    
    public static CommandManager instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("The CommandManager is NULL");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void AddCommand(ICommand command)
    {
        StopAllCoroutines();
        
        if (currentIndex < commandList.Count)
            commandList.RemoveRange(currentIndex, commandList.Count - currentIndex);

        commandList.Add(command);
        currentIndex = commandList.Count;
    }

    public void PlayAll()
    {
        StopAllCoroutines();
        StartCoroutine(PlayAllRoutine());
    }

    private IEnumerator PlayAllRoutine()
    {
        while(currentIndex < commandList.Count)
        {
            Play();
            yield return new WaitForSeconds(delay);
        }
    }

    public void Redo()
    {
        StopAllCoroutines();
        Play();
    }

    private void Play()
    {
        if (currentIndex >= commandList.Count) return;
        
        var command = commandList[currentIndex];
        command.Execute();
        currentIndex++;
    }
    
    public void Undo()
    {
        StopAllCoroutines();
        Rewind();
    }

    private void Rewind()
    {
        if (currentIndex <= 0) return;
        
        currentIndex--;
        var command = commandList[currentIndex];
        command.Undo();
    }
    
    public void RewindAll()
    {
        StopAllCoroutines();
        StartCoroutine(RewindAllRoutine());
    }

    private IEnumerator RewindAllRoutine()
    {
        while (currentIndex > 0)
        {
            Rewind();
            yield return new WaitForSeconds(delay);
        }
    }

    public void Done()
    {
        var cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach (var cube in cubes)
        {
            cube.GetComponent<MeshRenderer>().material.color = Color.white;
        }

        currentIndex = 0;
    }

    public void Reset()
    {
        StopAllCoroutines();
        commandList.Clear();
        Done();
    }
}
