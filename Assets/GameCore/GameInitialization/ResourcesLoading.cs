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

    public static Task GetDataLoadingTask()
    {

        UniTask uniTask = LoadCardlStorage();
        var task = uniTask.AsTask();

        return task;
    }

}
