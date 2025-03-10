using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Infrastructure.Dtos;
using Domain.Abstractions;
using Infrastructure.Interfaces;
using SQLite;

namespace Infrastructure.Repositories
{
    public class SQLiteUnitOfWork : IUnitOfWork
    {
        private readonly string dbPath = @"..\..\..\..\db\"; 
        SQLiteUnitOfWork()
        {
            CreateDataBaseAsync();
            BankRepository = new(_connection);
        }
        private SQLiteAsyncConnection _connection;
        BankRepository BankRepository { get; }
        ~SQLiteUnitOfWork()
        {
            DeleteDataBaseAsync();
        }

        public async Task CreateDataBaseAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _connection = new SQLiteAsyncConnection(dbPath);
            await _connection.CreateTableAsync<BankDto>();
        }

        public async Task DeleteDataBaseAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _connection.DeleteAllAsync<BankDto>();
        }

        public async Task SaveAllAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _connection.CreateTableAsync<BankDto>();
            var obj = BankRepository.GetAllAsync(cancellationToken);
            await _connection.UpdateAllAsync(obj.Result);
        }
    }
}
