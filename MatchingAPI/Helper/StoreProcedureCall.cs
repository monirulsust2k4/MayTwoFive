﻿using MatchingAPI.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Graph.Models;
using Newtonsoft.Json;
using System.Data;

namespace MatchingAPI.Helper
{
    public class StoreProcedureCall
    {
        private readonly PeopleDeskContext _dbContext;
        private static string _connection = Connection.PeopleDeskARLConnection;
        public StoreProcedureCall()
        {
            // _contextW = new WriteDbContext();
            // _contextW = new ReadDbContext();
        }

        public static List<KeyValue> PostJson<T>(string StoredProcedure, string InputJson, List<T> JsonObject, List<KeyValue> Output)
        {
            var json = JsonConvert.SerializeObject(JsonObject);

            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            // var _contextW = new WriteDbContext();

            // conn.ConnectionString = _contextW.Database.GetConnectionString();
            conn.ConnectionString = _connection;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = StoredProcedure;

            cmd.Parameters.AddWithValue(InputJson, json);

            foreach (var o in Output)
            {
                var typeName = o.Key.GetType().Name;
                SqlDbType type = SqlDbType.VarChar;

                if (typeName == "String") type = SqlDbType.VarChar;
                else if (typeName == "Int32") type = SqlDbType.Int;

                cmd.Parameters.Add(o.Key, type, 100);
                cmd.Parameters[o.Key].Direction = ParameterDirection.Output;
            }

            conn.Open();
            int i = cmd.ExecuteNonQuery();

            foreach (var o in Output)
            {
                o.Value = (string?)cmd.Parameters[o.Key].Value;
            }

            conn.Close();

            return Output;
        }

        public static List<KeyValue> PostJson(string StoredProcedure, List<KeyValue> JsonObject, List<KeyValue> Output)
        {
            // var json = JsonConvert.SerializeObject(JsonObject);

            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            var _contextW = new PeopleDeskContext();

            conn.ConnectionString = _connection;
            // conn.ConnectionString = _contextW.Database.GetConnectionString();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = StoredProcedure;

            JsonObject.ForEach(x =>
            {
                var json = JsonConvert.SerializeObject(x.Value);
                var name = x.Key;
                cmd.Parameters.AddWithValue(name, json);
            });

            // cmd.Parameters.AddWithValue(InputJson, json);

            foreach (var o in Output)
            {
                var typeName = o.Key.GetType().Name;
                SqlDbType type = SqlDbType.VarChar;

                if (typeName == "String") type = SqlDbType.VarChar;
                else if (typeName == "Int32") type = SqlDbType.Int;


                cmd.Parameters.Add(o.Key, type, 100);
                cmd.Parameters[o.Key].Direction = ParameterDirection.Output;
            }

            conn.Open();
            int i = cmd.ExecuteNonQuery();

            foreach (var o in Output)
            {
                o.Value = (string?)cmd.Parameters[o.Key].Value;
            }

            conn.Close();

            return Output;
        }

        public static List<KeyValue> PostJsonWithParam<T>(string StoredProcedure, string InputJson, List<T> JsonObject, List<KeyValue> InputParam, List<KeyValue> Output)
        {
            var json = JsonConvert.SerializeObject(JsonObject);

            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            // var _contextW = new WriteDbContext();

            conn.ConnectionString = _connection;
            // conn.ConnectionString = _contextW.Database.GetConnectionString();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = StoredProcedure;

            cmd.Parameters.AddWithValue(InputJson, json);

            foreach (var input in InputParam)
            {
                cmd.Parameters.AddWithValue(input.Key, input.Value);
            }

            foreach (var o in Output)
            {
                var typeName = o.Key.GetType().Name;
                SqlDbType type = SqlDbType.VarChar;

                if (typeName == "String") type = SqlDbType.VarChar;
                else if (typeName == "Int32") type = SqlDbType.Int;

                cmd.Parameters.Add(o.Key, type, 100);
                cmd.Parameters[o.Key].Direction = ParameterDirection.Output;
            }

            conn.Open();
            int i = cmd.ExecuteNonQuery();

            foreach (var o in Output)
            {
                o.Value = (string?)cmd.Parameters[o.Key].Value;
            }

            conn.Close();

            return Output;
        }

        public static List<KeyValue> PostJsonWithParam(string StoredProcedure, List<KeyValue> JsonObject, List<KeyValue> InputParam, List<KeyValue> Output)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            // var _contextW = new WriteDbContext();

            conn.ConnectionString = _connection;
            // conn.ConnectionString = _contextW.Database.GetConnectionString();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = StoredProcedure;

            foreach (var input in JsonObject)
            {
                var json = JsonConvert.SerializeObject(input.Value);
                cmd.Parameters.AddWithValue(input.Key, json);
            }

            foreach (var input in InputParam)
            {
                cmd.Parameters.AddWithValue(input.Key, input.Value);
            }

            foreach (var o in Output)
            {
                var typeName = o.Key.GetType().Name;
                SqlDbType type = SqlDbType.VarChar;

                if (typeName == "String") type = SqlDbType.VarChar;
                else if (typeName == "Int32") type = SqlDbType.Int;

                cmd.Parameters.Add(o.Key, type, 100);
                cmd.Parameters[o.Key].Direction = ParameterDirection.Output;
            }

            conn.Open();
            int i = cmd.ExecuteNonQuery();

            foreach (var o in Output)
            {
                var value = cmd.Parameters[o.Key].Value;

                if (value is System.DBNull)
                    o.Value = null;
                else
                    o.Value = (string?)value;
            }

            conn.Close();

            return Output;
        }

        public static List<KeyValue> PostParam(string StoredProcedure, List<KeyValue> InputParam, List<KeyValue> Output)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            // var _contextW = new WriteDbContext();

            conn.ConnectionString = _connection;
            // conn.ConnectionString = _contextW.Database.GetConnectionString();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = StoredProcedure;

            // foreach (var input in JsonObject)
            // {
            //     var json = JsonConvert.SerializeObject(input.Value);
            //     cmd.Parameters.AddWithValue(input.Key, json);
            // }

            foreach (var input in InputParam)
            {
                cmd.Parameters.AddWithValue(input.Key, input.Value);
            }

            foreach (var o in Output)
            {
                var typeName = o.Key.GetType().Name;
                SqlDbType type = SqlDbType.VarChar;

                if (typeName == "String") type = SqlDbType.VarChar;
                else if (typeName == "Int32") type = SqlDbType.Int;

                cmd.Parameters.Add(o.Key, type, 100);
                cmd.Parameters[o.Key].Direction = ParameterDirection.Output;
            }

            conn.Open();
            int i = cmd.ExecuteNonQuery();

            foreach (var o in Output)
            {
                o.Value = (string?)cmd.Parameters[o.Key].Value;
            }

            conn.Close();

            return Output;
        }

        public static KeyValue PostJson<T>(string StoredProcedure, string InputJson, List<T> JsonObject, KeyValue Output)
        {
            var json = JsonConvert.SerializeObject(JsonObject);

            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            // var _contextW = new WriteDbContext();

            conn.ConnectionString = _connection;
            // conn.ConnectionString = _contextW.Database.GetConnectionString();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = StoredProcedure;

            cmd.Parameters.AddWithValue(InputJson, json);

            var typeName = Output.Key.GetType().Name;
            SqlDbType type = SqlDbType.VarChar;

            // if (typeName == "String") type = SqlDbType.VarChar;
            if (typeName == "Int32") type = SqlDbType.Int;

            cmd.Parameters.Add(Output.Key, type, 100);
            cmd.Parameters[Output.Key].Direction = ParameterDirection.Output;


            conn.Open();
            int i = cmd.ExecuteNonQuery();

            Output.Value = (string?)cmd.Parameters[Output.Key].Value;

            conn.Close();

            return Output;
        }

        public static List<T> GetDataTable<T>(string StoredProcedure, List<KeyValue> InputParam)
        {
            DataTable dt = new DataTable();
            // var _contextW = new WriteDbContext();

            using (var connection = new SqlConnection(_connection))
            {
                string sql = StoredProcedure;
                using (SqlCommand sqlCmd = new SqlCommand(sql, connection))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    foreach (var input in InputParam)
                    {
                        sqlCmd.Parameters.AddWithValue(input.Key, input.Value);
                    }

                    connection.Open();
                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd))
                    {
                        sqlAdapter.Fill(dt);
                    }
                    connection.Close();
                }

            }

            return DataTableToList.ConvertDataTable<T>(dt);
        }

        public static DataTable GetDataTableUnknown(string StoredProcedure, List<KeyValue> InputParam)
        {
            DataTable dt = new DataTable();
            // var _contextW = new WriteDbContext();

            using (var connection = new SqlConnection(_connection))
            {
                string sql = StoredProcedure;
                using (SqlCommand sqlCmd = new SqlCommand(sql, connection))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    foreach (var input in InputParam)
                    {
                        sqlCmd.Parameters.AddWithValue(input.Key, input.Value);
                    }

                    connection.Open();
                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd))
                    {
                        sqlAdapter.Fill(dt);
                    }
                    connection.Close();
                }

            }

            return dt;
            // return DataTableToList.ConvertDataTable<T>(dt);
        }

    }
}
