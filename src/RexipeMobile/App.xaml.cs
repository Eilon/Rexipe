﻿using Xamarin.Essentials;
using Xamarin.Forms;
using RexipeMobile.Services;

namespace RexipeMobile
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        //To debug on Android emulators run the web backend against .NET Core not IIS
        //If using other emulators besides stock Google images you may need to adjust the IP address
        public static string AzureBackendUrl =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000";

        public static bool UseMockDataStore = false;

        /// <summary>
        /// Whether to use GraphQL or REST APIs to get server data.
        /// </summary>
        public static bool UseGraphQL = true;

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
            {
                DependencyService.Register<MockRecipeStore>();
            }
            else
            {
                DependencyService.Register<HttpRecipeStore>();
            }

            MainPage = new AppShell();
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
