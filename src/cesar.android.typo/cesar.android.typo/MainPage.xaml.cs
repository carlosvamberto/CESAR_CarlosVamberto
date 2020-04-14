using System;
using System.Collections.Generic;
using System.ComponentModel;
using cesar.utils;
using Xamarin.Forms;

namespace cesar.android.typo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public List<string> listToView = new List<string>();
        public List<string> listFiltered = new List<string>();

        public MainPage()
        {
            InitializeComponent();
            InitializeListView();
        }

        private void InitializeListView()
        {
            listToView = new List<string>()
            {
                "city", "cities", "jobs", "job", "cesar", "recife"
            };

            lsvListOfWords.ItemsSource = listToView;
        }

        private void ListFiltered()
        {
            if (txtFilter.Text.Trim() == string.Empty)
            {
                lsvListOfWords.ItemsSource = listToView;
                return;
            }
            
            listFiltered = new List<string>();

            foreach (string item in listToView)
            {
                if (Tools.IsTypo(item, txtFilter.Text))
                {
                    listFiltered.Add(item);
                }
            }

            lsvListOfWords.ItemsSource = listFiltered;
        }

        private void btnSearch_Clicked(object sender, EventArgs e)
        {
            ListFiltered();
        }
    }
}
