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

namespace Contracts.Contracts.Boss.ContractDefinition
{


    public partial class BossDeployment : BossDeploymentBase
    {
        public BossDeployment() : base(BYTECODE) { }
        public BossDeployment(string byteCode) : base(byteCode) { }
    }

    public class BossDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public BossDeploymentBase() : base(BYTECODE) { }
        public BossDeploymentBase(string byteCode) : base(byteCode) { }
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

    public partial class ApproveFunction : ApproveFunctionBase { }

    [Function("approve")]
    public class ApproveFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "tokenId", 2)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
    }

    public partial class BossRektFunction : BossRektFunctionBase { }

    [Function("bossRekt")]
    public class BossRektFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_tokenID", 1)]
        public virtual BigInteger TokenID { get; set; }
    }

    public partial class BurnFunction : BurnFunctionBase { }

    [Function("burn")]
    public class BurnFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
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

    public partial class ExecuteFunctionsProposalTypesUpdateProposalFunction : ExecuteFunctionsProposalTypesUpdateProposalFunctionBase { }

    [Function("executeFunctionsProposalTypesUpdateProposal")]
    public class ExecuteFunctionsProposalTypesUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_proposalID", 1)]
        public virtual BigInteger ProposalID { get; set; }
    }

    public partial class ExecuteMintCostProposalFunction : ExecuteMintCostProposalFunctionBase { }

    [Function("executeMintCostProposal")]
    public class ExecuteMintCostProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_proposalID", 1)]
        public virtual BigInteger ProposalID { get; set; }
    }

    public partial class FunctionsProposalTypesFunction : FunctionsProposalTypesFunctionBase { }

    [Function("functionsProposalTypes", "uint256")]
    public class FunctionsProposalTypesFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetApprovedFunction : GetApprovedFunctionBase { }

    [Function("getApproved", "address")]
    public class GetApprovedFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class IsApprovedForAllFunction : IsApprovedForAllFunctionBase { }

    [Function("isApprovedForAll", "bool")]
    public class IsApprovedForAllFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("address", "operator", 2)]
        public virtual string Operator { get; set; }
    }

    public partial class MintCostFunction : MintCostFunctionBase { }

    [Function("mintCost", "uint256")]
    public class MintCostFunctionBase : FunctionMessage
    {

    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
    {

    }

    public partial class NumOfRektFunction : NumOfRektFunctionBase { }

    [Function("numOfRekt", "uint256")]
    public class NumOfRektFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class OwnerOfFunction : OwnerOfFunctionBase { }

    [Function("ownerOf", "address")]
    public class OwnerOfFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
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

    public partial class ProposeFunctionsProposalTypesUpdateFunction : ProposeFunctionsProposalTypesUpdateFunctionBase { }

    [Function("proposeFunctionsProposalTypesUpdate")]
    public class ProposeFunctionsProposalTypesUpdateFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_functionIndex", 1)]
        public virtual BigInteger FunctionIndex { get; set; }
        [Parameter("uint256", "_newIndex", 2)]
        public virtual BigInteger NewIndex { get; set; }
    }

    public partial class ProposeMintCostUpdateFunction : ProposeMintCostUpdateFunctionBase { }

    [Function("proposeMintCostUpdate")]
    public class ProposeMintCostUpdateFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_newCost", 1)]
        public virtual BigInteger NewCost { get; set; }
    }

    public partial class SafeMintFunction : SafeMintFunctionBase { }

    [Function("safeMint")]
    public class SafeMintFunctionBase : FunctionMessage
    {
        [Parameter("address", "to", 1)]
        public virtual string To { get; set; }
        [Parameter("string", "uri", 2)]
        public virtual string Uri { get; set; }
    }

    public partial class SafeTransferFromFunction : SafeTransferFromFunctionBase { }

    [Function("safeTransferFrom")]
    public class SafeTransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class SafeTransferFrom1Function : SafeTransferFrom1FunctionBase { }

    [Function("safeTransferFrom")]
    public class SafeTransferFrom1FunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("bytes", "data", 4)]
        public virtual byte[] Data { get; set; }
    }

    public partial class SetApprovalForAllFunction : SetApprovalForAllFunctionBase { }

    [Function("setApprovalForAll")]
    public class SetApprovalForAllFunctionBase : FunctionMessage
    {
        [Parameter("address", "operator", 1)]
        public virtual string Operator { get; set; }
        [Parameter("bool", "approved", 2)]
        public virtual bool Approved { get; set; }
    }

    public partial class SetTokenURIFunction : SetTokenURIFunctionBase { }

    [Function("setTokenURI")]
    public class SetTokenURIFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("string", "_tokenURI", 2)]
        public virtual string TokenURI { get; set; }
    }

    public partial class SupportsInterfaceFunction : SupportsInterfaceFunctionBase { }

    [Function("supportsInterface", "bool")]
    public class SupportsInterfaceFunctionBase : FunctionMessage
    {
        [Parameter("bytes4", "interfaceId", 1)]
        public virtual byte[] InterfaceId { get; set; }
    }

    public partial class SymbolFunction : SymbolFunctionBase { }

    [Function("symbol", "string")]
    public class SymbolFunctionBase : FunctionMessage
    {

    }

    public partial class TokenURIFunction : TokenURIFunctionBase { }

    [Function("tokenURI", "string")]
    public class TokenURIFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class TotalSupplyFunction : TotalSupplyFunctionBase { }

    [Function("totalSupply", "uint256")]
    public class TotalSupplyFunctionBase : FunctionMessage
    {

    }

    public partial class TransferFromFunction : TransferFromFunctionBase { }

    [Function("transferFrom")]
    public class TransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

    [Event("Approval")]
    public class ApprovalEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "approved", 2, true )]
        public virtual string Approved { get; set; }
        [Parameter("uint256", "tokenId", 3, true )]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class ApprovalForAllEventDTO : ApprovalForAllEventDTOBase { }

    [Event("ApprovalForAll")]
    public class ApprovalForAllEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "operator", 2, true )]
        public virtual string Operator { get; set; }
        [Parameter("bool", "approved", 3, false )]
        public virtual bool Approved { get; set; }
    }

    public partial class TransferEventDTO : TransferEventDTOBase { }

    [Event("Transfer")]
    public class TransferEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, true )]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3, true )]
        public virtual BigInteger TokenId { get; set; }
    }







    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }





    public partial class ContractsOutputDTO : ContractsOutputDTOBase { }

    [FunctionOutput]
    public class ContractsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }







    public partial class FunctionsProposalTypesOutputDTO : FunctionsProposalTypesOutputDTOBase { }

    [FunctionOutput]
    public class FunctionsProposalTypesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetApprovedOutputDTO : GetApprovedOutputDTOBase { }

    [FunctionOutput]
    public class GetApprovedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class IsApprovedForAllOutputDTO : IsApprovedForAllOutputDTOBase { }

    [FunctionOutput]
    public class IsApprovedForAllOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class MintCostOutputDTO : MintCostOutputDTOBase { }

    [FunctionOutput]
    public class MintCostOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class NumOfRektOutputDTO : NumOfRektOutputDTOBase { }

    [FunctionOutput]
    public class NumOfRektOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class OwnerOfOutputDTO : OwnerOfOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
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

















    public partial class SupportsInterfaceOutputDTO : SupportsInterfaceOutputDTOBase { }

    [FunctionOutput]
    public class SupportsInterfaceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class SymbolOutputDTO : SymbolOutputDTOBase { }

    [FunctionOutput]
    public class SymbolOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TokenURIOutputDTO : TokenURIOutputDTOBase { }

    [FunctionOutput]
    public class TokenURIOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TotalSupplyOutputDTO : TotalSupplyOutputDTOBase { }

    [FunctionOutput]
    public class TotalSupplyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }


}
