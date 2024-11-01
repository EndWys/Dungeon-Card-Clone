using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.BaseLogic.Interfaces;
using Assets.GameCore.GamePlay.Cards.PlayerCard;
using Assets.GameCore.GamePlay.MainHeroOptions.PlayerStratagys;
using Assets.GameCore.GamePlay.MainHeroOptions.Weapons;
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

        private bool _isInitialized = false;
        public bool IsInitialized => _isInitialized;

        public void Init(PlayerCardController playerCard)
        {
            _playerCard = playerCard;
            _heroActionStratagy = new DefaultHeroActionStratagy();

            _isInitialized = true;
        }

        public bool IsHeroDead() => _playerCard.Health == 0;

        public async UniTask ExecuteHeroAction(GameCardController card)
        {
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
        }

        public void EquipWeapon(IWeapon weapon)
        {
            _playerCard.Wiel(weapon);
            _heroActionStratagy = weapon.Stratagy;

            weapon.OnDurabilityChange += (int dur) => {
                if (dur == 0)
                {
                    _heroActionStratagy = new DefaultHeroActionStratagy();
                    _playerCard.Unwiel();
                }
                else
                    _playerCard.ChangeWeaponDurability(dur);
            };
            
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