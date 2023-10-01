using com.goldsprite.GSTools.EssentialAttributes;
using UnityEngine;
using UnityEngine.Events;

public class Entity : MonoBehaviour
{
    [SerializeField] private int HP;
    [SerializeField] private Weapon weapon;
    [SerializeField] private UnityEvent onDeath;
    [SerializeField] private UnityEvent onHit;
    [Header("Info")]
    [SerializeField][ReadOnly] private int currentHP;

    public bool IsAlive { get; private set; } = true;

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
        if (currentHP - damage > 0)
        {
            currentHP -= damage;
            onHit.Invoke();
        }
        else if (IsAlive)
        {
            currentHP = 0;
            IsAlive = false;
            onDeath.Invoke();
        }
    }

    public void Attack(Entity entity)
    {
        entity.Hit(weapon.Damage);
    }

    private void Start()
    {
        currentHP = HP;
    }
}