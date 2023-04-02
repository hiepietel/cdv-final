public interface IUserService {
    Task<string> Register(UserDto user);
    Task<string> Login(UserDto user);
    Task<User> GetMe();
}