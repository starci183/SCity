using System;
using System.Collections;
using Unity.Collections;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport;
using Unity.Networking.Transport.TLS;
using UnityEngine;

public class NetworkServerController : Singleton<NetworkServerController>
{
    private async void Start()
    {
        var joinCode = await RelayUtility.CreateRelayAsync();
        Debug.Log(joinCode);

        NetworkManager.Singleton.StartServer();
        NetworkManager.Singleton.OnServerStarted += () =>
        {
            Debug.Log("Server started");
        };
    }
}
