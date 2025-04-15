using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eparking.Infra.Data.Settings
{
    public class SqlServerSettings
    {
        public static string ConnectionString => "Data Source=localhost,1436;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=Trop@1234;Encrypt=False";
    }
}
