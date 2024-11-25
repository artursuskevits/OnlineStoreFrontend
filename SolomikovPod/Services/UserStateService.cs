public class UserStateService
{
    private int? _currentUserId;

    public void SetCurrentUserId(int userId)
    {
        _currentUserId = userId;
    }

    public int GetCurrentUserId()
    {
        return _currentUserId ?? -1;
    }

    public bool IsLoggedIn()
    {
        return _currentUserId.HasValue;
    }

    public void Logout()
    {
        _currentUserId = null;
    }

}
