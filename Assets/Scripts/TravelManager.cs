using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelManager : MonoBehaviour
{
    void Awake()
    {
        int numTravelManager = FindObjectsOfType<TravelManager>().Length;

        if (numTravelManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetTravelManager()
    {
        Destroy(gameObject);
    }
}
