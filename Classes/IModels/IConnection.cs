using MySql.Data.MySqlClient;

namespace SystemInventory.Classes.IModels
{
    public interface IConnection
    {
        MySqlConnection GetConnection();
        void CloseConnection();

        void VerifyDatabaseConnection();
    }
}
