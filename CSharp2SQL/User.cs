using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2SQL {
	class User {
		public string Username { get; set; }
		public int Id { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string Lastname { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public bool IsReviewer { get; set; }
		public bool IsAdmin { get; set; }
		public bool Active { get; set; }

		public User(string userName, int id, string password, string firstName, string lastName, string phone, string email, bool isReviewer, bool isAdmin, bool active) {
			Username = userName;
			Id = id;
			Password = password;
			FirstName = firstName;
			Lastname = lastName;
			Phone = phone;
			Email = email;
			IsReviewer = isReviewer;
			IsAdmin = isAdmin;
			Active = active;
				
		}

		public User() {

		}
	}
}
