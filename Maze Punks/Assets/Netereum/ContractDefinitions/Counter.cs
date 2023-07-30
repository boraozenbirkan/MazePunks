using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Contracts.Contracts.StickClan.ContractDefinition
{
    public partial class Counter : CounterBase { }

    public class CounterBase 
    {
        [Parameter("uint256", "_value", 1)]
        public virtual BigInteger Value { get; set; }
    }
}
