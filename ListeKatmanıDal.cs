using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖgrenciListesi
{
    class ListeKatmanıDal


       

    //================================
    {

        SqlConnection connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog = SınıfListesi;integrated security = true");

        public DataTable GetAll()
        {
            
            //uzaktaki veritabanına erişmek için false yap
            if(connection.State==ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand command = new SqlCommand("Select * from Liste",connection);

           SqlDataReader reader =  command.ExecuteReader();
            //datatable oluşturduk ve okuduklarımıza datatable a doldurduk
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();
            connection.Close();
            return dataTable;
        }

        //===============================================

        public void Add(ListeKatmanı liste)
        {

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand command = new SqlCommand("Insert into liste values(@İsim,@Soyisim,@Bölüm,@Ortalaması)", connection);
            command.Parameters.AddWithValue("@İsim", liste.İsim);
            command.Parameters.AddWithValue("@Soyisim", liste.Soyisim);
            command.Parameters.AddWithValue("@Bölüm", liste.Bölüm);
            command.Parameters.AddWithValue("@Ortalaması", liste.Ortalaması);
            command.ExecuteNonQuery();

            connection.Close();



        }

        //============================================

        public void Update(ListeKatmanı liste)
        {

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand command = new SqlCommand("Update Liste set İsim=@İsim,Soyisim=@Soyisim,Bölüm=@Bölüm,Ortalaması=@Ortalaması where Okul_NO = @Okul_NO", connection);
            command.Parameters.AddWithValue("@İsim", liste.İsim);
            command.Parameters.AddWithValue("@Soyisim", liste.Soyisim);
            command.Parameters.AddWithValue("@Bölüm", liste.Bölüm);
            command.Parameters.AddWithValue("@Ortalaması", liste.Ortalaması);
            command.Parameters.AddWithValue("@Okul_NO", liste.Okul_NO);
            command.ExecuteNonQuery();

            connection.Close();



        }

        //=====================================================
        

        public void Delete(int Okul_NO)
        {

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand command = new SqlCommand("Delete from liste where Okul_NO=@Okul_NO", connection);            
            command.Parameters.AddWithValue("@Okul_NO", Okul_NO);
            command.ExecuteNonQuery();

            connection.Close();



        }





    }
}
