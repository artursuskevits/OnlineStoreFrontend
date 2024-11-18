namespace SolomikovPod.Services
{
    public class UserStateService
    {
        private int? CurrentUserId { get; set; }

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

        public bool IsUserLoggedIn()
        {
            return CurrentUserId.HasValue;
        }

        public void ClearUserState()
        {
            CurrentUserId = null;
        }
    }
}
