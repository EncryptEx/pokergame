using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Find Canvas in the Scene
        Canvas canvas = (Canvas)GameObject.FindObjectOfType(typeof(Canvas));
        GameObject canvasGameObject = canvas.gameObject;
        this.transform.parent = canvasGameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
