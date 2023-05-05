using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;


namespace WebApplication5.Models
{
    public class DAO
    {
        string Connectionstring =String.Format( "Data Source={0};Integrated Security={1}", "DESKTOP-ORK602N", "True");
         
        //creons une fonction qui vas listes les utilisateurs
        public IEnumerable<Utilisateur> liste_user() {
            var user = new List<Utilisateur>();
            using (SqlConnection con=new SqlConnection(Connectionstring)) {
                SqlCommand cmd = new SqlCommand("select_all_user",con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (SqlDataReader reader=cmd.ExecuteReader()) {
                    //instancions notre liste
                    user = new List<Utilisateur>();
                    //la boucle qui charge la liste 
                    while (reader.Read()) {
                        user.Add(
                            new Utilisateur
                            {
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                name=reader["_name"].ToString(),
                                email= reader["_email"].ToString(),
                                adresse= reader["_adresse"].ToString(),
                                date_naissance= reader["_datenaissance"].ToString()}
                            );
                    }        
                }
            }
                return user;
        }
        public void insert_user(Utilisateur user) {
            try {
                using (SqlConnection con=new SqlConnection(Connectionstring)) {
                    SqlCommand cmd = new SqlCommand("insert_user",con);
                    cmd.Parameters.AddWithValue("@name",user.name);
                    cmd.Parameters.AddWithValue("@email",user.email);
                    cmd.Parameters.AddWithValue("@adresse",user.adresse);
                    cmd.Parameters.AddWithValue("@datenaissance",user.date_naissance);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                
                }
                
            
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }


        
        }
        //focntion de modification
        public void update_user(Utilisateur user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connectionstring))
                {
                    SqlCommand cmd = new SqlCommand("update_user", con);
                    cmd.Parameters.AddWithValue("@id", user.Id);
                    cmd.Parameters.AddWithValue("@name", user.name);
                    cmd.Parameters.AddWithValue("@email", user.email);
                    cmd.Parameters.AddWithValue("@adresse", user.adresse);
                    cmd.Parameters.AddWithValue("@datenaissance", user.date_naissance);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }

        //focntion de suppression
        public void delete_user(int?id)
        {
           try
            {
                using (SqlConnection con = new SqlConnection(Connectionstring))
                {
                    SqlCommand cmd = new SqlCommand("delete_user", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }
        //fonction de selection par id
        public Utilisateur select_user_by_id(int?id) {
            var user = new Utilisateur();
            try{
                using (SqlConnection con = new SqlConnection(Connectionstring)) {
                    SqlCommand cmd = new SqlCommand("select_all_user_by_id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                           user.Id = Convert.ToInt32(reader["id"].ToString());
                            user.name = reader["_name"].ToString();
                            user.email = reader["_email"].ToString();
                            user.adresse = reader["_adresse"].ToString();
                            user.date_naissance = reader["_datenaissance"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
                return user;

        }


    }
}
