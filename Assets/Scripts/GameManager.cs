using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public TMPro.TextMeshProUGUI coinText;
    public TMPro.TextMeshProUGUI levelText;
    public static int coinCount;
    public GameObject gameOverUI;
    private void Awake()
    {
        coinCount = PlayerPrefs.GetInt("coinCount", 0);
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coinCount.ToString();
        levelText.text = "Level " + UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex.ToString();
        if(GameIsOver)
        {
            gameOverUI.SetActive(true);
            coinCount = 0;
        }
    }
     public void Replay()
    {
        // Unsubscribe from input events
        InputSystem.DisableDevice(Keyboard.current);

        // Reset game state variables
        coinCount = 0;
        GameIsOver = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        // Re-enable input events
        InputSystem.EnableDevice(Keyboard.current);
    }
}
