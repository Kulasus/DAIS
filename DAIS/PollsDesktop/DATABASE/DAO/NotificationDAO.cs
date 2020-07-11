using PollsDesktop.DATABASE.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace PollsDesktop.DATABASE.DAO
{
    class NotificationDAO : ObjectDAO<NotificationDTO, int>
    {
        public static String SQL_SELECT_USER_LOGIN = "SELECT id, text, user_login FROM notifications WHERE user_login = @user_login;";
        public static String SQL_DELETE_USER_LOGIN = "DELETE FROM notifications WHERE user_login = @user_login;";
        public NotificationDAO()
        {
            SQL_SELECT = "SELECT id, text, user_login FROM notifications;";
            SQL_SELECT_ID = "SELECT id, text, user_login FROM notifications WHERE id = @id;";
            SQL_INSERT = "INSERT INTO notifications VALUES (@text, @user_login);";
            SQL_DELETE_ID = "DELETE FROM notifications WHERE id = @id";
            SQL_UPDATE_ID = "UPDATE notifications SET text=@text WHERE id = @id;";
        }
        public Collection<NotificationDTO> SelectByUserLogin(String userLogin, Database pDb)
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
            command.Parameters.AddWithValue("@user_login", userLogin);
            SqlDataReader reader = db.Select(command);

            Collection<NotificationDTO> objects = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return objects;
        }
        public int DeleteByUserLogin(String userLogin, Database pDb)
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
            SqlCommand command = db.CreateCommand(SQL_DELETE_USER_LOGIN);

            command.Parameters.AddWithValue("@user_login", userLogin);
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
        public override void PrepareCommand(SqlCommand command, NotificationDTO notification)
        {
            try
            {
                command.Parameters.AddWithValue("@id", notification.Id);
                command.Parameters.AddWithValue("@text", notification.Text);
                command.Parameters.AddWithValue("@user_login", notification.UserLogin);
            }
            catch (Exception)
            {
                throw new ORMException("Something went wrong while preparing execution command! Maybe parameters you provided are wrong?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
        }
        public override Collection<NotificationDTO> Read(SqlDataReader reader)
        {
            Collection<NotificationDTO> notifications = new Collection<NotificationDTO>();
            try
            {
                while (reader.Read())
                {
                    int i = -1;
                    NotificationDTO notification = new NotificationDTO();
                    notification.Id = reader.GetInt32(++i);
                    notification.Text = reader.GetString(++i);
                    notification.UserLogin = reader.GetString(++i);
                    notifications.Add(notification);
                }
            }
            catch (Exception)
            {
                throw new ORMException("Something went wrong while reading query result!\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
            return notifications;
        }
    }
}
