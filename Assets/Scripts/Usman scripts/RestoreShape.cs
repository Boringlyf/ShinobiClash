using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreShape : MonoBehaviour
{
    public GameObject cube;
    public GameObject capsule;
    public GameObject cylinder;
    private float restoreTime; //how many seconds later should we restore the character

    void Start()
    {
        restoreTime = 2f;
    }
    public IEnumerator StartRestore()
    {
        yield return new WaitForSeconds(restoreTime);
        cube.SetActive(false);
        cylinder.SetActive(false);
        capsule.SetActive(true);
        capsule.transform.position = SwitchShapes.position;
        Debug.Log("RestoreShaped");
    }
}
