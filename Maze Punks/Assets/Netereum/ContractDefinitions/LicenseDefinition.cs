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

namespace Contracts.Contracts.License.ContractDefinition
{


    public partial class LicenseDeployment : LicenseDeploymentBase
    {
        public LicenseDeployment() : base(BYTECODE) { }
        public LicenseDeployment(string byteCode) : base(byteCode) { }
    }

    public class LicenseDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public LicenseDeploymentBase() : base(BYTECODE) { }
        public LicenseDeploymentBase(string byteCode) : base(byteCode) { }
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

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
        [Parameter("uint256", "id", 2)]
        public virtual BigInteger Id { get; set; }
    }

    public partial class BalanceOfBatchFunction : BalanceOfBatchFunctionBase { }

    [Function("balanceOfBatch", "uint256[]")]
    public class BalanceOfBatchFunctionBase : FunctionMessage
    {
        [Parameter("address[]", "accounts", 1)]
        public virtual List<string> Accounts { get; set; }
        [Parameter("uint256[]", "ids", 2)]
        public virtual List<BigInteger> Ids { get; set; }
    }

    public partial class BurnFunction : BurnFunctionBase { }

    [Function("burn")]
    public class BurnFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
        [Parameter("uint256", "id", 2)]
        public virtual BigInteger Id { get; set; }
        [Parameter("uint256", "value", 3)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class BurnBatchFunction : BurnBatchFunctionBase { }

    [Function("burnBatch")]
    public class BurnBatchFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
        [Parameter("uint256[]", "ids", 2)]
        public virtual List<BigInteger> Ids { get; set; }
        [Parameter("uint256[]", "values", 3)]
        public virtual List<BigInteger> Values { get; set; }
    }

    public partial class ContractsFunction : ContractsFunctionBase { }

    [Function("contracts", "address")]
    public class ContractsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class CustomURIFunction : CustomURIFunctionBase { }

    [Function("customURI", "string")]
    public class CustomURIFunctionBase : FunctionMessage
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

    public partial class IsApprovedForAllFunction : IsApprovedForAllFunctionBase { }

    [Function("isApprovedForAll", "bool")]
    public class IsApprovedForAllFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
        [Parameter("address", "operator", 2)]
        public virtual string Operator { get; set; }
    }

    public partial class MintCostFunction : MintCostFunctionBase { }

    [Function("mintCost", "uint256")]
    public class MintCostFunctionBase : FunctionMessage
    {

    }

    public partial class MintLicenseFunction : MintLicenseFunctionBase { }

    [Function("mintLicense")]
    public class MintLicenseFunctionBase : FunctionMessage
    {
        [Parameter("address", "_lordAddress", 1)]
        public virtual string LordAddress { get; set; }
        [Parameter("uint256", "_lordID", 2)]
        public virtual BigInteger LordID { get; set; }
        [Parameter("uint256", "_amount", 3)]
        public virtual BigInteger Amount { get; set; }
        [Parameter("bytes", "_data", 4)]
        public virtual byte[] Data { get; set; }
    }

    public partial class NumOfActiveLicenseFunction : NumOfActiveLicenseFunctionBase { }

    [Function("numOfActiveLicense", "uint256")]
    public class NumOfActiveLicenseFunctionBase : FunctionMessage
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
        [Parameter("uint256", "_newMintCost", 1)]
        public virtual BigInteger NewMintCost { get; set; }
    }

    public partial class SafeBatchTransferFromFunction : SafeBatchTransferFromFunctionBase { }

    [Function("safeBatchTransferFrom")]
    public class SafeBatchTransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256[]", "ids", 3)]
        public virtual List<BigInteger> Ids { get; set; }
        [Parameter("uint256[]", "amounts", 4)]
        public virtual List<BigInteger> Amounts { get; set; }
        [Parameter("bytes", "data", 5)]
        public virtual byte[] Data { get; set; }
    }

    public partial class SafeTransferFromFunction : SafeTransferFromFunctionBase { }

    [Function("safeTransferFrom")]
    public class SafeTransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "id", 3)]
        public virtual BigInteger Id { get; set; }
        [Parameter("uint256", "amount", 4)]
        public virtual BigInteger Amount { get; set; }
        [Parameter("bytes", "data", 5)]
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

    public partial class SetCustomURIFunction : SetCustomURIFunctionBase { }

    [Function("setCustomURI")]
    public class SetCustomURIFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_lordID", 1)]
        public virtual BigInteger LordID { get; set; }
        [Parameter("string", "_customURI", 2)]
        public virtual string CustomURI { get; set; }
    }

    public partial class SupportsInterfaceFunction : SupportsInterfaceFunctionBase { }

    [Function("supportsInterface", "bool")]
    public class SupportsInterfaceFunctionBase : FunctionMessage
    {
        [Parameter("bytes4", "interfaceId", 1)]
        public virtual byte[] InterfaceId { get; set; }
    }

    public partial class UriFunction : UriFunctionBase { }

    [Function("uri", "string")]
    public class UriFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_lordID", 1)]
        public virtual BigInteger LordID { get; set; }
    }

    public partial class ApprovalForAllEventDTO : ApprovalForAllEventDTOBase { }

    [Event("ApprovalForAll")]
    public class ApprovalForAllEventDTOBase : IEventDTO
    {
        [Parameter("address", "account", 1, true )]
        public virtual string Account { get; set; }
        [Parameter("address", "operator", 2, true )]
        public virtual string Operator { get; set; }
        [Parameter("bool", "approved", 3, false )]
        public virtual bool Approved { get; set; }
    }

    public partial class TransferBatchEventDTO : TransferBatchEventDTOBase { }

    [Event("TransferBatch")]
    public class TransferBatchEventDTOBase : IEventDTO
    {
        [Parameter("address", "operator", 1, true )]
        public virtual string Operator { get; set; }
        [Parameter("address", "from", 2, true )]
        public virtual string From { get; set; }
        [Parameter("address", "to", 3, true )]
        public virtual string To { get; set; }
        [Parameter("uint256[]", "ids", 4, false )]
        public virtual List<BigInteger> Ids { get; set; }
        [Parameter("uint256[]", "values", 5, false )]
        public virtual List<BigInteger> Values { get; set; }
    }

    public partial class TransferSingleEventDTO : TransferSingleEventDTOBase { }

    [Event("TransferSingle")]
    public class TransferSingleEventDTOBase : IEventDTO
    {
        [Parameter("address", "operator", 1, true )]
        public virtual string Operator { get; set; }
        [Parameter("address", "from", 2, true )]
        public virtual string From { get; set; }
        [Parameter("address", "to", 3, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "id", 4, false )]
        public virtual BigInteger Id { get; set; }
        [Parameter("uint256", "value", 5, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class URIEventDTO : URIEventDTOBase { }

    [Event("URI")]
    public class URIEventDTOBase : IEventDTO
    {
        [Parameter("string", "value", 1, false )]
        public virtual string Value { get; set; }
        [Parameter("uint256", "id", 2, true )]
        public virtual BigInteger Id { get; set; }
    }





    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class BalanceOfBatchOutputDTO : BalanceOfBatchOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfBatchOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256[]", "", 1)]
        public virtual List<BigInteger> ReturnValue1 { get; set; }
    }





    public partial class ContractsOutputDTO : ContractsOutputDTOBase { }

    [FunctionOutput]
    public class ContractsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class CustomURIOutputDTO : CustomURIOutputDTOBase { }

    [FunctionOutput]
    public class CustomURIOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }







    public partial class FunctionsProposalTypesOutputDTO : FunctionsProposalTypesOutputDTOBase { }

    [FunctionOutput]
    public class FunctionsProposalTypesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
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



    public partial class NumOfActiveLicenseOutputDTO : NumOfActiveLicenseOutputDTOBase { }

    [FunctionOutput]
    public class NumOfActiveLicenseOutputDTOBase : IFunctionOutputDTO 
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















    public partial class SupportsInterfaceOutputDTO : SupportsInterfaceOutputDTOBase { }

    [FunctionOutput]
    public class SupportsInterfaceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class UriOutputDTO : UriOutputDTOBase { }

    [FunctionOutput]
    public class UriOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }
}
