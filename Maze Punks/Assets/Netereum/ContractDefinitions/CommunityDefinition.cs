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

namespace Contracts.Contracts.Community.ContractDefinition
{


    public partial class CommunityDeployment : CommunityDeploymentBase
    {
        public CommunityDeployment() : base(BYTECODE) { }
        public CommunityDeployment(string byteCode) : base(byteCode) { }
    }

    public class CommunityDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public CommunityDeploymentBase() : base(BYTECODE) { }
        public CommunityDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address[13]", "_contracts", 1)]
        public virtual List<string> Contracts { get; set; }
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

    public partial class ClaimMerkleRewardFunction : ClaimMerkleRewardFunctionBase { }

    [Function("claimMerkleReward")]
    public class ClaimMerkleRewardFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_proposalID", 1)]
        public virtual BigInteger ProposalID { get; set; }
        [Parameter("bytes32[]", "_merkleProof", 2)]
        public virtual List<byte[]> MerkleProof { get; set; }
    }

    public partial class ClaimRewardFunction : ClaimRewardFunctionBase { }

    [Function("claimReward")]
    public class ClaimRewardFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_proposalID", 1)]
        public virtual BigInteger ProposalID { get; set; }
    }

    public partial class ContractsFunction : ContractsFunctionBase { }

    [Function("contracts", "address")]
    public class ContractsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ExecuteContractAddressUpdateProposalFunction : ExecuteContractAddressUpdateProposalFunctionBase { }

    [Function("executeContractAddressUpdateProposal")]
    public class ExecuteContractAddressUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_proposalID", 1)]
        public virtual BigInteger ProposalID { get; set; }
    }

    public partial class ExecuteExtremeRewardLimitSetProposalFunction : ExecuteExtremeRewardLimitSetProposalFunctionBase { }

    [Function("executeExtremeRewardLimitSetProposal")]
    public class ExecuteExtremeRewardLimitSetProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_proposalID", 1)]
        public virtual BigInteger ProposalID { get; set; }
    }

    public partial class ExecuteFunctionsProposalTypesUpdateProposalFunction : ExecuteFunctionsProposalTypesUpdateProposalFunctionBase { }

    [Function("executeFunctionsProposalTypesUpdateProposal")]
    public class ExecuteFunctionsProposalTypesUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_proposalID", 1)]
        public virtual BigInteger ProposalID { get; set; }
    }

    public partial class ExecuteHighRewarLimitSetProposalFunction : ExecuteHighRewarLimitSetProposalFunctionBase { }

    [Function("executeHighRewarLimitSetProposal")]
    public class ExecuteHighRewarLimitSetProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_proposalID", 1)]
        public virtual BigInteger ProposalID { get; set; }
    }

    public partial class ExtremeRewardLimitFunction : ExtremeRewardLimitFunctionBase { }

    [Function("extremeRewardLimit", "uint256")]
    public class ExtremeRewardLimitFunctionBase : FunctionMessage
    {

    }

    public partial class FunctionsProposalTypesFunction : FunctionsProposalTypesFunctionBase { }

    [Function("functionsProposalTypes", "uint256")]
    public class FunctionsProposalTypesFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class HighRewardLimitFunction : HighRewardLimitFunctionBase { }

    [Function("highRewardLimit", "uint256")]
    public class HighRewardLimitFunctionBase : FunctionMessage
    {

    }

    public partial class IncreaseReceivedBalanceFunction : IncreaseReceivedBalanceFunctionBase { }

    [Function("increaseReceivedBalance")]
    public class IncreaseReceivedBalanceFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class MerkleRewardsFunction : MerkleRewardsFunctionBase { }

    [Function("merkleRewards", typeof(MerkleRewardsOutputDTO))]
    public class MerkleRewardsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ProposalsFunction : ProposalsFunctionBase { }

    [Function("proposals", typeof(ProposalsOutputDTO))]
    public class ProposalsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ProposeContractAddressUpdateFunction : ProposeContractAddressUpdateFunctionBase { }

    [Function("proposeContractAddressUpdate")]
    public class ProposeContractAddressUpdateFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_contractIndex", 1)]
        public virtual BigInteger ContractIndex { get; set; }
        [Parameter("address", "_newAddress", 2)]
        public virtual string NewAddress { get; set; }
    }

    public partial class ProposeExtremeRewardLimitSetFunction : ProposeExtremeRewardLimitSetFunctionBase { }

    [Function("proposeExtremeRewardLimitSet")]
    public class ProposeExtremeRewardLimitSetFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_newLimit", 1)]
        public virtual BigInteger NewLimit { get; set; }
    }

    public partial class ProposeFunctionsProposalTypesUpdateFunction : ProposeFunctionsProposalTypesUpdateFunctionBase { }

    [Function("proposeFunctionsProposalTypesUpdate")]
    public class ProposeFunctionsProposalTypesUpdateFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_functionIndex", 1)]
        public virtual BigInteger FunctionIndex { get; set; }
        [Parameter("uint256", "_newIndex", 2)]
        public virtual BigInteger NewIndex { get; set; }
    }

    public partial class ProposeHighRewarLimitSetFunction : ProposeHighRewarLimitSetFunctionBase { }

    [Function("proposeHighRewarLimitSet")]
    public class ProposeHighRewarLimitSetFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_newLimit", 1)]
        public virtual BigInteger NewLimit { get; set; }
    }

    public partial class ProposeMerkleRewardFunction : ProposeMerkleRewardFunctionBase { }

    [Function("proposeMerkleReward")]
    public class ProposeMerkleRewardFunctionBase : FunctionMessage
    {
        [Parameter("bytes32[]", "_roots", 1)]
        public virtual List<byte[]> Roots { get; set; }
        [Parameter("uint256[]", "_rewards", 2)]
        public virtual List<BigInteger> Rewards { get; set; }
        [Parameter("uint256", "_totalReward", 3)]
        public virtual BigInteger TotalReward { get; set; }
    }

    public partial class ProposeRewardFunction : ProposeRewardFunctionBase { }

    [Function("proposeReward")]
    public class ProposeRewardFunctionBase : FunctionMessage
    {
        [Parameter("address[]", "_receivers", 1)]
        public virtual List<string> Receivers { get; set; }
        [Parameter("uint256[]", "_rewards", 2)]
        public virtual List<BigInteger> Rewards { get; set; }
    }

    public partial class ReceivedBalanceFunction : ReceivedBalanceFunctionBase { }

    [Function("receivedBalance", "uint256")]
    public class ReceivedBalanceFunctionBase : FunctionMessage
    {

    }

    public partial class ReservedBalanceFunction : ReservedBalanceFunctionBase { }

    [Function("reservedBalance", "uint256")]
    public class ReservedBalanceFunctionBase : FunctionMessage
    {

    }

    public partial class RewardsFunction : RewardsFunctionBase { }

    [Function("rewards", typeof(RewardsOutputDTO))]
    public class RewardsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class UpdateRewardStatusFunction : UpdateRewardStatusFunctionBase { }

    [Function("updateRewardStatus")]
    public class UpdateRewardStatusFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_proposalID", 1)]
        public virtual BigInteger ProposalID { get; set; }
    }









    public partial class ContractsOutputDTO : ContractsOutputDTOBase { }

    [FunctionOutput]
    public class ContractsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }









    public partial class ExtremeRewardLimitOutputDTO : ExtremeRewardLimitOutputDTOBase { }

    [FunctionOutput]
    public class ExtremeRewardLimitOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class FunctionsProposalTypesOutputDTO : FunctionsProposalTypesOutputDTOBase { }

    [FunctionOutput]
    public class FunctionsProposalTypesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class HighRewardLimitOutputDTO : HighRewardLimitOutputDTOBase { }

    [FunctionOutput]
    public class HighRewardLimitOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class MerkleRewardsOutputDTO : MerkleRewardsOutputDTOBase { }

    [FunctionOutput]
    public class MerkleRewardsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "approved", 1)]
        public virtual bool Approved { get; set; }
        [Parameter("uint256", "totalReward", 2)]
        public virtual BigInteger TotalReward { get; set; }
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













    public partial class ReceivedBalanceOutputDTO : ReceivedBalanceOutputDTOBase { }

    [FunctionOutput]
    public class ReceivedBalanceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ReservedBalanceOutputDTO : ReservedBalanceOutputDTOBase { }

    [FunctionOutput]
    public class ReservedBalanceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class RewardsOutputDTO : RewardsOutputDTOBase { }

    [FunctionOutput]
    public class RewardsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "approved", 1)]
        public virtual bool Approved { get; set; }
        [Parameter("uint256", "totalReward", 2)]
        public virtual BigInteger TotalReward { get; set; }
    }


}
