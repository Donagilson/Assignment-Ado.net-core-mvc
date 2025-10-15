using ProfessorManagementSystem.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ProfessorManagementSystem.Repository
{
    public class ProfessorRepositoryImpl : IProfessorRepository
    {
        private readonly string connectionString;

        public ProfessorRepositoryImpl(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("MVCConnectionString");
        }

        public List<Department> SelectAllDepartments()
        {
            var departments = new List<Department>();
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("sp_SelectAllProfessorDepartments", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            departments.Add(new Department
                            {
                                DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                                DepartmentName = reader["DepartmentName"].ToString() ?? string.Empty
                            });
                        }
                    }
                }
            }
            return departments;
        }

        public IEnumerable<Professor> SelectAllProfessors()
        {
            var professors = new List<Professor>();
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("sp_SelectAllProfessors", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            professors.Add(new Professor
                            {
                                ProfessorId = Convert.ToInt32(reader["ProfessorId"]),
                                HOD = reader["HOD"] != DBNull.Value ? Convert.ToInt32(reader["HOD"]) : null,
                                FirstName = reader["FirstName"].ToString() ?? string.Empty,
                                LastName = reader["LastName"].ToString() ?? string.Empty,
                                Deptno = Convert.ToInt32(reader["Deptno"]),
                                Salary = Convert.ToDecimal(reader["Salary"]),
                                JoiningDate = Convert.ToDateTime(reader["JoiningDate"]),
                                DOB = Convert.ToDateTime(reader["DOB"]),
                                Gender = reader["Gender"].ToString() ?? string.Empty,
                                IsActive = reader["IsActive"] != DBNull.Value && Convert.ToBoolean(reader["IsActive"]),
                                Department = new Department
                                {
                                    DepartmentId = Convert.ToInt32(reader["Deptno"]),
                                    DepartmentName = reader["DepartmentName"].ToString() ?? string.Empty
                                }
                            });
                        }
                    }
                }
            }
            return professors;
        }

        public void InsertProfessor(Professor professor)
        {
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("sp_AddProfessor", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@HOD", (object?)professor.HOD ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FirstName", professor.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", professor.LastName);
                    cmd.Parameters.AddWithValue("@Deptno", professor.Deptno);
                    cmd.Parameters.AddWithValue("@Salary", professor.Salary);
                    cmd.Parameters.AddWithValue("@JoiningDate", professor.JoiningDate);
                    cmd.Parameters.AddWithValue("@DOB", professor.DOB);
                    cmd.Parameters.AddWithValue("@Gender", professor.Gender);
                    cmd.Parameters.AddWithValue("@IsActive", professor.IsActive);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public Professor GetProfessorById(int id)
        {
            Professor professor = null;
            using (var con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("sp_GetProfessorById", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProfessorId", id);
                con.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        professor = new Professor
                        {
                            ProfessorId = Convert.ToInt32(dr["ProfessorId"]),
                            HOD = dr["HOD"] != DBNull.Value ? Convert.ToInt32(dr["HOD"]) : null,
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            Deptno = Convert.ToInt32(dr["Deptno"]),
                            Salary = Convert.ToDecimal(dr["Salary"]),
                            JoiningDate = Convert.ToDateTime(dr["JoiningDate"]),
                            DOB = Convert.ToDateTime(dr["DOB"]),
                            Gender = dr["Gender"].ToString(),
                            IsActive = Convert.ToBoolean(dr["IsActive"])
                        };
                    }
                }
            }
            return professor;
        }



        public void UpdateProfessor(Professor professor)
        {
            using (var con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("sp_UpdateProfessor", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProfessorId", professor.ProfessorId);
                cmd.Parameters.AddWithValue("@HOD", (object?)professor.HOD ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FirstName", professor.FirstName);
                cmd.Parameters.AddWithValue("@LastName", professor.LastName);
                cmd.Parameters.AddWithValue("@Deptno", professor.Deptno);
                cmd.Parameters.AddWithValue("@Salary", professor.Salary);
                cmd.Parameters.AddWithValue("@JoiningDate", professor.JoiningDate);
                cmd.Parameters.AddWithValue("@DOB", professor.DOB);
                cmd.Parameters.AddWithValue("@Gender", professor.Gender);
                cmd.Parameters.AddWithValue("@IsActive", professor.IsActive);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

    