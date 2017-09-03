using SQLite.Net;

namespace PaladinsStats.Business.Interfaces

{
    public interface ISqliteConnectionService
    {
        SQLiteConnection GetConnection();
    }
}
