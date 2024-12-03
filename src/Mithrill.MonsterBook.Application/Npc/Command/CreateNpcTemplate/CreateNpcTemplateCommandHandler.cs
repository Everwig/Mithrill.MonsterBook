using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Npc.Command.CreateNpcTemplate;

internal sealed class CreateNpcTemplateCommandHandler : IRequestHandler<CreateNpcTemplateCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IMonsterBookDbContext _monsterBookDbContext;

    public CreateNpcTemplateCommandHandler(IMapper mapper, IMonsterBookDbContext monsterBookDbContext)
    {
        _mapper = mapper;
        _monsterBookDbContext = monsterBookDbContext;
    }

    public async Task<int> Handle(CreateNpcTemplateCommand request, CancellationToken cancellationToken)
    {
        var template = _mapper.Map<MonsterBook.Domain.NpcTemplate>(request);
        _monsterBookDbContext.NpcTemplates.Add(template);

        return await _monsterBookDbContext.SaveChangesAsync(cancellationToken);
    }
}