namespace Lands8.Models
{
    using Newtonsoft.Json;


    public class RegionalBloc
    {

        [JsonProperty(PropertyName = "acronym")]
        public string Acronym { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
}
