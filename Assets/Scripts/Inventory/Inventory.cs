using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject _inventory, _button;
    public SpriteRenderer Point;
    [SerializeField] private List<Item> _items;
    public EquipmentSlots[] equipmentSlots;
    bool isEnable = false;
    public int freeSlots;
    public Slot[] slots;
    public List<Slot> occupiedSlots = new List<Slot>();

    public void OpenInventory()
    {
        _inventory.SetActive(!isEnable);
        isEnable = !isEnable;
    }

    public void Add()
    {
        if (_items.Count > 0)
            _items[0].AddItemInInventary();
    }

    private void Start()
    {
        freeSlots = slots.Length;
        _inventory.SetActive(isEnable);
        _button.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TryGetComponent(out Item item);
        if (item != null)
        {
            _button.SetActive(true);
            _items.Add(item);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.TryGetComponent(out Item item);
        if (item != null)
        {
            _button.SetActive(false);
            _items.Remove(item);
        }
    }

    public bool AddItem(Item item)
    {
        if (occupiedSlots.Count > 0)
        {
            foreach (Slot slot in occupiedSlots)
            {
                if (item.Name == slot.Name)
                {
                    slot._numberOfItems++;
                    slot.WriteCount();
                    return true;
                }
            }
        }

        if (freeSlots > 0)
        {
            foreach (Slot slot in slots)
            {
                if (slot.isFree == true)
                {
                    item.SpawnImage(slot);
                    slot.isFree = false;
                    slot.isFreeForOne = true;
                    slot.Name = item.Name;
                    slot._numberOfItems++;
                    slot.WriteCount();
                    occupiedSlots.Add(slot);
                    freeSlots -= 1;
                    return true;
                }
            }
            return false;
        }
        return false;
    }
}