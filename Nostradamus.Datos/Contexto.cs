using System.Collections.Generic;
using System.Linq;

namespace Nostradamus.Datos
{
    public static class Contexto
    {
        private static Repositorio _rep = new Repositorio();
        public static int Add(string entityDescription, object entity)
        {
            string spName = BuildProcedureName(entityDescription, "I");
            int answer = _rep.Add(GetParameters(entity), spName);
            return answer;
        }

        public static T GetById<T>(object id, string entityDescription)
        {
            string spName = BuildProcedureName(entityDescription, "GB");
            Dictionary<string, object> dbArg = GetParameters(id);
            T answer = _rep.Query<T>(spName, dbArg);
            return answer;
        }

        public static List<T> GetAll<T>(string entityDescription)
        {
            string spName = BuildProcedureName(entityDescription, "GA");
            List<T> answer = _rep.Query<T>(spName);
            return answer;
        }
   
        public static void MasiveDelete(string entityDescription)
        {
            string spName = BuildProcedureName(entityDescription, "MD");
            _rep.Execute(spName);
        }

        private static Dictionary<string, object> GetParameters(object obj)
        {
            var list = obj.GetType().GetProperties()
                     .Where(p => p.GetValue(obj) != null)
                     .ToList();
               
                Dictionary<string, object> dbArgs = new Dictionary<string, object>();

                list.ForEach(x =>
                {
                    dbArgs.Add(("@" +  x.Name), x.GetValue(obj));                   
                });

            return dbArgs;


        }

        private static string BuildProcedureName(string entity, string action)
        {
            return entity + "_" + action;
        }

    }
}
