using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace App6
{
    public partial class MainPage : ContentPage
    {
        protected ObservableCollection<string> _items;
        public ObservableCollection<string> Items
        {
            get => _items;
            set
            {
                if (_items == value)
                {
                    return;
                }
                _items = value;
                OnPropertyChanged();
            }
        }

        public MainPage()
        {
            InitializeComponent();
            InitList();
        }

        protected void InitList()
        {
            try
            {
                Items = new ObservableCollection<string>
                {
                    "apple","banana","cow","dragon","elephant","fire","honey","github","ice-cream","jet-brains","kane",
                    "Lazy","monkey","nice","october","pause","quiz","rainbow","service","tv","upset","vision","wake","x-ray",
                    "Yo-yo","Zeus"
                };
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void Entry1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListView1.IsVisible = true;
            ListView1.BeginRefresh();
            try
            {
                IEnumerable<string> newData = Items.Where(item => item.ToLower().Contains(e.NewTextValue.ToLower()));

                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                {
                    ListView1.IsVisible = false;
                }
                else if (newData.Max().Length == 0)
                {
                    ListView1.IsVisible = false;
                }
                else
                {
                    ListView1.ItemsSource = newData;
                    ListView1.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                ListView1.IsVisible = false;
                Debug.WriteLine(ex.ToString());
            }
            ListView1.EndRefresh();
        }

        private void ListView1_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            string result = e.Item as string;
            Entry1.Text = result;
            ListView1.IsVisible = false;
        }
    }
}

