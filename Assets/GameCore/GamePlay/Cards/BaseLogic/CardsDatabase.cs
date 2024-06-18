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

    public CardData PlayerCard;
    public CardData SkeletCard;
    public CardData ZombieCard;
    public CardData CoinCard;
    public CardData PotionnCard;
    public CardData SwordCard;
}
