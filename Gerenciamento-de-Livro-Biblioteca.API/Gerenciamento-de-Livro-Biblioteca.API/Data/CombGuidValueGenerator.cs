using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using RT.Comb;

namespace Gerenciamento_de_Livro_Biblioteca.API.Data
{
    public class CombGuidValueGenerator : ValueGenerator<Guid>
    {
        //private static readonly ICombProvider _provider = Provider.Sql;
        private static readonly ICombProvider _provider = Provider.PostgreSql;
        public override bool GeneratesTemporaryValues => false;
        public override Guid Next(EntityEntry entry)
        {
            return _provider.Create();
        }
    }
}
