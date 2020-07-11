using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace PollsDesktop.DATABASE.DAO
{
    // IDAO is interface which defines what functions all DAO objects have to implement
    interface IDAO<T, F>
    {
        int Insert(T o, Database db);
        int Update(T o, Database db);
        Collection<T> Select(Database db);
        T Select(F id, Database db);
        int Delete(F id, Database db);
        void PrepareCommand(SqlCommand command, T o);
        Collection<T> Read(SqlDataReader reader);
    }
}
