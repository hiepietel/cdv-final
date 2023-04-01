public class UserService: IUserService
{
    private readonly AppContext _appContext;
    public UserService(AppContext appContext)
    {
        _appContext = appContext;
    }

    
}