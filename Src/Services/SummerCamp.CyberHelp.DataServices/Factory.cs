using SummerCamp.CyberHelp.DataServices.Helpers;
using SummerCamp.CyberHelp.DataServices.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;

namespace SummerCamp.CyberHelp.DataServices
{
    public class Factory
    {
        #region DECLARATIONS

        private string _connectionString = "Server=tcp:summercamp.database.windows.net,1433;Initial Catalog=CyberHelpDb;Persist Security Info=False;User ID=summercampadmin;Password=trasys@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private static SqlConnection _connection = null;

        #endregion //DECLARATIONS

        #region CONSTRUCTORS

        public Factory()
        {
            if (!String.IsNullOrEmpty(_connectionString))
            {
                if (_connection == null)
                    _connection = new SqlConnection(_connectionString);
            }
            else
            {
                throw new NullReferenceException("Connection is null");
            }
        }

        #endregion

        #region METHODS

        #region ALERT

        public IEnumerable<Alert> GetAlerts()
        {
            using (SqlDatabaseCommand cmd = GetDatabaseCommand())
            {
                cmd.CommandText.AppendLine(" SELECT * FROM CyberAlert");

                IEnumerable<Alert> alerts = cmd.ExecuteTable<Alert>();
                return alerts;

            }
        }


        public Alert GetAlert(long id)
        {
            using (SqlDatabaseCommand cmd = GetDatabaseCommand())
            {
                cmd.CommandText.AppendLine($" SELECT * FROM CyberAlert WHERE CyberAlertID = {id}");

                Alert alert = cmd.ExecuteRow<Alert>();
                return alert;

            }
        }

        public long CreateAlert(Alert alertToCreate)
        {
            using (SqlDatabaseCommand cmd = this.GetDatabaseCommand())
            {
                cmd.CommandText.AppendLine("INSERT INTO [CyberAlert] ([Coordinates],[CyberAlertType],[Comment],[CyberHelpUserID],[StatusCode]) ");
                cmd.CommandText.AppendLine(" VALUES(@Coordinates, @AlertType, @Comment,@CyberHelpUserID, 'N')");
                cmd.Parameters.Add(new SqlParameter("@Coordinates", alertToCreate.Coordinates));
                cmd.Parameters.Add(new SqlParameter("@AlertType", alertToCreate.CyberAlertType));
                cmd.Parameters.Add(new SqlParameter("@Comment", alertToCreate.Comment));
                cmd.Parameters.Add(new SqlParameter("@CyberHelpUserID", alertToCreate.CyberHelpUserID));

                cmd.CommandText.AppendLine(" SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]; ");

                decimal id = cmd.ExecuteScalar<decimal>();

                SendNotification(NotificationType.AlertSent, 0);

                return (long)id;
            }
        }
        #endregion

        #region STUDENT

        public CyberHelpUser GetStudent(long studentID)
        {
            IEnumerable<CyberHelpUser> students = this.GetStudents(studentID);
            if (students == null)
            {
                return null;
            }
            else
            {
                return students.FirstOrDefault();
            }
        }

        public IEnumerable<CyberHelpUser> GetStudents()
        {
            return this.GetStudents(null);
        }

        public IEnumerable<CyberHelpUser> GetTeachers()
        {
            return this.GetTeachers(null);
        }

        public CyberHelpUser GetTeacher(long teacherID)
        {
            IEnumerable<CyberHelpUser> teachers = this.GetTeachers(teacherID);
            if (teachers == null)
            {
                return null;
            }
            else
            {
                return teachers.FirstOrDefault();
            }
        }

        private IEnumerable<CyberHelpUser> GetTeachers(long? id)
        {
            using (SqlDatabaseCommand cmd = GetDatabaseCommand())
            {
                cmd.CommandText.AppendLine(" SELECT * FROM CyberHelpUser ");
                cmd.CommandText.AppendLine("  INNER JOIN ClassRoom ON ClassRoom.ClassRoomID = CyberHelpUser.ClassRoomID                ");
                cmd.CommandText.AppendLine("  INNER JOIN School ON ClassRoom.SchoolID = School.SchoolID ");
                cmd.CommandText.AppendLine(" WHERE CyberHelpUserType = 'T'");
                if (id.HasValue)
                {
                    cmd.CommandText.AppendLine(" AND CyberHelpUserID = @studentID");
                    cmd.Parameters.Add(new SqlParameter("@studentID", id.Value));
                }

                IEnumerable<CyberHelpUser> teachers = cmd.ExecuteTable<CyberHelpUser>();
                return teachers;

            }
            //return new Student[] { new Student { ClassRoomID = 1, CyberHelpYear = 5, Login = "mfiorito", StudentID = 1 } };
        }

        private IEnumerable<CyberHelpUser> GetStudents(long? id)
        {
            using (SqlDatabaseCommand cmd = GetDatabaseCommand())
            {
                cmd.CommandText.AppendLine(" SELECT * FROM CyberHelpUser ");
                cmd.CommandText.AppendLine("  INNER JOIN ClassRoom ON ClassRoom.ClassRoomID = CyberHelpUser.ClassRoomID                ");
                cmd.CommandText.AppendLine("  INNER JOIN School ON ClassRoom.SchoolID = School.SchoolID ");
                cmd.CommandText.AppendLine(" WHERE CyberHelpUserType = 'S'");
                if (id.HasValue)
                {
                    cmd.CommandText.AppendLine(" AND CyberHelpUserID = @studentID");
                    cmd.Parameters.Add(new SqlParameter("@studentID", id.Value));
                }

                IEnumerable<CyberHelpUser> students = cmd.ExecuteTable<CyberHelpUser>();
                return students;

            }
            //return new Student[] { new Student { ClassRoomID = 1, CyberHelpYear = 5, Login = "mfiorito", StudentID = 1 } };
        }

        public void ChangeAlertStatus(long alertID, string newStatus)
        {
            using (SqlDatabaseCommand cmd = this.GetDatabaseCommand())
            {
                cmd.CommandText.AppendLine("UPDATE [CyberAlert] SET StatusCode = @StatusCode WHERE CyberAlertID = @Id");
                cmd.Parameters.Add(new SqlParameter("@StatusCode", newStatus));
                cmd.Parameters.Add(new SqlParameter("@Id", alertID));

                cmd.ExecuteNonQuery();
            }
            switch (newStatus.ToUpper())
            {
                case "V":
                    SendNotification(NotificationType.AlertValidated, 0); // No user - anonymous ?
                    break;
                case "I":
                    SendNotification(NotificationType.MeetingOrganizationInProgress, 0); // No user - anonymous ?
                    break;
                default:
                    break;
            }


        }

        #endregion

        #region CLASSROOM

        public IEnumerable<ClassRoom> GetClassRooms()
        {
            return GetClassRooms(null);
        }

        private IEnumerable<ClassRoom> GetClassRooms(long? id)
        {
            using (SqlDatabaseCommand cmd = GetDatabaseCommand())
            {
                cmd.CommandText.AppendLine(" SELECT * FROM ClassRoom ");
                cmd.CommandText.AppendLine("    INNER JOIN School ON ClassRoom.SchoolID = School.SchoolID ");
                if (id.HasValue)
                {
                    cmd.CommandText.AppendLine(" WHERE ClassRoomID = @ClassRoomID");
                    cmd.Parameters.Add(new SqlParameter("@ClassRoomID", id.Value));
                }
                IEnumerable<ClassRoom> classrooms = cmd.ExecuteTable<ClassRoom>();

                foreach (ClassRoom cla in classrooms)
                {
                    cmd.Clear();
                    cmd.CommandText.AppendLine(" SELECT * FROM CyberHelpUser WHERE ClassRoomID = @Id and CyberHelpUserType = 'S' ");
                    cmd.Parameters.Add(new SqlParameter("@Id", cla.ClassRoomID));

                    IEnumerable<CyberHelpUser> studentsFound = cmd.ExecuteTable<CyberHelpUser>();
                    cla.Students = studentsFound;

                    foreach (CyberHelpUser stud in studentsFound)
                    {
                        stud.SchoolName = cla.SchoolName;
                        stud.SchoolID = cla.SchoolID;
                    }

                    cmd.Clear();
                    cmd.CommandText.AppendLine(" SELECT * FROM CyberHelpUser WHERE ClassRoomID = @Id and CyberHelpUserType = 'T' ");
                    cmd.Parameters.Add(new SqlParameter("@Id", cla.ClassRoomID));
                    CyberHelpUser teacher = cmd.ExecuteRow<CyberHelpUser>();
                    if (teacher != null)
                        teacher.SchoolName = cla.SchoolName;
                    cla.Teacher = teacher;
                }

                return classrooms;

            }
            //return new ClassRoom[] { new ClassRoom { ClassRoomID = 1, Name = "Classe 1B", SchoolID = 1 } };
        }

        public ClassRoom GetClassRoom(long id)
        {
            IEnumerable<ClassRoom> rooms = GetClassRooms(id);
            if (rooms == null)
            {
                return null;
            }
            else
            {
                return rooms.FirstOrDefault();
            }
        }

        public long CreateClassRoom(ClassRoom classroom)
        {
            using (SqlDatabaseCommand cmd = this.GetDatabaseCommand())
            {
                cmd.CommandText.AppendLine("INSERT INTO [ClassRoom] ([ClassRoomName] ,[SchoolID]) VALUES (@Name,@SchoolID) ");
                cmd.Parameters.Add(new SqlParameter("@Name", classroom.ClassRoomName));
                cmd.Parameters.Add(new SqlParameter("@SchoolID", classroom.SchoolID));

                cmd.CommandText.AppendLine(" SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]; ");

                decimal id = cmd.ExecuteScalar<decimal>();

                return (long)id;
            }
        }

        public int GetAlertsCountForClassRoom(long classRoomID)
        {
            using (SqlDatabaseCommand cmd = GetDatabaseCommand())
            {
                cmd.CommandText.AppendLine(" SELECT count(*) FROM CyberAlert                                                                ");
                cmd.CommandText.AppendLine("    INNER JOIN CyberHelpUser ON cyberalert.cyberhelpuserid = cyberhelpuser.cyberhelpuserid      ");
                cmd.CommandText.AppendLine("    INNER JOIN ClassRoom ON ClassRoom.ClassRoomID = CyberHelpUser.ClassRoomID                   ");
                cmd.CommandText.AppendLine("    WHERE ClassRoom.ClassRoomID = @classRoomID                                                             ");
                cmd.Parameters.Add(new SqlParameter("@classRoomID", classRoomID));

                int count = cmd.ExecuteScalar<int>();

                return count;

            }
            //return new School[] { new School { SchoolID = 1, Name = "Académie Provinciale des métiers" } };
        }

        public IEnumerable<Alert> GetAlertsForClassRoom(long classRoomID)
        {
            using (SqlDatabaseCommand cmd = GetDatabaseCommand())
            {
                cmd.CommandText.AppendLine(" SELECT * FROM CyberAlert                                                                ");
                cmd.CommandText.AppendLine("    INNER JOIN CyberHelpUser ON cyberalert.cyberhelpuserid = cyberhelpuser.cyberhelpuserid      ");
                cmd.CommandText.AppendLine("    INNER JOIN ClassRoom ON ClassRoom.ClassRoomID = CyberHelpUser.ClassRoomID                   ");
                cmd.CommandText.AppendLine("    WHERE ClassRoom.ClassRoomID = @classRoomID                                                             ");
                cmd.Parameters.Add(new SqlParameter("@classRoomID", classRoomID));

                var result = cmd.ExecuteTable<Alert>();

                return result;

            }
            //return new School[] { new School { SchoolID = 1, Name = "Académie Provinciale des métiers" } };
        }
        #endregion

        #region SCHOOL

        public int GetAlertsForSchool(long schoolID)
        {
            using (SqlDatabaseCommand cmd = GetDatabaseCommand())
            {
                cmd.CommandText.AppendLine(" SELECT count(*) FROM CyberAlert                                                                ");
                cmd.CommandText.AppendLine("    INNER JOIN CyberHelpUser ON cyberalert.cyberhelpuserid = cyberhelpuser.cyberhelpuserid      ");
                cmd.CommandText.AppendLine("    INNER JOIN ClassRoom ON ClassRoom.ClassRoomID = CyberHelpUser.ClassRoomID                   ");
                cmd.CommandText.AppendLine("    INNER JOIN School ON School.SchoolID = ClassRoom.SchoolID                                   ");
                cmd.CommandText.AppendLine(" WHERE School.SchoolID = @SchoolID                                                                      ");
                cmd.Parameters.Add(new SqlParameter("@SchoolID", schoolID));

                int count = cmd.ExecuteScalar<int>();

                return count;

            }
            //return new School[] { new School { SchoolID = 1, Name = "Académie Provinciale des métiers" } };
        }


        public IEnumerable<School> GetSchools()
        {
            using (SqlDatabaseCommand cmd = GetDatabaseCommand())
            {
                cmd.CommandText.AppendLine(" SELECT * FROM School");

                IEnumerable<School> schools = cmd.ExecuteTable<School>();
                return schools;

            }
            //return new School[] { new School { SchoolID = 1, Name = "Académie Provinciale des métiers" } };
        }

        public long CreateSchool(School school)
        {
            using (SqlDatabaseCommand cmd = this.GetDatabaseCommand())
            {
                cmd.CommandText.AppendLine(" INSERT INTO[School](SchoolName) VALUES(@Name) ");
                cmd.Parameters.Add(new SqlParameter("@Name", school.SchoolName));

                cmd.CommandText.AppendLine(" SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]; ");

                decimal id = cmd.ExecuteScalar<decimal>();

                return (long)id;
            }
        }

        #endregion

        #region Tools


        public async Task  SendNotification(NotificationType type, long userID)
        {
            string message = string.Empty;

            switch (type)
            {
                case NotificationType.AlertSent:
                    message = "Votre alerte a été envoyée";
                    break;
                case NotificationType.AlertValidated:
                    message = "Votre alerte a été validée";
                    break;
                case NotificationType.MeetingOrganizationInProgress:
                    message = "Une réunion est en cours d'organisation";
                    break;
                default:
                    message = "Votre alerte a été envoyée";
                    break;
            }

            string fullUrl = string.Format("http://sumcamp2016notif.azurewebsites.net/api/values/1/{0}", message);

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://sumcamp2016notif.azurewebsites.net");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // New code:

                    HttpResponseMessage response = client.GetAsync(String.Format("/api/values/1/{0}", message)).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    int a=1; // Error is raised due to aspnetcore
                }

            }
        }
        public enum NotificationType
        {
            AlertSent,
            AlertValidated,
            MeetingOrganizationInProgress
        }

        /// <summary>
        /// Gets a SqlDatabaseCommand object already configured with Factory's database connection.
        /// </summary>
        /// <returns>A SqlDatabaseCommand object.</returns>
        public SqlDatabaseCommand GetDatabaseCommand()
        {
            return new SqlDatabaseCommand(GetOpenConnection());
        }

        /// <summary>
        /// Returns a sql connection, if the connexion is not open, the method will open it
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetOpenConnection()
        {
            if (_connection == null)
                throw new NullReferenceException("Connection is null");

            //Open the connection 
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }

            return _connection;
        }

        #endregion

        #endregion
    }
}
