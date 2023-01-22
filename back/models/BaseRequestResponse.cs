namespace back.models;

public class BaseRequestResponse{
    
    public bool IsSuccesfull { get; set; }

    public string MSG { get; set; }

    public int ResponseCode { get; set; }
}