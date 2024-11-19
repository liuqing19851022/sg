namespace PushPgToES.Interfaces
{
    public interface IPushDbToEs
    {

        Task PublishAllTable(string dbName, string tabName);

        Task PublishAllDataBase(string dbName);


        Task PublishAll();
    }
}
