﻿using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc
{
    public class Weapon : IWeapon, IMapFrom<Domain.Weapon>
    {
        public string Name { get; set; }
        public IAttackType AttackType { get; set; }
    }
}