using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace PollsDesktop.DATABASE.DAO
{
    // ObjectDAO is abstract class from whom all DAO objects inherit. It implements all methods from
    // interface IDAO. All child classes overrideS PrepareCommand and Read methods. All child classes also 
    // have to provide values to static Strings(SQL_SELECT, SQL_SELECT_ID, ....)
    abstract class ObjectDAO<T, F> : IDAO<T, F>
    {
        public static String SQL_SELECT, SQL_SELECT_ID, SQL_INSERT, SQL_DELETE_ID, SQL_UPDATE_ID;
        public virtual int Delete(F id, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@id", id);
            int ret = 0;
            try
            {
                ret = db.ExecuteNonQuery(command);
            }
            catch (Exception)
            {
                throw new ORMException("Cannot delete this entity! Maybe entity with this id doesn't exist?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        public virtual int Insert(T o, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, o);
            int ret = 0;
            try
            {
                ret = db.ExecuteNonQuery(command);
            }
            catch (Exception)
            {
                throw new ORMException("Cannot insert this entity! Maybe parameters are invalid?\n" +
                    "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }


            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        public Collection<T> Select(Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<T> objects = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return objects;
        }
        public virtual T Select(F id, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = db.Select(command);

            Collection<T> Objects = Read(reader);
            T obj = default(T);
            if (Objects.Count == 1)
            {
                obj = Objects[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }
            if (obj == null)
            {
                throw new ORMException("Invalid entity parameters! Entity doesn't exists in database!");
            }

            return obj;
        }
        public virtual int Update(T o, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }
            
            SqlCommand command = db.CreateCommand(SQL_UPDATE_ID);
            PrepareCommand(command, o);
            int ret = 0;
            try
            {
                ret = db.ExecuteNonQuery(command);
            }
            catch(Exception)
            {
                throw new ORMException("Cannot update this entity! Maybe entity with this id doesn't exist, or parameters are wrong?\n" +
          "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        public virtual void PrepareCommand(SqlCommand command, T o){}
        public virtual Collection<T> Read(SqlDataReader reader)
        {
            return null;
        }
    }
}
