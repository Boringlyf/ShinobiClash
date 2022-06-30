using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchShapes : MonoBehaviour
{
    public GameObject cube;
    public GameObject capsule;
    public GameObject cylinder;
    public GameObject gameManager;
    /*below static postion variable will store the position of any of the active character in the scene and will set
      this position for the new character to be spawn/activated when the trigger event occours
     */
    public static Vector3 position; 
    public static float playerSpeed;

    void Start()
    {
        playerSpeed = 8f;
        //restoreTime = 2f;
        //go.SetActive(false);
        //Debug.Log("SwitchShapes Started");
        //if (capsule.gameObject.activeInHierarchy) Debug.Log("Capsule active");
        //if (this.gameObject.activeInHierarchy) Debug.Log("SwitchShapes Activated");
    }

    
    void Update()
    {
        if (cube.activeInHierarchy)
        {
            position = cube.transform.position;
            PlayerMove();
        }
        else if (capsule.activeInHierarchy)
        {
            position = capsule.transform.position;
            PlayerMove();
        }
        else //(cylinder.activeInHierarchy)
        {
            position = cylinder.transform.position;
            PlayerMove();
        }
    }
    //void OnCollisionEnter(Collision collision)
    //{
    //    //if(collision.gameObject.tag == "Pickup_capsule")
    //   // Debug.Log("capsule");
    //    if (collision.gameObject.CompareTag("pickup_capsule"))
    //    {
    //        cube.SetActive(false);
    //        capsule.SetActive(true);
    //        capsule.transform.position = position;
    //        cylinder.SetActive(false);
    //        Debug.Log("capsule");
    //    }
    //    if (collision.gameObject.CompareTag("pickup_cylinder"))
    //    {
    //        //Instantiate(cylinder, transform.position, Quaternion.identity);
    //        cube.SetActive(false);
    //        capsule.SetActive(false);
    //        cylinder.SetActive(true);
    //        cylinder.transform.position = position;
    //        Debug.Log("cylinder");
    //    }
    //    if (collision.gameObject.CompareTag("pickup_cube"))
    //    {
    //        cube.SetActive(true);
    //        cube.transform.position = position;
    //        capsule.SetActive(false);
    //        cylinder.SetActive(false);
    //        Debug.Log("cube");
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "pickup_capsule":
                cube.SetActive(false);
                capsule.SetActive(true);
                capsule.transform.position = position;
                cylinder.SetActive(false);
                Debug.Log("capsule");
                break;
            case "pickup_cylinder":
                cube.SetActive(false);
                capsule.SetActive(false);
                cylinder.SetActive(true);
                cylinder.transform.position = position;
                StartCoroutine(gameManager.GetComponent<RestoreShape>().StartRestore());
                Debug.Log("cylinder");
                break;
            case "pickup_cube":
                cube.SetActive(true);
                cube.transform.position = position;
                capsule.SetActive(false);
                cylinder.SetActive(false);
                StartCoroutine(gameManager.GetComponent<RestoreShape>().StartRestore());
                Debug.Log("cube");
                break;
        }
        //Debug.Log("I'm executed");
        //if (other.CompareTag("pickup_capsule"))
        //{
        //    cube.SetActive(false);
        //    capsule.SetActive(true);
        //    capsule.transform.position = position;
        //    cylinder.SetActive(false);
        //    Debug.Log("capsule");
        //}
        //if (other.CompareTag("pickup_cylinder"))
        //{
        //    //Instantiate(cylinder, transform.position, Quaternion.identity);
        //    cube.SetActive(false);
        //    capsule.SetActive(false);
        //    cylinder.SetActive(true);
        //    cylinder.transform.position = position;
        //    Debug.Log("cylinder");
        //}
        //if (other.CompareTag("pickup_cube"))
        //{
        //    cube.SetActive(true);
        //    cube.transform.position = position;
        //    capsule.SetActive(false);
        //    cylinder.SetActive(false);
        //    Debug.Log("cube");
        //}
    }
    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0f, 0f, 1f) * playerSpeed * Time.deltaTime;
        }else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0f, 0f, -1f) * playerSpeed * Time.deltaTime;
        }else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1f, 0f, 0f) * playerSpeed * Time.deltaTime;
        }else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1f, 0f, 0f) * playerSpeed * Time.deltaTime;
        }
        else
        {
            return;
        }
    }
}
