using UnityEngine;
using TMPro;

//eigen code. hier maak ik een scriptje dat geactiveerd wordt zodra iemand binnen de collider van het object komt.

public class triggerText : MonoBehaviour
{
    public GameObject textdisplay;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player") //Is de speler binnen het object?
        {
            textdisplay.SetActive(true); //Als dat waar is zal de geselecteerde text inbeeld komen.
        }
    }
    private void OnTriggerExit(Collider other) //dit is hetzelfde maar andersom. stop met het laten zien van de tekst als je en niet meer in staat.ik
    {
        if (other.tag == "Player")
        {
            textdisplay.SetActive(false);
        }
    }
}
