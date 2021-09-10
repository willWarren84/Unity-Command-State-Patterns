using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class UserClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        
        
        var origin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(origin, out hit)) return;
        
        if (hit.collider.CompareTag("Cube"))
        {
            //Old code
            //hit.collider.GetComponent<MeshRenderer>().material.color = new Color(Random.value, Random.value,Random.value);
            
            //execute click command
            ICommand click = new ClickCommand(hit.collider.gameObject, 
                new Color(Random.value, Random.value,Random.value));
            
            CommandManager.instance.AddCommand(click);
            click.Execute();
        }
    }
}
