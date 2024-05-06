using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    [SerializeField]
    private Vector3 _spawnPosition;

    [SerializeField]
    private ClientDataScriptableObject _clientDataScriptableObject;
    
    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            
            _clientDataScriptableObject.isPlayerSpawned = true;
        }
    }

    public void Start()
    {
         transform.position = _spawnPosition;
    }
}
