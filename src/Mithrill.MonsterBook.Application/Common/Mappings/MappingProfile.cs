using AutoMapper;
using System.Reflection;

namespace Mithrill.MonsterBook.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Assembly.GetExecutingAssembly().ApplyMapFromAndToFromAssembly(this);
        }
    }
}