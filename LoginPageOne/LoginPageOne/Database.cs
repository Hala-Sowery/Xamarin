﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Essentials;

namespace LoginPageOne
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Book>();
        }

        public Task<List<Book>> GeBooksAsync()
        {
            return _database.Table<Book>().ToListAsync();
        }

        public Task<int> SaveBookAsync(Book book)
        {
            return _database.InsertAsync(book);
        }

        public Task<int> UpdateBookAsync(Book book)
        {
            return _database.UpdateAsync(book);
        }

        public Task<int> DeleteBookAsync(Book book)
        {
            return _database.DeleteAsync(book);
        }

        public Task<Book> GetBook(int id)
        {
            return _database.FindAsync<Book>(id);
        }
    }
}

