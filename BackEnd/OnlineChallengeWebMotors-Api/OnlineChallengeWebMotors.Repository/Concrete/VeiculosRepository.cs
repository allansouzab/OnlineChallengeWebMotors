using Microsoft.Extensions.Configuration;
using OnlineChallengeWebMotors.Domain.Entities;
using OnlineChallengeWebMotors.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace OnlineChallengeWebMotors.Repository.Concrete
{
    public class VeiculosRepository : IVeiculosRepository
    {
        public VeiculosRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public Retorno Add(Carro carro)
        {
            try
            {
                using (var con = new SqlConnection())
                {
                    con.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
                    con.Open();
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "INSERT INTO tb_AnuncioWebmotors (marca, modelo, versao, ano, quilometragem, observacao) VALUES (@Marca, @Modelo, @Versao, @Ano, @Quilometragem, @Observacao)";
                        cmd.Parameters.AddWithValue("@Marca", carro.Marca);
                        cmd.Parameters.AddWithValue("@Modelo", carro.Modelo);
                        cmd.Parameters.AddWithValue("@Versao", carro.Versao);
                        cmd.Parameters.AddWithValue("@Ano", carro.Ano);
                        cmd.Parameters.AddWithValue("@Quilometragem", carro.Quilometragem);
                        cmd.Parameters.AddWithValue("@Observacao", carro.Observacao);
                        var count = cmd.ExecuteNonQuery();

                        if (count > 0)
                        {
                            return new Retorno
                            {
                                Codigo = 0,
                                Mensagem = "Novo veículo adicionado com sucesso."
                            };
                        }
                        return new Retorno
                        {
                            Codigo = -1,
                            Mensagem = "Erro ao tentar adicionar veículo."
                        };
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Retorno Alterar(Carro carro)
        {
            try
            {
                using (var con = new SqlConnection())
                {
                    con.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
                    con.Open();
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "UPDATE tb_AnuncioWebmotors SET marca = @Marca, modelo = @Modelo, versao = @Versao, ano = @Ano, quilometragem = @Quilometragem, observacao = @Observacao WHERE ID = @Id";
                        cmd.Parameters.AddWithValue("@Marca", carro.Marca);
                        cmd.Parameters.AddWithValue("@Modelo", carro.Modelo);
                        cmd.Parameters.AddWithValue("@Versao", carro.Versao);
                        cmd.Parameters.AddWithValue("@Ano", carro.Ano);
                        cmd.Parameters.AddWithValue("@Quilometragem", carro.Quilometragem);
                        cmd.Parameters.AddWithValue("@Observacao", carro.Observacao);
                        cmd.Parameters.AddWithValue("@Id", carro.Id);
                        var count = cmd.ExecuteNonQuery();

                        if (count > 0)
                        {
                            return new Retorno
                            {
                                Codigo = 0,
                                Mensagem = "Veículo alterado com sucesso."
                            };
                        }
                        return new Retorno
                        {
                            Codigo = -1,
                            Mensagem = "Erro ao tentar alterar veículo."
                        };
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<Carro> Obter()
        {
            try
            {
                using (var con = new SqlConnection())
                {
                    con.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
                    con.Open();
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "SELECT ID, marca, modelo, versao, ano, quilometragem, observacao FROM tb_AnuncioWebmotors";
                        var reader = cmd.ExecuteReader();
                        var carros = new List<Carro>();

                        while (reader.Read())
                        {
                            var carro = new Carro
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                Marca = reader["marca"].ToString(),
                                Modelo = reader["modelo"].ToString(),
                                Versao = reader["versao"].ToString(),
                                Ano = Convert.ToInt32(reader["ano"]),
                                Quilometragem = Convert.ToInt32(reader["quilometragem"]),
                                Observacao = reader["observacao"].ToString()
                            };
                            carros.Add(carro);
                        }
                        return carros;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Retorno Remover(int id)
        {
            try
            {
                using (var con = new SqlConnection())
                {
                    con.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
                    con.Open();
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "DELETE FROM tb_AnuncioWebmotors WHERE ID = @Id";
                        cmd.Parameters.AddWithValue("@Id", id);
                        var count = cmd.ExecuteNonQuery();

                        if (count > 0)
                        {
                            return new Retorno
                            {
                                Codigo = 0,
                                Mensagem = "Veículo removido com sucesso."
                            };
                        }
                        return new Retorno
                        {
                            Codigo = 0,
                            Mensagem = "Erro ao tentar remover veículo."
                        };
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
