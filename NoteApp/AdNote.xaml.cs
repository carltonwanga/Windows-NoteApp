using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace NoteApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddNote : Page
    {
        Note note;
        public AddNote()
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
            note = new Note();
        }

        private async void btnSaveNote_Click(object sender, RoutedEventArgs e)
        {

            note.Title = textTitle.Text;
            note.Content = textContent.Text;
            note.User = Constants.admissionNumbers;
            note.Category = textCategory.Text;

            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;
            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(maximumAge: TimeSpan.FromMinutes(5),
                     timeout: TimeSpan.FromSeconds(10));
                note.Latitude = geoposition.Coordinate.Latitude.ToString("0.00");
                note.Longitude = geoposition.Coordinate.Longitude.ToString("0.00");
                Task<Note> task = Task.Run<Note>(async () => await Proxy.PostNote(note));

                Note noteRes = task.Result;

                if (noteRes != null)
                {
                    Frame.GoBack();
                }
                else
                {
                    new MessageDialog("It has failed to save").ShowAsync();
                }
            }
            catch (UnauthorizedAccessException)
            {
                // the app does not have the right capability or the location master switch is off 
                new MessageDialog("Could not get Location").ShowAsync();
            }

            Debug.WriteLine(note.Longitude);
        }

        private void textCategory_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textTitle_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
