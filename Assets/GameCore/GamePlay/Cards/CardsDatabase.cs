using UnityEngine;

[CreateAssetMenu(fileName = "CardsDatabase", menuName = "CardsDatabase")]
public class CardsDatabase : ScriptableObject
{
    private static CardsDatabase _instance;
    public static CardsDatabase Instance => _instance;

    public void Init()
    {
        _instance = this;
    }

    public GameObject MobCard;
    public GameObject CoinCard;
}
