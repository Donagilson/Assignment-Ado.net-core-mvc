using System.Data;
using System.Data.SqlClient;
using PatientManagementSystem2025.Models;

namespace PatientManagementSystem2025.Repository
{
    public class PatientRepositoryImpl : IPatientRepository
    {
        private readonly string connectionString;
        public PatientRepositoryImpl(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("MVCConnectionString");
        }

        public List<Membership> SelectAllMemberships()
        {
            List<Membership> memberships = new List<Membership>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_SelectAllMemberships", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    memberships.Add(new Membership
                    {
                        MemberId = Convert.ToInt32(reader["MemberId"]),
                        MemberDescrip = reader["MemberDescrip"].ToString(),
                        InsureAmt = Convert.ToDecimal(reader["InsureAmt"])
                    });
                }
                con.Close();
            }
            return memberships;
        }

        public IEnumerable<Patient> SelectAllPatients()
        {
            List<Patient> patients = new List<Patient>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_SelectAllPatients", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    patients.Add(new Patient
                    {
                        PatientId = Convert.ToInt32(reader["PatientId"]),
                        RegistrationNo = reader["RegistrationNo"].ToString(),
                        PatientName = reader["PatientName"].ToString(),
                        Dob = Convert.ToDateTime(reader["Dob"]),
                        Gender = reader["Gender"].ToString(),
                        Address = reader["Address"].ToString(),
                        PhoneNo = reader["PhoneNo"].ToString(),
                        MemberId = Convert.ToInt32(reader["MemberId"]),
                        IsActive = Convert.ToBoolean(reader["IsActive"])
                    });
                }
                con.Close();
            }
            return patients;
        }

        public Patient SelectPatientById(int? id)
        {
            Patient patient = new Patient();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetPatientById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientId", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    patient.PatientId = Convert.ToInt32(reader["PatientId"]);
                    patient.RegistrationNo = reader["RegistrationNo"].ToString();
                    patient.PatientName = reader["PatientName"].ToString();
                    patient.Dob = Convert.ToDateTime(reader["Dob"]);
                    patient.Gender = reader["Gender"].ToString();
                    patient.Address = reader["Address"].ToString();
                    patient.PhoneNo = reader["PhoneNo"].ToString();
                    patient.MemberId = Convert.ToInt32(reader["MemberId"]);
                    patient.IsActive = Convert.ToBoolean(reader["IsActive"]);
                }
                con.Close();
            }
            return patient;
        }

        public void InsertPatient(Patient patient)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddPatient", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RegistrationNo", patient.RegistrationNo);
                cmd.Parameters.AddWithValue("@PatientName", patient.PatientName);
                cmd.Parameters.AddWithValue("@Dob", patient.Dob);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                cmd.Parameters.AddWithValue("@Address", patient.Address);
                cmd.Parameters.AddWithValue("@PhoneNo", patient.PhoneNo);
                cmd.Parameters.AddWithValue("@MemberId", patient.MemberId);
                cmd.Parameters.AddWithValue("@IsActive", patient.IsActive);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdatePatient(Patient patient)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_EditPatient", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientId", patient.PatientId);
                cmd.Parameters.AddWithValue("@RegistrationNo", patient.RegistrationNo);
                cmd.Parameters.AddWithValue("@PatientName", patient.PatientName);
                cmd.Parameters.AddWithValue("@Dob", patient.Dob);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                cmd.Parameters.AddWithValue("@Address", patient.Address);
                cmd.Parameters.AddWithValue("@PhoneNo", patient.PhoneNo);
                cmd.Parameters.AddWithValue("@MemberId", patient.MemberId);
                cmd.Parameters.AddWithValue("@IsActive", patient.IsActive);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
