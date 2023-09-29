using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

[RequireComponent(typeof(Entity))]
public class PeriodicAttack : MonoBehaviour
{
    [SerializeField] private float coolDownInSeconds = 2f;
    private Entity attacker;

    private void Awake()
    {
        attacker = GetComponent<Entity>();
    }

    public void StartAttack(Entity entity)
    {
        StartCoroutine(Attack(entity));
    }

    public void StartAttack(GameObject gameObject)
    {  
        StartCoroutine(Attack(gameObject.GetComponent<Entity>()));
    }

    public void StopAttack()
    {
        StopAllCoroutines();
    }

    private IEnumerator Attack(Entity entity)
    {
        while (true)
        {
            attacker.Attack(entity);
            yield return new WaitForSeconds(coolDownInSeconds);
        }

    }

}
