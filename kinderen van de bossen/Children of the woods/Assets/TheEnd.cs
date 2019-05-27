using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;



public class TheEnd : MonoBehaviour
    {

    public FirstPersonController fpc;
    void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                fpc.m_MouseLook.SetCursorLock(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Debug.Log("finished");

        }
    }
}

