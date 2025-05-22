namespace OnlineEdu.WebUI.Services.TokenService
{
    public interface ITokenService
    {
        public string GetUserToken { get; }
        public int GetUserId { get; }
        public string GetUserRole { get; }
        public string GetUserNameSurname { get; }
    }
}
