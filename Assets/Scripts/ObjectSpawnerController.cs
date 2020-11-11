using UnityEngine;

public class ObjectSpawnerController : MonoBehaviour
{
    [SerializeField]
    private GameObject objectPrefabs;
    [SerializeField]
    private float delayTime;
    private float timer;
    private int count;
    private void Awake() => count = 0;
    private void Update() => CreateObject();
    private void CreateObject()
    {
        timer += Time.deltaTime;
        if (timer > delayTime)
        {
            Vector3 position = new Vector3(Random.Range(-28, 23), -8.5f, Random.Range(-2, 18));
            GameObject newObject = Instantiate(objectPrefabs, position, Quaternion.identity);
            count++;
            newObject.name = "" + count.ToString();
            timer = 0;
        }
    }
}
