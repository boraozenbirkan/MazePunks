using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Contracts.CryptoPunks.ContractDefinition
{


    public partial class CryptoPunksDeployment : CryptoPunksDeploymentBase
    {
        public CryptoPunksDeployment() : base(BYTECODE) { }
        public CryptoPunksDeployment(string byteCode) : base(byteCode) { }
    }

    public class CryptoPunksDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b50610172806100206000396000f3fe608060405234801561001057600080fd5b506004361061002b5760003560e01c806370a0823114610030575b600080fd5b61004a600480360381019061004591906100db565b610060565b6040516100579190610121565b60405180910390f35b60006020528060005260406000206000915090505481565b600080fd5b600073ffffffffffffffffffffffffffffffffffffffff82169050919050565b60006100a88261007d565b9050919050565b6100b88161009d565b81146100c357600080fd5b50565b6000813590506100d5816100af565b92915050565b6000602082840312156100f1576100f0610078565b5b60006100ff848285016100c6565b91505092915050565b6000819050919050565b61011b81610108565b82525050565b60006020820190506101366000830184610112565b9291505056fea26469706673582212203f08ef03a8bf29a837b62234687c27f580aaa7983739c915c21364a15313cea664736f6c63430008130033";
        public CryptoPunksDeploymentBase() : base(BYTECODE) { }
        public CryptoPunksDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }
}
