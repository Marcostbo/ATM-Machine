using System;

public class User
{
	public int userId;
	public int row;
	public string userFirstName;
	public string userLastName;
	public string fullName;
	public int userPin;
	public int accoundCode;
	public int agencyCode;
	public double availableBalance;

	public User(int userId, string userFirstName, string userLastName, int userPin, int accountCode, int agencyCode, double availableBalance)
	{
		this.userId = userId;
		this.userFirstName = userFirstName;
		this.userLastName = userLastName;
		this.fullName = userFirstName + " " + userLastName;
		this.userPin = userPin;
		this.accoundCode = accountCode;
		this.agencyCode = agencyCode;
		this.availableBalance = availableBalance;
	}

	public string PerformAction(string action, double amount)
    {	
		if (action == "Deposit")
        {
			double original_balance = this.availableBalance; 
			Deposit(amount: amount);
			double final_balance = this.availableBalance;
			return "Deposit confirmed. Balance changed from " + original_balance + " to " + final_balance;
        }
		else if (action == "Withdrawal")
		{
			if (amount > this.availableBalance)
            {
				return "Insuficcient balance";
            }
			double original_balance = this.availableBalance;
			Withdrawal(amount: amount);
			double final_balance = this.availableBalance;
			return "Withdrawal confirmed. Printing " + amount + ". Balance changed from " + original_balance + " to " + final_balance;
		}
        else
        {
			return "Invalid action";
        }
    }

	private bool Deposit(double amount)
    {
		this.availableBalance += amount;
		return true;
    }

	private bool Withdrawal(double amount)
    {
		this.availableBalance -= amount;
		return true;
    }
}
