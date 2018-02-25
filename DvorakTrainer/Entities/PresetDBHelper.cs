using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvorakTrainer.Entities
{
    class PresetDBHelper
    {
        private static SQLiteConnection m_dbConnection;

        public static void createNewDatabase()
        {
            SQLiteConnection.CreateFile("DvorakPresets.sqlite");
        }

        public static void connectToDatabase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=DvorakPresets.sqlite;Version=3;");
            m_dbConnection.Open();
        }

        public static void createTable()
        {
            string sql = "create table if not exists userPresets (name varchar(20), list varchar(300))";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        public static void InsertDefault()
        {
            string sql = "INSERT INTO 'userPresets' ('name', 'list') VALUES ('Home Row', '42 43 44 45 46 47 48 49 50 51')";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        public static void InsertDB(Preset preset)
        {
            string sql = "INSERT INTO 'userPresets' ('name', 'list') VALUES ('" + preset.Name + "', '" + preset.UserList + "')";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        public static void printPresetsComboBox(ComboBox comboBox)
        {
            string sql = "select * from userPresets";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox.Items.Add(reader[0]);
            }

            m_dbConnection.Close();
        }

        public static string getPresetList(string presetName)
        {
            
            string sql = "select * from userPresets where name = '"+presetName+"'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            string preset = "";

            while (reader.Read())
            {
                preset = (reader[1].ToString());
            }

            m_dbConnection.Close();

            return preset;

        }

    }
}
