﻿namespace DataLibrary
{
    public interface IDataAccess
    {
      
        Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString);
        Task<int> SaveData<T>(string sql, T parameters, string connectionString);
    }
}