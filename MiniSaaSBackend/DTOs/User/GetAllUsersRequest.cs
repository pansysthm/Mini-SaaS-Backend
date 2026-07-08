namespace MiniSaaSBackend.DTOs.User;

public class GetAllUsersRequest
{
    public int Limit { get; set; } = 10;
    public int Offset { get; set; } = 0;
}