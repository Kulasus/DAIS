using PollsDesktop.DATABASE.DTO;
using System;
using System.Data;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace PollsDesktop.DATABASE.DAO
{
    class SurveyDAO : ObjectDAO<SurveyDTO, int>
    {
        public static String SQL_UPDATE_STATE_START = "UPDATE surveys SET state_id=@state_id, start_date=@start_date WHERE id=@id;";
        public static String SQL_UPDATE_STATE_END = "UPDATE surveys SET state_id=@state_id, end_date=@end_date, duration=@duration WHERE id=@id;";
        public static String SQL_UPDATE_STATE_ARCHIVED = "UPDATE surveys SET state_id=@state_id WHERE id=@id;";
        public static String SQL_SELECT_GROUP_ID = "SELECT id, title, description, text, answers_percentage, creation_date, start_date, end_date, duration, group_id, state_id FROM surveys WHERE group_id=@group_id";
        public SurveyDAO()
        {
            SQL_SELECT = "SELECT id, title, description, text, answers_percentage, creation_date, start_date, end_date, duration, group_id, state_id FROM surveys;";
            SQL_SELECT_ID = "SELECT id, title, description, text, answers_percentage, creation_date, start_date, end_date, duration, group_id, state_id FROM surveys WHERE id = @id;";
            SQL_INSERT = "INSERT INTO surveys(title, description, text, answers_percentage, creation_date, start_date, end_date, group_id, state_id) VALUES (@title, @description, @text, NULL, CURRENT_TIMESTAMP, NULL, NULL, @group_id, 2);";
            SQL_DELETE_ID = "DELETE FROM surveys WHERE id = @id";
            SQL_UPDATE_ID = "UPDATE surveys SET title=@title, description=@description, text=@text WHERE id=@id;";
        }
        public Collection<SurveyDTO> SelectByGroupId(int id, Database pDb = null)
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

            Collection<SurveyDTO> objects = Read(reader);
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
            Collection<AnswerDTO> answers = new AnswerDAO().SelectBySurveyId(id, pDb);
            foreach(AnswerDTO answer in answers)
            {
                new AnswerDAO().Delete(answer.Id, pDb);
            }
            Collection<SurveyCategoryDTO> surCats = new SurveyCategoryDAO().SelectBySurveyId(id, pDb);
            foreach(SurveyCategoryDTO surCat in surCats)
            {
                new SurveyCategoryDAO().DeleteCategoryFromSurvey(id, surCat.CategoryId, pDb);
            }
            */
            return base.Delete(id, pDb);
        }
        public static void SetAnswerPercentage(int id, Database pDb = null)
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

            SqlCommand executeTransaction = db.CreateCommand("nastav_procenta_odpovedi");
            executeTransaction.CommandType = CommandType.StoredProcedure;

            executeTransaction.Parameters.AddWithValue("@p_surveyId", id);
            try
            {
                db.ExecuteNonQuery(executeTransaction);
            }
            catch (Exception)
            {
                throw new ORMException("Executing transaction failed! Maybe survey with this id does't exist?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
            if (pDb == null)
            {
                db.Close();
            }
        }
        public static void CopySurvey(int id, Database pDb = null)
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

            SurveyDTO survey = new SurveyDAO().Select(id, pDb);
            if(survey.StateId != 1)
            {
                throw new ORMException("Cannot copy unarchived survey!");
            }
            else
            {
                SqlCommand executeTransaction = db.CreateCommand("kopiruj_archivovany_dotaznik");
                executeTransaction.CommandType = CommandType.StoredProcedure;

                executeTransaction.Parameters.AddWithValue("@p_surveyId", id);
                try
                {
                    db.ExecuteNonQuery(executeTransaction);
                }
                catch (Exception)
                {
                    throw new ORMException("Executing transaction failed! Maybe survey with this id does't exist?\n" +
                    "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
                }
            }

            if (pDb == null)
            {
                db.Close();
            }
        }
        public static String SendStatistics(int id, Database pDb = null)
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

            SqlCommand executeTransaction = db.CreateCommand("zaslani_statistik");
            executeTransaction.CommandType = CommandType.StoredProcedure;

            executeTransaction.Parameters.AddWithValue("@p_surveyId", id);
            var returnParam = executeTransaction.Parameters.Add("@l_statistics", SqlDbType.NVarChar);
            returnParam.Direction = ParameterDirection.ReturnValue;
            try
            {
                db.ExecuteNonQuery(executeTransaction);
            }
            catch (Exception)
            {
                throw new ORMException("Executing transaction failed! Maybe survey with this id does't exist?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }

            if (pDb == null)
            {
                db.Close();
            }

            return executeTransaction.Parameters["@l_statistics"].Value.ToString();
        }
        public static void SendNotification(int id, Database pDb = null)
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

            SqlCommand executeTransaction = db.CreateCommand("zasli_upozorneni");
            executeTransaction.CommandType = CommandType.StoredProcedure;

            executeTransaction.Parameters.AddWithValue("@v_surveyId", id);
            try
            {
                db.ExecuteNonQuery(executeTransaction);
            }
            catch (Exception)
            {
                throw new ORMException("Executing transaction failed! Maybe survey with this id does't exist?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }

            if (pDb == null)
            {
                db.Close();
            }
        }
        public static void StartSurvey(int id, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_UPDATE_STATE_START);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@state_id", 3);
            command.Parameters.AddWithValue("@start_date", DateTime.Now);
            try
            {
                db.ExecuteNonQuery(command);
            }
            catch (Exception)
            {
                throw new ORMException("Executing sql statement failed! Maybe survey with this id does't exist?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }

            if (pDb == null)
            {
                db.Close();
            }

        }
        public static void EndSurvey(int id, Database pDb = null)
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

            SurveyDTO survey = new SurveyDAO().Select(id, pDb);
            TimeSpan? timespan = DateTime.Now - survey.StartDate;
            long? spanTicks = timespan.GetValueOrDefault().Ticks;

            SqlCommand command = db.CreateCommand(SQL_UPDATE_STATE_END);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@state_id", 4);
            command.Parameters.AddWithValue("@end_date", DateTime.Now);
            command.Parameters.AddWithValue("@duration", spanTicks);
            try
            {
                db.ExecuteNonQuery(command);
            }
            catch (Exception)
            {
                throw new ORMException("Executing sql statement failed! Maybe survey with this id does't exist?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }


            if (pDb == null)
            {
                db.Close();
            }
        }
        public static void ArchiveSurvey(int id, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_UPDATE_STATE_ARCHIVED);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@state_id", 1);
            try
            {
                db.ExecuteNonQuery(command);
            }
            catch (Exception)
            {
                throw new ORMException("Executing sql statement failed! Maybe survey with this id does't exist?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }

            if (pDb == null)
            {
                db.Close();
            }
        }
        public override void PrepareCommand(SqlCommand command, SurveyDTO survey)
        {
            try
            {
                command.Parameters.AddWithValue("@id", survey.Id);
                command.Parameters.AddWithValue("@title", survey.Title);
                command.Parameters.AddWithValue("@description", survey.Description);
                command.Parameters.AddWithValue("@text", survey.Text);
                command.Parameters.AddWithValue("@answers_percentage", survey.AnswersPercentage == null ? DBNull.Value : (object)survey.AnswersPercentage);
                command.Parameters.AddWithValue("@creation_date", survey.CreationDate == null ? DateTime.Now : (object)survey.CreationDate);
                command.Parameters.AddWithValue("@start_date", survey.StartDate == null ? DBNull.Value : (object)survey.StartDate);
                command.Parameters.AddWithValue("@end_date", survey.EndDate == null ? DBNull.Value : (object)survey.EndDate);
                command.Parameters.AddWithValue("@group_id", survey.GroupId);
                command.Parameters.AddWithValue("@state_id", survey.StateId);
            }
            catch (Exception)
            {
                throw new ORMException("Something went wrong while preparing execution command! Maybe parameters you provided are wrong?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
        }
        public override Collection<SurveyDTO> Read(SqlDataReader reader)
        {
            Collection<SurveyDTO> surveys = new Collection<SurveyDTO>();
            try
            {
                while (reader.Read())
                {
                    int i = -1;
                    SurveyDTO survey = new SurveyDTO();
                    survey.Id = reader.GetInt32(++i);
                    survey.Title = reader.GetString(++i);
                    if (!reader.IsDBNull(++i))
                    {
                        survey.Description = reader.GetString(i);
                    }
                    survey.Text = reader.GetString(++i);
                    if (!reader.IsDBNull(++i))
                    {
                        survey.AnswersPercentage = reader.GetInt32(i);
                    }
                    survey.CreationDate = reader.GetDateTime(++i);
                    if (!reader.IsDBNull(++i))
                    {
                        survey.StartDate = reader.GetDateTime(i);
                    }
                    if (!reader.IsDBNull(++i))
                    {
                        survey.EndDate = reader.GetDateTime(i);
                    }
                    if (!reader.IsDBNull(++i))
                    {
                        survey.Duration = reader.GetInt64(i);
                    }
                    survey.GroupId = reader.GetInt32(++i);
                    survey.StateId = reader.GetInt32(++i);
                    surveys.Add(survey);
                }
            }
            catch (Exception)
            {
                throw new ORMException("Something went wrong while reading query result!\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
            return surveys;
        }
    }
}
