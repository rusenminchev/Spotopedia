namespace Spotopedia.Services.Data
{
    using System.Threading.Tasks;

    using Spotopedia.Web.ViewModels.Users;

    public interface IUsersService
    {
        Task EditAsync(EditUserProfileInputModel input);

        T GetUserDetails<T>(string id);

        int GetUsersCount();

        bool IsThisUserOwnThisProfile(string currentUserId, string profileOwnerId);
    }
}
