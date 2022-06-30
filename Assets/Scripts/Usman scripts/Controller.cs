using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    
    public GameObject cube;
    public GameObject cylinder;
    public GameObject capsule;
    Vector3 offset;
    void Start()
    {
        offset = transform.position - cube.transform.position;
    }

    
    void Update()
    {
        //transform.position = player.transform.position + offset;
        //below code is for changing camera position according to the active character in the scene
        if (cube.activeInHierarchy)
        {
            transform.position = cube.transform.position + offset;
        }else if (cylinder.activeInHierarchy)
        {
            transform.position = cylinder.transform.position + offset;
        }
        else
        {
            transform.position = capsule.transform.position + offset;
        }
    }
}
