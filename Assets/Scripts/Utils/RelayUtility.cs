using System.Threading.Tasks;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;

public static class RelayUtility
{
    private static readonly int MAX_CONNECTIONS = 100;
    public static async Task<string> CreateRelayAsync()
    {
        var allocation = await RelayService.Instance.CreateAllocationAsync(MAX_CONNECTIONS);
        var relayServerData = new RelayServerData(allocation, "udp");

        var joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

        NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);
        return joinCode;
    }

    public static async Task JoinRelayAsync(string joinCode)
    {
        var joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);
        Debug.Log(joinAllocation);

        var relayServerData = new RelayServerData(joinAllocation, "udp");

        NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(
            relayServerData
            );
    }
}
