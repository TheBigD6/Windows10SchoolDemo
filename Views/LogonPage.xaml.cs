using SchoolDemoWin10.Data;
using SchoolDemoWin10.Services;
using SchoolDemoWin10;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SchoolDemoWin10.Views
{
    /// <summary>
    /// Log on validation gets preformed here
    /// </summary>
    public partial class LogonPage : Page
    {
        public LogonPage()
        {
            this.InitializeComponent();
        }
        #region Event Members
        public event EventHandler LogonSuccess;
        public event EventHandler LogonFailed;
        #endregion

        #region Logon Validation
        /// <summary>
        /// Validate the username and password against the Users collection in the MainWindow window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logon_Click(object sender, RoutedEventArgs e)
        {
            #region
            /*
            try
            {
                bool Tester = false;
                var teacher = (from Teacher t in DataSource.Teachers
                               where Tester = (t.UserName == username.Text)   //String.Compare(t.UserName, username.Text) == 0
                               //&& t.VerifyPassword(password.Password)
                               select t).FirstOrDefault();
                // If the UserName of the user retrieved by using LINQ is non-empty then the user is a teacher
                if (Tester == true )
                {
                    SessionContent.UserID = teacher.TeacherID;
                    SessionContent.UserRole = Role.Teacher;
                    SessionContent.UserName = teacher.UserName;
                    SessionContent.CurrentTeacher = teacher;
                    LogonSuccess(this, null);
                    return;
                }
                // If the user is not a teacher, check whether the username and password match those of a student
                else
                {
                    var student = (from Student s in DataSource.Students
                                   where String.Compare(s.UserName, username.Text) == 0
                                   && s.VerifyPassword(password.Password)
                                   select s).FirstOrDefault();
                    if (student != null && !String.IsNullOrEmpty(teacher.UserName))
                    {
                        SessionContent.UserID = student.StudentID;
                        SessionContent.UserRole = Role.Student;
                        SessionContent.UserName = student.UserName;
                        SessionContent.CurrentStudent = student;
                        LogonSuccess(this, null);
                        return;
                    }
                }
                LogonFailed(this, null);
            }
            catch (ArgumentNullException)
            {
                Logon_Failed("Null");
            }
            catch (Exception)
            {
                Logon_Failed("Other");
                
            }
            */
            // Find the user in the list of possible users - first check whether the user is a Teacher
            #endregion
            var USERNAME = 0;
            var teacher = (from Teacher t in DataSource.Teachers
                           where USERNAME == String.Compare(t.UserName, txbxUsername.Text)   //&& t.VerifyPassword(password.Password)
                           select t).FirstOrDefault();
            // If the UserName of the user retrieved by using LINQ is non-empty then the user is a teacher
            if (false)
            {
                SessionContent.UserID = teacher.TeacherID;
                SessionContent.UserRole = Role.Teacher;
                SessionContent.UserName = teacher.UserName;
                SessionContent.CurrentTeacher = teacher;
                LogonSuccess(this, null);
                return;
            }

        }

        public async void Logon_Failed(string error)
        {
            string fmessage = "Invalid Username or Password";
            var dialog = new MessageDialog(error, "Logon Failed");
            await dialog.ShowAsync();
        }
        #endregion
    }
}
