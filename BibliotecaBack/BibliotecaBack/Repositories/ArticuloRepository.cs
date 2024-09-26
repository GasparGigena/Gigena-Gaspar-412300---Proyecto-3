using proyecto_Practica02_.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Biblioteca.Data;

namespace BibliotecaBack.Repositories
{
    public class ArticuloRepository : IArticuloRepositorio
    {
        public bool Delete(int id)
        {
            bool aux = true;
            SqlConnection conn = DBHelper.GetInstance().GetConnection();
            SqlTransaction t = null;

            try
            {
                conn.Open();
                t = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("SP_ELIMINAR_ARTICULO", conn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_articulo", id);
                cmd.ExecuteNonQuery();
                t.Commit();
            }
            catch (Exception)
            {
                if (t != null)
                {
                    t.Rollback();
                }
                aux = false;
            }
            finally
            {
                conn.Close();
            }

            return aux;
        }
        public List<Articulo> GetArticulos()
        {
            DataTable table = DBHelper.GetInstance().Consultar("SP_RECUPERAR_ARTICULOS");
            List<Articulo> lst = new List<Articulo>();

            foreach (DataRow row in table.Rows)
            {
                int cod = int.Parse(row["cod_articulo"].ToString());
                string nombre = row["articulo"].ToString();
                int precio = int.Parse(row["pre_unitario"].ToString());
                Articulo a = new Articulo(cod, nombre, precio);
                lst.Add(a);
            }
            return lst;
        }
        public bool Save(Articulo articulo)
        {
            bool aux = true;
            SqlConnection conn = DBHelper.GetInstance().GetConnection();
            SqlTransaction t = null;
            try
            {
                conn.Open();
                t = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("SP_INSERTAR_ARTICULO", conn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_articulo", articulo.Codigo);
                cmd.Parameters.AddWithValue("@articulo", articulo.Nombre);
                cmd.Parameters.AddWithValue("@pre_unitario", articulo.Precio);
                cmd.ExecuteNonQuery();

                t.Commit();
            }
            catch (Exception ex)
            {
                if (t != null)
                {
                    aux = false;
                    t.Rollback();
                }
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return aux;
        }
        public bool Update(Articulo articulo)
        {
            bool aux = true;
            SqlConnection conn = DBHelper.GetInstance().GetConnection();
            SqlTransaction t = null;

            try
            {
                conn.Open();
                t = conn.BeginTransaction();

                SqlCommand cmd = new SqlCommand("SP_UPDATE_ARTICULO2", conn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_articulo", articulo.Codigo);
                cmd.Parameters.AddWithValue("@descripcion", articulo.Nombre);
                cmd.Parameters.AddWithValue("@pre_unitario", articulo.Precio);
                cmd.ExecuteNonQuery();
                t.Commit();
            }
            catch (Exception)
            {
                if (t != null)
                {
                    t.Rollback();
                }
                aux = false;
            }
            finally
            {
                conn.Close();
            }
            return aux;
        }
    }
}
