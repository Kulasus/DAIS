using PollsApplication.ORM.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace PollsApplication.ORM.DAO
{
    class SurveyCategoryDAO : ObjectDAO<SurveyCategoryDTO, int>
    {
        public static String SQL_SELECT_CATEGORY_ID = "SELECT * FROM surveys_categories WHERE category_id=@category_id";
        public static String SQL_SELECT_GROUP_ID = "SELECT * FROM surveys_categories WHERE survey_id=@survey_id";
        public SurveyCategoryDAO()
        {
            SQL_SELECT = "SELECT * FROM surveys_categories;";
            SQL_INSERT = "INSERT INTO surveys_categories(survey_id, category_id) VALUES (@survey_id, @category_id);";
            SQL_DELETE_ID = "DELETE FROM surveys_categories WHERE (survey_id = @survey_id AND category_id = @category_id)";
        }
        public int DeleteCategoryFromSurvey(int surveyId, int categoryId, Database pDb = null)
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
            command.Parameters.AddWithValue("@survey_id", surveyId);
            int ret = 0;
            try
            {
                ret = db.ExecuteNonQuery(command);
            }
            catch (Exception)
            {
                throw new ORMException("Ooops..something went wrong! Maybe entity with this id doesn't exist? If problem" +
                    "persist, please contact our support on lukas.kondiolka.st@vsb.cz" );
            }

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        public override int Delete(int id, Database pDb = null)
        {
            throw new ORMException("Cannnot delete by id in binding table! To delete category from survey use DeleteCategoryFromSurvey method.");
        }
        public override SurveyCategoryDTO Select(int id, Database pDb = null)
        {
            throw new ORMException("Cannot select by id in binding table!");
        }
        public Collection<SurveyCategoryDTO> SelectBySurveyId(int id, Database pDb)
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
            command.Parameters.AddWithValue("@survey_id", id);
            SqlDataReader reader = db.Select(command);

            Collection<SurveyCategoryDTO> objects = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return objects;
        }
        public Collection<SurveyCategoryDTO> SelectByCategoryId(int id, Database pDb)
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

            Collection<SurveyCategoryDTO> objects = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return objects;
        }
        public override int Update(SurveyCategoryDTO o, Database pDb = null)
        {
            throw new ORMException("Cannot update in binding table!");
        }
        public override void PrepareCommand(SqlCommand command, SurveyCategoryDTO surveyCategory)
        {
            try
            {
                command.Parameters.AddWithValue("@category_id", surveyCategory.CategoryId);
                command.Parameters.AddWithValue("@survey_id", surveyCategory.SurveyId);
            }
            catch (Exception)
            {
                throw new ORMException("Something went wrong while preparing execution command! Maybe parameters you provided are wrong?\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
        }
        public override Collection<SurveyCategoryDTO> Read(SqlDataReader reader)
        {
            Collection<SurveyCategoryDTO> surveyCategories = new Collection<SurveyCategoryDTO>();
            try
            {
                while (reader.Read())
                {
                    int i = -1;
                    SurveyCategoryDTO surveyCategory = new SurveyCategoryDTO();
                    surveyCategory.CategoryId = reader.GetInt32(++i);
                    surveyCategory.SurveyId = reader.GetInt32(++i);
                    surveyCategories.Add(surveyCategory);
                }
            }
            catch (Exception)
            {
                throw new ORMException("Something went wrong while reading query result!\n" +
                "If problem persist, please contact our support on lukas.kondiolka.st@vsb.cz");
            }
            return surveyCategories;
        }
    }
}
