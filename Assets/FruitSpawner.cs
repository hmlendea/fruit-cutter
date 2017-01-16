using UnityEngine;

public class FruitSpawner : MonoBehaviour
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
        InvokeRepeating("SpawnObject", 0.5f, 6);
    }

    void SpawnObject()
    {
        for (byte i = 0; i < 4; i++)
        {
            GameObject fruit = Instantiate(
                                   appleObject,
                                   new Vector3(Random.Range(10, 30), Random.Range(-25, -35), -32),
                                   Quaternion.identity) as GameObject;

            fruit.GetComponent<Rigidbody>().AddForce(appleThrowForce, ForceMode.Impulse);
        }

        GameObject burger = Instantiate(
                                burgerObject,
                                new Vector3(Random.Range(0, 10), Random.Range(-25, -35), 5),
                                Quaternion.identity) as GameObject;

        burger.GetComponent<Rigidbody>().AddForce(burgerThrowForce, ForceMode.Impulse);
    }
}
