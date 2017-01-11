using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Runtime.InteropServices;

public class Apple : MonoBehaviour
{
    [SerializeField]
    private GameObject splashObject;

    private GUIText scoreGuiText;

    private Vector3 randomPos = new Vector3(
                                    Random.Range(-1, 1),
                                    Random.Range(0.3f, 0.7f),
                                    Random.Range(-6.5f, -7.5f));

    /// <summary>
    /// Initialise this apple.
    /// </summary>
    void Start()
    {
        scoreGuiText = GetComponent<GUIText>(GameObject.Find("Score Text"));
    }

    /// <summary>
    /// Update this apple.
    /// </summary>
    void Update()
    {
        if (gameObject.transform.position.y < -36)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Raises the collision enter event.
    /// </summary>
    /// <param name="other">Other.</param>
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Line")
        {
            Camera.main.GetComponent<AudioSource>().Play();
            Destroy(gameObject);

            Instantiate(splashObject, randomPos, transform.rotation);

            int currentScore = int.Parse(scoreGuiText.text);
            scoreGuiText.text = (currentScore + 1).ToString();
        }
    }
}
