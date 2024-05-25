using Newtonsoft.Json;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }

    public static User FromJson(string jsonString)
    {
        return JsonConvert.DeserializeObject<User>(jsonString);
    }
}