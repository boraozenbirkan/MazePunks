using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Contracts.Contracts.StickClan.ContractDefinition
{
    public partial class ClanInfo : ClanInfoBase { }

    public class ClanInfoBase 
    {
        [Parameter("address", "leader", 1)]
        public virtual string Leader { get; set; }
        [Parameter("uint256", "lordID", 2)]
        public virtual BigInteger LordID { get; set; }
        [Parameter("uint256", "firstRound", 3)]
        public virtual BigInteger FirstRound { get; set; }
        [Parameter("string", "name", 4)]
        public virtual string Name { get; set; }
        [Parameter("string", "description", 5)]
        public virtual string Description { get; set; }
        [Parameter("string", "motto", 6)]
        public virtual string Motto { get; set; }
        [Parameter("string", "logoURI", 7)]
        public virtual string LogoURI { get; set; }
        [Parameter("bool", "canExecutorsSignalRebellion", 8)]
        public virtual bool CanExecutorsSignalRebellion { get; set; }
        [Parameter("bool", "canExecutorsSetPoint", 9)]
        public virtual bool CanExecutorsSetPoint { get; set; }
        [Parameter("bool", "canModsSetMembers", 10)]
        public virtual bool CanModsSetMembers { get; set; }
        [Parameter("bool", "isDisbanded", 11)]
        public virtual bool IsDisbanded { get; set; }
    }
}
