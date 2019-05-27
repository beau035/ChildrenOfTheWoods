using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

//Eigen geschreven code. Hier doe ik een collision check zodat als de ai je aanraakt je respawnd.

public class DeathScript : MonoBehaviour
{
    public bool PlayerAlive = true;
    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Ai")
        {
            PlayerAlive = false;
        }
    }

    private void Update()
    {
        if(PlayerAlive == false)
        {
            Debug.Log("Dead");
            GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }

    }


}
