using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.MonsterBook.Seeds
{
    internal class SimpleEnemiesAndHirelings
    {
        private int _identity;

        public SimpleEnemiesAndHirelings(int identitySeed)
        {
            _identity = identitySeed - 1;
        }

        public async Task<int> AddOrUpdateCharacters(DbContext context)
        {
            return _identity;
        }
        private int GetIdentity()
        {
            return _identity++;
        }
    }
}