using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text moneyText;
    public Text speedText;
    public Text passengersText;
    public Text stopText;
    public Text fpsText;

    private float fpsTimer = 0f;
    private int frames = 0;

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
        UpdateHUD();
        UpdateFPS();
    }

    private void UpdateHUD()
    {
        if (EconomyManager.Instance != null)
            moneyText.text = EconomyManager.Instance.money + " Kč";

        if (GameManager.Instance != null && GameManager.Instance.PlayerBus != null)
            speedText.text = Mathf.RoundToInt(GameManager.Instance.PlayerBus.GetSpeedKmh()) + " km/h";

        if (PassengerSystem.Instance != null)
            passengersText.text = PassengerSystem.Instance.passengersOnBoard + " cestujících";

        if (GameManager.Instance != null && GameManager.Instance.currentStop != null)
            stopText.text = GameManager.Instance.currentStop.stopName;
        else
            stopText.text = "-";
    }

    private void UpdateFPS()
    {
        frames++;
        fpsTimer += Time.unscaledDeltaTime;

        if (fpsTimer >= 0.5f)
        {
            float fps = frames / fpsTimer;
            fpsText.text = Mathf.RoundToInt(fps) + " FPS";
            frames = 0;
            fpsTimer = 0f;
        }
    }
}
