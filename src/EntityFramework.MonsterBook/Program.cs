using System.Threading.Tasks;
using EntityFramework.MonsterBook.Seeds;

namespace EntityFramework.MonsterBook
{
    internal class Program
    {
        private static async Task Main()
        {
            await using var context = new EfMonsterBookDbContext();
            await Merits.AddOrUpdateMerits(context);
            await Flaws.AddOrUpdateFlaws(context);
            await Skills.AddOrUpdateSkills(context);
            await Weapons.AddOrUpdateWeapons(context);
            const int identitySeedStart = 1;
            var seedIdContinuation = await new Animals(identitySeedStart).AddOrUpdateAnimals(context);
            seedIdContinuation = await new EvilAndGoodCreatures(seedIdContinuation).AddOrUpdateCreatures(context);
            seedIdContinuation = await new SimpleEnemiesAndHirelings(seedIdContinuation).AddOrUpdateCharacters(context);
            seedIdContinuation = await new DragonsAndBugs(seedIdContinuation).AddOrUpdateCreatures(context);
            await new MythicCreatures(seedIdContinuation).AddOrUpdateCreatures(context);
            await context.SaveChangesAsync();
        }
    }
}