using System.Threading.Tasks;
using EntityFramework.MonsterBook.Seeds;

namespace EntityFramework.MonsterBook
{
    internal class Program
    {
        private static async Task Main()
        {
            await using var context = new EfMonsterBookDbContext();
            //TODO: SET IDENTITY_INSERT ON for all tables
            await Merits.AddOrUpdateMerits(context);
            await Flaws.AddOrUpdateFlaws(context);
            await Skills.AddOrUpdateSkills(context);
            await Weapons.AddOrUpdateWeapons(context);
            await Creatures.AddOrUpdateCreatures(context);
            //await context.SaveChangesAsync();
            //TODO: SET IDENTITY_INSERT OFF for all tables
        }
    }
}