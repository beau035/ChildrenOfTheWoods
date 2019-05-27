using UnityEngine;
using System.Collections;

//eigen geschreven script waarbij als je op give up klikt je game afsluit

public class QuitButton : MonoBehaviour
{
    public void OnClick()
    {
        Application.Quit();
        Debug.Log ("quit");
    }
}