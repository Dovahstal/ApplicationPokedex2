﻿namespace ApplicationPokedex
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new AcceuilPage())
            {
                BarBackgroundColor = Colors.Transparent,
                BarTextColor = Colors.Transparent
            };
            NavigationPage.SetHasNavigationBar(this, false);

        }
    }
}
