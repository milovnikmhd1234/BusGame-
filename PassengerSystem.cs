using UnityEngine;

public class PassengerSystem : MonoBehaviour
{
    public static PassengerSystem Instance;

    public int passengersOnBoard = 0;

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

    public void OnStopCompleted()
    {
        int newPassengers = Random.Range(3, 12); // náhodný počet
        passengersOnBoard += newPassengers;

        int earnings = newPassengers * 8; // 8 Kč za cestujícího
        EconomyManager.Instance.AddMoney(earnings);

        Debug.Log("Nastoupilo: " + newPassengers + " | Výdělek: " + earnings + " Kč");
    }
}
