using Newtonsoft.Json;

namespace BelleBridal.API.Data
{
	public class MagazineAdvertiser
	{
		[JsonProperty("advertiser")]
		public Advertiser Advertiser;
		[JsonProperty("page")]
		public int Page;
	}
}
