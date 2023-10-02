using com.goldsprite.GSTools.EssentialAttributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDetector : MonoBehaviour
{
    [Tooltip("Event triggered when an object is detected or the closest object changes when multiple are in the field of view.")]
    [SerializeField] private UnityEvent<GameObject> onDetect;
    [SerializeField] private UnityEvent onLost;
    [SerializeField] private string enemyTag;

    [Header("Info")]
    [SerializeField][ReadOnly] private GameObject closestEnemy;
    [SerializeField][ReadOnly] private float closestDistance;
    [SerializeField][ReadOnly] private List<GameObject> detectedEnemies = new List<GameObject>();

    private Vector3 playerPosition;
    private GameObject previousEnemy;
    private bool isLost = true;

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
            if (isLost == false)
            {
                ClearClosestEnemy();
                onLost.Invoke();
            }
            return;
        }

        isLost = false;

        playerPosition = transform.position;

        previousEnemy = closestEnemy;

        FindClosestEnemy();

        if (previousEnemy != closestEnemy)
        {
            onDetect.Invoke(closestEnemy);
        }
    }

    private void ClearClosestEnemy()
    {
        closestEnemy = null;
        closestDistance = 0;
        isLost = true;
    }

    private void FindClosestEnemy()
    {
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
    }
}
