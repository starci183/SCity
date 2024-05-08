using Newtonsoft.Json;
using System.Collections;
using System.Net.Http;
using Unity.Netcode;
using UnityEngine;

public class NetworkServerController : Singleton<NetworkServerController>
{
    private IEnumerator Start()
    {
        yield return new WaitUntil(() => StartupController.HasFinished);

        var createRelayAsync = RelayUtility.CreateRelayAsync();
        yield return new WaitUntil(() => createRelayAsync.IsCompleted);
        var joinCode = createRelayAsync.Result;

        var postAsync = HttpUtility.PostAsync<JoinCodeDto, SuccessDto>(
            joinCode,
            new JoinCodeDto()
            {
                JoinCode = joinCode
            },
        async (response) =>
        {
            Debug.Log(response.StatusCode);
        }
        );
        yield return new WaitUntil(() => postAsync.IsCompleted);

        Debug.Log(joinCode);

        NetworkManager.Singleton.StartServer();
        NetworkManager.Singleton.OnServerStarted += () =>
        {
            Debug.Log("Server started");
        };
    }
}
