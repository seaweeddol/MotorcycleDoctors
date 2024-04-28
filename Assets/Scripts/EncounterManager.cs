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

    private EncounterSO _encounter;

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
        _encounter = _encounters[randomEncounterIndex];
        _encounters.Remove(_encounter);
        return true;
    }

    public void EnableEncounter(EncounterSO encounter = null)
    {
        if (encounter != null)
        {
            _encounter = encounter;
        }
        else
        {
            if (!SetCurrentEncounter()) return;
        }

        _encounterParent.SetActive(true);

        _encounterText.text = _encounter.EncounterText;

        if (_encounter.EncounterOptions != null && _encounter.EncounterOptions.Count != 0)
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
