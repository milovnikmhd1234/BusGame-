using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

    public MapDefinition[] maps;
    public int currentMapIndex = 0;

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

    public void LoadMap(int index)
    {
        if (index < 0 || index >= maps.Length) return;

        currentMapIndex = index;
        SceneManager.LoadScene(maps[index].sceneName);
    }
}
