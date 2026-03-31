using UnityEngine;

public class TimetableManager : MonoBehaviour
{
    public static TimetableManager Instance;

    public RouteStop[] route;
    public int currentIndex = 0;

    public float gameTime = 0f; // běží od startu

    public float onTimeBonus = 20f;   // Kč za včas
    public float latePenalty = -10f;  // Kč za velké zpoždění
    public float maxDelay = 60f;      // po kolika sekundách už je to „pozdě“

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

    private void Update()
    {
        gameTime += Time.deltaTime;
    }

    public RouteStop GetCurrentRouteStop()
    {
        if (currentIndex < 0 || currentIndex >= route.Length) return null;
        return route[currentIndex];
    }

    public void OnStopCompleted(BusStop stop)
    {
        RouteStop current = GetCurrentRouteStop();
        if (current == null || current.stop != stop) return;

        float planned = current.plannedTime;
        float delay = gameTime - planned;

        if (Mathf.Abs(delay) <= 15f)
        {
            EconomyManager.Instance.AddMoney((int)onTimeBonus);
            Debug.Log("Včas! Bonus: " + onTimeBonus + " Kč");
        }
        else if (delay > maxDelay)
        {
            EconomyManager.Instance.AddMoney((int)latePenalty);
            Debug.Log("Velké zpoždění! Penalizace: " + latePenalty + " Kč");
        }

        currentIndex++;
    }
}
