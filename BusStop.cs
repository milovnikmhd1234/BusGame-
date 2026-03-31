using UnityEngine;

public partial class BusStop : MonoBehaviour {
    public string stopName;
    public int xpReward = 50;
    public float requiredStopSpeed = 0.5f;

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            
            // Pokud autobus skoro stojí
            if (rb.velocity.magnitude < requiredStopSpeed) {
                Debug.Log("Zastavil jsi na: " + stopName + ". Získáváš XP!");
                GameManager.instance.AddXP(xpReward);
                // Zde by se spustil zvuk otevírání dveří
                this.enabled = false; // Zamezí opakovanému braní XP na jedné zastávce
            }
        }
    }
}
