using MLApps.Capstone.Encriptado.Domain.Entity;
using MLApps.Capstone.Encriptado.Domain.Entity.Models;
using MLApps.Capstone.Encriptado.Infrastructure.Data;
using MLApps.Capstone.Encriptado.Infrastructure.Interface;
using System;
using System.Data.SQLite;

namespace MLApps.Capstone.Encriptado.Infrastructure.Repository
{
    public class EncriptadosRepository : IEncriptadosRepository
    {
        private readonly DatabaseContext database;

        public EncriptadosRepository(DatabaseContext database)
        {
            this.database = database;
        }

        public ResponseDomain GuardaDatos(Informacion informacion)
        {
            try
            {
                using var connection = database.GetSqliteConnection();
                SQLiteCommand command = new(connection.ConnectionString)
                {
                    CommandText = "INSERT INTO Encriptado (CadenaOriginal, CadenaEnmascarada, CadenaEncriptada) VALUES(@CadenaOriginal, @CadenaEnmascarada, @CadenaEncriptada)",
                    CommandType = System.Data.CommandType.Text
                };
                command.Parameters.Add(new SQLiteParameter("@CadenaOriginal", informacion.TextoOriginal));
                command.Parameters.Add(new SQLiteParameter("@CadenaEnmascarada", informacion.TextoEnmascarado));
                command.Parameters.Add(new SQLiteParameter("@CadenaEncriptada", informacion.TextoEncriptado));
                command.ExecuteNonQuery();

                return ResponseDomain.Success("Guardado correctamente");
            }
            catch (Exception ex)
            {
                return ResponseDomain.Fail(ex.Message);
            }
        }
    }
}