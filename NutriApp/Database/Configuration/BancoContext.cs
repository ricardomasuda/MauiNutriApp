using System.Reflection;
using NutriApp.Models;
using SQLite;

namespace NutriApp.Database.Configuration;

public class BancoContext
{
    private static SQLiteAsyncConnection _database;

    public SQLiteAsyncConnection Connection()
    {
        try
        {
            string databasePath = Constantes.CaminhoDoBanco();

            Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            Stream embessedDatabaseStream = assembly.GetManifestResourceStream("NutriApp.nutridb.db3");

            if (!File.Exists(databasePath))
            {
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "nutridb.db3");
                FileStream fileStreamToWrite = File.Create(databasePath);
                embessedDatabaseStream.Seek(0, SeekOrigin.Begin);
                embessedDatabaseStream.CopyTo(fileStreamToWrite);
                fileStreamToWrite.Close();
                //throw new ArgumentException("Parameter cannot be null");
            }
            _database = new SQLiteAsyncConnection(databasePath);
            CreatTable();
            return _database;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }

    public void CreatTable()
    {
        _database.CreateTableAsync<FoodModel>();
        _database.CreateTableAsync<MealModel>();
        _database.CreateTableAsync<FoodPlanModel>();
        _database.CreateTableAsync<ValueReferenceModel>();
    }
}