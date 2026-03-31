using UnityEngine;

[System.Serializable]
public class BusData
{
    public string busName;
    public int price;
    public bool unlocked;
}

public class BusShop : MonoBehaviour
{
    public static BusShop Instance;

    public BusData[] buses;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public bool BuyBus(int index)
    {
        BusData bus = buses[index];

        if (bus.unlocked)
        {
            Debug.Log("Bus už je odemčený");
            return false;
        }

        if (EconomyManager.Instance.SpendMoney(bus.price))
        {
            bus.unlocked = true;
            Debug.Log("Odemčen bus: " + bus.busName);
            return true;
        }

        return false;
    }
}
