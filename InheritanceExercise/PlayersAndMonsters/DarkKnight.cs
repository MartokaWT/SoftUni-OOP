﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndMonsters
{
	public class DarkKnight : Knight
	{
		public DarkKnight(string username, int level) : base(username, level)
		{
			Username = username;
			Level = level;
		}
	}
}