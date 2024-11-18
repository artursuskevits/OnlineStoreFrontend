namespace SolomikovPod.Services
{
    public class UserStateService
    {
        public int? CurrentUserId { get; set; } = null;

        public void SetCurrentUserId(int userId)
        {
            CurrentUserId = userId;
        }

        public int GetCurrentUserId()
        {
            if (CurrentUserId == null)
                throw new InvalidOperationException("User is not logged in.");

            return CurrentUserId.Value;
        }

        public void ClearUserState()
        {
            CurrentUserId = null;
        }

    }
}
