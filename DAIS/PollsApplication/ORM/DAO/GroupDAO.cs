using PollsApplication.ORM.DTO;
using System;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace PollsApplication.ORM.DAO
{
    class GroupDAO : ObjectDAO<GroupDTO,int>
    {
        public static String SQL_SELECT_USERS_MOST_ANSWERS = "EXEC seznam_uzivatelu_s_nejvice_odpovedmi @v_groupId = @var";
        public static String SQL_SELECT_MANAGER_LOGIN = "SELECT id, title, description, creation_date, manager_login FROM groups WHERE manager_login = @manager_login;";
        public GroupDAO()
        {
            SQL_SELECT = "SELECT id, title, description, creation_date, manager_login FROM groups;";
            SQL_SELECT_ID = "SELECT id, title, description, creation_date, manager_login FROM groups WHERE id = @id;";
            SQL_INSERT = "INSERT INTO groups(title, description, manager_login, creation_date) VALUES (@title, @description, @manager_login, CURRENT_TIMESTAMP);";
            SQL_DELETE_ID = "DELETE FROM groups WHERE id = @id";
            SQL_UPDATE_ID = "UPDATE groups SET title=@title, description=@description, manager_login=@manager_login WHERE id=@id";
        }
        public Collection<GroupDTO> SelectByManagerLogin(String login, Database pDb = null)
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
            command.Parameters.AddWithValue("@manager_login", login);
            SqlDataReader reader = db.Select(command);

            Collection<GroupDTO> objects = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return objects;
        }
        public override int Delete(int id, Database pDb = null)
        {
            /* OLD DELETING LOGIC NOW REPLACED WITH CASCADING IN DATABASE
            Collection<SurveyDTO> surveys = new SurveyDAO().SelectByGroupId(id, pDb);
            foreach (SurveyDTO survey in surveys)
            {
                new SurveyDAO().Delete(survey.Id, pDb);
            }
            Collection<GroupCategoryDTO> gruCats = new GroupCategoryDAO().SelectByGroupId(id, pDb);
            foreach (GroupCategoryDTO gruCat in gruCats)
            {
                new GroupCategoryDAO().DeleteCategoryFromGroup(id, gruCat.CategoryId, pDb);
            }
            */
            Collection<SurveyDTO> surveys = new SurveyDAO().SelectByGroupId(id, pDb);
            foreach (SurveyDTO survey in surveys)
            {
                SurveyDAO.ArchiveSurvey(survey.Id, pDb);
            }
            return base.Delete(id, pDb);
        }
        public Collection<String> SelectUsersWithMostAnswers(int groupId, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_USERS_MOST_ANSWERS);
            command.Parameters.AddWithValue("@var", groupId);
            Collection<String> objects = new Collection<String>();
            SqlDataReader reader = db.Select(command);
            while (reader.Read())
            {
                objects.Add(reader.GetString(0));
            }

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return objects;
        }
        public override void PrepareCommand(SqlCommand command, GroupDTO group)
        {
            try
            {
                command.Parameters.AddWithValue("@id", group.Id);
                command.Parameters.AddWithValue("@title", group.Title);
                command.Parameters.AddWithValue("@description", group.Description);
                command.Parameters.AddWithValue("@manager_login", group.ManagerLogin);
            }
            catch (Exception)
            {
                throw new ORMException("Something went wrong while preparing execution command! Maybe parameters you provided are wrong?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
        }
        public override Collection<GroupDTO> Read(SqlDataReader reader)
        {
            Collection<GroupDTO> groups = new Collection<GroupDTO>();
            try
            {
                while (reader.Read())
                {
                    int i = -1;
                    GroupDTO group = new GroupDTO();
                    group.Id = reader.GetInt32(++i);
                    group.Title = reader.GetString(++i);
                    if (!reader.IsDBNull(++i))
                    {
                        group.Description = reader.GetString(i);
                    }
                    group.CreationDate = reader.GetDateTime(++i);
                    group.ManagerLogin = reader.GetString(++i);
                    groups.Add(group);
                }
            }
            catch (Exception)
            {
                throw new ORMException("Something went wrong while reading query result!\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
            return groups;
        }
    }
}
