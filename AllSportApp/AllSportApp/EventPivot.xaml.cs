using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using AllSportApp.WP.Domain;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AllSportApp.ViewModels;
namespace AllSportApp
{
    public partial class EventPivot : PhoneApplicationPage
    {
        public EventPivot()
        {
            InitializeComponent();
            EventViewModel eventViewModel = new EventViewModel();
            List<AlphaKeyGroup<Event>> dataSource = AlphaKeyGroup<Event>.CreateGroups(eventViewModel.Events,
                System.Threading.Thread.CurrentThread.CurrentUICulture,
                (Event s) => { return s.Name; }, true);

            llsDayView.ItemsSource = dataSource;
        }

        private void Pivot_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}