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
    private TextMeshProUGUI _moneyText;
    [SerializeField]
    private TextMeshProUGUI _ammoText;
    [SerializeField]
    private TextMeshProUGUI _medicineText;

    void Start()
    {
        _moneyText.text = "$" + _money.ToString();
        _ammoText.text = _ammo.ToString();
        _medicineText.text = _medicine.ToString();
    }

    public void UpdateMoney(int amount)
    {
        _money += amount;
        _moneyText.text = "$" + _money;
    }

    public void UpdateAmmo(int amount)
    {
        _ammo += amount;
        _ammoText.text = _ammo.ToString();
    }

    public void UpdateMedicine(int amount)
    {
        _medicine += amount;
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
}
