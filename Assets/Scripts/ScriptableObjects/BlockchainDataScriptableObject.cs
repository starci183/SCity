using UnityEngine;

[CreateAssetMenu(fileName = "BlockchainData", menuName = "ScriptableObjects/BlockchainData")]
public class BlockchainDataScriptableObject : ScriptableObject
{
    public string Address;
    public float Balance;
    public ChainName ChainName;
}

public enum ChainName
{
    SUI
}