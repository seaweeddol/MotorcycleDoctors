using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterOption : MonoBehaviour
{
    private EncounterSO _encounter;

    public void SelectOption()
    {
        Debug.Log("option: " + _encounter.EncounterText);
        FindObjectOfType<EncounterManager>().EnableEncounter(_encounter);
    }

    public void SetEncounter(EncounterSO encounter)
    {
        _encounter = encounter;
    }
}
