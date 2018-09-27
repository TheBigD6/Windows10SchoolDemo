using System;
using System.Windows;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SchoolDemoWin10.Views;
using SchoolDemoWin10.Services;
using SchoolDemoWin10.Data;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SchoolDemoWin10
{
    
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MyFrame.Navigate(typeof(LogonPage));
            //StudentListBoxItem.IsSelected = true;
            StudentListBoxItem.Visibility = Visibility.Collapsed;
            TeacherListBoxItem.Visibility = Visibility.Collapsed;
            PrincipleListBoxItem.Visibility = Visibility.Collapsed;
        }

        private void ControlListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StudentListBoxItem.IsSelected)
            {
                MyFrame.Navigate(typeof(StudentProfile));
            }
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SideSplitView.IsPaneOpen = !SideSplitView.IsPaneOpen;
        }
        #region Navigation


        #endregion

        #region Event Handlers
        /// <summary>
        /// Handle successful logon.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logon_Success(object sender, EventArgs e)
        {
            //Update the display and show the data for the user.
            logonPage.Visibility = Visibility.Collapsed;
            gridLoggedIn.Visibility = Visibility.Visible;
            Refresh();
        }
        /// <summary>
        /// Display message indicating user credentials invalid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Logon_Failed(object sender, EventArgs e)
        {
            string fmessage = "Invalid Username or Password";
            var dialog = new MessageDialog(fmessage, "Logon Failed");
            await dialog.ShowAsync();
        }

        private void Logoff_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Display logic
        private void Refresh()
        {
            switch (SessionContent.UserRole)
            {
                case Role.Student:
                    TitleTextBlock.Text = string.Format("Welcome {0} {1}", SessionContent.CurrentStudent.FirstName, SessionContent.CurrentStudent.LastName);
                    //GoToStudentProfile();
                    break;
                case Role.Teacher:
                    TitleTextBlock.Text = string.Format("Welcome {0} {1}", SessionContent.CurrentTeacher.FirstName, SessionContent.CurrentTeacher.LastName);
                    //GoToTeachersPage();
                    break;
            }
        }


        #endregion

        
    }
}
