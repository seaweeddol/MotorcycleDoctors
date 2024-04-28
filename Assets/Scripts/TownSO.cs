using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Twon", fileName = "New Town")]
public class TownSO : ScriptableObject
{
    [field: SerializeField]
    public string TownName { get; private set; }

    [field: SerializeField]
    public string TownDescription { get; private set; }

    [field: SerializeField]
    public int MoneyOnArrival { get; private set; }

    [field: SerializeField]
    public int AmmoCost { get; private set; }
    [field: SerializeField]
    public int AmmoAmount { get; private set; }

    [field: SerializeField]
    public int HealthCost { get; private set; }
    [field: SerializeField]
    public int HealthAmount { get; private set; }

    [field: SerializeField]
    public int RepairCost { get; private set; }
    [field: SerializeField]
    public int RepairAmount { get; private set; }

}
