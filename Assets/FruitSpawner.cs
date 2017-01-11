using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject appleObject;

    private Vector3 throwForce = new Vector3(0, 18, 0);

    /// <summary>
    /// Start this fruit spawner.
    /// </summary>
    void Start()
    {
        InvokeRepeating("SpawnFruit", 0.5f, 6);
    }

    void SpawnFruit()
    {
        for (byte i = 0; i < 4; i++)
        {
            GameObject fruit = Instantiate(
                                   appleObject,
                                   new Vector3(Random.Range(10, 30), Random.Range(-25, -35), -32),
                                   Quaternion.identity) as GameObject;
        
            fruit.GetComponent<Rigidbody>().AddForce(throwForce, ForceMode.Impulse);
        }
    }
}
