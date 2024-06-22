using UnityEngine;

namespace Assets.GameCore.GamePlay.MainHeroOptions.Equipe
{
    [CreateAssetMenu(fileName = "EquipeDatabase", menuName = "EquipeDatabase")]
    public class EquipeDatabase : ScriptableObject
    {
        private static EquipeDatabase _instance;
        public static EquipeDatabase Instance => _instance;

        public static void SetInstance(EquipeDatabase cardData)
        {
            _instance = cardData;
        }

        public EquipeData Sword;
    }
}