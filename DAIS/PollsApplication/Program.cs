using System;
using System.Collections.ObjectModel;
using PollsApplication.ORM.DTO;
using PollsApplication.ORM;
using PollsApplication.ORM.DAO;


namespace PollsApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();
            bool connection = db.Connect();




            //-----------TESTS------------
            /* Uncomment those you want to test. I recommend uncommenting only one at the time. */
            //Tests.Users(db);
            //Tests.Roles(db);
            //Tests.Groups(db);
            //Tests.UserGroups(db);
            //Tests.Notifications(db);
            //Tests.Categories(db);
            //Tests.States(db);
            //Tests.GroupCategories(db);
            //Tests.Surveys(db);
            //Tests.Answers(db);
            //Tests.SurveyCategories(db);
        }
    }
}
