﻿using AndroidTask.Data;
using AndroidTask.Model;
using AndroidTask.View;
using AndroidTask.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidTask
{
    public partial class App : Application
    {
        static AndroidTaskDatabase database;
        public static ItemManager GeeksManager { get; private set; }

        public App()
        {
            InitializeComponent();

            GeeksManager = new ItemManager(new RestService());
            MainPage = new NavigationPage(new MainPage());
        }

        public static AndroidTaskDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new AndroidTaskDatabase();
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        
    }
}
