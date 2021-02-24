using AutoMapper;
using Mithrill.MonsterBook.Application.Monsters.Query.GetMonster;

namespace Mithrill.MonsterBook.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Creature, Monster>();
            CreateMap<Domain.Skill, Skill>();
            CreateMap<Domain.Merit, Merit>();
            CreateMap<Domain.Weapon, Weapon>();
            CreateMap<Domain.AttackType, AttackType>();
        }
    }
}