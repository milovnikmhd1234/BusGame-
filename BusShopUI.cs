using UnityEngine;
using UnityEngine.UI;

public class BusShopUI : MonoBehaviour
{
    public Text busNameText;
    public Text priceText;
    public Text statusText;

    public int currentIndex = 0;

    private void Start()
    {
        Refresh();
    }

    public void NextBus()
    {
        currentIndex++;
        if (currentIndex >= BusShop.Instance.buses.Length)
            currentIndex = 0;

        Refresh();
    }

    public void PreviousBus()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = BusShop.Instance.buses.Length - 1;

        Refresh();
    }

    public void BuyCurrentBus()
    {
        bool success = BusShop.Instance.BuyBus(currentIndex);
        Refresh();
    }

    public void SelectCurrentBus()
    {
        // tady můžeš uložit index vybraného busu do GameManageru
        PlayerPrefs.SetInt("SelectedBusIndex", currentIndex);
        PlayerPrefs.Save();
        statusText.text = "Vybrán: " + BusShop.Instance.buses[currentIndex].busName;
    }

    private void Refresh()
    {
        var bus = BusShop.Instance.buses[currentIndex];
        busNameText.text = bus.busName;
        priceText.text = bus.price + " Kč";
        statusText.text = bus.unlocked ? "Odemčeno" : "Zamčeno";
    }
}
