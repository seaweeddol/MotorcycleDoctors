using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Encounter", fileName = "New Encounter")]
public class EncounterSO : ScriptableObject
{
    [field: SerializeField]
    public string EncounterText { get; private set; }

    [field: SerializeField]
    public List<EncounterOptionSO> EncounterOptions { get; private set; } = null;

    [field: SerializeField]
    public bool FillMaxHealth { get; private set; }
    [field: SerializeField]
    public int HealthChange { get; private set; }
    [field: SerializeField]
    public bool IsAllHealthAffected { get; private set; }
    [field: SerializeField]
    public int MotorcyclistHealthAffected { get; private set; }

    [field: SerializeField]
    public bool FillMaxMotorcycleHealth { get; private set; }
    [field: SerializeField]
    public int MotorcycleHealthChange { get; private set; }
    [field: SerializeField]
    public bool IsAllMotorcycleHealthAffected { get; private set; }
    [field: SerializeField]
    public int MotorcyclistMotorcycleHealthAffected { get; private set; }

    [field: SerializeField]
    public bool FillMaxFuel { get; private set; }
    [field: SerializeField]
    public int FuelChange { get; private set; }
    [field: SerializeField]
    public bool IsAllFuelAffected { get; private set; }
    [field: SerializeField]
    public int MotorcyclistFuelAffected { get; private set; }

    [field: SerializeField]
    public int MoneyChange { get; private set; }
    [field: SerializeField]
    public int AmmoChange { get; private set; }
    [field: SerializeField]
    public int MedicineChange { get; private set; }
}
