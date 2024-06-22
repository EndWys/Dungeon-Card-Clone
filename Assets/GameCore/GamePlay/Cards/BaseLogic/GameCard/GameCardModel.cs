namespace Assets.GameCore.GamePlay.Cards.BaseLogic
{
    public abstract class GameCardModel
    {
        public abstract void Init();//when card is creating

        public abstract void ResponceOnAction();//when player click on card

        public abstract void Remove();//when card is removing from field
    }
}