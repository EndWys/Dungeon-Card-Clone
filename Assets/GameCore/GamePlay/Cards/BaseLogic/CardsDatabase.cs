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

    public GameObject PlayerCard;
    public GameObject SkeletCard;
    public GameObject ZombieCard;
    public GameObject CoinCard;
    public GameObject PotionnCard;
}
