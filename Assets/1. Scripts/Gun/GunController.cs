using com.goldsprite.GSTools.EssentialAttributes;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GunController : MonoBehaviour
{
    [SerializeField][ReadOnly] private GameObject hittenObject;
    [SerializeField] private UnityEvent<GameObject> onHit;
    [SerializeField] private string enemyTag;

    [SerializeField] private int ammoAmount = 20;
    [SerializeField, ReadOnly] int currentAmmoAmount;
    public int CurrentAmmoAmount
    {
        get { return currentAmmoAmount; }
        private set { currentAmmoAmount = value; onAmmoAmountChanged?.Invoke(); }
    }
    [SerializeField] private UnityEvent onReloadStart;
    [SerializeField] private UnityEvent onReloadPeformed;
    [SerializeField] private UnityEvent onAmmoAmountChanged;
    [SerializeField] private float reloadTimeInSeconds;
    [SerializeField, ReadOnly] private bool isReloading;

    public int GetCurrentAmmoAmount()
    {
        return CurrentAmmoAmount;
    }

    public int GetMaxAmmoAmount()
    {
        return ammoAmount;
    }

    public float GetReloadTime()
    {
        return reloadTimeInSeconds;
    }

    private void Awake()
    {
        CurrentAmmoAmount = ammoAmount;
    }

    public void Shoot()
    {
        if (!isReloading)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), Mathf.Infinity, 1 << 3);
            CurrentAmmoAmount--;
            if (CurrentAmmoAmount <= 0)
            {
                Reload();
            }
            var hitCollider = hit.collider;
            if (hitCollider != null)
            {
                hittenObject = hitCollider.gameObject;
                onHit.Invoke(hittenObject);
            }
            else
            {
                hittenObject = null;
            }
        }

    }

    public void Reload()
    {
        if (!isReloading)
        {
            StartCoroutine(ReloadCoroutine());
        }
    }

    private IEnumerator ReloadCoroutine()
    {
        onReloadStart?.Invoke();
        isReloading = true;
        yield return new WaitForSeconds(reloadTimeInSeconds);
        CurrentAmmoAmount = ammoAmount;
        isReloading = false;
        onReloadPeformed?.Invoke();
    }
}
