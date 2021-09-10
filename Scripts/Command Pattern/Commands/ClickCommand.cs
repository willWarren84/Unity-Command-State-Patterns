using UnityEngine;

public class ClickCommand : ICommand
{
    private GameObject _cube;
    private Color _colour;

    private Color _previousColour;

    private Material _material;
    
    public ClickCommand(GameObject cube, Color colour)
    {
        _cube = cube;
        _colour = colour;
    }
    
    public void Execute()
    {
        if (_material == null)
            _material = _cube.GetComponent<MeshRenderer>().material;
        
        _previousColour = _material.color;
        _material.color = _colour;
    }

    public void Undo()
    {
        if(_material == null)
            _material = _cube.GetComponent<MeshRenderer>().material;
            
        _material.color = _previousColour;
    }
}
