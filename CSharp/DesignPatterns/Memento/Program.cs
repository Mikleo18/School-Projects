using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book
            {
                Isbn="12345",
                Title="Siyah",
                Author="Rıfat Keskin",
            }; 
            book.ShowBook();
            CareTaker history = new CareTaker();
            history.memento = book.CreateUndo();

            book.Isbn = "55555";
            book.Title = "Musalar";
            book.ShowBook();

            book.RestoreFromUndo(history.memento);
            book.ShowBook();

            Console.ReadLine();

        }
    }
    class Book
    {
        private string _title;
        private string _author;
        private string _isbn;
        DateTime _LastEdited;

        public string Title 
        { 
            get{ return _title; }
            set 
            { 
                _title = value;
                SetLastEdited();
            } 
        }

        public string Author 
        { 
            get{ return _author; }
            set 
            { 
                _author = value;
                SetLastEdited();
            } 
        }

        public string Isbn
        {
            get{ return _isbn; }
            set 
            {
                _isbn = value;
                SetLastEdited();
            }
        }

        private void SetLastEdited()
        {
            _LastEdited = DateTime.UtcNow;
        }

        public Memento CreateUndo()
        {
            return new Memento(_isbn,_title,_author,_LastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title=memento.Title;
            _author=memento.Author;
            _isbn=memento.Isbn;
            _LastEdited=memento.LastEdited;
        }

        public void ShowBook()
        {
            Console.WriteLine("{0},{1},{2} edited : {3}",Isbn,Title,Author,_LastEdited);
        }
    }

    class Memento
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string isbn,string title,string author,DateTime lastedited)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            LastEdited = lastedited;
        }
    }

    class CareTaker
    {
        public Memento memento { get; set; }
    }
}
