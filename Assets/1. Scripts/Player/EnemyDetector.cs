using com.goldsprite.GSTools.EssentialAttributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDetector : MonoBehaviour
{
    [Tooltip("Вызывает данное событие, когда замечается объект, либо меняется близжайший обьект, когда их несколько в поле зрения")]
    [SerializeField] private UnityEvent<GameObject> onDetect;
    [SerializeField] private UnityEvent onLost;
    [SerializeField] private string enemyTag;

    [Header("Info")]
    [SerializeField][ReadOnly] private GameObject closestEnemy;
    [SerializeField][ReadOnly] private float closestDistance;
    [SerializeField][ReadOnly] private List<GameObject> detectedEnemies = new List<GameObject>();

    private Vector3 playerPosition;
    private GameObject previousEnemy;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemyTag))
            detectedEnemies.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(enemyTag))
            detectedEnemies.Remove(collision.gameObject);
    }

    private void FixedUpdate()
    {
        if (detectedEnemies.Count < 1)
        {
            onLost.Invoke();
            closestEnemy = null;
            closestDistance = 0;
            return;
        }

        playerPosition = transform.position;

        previousEnemy = closestEnemy;

        closestEnemy = detectedEnemies[0];
        closestDistance = Vector3.Distance(playerPosition, detectedEnemies[0].transform.position); 

        if (detectedEnemies.Count > 1)
        {
            foreach (var enemy in detectedEnemies)
            {
                var enemyPosition = enemy.transform.position;
                var distance = Vector3.Distance(playerPosition, enemyPosition);
                if (closestDistance > distance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }
        }

        if (previousEnemy != closestEnemy)
        {
            onDetect.Invoke(closestEnemy);
        }

    }
}
