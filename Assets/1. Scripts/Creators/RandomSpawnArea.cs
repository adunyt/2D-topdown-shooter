using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnArea : MonoBehaviour
{
    [SerializeField] private float height = 1;
    [SerializeField] private float width = 1;
    [SerializeField] private List<GameObject> objectsToSpawn = new List<GameObject>();

    private IEnumerator Start()
    {
        float widthMin = width / 2 * -1;
        float widthMax = width / 2;

        float heigthMin = height / 2 * -1;
        float heigthMax = height / 2;

        int i = 0;
        foreach (var gObject in objectsToSpawn)
        {
            Vector3 randomPosition = new Vector3(Random.Range(widthMin, widthMax), Random.Range(heigthMin, heigthMax));
            var spawnedGObject = Instantiate(gObject, transform.position + randomPosition, Quaternion.identity);
            spawnedGObject.name += i;
            i++;
            yield return null;
        }
    }

    void OnDrawGizmosSelected()
    {
        height = Mathf.Max(0, height);
        width = Mathf.Max(0, width);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }
}
