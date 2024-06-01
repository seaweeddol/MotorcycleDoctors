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

    [SerializeField]
    private EncounterSO _healthDeathEncounter;
    [SerializeField]
    private EncounterSO _fuelDeathEncounter;
    [SerializeField]
    private EncounterSO _motorcycleDeathEncounter;

    private float _timer = 0f;
    private int _encounterCounter = 0;
    private bool _isInTown;
    private bool _isFirstTown = true;

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
        if (_isFirstTown)
        {
            _isFirstTown = false;
            SceneManager.LoadScene(1);
        }

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
            _timer = 0f;
            _encounterCounter = 0;
            SceneManager.LoadScene(1);
        }
    }

    public void EnableDeathEncounter(int encounterIndex, Motorcyclist motorcyclist)
    {
        switch (encounterIndex)
        {
            case 0:
                _encounterManager.EnableEncounter(_healthDeathEncounter, motorcyclist);
                break;
            case 1:
                _encounterManager.EnableEncounter(_fuelDeathEncounter, motorcyclist);
                break;
            case 2:
                _encounterManager.EnableEncounter(_motorcycleDeathEncounter, motorcyclist);
                break;
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

    public bool IsInEncounter()
    {
        return _encounterManager.CheckIfActive();
    }

    public TownSO GetNextTown()
    {
        if (_towns.Count > 0)
        {
            _isInTown = true;
            TownSO currentTown = _towns[0];
            _towns.RemoveAt(0);
            return currentTown;
        }
        else
        {
            Debug.Log("No towns left;");
            return null;
        }
    }
}
