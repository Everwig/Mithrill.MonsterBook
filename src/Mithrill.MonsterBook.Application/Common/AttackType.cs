using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Common
{
    public class AttackType :
        IAttackType,
        IMapFrom<MonsterBook.Domain.AttackType>,
        IMapTo<MonsterBook.Domain.AttackType>
    {
        public DamageType DamageType { get; set; }
        public int NumberOfDices { get; set; }
        public int GuaranteedDamage { get; set; }

        void IMapTo<MonsterBook.Domain.AttackType>.Mapping(Profile profile)
        {
            profile.CreateMap<AttackType, MonsterBook.Domain.AttackType>()
                .ForMember(attackType => attackType.Id, opt => opt.Ignore())
                .ForMember(attackType => attackType.Weapons, opt => opt.Ignore())
                .ForMember(attackType => attackType.CharacterWeaponAttackTypes, opt => opt.Ignore());
        }
    }
}