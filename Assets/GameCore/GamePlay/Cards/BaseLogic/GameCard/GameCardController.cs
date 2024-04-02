using Assets.GameCore.GamePlay.MainHeroOptions;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard
{
    public interface IOnFieldCard
    {
        UniTask MoveView(Vector3 target);
        UniTask HideView();
        void SetParent(Transform parent);

        void Kill();
    }

    public abstract class GameCardController : IOnFieldCard
    {
        private IParentCardField _parentCardField;
        private GameCardView _gameCardView;

        private Vector2Int _coord;
        public Vector2Int Coord => _coord;

        public GameCardController(IParentCardField parentCardField, GameCardView gameCardView)
        {
            _parentCardField = parentCardField;
            _gameCardView = gameCardView;
        }

        public void Init()
        {
            _gameCardView.OnCardTap += CardTap;
        }

        public void CardTap()
        {
            MainHeroHolder.Instance.OnCardTap(this);
        }

        public void Move(Vector2Int target)
        {
            _parentCardField.MoveCard(target, _coord);
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