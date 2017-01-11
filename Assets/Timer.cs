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

    /// <summary>
    /// Initialises this timer.
    /// </summary>
    void Start()
    {
        timerText = gameObject.GetComponent<TextMesh>();
        InvokeRepeating("ReduceTime", 1, 1f);
    }

    /// <summary>
    /// Reduces the time.
    /// </summary>
    void ReduceTime()
    {
        int currentTime = int.Parse(timerText.text);
		
        if (currentTime == 1)
        {
            Time.timeScale = 0;
            Instantiate(alertObject, new Vector3(0.5f, 0.5f, 0), transform.rotation);
            // TODO: Add audio
            //GetComponent<AudioSource>().Play();
            //GameObject.Find("Score Text").GetComponent<AudioSource>().Stop();
        }

        timerText.text = (currentTime - 1).ToString();
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
