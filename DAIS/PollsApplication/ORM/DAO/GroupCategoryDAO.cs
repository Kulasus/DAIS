using PollsApplication.ORM.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace PollsApplication.ORM.DAO
{
    class GroupCategoryDAO : ObjectDAO<GroupCategoryDTO, int>
    {
        public static String SQL_SELECT_CATEGORY_ID = "SELECT category_id, group_id FROM groups_categories WHERE category_id=@category_id";
        public static String SQL_SELECT_GROUP_ID = "SELECT category_id, group_id FROM groups_categories WHERE group_id=@group_id";
        public GroupCategoryDAO()
        {
            SQL_SELECT = "SELECT category_id, group_id FROM groups_categories;";
            SQL_INSERT = "INSERT INTO groups_categories(group_id, category_id) VALUES (@group_id, @category_id);";
            SQL_DELETE_ID = "DELETE FROM groups_categories WHERE (group_id = @group_id AND category_id = @category_id)";
        }
        public int DeleteCategoryFromGroup(int groupId, int categoryId, Database pDb = null)
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

            command.Parameters.AddWithValue("@category_id", categoryId);
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
            throw new ORMException("Cannnot delete by id in binding table! To delete category from group use DeleteCategoryFromGroup method.");
        }
        public override GroupCategoryDTO Select(int id, Database pDb = null)
        {
            throw new ORMException("Cannot select by id in binding table!");
        }
        public Collection<GroupCategoryDTO> SelectByGroupId(int id, Database pDb)
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

            Collection<GroupCategoryDTO> objects = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return objects;
        }
        public Collection<GroupCategoryDTO> SelectByCategoryId(int id, Database pDb)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_CATEGORY_ID);
            command.Parameters.AddWithValue("@category_id", id);
            SqlDataReader reader = db.Select(command);

            Collection<GroupCategoryDTO> objects = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return objects;
        }
        public override int Update(GroupCategoryDTO o, Database pDb = null)
        {
            throw new ORMException("Cannot update in binding table!");
        }
        public override void PrepareCommand(SqlCommand command, GroupCategoryDTO groupCategory)
        {
            try
            {
                command.Parameters.AddWithValue("@category_id", groupCategory.CategoryId);
                command.Parameters.AddWithValue("@group_id", groupCategory.GroupId);
            }
            catch (Exception)
            {
                throw new ORMException("Something went wrong while preparing execution command! Maybe parameters you provided are wrong?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
        }
        public override Collection<GroupCategoryDTO> Read(SqlDataReader reader)
        {
            Collection<GroupCategoryDTO> groupCategories = new Collection<GroupCategoryDTO>();
            try
            {
                while (reader.Read())
                {
                    int i = -1;
                    GroupCategoryDTO groupCategory = new GroupCategoryDTO();
                    groupCategory.CategoryId = reader.GetInt32(++i);
                    groupCategory.GroupId = reader.GetInt32(++i);
                    groupCategories.Add(groupCategory);
                }
            }
            catch (Exception)
            {
                throw new ORMException("Something went wrong while reading query result!\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
            return groupCategories;
        }
    }
}
