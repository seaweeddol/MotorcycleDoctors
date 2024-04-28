using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Encounter : MonoBehaviour
{
    public Encounter(EncounterSO encounter)
    {
        _encounter = encounter;
    }
    [SerializeField]
    private TextMeshProUGUI _encounterText;

    [SerializeField]
    private EncounterSO _encounter;

    [SerializeField]
    private GameObject _continuePrompt;

    [SerializeField]
    private GameObject _optionParent;

    [SerializeField]
    private GameObject _optionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        _encounterText.text = _encounter.EncounterText;

        if (_encounter.EncounterOptions != null)
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

    // Update is called once per frame
    void Update()
    {

    }
}
