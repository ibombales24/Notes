﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Notes.Models;

namespace Notes
{
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetNoteAsync();
            //var notes = new List<Note>();

            //var files = Directory.EnumerateFiles(App.FolderPath, "*.notes.txt");
            //foreach(var fileName in files)
            //{
            //    notes.Add(new Note
            //    {
            //        Filename = fileName,
            //        Text = File.ReadAllText(fileName),
            //        Date = File.GetCreationTime(fileName)
            //    });
            //}

            //listView.ItemsSource = notes
            //    .OrderBy(d => d.Date)
            //    .ToList();
        }

        async void OnNoteAddClicked (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteEntryPage
            {
                BindingContext = new Note()
            });
        }

        async void OnListViewItemSelected (object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NoteEntryPage
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }
    }
}