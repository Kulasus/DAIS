using PollsDesktop.DATABASE.DTO;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace PollsDesktop.DATABASE.DAO
{
    class AnswerDAO : ObjectDAO<AnswerDTO, int>
    {
        public static string SQL_SELECT_SURVEY_ID = "SELECT * FROM answers WHERE survey_id=@survey_id";
        public AnswerDAO()
        {
            SQL_SELECT = "SELECT * FROM answers;";
            SQL_SELECT_ID = "SELECT * FROM answers WHERE id = @id;";
            SQL_INSERT = "INSERT INTO answers(text, creation_date, user_login, survey_id) VALUES (@text, CURRENT_TIMESTAMP, @user_login, @survey_id);";
            SQL_DELETE_ID = "DELETE FROM answers WHERE id = @id;";
            //SQL_UPDATE_ID = "UPDATE answers SET title=@title, description=@description, text=@text, start_date=@start_date, end_date=@end_date WHERE id=@id;";
        }
        public Collection<AnswerDTO> SelectBySurveyId(int id, Database pDb)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_SURVEY_ID);
            command.Parameters.AddWithValue("@survey_id", id);
            SqlDataReader reader = db.Select(command);

            Collection<AnswerDTO> objects = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return objects;
        }
        public override int Update(AnswerDTO o, Database pDb = null)
        {
            throw new ORMException("Cannot modify answers!");
        }
        public override void PrepareCommand(SqlCommand command, AnswerDTO answer)
        {
            try
            {
                command.Parameters.AddWithValue("@id", answer.Id);
                command.Parameters.AddWithValue("@text", answer.Text);
                command.Parameters.AddWithValue("@user_login", answer.UserLogin);
                command.Parameters.AddWithValue("@survey_id", answer.SurveyId);
            }
            catch (Exception )
            {
                throw new ORMException("Something went wrong while preparing execution command! Maybe parameters you provided are wrong?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }

        }
        public override Collection<AnswerDTO> Read(SqlDataReader reader)
        {
            Collection<AnswerDTO> answers = new Collection<AnswerDTO>();
            try
            {
                while (reader.Read())
                {
                    int i = -1;
                    AnswerDTO answer = new AnswerDTO();
                    answer.Id = reader.GetInt32(++i);
                    answer.Text = reader.GetString(++i);
                    answer.CreationDate = reader.GetDateTime(++i);
                    answer.UserLogin = reader.GetString(++i);
                    answer.SurveyId = reader.GetInt32(++i);
                    answers.Add(answer);
                }
            }
            catch (Exception)
            {
                throw new ORMException("Something went wrong while reading query result!\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
            return answers;
        }
    }
}
