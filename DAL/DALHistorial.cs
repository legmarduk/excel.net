using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using BOL.Helpers;

namespace DAL
{
    public class DALHistorial
    {
  
     
        public static List<Historial> listaAtencion()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                Coneccion param = Parameter.Leer_parametros();
                cmd.Connection = new SqlConnection(param.ConString);
                cmd.Connection.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select *  from HistorialMascota";

                SqlDataReader rdr = cmd.ExecuteReader();
                List<Historial> historial = new List<Historial>();
                

                while (rdr.Read())
                {
                    historial.Add(new Historial
                    {
                        codigo_historial = Int32.Parse(rdr["codigo_historial"].ToString()),
                        fecha_visita = Convert.ToDateTime(rdr["fecha_visita"]),
                        codigo_mascota = Int32.Parse(rdr["codigo_mascota"].ToString()),
                        titulo_visita = rdr["titulo_visita"].ToString(),
                        tema_visita = rdr["tema_visita"].ToString(),
                        codigo_veterinaria = Int32.Parse(rdr["codigo_veterinaria"].ToString()),
                        veterinario_visita = rdr["veterinario_visita"].ToString()


                    });
                }
                cmd.Connection.Close();
                cmd.Dispose();
                return historial;
            }
            catch (Exception)
            {
                throw;
            }

            

            
        }

    }
}
