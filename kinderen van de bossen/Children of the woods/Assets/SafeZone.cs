using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Deze code is niet van mij!. Dit is code van tim peeters voor project context. Ik heb toestemming om het te gebruiken.

public class SafeZone : MonoBehaviour
{
    public bool playerInRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
           //other.GetComponent<AI_PlayerHealth>().inLight = true;
           playerInRange = true;

            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            //other.GetComponent<AI_PlayerHealth>().inLight = false;
            playerInRange = false;
    }
}
