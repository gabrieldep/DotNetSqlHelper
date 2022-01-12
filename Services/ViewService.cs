using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSqlHelper.Services
{
    public class ViewService
    {
        //Funcionando no MySql- Não testado em outros bancos;
        public static void InjectView(DatabaseFacade db, string sqlFileName, string viewName, Type programType)
        {
            var assembly = programType.Assembly;
            var assemblyName = assembly.FullName[..assembly.FullName.IndexOf(',')];
            var resource = assembly.GetManifestResourceStream($"{assemblyName}.{sqlFileName}");
            var sqlQuery = new StreamReader(resource).ReadToEnd();

            db.ExecuteSqlRaw($"CREATE OR REPLACE VIEW {viewName} AS {sqlQuery}");
        }
    }
}
