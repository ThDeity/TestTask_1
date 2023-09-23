using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private Inventory _inventoryOfItem;
    [SerializeField] private Image _image;
    public string Name;

    private void Start() => _inventoryOfItem = StaticsVariables.Inventory;

    public void SpawnImage(Slot slot) => Instantiate(_image, slot.transform);

    public void AddItemInInventary()
    {
        _inventoryOfItem.AddItem(gameObject.GetComponent<Item>());
        Destroy(gameObject);
    }
}
