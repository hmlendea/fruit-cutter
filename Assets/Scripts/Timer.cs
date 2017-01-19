using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    /// <summary>
    /// Gets or sets the reference to the alert object.
    /// </summary>
    /// <value>The alert object.</value>
    public GameObject alertObject;

    private TextMesh timerText;
    private TextMesh burgersText;

    /// <summary>
    /// Initialises this timer.
    /// </summary>
    void Start()
    {
        timerText = GameObject.Find("Timer Text").GetComponent<TextMesh>();
        burgersText = GameObject.Find("Burgers Text").GetComponent<TextMesh>();

        InvokeRepeating("Tick", 1, 1f);
    }

    /// <summary>
    /// Is called every tick.
    /// </summary>
    void Tick()
    {
        ReduceTime();
        CheckForGameOver();
    }

    /// <summary>
    /// Reduces the time.
    /// </summary>
    void ReduceTime()
    {
        int currentTime = int.Parse(timerText.text);

        timerText.text = (currentTime - 1).ToString();
    }

    /// <summary>
    /// Checks for game over.
    /// </summary>
    void CheckForGameOver()
    {
        int currentTime = int.Parse(timerText.text);
        int currentBurgers = int.Parse(burgersText.text);

        if (currentTime == 1 || currentBurgers >= 3)
        {
            EndGame();
        }
    }

    /// <summary>
    /// Ends the game.
    /// </summary>
    void EndGame()
    {
        Time.timeScale = 0;
        Instantiate(alertObject, new Vector3(0.5f, 0.5f, 0), transform.rotation);

        // TODO: Add audio
        //GetComponent<AudioSource>().Play();
        //GameObject.Find("Score Text").GetComponent<AudioSource>().Stop();
    }

    /// <summary>
    /// Reload this timer.
    /// </summary>
    void Reload()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
