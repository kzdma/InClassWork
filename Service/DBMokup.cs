using InClassWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClassWork.Service
{
	public class DBMokup
	{
		private List<AppUser> _users = new List<AppUser>();
		public DBMokup()
		{
			_users.Add(
				new AppUser 
				{ 
					FirstName = "Tomer", 
					LastName = "Marty", 
					UserEmail = "admin@mail.com", 
					UserPassword = "123456",
					RegDate = DateTime.Now.ToShortDateString(),
					IsAdmin =true
				});
			_users.Add(
				new AppUser 
				{ 
					FirstName = "Amir", 
					LastName = "Mayo", 
					UserEmail = "user1@mail.com", 
					UserPassword = "pass1",
					RegDate= DateTime.Now.ToShortDateString(),
					IsAdmin = false
				});
			_users.Add(
				new AppUser
				{
					FirstName = "Galit",
					LastName = "Nuvy",
					UserEmail = "user2@mail.com",
					UserPassword = "pass2",
					RegDate = DateTime.Now.ToShortDateString(),
					IsAdmin = false
				});
			_users.Add(
				new AppUser
				{
					FirstName = "Tomer",
					LastName = "Guta",
					UserEmail = "user3@mail.com",
					UserPassword = "pass3",
					RegDate = DateTime.Now.ToShortDateString(),
					IsAdmin = false
				});
			_users.Add(
				new AppUser
				{
					FirstName = "Dana",
					LastName = "Novik",
					UserEmail = "user4@mail.com",
					UserPassword = "pass4",
					RegDate = DateTime.Now.ToShortDateString(),
					IsAdmin = false
				});
			_users.Add(
				new AppUser
				{
					FirstName = "Avi",
					LastName = "Shalom",
					UserEmail = "user5@mail.com",
					UserPassword = "pass5",
					RegDate = DateTime.Now.ToShortDateString(),
					IsAdmin = false
				});
			_users.Add(
				new AppUser
				{
					FirstName = "Gili",
					LastName = "Rotem",
					UserEmail = "user6@mail.com",
					UserPassword = "pass6",
					RegDate = DateTime.Now.ToShortDateString(),
					IsAdmin = false
				});
			_users.Add(
				new AppUser
				{
					FirstName = "Moshe",
					LastName = "Fragment",
					UserEmail = "user7@mail.com",
					UserPassword = "pass7",
					RegDate = DateTime.Now.ToShortDateString(),
					IsAdmin = false
				});

		}

		public List<AppUser> GetUsers()
		{
			return _users;
		}
		public bool isExist(string uEmail, string uPass)
		{
			return _users.Any(u => u.UserEmail == uEmail && u.UserPassword == uPass);
		}

		public AppUser? GetUserByEmail(string uEmail)
		{
			return _users.FirstOrDefault(u => u!.UserEmail == uEmail, null);
		}

		public void Insert(AppUser user)
		{
			_users.Add(user);
		}
		public void Delete(AppUser user)
		{
			if (user != null && _users.Contains(user))
			{
				_users.Remove(user);
			}
		}
		public void Update(AppUser user)
		{
			if (user != null && _users.Contains(user))
			{
				var index = _users.IndexOf(user);
				if (index >= 0)
				{
					_users[index] = user;
				}
			}
		}
	}
}
