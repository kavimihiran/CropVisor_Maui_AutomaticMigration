using SQLite;
using System;
using System.IO;

using Microsoft.Maui.Controls;
using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Storage;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public Command TapCommand { get; set; }
  
        public MainPage()
        {
            InitializeComponent();
             
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.FromArgb("#228B22");
        }
        private void OnTappedRec(object sender,EventArgs e) {
            Navigation.PushAsync(new Signup());  
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);

            var myquery = db.Table<RegisterTable>().Where(u=>u.Email.Equals(NameTextBox.Text) && u.Password.Equals(PasswordTextBox.Text)).FirstOrDefault();

            if (myquery != null)
            {
                Preferences.Default.Set("Name",NameTextBox.Text);
                Navigation.PushAsync(new MenuPage());
            }
            else {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Error", "Failed Username and Password","yes","cancel");
                    if (result)
                    {
                        await Navigation.PushAsync(new MainPage());
                    }
                    else 
                    {
                        await Navigation.PushAsync(new MainPage());
                    }
                });
            }
        }
    }
}
