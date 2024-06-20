using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.GameCore.GamePlay.MainHeroOptions.Weapons
{
    public class Sword : IWeapon
    {
        private int _power;
        private IHeroActionStratagy _stratagy;

        public int Power => _power;

        public IHeroActionStratagy Stratagy => _stratagy;

        public Action OnBroke { get; set; } = delegate { };
        public Action<int> OnDurabilityChange { get; set; } = delegate { };

        public Sword(int power, IHeroActionStratagy stratagy)
        {
            _power = power;
            _stratagy = stratagy;
        }

        public void UseDurability(int durability)
        {
            if (_power > durability) 
            {
                _power -= durability;
            }
            else
                _power = 0;

            OnDurabilityChange.Invoke(_power);
        }

        public void Breake()
        {
            _power = 0;
            OnBroke.Invoke();
            OnBroke = delegate { };
        }
    }
}