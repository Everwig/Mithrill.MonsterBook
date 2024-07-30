using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Creature.Command.AddCreate;

public class AddCreatureCommandHandler : IRequestHandler<AddCreateCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IMonsterBookDbContext _monsterBookDbContext;

    public AddCreatureCommandHandler(IMapper mapper, IMonsterBookDbContext monsterBookDbContext)
    {
        _mapper = mapper;
        _monsterBookDbContext = monsterBookDbContext;
    }

    public async Task<int> Handle(AddCreateCommand request, CancellationToken cancellationToken)
    {
        var creature = _mapper.Map<MonsterBook.Domain.Creature>(request.Creature);
        var entry = await _monsterBookDbContext.Creatures.AddAsync(creature, cancellationToken);

        return entry.Entity.Id;
    }
}