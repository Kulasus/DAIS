using PollsApplication.ORM.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace PollsApplication.ORM.DAO
{
    class CategoryDAO : ObjectDAO<CategoryDTO, int>
    {
        public CategoryDAO()
        {
            SQL_SELECT = "SELECT id, title, description FROM categories;";
            SQL_SELECT_ID = "SELECT id, title, description FROM categories WHERE id = @id;";
            SQL_INSERT = "INSERT INTO categories VALUES (@title, @description);";
            SQL_DELETE_ID = "DELETE FROM categories WHERE id = @id";
            SQL_UPDATE_ID = "UPDATE categories SET title=@title, description=@description WHERE id = @id;";
        }
        public override void PrepareCommand(SqlCommand command, CategoryDTO category)
        {
            try
            {
                command.Parameters.AddWithValue("@id", category.Id);
                command.Parameters.AddWithValue("@title", category.Title);
                command.Parameters.AddWithValue("@description", category.Description == null ? DBNull.Value : (object)category.Description);
            }
            catch (Exception)
            {
                throw new ORMException("Something went wrong while preparing execution command! Maybe parameters you provided are wrong?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
        }
        public override Collection<CategoryDTO> Read(SqlDataReader reader)
        {
            Collection<CategoryDTO> categories = new Collection<CategoryDTO>();
            try
            {
                while (reader.Read())
                {
                    int i = -1;
                    CategoryDTO category = new CategoryDTO();
                    category.Id = reader.GetInt32(++i);
                    category.Title = reader.GetString(++i);
                    if (!reader.IsDBNull(++i))
                    {
                        category.Description = reader.GetString(i);
                    }
                    categories.Add(category);
                }
            }
            catch (Exception)
            {
                throw new ORMException("Something went wrong while reading query result!\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
            return categories;
        }
    }
}
