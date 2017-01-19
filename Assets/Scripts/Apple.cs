﻿using UnityEngine;

public class Apple : MonoBehaviour
{
    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="Apple"/> is cut.
    /// </summary>
    /// <value><c>true</c> if cut; otherwise, <c>false</c>.</value>
    public bool Cut { get; set; }

    [SerializeField]
    private GameObject splashObject;

    private TextMesh applesText;

    /// <summary>
    /// Initialise this apple.
    /// </summary>
    void Start()
    {
        applesText = GameObject.Find("Apples Text").GetComponent<TextMesh>();
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
        if (Cut)
        {
            return;
        }

        if (other.gameObject.name == "Line")
        {
            Cut = true;
            
            // TODO: Add audio
            //Camera.main.GetComponent<AudioSource>().Play();
            Destroy(gameObject);

            Vector3 randomPos = new Vector3(
                                    Random.Range(-1, 1),
                                    Random.Range(0.3f, 0.7f),
                                    Random.Range(-6.5f, -7.5f));
            
            Instantiate(splashObject, randomPos, transform.rotation);

            int currentApples = int.Parse(applesText.text);
            applesText.text = (currentApples + 1).ToString();
        }
    }
}
