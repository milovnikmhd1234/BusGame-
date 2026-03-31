using UnityEngine;

public class BusSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] busPrefabs;

    public GameObject SpawnBus(int index)
    {
        GameObject bus = Instantiate(busPrefabs[index], spawnPoint.position, spawnPoint.rotation);
        GameManager.Instance.PlayerBus = bus.GetComponent<BusController>();
        return bus;
    }
}
