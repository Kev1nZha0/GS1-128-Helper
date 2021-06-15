using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS1_128_Helper
{
	/// <summary>Enumeration to define special actions during data-parse</summary>
	internal enum SpecialAction
	{
		/// <summary>no special action</summary>
		none = -1,
		/// <summary>fill day with 0s if not in data</summary>
		FillDayWithZeroIfEmpty = 10,
		/// <summary>point-position is defined by fourth place of application identifier</summary>
		FourthDigitPointPosition = 25,
		/// <summary>The first three signs in content are a country-code</summary>
		FirstThreeDigitsCountryCode = 37
	}
}
