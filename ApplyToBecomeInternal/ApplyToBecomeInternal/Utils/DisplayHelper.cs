﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplyToBecomeInternal.Utils
{
	public static class DisplayHelper
	{
		public static string CalculatePercentage(int? whole, int? part)
		{
			if (!whole.HasValue || !part.HasValue)
			{
				return "";
			}
			return string.Format("{0:F0}%", 100 / whole * part);
		}
	}
}
