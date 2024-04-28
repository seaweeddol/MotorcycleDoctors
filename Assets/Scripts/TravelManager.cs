using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Parent game object for motorcyclist stats and overall stats.
*/
public class TravelManager : MonoBehaviour
{
    [SerializeField]
    private EncounterManager _encounterManager;

    [SerializeField]
    private float _travelLength = 20f;

    [SerializeField]
    private float _firstEncounter = 5f;
    [SerializeField]
    private float _secondEncounter = 15f;

    private float _timer = 0f;
    private int _encounterCounter = 0;

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

    void Update()
    {
        if (_encounterManager.CheckIfActive()) return;

        _timer += Time.deltaTime;

        if (_timer >= _firstEncounter && _encounterCounter == 0)
        {
            _encounterCounter++;
            _encounterManager.EnableEncounter();
        }
        else if (_timer >= _secondEncounter && _encounterCounter == 1)
        {
            _encounterCounter++;
            _encounterManager.EnableEncounter();
        }
        else if (_timer >= _travelLength)
        {
            // TODO: end travel, show next town interface
            Debug.Log("travel segment completed");
            _timer = 0f;
            _encounterCounter = 0;
        }
    }

    public void ResetTravelManager()
    {
        Destroy(gameObject);
    }
}
