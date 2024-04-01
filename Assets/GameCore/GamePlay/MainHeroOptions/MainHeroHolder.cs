using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.PlayerCard;
using Assets.GameCore.GamePlay.MainHeroOptions.PlayerStratagys;
using System;

namespace Assets.GameCore.GamePlay.MainHeroOptions
{
    public class MainHeroHolder : IDisposable
    {
        private static MainHeroHolder _instance;

        public static MainHeroHolder Instance => _instance;

        private PlayerGameCardController _playerCard;

        private IHeroActionStratagy _heroActionStratagy;

        private bool isInitialized = false;

        public void Init(PlayerGameCardController playerCard)
        {
            _playerCard = playerCard;
            _instance = this;

            isInitialized = true;

            _heroActionStratagy = new DefaultHeroActionStratagy();
        }

        public void OnCardTap(GameCardController card)
        {
            if (!isInitialized) return;

            _heroActionStratagy.UseStratagy(_playerCard, card);

            //Validate action

            //then choose correct strategy
            //then get card response strategy
            //then apply player strategy
            //then apply card response strategy

            //����� ����� ��������� ����� �������� ���������� � ����� ������� � ��� ���� ������ � ������
            //������: ���� � ������ ���� � � ����� IWeaponTarget ����������, �� ���������� ����� IWeaponTarget.TakeHit()
            //����� ��� ����� ��������� �� isDead ��� ����� � ������� �� � ���� � ��������� ������� �� �� �����.
            //Eckb �� ������ ��� �� �������� ����� IMob.TakeHit() � �.�.
        }

        public void EquipStratagy(IHeroActionStratagy heroStratagy)
        {
            _heroActionStratagy = heroStratagy;
        }

        public void Dispose()
        {
            _instance = null;
        }
    }
}