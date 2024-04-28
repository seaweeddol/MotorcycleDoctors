using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Motorcyclist : MonoBehaviour
{
    [SerializeField]
    private string _motorcyclistName = "Jerry";

    [SerializeField]
    private int _maxHealth = 5;

    [SerializeField]
    private int _maxFuel = 20;

    [SerializeField]
    private int _maxMotorcycleHealth = 3;

    [SerializeField]
    private TextMeshProUGUI _nameText;

    [SerializeField]
    private SliderBar _healthSlider;

    [SerializeField]
    private SliderBar _fuelSlider;

    [SerializeField]
    private SliderBar _motorcycleHealthSlider;

    [SerializeField]
    private float _fuelDrainTimer = 2f;

    private int _currentHealth;
    private int _currentFuel;
    private int _currentMotorcycleHealth;
    private float _fuelTimer = 0f;
    private bool _isDead = false;
    private bool _isFirstTravel = true;

    private float timer = 0f;

    private int _HEALTH = 0;
    private int _FUEL = 1;
    private int _MOTORCYCLEHEALTH = 2;

    void Start()
    {
        // if (_isFirstTravel)
        // {
        _currentHealth = _maxHealth;
        _currentFuel = _maxFuel;
        _currentMotorcycleHealth = _maxMotorcycleHealth;
        _isFirstTravel = false;
        // }
        // else
        // {
        //     _healthSlider.SetCurrentValue(_currentHealth);
        //     _motorcycleHealthSlider.SetCurrentValue(_currentMotorcycleHealth);
        //     _fuelSlider.SetCurrentValue(_currentFuel);
        // }

        _nameText.text = _motorcyclistName;
        _healthSlider.SetMaxValue(_maxHealth);
        _fuelSlider.SetMaxValue(_maxFuel);
        _motorcycleHealthSlider.SetMaxValue(_maxMotorcycleHealth);
    }

    void Update()
    {
        _fuelTimer += Time.deltaTime;
        timer += Time.deltaTime;
        if (_fuelTimer >= _fuelDrainTimer)
        {
            _fuelTimer = 0;
            UpdateFuel(-1);
        }

        if (timer >= 6f)
        {
            timer = 0f;
            Debug.Log("reloading");
            SceneManager.LoadScene(0);
        }
    }

    public void UpdateHealth(int amount)
    {
        _currentHealth += amount;
        _healthSlider.SetCurrentValue(_currentHealth);
    }

    public void UpdateMotorcycleHealth(int amount)
    {
        _currentMotorcycleHealth += amount;
        _motorcycleHealthSlider.SetCurrentValue(_currentMotorcycleHealth);
    }

    public void UpdateFuel(int amount)
    {
        _currentFuel += amount;
        _fuelSlider.SetCurrentValue(_currentFuel);
    }

    public void FillFuelCompletely()
    {
        _currentFuel = _maxFuel;
        _fuelSlider.SetCurrentValue(_currentFuel);
    }


    private void CheckIfDead(int type)
    {
        if (_isDead) return;

        switch (type)
        {
            case 0:
                if (_currentHealth <= 0)
                {

                }
                break;
            case 1:
                if (_currentFuel <= 0)
                {

                }
                break;
            case 2:
                if (_currentMotorcycleHealth <= 0)
                {

                }
                break;
        }

    }
}
