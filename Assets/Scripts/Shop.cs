using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _name;

    [SerializeField]
    private TextMeshProUGUI _healthCostText;
    [SerializeField]
    private SliderBar _healthSlider;

    [SerializeField]
    private TextMeshProUGUI _fuelCostText;
    [SerializeField]
    private SliderBar _fuelSlider;

    [SerializeField]
    private TextMeshProUGUI _motorcycleCostText;
    [SerializeField]
    private SliderBar _motorcycleConditionSlider;

    private Motorcyclist _motorcyclist;
    private GroupStats _groupStats;
    private TownSO _currentTown;

    void Start()
    {
        _groupStats = FindObjectOfType<GroupStats>();
        _currentTown = FindObjectOfType<Town>()._currentTown;
    }

    public void SetMotorcycle(Motorcyclist motorcyclist)
    {
        _motorcyclist = motorcyclist;
    }

    public void BuyHealth()
    {
        if (_groupStats.HasEnoughMoney(_currentTown.HealthCost) && !_motorcyclist.IsAtMaxHealth())
        {
            _groupStats.UpdateMoney(-_currentTown.HealthCost);
            _motorcyclist.UpdateHealth(_currentTown.HealthAmount);
            _healthSlider.SetCurrentValue(_motorcyclist._currentHealth);
        }
        else
        {
            // TODO display some UI, or disable button
        }
    }

    public void BuyFuel()
    {
        if (_groupStats.HasEnoughMoney(_currentTown.FuelCost) && !_motorcyclist.IsAtMaxFuel())
        {
            _groupStats.UpdateMoney(-_currentTown.FuelCost);
            _motorcyclist.UpdateFuel(_currentTown.FuelAmount);
            _fuelSlider.SetCurrentValue(_motorcyclist._currentFuel);
        }
        else
        {
            // TODO display some UI, or disable button
        }
    }

    public void RepairMotorcycle()
    {
        if (_groupStats.HasEnoughMoney(_currentTown.RepairCost) && !_motorcyclist.IsAtMaxMotorcycleCondition())
        {
            _groupStats.UpdateMoney(-_currentTown.RepairCost);
            _motorcyclist.UpdateMotorcycleCondition(_currentTown.RepairAmount);
            _motorcycleConditionSlider.SetCurrentValue(_motorcyclist._currentMotorcycleCondition);
        }
        else
        {
            // TODO display some UI, or disable button
        }
    }


}
