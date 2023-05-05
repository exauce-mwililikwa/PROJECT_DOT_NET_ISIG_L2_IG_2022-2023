using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace WebApplication5.Models
{
    public class Utilisateur
    {
   public int Id { get; set; }
  
        public string name { get; set; }
   public string email { get; set; }
   public string adresse { get; set; }
   public string date_naissance { get; set; }

    }
}
