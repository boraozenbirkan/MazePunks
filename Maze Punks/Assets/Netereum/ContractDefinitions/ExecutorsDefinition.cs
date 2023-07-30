using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Contracts.Contracts.Executors.ContractDefinition
{


    public partial class ExecutorsDeployment : ExecutorsDeploymentBase
    {
        public ExecutorsDeployment() : base(BYTECODE) { }
        public ExecutorsDeployment(string byteCode) : base(byteCode) { }
    }

    public class ExecutorsDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public ExecutorsDeploymentBase() : base(BYTECODE) { }
        public ExecutorsDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class DEBUG_setContractFunction : DEBUG_setContractFunctionBase { }

    [Function("DEBUG_setContract")]
    public class DEBUG_setContractFunctionBase : FunctionMessage
    {
        [Parameter("address", "_contractAddress", 1)]
        public virtual string ContractAddress { get; set; }
        [Parameter("uint256", "_index", 2)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class DEBUG_setContractsFunction : DEBUG_setContractsFunctionBase { }

    [Function("DEBUG_setContracts")]
    public class DEBUG_setContractsFunctionBase : FunctionMessage
    {
        [Parameter("address[13]", "_contracts", 1)]
        public virtual List<string> Contracts { get; set; }
    }

    public partial class DEFAULT_ADMIN_ROLEFunction : DEFAULT_ADMIN_ROLEFunctionBase { }

    [Function("DEFAULT_ADMIN_ROLE", "bytes32")]
    public class DEFAULT_ADMIN_ROLEFunctionBase : FunctionMessage
    {

    }

    public partial class EXECUTOR_ROLEFunction : EXECUTOR_ROLEFunctionBase { }

    [Function("EXECUTOR_ROLE", "bytes32")]
    public class EXECUTOR_ROLEFunctionBase : FunctionMessage
    {

    }

    public partial class ContractsFunction : ContractsFunctionBase { }

    [Function("contracts", "address")]
    public class ContractsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class CreateBossMintCostUpdateProposalFunction : CreateBossMintCostUpdateProposalFunctionBase { }

    [Function("createBossMintCostUpdateProposal")]
    public class CreateBossMintCostUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_newCost", 1)]
        public virtual BigInteger NewCost { get; set; }
    }

    public partial class CreateClanCooldownTimeUpdateProposalFunction : CreateClanCooldownTimeUpdateProposalFunctionBase { }

    [Function("createClanCooldownTimeUpdateProposal")]
    public class CreateClanCooldownTimeUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_newCoolDownTime", 1)]
        public virtual BigInteger NewCoolDownTime { get; set; }
    }

    public partial class CreateClanGiveBatchClanPointsFunction : CreateClanGiveBatchClanPointsFunctionBase { }

    [Function("createClanGiveBatchClanPoints")]
    public class CreateClanGiveBatchClanPointsFunctionBase : FunctionMessage
    {
        [Parameter("uint256[]", "_clanIDs", 1)]
        public virtual List<BigInteger> ClanIDs { get; set; }
        [Parameter("uint256[]", "_points", 2)]
        public virtual List<BigInteger> Points { get; set; }
        [Parameter("bool[]", "_isDecreasing", 3)]
        public virtual List<bool> IsDecreasing { get; set; }
    }

    public partial class CreateClanGiveClanPointFunction : CreateClanGiveClanPointFunctionBase { }

    [Function("createClanGiveClanPoint")]
    public class CreateClanGiveClanPointFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_clanID", 1)]
        public virtual BigInteger ClanID { get; set; }
        [Parameter("uint256", "_point", 2)]
        public virtual BigInteger Point { get; set; }
        [Parameter("bool", "_isDecreasing", 3)]
        public virtual bool IsDecreasing { get; set; }
    }

    public partial class CreateClanLicenseMintCostUpdateProposalFunction : CreateClanLicenseMintCostUpdateProposalFunctionBase { }

    [Function("createClanLicenseMintCostUpdateProposal")]
    public class CreateClanLicenseMintCostUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_newCost", 1)]
        public virtual BigInteger NewCost { get; set; }
    }

    public partial class CreateClanMaxPointToChangeUpdateProposalFunction : CreateClanMaxPointToChangeUpdateProposalFunctionBase { }

    [Function("createClanMaxPointToChangeUpdateProposal")]
    public class CreateClanMaxPointToChangeUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_newMaxPoint", 1)]
        public virtual BigInteger NewMaxPoint { get; set; }
    }

    public partial class CreateClanMinBalanceToPropClanPointUpdateProposalFunction : CreateClanMinBalanceToPropClanPointUpdateProposalFunctionBase { }

    [Function("createClanMinBalanceToPropClanPointUpdateProposal")]
    public class CreateClanMinBalanceToPropClanPointUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_newAmount", 1)]
        public virtual BigInteger NewAmount { get; set; }
    }

    public partial class CreateCommunityExtremeRewardLimitSetProposalFunction : CreateCommunityExtremeRewardLimitSetProposalFunctionBase { }

    [Function("createCommunityExtremeRewardLimitSetProposal")]
    public class CreateCommunityExtremeRewardLimitSetProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_newLimit", 1)]
        public virtual BigInteger NewLimit { get; set; }
    }

    public partial class CreateCommunityHighRewarLimitSetProposalFunction : CreateCommunityHighRewarLimitSetProposalFunctionBase { }

    [Function("createCommunityHighRewarLimitSetProposal")]
    public class CreateCommunityHighRewarLimitSetProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_newLimit", 1)]
        public virtual BigInteger NewLimit { get; set; }
    }

    public partial class CreateCommunityMerkleRewardProposalFunction : CreateCommunityMerkleRewardProposalFunctionBase { }

    [Function("createCommunityMerkleRewardProposal")]
    public class CreateCommunityMerkleRewardProposalFunctionBase : FunctionMessage
    {
        [Parameter("bytes32[]", "_roots", 1)]
        public virtual List<byte[]> Roots { get; set; }
        [Parameter("uint256[]", "_rewards", 2)]
        public virtual List<BigInteger> Rewards { get; set; }
        [Parameter("uint256", "_totalReward", 3)]
        public virtual BigInteger TotalReward { get; set; }
    }

    public partial class CreateCommunityRewardProposalFunction : CreateCommunityRewardProposalFunctionBase { }

    [Function("createCommunityRewardProposal")]
    public class CreateCommunityRewardProposalFunctionBase : FunctionMessage
    {
        [Parameter("address[]", "_receivers", 1)]
        public virtual List<string> Receivers { get; set; }
        [Parameter("uint256[]", "_rewards", 2)]
        public virtual List<BigInteger> Rewards { get; set; }
    }

    public partial class CreateContractAddressUpdateProposalFunction : CreateContractAddressUpdateProposalFunctionBase { }

    [Function("createContractAddressUpdateProposal")]
    public class CreateContractAddressUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_contractIndex", 1)]
        public virtual BigInteger ContractIndex { get; set; }
        [Parameter("uint256", "_subjectIndex", 2)]
        public virtual BigInteger SubjectIndex { get; set; }
        [Parameter("address", "_newAddress", 3)]
        public virtual string NewAddress { get; set; }
    }

    public partial class CreateDAOMinBalanceToPropUpdateProposalFunction : CreateDAOMinBalanceToPropUpdateProposalFunctionBase { }

    [Function("createDAOMinBalanceToPropUpdateProposal")]
    public class CreateDAOMinBalanceToPropUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_newAmount", 1)]
        public virtual BigInteger NewAmount { get; set; }
    }

    public partial class CreateDAONewCoinSpendingProposalFunction : CreateDAONewCoinSpendingProposalFunctionBase { }

    [Function("createDAONewCoinSpendingProposal")]
    public class CreateDAONewCoinSpendingProposalFunctionBase : FunctionMessage
    {
        [Parameter("bytes32[]", "_merkleRoots", 1)]
        public virtual List<byte[]> MerkleRoots { get; set; }
        [Parameter("uint256[]", "_allowances", 2)]
        public virtual List<BigInteger> Allowances { get; set; }
        [Parameter("uint256", "_totalSpending", 3)]
        public virtual BigInteger TotalSpending { get; set; }
    }

    public partial class CreateDAONewProposalTypeProposalFunction : CreateDAONewProposalTypeProposalFunctionBase { }

    [Function("createDAONewProposalTypeProposal")]
    public class CreateDAONewProposalTypeProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_length", 1)]
        public virtual BigInteger Length { get; set; }
        [Parameter("uint256", "_requiredApprovalRate", 2)]
        public virtual BigInteger RequiredApprovalRate { get; set; }
        [Parameter("uint256", "_requiredTokenAmount", 3)]
        public virtual BigInteger RequiredTokenAmount { get; set; }
        [Parameter("uint256", "_requiredParticipantAmount", 4)]
        public virtual BigInteger RequiredParticipantAmount { get; set; }
    }

    public partial class CreateDAONewTokenSpendingProposalFunction : CreateDAONewTokenSpendingProposalFunctionBase { }

    [Function("createDAONewTokenSpendingProposal")]
    public class CreateDAONewTokenSpendingProposalFunctionBase : FunctionMessage
    {
        [Parameter("address", "_tokenContractAddress", 1)]
        public virtual string TokenContractAddress { get; set; }
        [Parameter("bytes32[]", "_merkleRoots", 2)]
        public virtual List<byte[]> MerkleRoots { get; set; }
        [Parameter("uint256[]", "_allowances", 3)]
        public virtual List<BigInteger> Allowances { get; set; }
        [Parameter("uint256", "_totalSpending", 4)]
        public virtual BigInteger TotalSpending { get; set; }
    }

    public partial class CreateDAOProposalTypeUpdateProposalFunction : CreateDAOProposalTypeUpdateProposalFunctionBase { }

    [Function("createDAOProposalTypeUpdateProposal")]
    public class CreateDAOProposalTypeUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_proposalTypeNumber", 1)]
        public virtual BigInteger ProposalTypeNumber { get; set; }
        [Parameter("uint256", "_newLength", 2)]
        public virtual BigInteger NewLength { get; set; }
        [Parameter("uint256", "_newRequiredApprovalRate", 3)]
        public virtual BigInteger NewRequiredApprovalRate { get; set; }
        [Parameter("uint256", "_newRequiredTokenAmount", 4)]
        public virtual BigInteger NewRequiredTokenAmount { get; set; }
        [Parameter("uint256", "_newRequiredParticipantAmount", 5)]
        public virtual BigInteger NewRequiredParticipantAmount { get; set; }
    }

    public partial class CreateFunctionsProposalTypesUpdateProposalFunction : CreateFunctionsProposalTypesUpdateProposalFunctionBase { }

    [Function("createFunctionsProposalTypesUpdateProposal")]
    public class CreateFunctionsProposalTypesUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_contractIndex", 1)]
        public virtual BigInteger ContractIndex { get; set; }
        [Parameter("uint256", "_subjectIndex", 2)]
        public virtual BigInteger SubjectIndex { get; set; }
        [Parameter("uint256", "_newIndex", 3)]
        public virtual BigInteger NewIndex { get; set; }
    }

    public partial class CreateItemActivationUpdateProposalFunction : CreateItemActivationUpdateProposalFunctionBase { }

    [Function("createItemActivationUpdateProposal")]
    public class CreateItemActivationUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_itemID", 1)]
        public virtual BigInteger ItemID { get; set; }
        [Parameter("bool", "_activationStatus", 2)]
        public virtual bool ActivationStatus { get; set; }
    }

    public partial class CreateItemSetNewTokenURIFunction : CreateItemSetNewTokenURIFunctionBase { }

    [Function("createItemSetNewTokenURI")]
    public class CreateItemSetNewTokenURIFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_tokenID", 1)]
        public virtual BigInteger TokenID { get; set; }
        [Parameter("string", "_newURI", 2)]
        public virtual string NewURI { get; set; }
    }

    public partial class CreateItemsMintCostUpdateProposalFunction : CreateItemsMintCostUpdateProposalFunctionBase { }

    [Function("createItemsMintCostUpdateProposal")]
    public class CreateItemsMintCostUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_itemID", 1)]
        public virtual BigInteger ItemID { get; set; }
        [Parameter("uint256", "_newCost", 2)]
        public virtual BigInteger NewCost { get; set; }
    }

    public partial class CreateLordBaseTaxRateUpdateProposalFunction : CreateLordBaseTaxRateUpdateProposalFunctionBase { }

    [Function("createLordBaseTaxRateUpdateProposal")]
    public class CreateLordBaseTaxRateUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_newBaseTaxRate", 1)]
        public virtual BigInteger NewBaseTaxRate { get; set; }
    }

    public partial class CreateLordRebellionLengthUpdateProposalFunction : CreateLordRebellionLengthUpdateProposalFunctionBase { }

    [Function("createLordRebellionLengthUpdateProposal")]
    public class CreateLordRebellionLengthUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_newRebellionLength", 1)]
        public virtual BigInteger NewRebellionLength { get; set; }
    }

    public partial class CreateLordSetBaseURIFunction : CreateLordSetBaseURIFunctionBase { }

    [Function("createLordSetBaseURI")]
    public class CreateLordSetBaseURIFunctionBase : FunctionMessage
    {
        [Parameter("string", "_newURI", 1)]
        public virtual string NewURI { get; set; }
    }

    public partial class CreateLordSignalLengthUpdateProposalFunction : CreateLordSignalLengthUpdateProposalFunctionBase { }

    [Function("createLordSignalLengthUpdateProposal")]
    public class CreateLordSignalLengthUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_newSignalLength", 1)]
        public virtual BigInteger NewSignalLength { get; set; }
    }

    public partial class CreateLordTaxChangeRateUpdateProposalFunction : CreateLordTaxChangeRateUpdateProposalFunctionBase { }

    [Function("createLordTaxChangeRateUpdateProposal")]
    public class CreateLordTaxChangeRateUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_newTaxChangeRate", 1)]
        public virtual BigInteger NewTaxChangeRate { get; set; }
    }

    public partial class CreateLordVictoryRateUpdateProposalFunction : CreateLordVictoryRateUpdateProposalFunctionBase { }

    [Function("createLordVictoryRateUpdateProposal")]
    public class CreateLordVictoryRateUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_newVictoryRate", 1)]
        public virtual BigInteger NewVictoryRate { get; set; }
    }

    public partial class CreateLordWarLordCasualtyRateUpdateProposalFunction : CreateLordWarLordCasualtyRateUpdateProposalFunctionBase { }

    [Function("createLordWarLordCasualtyRateUpdateProposal")]
    public class CreateLordWarLordCasualtyRateUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_newWarCasualtyRate", 1)]
        public virtual BigInteger NewWarCasualtyRate { get; set; }
    }

    public partial class CreateRoundSetPlayerRootAndNumberFunction : CreateRoundSetPlayerRootAndNumberFunctionBase { }

    [Function("createRoundSetPlayerRootAndNumber")]
    public class CreateRoundSetPlayerRootAndNumberFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_round", 1)]
        public virtual BigInteger Round { get; set; }
        [Parameter("uint256", "_level", 2)]
        public virtual BigInteger Level { get; set; }
        [Parameter("bytes32", "_root", 3)]
        public virtual byte[] Root { get; set; }
        [Parameter("uint256", "_playerNumber", 4)]
        public virtual BigInteger PlayerNumber { get; set; }
    }

    public partial class CreateRoundUpdateLevelRewardRatesFunction : CreateRoundUpdateLevelRewardRatesFunctionBase { }

    [Function("createRoundUpdateLevelRewardRates")]
    public class CreateRoundUpdateLevelRewardRatesFunctionBase : FunctionMessage
    {
        [Parameter("uint256[10]", "_newLevelWeights", 1)]
        public virtual List<BigInteger> NewLevelWeights { get; set; }
        [Parameter("uint256", "_newTotalWeight", 2)]
        public virtual BigInteger NewTotalWeight { get; set; }
    }

    public partial class CreateTokenCommunityMintFunction : CreateTokenCommunityMintFunctionBase { }

    [Function("createTokenCommunityMint")]
    public class CreateTokenCommunityMintFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class CreateTokenDAOMintFunction : CreateTokenDAOMintFunctionBase { }

    [Function("createTokenDAOMint")]
    public class CreateTokenDAOMintFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class CreateTokenDevelopmentMintFunction : CreateTokenDevelopmentMintFunctionBase { }

    [Function("createTokenDevelopmentMint")]
    public class CreateTokenDevelopmentMintFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class CreateTokenMintPerSecondUpdateProposalFunction : CreateTokenMintPerSecondUpdateProposalFunctionBase { }

    [Function("createTokenMintPerSecondUpdateProposal")]
    public class CreateTokenMintPerSecondUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_mintIndex", 1)]
        public virtual BigInteger MintIndex { get; set; }
        [Parameter("uint256", "_newMintPerSecond", 2)]
        public virtual BigInteger NewMintPerSecond { get; set; }
    }

    public partial class CreateTokenPauseFunction : CreateTokenPauseFunctionBase { }

    [Function("createTokenPause")]
    public class CreateTokenPauseFunctionBase : FunctionMessage
    {
        [Parameter("bool", "_pauseToken", 1)]
        public virtual bool PauseToken { get; set; }
    }

    public partial class CreateTokenSnapshotFunction : CreateTokenSnapshotFunctionBase { }

    [Function("createTokenSnapshot")]
    public class CreateTokenSnapshotFunctionBase : FunctionMessage
    {

    }

    public partial class CreateTokenStakingMintFunction : CreateTokenStakingMintFunctionBase { }

    [Function("createTokenStakingMint")]
    public class CreateTokenStakingMintFunctionBase : FunctionMessage
    {

    }

    public partial class ExecuteFunctionsProposalTypesUpdateProposalFunction : ExecuteFunctionsProposalTypesUpdateProposalFunctionBase { }

    [Function("executeFunctionsProposalTypesUpdateProposal")]
    public class ExecuteFunctionsProposalTypesUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_proposalID", 1)]
        public virtual BigInteger ProposalID { get; set; }
    }

    public partial class ExecuteRoleProposalFunction : ExecuteRoleProposalFunctionBase { }

    [Function("executeRoleProposal")]
    public class ExecuteRoleProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_proposalID", 1)]
        public virtual BigInteger ProposalID { get; set; }
    }

    public partial class ExecutorProposalTypeIndexFunction : ExecutorProposalTypeIndexFunctionBase { }

    [Function("executorProposalTypeIndex", "uint256")]
    public class ExecutorProposalTypeIndexFunctionBase : FunctionMessage
    {

    }

    public partial class GetRoleAdminFunction : GetRoleAdminFunctionBase { }

    [Function("getRoleAdmin", "bytes32")]
    public class GetRoleAdminFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "role", 1)]
        public virtual byte[] Role { get; set; }
    }

    public partial class GetSignalTimingFunction : GetSignalTimingFunctionBase { }

    [Function("getSignalTiming", "uint256")]
    public class GetSignalTimingFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_signalIndex", 1)]
        public virtual BigInteger SignalIndex { get; set; }
    }

    public partial class GrantRoleFunction : GrantRoleFunctionBase { }

    [Function("grantRole")]
    public class GrantRoleFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "role", 1)]
        public virtual byte[] Role { get; set; }
        [Parameter("address", "account", 2)]
        public virtual string Account { get; set; }
    }

    public partial class HasRoleFunction : HasRoleFunctionBase { }

    [Function("hasRole", "bool")]
    public class HasRoleFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "role", 1)]
        public virtual byte[] Role { get; set; }
        [Parameter("address", "account", 2)]
        public virtual string Account { get; set; }
    }

    public partial class IsExecutorFunction : IsExecutorFunctionBase { }

    [Function("isExecutor", "bool")]
    public class IsExecutorFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class NumOfExecutorsFunction : NumOfExecutorsFunctionBase { }

    [Function("numOfExecutors", "uint256")]
    public class NumOfExecutorsFunctionBase : FunctionMessage
    {

    }

    public partial class ProposalsFunction : ProposalsFunctionBase { }

    [Function("proposals", typeof(ProposalsOutputDTO))]
    public class ProposalsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ProposeExecutorRoleFunction : ProposeExecutorRoleFunctionBase { }

    [Function("proposeExecutorRole")]
    public class ProposeExecutorRoleFunctionBase : FunctionMessage
    {
        [Parameter("address", "_address", 1)]
        public virtual string Address { get; set; }
        [Parameter("bool", "_isAssigning", 2)]
        public virtual bool IsAssigning { get; set; }
    }

    public partial class ProposeFunctionsProposalTypesUpdateFunction : ProposeFunctionsProposalTypesUpdateFunctionBase { }

    [Function("proposeFunctionsProposalTypesUpdate")]
    public class ProposeFunctionsProposalTypesUpdateFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_newIndex", 1)]
        public virtual BigInteger NewIndex { get; set; }
    }

    public partial class RenounceRoleFunction : RenounceRoleFunctionBase { }

    [Function("renounceRole")]
    public class RenounceRoleFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "role", 1)]
        public virtual byte[] Role { get; set; }
        [Parameter("address", "account", 2)]
        public virtual string Account { get; set; }
    }

    public partial class RevokeRoleFunction : RevokeRoleFunctionBase { }

    [Function("revokeRole")]
    public class RevokeRoleFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "role", 1)]
        public virtual byte[] Role { get; set; }
        [Parameter("address", "account", 2)]
        public virtual string Account { get; set; }
    }

    public partial class SignalTimeFunction : SignalTimeFunctionBase { }

    [Function("signalTime", "uint256")]
    public class SignalTimeFunctionBase : FunctionMessage
    {

    }

    public partial class SignalTrackerIDFunction : SignalTrackerIDFunctionBase { }

    [Function("signalTrackerID", "uint256")]
    public class SignalTrackerIDFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class SignalsFunction : SignalsFunctionBase { }

    [Function("signals", typeof(SignalsOutputDTO))]
    public class SignalsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class SupportsInterfaceFunction : SupportsInterfaceFunctionBase { }

    [Function("supportsInterface", "bool")]
    public class SupportsInterfaceFunctionBase : FunctionMessage
    {
        [Parameter("bytes4", "interfaceId", 1)]
        public virtual byte[] InterfaceId { get; set; }
    }

    public partial class UpdateContractAddressFunction : UpdateContractAddressFunctionBase { }

    [Function("updateContractAddress")]
    public class UpdateContractAddressFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_contractIndex", 1)]
        public virtual BigInteger ContractIndex { get; set; }
        [Parameter("address", "_newAddress", 2)]
        public virtual string NewAddress { get; set; }
    }

    public partial class RoleAdminChangedEventDTO : RoleAdminChangedEventDTOBase { }

    [Event("RoleAdminChanged")]
    public class RoleAdminChangedEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "role", 1, true )]
        public virtual byte[] Role { get; set; }
        [Parameter("bytes32", "previousAdminRole", 2, true )]
        public virtual byte[] PreviousAdminRole { get; set; }
        [Parameter("bytes32", "newAdminRole", 3, true )]
        public virtual byte[] NewAdminRole { get; set; }
    }

    public partial class RoleGrantedEventDTO : RoleGrantedEventDTOBase { }

    [Event("RoleGranted")]
    public class RoleGrantedEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "role", 1, true )]
        public virtual byte[] Role { get; set; }
        [Parameter("address", "account", 2, true )]
        public virtual string Account { get; set; }
        [Parameter("address", "sender", 3, true )]
        public virtual string Sender { get; set; }
    }

    public partial class RoleRevokedEventDTO : RoleRevokedEventDTOBase { }

    [Event("RoleRevoked")]
    public class RoleRevokedEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "role", 1, true )]
        public virtual byte[] Role { get; set; }
        [Parameter("address", "account", 2, true )]
        public virtual string Account { get; set; }
        [Parameter("address", "sender", 3, true )]
        public virtual string Sender { get; set; }
    }





    public partial class DEFAULT_ADMIN_ROLEOutputDTO : DEFAULT_ADMIN_ROLEOutputDTOBase { }

    [FunctionOutput]
    public class DEFAULT_ADMIN_ROLEOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class EXECUTOR_ROLEOutputDTO : EXECUTOR_ROLEOutputDTOBase { }

    [FunctionOutput]
    public class EXECUTOR_ROLEOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class ContractsOutputDTO : ContractsOutputDTOBase { }

    [FunctionOutput]
    public class ContractsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }















































































    public partial class ExecutorProposalTypeIndexOutputDTO : ExecutorProposalTypeIndexOutputDTOBase { }

    [FunctionOutput]
    public class ExecutorProposalTypeIndexOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetRoleAdminOutputDTO : GetRoleAdminOutputDTOBase { }

    [FunctionOutput]
    public class GetRoleAdminOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class GetSignalTimingOutputDTO : GetSignalTimingOutputDTOBase { }

    [FunctionOutput]
    public class GetSignalTimingOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class HasRoleOutputDTO : HasRoleOutputDTOBase { }

    [FunctionOutput]
    public class HasRoleOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class IsExecutorOutputDTO : IsExecutorOutputDTOBase { }

    [FunctionOutput]
    public class IsExecutorOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class NumOfExecutorsOutputDTO : NumOfExecutorsOutputDTOBase { }

    [FunctionOutput]
    public class NumOfExecutorsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ProposalsOutputDTO : ProposalsOutputDTOBase { }

    [FunctionOutput]
    public class ProposalsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "status", 1)]
        public virtual byte Status { get; set; }
        [Parameter("uint256", "updateCode", 2)]
        public virtual BigInteger UpdateCode { get; set; }
        [Parameter("bool", "isExecuted", 3)]
        public virtual bool IsExecuted { get; set; }
        [Parameter("uint256", "index", 4)]
        public virtual BigInteger Index { get; set; }
        [Parameter("uint256", "newUint", 5)]
        public virtual BigInteger NewUint { get; set; }
        [Parameter("address", "newAddress", 6)]
        public virtual string NewAddress { get; set; }
        [Parameter("bytes32", "newBytes32", 7)]
        public virtual byte[] NewBytes32 { get; set; }
        [Parameter("bool", "newBool", 8)]
        public virtual bool NewBool { get; set; }
    }









    public partial class SignalTimeOutputDTO : SignalTimeOutputDTOBase { }

    [FunctionOutput]
    public class SignalTimeOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class SignalTrackerIDOutputDTO : SignalTrackerIDOutputDTOBase { }

    [FunctionOutput]
    public class SignalTrackerIDOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class SignalsOutputDTO : SignalsOutputDTOBase { }

    [FunctionOutput]
    public class SignalsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "expires", 1)]
        public virtual BigInteger Expires { get; set; }
        [Parameter("uint256", "signalTrackerID", 2)]
        public virtual BigInteger SignalTrackerID { get; set; }
        [Parameter("uint256", "numOfSignals", 3)]
        public virtual BigInteger NumOfSignals { get; set; }
        [Parameter("uint256", "contractIndex", 4)]
        public virtual BigInteger ContractIndex { get; set; }
        [Parameter("uint256", "subjectIndex", 5)]
        public virtual BigInteger SubjectIndex { get; set; }
        [Parameter("bytes32", "propBytes32", 6)]
        public virtual byte[] PropBytes32 { get; set; }
        [Parameter("string", "propString", 7)]
        public virtual string PropString { get; set; }
        [Parameter("bool", "propBool", 8)]
        public virtual bool PropBool { get; set; }
        [Parameter("address", "propAddress", 9)]
        public virtual string PropAddress { get; set; }
        [Parameter("uint256", "propUint", 10)]
        public virtual BigInteger PropUint { get; set; }
        [Parameter("uint256", "propUint1", 11)]
        public virtual BigInteger PropUint1 { get; set; }
        [Parameter("uint256", "propUint2", 12)]
        public virtual BigInteger PropUint2 { get; set; }
        [Parameter("uint256", "propUint3", 13)]
        public virtual BigInteger PropUint3 { get; set; }
        [Parameter("uint256", "propUint4", 14)]
        public virtual BigInteger PropUint4 { get; set; }
    }

    public partial class SupportsInterfaceOutputDTO : SupportsInterfaceOutputDTOBase { }

    [FunctionOutput]
    public class SupportsInterfaceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }


}
