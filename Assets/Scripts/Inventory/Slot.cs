using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    protected Inventory _inventory;
    public bool isFree = true, isFreeForOne = false;
    public int _numberOfItems = 0;
    public string Name;
    [SerializeField] private Text text;

    private void Start() => _inventory = StaticsVariables.Inventory;

    public virtual void RemoveItem()
    {
        if (transform.childCount >= 3)
        {
            Spawn child = transform.GetChild(2).GetComponent<Spawn>();
            child.DeleteItem();
            WriteCount();
        }
    }

    public void WriteCount()
    {
        if (transform.childCount >= 3)
        {
            Spawn child = transform.GetChild(2).GetComponent<Spawn>();
            if (_numberOfItems + 1 == child.MaxCount || _numberOfItems <= 0)
                _inventory.occupiedSlots.Remove(gameObject.GetComponent<Slot>());
        }
        text.text = $"{_numberOfItems}";
    }
}
