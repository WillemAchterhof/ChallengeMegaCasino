using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeMegaCasino
{
	public class GetDisplayStrings
	{
		public static string NoMoneyLeft()
		{
			string result = string.Format($"Sorry, you don't have enough credit, please give us more of your money!");
			return result;
		}
		public static string AvailibleMoney(double _playersMonegy)
		{
			string result = string.Format($"Player's money: {_playersMonegy:c2}");
			return result;
		}
		public static string NoBetPlaced()
		{
			string result = string.Format($"You haven't placed a valid bet!");
			return result;
		}
		public static string LostBet(double _moneyBet)
		{
			string result = string.Format($"Sorry, you lost {_moneyBet:c2}, better luck next time.");
			return result;
		}
		public static string WonBet(double _moneyBet, double _moneyWon)
		{
			string result = string.Format($"You did bet {_moneyBet:c2} and won {_moneyWon:c2}!");
			return result;
		}
		public static string ImageUrl(string _image)
		{
			string result = string.Format($"\\Images\\{_image}.png");
			return result;
		}

	}
}