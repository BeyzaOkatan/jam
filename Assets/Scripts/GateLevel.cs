using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Gate1")
        {
            Debug.Log("1");
            SceneManager.LoadScene("1");
        }
        else if (other.gameObject.name == "Gate2")
        {
            Debug.Log("2");

            SceneManager.LoadScene("2");
        }
        else if (other.gameObject.name == "Gate3")
        {
            Debug.Log("3");

            SceneManager.LoadScene("3");
        }
        else if (other.gameObject.name == "Gate4")
        {
            Debug.Log("4");

            SceneManager.LoadScene("4");
        }else if(other.gameObject.name == "Main")
        {
            SceneManager.LoadScene("Opening");
        }
    }
}