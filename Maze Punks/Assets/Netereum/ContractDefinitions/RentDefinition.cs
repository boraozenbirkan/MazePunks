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

namespace Contracts.Contracts.Rent.ContractDefinition
{


    public partial class RentDeployment : RentDeploymentBase
    {
        public RentDeployment() : base(BYTECODE) { }
        public RentDeployment(string byteCode) : base(byteCode) { }
    }

    public class RentDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public RentDeploymentBase() : base(BYTECODE) { }
        public RentDeploymentBase(string byteCode) : base(byteCode) { }
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

    public partial class ContractsFunction : ContractsFunctionBase { }

    [Function("contracts", "address")]
    public class ContractsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class DelistFunction : DelistFunctionBase { }

    [Function("delist")]
    public class DelistFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_lordID", 1)]
        public virtual BigInteger LordID { get; set; }
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

    public partial class ListFunction : ListFunctionBase { }

    [Function("list")]
    public class ListFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_lordID", 1)]
        public virtual BigInteger LordID { get; set; }
        [Parameter("uint256", "_rentFee", 2)]
        public virtual BigInteger RentFee { get; set; }
        [Parameter("uint256", "_length", 3)]
        public virtual BigInteger Length { get; set; }
    }

    public partial class ListingsFunction : ListingsFunctionBase { }

    [Function("listings", typeof(ListingsOutputDTO))]
    public class ListingsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ProposalTypeIndexFunction : ProposalTypeIndexFunctionBase { }

    [Function("proposalTypeIndex", "uint256")]
    public class ProposalTypeIndexFunctionBase : FunctionMessage
    {

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
        [Parameter("uint256", "_newTypeIndex", 1)]
        public virtual BigInteger NewTypeIndex { get; set; }
    }

    public partial class RentFunction : RentFunctionBase { }

    [Function("rent")]
    public class RentFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_lordID", 1)]
        public virtual BigInteger LordID { get; set; }
    }





    public partial class ContractsOutputDTO : ContractsOutputDTOBase { }

    [FunctionOutput]
    public class ContractsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }









    public partial class ListingsOutputDTO : ListingsOutputDTOBase { }

    [FunctionOutput]
    public class ListingsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "isListed", 1)]
        public virtual bool IsListed { get; set; }
        [Parameter("uint256", "lordID", 2)]
        public virtual BigInteger LordID { get; set; }
        [Parameter("address", "ownerAddress", 3)]
        public virtual string OwnerAddress { get; set; }
        [Parameter("uint256", "fee", 4)]
        public virtual BigInteger Fee { get; set; }
        [Parameter("uint256", "length", 5)]
        public virtual BigInteger Length { get; set; }
    }

    public partial class ProposalTypeIndexOutputDTO : ProposalTypeIndexOutputDTOBase { }

    [FunctionOutput]
    public class ProposalTypeIndexOutputDTOBase : IFunctionOutputDTO 
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






}
