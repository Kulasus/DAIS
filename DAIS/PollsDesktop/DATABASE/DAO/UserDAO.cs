using System;
using System.Data;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using PollsDesktop.DATABASE.DTO;

namespace PollsDesktop.DATABASE.DAO
{
    class UserDAO : ObjectDAO<UserDTO, String>
    {
        public UserDAO()
        {
            SQL_SELECT = "SELECT login, fname, lname, email, last_visit, role_id, state FROM users;";
            SQL_SELECT_ID = "SELECT login, fname, lname, email, last_visit, role_id, state FROM users WHERE login = @login;";
            SQL_INSERT = "INSERT INTO users(login, fname, lname, email, last_visit, role_id, state) VALUES (@login, @fname, @lname, @email, @last_visit, @role_id, @state);";
            SQL_DELETE_ID = "DELETE FROM users WHERE login = @login";
            SQL_UPDATE_ID = "UPDATE users SET fname=@fname, lname=@lname, email=@email, last_visit=@last_visit, role_id=@role_id, state=@state WHERE login=@login";
        }
        public void ChangeUserRoleToManager(String login, Database pDb)
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
            SqlCommand executeTransaction = db.CreateCommand("zmen_roli_uzivatele_na_manazera");
            executeTransaction.CommandType = CommandType.StoredProcedure;

            executeTransaction.Parameters.AddWithValue("@p_userLogin", login);

            try
            {
                db.ExecuteNonQuery(executeTransaction);
            }
            catch (Exception)
            {
                throw new ORMException("Executing transaction failed! Maybe user with this id does't exist?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }

            if (pDb == null)
            {
                db.Close();
            }
        }
        public override int Insert(UserDTO o, Database pDb = null)
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
            if (o.Login == null)
            {
                o.Login = GenerateLogin(o.Fname, o.Lname, db);
            }
            PrepareCommand(command, o);
            int ret = 0;
            try
            {
                ret = db.ExecuteNonQuery(command);
            }
            catch (Exception)
            {
                throw new ORMException("Inserting user failed! Maybe parameters are invalid?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }

            SetActivity(o.Login, db);

            if (pDb == null)
            {
                db.Close();
            }
            

            return ret;
        }
        public override int Update(UserDTO o, Database pDb = null)
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

            int ret = 0;
            try
            {
                SqlCommand command = db.CreateCommand(SQL_UPDATE_ID);
                PrepareCommand(command, o);
                ret = db.ExecuteNonQuery(command);
                SetActivity(o.Login, db);
            }
            catch (Exception)
            {
                throw new ORMException("Updating user failed! Maybe user with this id does't exist?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }


            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        public override UserDTO Select(String id, Database pDb = null)
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

            command.Parameters.AddWithValue("@login", id);
            SqlDataReader reader = db.Select(command);

            Collection<UserDTO> Objects = Read(reader);
            UserDTO obj = default(UserDTO);
            if (Objects.Count == 1)
            {
                obj = Objects[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            if(obj == null)
            {
                throw new ORMException("Invalid entity parameters! Entity doesn't exists in database!");
            }

            return obj;
        }
        public override int Delete(String id, Database pDb = null)
        {
            /* OLD DELETING LOGIC NOW REPLACED WITH CASCADING IN DATABASE
            UserDTO user = Select(id, pDb);
            if(user.RoleId == 2)
            {
                Collection<GroupDTO> groups = new GroupDAO().SelectByManagerLogin(id, pDb);
                foreach(GroupDTO group in groups)
                {
                    new GroupDAO().Delete(group.Id, pDb);
                }
            }
            Collection<UserGroupDTO> userGroups = new UserGroupDAO().SelectByUserLogin(id, pDb);
            foreach(UserGroupDTO userGroup in userGroups)
            {
                new UserGroupDAO().DeleteUserFromGroup(userGroup.GroupId, id);
            }
            new NotificationDAO().DeleteByUserLogin(id, pDb);
            */
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
            command.Parameters.AddWithValue("@login", id);
            int ret = 0;
            try
            {
                ret = db.ExecuteNonQuery(command);
            }
            catch (Exception)
            {
                throw new ORMException("Deleting user failed! Maybe user with this id does't exist?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        public override void PrepareCommand(SqlCommand command, UserDTO user)
        {
            try
            {
                command.Parameters.AddWithValue("@login", user.Login);
                command.Parameters.AddWithValue("@fname", user.Fname);
                command.Parameters.AddWithValue("@lname", user.Lname);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@last_visit", user.LastVisit == null ? DBNull.Value : (object)user.LastVisit);
                command.Parameters.AddWithValue("@role_id", user.RoleId);
                command.Parameters.AddWithValue("@state", user.State);
            }
            catch (Exception)
            {
                throw new ORMException("Something went wrong while preparing execution command! Maybe parameters you provided are wrong?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
        }
        public static String GenerateLogin(String name, String surname, Database pDb)
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

            SqlCommand executeTransaction = db.CreateCommand("vygenerovani_loginu");
            executeTransaction.CommandType = CommandType.StoredProcedure;

            executeTransaction.Parameters.AddWithValue("@p_name", name);
            executeTransaction.Parameters.AddWithValue("@p_surname", surname);
            var returnParam = executeTransaction.Parameters.Add("@login", SqlDbType.Char, 10);
            returnParam.Direction = ParameterDirection.ReturnValue;

            try
            {
                db.ExecuteNonQuery(executeTransaction);
            }
            catch (Exception)
            {
                throw new ORMException("Executing transaction failed!\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }

            if (pDb == null)
            {
                db.Close();
            }

            return executeTransaction.Parameters["@login"].Value.ToString(); 
        }
        public static void SetActivity(String login, Database pDb)
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
            SqlCommand executeTransaction = db.CreateCommand("nastav_aktivitu_uzivatele");
            executeTransaction.CommandType = CommandType.StoredProcedure;

            executeTransaction.Parameters.AddWithValue("@p_userLogin", login);

            try
            {
                db.ExecuteNonQuery(executeTransaction);
            }
            catch (Exception)
            {
                throw new ORMException("Executing transaction failed! Maybe user with this id does't exist?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
            if (pDb == null)
            {
                db.Close();
            }

        }
        public static int GetUserAnswersPercentage(String login, Database pDb)
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

            SqlCommand executeTransaction = db.CreateCommand("vypocitej_procento_odpovedi_uzivatele");
            executeTransaction.CommandType = CommandType.StoredProcedure;

            executeTransaction.Parameters.AddWithValue("@v_userLogin", login);
            var returnParam = executeTransaction.Parameters.Add("@l_ans", SqlDbType.Int);
            returnParam.Direction = ParameterDirection.ReturnValue;

            try
            {
                db.ExecuteNonQuery(executeTransaction);
            }
            catch (Exception)
            {
                throw new ORMException("Executing transaction failed! Maybe user with this id does't exist?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }

            if (pDb == null)
            {
                db.Close();
            }

            return (int)executeTransaction.Parameters["@l_ans"].Value;

        }
        public override Collection<UserDTO> Read(SqlDataReader reader)
        {
            Collection<UserDTO> users = new Collection<UserDTO>();
            try
            {
                while (reader.Read())
                {
                    int i = -1;
                    UserDTO user = new UserDTO();
                    user.Login = reader.GetString(++i);
                    user.Fname = reader.GetString(++i);
                    user.Lname = reader.GetString(++i);
                    user.Email = reader.GetString(++i);
                    if (!reader.IsDBNull(++i))
                    {
                        user.LastVisit = reader.GetDateTime(i);
                    }
                    user.RoleId = reader.GetInt32(++i);
                    user.State = reader.GetString(++i);
                    users.Add(user);
                }
            }
            catch (Exception)
            {
                throw new ORMException("Something went wrong while reading query result!\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
            return users;
        }
    }
}
