using UnityEngine;

public class EquipmentSlots : Slot
{
    public bool isEquip = false;

    public void Equip(Spawn item, bool isDestroyable)
    {
        if (isEquip == false)
        {
            Instantiate(item.gameObject, transform);
            item.enabled = false;
        }
        else
        {
            RemoveItem();
            Instantiate(item.gameObject, transform);
        }

        isEquip = true;
        if (isDestroyable)
            Destroy(item.gameObject);
    }

    public override void RemoveItem()
    {
        if (transform.childCount >= 2)
        {
            Transform child1 = transform.GetChild(1);
            child1.GetComponent<Spawn>().enabled = true;
            Spawn child = child1.GetComponent<Spawn>();
            if (_inventory.AddItem(child) == false)
                child.DeleteItem();
            else
                Destroy(child1.gameObject);
            isEquip = false;
            Destroy(_inventory.Point.transform.GetChild(0));
        }
    }
}
