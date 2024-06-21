using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.MainHeroOptions.Equipe;
using Cysharp.Threading.Tasks;
using System;
using System.Threading.Tasks;
using UnityEngine;

public static class ResourcesLoading
{
    static async UniTask LoadCardlStorage()
    {
        var asset = await Resources.LoadAsync<CardsDatabase>("CardsDatabase");
        CardsDatabase content = asset as CardsDatabase;
        CardsDatabase.SetInstance(content);

        if (content == null)
        {
            throw new Exception("Can't load CardsDatabase");
        }
    }

    static async UniTask LoadEquipeStorage()
    {
        var asset = await Resources.LoadAsync<EquipeDatabase>("EquipeDatabase");
        EquipeDatabase content = asset as EquipeDatabase;
        EquipeDatabase.SetInstance(content);

        if (content == null)
        {
            throw new Exception("Can't load EquipeDatabase");
        }
    }

    public static Task GetDataLoadingTask()
    {
        var cardsTask = LoadCardlStorage().AsTask();
        var equipeTask = LoadEquipeStorage().AsTask();

        return Task.WhenAll(cardsTask, equipeTask);
    }


}
