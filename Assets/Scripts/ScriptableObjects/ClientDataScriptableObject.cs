using UnityEngine;

[CreateAssetMenu(fileName = "ClientData", menuName = "ScriptableObjects/ClientData")]
public class ClientDataScriptableObject : ScriptableObject
{
    public string joinCode;
    public bool isPlayerSpawned;
}