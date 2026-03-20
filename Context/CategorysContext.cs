using praktika27.Classes;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace praktika27.Context
{
    public class CategorysContext : Modell.Categorys
    {
        /// <summary> Метод загрузки данных из БД
        public static ObservableCollection<ItemsContext> AllCategorys()
        {
            ObservableCollection<ItemsContext> allCategorys = new ObservableCollection<ItemsContext>();
            SqlConnection connection;
            SqlDataReader dataCategorys = Connection.Query("SELECT * FROM [dbo].[Items]", out connection);
            while (dataCategorys.Read())
            {
                allCategorys.Add(new ItemsContext()
                {
                    Id = dataCategorys.GetInt32(0),
                    Name = dataCategorys.GetString(1)
                });
            }
            Connection.CloseConnection(connection);
            return allCategorys;
        }
    }
}
