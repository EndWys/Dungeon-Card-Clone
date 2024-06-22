using System;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.BaseLogic
{
    [Serializable]
    public class CardData
    {
        public string CardName;
        public int CardValueNumber;
        public GameObject CardPrefab;
    }
}