using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;

using ImeSense.GeneoGraph.Models;

namespace ImeSense.GeneoGraph.ViewModels {
    public class NotesViewModel : ObservableObject 
    {
        private ObservableCollection<NoteCategory> _categoryList;
        private ObservableCollection<Note> _notesList;

        private string _selectedCategory;
        private string _selectedNote;

        public NotesViewModel() 
        {
            CategoryList = new()
            {
                new NoteCategory {
                Id = 1,
                CategoryName = "All notes"},
                new NoteCategory {
                Id = 2,
                CategoryName = "Recent"},
                new NoteCategory {
                Id = 3,
                CategoryName = "Custom"},
            };

            NotesList = new() 
            {
                new Note 
                {
                NoteId = 1,
                NoteHeader = "Test Note",
                NoteDescription= "Test Lorem Ipsum",
                NoteText= "Test Lorem Ipsum AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA AAAAAAAAAAAAAAAAAAAAAAAAAAA",
                Category= "All notes",
                AddedTime= DateTime.Now
                },
                new Note
                {
                NoteId = 2,
                NoteHeader = "Test Note 2",
                NoteDescription= "Test Lorem Ipsum 2",
                NoteText= "Test Lorem Ipsum AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA AAAAAAAAAAAAAAAAAAAAAAAAAAA",
                Category= "All notes",
                AddedTime= DateTime.Now
                },
            };

            SelectedCategory = CategoryList[0].CategoryName;

        }

        public ObservableCollection<NoteCategory> CategoryList {
            get => _categoryList;
            set => SetProperty(ref _categoryList, value);
        }

        public ObservableCollection<Note> NotesList {
            get => _notesList;
            set => SetProperty(ref _notesList, value);
        }

        public string SelectedCategory {
            get => _selectedCategory;
            set => SetProperty(ref _selectedCategory, value);
        }

        public string SelectedNote {
            get => _selectedNote;
            set => SetProperty(ref _selectedNote, value);
        }

    }
}
