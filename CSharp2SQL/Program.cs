using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2SQL {
	class Program {

		static List<User> users = new List<User>();

		void Run() {
			User user = new User() {
				Username = "Jerry-of-the-Day",
				Password = "x",
				FirstName = "Jerry",
				Lastname = "of-the-Day",
				Email = "jerry@email.com",
				Phone = "555-555-5558",
				IsAdmin = false,
				IsReviewer = false,
				Id = 7
			};
			Update(user);
		}

		static void Main(string[] args) {
			

			(new Program()).Run();

		}
		void Update(User user) {
			//String to open instance of SQL server
			string connStr = @"server=STUDENT50\SQLEXPRESS;database=prssql;Trusted_Connection=true";
			//set up the connection to pass the commands.
			SqlConnection conn = new SqlConnection(connStr);
			//Open the connection
			conn.Open();
			//Make sure the state is loaded, if not, throw an error
			if(conn.State != System.Data.ConnectionState.Open) {
				throw new ApplicationException("Conection did not open");
			}
			System.Diagnostics.Debug.WriteLine("Connection Opened");

			string sql = "Update [user] Set Username=@Username, Password=@Password, Firstname=@Firstname, Lastname=@Lastname," +
				" Phone=@Phone, Email=@Email, IsReviewer=@IsReviewer, IsAdmin=@IsAdmin Where Id = @Id;";

			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.Add(new SqlParameter("@Id", user.Id));
			cmd.Parameters.Add(new SqlParameter("@Username", user.Username));
			cmd.Parameters.Add(new SqlParameter("@Firstname", user.FirstName));
			cmd.Parameters.Add(new SqlParameter("@Password", user.Password));
			cmd.Parameters.Add(new SqlParameter("@Lastname", user.Lastname));
			cmd.Parameters.Add(new SqlParameter("@Phone", user.Phone));
			cmd.Parameters.Add(new SqlParameter("@Email", user.Email));
			cmd.Parameters.Add(new SqlParameter("@IsReviewer", user.IsReviewer));
			cmd.Parameters.Add(new SqlParameter("@IsAdmin", user.IsAdmin));

			int recsAffected = cmd.ExecuteNonQuery();
			if(recsAffected != 1) {
				System.Diagnostics.Debug.WriteLine("Record insert failed");
			}
			conn.Close();
		}

		void Insert(User user) {
			//String to open instance of SQL server
			string connStr = @"server=STUDENT50\SQLEXPRESS;database=prssql;Trusted_Connection=true";
			//set up the connection to pass the commands.
			SqlConnection conn = new SqlConnection(connStr);
			//Open the connection
			conn.Open();
			//Make sure the state is loaded, if not, throw an error
			if(conn.State != System.Data.ConnectionState.Open) {
				throw new ApplicationException("Conection did not open");
			}
			System.Diagnostics.Debug.WriteLine("Connection Opened");

			string sql = "Insert into [user] (Username, Password, Firstname, Lastname,Phone, Email, IsReviewer, IsAdmin)" +
						 "values (@Username, @Password, @Firstname, @Lastname,@Phone,@Email,@IsReviewer,@IsAdmin)";
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.Add(new SqlParameter("@Username", user.Username));
			cmd.Parameters.Add(new SqlParameter("@Firstname", user.FirstName));
			cmd.Parameters.Add(new SqlParameter("@Password", user.Password));
			cmd.Parameters.Add(new SqlParameter("@Lastname", user.Lastname));
			cmd.Parameters.Add(new SqlParameter("@Phone", user.Phone));
			cmd.Parameters.Add(new SqlParameter("@Email", user.Email));
			cmd.Parameters.Add(new SqlParameter("@IsReviewer", user.IsReviewer));
			cmd.Parameters.Add(new SqlParameter("@IsAdmin", user.IsAdmin));

			int recsAffected = cmd.ExecuteNonQuery();
			if (recsAffected != 1) {
				System.Diagnostics.Debug.WriteLine("Record insert failed");
			}
			conn.Close();
		}

		void Select() { 
			//String to open instance of SQL server
			string connStr = @"server=STUDENT50\SQLEXPRESS;database=prssql;Trusted_Connection=true";
			//set up the connection to pass the commands.
			SqlConnection conn = new SqlConnection(connStr);
			//Open the connection
			conn.Open();
			//Make sure the state is loaded, if not, throw an error
			if (conn.State != System.Data.ConnectionState.Open) {
				throw new ApplicationException("Conection did not open");
			}
			System.Diagnostics.Debug.WriteLine("Connection Opened");

			string sql = "select * from [user]";
			SqlCommand cmd = new SqlCommand(sql, conn);
			SqlDataReader reader = cmd.ExecuteReader();
			//Loop through the returned information
			while (reader.Read()) {
				//find the column named id, and cast that to a C# int32
				int id = reader.GetInt32(reader.GetOrdinal("Id"));
				string username = reader.GetString(reader.GetOrdinal("Username"));
				string password = reader.GetString(reader.GetOrdinal("Password"));
				string firstname = reader.GetString(reader.GetOrdinal("Firstname"));
				string lastname = reader.GetString(reader.GetOrdinal("Lastname"));
				string phone = reader.GetString(reader.GetOrdinal("Phone"));
				string email = reader.GetString(reader.GetOrdinal("Email"));
				bool isreviewer = reader.GetBoolean(reader.GetOrdinal("IsReviewer"));
				bool isadmin = reader.GetBoolean(reader.GetOrdinal("IsAdmin"));
				bool active = reader.GetBoolean(reader.GetOrdinal("Active"));
				//System.Diagnostics.Debug.Print($"{id}, {username}");

				User user = new User(username, id, password, firstname, lastname, phone, email, isreviewer, isadmin, active);

				users.Add(user);
			}
			



			conn.Close();


		}
	}
}
