namespace treloPOS.Application.DTOs.Identity;

public class LoginResponse{
    public string Token{get; set;} = string.Empty;
    public Guid UserId{get; set;}
    public string UserName{get; set;} = string.Empty;
    public Guid RoleId{get; set;}
    public string RoleName{get; set;} = string.Empty;
    public Guid OrganizationId{get; set;}
    public string OrganizationName{get; set;} = string.Empty;
}