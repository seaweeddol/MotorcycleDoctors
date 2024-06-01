using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Motorcyclist : MonoBehaviour
{
    [SerializeField]
    private GameObject _motorcyclistImage;

    [SerializeField]
    private string _motorcyclistName = "Jerry";

    [SerializeField]
    private int _maxHealth = 5;

    [SerializeField]
    private int _maxFuel = 20;

    [SerializeField]
    private int _maxMotorcycleCondition = 3;

    [SerializeField]
    private TextMeshProUGUI _nameText;

    [SerializeField]
    private GameObject _motorcycleStatsParent;

    [SerializeField]
    private GameObject _healthSliderGO;

    [SerializeField]
    private SliderBar _healthSlider;

    [SerializeField]
    private GameObject _fuelSliderGO;

    [SerializeField]
    private SliderBar _fuelSlider;

    [SerializeField]
    private GameObject _motorcycleSliderGO;

    [SerializeField]
    private SliderBar _motorcycleConditionSlider;

    [SerializeField]
    private float _fuelDrainTimer = 2f;

    [SerializeField]
    private int _healthLostEachDay = 1;
    [SerializeField]
    private int _fuelLostEachDay = 0;
    [SerializeField]
    private int _motorcycleConditionLostEachDay = 0;

    private TravelManager _travelManager;

    public int _currentHealth { get; private set; }
    public int _currentFuel { get; private set; }
    public int _currentMotorcycleCondition { get; private set; }
    private float _fuelTimer = 0f;
    private bool _isDead = false;
    private bool _isFirstTravel = true;

    private int _HEALTH = 0;
    private int _FUEL = 1;
    private int _MOTORCYCLECONDITION = 2;

    void Start()
    {
        _currentHealth = _maxHealth;
        _currentFuel = _maxFuel;
        _currentMotorcycleCondition = _maxMotorcycleCondition;
        _isFirstTravel = false;

        _nameText.text = _motorcyclistName;
        _healthSlider.SetMaxValue(_maxHealth);
        _fuelSlider.SetMaxValue(_maxFuel);
        _motorcycleConditionSlider.SetMaxValue(_maxMotorcycleCondition);

        _travelManager = FindObjectOfType<TravelManager>();
    }

    void Update()
    {
        // TODO check if dead (fuel/health/motorcycle condition runs out)
        if (_isDead) return;

        if (_travelManager.IsInTown() || _travelManager.IsInEncounter())
        {
            _fuelTimer = 0;
            return;
        }

        _fuelTimer += Time.deltaTime;
        if (_fuelTimer >= _fuelDrainTimer)
        {
            _fuelTimer = 0;
            UpdateFuel(-1);
        }
    }

    public void UpdateHealth(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, _maxHealth);
        _healthSlider.SetCurrentValue(_currentHealth);
        CheckIfDead(_HEALTH);
    }

    public void MaxOutHealth()
    {
        _currentHealth = _maxHealth;
        _healthSlider.SetCurrentValue(_currentHealth);
    }

    public bool IsAtMaxHealth()
    {
        if (_currentHealth == _maxHealth)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UpdateFuel(int amount)
    {
        _currentFuel = Mathf.Clamp(_currentFuel + amount, 0, _maxFuel);
        _fuelSlider.SetCurrentValue(_currentFuel);
        CheckIfDead(_FUEL);
    }

    public void MaxOutFuel()
    {
        _currentFuel = _maxFuel;
        _fuelSlider.SetCurrentValue(_currentFuel);
    }

    public bool IsAtMaxFuel()
    {
        if (_currentFuel == _maxFuel)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UpdateMotorcycleCondition(int amount)
    {
        _currentMotorcycleCondition = Mathf.Clamp(_currentMotorcycleCondition + amount, 0, _maxMotorcycleCondition);
        _motorcycleConditionSlider.SetCurrentValue(_currentMotorcycleCondition);
        CheckIfDead(_MOTORCYCLECONDITION);
    }

    public void MaxOutMotorcycleCondition()
    {
        _currentMotorcycleCondition = _maxMotorcycleCondition;
        _motorcycleConditionSlider.SetCurrentValue(_currentFuel);
    }

    public bool IsAtMaxMotorcycleCondition()
    {
        if (_currentMotorcycleCondition == _maxMotorcycleCondition)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string GetName()
    {
        return _motorcyclistName;
    }

    private bool CheckIfDead(int type)
    {
        if (_isDead) return true;

        switch (type)
        {
            case 0:
                if (_currentHealth <= 0)
                {
                    _travelManager.EnableDeathEncounter(_HEALTH, this);
                    Debug.Log(_motorcyclistName + " died");
                    return true;
                }
                break;
            case 1:
                if (_currentFuel <= 0)
                {
                    _travelManager.EnableDeathEncounter(_FUEL, this);
                    Debug.Log(_motorcyclistName + " is out of fuel and has to be left behind.");
                    return true;
                }
                break;
            case 2:
                if (_currentMotorcycleCondition <= 0)
                {
                    _travelManager.EnableDeathEncounter(_MOTORCYCLECONDITION, this);
                    // TODO: split remaining fuel between other motorcyclists
                    Debug.Log(_motorcyclistName + "'s motorcycle is beyond repair, and they must be left behind.");
                    return true;
                }
                break;
        }

        return false;
    }

    public void SetParentsOfSliders(Transform healthParent, Transform fuelParent, Transform motorcycleParent)
    {
        _healthSliderGO.transform.SetParent(healthParent);
        _healthSliderGO.transform.SetAsFirstSibling();
        _fuelSliderGO.transform.SetParent(fuelParent);
        _fuelSliderGO.transform.SetAsFirstSibling();
        _motorcycleSliderGO.transform.SetParent(motorcycleParent);
        _motorcycleSliderGO.transform.SetAsFirstSibling();
    }

    public void ResetSliderParents()
    {
        _healthSliderGO.transform.SetParent(_motorcycleStatsParent.transform);
        _fuelSliderGO.transform.SetParent(_motorcycleStatsParent.transform);
        _motorcycleSliderGO.transform.SetParent(_motorcycleStatsParent.transform);
    }

    public void DestroyMotorcyclist()
    {
        // TODO: center motorcyclists
        Destroy(_motorcyclistImage);
        Destroy(_motorcycleStatsParent);
        Destroy(gameObject);
    }
}
