using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.MonsterBook.Seeds
{
    public class MythicCreatures
    {
        private int _identity;

        public MythicCreatures(int identitySeed)
        {
            _identity = identitySeed - 1;
        }

        public async Task AddOrUpdateCreatures(DbContext context)
        {
            await AddChimeraAsync(context, GetIdentity());
            await AddDiagonaAsync(context, GetIdentity());
            await AddUnicornAync(context, GetIdentity());
            await AddGiganticSnailAsync(context, GetIdentity());
            await AddGnollAsync(context, GetIdentity());
            await AddGriffAsync(context, GetIdentity());
            await AddHydraAsync(context, GetIdentity());
            await AddLamassuAsync(context, GetIdentity());
            await AddSirenAsync(context, GetIdentity());
        }

        private async Task AddChimeraAsync(DbContext context, int identity)
        {
            throw new System.NotImplementedException();
        }

        private async Task AddDiagonaAsync(DbContext context, int identity)
        {
            throw new System.NotImplementedException();
        }

        private async Task AddUnicornAync(DbContext context, int identity)
        {
            throw new System.NotImplementedException();
        }

        private async Task AddGiganticSnailAsync(DbContext context, int identity)
        {
            throw new System.NotImplementedException();
        }

        private async Task AddGnollAsync(DbContext context, int identity)
        {
            throw new System.NotImplementedException();
        }

        private async Task AddGriffAsync(DbContext context, int identity)
        {
            throw new System.NotImplementedException();
        }

        private async Task AddHydraAsync(DbContext context, int identity)
        {
            throw new System.NotImplementedException();
        }

        private async Task AddLamassuAsync(DbContext context, int identity)
        {
            throw new System.NotImplementedException();
        }

        private async Task AddSirenAsync(DbContext context, int identity)
        {
            throw new System.NotImplementedException();
        }

        private int GetIdentity()
        {
            return _identity++;
        }
    }
}