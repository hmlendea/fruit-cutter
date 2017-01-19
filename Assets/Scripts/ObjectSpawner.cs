using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject appleObject;

    [SerializeField]
    private GameObject burgerObject;

    private Vector3 appleThrowForce = new Vector3(0, 18, 0);
    private Vector3 burgerThrowForce = new Vector3(0, 28, 0);

    /// <summary>
    /// Start this fruit spawner.
    /// </summary>
    void Start()
    {
        InvokeRepeating("SpawnObjects", 0.5f, 6);
    }

    /// <summary>
    /// Spawns the objects.
    /// </summary>
    void SpawnObjects()
    {
        // Spawn between 3 and 6 apples
        for (int i = 0; i < Random.Range(3, 6); i++)
        {
            SpawnApple();
        }

        // 33.3% chance to spawn a burger
        if (1 == Random.Range(1, 3))
        {
            SpawnBurger();
        }
    }

    /// <summary>
    /// Spawns an apple.
    /// </summary>
    void SpawnApple()
    {
        GameObject fruit = Instantiate(
                               appleObject,
                               new Vector3(Random.Range(10, 30), Random.Range(-25, -35), -32),
                               Quaternion.identity) as GameObject;

        fruit.GetComponent<Rigidbody>().AddForce(appleThrowForce, ForceMode.Impulse);
    }

    /// <summary>
    /// Spawns a burger.
    /// </summary>
    void SpawnBurger()
    {
        GameObject burger = Instantiate(
                                burgerObject,
                                new Vector3(Random.Range(0, 10), Random.Range(-25, -35), 0),
                                Quaternion.identity) as GameObject;

        burger.GetComponent<Rigidbody>().AddForce(burgerThrowForce, ForceMode.Impulse);
    }
}
