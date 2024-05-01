using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Town", fileName = "New Town")]
public class TownSO : ScriptableObject
{
    [field: SerializeField]
    public bool IsFinalTown { get; private set; }

    [field: SerializeField]
    public string TownName { get; private set; }

    [field: SerializeField]
    public string TownDescription { get; private set; }

    [field: SerializeField]
    public int MoneyOnArrival { get; private set; }

    /*
    Medicine and ammo are only available in the first shop.
    */
    [field: SerializeField]
    public bool isFirstShop { get; private set; }
    [field: SerializeField]
    public int MedicineCost { get; private set; }
    [field: SerializeField]
    public int MedicineAmount { get; private set; }
    [field: SerializeField]
    public int AmmoCost { get; private set; }
    [field: SerializeField]
    public int AmmoAmount { get; private set; }

    [field: SerializeField]
    public int HealthCost { get; private set; }
    [field: SerializeField]
    public int HealthAmount { get; private set; }

    [field: SerializeField]
    public int FuelCost { get; private set; }
    [field: SerializeField]
    public int FuelAmount { get; private set; }

    [field: SerializeField]
    public int RepairCost { get; private set; }
    [field: SerializeField]
    public int RepairAmount { get; private set; }

}
