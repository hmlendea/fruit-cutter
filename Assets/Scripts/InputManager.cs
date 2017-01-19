using UnityEngine;

public class InputManager : MonoBehaviour
{
    /// <summary>
    /// Gets or sets the start colour.
    /// </summary>
    /// <value>The start colour.</value>
    public Color StartColour { get; set; }

    /// <summary>
    /// Gets or sets the end colour.
    /// </summary>
    /// <value>The end colour.</value>
    public Color EndColour { get; set; }

    private GameObject lineObject;
    private LineRenderer lineRenderer;

    private int i = 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="InputManager"/> class.
    /// </summary>
    public InputManager()
    {
        StartColour = Color.yellow;
        EndColour = Color.red;
    }

    /// <summary>
    /// Start this line renderer.
    /// </summary>
    void Start()
    {
        Material lineRendererMaterial = new Material(Shader.Find("Mobile/Particles/Additive"));
        
        lineObject = new GameObject("Line");
        lineObject.AddComponent<LineRenderer>();

        lineRenderer = lineObject.GetComponent<LineRenderer>();
        lineRenderer.material = lineRendererMaterial;

        lineRenderer.startColor = StartColour;
        lineRenderer.startWidth = 0.3f;

        lineRenderer.endColor = EndColour;
        lineRenderer.endWidth = 0.05f;

        lineRenderer.numPositions = 0;
    }

    /// <summary>
    /// Update this line renderer.
    /// </summary>
    void Update()
    {
        // Prevent line drawing when the game is over
        if (Time.timeScale == 0)
            return;

        // Left Mouse Button is down
        if (Input.GetMouseButton(0))
        {
            lineRenderer.numPositions = i + 1;

            Vector3 mPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15);
            lineRenderer.SetPosition(i, Camera.main.ScreenToWorldPoint(mPosition));

            i += 1;

            BoxCollider boxCollider = lineObject.AddComponent<BoxCollider>();
            boxCollider.transform.position = lineRenderer.transform.position;
            boxCollider.size = new Vector3(0.2f, 0.2f, 10f);
        }

        // Left Mouse Button is up or line length exceeded
        if (Input.GetMouseButtonUp(0) || lineRenderer.numPositions > 20)
        {
            lineRenderer.numPositions = 0;

            i = 0;

            BoxCollider[] boxColliders = lineObject.GetComponents<BoxCollider>();

            foreach (BoxCollider boxCollider in boxColliders)
            {
                Destroy(boxCollider);
            }
        }
    }
}
