using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Nethereum.Unity.Rpc;

public class ChainManager : MonoBehaviour
{
    // --- Essentials --- //
    string zkMainnetRPC = "https://mainnet.infura.io/v3/";
    string zkTestnetRPC = "https://testnet.era.zksync.dev";

    string nftAddress = "0x789e35a999c443fE6089544056f728239B8ffeE7";

    //BigInteger zkTestnetID = 280;
    //BigInteger zkMainnetID = 280;

    string address = "0xc479D3fd2F4A1a295fa190191446Ff5B7d2C0551";
    int balance = 0;

    private void Start()
    {
        StartCoroutine(CheckBalance());
    }

    public IEnumerator CheckBalance()
    {
        Debug.Log("Getting weapon balances for " + address);

        var queryRequest = new QueryUnityRequest<
            ContractDefinitions.Contracts.testNFT.ContractDefinition.BalanceOfFunction,
            ContractDefinitions.Contracts.testNFT.ContractDefinition.BalanceOfOutputDTO>(
            zkMainnetRPC, address
        );

        yield return queryRequest.Query(new ContractDefinitions.Contracts.testNFT.ContractDefinition
            .BalanceOfFunction()
        {
            Owner = address
        }, nftAddress);

        Debug.Log("Balance: " + queryRequest.Result.ReturnValue1);
    }
}
