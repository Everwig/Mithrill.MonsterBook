using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Npc.Command.DeleteNpcTemplate;

internal sealed class DeleteNpcTemplateCommandHandler : IRequestHandler<DeleteNpcTemplateCommand>
{
    private readonly IMonsterBookDbContext _monsterBookDbContext;

    public DeleteNpcTemplateCommandHandler(IMonsterBookDbContext monsterBookDbContext)
    {
        _monsterBookDbContext = monsterBookDbContext;
    }

    public async Task Handle(DeleteNpcTemplateCommand request, CancellationToken cancellationToken)
    {
        var npc = await _monsterBookDbContext.Creatures.SingleOrDefaultAsync(
            creature => creature.Id == request.TemplateId,
            cancellationToken);

        if (npc != null)
        {
            _monsterBookDbContext.Creatures.Remove(npc);
        }
    }
}