using UnityEngine;

public class Burger : MonoBehaviour
{
    [SerializeField]
    private GameObject splashObject;

    private TextMesh burgersText;

    /// <summary>
    /// Initialise this apple.
    /// </summary>
    void Start()
    {
        burgersText = GameObject.Find("Burgers Text").GetComponent<TextMesh>();
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
            // TODO: Add audio
            //Camera.main.GetComponent<AudioSource>().Play();
            Destroy(gameObject);

            Vector3 randomPos = new Vector3(
                                    Random.Range(-1, 1),
                                    Random.Range(0.3f, 0.7f),
                                    Random.Range(-6.5f, -7.5f));

            Instantiate(splashObject, randomPos, transform.rotation);

            int currentBurgers = int.Parse(burgersText.text);
            burgersText.text = (currentBurgers + 1).ToString();
        }
    }
}
