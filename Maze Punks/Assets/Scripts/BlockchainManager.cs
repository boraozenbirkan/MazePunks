using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Numerics;

using Nethereum.Unity.Metamask;     // for GetContractTransactionUnityRequest
using Nethereum.Unity.Contracts;    // for GetContractTransactionUnityRequest
using Nethereum.Unity.Rpc;          // for GetUnityRpcRequestClientFactory
using Nethereum.RPC.HostWallet;
using Nethereum.Hex.HexTypes;
using Nethereum.JsonRpc.Client;

public class BlockchainManager : MonoBehaviour
{
    public static BlockchainManager instance;

    public int punkBalance { get; private set; }

    // --- Essentials --- //
    bool _isMetamaskInitialised;
    string _selectedAccountAddress = "0x85be25d0Ef53959dB27D42df1f7da57549154D5f";
    string _currentContractAddress = "";
    private BigInteger _currentChainId;
    private BigInteger desiredChainID = 421613; // Arbi Goerli

    string zkMainnetRPC = "https://mainnet.era.zksync.io";
    string zkPunks = "0x474d5d6c77efb701c7fd0727164082c99767bf88";

    string arbitrumMainnetRPC = "https://arbitrum-mainnet.infura.io";
    string arbiPunks = "0x652d66fe218a7c33808b7d6a7db6a54e2f9f4a51";

    string polygonMainnetRPC = "https://polygon-rpc.com/";
    string polyPunks = "0x9498274b8c82b4a3127d67839f2127f2ae9753f4";

    string ethMainnetRPC = "https://mainnet.infura.io/v3/";
    string ethPunks = "0xb47e3cd837ddf8e4c57f05d70ab865de6e193bbb";

    string zkTestnetRPC = "https://testnet.era.zksync.dev";
    string zkTestPunks = "0xd40B3768d53Ed4340F6fbCF66aB69044Faf422f5";

    Manager manager;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        manager = FindObjectOfType<Manager>();

        StartCoroutine(ERC721BalanceOf());
    }

    public IEnumerator ERC721BalanceOf()
    {
        print("Wallet: " + _selectedAccountAddress);

        // **** zk Punks **** \\
        #region
        print("Zk Punks Era - " + zkPunks);

        var queryRequest = new QueryUnityRequest<
                Contracts.ERC721.ContractDefinition.BalanceOfFunction,
                Contracts.ERC721.ContractDefinition.BalanceOfOutputDTO>(
                zkMainnetRPC, _selectedAccountAddress
            );

        yield return queryRequest.Query(new Contracts.ERC721.ContractDefinition
            .BalanceOfFunction()
        {
            Account = _selectedAccountAddress
        }, zkPunks);

        //Getting the dto response already decoded
        try
        {
            punkBalance += (int)queryRequest.Result.ReturnValue1;
            print("Zk Punks Era Balance: " + punkBalance);
        }
        catch (Exception ex)
        {
            print("ERROR !! Can't retreive balance from the Zk Punks Era contract using balanceOf funtion!");
            Debug.LogError("Expetion: " + ex);
        }
        #endregion


        // **** arbi Punks **** \\
        #region
        print("Punks On Arbitrum - " + arbiPunks);

        var arbQueryRequest = new QueryUnityRequest<
                Contracts.ArbPunk.ContractDefinition.BalanceOfFunction,
                Contracts.ArbPunk.ContractDefinition.BalanceOfOutputDTO>(
                arbitrumMainnetRPC, _selectedAccountAddress
            );

        yield return arbQueryRequest.Query(new Contracts.ArbPunk.ContractDefinition
            .BalanceOfFunction()
        {
            Owner = _selectedAccountAddress
        }, arbiPunks);

        //Getting the dto response already decoded
        try
        {
            punkBalance += (int)arbQueryRequest.Result.ReturnValue1;
            print("Punks On Arbitrum Balance: " + arbQueryRequest.Result.ReturnValue1);
        }
        catch (Exception ex)
        {
            print("ERROR !! Can't retreive balance from the Punks On Arbitrum contract using balanceOf funtion!");
            Debug.LogError("Expection: " + ex.Message);
        }
        #endregion


        // **** polygon Punks **** \\
        #region
        print("Polygon Punks - " + polyPunks);

        queryRequest = new QueryUnityRequest<
                Contracts.ERC721.ContractDefinition.BalanceOfFunction,
                Contracts.ERC721.ContractDefinition.BalanceOfOutputDTO>(
                polygonMainnetRPC, _selectedAccountAddress
            );

        yield return queryRequest.Query(new Contracts.ERC721.ContractDefinition
            .BalanceOfFunction()
        {
            Account = _selectedAccountAddress
        }, polyPunks);

        //Getting the dto response already decoded
        try
        {
            punkBalance += (int)queryRequest.Result.ReturnValue1;
            print("Polygon Punks Balance: " + queryRequest.Result.ReturnValue1);
        }
        catch (Exception ex)
        {
            print("ERROR !! Can't retreive balance from the Polygon Punks contract using balanceOf funtion!");
            Debug.LogError("Expection: " + ex.Message);
        }
        #endregion


        // **** eth Punks **** \\
        #region
        print("CryptoPunks - " + ethPunks);

        var ethQueryRequest = new QueryUnityRequest<
                Contracts.CryptoPunks.ContractDefinition.BalanceOfFunction,
                Contracts.CryptoPunks.ContractDefinition.BalanceOfOutputDTO>(
                ethMainnetRPC, _selectedAccountAddress
            );

        yield return ethQueryRequest.Query(new Contracts.CryptoPunks.ContractDefinition
            .BalanceOfFunction()
        {
            ReturnValue1 = _selectedAccountAddress
        }, ethPunks);

        //Getting the dto response already decoded
        try
        {
            punkBalance += (int)ethQueryRequest.Result.ReturnValue1;
            print("CryptoPunks Balance: " + ethQueryRequest.Result.ReturnValue1);
        }
        catch (Exception ex)
        {
            print("ERROR !! Can't retreive balance from the CryptoPunks contract using balanceOf funtion!");
            Debug.LogError("Expection: " + ex.Message);
        }
        #endregion


        // **** test Punks **** \\
        #region
        print("Testnet Punks - " + zkTestPunks);

        queryRequest = new QueryUnityRequest<
                Contracts.ERC721.ContractDefinition.BalanceOfFunction,
                Contracts.ERC721.ContractDefinition.BalanceOfOutputDTO>(
                zkTestnetRPC, _selectedAccountAddress
            );

        yield return queryRequest.Query(new Contracts.ERC721.ContractDefinition
            .BalanceOfFunction()
        {
            Account = _selectedAccountAddress
        }, zkTestPunks);

        //Getting the dto response already decoded
        try
        {
            punkBalance += (int)queryRequest.Result.ReturnValue1;
            print("Testnet Punks Balance: " + queryRequest.Result.ReturnValue1);
        }
        catch
        {
            print("ERROR !! Can't retreive balance from the Testnet Punks contract using balanceOf funtion!");
        }
        #endregion

        manager.OnBalanceReturn(punkBalance);
    }    
}
