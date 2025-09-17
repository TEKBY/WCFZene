using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using WCFZene.Models;

namespace WCFZene.Controllers
{
    public class EloadoController
    {
        static MySqlConnection SQLConnection;

        private static void BuildConnection()
        {
            string connectionString = "SERVER = localhost;" +
                                      "DATABASE= zene;" +
                                      "UID = root;" +
                                      "PASSWORD =;" +
                                      "SSL MODE= none;";
            SQLConnection = new MySqlConnection();
            SQLConnection.ConnectionString = connectionString;

        }

        public string EloadoTorlese(int id)
        {
            try
            {
                BuildConnection();
                SQLConnection.Open();
                string sql = "DELETE FROM eloado WHERE Id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, SQLConnection);
                cmd.Parameters.AddWithValue("@id", id);
                int sorokszama = cmd.ExecuteNonQuery();
                SQLConnection.Close();
                return sorokszama > 0 ? "Sikeres törlés" : "Hiba a törlés során";
            }
            catch (Exception ex)
            {
                if (SQLConnection.State == System.Data.ConnectionState.Open)
                    SQLConnection.Close();
                {
                    return "Hiba a törlés során: " + ex.Message;
                }
            }
        }

        public string EloadoModositasa(Eloado modositando)
        {
            try
            {
                BuildConnection();
                SQLConnection.Open();
                string sql = "UPDATE eloado SET Nev = @nev, Nemzetiseg = @nemzetiseg, Szolo = @szolo WHERE Id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, SQLConnection);
                cmd.Parameters.AddWithValue("@nev", modositando.Nev);
                cmd.Parameters.AddWithValue("@nemzetiseg", modositando.Nemzetiseg);
                cmd.Parameters.AddWithValue("@szolo", modositando.Szolo);
                cmd.Parameters.AddWithValue("@id", modositando.Id);
                int sorokszama = cmd.ExecuteNonQuery();
                SQLConnection.Close();
                return sorokszama > 0 ? "Sikeres módosítás" : "Hiba a módosítás során";
            }
            catch (Exception ex)
            {
                if (SQLConnection.State == System.Data.ConnectionState.Open)
                    SQLConnection.Close();
                {
                    return "Hiba a módosítás során: " + ex.Message;
                }
            }
        }

        public string EloadoFelvitele(Eloado rogzitendo)
        {
            try
            {
                BuildConnection();
                SQLConnection.Open();
                string sql = "INSERT INTO eloado(Nev, Nemzetiseg, Szolo) VALUES (@nev,@nemzetiseg,@szolo)";
                MySqlCommand cmd = new MySqlCommand(sql, SQLConnection);
                cmd.Parameters.AddWithValue("@nev", rogzitendo.Nev);
                cmd.Parameters.AddWithValue("@nemzetiseg", rogzitendo.Nemzetiseg);
                cmd.Parameters.AddWithValue("@szolo", rogzitendo.Szolo);
                int sorokszama = cmd.ExecuteNonQuery();
                SQLConnection.Close();
                return sorokszama > 0 ? "Sikeres felvitel" : "Hiba a rögzítésben";
            }
            catch (Exception ex)
            {
                if (SQLConnection.State == System.Data.ConnectionState.Open)
                    SQLConnection.Close();
                {
                    return "Hiba a rögzítésben: " + ex.Message;
                }
            }
        }

        public List<Eloado> EloadokListaja()
        {
            List<Eloado> eloadoLista = new List<Eloado>();
            try
            {
                BuildConnection();
                SQLConnection.Open();
                string sql = "SELECT * FROM eloado";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = SQLConnection;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Eloado eloado = new Eloado();
                    eloado.Id = reader.GetInt32("Id");
                    eloado.Nev = reader.GetString("Nev");
                    if (!reader.IsDBNull(2))
                        eloado.Nemzetiseg = reader.GetString("Nemzetiseg");
                    eloado.Szolo = reader.GetBoolean("Szolo");
                    eloadoLista.Add(eloado);
                }
                SQLConnection.Close();
                return eloadoLista;
            }

            catch (Exception ex)
            {
                Eloado hiba = new Eloado()
                {
                    Id = 0,
                    Nev = ex.Message
                };
                eloadoLista.Add(hiba);
                return eloadoLista;
            }
        }
    }
}