using Newtonsoft.Json;

public class JoinCodeDto
{
    [JsonProperty("joinCode")]
    public string JoinCode { get; set; }
}

public class SuccessDto
{
    [JsonProperty("message")]
    public string Message { get; set; }
}