using System;
using System.Collections.Generic;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace NoteApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NotesMap : Page
    {
        public NotesMap()
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
            List<Note> notes = e.Parameter as List<Note>;

            for (int i = 0; i < notes.Count; i++) { 
                var note = notes[i];
                var  noteGeoPosition = new BasicGeoposition();
                noteGeoPosition.Latitude = Double.Parse(note.Latitude);
                noteGeoPosition.Longitude = Double.Parse(note.Longitude);
                AddPushpin(noteGeoPosition, note.Title);

            }
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
            Notes_Map.Center = new Geopoint(centerLocation);
            Notes_Map.ZoomLevel = 10;
            Notes_Map.Children.Add(pin);
        }
    }
}
