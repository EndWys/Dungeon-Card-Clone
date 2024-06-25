namespace Assets.GameCore.GameCoreSystems.Currencies
{
    public interface ICurrencyManager
    {
        int Currency { get; }

        void AddCurrency(int value);

        public void SubstractCurrency(int value);
    }
}