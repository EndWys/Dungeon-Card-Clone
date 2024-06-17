using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.PlayerCard;
using Assets.GameCore.GamePlay.MainHeroOptions.PlayerStratagys;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace Assets.GameCore.GamePlay.MainHeroOptions
{
    public class MainHeroHolder : IDisposable
    {
        private static MainHeroHolder _instance;

        public static MainHeroHolder Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainHeroHolder();

                return _instance;
            }
        }

        private PlayerCardController _playerCard;

        private IHeroActionStratagy _heroActionStratagy;

        private bool _isStepDone = false;

        private bool _isInitialized = false;

        public void Init(PlayerCardController playerCard)
        {
            _playerCard = playerCard;
            _heroActionStratagy = new DefaultHeroActionStratagy();

            _isInitialized = true;
            _isStepDone = true;
        }

        public async UniTask OnCardTap(GameCardController card)
        {
            Debug.Log("Tap - choose initialization");
            if (!_isInitialized) return;

            if (!_isStepDone) return;

            _isStepDone = false;

            Debug.Log("Using stratagy");
            await _heroActionStratagy.UseStratagy(_playerCard, card);

            //Validate action

            //then choose correct strategy
            //then get card response strategy
            //then apply player strategy
            //then apply card response strategy

            //����� ����� ��������� ����� �������� ���������� � ����� ������� � ��� ���� ������ � ������
            //������: ���� � ������ ���� � � ����� IWeaponTarget ����������, �� ���������� ����� IWeaponTarget.TakeHit()
            //����� ��� ����� ��������� �� isDead ��� ����� � ������� �� � ���� � ��������� ������� �� �� �����.
            //Eckb �� ������ ��� �� �������� ����� IMob.TakeHit() � �.�.

            await _playerCard.StepDone();

            _isStepDone = true;
        }

        public void EquipStratagy(IHeroActionStratagy heroStratagy)
        {
            _heroActionStratagy = heroStratagy;
        }

        public void ConsumeItem(Action<PlayerCardController> action)
        {
            action.Invoke(_playerCard);
        }

        public void Dispose()
        {
            _instance = null;
        }
    }
}