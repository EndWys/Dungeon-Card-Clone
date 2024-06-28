using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace Assets.GameCore.GamePlay.GameField
{
    public interface IGameStarter
    {
        public bool IsGameActive();
        public void StartingNewGame();
    }
    public interface IGameFinisher
    {
        public event Action OnGameFinish;
    }

    public interface IFieldsManagerFolder
    {
        GameFieldManagerHolder Managers { get; }
    }

    public interface IParentCardField : IFieldsManagerFolder
    {
        UniTask ExecutePlayerStep(GameCardController target);
        UniTask MoveCard(Vector2Int target, Vector2Int origin);
    }
}