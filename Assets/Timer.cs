using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
	/// <summary>
	/// Gets or sets the reference to the alert object.
	/// </summary>
	/// <value>The alert object.</value>
	public GameObject alertObject { get; set; }

	private GUIText timerGuiText;

	/// <summary>
	/// Initialises this timer.
	/// </summary>
	void Start()
	{
		timerGuiText = GetComponent<GUIText>(gameObject);
		InvokeRepeating("ReduceTime", 1, 1);
	}

	/// <summary>
	/// Reduces the time.
	/// </summary>
	void ReduceTime()
	{
		int currentTime = int.Parse(timerGuiText.text);
		
		if (currentTime == 1)
		{
			Time.timeScale = 0;
			Instantiate(alertObject, new Vector3(0.5f, 0.5f, 0), transform.rotation);
			GetComponent<AudioSource>().Play();
			GameObject.Find("Score Icon").GetComponent<AudioSource>().Stop();
		}

		timerGuiText.text = (currentTime - 1).ToString();
	}

	/// <summary>
	/// Update this timer.
	/// </summary>
	void Update()
	{
		Scene currentScene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(currentScene.buildIndex);
	}
}
