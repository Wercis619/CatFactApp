using System.Text.Json.Serialization;

namespace CatFactApp.Models
{
    public class CatFact
    {
        private string fact = string.Empty;
        private int length;

        [JsonPropertyName("fact")]
        public string Fact
        {
            get { return fact; }
            set { fact = value; }
        }

        [JsonPropertyName("length")]
        public int Length
        {
            get { return length; }
            set { length = value; }
        }
        
    }
}
