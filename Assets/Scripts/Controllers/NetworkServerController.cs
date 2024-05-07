using System.Collections;
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
        Debug.Log(joinCode);

        NetworkManager.Singleton.StartServer();
        NetworkManager.Singleton.OnServerStarted += () =>
        {
            Debug.Log("Server started");
        };
    }
}
