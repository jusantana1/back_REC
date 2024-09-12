using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp.Models
{
    public class CadUserModel
    {
      public int usua_id {get; set;}
      public string usua_nome {get; set;}
      public string usua_email {get; set;}
      public string _usua_senha {get;set;}
      public string usua_dt_cadastro {get; set;}

        internal static void add(CadUserModel cadUserModel)
        {
            throw new NotImplementedException();
        }
    }
}