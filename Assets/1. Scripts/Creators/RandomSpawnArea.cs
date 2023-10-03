using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomSpawnArea : MonoBehaviour
{
    [SerializeField] private float height = 1;
    [SerializeField] private float width = 1;
    [SerializeField] private List<GameObject> objectsToSpawn = new List<GameObject>();

    [SerializeField] private UnityEvent onAllEnemiesDead;

    private int enemiesRemaining;

    private void Start()
    {
        enemiesRemaining = objectsToSpawn.Count;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        float widthMin = width / 2 * -1;
        float widthMax = width / 2;

        float heightMin = height / 2 * -1;
        float heightMax = height / 2;

        int i = 0;
        foreach (var gObject in objectsToSpawn)
        {
            Vector3 randomPosition = new Vector3(Random.Range(widthMin, widthMax), Random.Range(heightMin, heightMax));
            var spawnedGObject = Instantiate(gObject, transform.position + randomPosition, Quaternion.identity);
            spawnedGObject.name += i;
            i++;

            // Attach the EnemyDeathEvent component and subscribe to the death event
            if (spawnedGObject.TryGetComponent<EnemyDeathEvent>(out var enemyDeathEvent))
            {
                enemyDeathEvent.OnEnemyDeath.AddListener(OnEnemyDeath);
            }

            yield return null;
        }
    }

    private void OnEnemyDeath()
    {
        enemiesRemaining--;

        if (enemiesRemaining <= 0)
        {
            onAllEnemiesDead?.Invoke();
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
