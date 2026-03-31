using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public int totalXP;
    public int money;

    void Awake() {
        instance = this;
        LoadGame(); // Načte data při startu
    }

    public void AddXP(int amount) {
        totalXP += amount;
        money += amount / 2; // Příklad výdělku
        SaveGame();
    }

    public void SaveGame() {
        PlayerPrefs.SetInt("PlayerXP", totalXP);
        PlayerPrefs.SetInt("PlayerMoney", money);
        PlayerPrefs.Save();
        Debug.Log("Hra uložena!");
    }

    void LoadGame() {
        totalXP = PlayerPrefs.GetInt("PlayerXP", 0);
        money = PlayerPrefs.GetInt("PlayerMoney", 1000); // Startovní kapitál
    }
}
