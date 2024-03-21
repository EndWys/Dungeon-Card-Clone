namespace Assets.GameCore.GamePlay.InteractionStratagy
{
    public abstract class BaseCardStratage<T> where T : OnCardObjectBase
    {
        private T _executor;
        protected T Executor => _executor;

        public BaseCardStratage(T executor)
        {
            _executor = executor;
        }

        public abstract void DoAction(OneGameCard playerCard);
    }
}