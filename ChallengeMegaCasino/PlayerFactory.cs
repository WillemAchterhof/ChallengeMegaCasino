using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeMegaCasino
{
	public class PlayerFactory
	{
		public static Player Create()
		{
			return new Player();
		}

	}
}