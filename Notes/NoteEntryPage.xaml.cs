
using System;
using System.IO;
using Xamarin.Forms;
using Notes.Models;

namespace Notes
{
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked (object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            await App.Database.SaveNoteAsync(note);

            //if (string.IsNullOrEmpty(note.Filename))
            //{
            //    // Save
            //    var fileName = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
            //    File.WriteAllText(fileName, note.Text);
            //}
            //else
            //{
            //    // Update
            //    File.WriteAllText(note.Filename, note.Text);
            //}
            
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked (object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.Database.DeleteNoteAsync(note);

            //if (File.Exists(note.Filename))
            //{
            //    File.Delete(note.Filename);
            //}

            await Navigation.PopAsync();
        }
    }
}