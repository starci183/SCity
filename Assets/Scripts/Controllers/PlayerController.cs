using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    [SerializeField]
    private ClientDataScriptableObject _clientDataScriptableObject;

    [SerializeField]
    private Vector3 _spawnPoint;

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            _clientDataScriptableObject.isPlayerSpawned = true;
            UpdatePositionRpc();
        }
    }
    private Vector3 GetPlayerSpawnPosition()
    {
        return new (
            Random.Range(_spawnPoint.x - 1, _spawnPoint.x + 1), 
            _spawnPoint.y, 
            Random.Range(_spawnPoint.z - 1, _spawnPoint.z + 1)
            );
    }

    [Rpc(SendTo.NotServer)]
    private void UpdatePositionRpc()
    {
        transform.position = GetPlayerSpawnPosition();
    }
}
