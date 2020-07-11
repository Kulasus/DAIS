using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;
using PollsDesktop.DATABASE.DTO;

namespace PollsDesktop.DATABASE.DAO
{
    class UserGroupDAO : ObjectDAO<UserGroupDTO, int>
    {
        public static String SQL_SELECT_USER_LOGIN = "SELECT user_login, group_id FROM users_groups WHERE user_login=@user_login";
        public static String SQL_SELECT_GROUP_ID = "SELECT user_login, group_id FROM users_groups WHERE group_id=@group_id";
        public UserGroupDAO()
        {
            SQL_SELECT = "SELECT user_login, group_id FROM users_groups;";
            SQL_INSERT = "INSERT INTO users_groups(user_login, group_id) VALUES (@user_login, @group_id);";
            SQL_DELETE_ID = "DELETE FROM users_groups WHERE (user_login = @user_login AND group_id = @group_id)";
        }
        public int DeleteUserFromGroup(int groupId, String userLogin, Database pDb = null)
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

            command.Parameters.AddWithValue("@user_login", userLogin);
            command.Parameters.AddWithValue("@group_id", groupId);
            int ret = 0;
            try
            {
                ret = db.ExecuteNonQuery(command);
            }
            catch (Exception)
            {
                throw new ORMException("Deleting failed! Maybe parameters are invalid?\n" +
                    "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        public override int Delete(int id, Database pDb = null)
        {
            throw new ORMException("Cannnot delete by id in binding table! To delete user from group use DeleteUserFromGroup method.");
        }
        public override UserGroupDTO Select(int id, Database pDb = null)
        {
            throw new ORMException("Cannot select by id in binding table!");
        }
        public override int Insert(UserGroupDTO o, Database pDb = null)
        {
            UserDTO user = new UserDAO().Select(o.UserLogin, pDb);
            if(user.RoleId == 2) //manager
            {
                throw new ORMException("Cannot add manager to group!");
            }
            return base.Insert(o, pDb);
        }
        public Collection<UserGroupDTO> SelectByGroupId(int id, Database pDb)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_GROUP_ID);
            command.Parameters.AddWithValue("@group_id", id);
            SqlDataReader reader = db.Select(command);

            Collection<UserGroupDTO> objects = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return objects;
        }
        public Collection<UserGroupDTO> SelectByUserLogin(String login, Database pDb)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_USER_LOGIN);
            command.Parameters.AddWithValue("@user_login", login);
            SqlDataReader reader = db.Select(command);

            Collection<UserGroupDTO> objects = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return objects;
        }
        public override int Update(UserGroupDTO o, Database pDb = null)
        {
            throw new ORMException("Cannot update in binding table!");
        }
        public override void PrepareCommand(SqlCommand command, UserGroupDTO userGroup)
        {
            try
            {
                command.Parameters.AddWithValue("@user_login", userGroup.UserLogin);
                command.Parameters.AddWithValue("@group_id", userGroup.GroupId);
            }
            catch (Exception)
            {
                throw new ORMException("Something went wrong while preparing execution command! Maybe parameters you provided are wrong?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
        }
        public override Collection<UserGroupDTO> Read(SqlDataReader reader)
        {
            Collection<UserGroupDTO> userGroups = new Collection<UserGroupDTO>();
            try
            {
                while (reader.Read())
                {
                    int i = -1;
                    UserGroupDTO userGroup = new UserGroupDTO();
                    userGroup.UserLogin = reader.GetString(++i);
                    userGroup.GroupId = reader.GetInt32(++i);
                    userGroups.Add(userGroup);
                }
            }
            catch (Exception)
            {
                throw new ORMException("Something went wrong while reading query result!\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
            return userGroups;
        }
    }
}
