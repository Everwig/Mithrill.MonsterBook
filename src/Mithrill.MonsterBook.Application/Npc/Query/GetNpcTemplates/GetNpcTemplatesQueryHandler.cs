using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Builders;
using Mithrill.MonsterBook.Application.Common.PageInformation;
using Mithrill.MonsterBook.Application.Common.SortInformation;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplates;

internal sealed class GetNpcTemplatesQueryHandler : IRequestHandler<GetNpcTemplatesQuery, GetNpcTemplatesQueryResult>
{
    private readonly IMapper _mapper;
    private readonly IMonsterBookDbContext _monsterBookDbContext;

    public GetNpcTemplatesQueryHandler(IMapper mapper, IMonsterBookDbContext monsterBookDbContext)
    {
        _mapper = mapper;
        _monsterBookDbContext = monsterBookDbContext;
    }

    public async Task<GetNpcTemplatesQueryResult> Handle(GetNpcTemplatesQuery request, CancellationToken cancellationToken)
    {
        var baseQuery = _monsterBookDbContext.Creatures
            .Include(creature => creature.CreatureMerits)
            .ThenInclude(creatureMerit => creatureMerit.Merit);

        var orderedCreatures = OrderBaseQuery(baseQuery, request.SortProperty, request.SortDirection);
        var totalCount = await orderedCreatures.CountAsync(cancellationToken);
        var creatures = await orderedCreatures.Skip(request.PageIndex * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var mappedCreatures = _mapper.Map<List<Npc>>(creatures);
        CalculateAttributes(mappedCreatures, creatures);

        return new GetNpcTemplatesQueryResult
        {
            Creatures = mappedCreatures,
            SortInformation = new SortInformation<SortProperty>
            {
                SortDirection = request.SortDirection,
                SortProperty = request.SortProperty
            },
            PageInformation = new PageInformation
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalCount = totalCount
            }
        };
    }

    private static IQueryable<MonsterBook.Domain.Creature> OrderBaseQuery(
        IQueryable<MonsterBook.Domain.Creature> baseQuery,
        SortProperty sortProperty,
        SortDirection sortDirection)
    {
        switch (sortProperty)
        {
            case SortProperty.Vitality:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(creature => creature.VitalityMin)
                    : baseQuery.OrderByDescending(creature => creature.VitalityMax);
            case SortProperty.Body:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(creature => creature.BodyMin)
                    : baseQuery.OrderByDescending(creature => creature.BodyMax);
            case SortProperty.Agility:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(creature => creature.AgilityMin)
                    : baseQuery.OrderByDescending(creature => creature.AgilityMax);
            case SortProperty.Dexterity:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(creature => creature.DexterityMin)
                    : baseQuery.OrderByDescending(creature => creature.DexterityMax);
            case SortProperty.Intelligence:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(creature => creature.IntelligenceMin)
                    : baseQuery.OrderByDescending(creature => creature.IntelligenceMax);
            case SortProperty.Willpower:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(creature => creature.WillpowerMin)
                    : baseQuery.OrderByDescending(creature => creature.WillpowerMax);
            case SortProperty.Emotion:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(creature => creature.EmotionMin)
                    : baseQuery.OrderByDescending(creature => creature.EmotionMax);
            case SortProperty.Karma:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(creature => creature.KarmaMax)
                    : baseQuery.OrderByDescending(creature => creature.KarmaMax);
            case SortProperty.Strength:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(creature => creature.StrengthMin)
                    : baseQuery.OrderByDescending(creature => creature.StrengthMax);
            case SortProperty.Race:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(creature => creature.Race)
                    : baseQuery.OrderByDescending(creature => creature.Race);
            case SortProperty.Name:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(creature => creature.Name)
                    : baseQuery.OrderByDescending(creature => creature.Name);
            case SortProperty.Difficulty:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(creature => creature.Difficulty)
                    : baseQuery.OrderByDescending(creature => creature.Difficulty);
            case SortProperty.Id:
            default:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(creature => creature.Id)
                    : baseQuery.OrderByDescending(creature => creature.Id);
        }
    }

    private static void CalculateAttributes(IEnumerable<Npc> creatures, IEnumerable<MonsterBook.Domain.Creature> queriedCreatures)
    {
        foreach (var creature in creatures)
        {
            var storedCreature = queriedCreatures.Single(c => c.Id == creature.Id);

            creature.HitPointMin = Calculators.CalculateHitPoints(
                creature.StrengthMin,
                creature.BodyMin,
                MonsterBook.Domain.Race.Undead,
                Enumerable.Empty<MonsterBook.Domain.Merit>());

            creature.HitPointMax = Calculators.CalculateHitPoints(
                creature.StrengthMax,
                creature.BodyMax,
                storedCreature.Race,
                storedCreature.CreatureMerits.Select(creatureMerit => creatureMerit.Merit));

            creature.ManaMin = Calculators.CalculateManaPoints(
                creature.IntelligenceMin,
                creature.WillpowerMin,
                creature.EmotionMin,
                Enumerable.Empty<MonsterBook.Domain.Merit>());

            creature.ManaMax = Calculators.CalculateManaPoints(
                creature.IntelligenceMin,
                creature.WillpowerMin,
                creature.EmotionMin,
                storedCreature.CreatureMerits.Select(creatureMerit => creatureMerit.Merit));

            creature.PowerPointMin = Calculators.CalculatePowerPoints(creature.KarmaMin);
            creature.PowerPointMax = Calculators.CalculatePowerPoints(creature.KarmaMax);
        }
    }
}