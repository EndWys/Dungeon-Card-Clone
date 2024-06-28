using Assets.GameCore.GameCoreSystems.Currencies;
using VContainer;
public class CoinsMatchManager : BaseCurrencyManager<CoinsMatchManager>
{
    protected override string CurrencyName => "Match";

    [Inject]
    public CoinsMatchManager()
    {

    }
}
