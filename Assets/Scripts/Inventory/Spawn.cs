using UnityEngine;

public class Spawn : Item
{
    private GameObject _player;
    private Transform _playerTransform;
    [SerializeField] private GameObject _item, _itemOnYou;
    [SerializeField] private Sprite _sprite;
    private Vector2 _posOfSpawn;
    private Slot parent;
    private Inventory _inventory;
    public int MaxCount;

    private void Start()
    {
        parent = transform.parent.GetComponent<Slot>();
        _inventory = StaticsVariables.Inventory;
    }

    public void DeleteItem()
    {
        _player = StaticsVariables.Player;
        _playerTransform = _player.transform;
        _posOfSpawn = new Vector2(_playerTransform.position.x + 2f, _playerTransform.position.y + 2f);
        Instantiate(_item, _posOfSpawn, Quaternion.identity);
        parent._numberOfItems--;
        parent.WriteCount();

        if (parent._numberOfItems <= 0)
        {
            parent.isFree = true;
            parent.Name = "";
            _inventory.freeSlots++;
            parent.isFreeForOne = false;
            _inventory.occupiedSlots.Remove(parent);
            Destroy(gameObject);
        }
    }

    public void SpawnItem()
    {
        SpriteRenderer point = _inventory.Point;
        point.sprite = _sprite;
        int indexOfSlot = 0;

        if (point.transform.childCount > 0)
        {
            Destroy(point.transform.GetChild(0).gameObject);
            Instantiate(_itemOnYou, point.transform);
        }
        else
            Instantiate(_itemOnYou, point.transform);

        if (parent._numberOfItems == 1)
        {
            parent.isFree = true;
            _inventory.freeSlots += 1;
            _inventory.equipmentSlots[indexOfSlot].Equip(gameObject.GetComponent<Spawn>(), true);
        }
        else
            _inventory.equipmentSlots[indexOfSlot].Equip(gameObject.GetComponent<Spawn>(), false);

        parent._numberOfItems--;
        parent.WriteCount();
    }
}
