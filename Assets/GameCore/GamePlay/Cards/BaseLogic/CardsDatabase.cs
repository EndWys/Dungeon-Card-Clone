using UnityEngine;

[CreateAssetMenu(fileName = "CardsDatabase", menuName = "CardsDatabase")]
public class CardsDatabase : ScriptableObject
{
    private static CardsDatabase _instance;
    public static CardsDatabase Instance => _instance;

    public static void SetInstance(CardsDatabase cardData)
    {
        _instance = cardData;
    }

    public GameObject MobCard;
    public GameObject CoinCard;
}
