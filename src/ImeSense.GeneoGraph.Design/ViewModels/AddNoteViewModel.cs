using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Avalonia.Controls;

using ImeSense.GeneoGraph.Models;
using Avalonia.ReactiveUI;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ImeSense.GeneoGraph.Design.ViewModels {
    public class AddNoteViewModel : ReactiveObject 
    {

        private NoteCategory _selectedCategory;

        private readonly Note _newnote;

        public AddNoteViewModel(Note newnote) 
        {
            CategoryList = NoteCategory.CategoryList;
            SelectedCategory = CategoryList[0];
            NotesList = Note.NotesList;

            _newnote = newnote;
        }



        [Reactive]
        public string NewNoteHeader { get; set; } = string.Empty;

        [Reactive]
        public string NewNoteText { get; set; } = string.Empty;

        [Reactive]
        public ObservableCollection<Note> NotesList { get; set; } = new();



        [Reactive]
        public ObservableCollection<NoteCategory> CategoryList { get; set; } = new();

        [Reactive]
        public string NewCategoryName { get; set; }

        public NoteCategory SelectedCategory {
            get => _selectedCategory;
            set {
                this.RaiseAndSetIfChanged(ref _selectedCategory, value);
            }
        }

        public static void AddNoteClose() 
        {
            NotesViewModel._addNoteWindow.Close();
        }

        public static void AddCategoryClose() {
            NotesViewModel._addCategoryWindow.Close();
        }


        public void AddNote() {
            Note.NotesList.Add(new Note() {
                NoteId = NotesList.Last().NoteId + 1,
                NoteHeader = NewNoteHeader,
                NoteText = NewNoteText,
                Category = SelectedCategory,
                AddedTime = DateTime.Now
            }); ;

            AddNoteClose();

        }

        public void AddCategory() {
            CategoryList.Add(new NoteCategory() {
                Id = CategoryList.Last().Id + 1,
                CategoryName = NewCategoryName
            });

            AddCategoryClose();
        }

    }
}
