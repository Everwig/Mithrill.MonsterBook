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
        var baseQuery = _monsterBookDbContext.NpcTemplates
            .Include(npcTemplate => npcTemplate.CharacterMerits)
            .ThenInclude(characterMerit => characterMerit.Merit);

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

    private static IQueryable<MonsterBook.Domain.NpcTemplate> OrderBaseQuery(
        IQueryable<MonsterBook.Domain.NpcTemplate> baseQuery,
        SortProperty sortProperty,
        SortDirection sortDirection)
    {
        switch (sortProperty)
        {
            case SortProperty.Vitality:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(npcTemplate => npcTemplate.VitalityMin)
                    : baseQuery.OrderByDescending(npcTemplate => npcTemplate.VitalityMax);
            case SortProperty.Body:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(npcTemplate => npcTemplate.BodyMin)
                    : baseQuery.OrderByDescending(npcTemplate => npcTemplate.BodyMax);
            case SortProperty.Agility:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(npcTemplate => npcTemplate.AgilityMin)
                    : baseQuery.OrderByDescending(npcTemplate => npcTemplate.AgilityMax);
            case SortProperty.Dexterity:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(npcTemplate => npcTemplate.DexterityMin)
                    : baseQuery.OrderByDescending(npcTemplate => npcTemplate.DexterityMax);
            case SortProperty.Intelligence:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(npcTemplate => npcTemplate.IntelligenceMin)
                    : baseQuery.OrderByDescending(npcTemplate => npcTemplate.IntelligenceMax);
            case SortProperty.Willpower:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(npcTemplate => npcTemplate.WillpowerMin)
                    : baseQuery.OrderByDescending(npcTemplate => npcTemplate.WillpowerMax);
            case SortProperty.Emotion:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(npcTemplate => npcTemplate.EmotionMin)
                    : baseQuery.OrderByDescending(npcTemplate => npcTemplate.EmotionMax);
            case SortProperty.Karma:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(npcTemplate => npcTemplate.KarmaMax)
                    : baseQuery.OrderByDescending(npcTemplate => npcTemplate.KarmaMax);
            case SortProperty.Strength:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(npcTemplate => npcTemplate.StrengthMin)
                    : baseQuery.OrderByDescending(npcTemplate => npcTemplate.StrengthMax);
            case SortProperty.Race:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(npcTemplate => npcTemplate.Race)
                    : baseQuery.OrderByDescending(npcTemplate => npcTemplate.Race);
            case SortProperty.Name:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(npcTemplate => npcTemplate.Name)
                    : baseQuery.OrderByDescending(npcTemplate => npcTemplate.Name);
            case SortProperty.Difficulty:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(npcTemplate => npcTemplate.Difficulty)
                    : baseQuery.OrderByDescending(npcTemplate => npcTemplate.Difficulty);
            case SortProperty.Id:
            default:
                return sortDirection == SortDirection.Asc
                    ? baseQuery.OrderBy(npcTemplate => npcTemplate.Id)
                    : baseQuery.OrderByDescending(npcTemplate => npcTemplate.Id);
        }
    }

    private static void CalculateAttributes(IEnumerable<Npc> creatures, IEnumerable<MonsterBook.Domain.NpcTemplate> queriedCreatures)
    {
        foreach (var npcTemplate in creatures)
        {
            var storedCreature = queriedCreatures.Single(c => c.Id == npcTemplate.Id);

            npcTemplate.HitPointMin = Calculators.CalculateHitPoints(
                npcTemplate.StrengthMin,
                npcTemplate.BodyMin,
                MonsterBook.Domain.Race.Undead,
                Enumerable.Empty<MonsterBook.Domain.Merit>());

            npcTemplate.HitPointMax = Calculators.CalculateHitPoints(
                npcTemplate.StrengthMax,
                npcTemplate.BodyMax,
                storedCreature.Race,
                storedCreature.CharacterMerits.Select(characterMerit => characterMerit.Merit));

            npcTemplate.ManaMin = Calculators.CalculateManaPoints(
                npcTemplate.IntelligenceMin,
                npcTemplate.WillpowerMin,
                npcTemplate.EmotionMin,
                Enumerable.Empty<MonsterBook.Domain.Merit>());

            npcTemplate.ManaMax = Calculators.CalculateManaPoints(
                npcTemplate.IntelligenceMin,
                npcTemplate.WillpowerMin,
                npcTemplate.EmotionMin,
                storedCreature.CharacterMerits.Select(characterMerit => characterMerit.Merit));

            npcTemplate.PowerPointMin = Calculators.CalculatePowerPoints(npcTemplate.KarmaMin);
            npcTemplate.PowerPointMax = Calculators.CalculatePowerPoints(npcTemplate.KarmaMax);
        }
    }
}