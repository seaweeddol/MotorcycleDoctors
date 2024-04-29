using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private List<TownSO> _towns;

    private float _timer = 0f;
    private int _encounterCounter = 0;
    private bool _isInTown;

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
        if (_encounterManager.CheckIfActive() || _isInTown) return;

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
            SceneManager.LoadScene(1);
            // TODO: pause timer while in shop
        }
    }

    public void ResetTravelManager()
    {
        Destroy(gameObject);
    }

    public void SetInTown(bool isInTown)
    {
        _isInTown = isInTown;
    }

    public bool IsInTown()
    {
        return _isInTown;
    }

    public TownSO GetNextTown()
    {
        if (_towns.Count > 0)
        {
            TownSO currentTown = _towns[0];
            _towns.RemoveAt(0);
            _isInTown = true;
            return currentTown;
        }
        else
        {
            Debug.Log("No towns left;");
            return null;
        }
    }

}
