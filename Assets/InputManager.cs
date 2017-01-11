using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Color Colour1 { get; set; }

    public Color Colour2 { get; set; }

    private GameObject lineObject;
    private LineRenderer lineRenderer;

    private Material lineRendererMaterial = new Material(Shader.Find("Mobile/Particles/Additive"));
    private int i = 0;

    public InputManager()
    {
        Colour1 = Color.yellow;
        Colour2 = Color.red;
    }

    /// <summary>
    /// Start this line renderer.
    /// </summary>
    void Start()
    {
        lineObject = new GameObject("Line");
        lineObject.AddComponent<LineRenderer>();

        lineRenderer = lineObject.GetComponent<LineRenderer>();
        lineRenderer.material = lineRendererMaterial;

        lineRenderer.startColor = Colour1;
        lineRenderer.startWidth = 0.3f;

        lineRenderer.endColor = Colour2;
        lineRenderer.endWidth = 0;

        lineRenderer.numPositions = 0;
    }

    /// <summary>
    /// Update this line renderer.
    /// </summary>
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                lineRenderer.numPositions = i + 1;

                Vector3 mPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15);
                lineRenderer.SetPosition(i, Camera.main.ScreenToWorldPoint(mPosition));

                i += 1;

                BoxCollider boxCollider = lineObject.AddComponent<BoxCollider>();
                boxCollider.transform.position = lineRenderer.transform.position;
                boxCollider.size = new Vector3(0.1f, 0.1f, 0.1f);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                lineRenderer.numPositions = 0;

                BoxCollider[] boxColliders = lineObject.GetComponents<BoxCollider>();

                foreach (BoxCollider boxCollider in boxColliders)
                {
                    Destroy(boxCollider);
                }
            }
        }
    }
}
