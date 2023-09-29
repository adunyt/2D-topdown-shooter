using com.goldsprite.GSTools.EssentialAttributes;
using UnityEngine;
using UnityEngine.Events;

public class Entity : MonoBehaviour
{
    [SerializeField] private int HP;
    [SerializeField] private int Damage;
    [SerializeField] private UnityEvent onDeath;
    [SerializeField] private UnityEvent onHit;
    [Header("Info")]
    [SerializeField][ReadOnly] private int currentHP;

    public int GetMaxHP()
    {
        return HP;
    }

    public int GetCurrentHP()
    {
        return currentHP;
    }

    public void Hit(int damage)
    {
        HP -= damage;
        if (HP > 0)
        {
            onHit.Invoke();
        }
        else
        {
            onDeath.Invoke();
        }
    }

    public void Attack(Entity entity)
    {
        entity.Hit(Damage);
    }

    private void Start()
    {
        currentHP = HP;
    }
}