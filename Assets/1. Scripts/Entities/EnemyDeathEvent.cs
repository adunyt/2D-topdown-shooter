using UnityEngine;
using UnityEngine.Events;

public class EnemyDeathEvent : MonoBehaviour
{
    public UnityEvent OnEnemyDeath = new UnityEvent();

    public void EnemyDied()
    {
        OnEnemyDeath.Invoke();
    }
}
