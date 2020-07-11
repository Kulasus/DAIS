using PollsApplication.ORM.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace PollsApplication.ORM.DAO
{
    class StateDAO : ObjectDAO<StateDTO, int>
    {
        public StateDAO()
        {
            SQL_SELECT = "SELECT id, title FROM states;";
            SQL_SELECT_ID = "SELECT id, title FROM states WHERE id = @id;";
            SQL_INSERT = "INSERT INTO states VALUES (@title);";
            SQL_DELETE_ID = "DELETE FROM states WHERE id = @id";
            SQL_UPDATE_ID = "UPDATE states SET title=@title WHERE id = @id;";
        }
        public override void PrepareCommand(SqlCommand command, StateDTO state)
        {
            try
            {
                command.Parameters.AddWithValue("@id", state.Id);
                command.Parameters.AddWithValue("@title", state.Title);
            }
            catch (Exception)
            {
                throw new ORMException("Something went wrong while preparing execution command! Maybe parameters you provided are wrong?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
        }
        public override Collection<StateDTO> Read(SqlDataReader reader)
        {
            Collection<StateDTO> states = new Collection<StateDTO>();
            try
            {
                while (reader.Read())
                {
                    int i = -1;
                    StateDTO state = new StateDTO();
                    state.Id = reader.GetInt32(++i);
                    state.Title = reader.GetString(++i);
                    states.Add(state);
                }
            }
            catch (Exception)
            {
                throw new ORMException("Something went wrong while reading query result!\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
            return states;
        }

    }
}
