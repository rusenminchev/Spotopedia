using Spotopedia.Web.ViewModels.Challenges;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Spotopedia.Services.Data
{
    public interface IChallengesService
    {
        Task CreateAsync(CreateChallengeInputModel input, string userId);

        T GetChallengeDetails<T>(string id);

        IEnumerable<T> GetAll<T>();

        Task EditAsync(string id, EditChallengeInputModel input);
    }
}
