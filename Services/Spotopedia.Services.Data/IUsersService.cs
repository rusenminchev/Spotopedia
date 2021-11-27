using Spotopedia.Web.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Spotopedia.Services.Data
{
    public interface IUsersService
    {
        Task EditAsync(EditUserProfileInputModel input);

        T GetUserDetails<T>(string id);

        int GetUsersCount();
    }
}
