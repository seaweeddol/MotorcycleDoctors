using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        // if (_encounterParent.activeSelf && _continuePrompt.activeSelf)
        if (_encounterParent.activeSelf)
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
            _continuePrompt.SetActive(false);
            _optionParent.SetActive(true);
            foreach (EncounterOptionSO encounterOption in _currentEncounter.EncounterOptions)
            {
                Debug.Log(encounterOption);
                GameObject option = Instantiate(_optionPrefab, _optionParent.transform);
                option.GetComponent<EncounterOption>().SetEncounter(encounterOption.Encounter);
                option.GetComponentInChildren<TextMeshProUGUI>().text = encounterOption.OptionText;
            }
        }
        else
        {
            _optionParent.SetActive(false);
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
        if (_currentEncounter.IsAllMotorcycleConditionAffected)
        {
            foreach (Motorcyclist motorcyclist in _motorcyclists)
            {
                if (_currentEncounter.FillMaxMotorcycleCondition)
                {
                    motorcyclist.MaxOutMotorcycleCondition();
                }
                else
                {
                    motorcyclist.UpdateMotorcycleCondition(_currentEncounter.MotorcycleConditionChange);

                }
            }
        }
        else
        {
            int randomIndex = Random.Range(0, _motorcyclists.Count);
            _motorcyclists[randomIndex].UpdateMotorcycleCondition(_currentEncounter.MotorcycleConditionChange);
        }

    }

    private void DisableEncounter()
    {
        while (_optionParent.transform.childCount > 0)
        {
            DestroyImmediate(_optionParent.transform.GetChild(0).gameObject);
        }

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
