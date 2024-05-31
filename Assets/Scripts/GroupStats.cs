using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GroupStats : MonoBehaviour
{
    [SerializeField]
    private int _money = 20;
    [SerializeField]
    private int _ammo = 20;
    [SerializeField]
    private int _medicine = 2;

    [SerializeField]
    private GameObject _statsParent;
    [SerializeField]
    private GameObject _moneyGO;
    [SerializeField]
    private TextMeshProUGUI _moneyText;

    [SerializeField]
    private GameObject _ammoGO;
    [SerializeField]
    private TextMeshProUGUI _ammoText;

    [SerializeField]
    private GameObject _medicineGO;
    [SerializeField]
    private TextMeshProUGUI _medicineText;

    void Start()
    {
        _moneyText.text = "$" + _money.ToString();
        _ammoText.text = _ammo.ToString();
        _medicineText.text = _medicine.ToString();
    }

    // TODO add ability to use medicine

    public void UpdateMoney(int amount)
    {
        _money = Mathf.Max(0, _money + amount);
        _moneyText.text = "$" + _money;
    }

    public void UpdateAmmo(int amount)
    {
        _ammo = Mathf.Max(0, _ammo + amount);
        _ammoText.text = _ammo.ToString();
    }

    public void UpdateMedicine(int amount)
    {
        _medicine = Mathf.Max(0, _medicine + amount);
        _medicineText.text = _medicine.ToString();
    }

    public bool HasEnoughMoney(int amountToSubtract)
    {
        int moneyAfterCost = _money - amountToSubtract;
        if (moneyAfterCost < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void SetParentsOfStats(Transform moneyParent, Transform ammoParent, Transform medicineParent)
    {
        _moneyGO.transform.SetParent(moneyParent);
        _ammoGO.transform.SetParent(ammoParent);
        _medicineGO.transform.SetParent(medicineParent);
    }

    public void ResetStatParents()
    {
        _moneyGO.transform.SetParent(_statsParent.transform);
        _ammoGO.transform.SetParent(_statsParent.transform);
        _medicineGO.transform.SetParent(_statsParent.transform);
    }
}
