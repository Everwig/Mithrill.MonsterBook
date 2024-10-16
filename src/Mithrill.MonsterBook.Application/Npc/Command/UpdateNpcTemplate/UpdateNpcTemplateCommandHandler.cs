using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Exceptions;

namespace Mithrill.MonsterBook.Application.Npc.Command.UpdateNpcTemplate;

internal sealed class UpdateNpcTemplateCommandHandler : IRequestHandler<UpdateNpcTemplateCommand>
{
    private readonly IMapper _mapper;
    private readonly IMonsterBookDbContext _monsterBookDbContext;

    public UpdateNpcTemplateCommandHandler(IMapper mapper, IMonsterBookDbContext monsterBookDbContext)
    {
        _mapper = mapper;
        _monsterBookDbContext = monsterBookDbContext;
    }

    public async Task Handle(UpdateNpcTemplateCommand request, CancellationToken cancellationToken)
    {
        var template = await _monsterBookDbContext.NpcTemplates
            .AsNoTrackingWithIdentityResolution()
            .SingleOrDefaultAsync(template => template.Id == request.Id, cancellationToken);

        if (template is null)
        {
            throw new NotFoundException("Template not found", request.Id);
        }

        template = _mapper.Map<MonsterBook.Domain.NpcTemplate>(request.NpcTemplate);

        _monsterBookDbContext.NpcTemplates.Update(template);
        await _monsterBookDbContext.SaveChangesAsync(cancellationToken);
    }
}