using Assets.GameCore.GamePlay.CardObjects.BaseLogic.MobsBaseLogic;
using Assets.GameCore.GamePlay.CardObjects.ObjetsModification;
using Assets.GameCore.GamePlay.Cards;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.GameCore.GamePlay
{
    public interface ICardClickReceiver
    {
        void OnCardClick(Vector2Int coord);
    }

    public class GameField : MonoBehaviour, ICardClickReceiver
    {
        private const int FIELD_SIZE = 3;

        [SerializeField] private OneGameCard[] oneGameCards = new OneGameCard[FIELD_SIZE * FIELD_SIZE];
        [SerializeField] private PlayerGameCard _playerCard;

        private Dictionary<Vector2Int, OneGameCard> _gameCards = new Dictionary<Vector2Int, OneGameCard>();

        private void Awake()
        {
            InitializeField();
        }

        private void InitializeField()
        {
            int i = 0;
            for (int y = 0; y < FIELD_SIZE; y++)
            {
                for (int x = 0; x < FIELD_SIZE; x++)
                {
                    OneGameCard card = oneGameCards[i];

                    Vector2Int coord = new Vector2Int(x, y);

                    card.Init(coord, this);

                    _gameCards.Add(coord, card);

                    //temporary, need to use factory for different cards
                    if (y == 0 && x == 0)
                    {
                        card.SetOnCardObject(new PlayerObject());
                    } 
                    else if (y == 1) 
                    {
                        card.SetOnCardObject(new CoinObject());
                    } 
                    else
                    {
                        card.SetOnCardObject(new MobObjectBase());
                    }

                    i++;
                }
            }
        }

        public void OnCardClick(Vector2Int coord)
        {
            OneGameCard targetGameCard = _gameCards[coord];
            targetGameCard.OnTap(_playerCard);
            //wait for result
        }
    }
}