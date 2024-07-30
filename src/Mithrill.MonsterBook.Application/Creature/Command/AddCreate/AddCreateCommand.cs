using System;
using MediatR;

namespace Mithrill.MonsterBook.Application.Creature.Command.AddCreate;

public class AddCreateCommand : IRequest<int>
{
    public Creature Creature { get; set; }
    public string CreatedBy { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}