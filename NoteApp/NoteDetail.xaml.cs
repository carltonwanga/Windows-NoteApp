using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace NoteApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NoteDetail : Page
    {
        public NoteDetail()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var note = e.Parameter as Note;

            tbTitle.Text = note.Title;
            tbContent.Text = note.Content;
            tbLat.Text = note.Latitude;
            tbLong.Text = note.Longitude;

            
            var noteGeoPosition = new BasicGeoposition();
            noteGeoPosition.Latitude = Double.Parse(note.Latitude);
            noteGeoPosition.Longitude = Double.Parse(note.Longitude);
            AddPushpin(noteGeoPosition, note.Title);

        }

        private void tbTitle_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void tbLong_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void lblLong_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
        public void AddPushpin(BasicGeoposition location, string text)
        {
            var pin = new Grid()
            {
                Width = 50,
                Height = 50,
                Margin = new Windows.UI.Xaml.Thickness(-12)
            };

            pin.Children.Add(new Ellipse()
            {
                Fill = new SolidColorBrush(Colors.DodgerBlue),
                Stroke = new SolidColorBrush(Colors.White),
                StrokeThickness = 3,
                Width = 50,
                Height = 50
            });

            pin.Children.Add(new TextBlock()
            {
                Text = text,
                FontSize = 12,
                Foreground = new SolidColorBrush(Colors.White),
                HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center,
                VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center
            });

            MapControl.SetLocation(pin, new Geopoint(location));
            BasicGeoposition centerLocation = new BasicGeoposition();
            centerLocation.Latitude = 47.68;
            centerLocation.Longitude = -122.33;
            DetailMap.Center = new Geopoint(centerLocation);
            DetailMap.ZoomLevel = 10;
            DetailMap.Children.Add(pin);
        }
    }
}
