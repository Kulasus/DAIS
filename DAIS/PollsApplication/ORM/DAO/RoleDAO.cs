using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using PollsApplication.ORM.DTO;

namespace PollsApplication.ORM.DAO
{
    class RoleDAO : ObjectDAO<RoleDTO, int>
    {
        public RoleDAO()
        {
            SQL_SELECT = "SELECT id, title, description FROM roles;";
            SQL_SELECT_ID = "SELECT id, title, description FROM roles WHERE id = @id;";
            SQL_INSERT = "INSERT INTO roles VALUES (@title, @description);";
            SQL_DELETE_ID = "DELETE FROM roles WHERE id = @id";
            SQL_UPDATE_ID = "UPDATE roles SET title=@title, description=@description WHERE id = @id;";
        }
        public override void PrepareCommand(SqlCommand command, RoleDTO role)
        {
            try
            {
                command.Parameters.AddWithValue("@id", role.ID);
                command.Parameters.AddWithValue("@title", role.Title);
                command.Parameters.AddWithValue("@description", role.Description == null ? DBNull.Value : (object)role.Description);
            }
            catch (Exception)
            {
                throw new ORMException("Something went wrong while preparing execution command! Maybe parameters you provided are wrong?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
        }
        public  override Collection<RoleDTO> Read(SqlDataReader reader)
        {
            Collection<RoleDTO> roles = new Collection<RoleDTO>();
            try
            {
                while (reader.Read())
                {
                    int i = -1;
                    RoleDTO role = new RoleDTO();
                    role.ID = reader.GetInt32(++i);
                    role.Title = reader.GetString(++i);
                    if (!reader.IsDBNull(++i))
                    {
                        role.Description = reader.GetString(i);
                    }
                    roles.Add(role);
                }
            }
            catch (Exception)
            {
                throw new ORMException("Something went wrong while reading query result!\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
            return roles;
        }
    }
}
