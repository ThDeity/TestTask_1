using UnityEngine;

public class StaticsVariables : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    public static Inventory Inventory;
    public static GameObject Player;
    public Inventory inventory;

    private void Awake()
    {
        Player = _player;
        Inventory = Player.GetComponent<Inventory>();
        inventory = Inventory;
    }
}
