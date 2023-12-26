using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GearHonService.Services
{
	public class CurrencyLoader
	{
		private const string EcbUrl = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";

		public async Task<List<CurrencyModel>> LoadCurrenciesAsync()
		{
			var httpClient = new HttpClient();
			var response = await httpClient.GetStringAsync(EcbUrl);

			var xDocument = XDocument.Parse(response);
			XNamespace ns = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref";

			var currencies = new List<CurrencyModel>();

			foreach (var cubeElement in xDocument.Descendants(ns + "Cube"))
			{
				if (cubeElement.Attribute("currency") != null && cubeElement.Attribute("rate") != null)
				{
					var currency = new CurrencyModel
					{
						Code = cubeElement.Attribute("currency").Value,
						Rate = decimal.Parse(cubeElement.Attribute("rate").Value)
					};

					currencies.Add(currency);
				}
			}

			return currencies;
		}
	}
}
