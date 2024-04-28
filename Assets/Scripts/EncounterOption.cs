using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterOption : MonoBehaviour
{
    private EncounterSO _encounter;

    public void SelectOption()
    {
        Debug.Log("option: " + _encounter.EncounterText);
        /*
            when an option is selected, we want to update the encounter text to the selected option text
            get the index of the selected option
            _encounter = _encounter.EncounterOptions[selectedIndex]
            _encounterText.text = _encounter.EncounterText;
        */
    }

    public void SetEncounter(EncounterSO encounter)
    {
        _encounter = encounter;
    }
}
