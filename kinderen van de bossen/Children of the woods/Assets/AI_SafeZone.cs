using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (AI_Base))]
public class AI_SafeZone : MonoBehaviour
{
    AI_Base ai_base;

    public bool playerInLight;

    float currentMin;
    [SerializeField] GameObject closestZone;
    int closestIndex;

    [SerializeField] SafeZone[] zoneObjects;
    [SerializeField] List<float> distances;

    private void Start()
    {
        ai_base = GetComponent<AI_Base>();

        zoneObjects = FindObjectsOfType<SafeZone>();
        for (int i = 0; i < zoneObjects.Length; i++)
        {
            float distance1 = Vector3.Distance(transform.position, zoneObjects[i].transform.position);
            distances.Insert(i, distance1);
        }
    }


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < zoneObjects.Length; i++)
        {
            float distance1 = Vector3.Distance(transform.position, zoneObjects[i].transform.position);

            distances.RemoveAt(i);
            distances.Insert(i, distance1);
        }

        float min = distances.Min();
        closestIndex = distances.IndexOf(min);

        closestZone = zoneObjects[closestIndex].gameObject;

        if (closestZone.GetComponent<SafeZone>().playerInRange && ai_base.currentState != AI_Base.AI_State.Returning)
        {
            //ai_base.currentState = AI_Base.AI_State.Returning;
            playerInLight = true;
        }
        else
        {
            playerInLight = false;
        }
    }
}
