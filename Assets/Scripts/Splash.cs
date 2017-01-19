using UnityEngine;

public class Splash : MonoBehaviour
{
    private Color randomAlpha;
    private float currentAlpha;

    /// <summary>
    /// Initialise this splash.
    /// </summary>
    void Start()
    {
        randomAlpha = new Color(1, 1, 1, Random.Range(0.3f, 0.5f));
        gameObject.GetComponent<Renderer>().material.color = randomAlpha;
        InvokeRepeating("ReduceAlpha", 0.05f, 0.1f);
    }

    /// <summary>
    /// Reduces the opacity of this splash.
    /// </summary>
    void ReduceAlpha()
    {
        currentAlpha = gameObject.GetComponent<Renderer>().material.color.a;

        if (gameObject.GetComponent<Renderer>().material.color.a <= 0.01f)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, currentAlpha - 0.1f);
        }
    }
}
