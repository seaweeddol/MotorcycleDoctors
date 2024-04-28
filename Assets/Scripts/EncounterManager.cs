using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _encounterParent;

    [SerializeField]
    private List<EncounterSO> _encounters;

    [SerializeField]
    private TextMeshProUGUI _encounterText;

    [SerializeField]
    private GameObject _continuePrompt;

    [SerializeField]
    private GameObject _optionParent;

    [SerializeField]
    private GameObject _optionPrefab;

    [SerializeField]
    private GroupStats _groupStats;

    [SerializeField]
    private List<Motorcyclist> _motorcyclists;

    private EncounterSO _currentEncounter;
    private bool _isEncounterActive;

    void Awake()
    {
        int numEncounterManager = FindObjectsOfType<EncounterManager>().Length;

        if (numEncounterManager > 1)
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
        if (_encounterParent.activeSelf && _continuePrompt.activeSelf)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                DisableEncounter();
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                EnableEncounter();
            }
        }
    }

    public void ResetEncounterManager()
    {
        Destroy(gameObject);
    }

    private bool SetCurrentEncounter()
    {
        if (_encounters.Count == 0)
        {
            Debug.Log("No encounters in _encounters.");
            return false;
        }

        int randomEncounterIndex = Random.Range(0, _encounters.Count);
        _currentEncounter = _encounters[randomEncounterIndex];
        _encounters.Remove(_currentEncounter);
        return true;
    }

    /*
        encounter: Provide if EnableEncounter() is accessed due to option selection.
    */
    public void EnableEncounter(EncounterSO encounter = null)
    {
        if (encounter != null)
        {
            _currentEncounter = encounter;
        }
        else
        {
            if (!SetCurrentEncounter()) return;
        }

        _encounterParent.SetActive(true);

        _encounterText.text = _currentEncounter.EncounterText;

        if (_currentEncounter.EncounterOptions != null && _currentEncounter.EncounterOptions.Count != 0)
        {
            _optionParent.SetActive(true);
            // add encounter option buttons
            // for each encounter option, create a _optionPrefab
            // set button text to encounter text
            // set click action to create a new encounter game object
        }
        else
        {
            _continuePrompt.SetActive(true);
        }

        UpdateStats();
    }

    private void UpdateStats()
    {
        _groupStats.UpdateMoney(_currentEncounter.MoneyChange);
        _groupStats.UpdateAmmo(_currentEncounter.AmmoChange);
        _groupStats.UpdateMedicine(_currentEncounter.MedicineChange);

        // health
        if (_currentEncounter.IsAllHealthAffected)
        {
            foreach (Motorcyclist motorcyclist in _motorcyclists)
            {
                if (_currentEncounter.FillMaxHealth)
                {
                    motorcyclist.MaxOutHealth();
                }
                else
                {
                    motorcyclist.UpdateHealth(_currentEncounter.HealthChange);

                }
            }
        }
        else
        {
            int randomIndex = Random.Range(0, _motorcyclists.Count);
            _motorcyclists[randomIndex].UpdateHealth(_currentEncounter.HealthChange);
        }

        // fuel
        if (_currentEncounter.IsAllFuelAffected)
        {
            foreach (Motorcyclist motorcyclist in _motorcyclists)
            {
                if (_currentEncounter.FillMaxFuel)
                {
                    motorcyclist.MaxOutFuel();
                }
                else
                {
                    motorcyclist.UpdateFuel(_currentEncounter.FuelChange);

                }
            }
        }
        else
        {
            int randomIndex = Random.Range(0, _motorcyclists.Count);
            _motorcyclists[randomIndex].UpdateFuel(_currentEncounter.FuelChange);
        }

        // motorcycle health
        if (_currentEncounter.IsAllMotorcycleHealthAffected)
        {
            foreach (Motorcyclist motorcyclist in _motorcyclists)
            {
                if (_currentEncounter.FillMaxMotorcycleHealth)
                {
                    motorcyclist.MaxOutMotorcycleHealth();
                }
                else
                {
                    motorcyclist.UpdateMotorcycleHealth(_currentEncounter.MotorcycleHealthChange);

                }
            }
        }
        else
        {
            int randomIndex = Random.Range(0, _motorcyclists.Count);
            _motorcyclists[randomIndex].UpdateMotorcycleHealth(_currentEncounter.MotorcycleHealthChange);
        }

    }

    public void SelectOption(EncounterSO encounter)
    {
        /*
            when an option is selected, we want to update the encounter text to the selected option text
            get the index of the selected option
            _encounter = _encounter.EncounterOptions[selectedIndex]
            _encounterText.text = _encounter.EncounterText;
        */
    }

    private void DisableEncounter()
    {
        _encounterParent.SetActive(false);
        _optionParent.SetActive(false);
        _continuePrompt.SetActive(false);
    }

    public bool CheckIfActive()
    {
        if (_encounterParent.activeSelf)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /*
    encounter
    when it's time for an encounter, grab a random EncounterSO from _encounters
        remove the encounter from the list
    instantiate an encounter prefab
    


        initial encounter text
        [encounter with options]
            option 1
                when selected, show option text
                press space to continue
            option 2
                when selected, show option text
                press space to continue
        [encounter with no options]
            press space to continue

    so we basically have two types of encounter screens
        1. encounter with options
        2. encounter with no options


    */
}
