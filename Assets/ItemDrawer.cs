using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDrawer : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemCount;

    [SerializeField] private Button removeButton;

    public void SetItem(Item item, int count)
    {
        image.sprite = item.sprite;
        itemName.text = item.name;
        if (count > 1)
            itemCount.text = count.ToString();
    }
    public void RemoveItem()
    {
        image.sprite = null;
        itemName.text = string.Empty;
        itemCount.text = string.Empty;
    }
}
