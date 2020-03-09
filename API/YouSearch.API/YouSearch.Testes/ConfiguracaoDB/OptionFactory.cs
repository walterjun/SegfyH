using System.Data;
using System.Data.SqlClient;

namespace YouSearch.Testes.ConfiguracaoDB
{
    public class OptionFactory
    {
        public string DefaultConnection { get; set; }
        public IDbConnection DatabaseConnection => new SqlConnection(DefaultConnection);
    }
}
