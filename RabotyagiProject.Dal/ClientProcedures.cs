﻿using System.Data;
using System.Data.Common;
using Microsoft.VisualBasic;
using RabotyagiProject.Dal.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace RabotyagiProject.Dal;

public class ClientProcedures
{
    public List<ClientDto> GetAllClients()
    {
        using (var sqlConnection = new SqlConnection(Options.Constants.ConnectionString))
        {
            sqlConnection.Open();
            return sqlConnection.Query<ClientDto>(Options.StoredProcedures.GetAllClients,
                commandType: CommandType.StoredProcedure).ToList();
        }
    }

    public ClientDto GetClientById(int Id)
    {
        using (var sqlConnection = new SqlConnection(Options.Constants.ConnectionString))
        {
            sqlConnection.Open();
            return sqlConnection.QueryFirst<ClientDto>(Options.StoredProcedures.GetClientById,
            new {Id}, commandType: CommandType.StoredProcedure);
        }
    }

    public void AddNewClient(string name, string phone, string mail)
    {
        using (var sqlConnection = new SqlConnection(Options.Constants.ConnectionString))
        {
            sqlConnection.Open();
            sqlConnection.Execute(Options.StoredProcedures.AddNewClient, new { name,phone,mail }, commandType: CommandType.StoredProcedure);
        }
    }

    public void UpdateClientById(int id, string name, string phone, string mail, bool isDeleted)
    {
        using (var sqlConnection = new SqlConnection(Options.Constants.ConnectionString))
        {
            sqlConnection.Open();
            sqlConnection.Execute(Options.StoredProcedures.UpdateClientById, new {id, name, phone, mail, isDeleted }, commandType: CommandType.StoredProcedure);
        }
    }
}