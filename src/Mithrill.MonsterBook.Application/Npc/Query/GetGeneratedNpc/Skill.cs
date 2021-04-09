﻿using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc
{
    public class Skill : ISkill, IMapFrom<Domain.Skill>
    {
        public string Name { get; set; }
        public int Level { get; set; }
    }
}