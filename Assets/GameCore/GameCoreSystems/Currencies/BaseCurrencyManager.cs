using DG.Tweening.Core.Easing;
using System;
using UnityEngine;

namespace Assets.GameCore.GameCoreSystems.Currencies
{
    public abstract class BaseCurrencyManager<T> : BaseManager<T>, ICurrencyManager where T : BaseCurrencyManager<T>, new()
    {
        protected abstract string CurrencyName { get; }

        public int CurrencyValue { get; private set; }
        public int Currency => CurrencyValue;

        public event Action<int> CurrencyChanged = (int v) => { };

        public void AddCurrency(int value)
        {
            if (value <= 0)
                return;

            CurrencyValue += value;

            Debug.Log($"CurrentBalance, {CurrencyName}: {CurrencyValue}");
            CurrencyChanged.Invoke(CurrencyValue);
        }

        public void SubstractCurrency(int value)
        {
            if (value <= 0)
                return;

            CurrencyValue -= value;
            CurrencyChanged.Invoke(CurrencyValue);
        }

        public void ResetCurrency()
        {
            SubstractCurrency(CurrencyValue);
        }
    }
}