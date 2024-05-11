using Newtonsoft.Json;
using System.Collections;
using System.Net.Http;
using Unity.Netcode;
using UnityEngine;

public class NetworkServerController : Singleton<NetworkServerController>
{
    private IEnumerator StartServerCoroutine()
    {
        yield return new WaitUntil(() => BootstrapStartupController.HasFinished);

        var createRelayAsync = RelayUtility.CreateRelayAsync();
        yield return new WaitUntil(() => createRelayAsync.IsCompleted);
        var joinCode = createRelayAsync.Result;

        var postAsync = HttpUtility.PostAsync(
            Constants.ApiEndpoints.JOIN_CODE,
            new JoinCodeDto()
            {
                JoinCode = joinCode
            },
            async (message) =>
            {
                Debug.Log(JsonConvert.SerializeObject(message));
            }
        );
        yield return new WaitUntil(() => postAsync.IsCompleted);

        NetworkManager.Singleton.StartServer();
    }

    private void StartServer()
    {
        StartCoroutine(StartServerCoroutine());
    }

    private void Start()
    {
        StartServer();

        NetworkManager.Singleton.OnServerStarted += () =>
        {
            Debug.Log("Server started");
        };

        NetworkManager.Singleton.OnServerStopped += obj =>
        {
            StartServer();
        };
    }
}
