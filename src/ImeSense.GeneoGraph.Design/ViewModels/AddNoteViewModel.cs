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
using System.Reactive;

namespace ImeSense.GeneoGraph.Design.ViewModels {
    public class AddNoteViewModel : ReactiveObject 
    {

        private NoteCategory _selectedCategory;
        private Note _newNote;

        public AddNoteViewModel() 
        {
            CategoryList = NoteCategory.CategoryList;
            SelectedCategory = CategoryList[0];

            ///_newNote = newnote;
        }


        [Reactive]
        public string NewNoteHeader { get; set; } = string.Empty;

        [Reactive]
        public string NewNoteText { get; set; } = string.Empty;


        [Reactive]
        public ObservableCollection<NoteCategory> CategoryList { get; set; } = new();

        [Reactive]
        public string NewCategoryName { get; set; }

        public Note NewNote {
            get => _newNote;
            set => this.RaiseAndSetIfChanged(ref _newNote, value);
        }

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


            NewNote = new Note() {
                NoteId = 5,
                NoteHeader = NewNoteHeader,
                NoteText = NewNoteText,
                Category = SelectedCategory,
                AddedTime = DateTime.Now
            };

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
