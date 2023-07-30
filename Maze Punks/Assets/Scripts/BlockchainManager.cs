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
    string _selectedAccountAddress = "";
    string _currentContractAddress = "";
    private BigInteger _currentChainId;
    private BigInteger desiredChainID = 421613; // Arbi Goerli

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
        string zkMainnetRPC = "https://mainnet.era.zksync.io";
        string nftAddress = "0xd07180c423f9b8cf84012aa28cc174f3c433ee29";
        string walletAddress = "0x9e24f415df66b07e842bc925f6c0b204ed17853f";

        print("Wallet: " + walletAddress);
        print("Balance Of - Lord Contract: " + nftAddress);

        var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickLord.ContractDefinition.BalanceOfFunction,
                Contracts.Contracts.StickLord.ContractDefinition.BalanceOfOutputDTO>(
                zkMainnetRPC, walletAddress
            );

        yield return queryRequest.Query(new Contracts.Contracts.StickLord.ContractDefinition
            .BalanceOfFunction()
        {
            Owner = walletAddress
        }, nftAddress);

        //Getting the dto response already decoded
        punkBalance = (int)queryRequest.Result.ReturnValue1;

        print("Balance: " + punkBalance);

        manager.OnBalanceReturn(punkBalance);
    }

    /*
    //******    BUTTONS    ******
    // Other
    public void Button_TokenBalanceUpdate() { StartCoroutine(TokenBalanceOfCall()); }
    public void Button_DAOBalanceUpdate() { StartCoroutine(DAOBalanceOfCall()); }

    // Lord
    public void Button_LordMint()
    {
        print("string: " + lordPriceInput.text);

        Double price = Double.Parse(lordPriceInput.text, System.Globalization.CultureInfo.InvariantCulture);

        if (price < 0.05)
        {
            print("Price is lower than minimum(0.05 ETH) !!");
            return;
        }

        print("Lord Mint Price to send: " + price.ToString());

        StartCoroutine(LordMintCall(ToWei(price)));
    }
    public void Button_LordUpdateSupply() { StartCoroutine(GetLordSupply()); }
    public void Button_LordID(BigInteger index) { StartCoroutine(LordIDCall(index)); }

    // Clan
    public void Button_ClanCreate() { StartCoroutine(CreateClanCall()); }
    public void Button_ClanDeclare() { StartCoroutine(DeclareClanCall()); }
    public void Button_ClanSetMember(bool assignAsMember) { StartCoroutine(SetMemberCall(assignAsMember)); }
    public void Button_ClanSetExecutor(bool assignAsExecutor) { StartCoroutine(SetExecutorCall(assignAsExecutor)); }
    public void Button_ClanSetMod(bool assignAsMod) { StartCoroutine(SetModCall(assignAsMod)); }
    public void Button_ClanGiveMemberPoint(bool isDecreasing)
    {
        BigInteger point = BigInteger.Parse(clanGiveMemberPointPointInput.text, System.Globalization.CultureInfo.InvariantCulture);

        if (point == 0) { print("PLEASE ENTER SOME POINT !!"); return; }
        StartCoroutine(GiveMemberPointCall(point, isDecreasing));
    }
    public void Button_ClanTransferLeadership() { StartCoroutine(TransferLeadershipCall()); }
    public void Button_ClanDisband() { StartCoroutine(DisbandCall()); }
    public void Button_ClanUpdateInfo() { StartCoroutine(UpdateClanInfoCall()); }
    public void Button_ClanViewInfo() { StartCoroutine(ViewClanInfoCall(int.Parse(clanIDSearchInput.text))); }

    // Round

    // DAO
    public void Button_DAOnewProposal() { StartCoroutine(NewProposalCall()); }

    // Item
    public void Button_ItemMint(BigInteger id, BigInteger amount) { StartCoroutine(MintItemCall(id, amount)); }
    public void Button_ItemBurn(List<BigInteger> ids, List<BigInteger> amounts) { StartCoroutine(BurnItemsCall(ids, amounts)); }
    public void Button_ItemBalanceOf(BigInteger id) { StartCoroutine(ItemBalanceOfCall(id)); }
    public void Button_ItemCheckMintAllowance() { StartCoroutine(ItemMintAllowanceCheckCall()); }
    public void Button_ItemIncreaseTokenAllowance() { StartCoroutine(ItemMintAllowanceCall()); }



    /*
     * 
     *              CHANGE ALL REFERENCES NON_BUTTON FUNCTION TO COROUTINE FUNCTIONS
     *              
     * 


    //******    BLOCKCHAIN FUNCTIONS    ******
    // General
    public IEnumerator TokenBalanceOfCall()
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Balance Of - Token Contract: " + tokenContractAddress);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.Token.ContractDefinition.BalanceOfFunction,
                Contracts.Contracts.Token.ContractDefinition.BalanceOfOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.Token.ContractDefinition
                .BalanceOfFunction()
            {
                Account = _selectedAccountAddress
            }, tokenContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            var balance = dtoResult.ReturnValue1;

            chainReader.DisplayTokenBalance(FromWei(balance));
            print("Balance of " + _selectedAccountAddress + " : " + FromWei(balance));
        }
    }
    public IEnumerator DAOBalanceOfCall()
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Balance Of - DAO Contract: " + DAOContractAddress);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.Token.ContractDefinition.BalanceOfFunction,
                Contracts.Contracts.Token.ContractDefinition.BalanceOfOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.Token.ContractDefinition
                .BalanceOfFunction()
            {
                Account = _selectedAccountAddress
            }, DAOContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            var balance = dtoResult.ReturnValue1;

            chainReader.DisplayDAOBalance(FromWei(balance));
            print("Balance of " + _selectedAccountAddress + " : " + FromWei(balance));
        }
    }
    private IEnumerator ItemMintAllowanceCheckCall()
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Item Contract Allowance - Token Contract: " + tokenContractAddress);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.Token.ContractDefinition.AllowanceFunction,
                Contracts.Contracts.Token.ContractDefinition.AllowanceOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.Token.ContractDefinition
                .AllowanceFunction()
            {
                Owner = _selectedAccountAddress,
                Spender = itemContractAddress
            }, tokenContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            var allowance = FromWei(dtoResult.ReturnValue1);

            if (allowance >= 1000000000) // If the allowance is more than 1 billion token
            {
                print("Allowance is given!");
                chainReader.WriteItemMintAllowance(true);
            }
            print("Allowance Of " + _selectedAccountAddress + " : " + allowance);
        }
    }
    public IEnumerator BossSupplyCall()
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Boss Supply Call - Boss Contract: " + bossContractAddress);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.Boss.ContractDefinition.TotalSupplyFunction,
                Contracts.Contracts.Boss.ContractDefinition.TotalSupplyOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.Boss.ContractDefinition
                .TotalSupplyFunction()
            { }, bossContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            var supply = dtoResult.ReturnValue1;

            chainReader.OnBossSupplyReturn((int)supply);

            print("Current Boss Supply: " + supply);
        }
    }

    //------ CLAN CONTRACT ------//
    // Write
    private IEnumerator CreateClanCall()
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Creating Clan - Clan Contract: " + clanContractAddress);
        // Paramaters
        print("Lord ID: " + BigInteger.Parse(createClanLordIDInput.text));
        print("Clan Name: " + createClanNameInput.text);
        print("Clan Description: " + createClanDescriptionInput.text);
        print("Clan Logo URI: " + createClanLogoInput.text);
        print("Clan Motto: " + createClanMottoInput.text);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var callFunction = new Contracts.Contracts.StickClan.ContractDefinition.CreateClanFunction
            {
                LordID = BigInteger.Parse(createClanLordIDInput.text),
                ClanName = createClanNameInput.text,
                ClanDescription = createClanDescriptionInput.text,
                ClanLogoURI = createClanLogoInput.text,
                ClanMotto = createClanMottoInput.text
            };

            yield return contractTransactionUnityRequest.
                SignAndSendTransaction(callFunction, clanContractAddress);

            if (contractTransactionUnityRequest.Exception == null)
            {
                print(contractTransactionUnityRequest.Result);
            }
            else
            {
                print(contractTransactionUnityRequest.Exception.Message);
            }
        }

        // Wait for a short time to check
        print("Waiting " + checkDelay_1 + 5f + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_1 + 5f);

        // Check the last status of the state
        print("Checking the last status!");
        StartCoroutine(WalletClanCall());

        // Then wait one more time but a bit longer to check the last status
        print("Waiting " + checkDelay_2 + 10f + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_2 + 10f);

        // Check the last status one more time
        print("Checking the last status again!");
        StartCoroutine(WalletClanCall());
    }
    private IEnumerator DeclareClanCall()
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Declaring Clan - Clan Contract: " + clanContractAddress);
        // Paramaters
        print("Clan ID: " + BigInteger.Parse(clanIDSearchInput.text));

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var callFunction = new Contracts.Contracts.StickClan.ContractDefinition.DeclareClanFunction
            {
                ClanID = BigInteger.Parse(clanIDSearchInput.text)
            };

            yield return contractTransactionUnityRequest.
                SignAndSendTransaction(callFunction, clanContractAddress);

            if (contractTransactionUnityRequest.Exception == null)
            {
                print(contractTransactionUnityRequest.Result);
            }
            else
            {
                print(contractTransactionUnityRequest.Exception.Message);
            }

        }

        // Wait for a short time to check
        print("Waiting " + checkDelay_1 + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_1);

        // Check the last status of the state
        print("Checking the last status!");
        StartCoroutine(GetDeclaredClanCall());

        // Then wait one more time but a bit longer to check the last status
        print("Waiting " + checkDelay_2 + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_2);

        // Check the last status one more time
        print("Checking the last status again!");
        StartCoroutine(GetDeclaredClanCall());
    }
    private IEnumerator SetMemberCall(bool assignAsMember)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Set Member - Clan Contract: " + clanContractAddress);
        // Parameters
        print("Clan ID: " + chainReader.displayClan.id);
        print("Member Address: " + clanSetMemberAddressInput.text);
        print("Set As: " + assignAsMember);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var callFunction = new Contracts.Contracts.StickClan.ContractDefinition.SetMemberFunction
            {
                ClanID = (BigInteger)chainReader.displayClan.id, // Get the displayed clan ID
                Address = clanSetMemberAddressInput.text,
                SetAsMember = assignAsMember
            };

            yield return contractTransactionUnityRequest.
                SignAndSendTransaction(callFunction, clanContractAddress);

            if (contractTransactionUnityRequest.Exception == null)
            {
                print(contractTransactionUnityRequest.Result);
            }
            else
            {
                print(contractTransactionUnityRequest.Exception.Message);
            }
        }

        // Wait for a short time to check
        print("Waiting " + checkDelay_1 + 5f + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_1 + 5f);

        // Check the last status of the state
        print("Checking the last status!");
        StartCoroutine(GetClanPointsCall(chainReader.displayClan.id));

        // Then wait one more time but a bit longer to check the last status
        print("Waiting " + checkDelay_2 + 10f + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_2 + 10f);

        // Check the last status one more time
        print("Checking the last status again!");
        StartCoroutine(GetClanPointsCall(chainReader.displayClan.id));
    }
    private IEnumerator SetExecutorCall(bool assignAsExecutor)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Set Executor - Clan Contract: " + clanContractAddress);
        // Parameters
        print("Clan ID: " + chainReader.displayClan.id);
        print("Executor Address: " + clanSetExecutorAddressInput.text);
        print("Set As: " + assignAsExecutor);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var callFunction = new Contracts.Contracts.StickClan.ContractDefinition.SetClanExecutorFunction
            {
                ClanID = (BigInteger)chainReader.displayClan.id, // Get the displayed clan ID
                Address = clanSetExecutorAddressInput.text,
                SetAsExecutor = assignAsExecutor
            };

            yield return contractTransactionUnityRequest.
                SignAndSendTransaction(callFunction, clanContractAddress);

            if (contractTransactionUnityRequest.Exception == null)
            {
                print(contractTransactionUnityRequest.Result);
            }
            else
            {
                print(contractTransactionUnityRequest.Exception.Message);
            }
        }

        // Wait for a short time to check
        print("Waiting " + checkDelay_1 + 5f + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_1 + 5f);

        // Check the last status of the state
        print("Checking the last status!");
        StartCoroutine(GetClanPointsCall(chainReader.displayClan.id));

        // Then wait one more time but a bit longer to check the last status
        print("Waiting " + checkDelay_2 + 10f + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_2 + 10f);

        // Check the last status one more time
        print("Checking the last status again!");
        StartCoroutine(GetClanPointsCall(chainReader.displayClan.id));
    }
    private IEnumerator SetModCall(bool assignAsMod)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Set Mod - Clan Contract: " + clanContractAddress);
        // Parameters
        print("Clan ID: " + chainReader.displayClan.id);
        print("Mod Address: " + clanSetModAddressInput.text);
        print("Set As: " + assignAsMod);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var callFunction = new Contracts.Contracts.StickClan.ContractDefinition.SetClanModFunction
            {
                ClanID = (BigInteger)chainReader.displayClan.id, // Get the displayed clan ID
                Address = clanSetModAddressInput.text,
                SetAsMod = assignAsMod
            };

            yield return contractTransactionUnityRequest.
                SignAndSendTransaction(callFunction, clanContractAddress);

            if (contractTransactionUnityRequest.Exception == null)
            {
                print(contractTransactionUnityRequest.Result);
            }
            else
            {
                print(contractTransactionUnityRequest.Exception.Message);
            }
        }

        // Wait for a short time to check
        print("Waiting " + checkDelay_1 + 5f + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_1 + 5f);

        // Check the last status of the state
        print("Checking the last status!");
        StartCoroutine(GetClanPointsCall(chainReader.displayClan.id));

        // Then wait one more time but a bit longer to check the last status
        print("Waiting " + checkDelay_2 + 10f + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_2 + 10f);

        // Check the last status one more time
        print("Checking the last status again!");
        StartCoroutine(GetClanPointsCall(chainReader.displayClan.id));
    }
    private IEnumerator GiveMemberPointCall(BigInteger point, bool isDecreasing)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Give Member Point - Clan Contract: " + clanContractAddress);

        // Parameters
        print("Clan ID: " + chainReader.displayClan.id);
        print("Member Address: " + clanGiveMemberPointAddressInput.text);
        print("Point: " + point);
        print("Is decreasing?: " + isDecreasing);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var callFunction = new Contracts.Contracts.StickClan.ContractDefinition.GiveMemberPointFunction
            {
                ClanID = (BigInteger)chainReader.displayClan.id, // Get the displayed clan ID
                MemberAddress = clanGiveMemberPointAddressInput.text,
                Point = point,
                IsDecreasing = isDecreasing
            };

            yield return contractTransactionUnityRequest.
                SignAndSendTransaction(callFunction, clanContractAddress);

            if (contractTransactionUnityRequest.Exception == null)
            {
                print(contractTransactionUnityRequest.Result);
            }
            else
            {
                print(contractTransactionUnityRequest.Exception.Message);
            }
        }

        // Wait for a short time to check
        print("Waiting " + checkDelay_1 + 5f + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_1 + 5f);

        // Check the last status of the state
        print("Checking the last status!");
        StartCoroutine(GetClanPointsCall(chainReader.displayClan.id));

        // Then wait one more time but a bit longer to check the last status
        print("Waiting " + checkDelay_2 + 10f + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_2 + 10f);

        // Check the last status one more time
        print("Checking the last status again!");
        StartCoroutine(GetClanPointsCall(chainReader.displayClan.id));
    }
    public IEnumerator ClaimMemberRewardCall(BigInteger clanID, BigInteger roundNumber)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Claim Member Reward - Clan Contract: " + clanContractAddress);

        // Parameters
        print("Clan ID: " + clanID);
        print("Round Number: " + roundNumber);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var callFunction = new Contracts.Contracts.StickClan.ContractDefinition.MemberRewardClaimFunction
            {
                ClanID = clanID, // Get the displayed clan ID
                RoundNumber = roundNumber
            };

            yield return contractTransactionUnityRequest.
                SignAndSendTransaction(callFunction, clanContractAddress);

            if (contractTransactionUnityRequest.Exception == null)
            {
                print(contractTransactionUnityRequest.Result);
            }
            else
            {
                print(contractTransactionUnityRequest.Exception.Message);
            }
        }

        // Wait for a short time to check
        print("Waiting " + checkDelay_1 + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_1);

        // Check the last status of the state
        print("Checking the last status!");
        StartCoroutine(ViewMemberRewardCall(clanID, roundNumber));

        // Then wait one more time but a bit longer to check the last status
        print("Waiting " + checkDelay_2 + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_2);

        // Check the last status one more time
        print("Checking the last status again!");
        StartCoroutine(ViewMemberRewardCall(clanID, roundNumber));
    }
    private IEnumerator UpdateClanInfoCall()
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Update Clan Info - Clan Contract: " + clanContractAddress);

        // Parameters
        print("Clan ID: " + chainReader.displayClan.id);
        print("Name: " + clanUpdateInfoNameInput.text);
        print("Description: " + clanUpdateInfoDescInput.text);
        print("Motto: " + clanUpdateInfoMottoInput.text);
        print("Logo URI: " + clanUpdateInfoLogoInput.text);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var callFunction = new Contracts.Contracts.StickClan.ContractDefinition.UpdateClanInfoFunction
            {
                ClanID = chainReader.displayClan.id,
                NewName = clanUpdateInfoNameInput.text,
                NewDescription = clanUpdateInfoDescInput.text,
                NewMotto = clanUpdateInfoMottoInput.text,
                NewLogoURI = clanUpdateInfoLogoInput.text,
            };

            yield return contractTransactionUnityRequest.
                SignAndSendTransaction(callFunction, clanContractAddress);

            if (contractTransactionUnityRequest.Exception == null)
            {
                print(contractTransactionUnityRequest.Result);
            }
            else
            {
                print(contractTransactionUnityRequest.Exception.Message);
            }
        }

        // Wait for a short time to check
        print("Waiting " + checkDelay_1 + 5f + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_1 + 5f);

        // Check the last status of the state
        print("Checking the last status!");
        StartCoroutine(ViewClanInfoCall(chainReader.displayClan.id));

        // Then wait one more time but a bit longer to check the last status
        print("Waiting " + checkDelay_2 + 10f + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_2 + 10f);

        // Check the last status one more time
        print("Checking the last status again!");
        StartCoroutine(ViewClanInfoCall(chainReader.displayClan.id));
    }
    private IEnumerator TransferLeadershipCall()
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Transfer Leadership - Clan Contract: " + clanContractAddress);

        // Parameters
        print("Clan ID: " + chainReader.displayClan.id);
        print("New Leader Address: " + clanTransferLeadershipAddressInput.text);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var callFunction = new Contracts.Contracts.StickClan.ContractDefinition.TransferLeadershipFunction
            {
                ClanID = (BigInteger)chainReader.displayClan.id, // Get the displayed clan ID
                NewLeader = clanTransferLeadershipAddressInput.text
            };

            yield return contractTransactionUnityRequest.
                SignAndSendTransaction(callFunction, clanContractAddress);

            if (contractTransactionUnityRequest.Exception == null)
            {
                print(contractTransactionUnityRequest.Result);
            }
            else
            {
                print(contractTransactionUnityRequest.Exception.Message);
            }
        }

        // Wait for a short time to check
        print("Waiting " + checkDelay_1 + 5f + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_1 + 5f);

        // Check the last status of the state
        print("Checking the last status!");
        StartCoroutine(ViewClanInfoCall(chainReader.displayClan.id));

        // Then wait one more time but a bit longer to check the last status
        print("Waiting " + checkDelay_2 + 10f + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_2 + 10f);

        // Check the last status one more time
        print("Checking the last status again!");
        StartCoroutine(ViewClanInfoCall(chainReader.displayClan.id));
    }
    private IEnumerator DisbandCall()
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Disband - Clan Contract: " + clanContractAddress);

        // Parameters
        print("Clan ID: " + chainReader.displayClan.id);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var callFunction = new Contracts.Contracts.StickClan.ContractDefinition.DisbandClanFunction
            {
                ClanID = (BigInteger)chainReader.displayClan.id // Get the displayed clan ID
            };

            yield return contractTransactionUnityRequest.
                SignAndSendTransaction(callFunction, clanContractAddress);

            if (contractTransactionUnityRequest.Exception == null)
            {
                print(contractTransactionUnityRequest.Result);
            }
            else
            {
                print(contractTransactionUnityRequest.Exception.Message);
            }
        }

        // Wait for a short time to check
        print("Waiting " + checkDelay_1 + 5f + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_1 + 5f);

        // Check the last status of the state
        print("Checking the last status!");
        StartCoroutine(ViewClanInfoCall(chainReader.displayClan.id));

        // Then wait one more time but a bit longer to check the last status
        print("Waiting " + checkDelay_2 + 10f + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_2 + 10f);

        // Check the last status one more time
        print("Checking the last status again!");
        StartCoroutine(ViewClanInfoCall(chainReader.displayClan.id));
    }

    // Read
    public IEnumerator ViewMemberRewardCall(BigInteger clanID, BigInteger roundNumber)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("View Member Reward - Clan Contract: " + clanContractAddress);
        // Parameters
        print("Clan ID: " + clanID);
        print("Round Number: " + roundNumber);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickClan.ContractDefinition.ViewMemberRewardFunction,
                Contracts.Contracts.StickClan.ContractDefinition.ViewMemberRewardOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickClan.ContractDefinition
                .ViewMemberRewardFunction()
            {
                ClanID = clanID,
                RoundNumber = roundNumber
            }, clanContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            var reward = FromWei(dtoResult.ReturnValue1);

            chainReader.OnClanRewardReturn(reward);
            print("Available Member Reward: " + reward);
        }
    }
    public IEnumerator WalletClanCall()
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Get Clan Of - Clan Contract: " + clanContractAddress);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickClan.ContractDefinition.GetClanOfFunction,
                Contracts.Contracts.StickClan.ContractDefinition.GetClanOfOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickClan.ContractDefinition
                .GetClanOfFunction()
            {
                Address = _selectedAccountAddress
            }, clanContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            var clanID = dtoResult.ReturnValue1;

            // If the account has a clan and info not set yet
            if (clanID > 0 && !chainReader.clanInfoSet)
            {
                chainReader.walletClan.id = (int)clanID;  // Save the account's clan ID
                StartCoroutine(ViewClanInfoCall((int)clanID));
            }
            if (clanID == 0) { StartCoroutine(GetDeclaredClanCall()); }

            print("Clan ID of " + _selectedAccountAddress + " : " + clanID);
        }
    }
    public IEnumerator ViewClanInfoCall(int clanID)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("View Clan Info - Clan Contract: " + clanContractAddress);
        // Parameters
        print("Clan ID: " + clanID);

        StartCoroutine(GetClanPointsCall(clanID));  // Start the point call as well

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickClan.ContractDefinition.ViewClanInfoFunction,
                Contracts.Contracts.StickClan.ContractDefinition.ViewClanInfoOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickClan.ContractDefinition
                .ViewClanInfoFunction()
            {
                ClanID = clanID
            }, clanContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;

            Clan clan;
            if (clanID == chainReader.walletClan.id) { clan = chainReader.walletClan; }
            else { clan = chainReader.displayClan; }

            clan.id = clanID;
            clan.leaderAddress = dtoResult.ReturnValue1;
            clan.lordID = (int)dtoResult.ReturnValue2;
            clan.firstRound = (int)dtoResult.ReturnValue3;
            clan.name = dtoResult.ReturnValue4;
            clan.description = dtoResult.ReturnValue5;
            clan.motto = dtoResult.ReturnValue6;
            clan.logoURI = dtoResult.ReturnValue7;
            clan.canExecutorsSignalRebellion = dtoResult.ReturnValue8;
            clan.canExecutorsSetPoint = dtoResult.ReturnValue9;
            clan.canModsSetMembers = dtoResult.ReturnValue10;
            clan.isDisbanded = dtoResult.ReturnValue11;

            chainReader.DisplayClanInfo(clan);   // Send it to the reader to display

            print("Clan ID: " + clan.id);
            print("Clan Name: " + clan.name);
        }
    }
    private IEnumerator GetClanPointsCall(int clanID)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Get Clan Points - Clan Contract: " + clanContractAddress);
        // Parameters
        print("Clan ID: " + clanID);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickClan.ContractDefinition.GetClanPointsFunction,
                Contracts.Contracts.StickClan.ContractDefinition.GetClanPointsOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickClan.ContractDefinition
                .GetClanPointsFunction()
            {
                ClanID = clanID
            }, clanContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;

            Clan clan;
            if (clanID == chainReader.walletClan.id) { clan = chainReader.walletClan; }
            else { clan = chainReader.displayClan; }

            // Save the points
            clan.totalClanPoints = (int)dtoResult.ReturnValue1;
            clan.clanPoint = (int)dtoResult.ReturnValue2;
            clan.totalMemberPoints = (int)dtoResult.ReturnValue3;

            // Save the member info
            List<string> memberAddresses = dtoResult.ReturnValue5;
            List<BigInteger> memberPoints = dtoResult.ReturnValue6;
            List<bool> memberActive = dtoResult.ReturnValue7;
            List<bool> memberExecutor = dtoResult.ReturnValue8;
            List<bool> memberMod = dtoResult.ReturnValue9;

            int memberCount = dtoResult.ReturnValue5.Count;

            for (int i = 0; i < memberCount; i++)
            {
                if (memberActive[i])
                {
                    // Determine the role
                    string role;
                    if (memberAddresses[i] == clan.leaderAddress) { role = "Leader"; }
                    else if (memberExecutor[i]) { role = "Executor"; }
                    else if (memberMod[i]) { role = "Mod"; }
                    else { role = "Member"; }

                    // Calculate the share (if total member points is 0, then the share is 0 as well
                    double share = clan.totalMemberPoints == 0 ? 0 :
                        ((int)memberPoints[i] / clan.totalMemberPoints) * 100;

                    // Add the member
                    clan.members.Add(new Member(
                        memberAddresses[i], role, (int)memberPoints[i], share
                    ));
                }
            }

            chainReader.DisplayClanPoints(clan);

            print("Clan ID: " + clan.id);
            print("Clan Name: " + clan.name);
            print("Clan Point: " + clan.clanPoint);
        }
    }
    public IEnumerator GetDeclaredClanCall()
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Get Declared Clan - Clan Contract: " + clanContractAddress);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickClan.ContractDefinition.DeclaredClanFunction,
                Contracts.Contracts.StickClan.ContractDefinition.DeclaredClanOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickClan.ContractDefinition
                .DeclaredClanFunction()
            {
                ReturnValue1 = _selectedAccountAddress
            }, clanContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            var clanID = dtoResult.ReturnValue1;

            // If the user has a declared clan, then get its name as well
            if (clanID > 0)
            {
                var queryRequest_name = new QueryUnityRequest<
                    Contracts.Contracts.StickClan.ContractDefinition.ViewClanInfoFunction,
                    Contracts.Contracts.StickClan.ContractDefinition.ViewClanInfoOutputDTO>(
                    GetUnityRpcRequestClientFactory(), _selectedAccountAddress
                );

                yield return queryRequest_name.Query(new Contracts.Contracts.StickClan.ContractDefinition
                    .ViewClanInfoFunction()
                {
                    ClanID = clanID
                }, clanContractAddress);

                //Getting the dto response already decoded
                var dtoResult_name = queryRequest_name.Result;

                var name = dtoResult_name.ReturnValue4;

                // Display them on the screen
                chainReader.OnDeclaredClan(name, (int)clanID);

                print("Declared Clan Name: " + name + " (" + clanID + ") of " + _selectedAccountAddress);
            }
        }
    }



    //------ LORD CONTRACT ------//
    // Write
    private IEnumerator LordMintCall(BigInteger _amountToSend)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Lord Mint - Lord Contract: " + lordContractAddress);
        print("Given BigInteger: " + _amountToSend.ToString());

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var callFunction = new Contracts.Contracts.StickLord.ContractDefinition.LordMintFunction
            {
                AmountToSend = _amountToSend
            };

            yield return contractTransactionUnityRequest.
                SignAndSendTransaction(callFunction, lordContractAddress);

            if (contractTransactionUnityRequest.Exception == null)
            {
                print(contractTransactionUnityRequest.Result);
            }
            else
            {
                print(contractTransactionUnityRequest.Exception.Message);
            }
        }

        // Wait for a short time to check
        print("Waiting " + checkDelay_1 + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_1);

        // Check the last status of the state
        print("Checking the last status!");
        StartCoroutine(GetLordSupply());

        // Then wait one more time but a bit longer to check the last status
        print("Waiting " + checkDelay_2 + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_2);

        // Check the last status one more time
        print("Checking the last status again!");
        StartCoroutine(GetLordSupply());
    }
    public IEnumerator MintLicenseCall(LordContainer lordContainer, Lord lord, BigInteger _amount)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Mint License - Lord Contract: " + lordContractAddress);
        print("Amount: " + _amount);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var callFunction = new Contracts.Contracts.StickLord.ContractDefinition.MintClanLicenseFunction
            {
                Amount = _amount
            };

            yield return contractTransactionUnityRequest.
                SignAndSendTransaction(callFunction, lordContractAddress);

            if (contractTransactionUnityRequest.Exception == null)
            {
                print(contractTransactionUnityRequest.Result);
                lordContainer.MintSuccess();
            }
            else
            {
                print(contractTransactionUnityRequest.Exception.Message);
            }
        }

        // Wait for a short time to check
        print("Waiting " + checkDelay_1 + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_1);

        // Check the last status of the state
        print("Checking the last status!");
        StartCoroutine(LordNumberOfLicenseCall(lord));

        // Then wait one more time but a bit longer to check the last status
        print("Waiting " + checkDelay_2 + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_2);

        // Check the last status one more time
        print("Checking the last status again!");
        StartCoroutine(LordNumberOfLicenseCall(lord));
    }
    public IEnumerator LordDAOvoteCall(LordContainer lord, BigInteger _proposalID, bool _isApproving)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("DAO Vote - Lord Contract: " + lordContractAddress);
        print("Lord ID: " + lord.lordID);
        print("Proposal ID: " + _proposalID);
        print("is Approving?: " + _isApproving);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var callFunction = new Contracts.Contracts.StickLord.ContractDefinition.DAOvoteFunction
            {
                LordID = lord.lordID,
                ProposalID = _proposalID,
                IsApproving = _isApproving
            };

            yield return contractTransactionUnityRequest.
                SignAndSendTransaction(callFunction, lordContractAddress);

            if (contractTransactionUnityRequest.Exception == null)
            {
                print(contractTransactionUnityRequest.Result);
                lord.VoteSuccess();
            }
            else
            {
                print(contractTransactionUnityRequest.Exception.Message);
            }
        }
    }

    // Read
    public IEnumerator GetLordSupply()
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Lord Contract: " + lordContractAddress);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickLord.ContractDefinition.TotalSupplyFunction,
                Contracts.Contracts.StickLord.ContractDefinition.TotalSupplyOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickLord.ContractDefinition
                .TotalSupplyFunction()
            { }, lordContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            var supply = dtoResult.ReturnValue1;
            // Base         // After 50th   *   mint cost increase
            lordSupplyText.text = (0.05 + (((double)supply - 50) * 0.001)).ToString();
            lordCurrentCostText.text = supply.ToString() + "/256";
            print("Lord Supply: " + supply);
        }
    }
    public IEnumerator LordBalanceOfCall()
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Balance Of - Lord Contract: " + lordContractAddress);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickLord.ContractDefinition.BalanceOfFunction,
                Contracts.Contracts.StickLord.ContractDefinition.BalanceOfOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickLord.ContractDefinition
                .BalanceOfFunction()
            {
                Owner = _selectedAccountAddress
            }, lordContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            var balance = dtoResult.ReturnValue1;

            chainReader.OnLordBalanceReturn((int)balance);
            print("Balance: " + balance);
        }
    }
    public IEnumerator LordIDCall(BigInteger index)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("ID call - Lord Contract: " + lordContractAddress);
        print("Index: " + index);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickLord.ContractDefinition.TokenOfOwnerByIndexFunction,
                Contracts.Contracts.StickLord.ContractDefinition.TokenOfOwnerByIndexOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickLord.ContractDefinition
                .TokenOfOwnerByIndexFunction()
            {
                Owner = _selectedAccountAddress,
                Index = index
            }, lordContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            var id = dtoResult.ReturnValue1;

            chainReader.OnLordIDReturn((int)id);
            print("Owned ID: " + (int)id);
        }
    }
    public IEnumerator LordNumberOfClansCall(Lord lord)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Number Of Clans - Lord Contract: " + lordContractAddress);
        print("Lord ID: " + lord.id);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickLord.ContractDefinition.ViewNumberOfClansFunction,
                Contracts.Contracts.StickLord.ContractDefinition.ViewNumberOfClansOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickLord.ContractDefinition
                .ViewNumberOfClansFunction()
            {
                LordID = lord.id
            }, lordContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            var numOfClan = dtoResult.ReturnValue1;

            lord.ClanNumberSet((int)numOfClan);
            print("Number Of Clan of id(" + lord.id + "): " + numOfClan);
        }
    }
    public IEnumerator LordNumberOfLicenseCall(Lord lord)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Number Of License - License Contract: " + licenseContractAddress);
        print("Lord ID: " + lord.id);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.License.ContractDefinition.NumOfActiveLicenseFunction,
                Contracts.Contracts.License.ContractDefinition.NumOfActiveLicenseOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.License.ContractDefinition
                .NumOfActiveLicenseFunction()
            {
                ReturnValue1 = lord.id
            }, licenseContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            var numOfLicense = dtoResult.ReturnValue1;

            lord.LicenseNumberSet((int)numOfLicense);
            print("Number Of License of id(" + lord.id + "): " + numOfLicense);
        }
    }
    public IEnumerator LordCollectedTaxesCall(Lord lord)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Collected Taxes - Clan Contract: " + clanContractAddress);
        print("Lord ID: " + lord.id);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickClan.ContractDefinition.CollectedTaxesFunction,
                Contracts.Contracts.StickClan.ContractDefinition.CollectedTaxesOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickClan.ContractDefinition
                .CollectedTaxesFunction()
            {
                ReturnValue1 = lord.id
            }, clanContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            var collectedTaxes = dtoResult.ReturnValue1;

            lord.CollectedTaxSet((int)collectedTaxes);
            print("Collected Taxes of id(" + lord.id + "): " + collectedTaxes);
        }
    }



    //------ DAO CONTRACT ------//
    // Write
    private IEnumerator NewProposalCall()
    {
        print("Wallet: " + _selectedAccountAddress);
        print("New Proposal - DAO Contract: " + DAOContractAddress);

        string selectedText = proposalTypeInput.options[proposalTypeInput.value].text;
        print("Selected: " + selectedText);

        BigInteger type;
        switch (selectedText)
        {
            case "1 Hour":
                type = 1;
                break;
            case "1 Day":
                type = 2;
                break;
            case "3 Days":
                type = 3;
                break;
            default:
                type = 3;
                break;
        }

        print("Description: " + proposalDescription.text);
        print("Proposal Type: " + type);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            // Update proposal counter

            print("View Proposal Counter - DAO Contract: " + DAOContractAddress);

            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickDAO.ContractDefinition.ProposalCounterFunction,
                Contracts.Contracts.StickDAO.ContractDefinition.ProposalCounterOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickDAO.ContractDefinition
                .ProposalCounterFunction()
            { }, DAOContractAddress);

            //Getting the dto response already decoded
            proposalCounter = (int)queryRequest.Result.Value;
            print("Counter: " + proposalCounter);

            // Save the current counter
            int currentCounter = proposalCounter;

            // THEN, send new proposal transaction

            var callFunction = new Contracts.Contracts.StickDAO.ContractDefinition.NewProposalFunction
            {
                Description = proposalDescription.text,
                ProposalType = type
            };

            yield return contractTransactionUnityRequest.
                SignAndSendTransaction(callFunction, DAOContractAddress);

            if (contractTransactionUnityRequest.Exception == null)
            {
                print(contractTransactionUnityRequest.Result);
            }
            else
            {
                print(contractTransactionUnityRequest.Exception.Message);
            }


            // THEN check if the counter has changed

            int propChecked = 0;
            bool counterChanged = false;

            while (propChecked < 5 && !counterChanged)
            {
                print("Waiting 10 seconds to check if the proposal counter has changed");
                yield return new WaitForSeconds(10f);

                // Get the updated counter again
                yield return queryRequest.Query(new Contracts.Contracts.StickDAO.ContractDefinition
                .ProposalCounterFunction()
                { }, DAOContractAddress);

                // check if it is changed
                proposalCounter = (int)queryRequest.Result.Value;
                if (proposalCounter > currentCounter) { counterChanged = true; }
                propChecked++;
            }

            if (counterChanged) { StartCoroutine(GetProposal(proposalCounter - 1)); }
        }
    }
    public IEnumerator VoteCall(ProposalContainer proposal, bool _approve)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Vote - DAO Contract: " + DAOContractAddress);
        print("Proposal ID: " + proposal.id);
        print("Approve?: " + _approve);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var callFunction = new Contracts.Contracts.StickDAO.ContractDefinition.VoteFunction
            {
                ProposalID = proposal.id,
                IsApproving = _approve
            };

            yield return contractTransactionUnityRequest.
                SignAndSendTransaction(callFunction, DAOContractAddress);

            if (contractTransactionUnityRequest.Exception == null)
            {
                print(contractTransactionUnityRequest.Result);
            }
            else
            {
                print(contractTransactionUnityRequest.Exception.Message);
            }
        }

        // Wait for a short time to check
        print("Waiting " + checkDelay_1 + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_1);

        // Check the last status of the state
        print("Checking the last status!");
        StartCoroutine(UpdateProposal(proposal));

        // Then wait one more time but a bit longer to check the last status
        print("Waiting " + checkDelay_2 + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_2);

        // Check the last status one more time
        print("Checking the last status again!");
        StartCoroutine(UpdateProposal(proposal));
    }
    // LATER: Spending Proposal Claim Functions

    // Read
    public IEnumerator GetDAOBalanceCall()
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Balance Of - DAO Contract: " + DAOContractAddress);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickDAO.ContractDefinition.BalanceOfFunction,
                Contracts.Contracts.StickDAO.ContractDefinition.BalanceOfOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickDAO.ContractDefinition
                .BalanceOfFunction()
            {
                Account = _selectedAccountAddress
            }, DAOContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            var DAObalance = dtoResult.ReturnValue1;
            print("DAO Balance: " + DAObalance);
        }
    }
    public IEnumerator GetProposalCounter()
    {
        print("View Proposal Counter - DAO Contract: " + DAOContractAddress);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickDAO.ContractDefinition.ProposalCounterFunction,
                Contracts.Contracts.StickDAO.ContractDefinition.ProposalCounterOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickDAO.ContractDefinition
                .ProposalCounterFunction()
            { }, DAOContractAddress);

            //Getting the dto response already decoded
            proposalCounter = (int)queryRequest.Result.Value;
            print("Counter: " + proposalCounter);
        }
    }
    public IEnumerator GetLastProposals(int propAmountToGet)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("View Proposal Counter - DAO Contract: " + DAOContractAddress);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickDAO.ContractDefinition.ProposalCounterFunction,
                Contracts.Contracts.StickDAO.ContractDefinition.ProposalCounterOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickDAO.ContractDefinition
                .ProposalCounterFunction()
            { }, DAOContractAddress);

            //Getting the dto response already decoded
            int totalNumberOfProposals = (int)queryRequest.Result.Value;
            print("Proposal Counter: " + totalNumberOfProposals);

            // Determine the start and end index to get
            int startIndex;
            int endIndex;

            // TEST - CHANGE IT WHEN YOU UPDATE CHANE THE DAO CONTRACT : 4 -> totalNumberOfProposals
            if (4 - propAmountToGet > 0)
            {
                startIndex = 4 - propAmountToGet;
                endIndex = startIndex + propAmountToGet - 1;
            }
            else
            {
                startIndex = 1;
                endIndex = 4 - 1;
            }

            // Get proposals
            for (int i = startIndex; i <= endIndex; i++)
            {
                StartCoroutine(GetProposal(i));
            }
        }
    }
    public IEnumerator GetProposal(BigInteger proposalID)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("View Proposals - DAO Contract: " + DAOContractAddress);
        print("Proposal ID: " + proposalID);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickDAO.ContractDefinition.ProposalsFunction,
                Contracts.Contracts.StickDAO.ContractDefinition.ProposalsOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickDAO.ContractDefinition
                .ProposalsFunction()
            {
                ReturnValue1 = proposalID
            }, DAOContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;

            chainReader.OnProposalReturn(dtoResult);
        }
    }
    public IEnumerator UpdateProposal(ProposalContainer proposal)
    {
        print("Updateing Proposal - DAO Contract: " + DAOContractAddress);
        print("Proposal ID: " + proposal.id);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickDAO.ContractDefinition.ProposalsFunction,
                Contracts.Contracts.StickDAO.ContractDefinition.ProposalsOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickDAO.ContractDefinition
                .ProposalsFunction()
            {
                ReturnValue1 = proposal.id
            }, DAOContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;

            proposal.OnProposalUpdate(dtoResult);
        }
    }
    // BACKUP - OLD WAY
    /* HERE
    public IEnumerator GetLastProposalBasics(BigInteger proposalAmount)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("View Last Proposal Basics - DAO Contract: " + DAOContractAddress);
        print("Proposal Amount: " + proposalAmount);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickDAO.ContractDefinition.ViewLastProposalsBasicsFunction,
                Contracts.Contracts.StickDAO.ContractDefinition.ViewLastProposalsBasicsOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickDAO.ContractDefinition
                .ViewLastProposalsBasicsFunction()
            {
                ProposalAmount = proposalAmount
            }, DAOContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            var amount = dtoResult.ReturnValue1.Count;

            chainReader.OnProposalReturn_OLD(
                dtoResult.ReturnValue1, 
                dtoResult.ReturnValue2, 
                dtoResult.ReturnValue3, 
                dtoResult.ReturnValue4, 
                dtoResult.ReturnValue5
            );

            print("Received Amount: " + amount);
            print("Last Proposal ID: " + dtoResult.ReturnValue1[amount - 1]);
            print("Last Proposal Description: " + dtoResult.ReturnValue2[amount - 1]);
            print("Last Proposal Start Time: " + dtoResult.ReturnValue3[amount - 1]);
            print("Last Proposal Ending Time: " + dtoResult.ReturnValue4[amount - 1]);
            print("Last Proposal Status: " + dtoResult.ReturnValue5[amount - 1]);
        }
    }
    public IEnumerator GetLastProposalNumbers(BigInteger proposalAmount, List<ProposalContainer> props)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("View Last Proposal Numbers - DAO Contract: " + DAOContractAddress);
        print("Proposal Amount: " + proposalAmount);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickDAO.ContractDefinition.ViewLastProposalsNumbersFunction,
                Contracts.Contracts.StickDAO.ContractDefinition.ViewLastProposalsNumbersOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickDAO.ContractDefinition
                .ViewLastProposalsNumbersFunction()
            {
                ProposalAmount = proposalAmount
            }, DAOContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            var amount = dtoResult.ReturnValue1.Count;

            for (int i = 0; i < amount; i++)
            {
                props[i].participants = (int)dtoResult.ReturnValue1[i];
                props[i].forVotes = (int)dtoResult.ReturnValue3[i];
                props[i].againstVotes = (int)dtoResult.ReturnValue2[i] - props[i].forVotes;

                props[i].DisplayInfo();
            }

            print("Received Amount: " + amount);
            print("Last Proposal participants: " + dtoResult.ReturnValue1[amount - 1]);
            print("Last Proposal total votes: " + dtoResult.ReturnValue2[amount - 1]);
            print("Last Proposal for votes: " + dtoResult.ReturnValue3[amount - 1]);
        }
    }
    


    //------ ROUND CONTRACT ------//
    // Write
    public IEnumerator FundBossCall(BossContainer boss, BigInteger amount)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Fund Boss - Round Contract: " + roundContractAddress);

        print("Level: " + boss.selectedLevel);
        print("Boss ID: " + boss.id);
        print("Amount: " + amount);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var callFunction = new Contracts.Contracts.StickRound.ContractDefinition.FundBossFunction
            {
                LevelNumber = boss.selectedLevel,
                BossID = boss.id,
                FundAmount = ToWei((double)amount)
            };

            yield return contractTransactionUnityRequest.
                SignAndSendTransaction(callFunction, roundContractAddress);

            if (contractTransactionUnityRequest.Exception == null)
            {
                print(contractTransactionUnityRequest.Result);
            }
            else
            {
                print(contractTransactionUnityRequest.Exception.Message);
            }
        }

        // Wait for a short time to check
        print("Waiting " + checkDelay_1 + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_1);

        // Check the last status of the state
        print("Checking the last status!");
        StartCoroutine(GetCandidateFunds(chainReader.currentRound, boss));

        // Then wait one more time but a bit longer to check the last status
        print("Waiting " + checkDelay_2 + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_2);

        // Check the last status one more time
        print("Checking the last status again!");
        StartCoroutine(GetCandidateFunds(chainReader.currentRound, boss));
    }
    public IEnumerator DefundBossCall(BossContainer boss, BigInteger amount)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Defund Boss - Round Contract: " + roundContractAddress);

        print("Level: " + boss.selectedLevel);
        print("Boss ID: " + boss.id);
        print("Amount: " + amount);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var callFunction = new Contracts.Contracts.StickRound.ContractDefinition.FundBossFunction
            {
                LevelNumber = boss.selectedLevel,
                BossID = boss.id,
                FundAmount = ToWei((double)amount)
            };

            yield return contractTransactionUnityRequest.
                SignAndSendTransaction(callFunction, roundContractAddress);

            if (contractTransactionUnityRequest.Exception == null)
            {
                print(contractTransactionUnityRequest.Result);
            }
            else
            {
                print(contractTransactionUnityRequest.Exception.Message);
            }
        }

        // Wait for a short time to check
        print("Waiting " + checkDelay_1 + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_1);

        // Check the last status of the state
        print("Checking the last status!");
        StartCoroutine(GetCandidateFunds(chainReader.currentRound, boss));

        // Then wait one more time but a bit longer to check the last status
        print("Waiting " + checkDelay_2 + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_2);

        // Check the last status one more time
        print("Checking the last status again!");
        StartCoroutine(GetCandidateFunds(chainReader.currentRound, boss));
    }
    public IEnumerator ClaimBackerRewardCall(BigInteger roundNumber)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Claim Backer Reward- Round Contract: " + roundContractAddress);

        print("Round: " + roundNumber);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var callFunction = new Contracts.Contracts.StickRound.ContractDefinition.ClaimBackerRewardFunction
            {
                RoundNumber = roundNumber
            };

            yield return contractTransactionUnityRequest.
                SignAndSendTransaction(callFunction, roundContractAddress);

            if (contractTransactionUnityRequest.Exception == null)
            {
                print(contractTransactionUnityRequest.Result);
            }
            else
            {
                print(contractTransactionUnityRequest.Exception.Message);
            }
        }

        // Wait for a short time to check
        print("Waiting " + checkDelay_1 + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_1);

        // Check the last status of the state
        print("Checking the last status!");
        StartCoroutine(GetBackerRewards(chainReader.currentRound));

        // Then wait one more time but a bit longer to check the last status
        print("Waiting " + checkDelay_2 + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_2);

        // Check the last status one more time
        print("Checking the last status again!");
        StartCoroutine(GetBackerRewards(chainReader.currentRound));
    }

    // Read
    public IEnumerator GetCurrentBackerRewardCall()
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Get Backer Reward - Round Contract: " + roundContractAddress);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickRound.ContractDefinition.ViewCurrentBackerRewardsFunction,
                Contracts.Contracts.StickRound.ContractDefinition.ViewCurrentBackerRewardsOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickRound.ContractDefinition
                .ViewCurrentBackerRewardsFunction()
            { }, roundContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;

            chainReader.OnLevelBackerRewardReturn(dtoResult.ReturnValue1);
            print("Level 1 Backer Reward: " + dtoResult.ReturnValue1[0]);
        }
    }
    public IEnumerator GetCurrentRoundNumberCall()
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Get Current Round Number - Round Contract: " + roundContractAddress);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickRound.ContractDefinition.ViewRoundNumberFunction,
                Contracts.Contracts.StickRound.ContractDefinition.ViewRoundNumberOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickRound.ContractDefinition
                .ViewRoundNumberFunction()
            { }, roundContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            chainReader.currentRound = (int)dtoResult.ReturnValue1;

            print("Current Round: " + dtoResult.ReturnValue1);
        }
    }
    public IEnumerator GetLevelCandidatesCall(BigInteger roundNumber, BigInteger levelNumber)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("View Election (getting candidates) - Round Contract: " + roundContractAddress);
        // Paramters
        print("Round number:" + roundNumber);
        print("Level number:" + levelNumber);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickRound.ContractDefinition.ViewElectionFunction,
                Contracts.Contracts.StickRound.ContractDefinition.ViewElectionOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickRound.ContractDefinition
                .ViewElectionFunction()
            {
                RoundNumber = roundNumber,
                LevelNumber = levelNumber
            }, roundContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            chainReader.OnLevelCandidateReturnReturn((int)levelNumber, dtoResult.ReturnValue1);

            print("Round " + roundNumber + ", level " + levelNumber + " results:");
            foreach (BigInteger candidateID in dtoResult.ReturnValue1)
            {
                print("Candidate: " + candidateID);
            }
        }
    }
    public IEnumerator GetCandidateFunds(BigInteger roundNumber, BossContainer candidate)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("View Candidate Funds - Round Contract: " + roundContractAddress);
        // Paramters
        print("Round number:" + roundNumber);
        print("Level number:" + candidate.selectedLevel);
        print("Candidate ID:" + candidate.id);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickRound.ContractDefinition.ViewCandidateFundsFunction,
                Contracts.Contracts.StickRound.ContractDefinition.ViewCandidateFundsOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickRound.ContractDefinition
                .ViewCandidateFundsFunction()
            {
                RoundNumber = roundNumber,
                LevelNumber = candidate.selectedLevel,
                CandidateID = candidate.id,
            }, roundContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            candidate.OnAllFundsReturn((double)dtoResult.ReturnValue1);

            print("Round: " + roundNumber + "  level: " + candidate.selectedLevel + "  Candidate: " + candidate.id);
            print("Fund: " + dtoResult.ReturnValue1);
        }
    }
    public IEnumerator GetElectionUserFunds(BigInteger roundNumber, BossContainer candidate)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("View Candidate Funds - Round Contract: " + roundContractAddress);
        // Paramters
        print("Round number:" + roundNumber);
        print("Level number:" + candidate.selectedLevel);
        print("Candidate ID:" + candidate.id);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickRound.ContractDefinition.ViewCandidateFundsFunction,
                Contracts.Contracts.StickRound.ContractDefinition.ViewCandidateFundsOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickRound.ContractDefinition
                .ViewCandidateFundsFunction()
            {
                RoundNumber = roundNumber,
                LevelNumber = candidate.selectedLevel,
                CandidateID = candidate.id,
            }, roundContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            candidate.OnAllFundsReturn((double)dtoResult.ReturnValue1);

            print("Round: " + roundNumber + "  level: " + candidate.selectedLevel + "  Candidate: " + candidate.id);
            print("Fund: " + dtoResult.ReturnValue1);
        }
    }
    public IEnumerator GetBackerRewards(BigInteger roundNumber)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("View Backer Reward Info - Round Contract: " + roundContractAddress);
        // Paramters
        print("Round number:" + roundNumber);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickRound.ContractDefinition.ViewBackerRewardInfoFunction,
                Contracts.Contracts.StickRound.ContractDefinition.ViewBackerRewardInfoOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickRound.ContractDefinition
                .ViewBackerRewardInfoFunction()
            {
                RoundNumber = roundNumber,
                Backer = _selectedAccountAddress
            }, roundContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            chainReader.OnBackerRewardsReturn(dtoResult.ReturnValue1,
                dtoResult.ReturnValue2, dtoResult.ReturnValue3, dtoResult.ReturnValue4);
        }
    }
    public IEnumerator GetPlayerRewards(BigInteger roundNumber)
    {
        // DOESN'T WORK WITHOUT MERKLE PROOF

        print("Wallet: " + _selectedAccountAddress);
        print("View Player Reward Info - Round Contract: " + roundContractAddress);
        // Paramters
        print("Round number:" + roundNumber);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.StickRound.ContractDefinition.ViewPlayerRewardsFunction,
                Contracts.Contracts.StickRound.ContractDefinition.ViewPlayerRewardsOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.StickRound.ContractDefinition
                .ViewPlayerRewardsFunction()
            {
                RoundNumber = roundNumber,
                // NEED MERKLE PROOFF
            }, roundContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
        }
    }

    //------ BOSS CONTRACT ------//
    // Read
    public IEnumerator GetBossRektCall(BossContainer boss)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Get Boss Rekt - Boss Contract: " + bossContractAddress);
        print("Boss ID: " + boss.id);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.Boss.ContractDefinition.NumOfRektFunction,
                Contracts.Contracts.Boss.ContractDefinition.NumOfRektOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.Boss.ContractDefinition
                .NumOfRektFunction()
            {
                ReturnValue1 = boss.id
            }, bossContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            var numOfRekt = dtoResult.ReturnValue1;

            boss.OnBossRektReturn((int)numOfRekt);
            print("Number Of Rekt of id(" + boss.id + "): " + numOfRekt);

        }
    }

    // public List<byte[]> GetProof(byte[] hashLeaf) --> hashLeaf ??
    // 



    //------ ITEM CONTRACT ------//
    // Write
    private IEnumerator MintItemCall(BigInteger id, BigInteger amount)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Mint - Items Contract: " + itemContractAddress);

        print("id: " + id);
        print("Amount: " + amount);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var callFunction = new Contracts.Contracts.Items.ContractDefinition.MintFunction
            {
                Id = id,
                Amount = amount,
                Data = new byte[0]
            };

            yield return contractTransactionUnityRequest.
                SignAndSendTransaction(callFunction, itemContractAddress);

            if (contractTransactionUnityRequest.Exception == null)
            {
                print(contractTransactionUnityRequest.Result);
            }
            else
            {
                print(contractTransactionUnityRequest.Exception.Message);
            }
        }

        // Wait for a short time to check
        print("Waiting " + checkDelay_1 + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_1);

        // Check the last status of the state
        print("Checking the last status!");
        StartCoroutine(ItemBalanceOfCall(id));

        // Then wait one more time but a bit longer to check the last status
        print("Waiting " + checkDelay_2 + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_2);

        // Check the last status one more time
        print("Checking the last status again!");
        StartCoroutine(ItemBalanceOfCall(id));
    }
    private IEnumerator BurnItemsCall(List<BigInteger> ids, List<BigInteger> amounts)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Mint - Items Contract: " + itemContractAddress);

        print("id: " + ids);
        print("Amount: " + amounts);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var callFunction = new Contracts.Contracts.Items.ContractDefinition.BurnBatchFunction
            {
                Account = _selectedAccountAddress,
                Ids = ids,
                Values = amounts
            };

            yield return contractTransactionUnityRequest.
                SignAndSendTransaction(callFunction, itemContractAddress);

            if (contractTransactionUnityRequest.Exception == null)
            {
                print(contractTransactionUnityRequest.Result);
            }
            else
            {
                print(contractTransactionUnityRequest.Exception.Message);
            }
        }
    }
    private IEnumerator ItemMintAllowanceCall()
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Giving Token Allowance to Item Cont - Token Contract: " + tokenContractAddress);
        print("Item Contract: " + itemContractAddress);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var callFunction = new Contracts.Contracts.Token.ContractDefinition.IncreaseAllowanceFunction
            {
                Spender = itemContractAddress,
                AddedValue = ToWei(1000000000)  // 1 billion allowance                
            };

            yield return contractTransactionUnityRequest.
                SignAndSendTransaction(callFunction, tokenContractAddress);

            if (contractTransactionUnityRequest.Exception == null)
            {
                print(contractTransactionUnityRequest.Result);
                chainReader.WriteItemMintAllowance(true);
            }
            else
            {
                print(contractTransactionUnityRequest.Exception.Message);
            }
        }

        // Wait for a short time to check
        print("Waiting " + checkDelay_1 + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_1);

        // Check the last status of the state
        print("Checking the last status!");
        StartCoroutine(ItemMintAllowanceCheckCall());

        // Then wait one more time but a bit longer to check the last status
        print("Waiting " + checkDelay_2 + " seconds to check the last status");
        yield return new WaitForSeconds(checkDelay_2);

        // Check the last status one more time
        print("Checking the last status again!");
        StartCoroutine(ItemMintAllowanceCheckCall());
    }

    // Read
    private IEnumerator ItemBalanceOfCall(BigInteger id)
    {
        print("Wallet: " + _selectedAccountAddress);
        print("Balance Of Batch - Items Contract: " + itemContractAddress);
        print("Item ID: " + id);

        var contractTransactionUnityRequest = GetContractTransactionUnityRequest();

        if (contractTransactionUnityRequest != null)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.Items.ContractDefinition.BalanceOfFunction,
                Contracts.Contracts.Items.ContractDefinition.BalanceOfOutputDTO>(
                GetUnityRpcRequestClientFactory(), _selectedAccountAddress
            );

            yield return queryRequest.Query(new Contracts.Contracts.Items.ContractDefinition
                .BalanceOfFunction()
            {
                Account = _selectedAccountAddress,
                Id = id
            }, itemContractAddress);

            //Getting the dto response already decoded
            var dtoResult = queryRequest.Result;
            int balance = (int)dtoResult.ReturnValue1;

            chainReader.WriteItemBalance((int)id, balance);
            print("Item (ID: " + id + ") Balance :" + balance);
        }
    }
    */


    //******  TOOLS TO USE  ******//
    // Essentials
    public void ConnectWalletButton()
    {
        if (MetamaskInterop.IsMetamaskAvailable())
        {
            MetamaskInterop.EnableEthereum(gameObject.name, nameof(EthereumEnabled), nameof(DisplayError));

            StartCoroutine(AddChain());
        }
        else
        {
            print("Metamask is not available, please install it");
        }
        /**
        if (!checkAllowance(nftContract))
            mintNFTButtonText.text = "Approve";
        else
            mintNFTButtonText.text = "Mint NFT";

        if (!checkAllowance(itemContract))
            mintItemButtonText.text = "Approve";
        else
            mintItemButtonText.text = "Mint Item";
        */
    }
    private IEnumerator AddChain()
    {
        var addRequest = new WalletAddEthereumChainUnityRequest(GetUnityRpcRequestClientFactory());

        var chainParams = new AddEthereumChainParameter
        {
            ChainId = new HexBigInteger("0x66EED"), // In hexadecimal !!
            ChainName = "Arbitrum Goerli Testnet",
            RpcUrls = new List<string> { "https://goerli-rollup.arbitrum.io/rpc" },
            BlockExplorerUrls = new List<string> { "https://goerli.arbiscan.io/" },
            NativeCurrency = new NativeCurrency
            {
                Name = "Ether",
                Symbol = "ETH",
                Decimals = 18
            }
        };

        yield return addRequest.SendRequest(chainParams);
        print("Chain Added! " + addRequest.Result);
    }
    public void EthereumEnabled(string addressSelected)
    {
        if (!_isMetamaskInitialised)
        {
            MetamaskInterop.EthereumInit(gameObject.name, nameof(NewAccountSelected), nameof(ChainChanged));
            MetamaskInterop.GetChainId(gameObject.name, nameof(ChainChanged), nameof(DisplayError));
            _isMetamaskInitialised = true;
        }
        NewAccountSelected(addressSelected);
    }
    private void DisplayError(string errorMessage) { }
    private void NewAccountSelected(string accountAddress)
    {
        print("New Account executed: " + accountAddress);

        _selectedAccountAddress = accountAddress;

        print("Sent!");
    }
    private void ChainChanged(string chainId)
    {
        _currentChainId = new HexBigInteger(chainId).Value;
        try
        {
            //simple workaround to show suported configured chains
            print("Current Chain: " + _currentChainId.ToString());
            StartCoroutine(GetBlockNumber());

            if (_currentChainId != desiredChainID) { print("Adding Chain... "); StartCoroutine(AddChain()); }
        }
        catch (Exception ex)
        {
            DisplayError(ex.Message);
        }
    }
    private IEnumerator GetBlockNumber()
    {
        var blockNumberRequest = new EthBlockNumberUnityRequest(GetUnityRpcRequestClientFactory());
        yield return blockNumberRequest.SendRequest();
        print("Block Number: " + blockNumberRequest.Result.Value);
    }
    public IContractTransactionUnityRequest GetContractTransactionUnityRequest()
    {
        if (MetamaskInterop.IsMetamaskAvailable())
        {
            return new MetamaskTransactionUnityRequest(_selectedAccountAddress, GetUnityRpcRequestClientFactory());
        }
        else
        {
            print("Metamask is not available, please install it");
            return null;
        }
    }
    public IUnityRpcRequestClientFactory GetUnityRpcRequestClientFactory()
    {
        if (MetamaskInterop.IsMetamaskAvailable())
        {
            return new MetamaskRequestRpcClientFactory(_selectedAccountAddress, null, 1000);
        }
        else
        {
            print("Metamask is not available, please install it");
            return null;
        }
    }

    // Getters and Setters
    public string GetConnectedAddress() { return _selectedAccountAddress; }

    // Conversion Tools
    private static BigInteger ToWei(double value) { return (BigInteger)(value * Math.Pow(10, 18)); }
    private static double FromWei(BigInteger value) { return ((double)value / Math.Pow(10, 18)); }

    
}
