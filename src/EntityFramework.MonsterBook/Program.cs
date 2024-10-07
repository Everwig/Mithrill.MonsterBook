using System.Threading.Tasks;
using EntityFramework.MonsterBook.Seeds;

namespace EntityFramework.MonsterBook
{
    internal class Program
    {
        private static async Task Main()
        {
            await using var dbContext = new EfMonsterBookDbContext();
            await Merits.AddOrUpdateMerits(dbContext);
            await Flaws.AddOrUpdateFlaws(dbContext);
            await Skills.AddOrUpdateSkills(dbContext);
            await WeaponsAndArmors.AddOrUpdateAttackTypes(dbContext);
            await WeaponsAndArmors.AddOrUpdateWeapons(dbContext);
            await WeaponsAndArmors.AddOrUpdateArmors(dbContext);
            const int identitySeedStart = 1;
            var seedIdContinuation = await new Animals(identitySeedStart).AddOrUpdateAnimals(dbContext);
            seedIdContinuation = await new EvilAndGoodCreatures(seedIdContinuation).AddOrUpdateCreatures(dbContext);
            seedIdContinuation = await new SimpleEnemiesAndHirelings(seedIdContinuation).AddOrUpdateCharacters(dbContext);
            seedIdContinuation = await new DragonsAndBugs(seedIdContinuation).AddOrUpdateCreatures(dbContext);
            await new MythicCreatures(seedIdContinuation).AddOrUpdateCreatures(dbContext);
            await dbContext.SaveChangesAsync();
        }
    }
}