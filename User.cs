using System;

public class User
{
	public int userId;
	public int row;
	public string userFirstName;
	public string userLastName;
	public int userPin;
	public int accoundCode;
	public int agencyCode;
	public double availableBalance;

	public User(int userId, string userFirstName, string userLastName, int userPin, int accountCode, int agencyCode, double availableBalance)
	{
		this.userId = userId;
		this.userFirstName = userFirstName;
		this.userLastName = userLastName;
		this.userPin = userPin;
		this.accoundCode = accountCode;
		this.agencyCode = agencyCode;
		this.availableBalance = availableBalance;
	}

	public bool PerformAction(string action)
    {
		return true;
    }

	private bool Deposit(float amount)
    {
		this.availableBalance += amount;
		return true;
    }

	private bool Withdrawal(float amount)
    {
		this.availableBalance -= amount;
		return true;
    }
}
