using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace aspdotnetCORETest.DataContracts
{
    public class Employee
	{
		[JsonProperty("id")]
		public int id { get; set; }
		
		[JsonProperty("employee_name")]
        public string employee_name { get; set; }

		[JsonProperty("employee_salary")]
        public int employee_salary { get; set; }

		[JsonProperty("employee_age")]
        public int employee_age { get; set; }
    }
}