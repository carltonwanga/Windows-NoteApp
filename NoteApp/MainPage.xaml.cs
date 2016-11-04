using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace NoteApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class MainPage : Page
    {
        List<Note> notes;


        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;


            Loaded += new RoutedEventHandler(Page_Loaded);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("hi ");
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            download_data dwl = new download_data();

            dwl.downloadDatacomplete += data_arrived;
            dwl.get_data("http://apinotes.azurewebsites.net/notes?user=" + Constants.admissionNumbers);

        }


        void data_arrived(object sender, DownloadCompleteData e)
        {

            String data = e.data;

            JArray obj = JArray.Parse(data);
             notes = new List<Note>();

            for (int i = 0; i < obj.Count; i++)
            {

                JObject row = JObject.Parse(obj[i].ToString());

                var note = new Note();
                note.Title = row["title"].ToString();
                note.Content = row["content"].ToString();
                //note.Category= row["category"].ToString();
                note.Latitude = row["latitude"].ToString();
                note.Longitude = row["longitude"].ToString();
                note.User = row["user"].ToString();
                //System.Diagnostics.Debug.WriteLine(Note.Title);
                notes.Add(note);
            }
            notesList.ItemsSource = notes;


        }

        private void btnMap_Click(object sender, RoutedEventArgs e)
        {

        }


        private void notesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnActionAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddNote));
        }

        private void notesList_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Note selectedItem = (sender as ListBox).SelectedItem as Note;


            Frame.Navigate(typeof(NoteDetail), e.ClickedItem);
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NotesMap), notes);
        }
    }
}
