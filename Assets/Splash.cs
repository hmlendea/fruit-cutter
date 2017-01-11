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
        GetComponent<Renderer>(gameObject).material.color = randomAlpha;
        InvokeRepeating("ReduceAlpha", 0.3f, 0.3f);
    }

    /// <summary>
    /// Reduces the opacity of this splash.
    /// </summary>
    void ReduceAlpha()
    {
        currentAlpha = GetComponent<Renderer>(gameObject).material.color.a;

        if (GetComponent<Renderer>(gameObject).material.color.a <= 0.1f)
        {
            Destroy(gameObject);
        }
        else
        {
            GetComponent<Renderer>(gameObject).material.color = new Color(1, 1, 1, currentAlpha - 0.1f);
        }
    }
}
