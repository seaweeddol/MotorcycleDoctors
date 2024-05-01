using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        _townName.text = _currentTown.TownName + " Shop";
    }

    void Update()
    {
        if (_welcomeGO.activeSelf)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _welcomeGO.SetActive(false);
                _shopGO.SetActive(true);
                SetupShop();
            }
        }
    }

    void SetupShop()
    {
        // TODO: need to hide traveling UI while in shop
        // TODO: need to show money while in shop

        foreach (Motorcyclist motorcyclist in _encounterManager._motorcyclists)
        {
            GameObject motorcyclistShop = Instantiate(_motorcyclistShopGO, _motorcyclistShopParent.transform);
            motorcyclistShop.GetComponent<Shop>().SetMotorcyclist(motorcyclist);
        }
    }
    public void LeaveTown()
    {
        foreach (Motorcyclist motorcyclist in _encounterManager._motorcyclists)
        {
            motorcyclist.ResetSliderParents();
        }

        for (int i = 0; i < _motorcyclistShopParent.transform.childCount; i++)
        {
            Destroy(_motorcyclistShopParent.transform.GetChild(0).gameObject);
        }

        _travelManager.SetInTown(false);
        SceneManager.LoadScene(0);
    }
}
