using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Encounter Option", fileName = "New Encounter Option")]
public class EncounterOptionSO : ScriptableObject
{
    [field: SerializeField]
    public string OptionText { get; private set; }

    [field: SerializeField]
    public EncounterSO Encounter { get; private set; }
}
