using Cinemachine;
using System.Collections;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class NetworkClientController : Singleton<NetworkClientController>
{
    [SerializeField]
    private GameObject _serverData;

    private async void Start()
    {
        //NetworkManager.Singleton.StartClient();
        //NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
        //{
        //    Debug.Log("Client connected");
        //};
    }
}