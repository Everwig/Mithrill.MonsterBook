﻿using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate
{
    public class AttackType : IMapFrom<MonsterBook.Domain.AttackType>
    {
        public int Id { get; set; }
        public DamageType DamageType { get; set; }
        public int NumberOfDices { get; set; }
        public int GuaranteedDamage { get; set; }
        public bool IsBaseAttackType { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MonsterBook.Domain.AttackType, AttackType>()
                .ForMember(attackType => attackType.IsBaseAttackType, opt => opt.Ignore());
        }
    }
}