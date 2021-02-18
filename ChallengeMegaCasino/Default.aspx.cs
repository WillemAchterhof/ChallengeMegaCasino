using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeMegaCasino
{
	public partial class Default : System.Web.UI.Page
	{
		string[] storeImages = new string[] { "Bar", "Bell", "Cherry", "Clover", "Diamond", "HorseShoe", "Lemon", "Orange", "Plum", "Seven", "Strawberry", "Watermellon" };
		string[] resultImages = new string[3];
		Random randomImage = new Random();
		Player player = PlayerFactory.Create();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				SetImages();

				player.Money = 100;
				moneyLabel.Text = GetDisplayStrings.AvailibleMoney(player.Money);

				ViewState.Add("AvailibleMoney", player.Money);
			}
		}
		protected void OkButton_Click(object sender, EventArgs e)
		{
			player.Money = (double)ViewState["AvailibleMoney"];
			double.TryParse(placeBetTextBox.Text, out double placedBet);

			if (placedBet <= 0)
			{
				resultLabel.Text = GetDisplayStrings.NoBetPlaced();
			}
			else if (!CheckPlayerMoney(player.Money, placedBet)) { resultLabel.Text = GetDisplayStrings.NoMoneyLeft(); }
			else
			{
				SetImages();

				double moneyWon = placedBet * getImageResult();
				if (moneyWon > 0)
				{
					player.Money += moneyWon;
					resultLabel.Text = GetDisplayStrings.WonBet(placedBet, moneyWon);
				}
				else
				{
					player.Money -= placedBet;
					resultLabel.Text = GetDisplayStrings.LostBet(placedBet);
				}

				moneyLabel.Text = GetDisplayStrings.AvailibleMoney(player.Money);
				ViewState["AvailibleMoney"] = player.Money;
			}

		}

		private double getImageResult()
		{
			if (resultImages[0] == "Bar"
				|| resultImages[1] == "Bar"
				|| resultImages[2] == "Bar")
			{ return 0; }
			else if (resultImages[0] == "Seven"
				&& resultImages[1] == "Seven"
				&& resultImages[2] == "Seven")
			{ return 100; }
			else if (resultImages[0] == "Cherry"
				|| resultImages[1] == "Cherry"
				|| resultImages[2] == "Cherry")
			{ return CherryCalculator(); }
			else { return 0; }
		}
		private double CherryCalculator()
		{
			if ((resultImages[0] == "Cherry"
				&& resultImages[1] == "Cherry")
				|| (resultImages[0] == "Cherry"
				&& resultImages[2] == "Cherry")
				|| (resultImages[1] == "Cherry"
				&& resultImages[2] == "Cherry"))
			{ return 3; }
			else if (resultImages[0] == "Cherry"
				&& resultImages[1] == "Cherry"
				&& resultImages[2] == "Cherry")
			{ return 4; }
			else { return 2; }
		}

		protected void SpendMoreButton_Click(object sender, EventArgs e)
		{
			player.Money = (double)ViewState["AvailibleMoney"];

			double.TryParse(spendMoreTextBox.Text, out double _addMoney);
			if (_addMoney > 0)
			{
				player.Money += _addMoney;
				moneyLabel.Text = GetDisplayStrings.AvailibleMoney(player.Money);
				ViewState["AvailibleMoney"] = player.Money;
			}

			spendMoreTextBox.Text = string.Empty;
		}
		private bool CheckPlayerMoney(double _playerMoney, double _placedBet)
		{
			if (_playerMoney == 0) { return false; }
			else if (_playerMoney - _placedBet < 0) { return false; }
			else { return true; }
		}
		private void SetImages()
		{
			firstImage.ImageUrl = GetImage(0);
			secondImage.ImageUrl = GetImage(1);
			thirdImage.ImageUrl = GetImage(2);
		}
		private string GetImage(int _imageLocation)
		{
			string _image = storeImages[randomImage.Next(storeImages.Length)];
			string _imageUrl = GetDisplayStrings.ImageUrl(_image);

			resultImages[_imageLocation] = _image;

			return _imageUrl;
		}
	}

}