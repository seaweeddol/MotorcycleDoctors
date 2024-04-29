using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Town : MonoBehaviour
{
    [Header("Welcome Section")]
    [SerializeField]
    private GameObject _welcomeGO;
    [SerializeField]
    private TextMeshProUGUI _welcomeText;
    [SerializeField]
    private TextMeshProUGUI _townDescription;

    [Header("Shop Section")]
    [SerializeField]
    private GameObject _shopGO;
    [SerializeField]
    private TextMeshProUGUI _townName;
    [SerializeField]
    private GameObject _motorcyclistShopParent;
    [SerializeField]
    private GameObject _motorcyclistShopGO;

    private TravelManager _travelManager;
    private EncounterManager _encounterManager;

    public TownSO _currentTown { get; private set; }

    void Start()
    {
        _travelManager = FindObjectOfType<TravelManager>();
        _encounterManager = FindObjectOfType<EncounterManager>();

        _currentTown = _travelManager.GetNextTown();

        _welcomeGO.SetActive(true);
        _welcomeText.text = "Welcome to " + _currentTown.TownName;
        _townDescription.text = _currentTown.TownDescription;
    }

    void Update()
    {
        if (_welcomeGO.activeSelf)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _welcomeGO.SetActive(false);
                _shopGO.SetActive(true);
                // TODO set up shop
            }
        }
    }

    void SetupShop()
    {
        foreach (Motorcyclist motorcyclist in _encounterManager._motorcyclists)
        {
            GameObject motorcyclistShop = Instantiate(_motorcyclistShopGO, _motorcyclistShopParent.transform);

        }
    }
}
