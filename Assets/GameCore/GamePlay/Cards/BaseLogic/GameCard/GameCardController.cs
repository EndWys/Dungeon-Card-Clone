using Assets.GameCore.GamePlay.MainHeroOptions;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard
{
    public interface IOnFieldCard
    {
        UniTask Move(Vector2Int target);
        UniTask MoveView(Vector3 target);
        UniTask HideView();
        void SetCoord(Vector2Int coord);
        void SetParent(Transform parent);

        void Kill();
    }

    public abstract class GameCardController : IOnFieldCard
    {
        private CardData _cardData;

        private Vector2Int _coord;
        public Vector2Int Coord => _coord;

        protected IParentCardField _parentCardField;
        protected GameCardView _gameCardView;


        public GameCardController(CardData cardData, IParentCardField parentCardField, GameCardView gameCardView)
        {
            _cardData = cardData;
            _parentCardField = parentCardField;
            _gameCardView = gameCardView;
        }

        public void SetCoord(Vector2Int coord)
        {
            _coord = coord;
        }

        public void Init()
        {
            _gameCardView.OnCardTap += CardTap;
        }

        public void CardTap()
        {
            _parentCardField.ExecutePlayerStep(this);
        }

        public async UniTask Move(Vector2Int target)
        {
            await _parentCardField.MoveCard(target, _coord);
        }

        public void Kill()
        {
            _gameCardView.Kill();
        }

        public void SetParent(Transform parent)
        {
            _gameCardView.SetParent(parent);
        }

        public async UniTask MoveView(Vector3 pos)
        {
            await _gameCardView.MoveView(pos);
        }

        public async UniTask HideView()
        {
            await _gameCardView.HideView();
        }
    }
}