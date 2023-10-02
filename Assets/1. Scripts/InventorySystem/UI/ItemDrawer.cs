using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ItemDrawer : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemCount;

    [SerializeField] private Button removeButton;
    public Button outsideClickButton;
    private Button button;
    private Item currentItem;
    private int count;

    private void Start()
    {
        button = GetComponent<Button>();
        removeButton.onClick.AddListener(RemoveItemFromInventory);
        outsideClickButton.onClick.AddListener(HideDeleteButton);
        button.onClick.AddListener(ShowDeleteButton);
    }

    private void RemoveItemFromInventory()
    {
        Inventory.Instance.RemoveItem(currentItem, count);
        HideDeleteButton();
    }

    private void ShowDeleteButton()
    {
        removeButton.gameObject.SetActive(true);
        outsideClickButton.gameObject.SetActive(true);
    }
    
    private void HideDeleteButton()
    {
        removeButton.gameObject.SetActive(false);
    }

    public void SetItem(Item item, int count)
    {
        currentItem = item;
        this.count = count;
        UpdateUI();
    }

    private void UpdateUI()
    {
        image.sprite = currentItem.sprite;
        itemName.text = currentItem.name;
        if (count > 1)
            itemCount.text = count.ToString();
        else
            itemCount.text = string.Empty;
    }
}
