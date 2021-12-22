namespace Spotopedia.Services.Data
{
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Spotopedia.Data.Common.Repositories;
    using Spotopedia.Data.Models;
    using Spotopedia.Services.Mapping;
    using Spotopedia.Web.ViewModels.Users;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IDeletableEntityRepository<Spot> spotsRepository;
        private readonly ISpotVotesService spotVotesService;

        public UsersService(
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            ICloudinaryService cloudinaryService,
            IDeletableEntityRepository<Spot> spotsRepository,
            ISpotVotesService spotVotesService)
        {
            this.usersRepository = usersRepository;
            this.cloudinaryService = cloudinaryService;
            this.spotsRepository = spotsRepository;
            this.spotVotesService = spotVotesService;
        }

        public async Task EditAsync(EditUserProfileInputModel input)
        {
            var user = this.usersRepository.All()
                .FirstOrDefault(x => x.Id == input.Id);

            if (input.ProfileImage is not null)
            {
                await using var memoryStream = new MemoryStream();
                await input.ProfileImage.CopyToAsync(memoryStream);
                var destinationData = memoryStream.ToArray();

                var profileImageUrl = await this.cloudinaryService.UploadPictureAsync(destinationData, "ProfileImage", "UsersProfileImages", 500, 500);

                var avatarImageUrl = await this.cloudinaryService.UploadPictureAsync(destinationData, "AvatarImage", "UsersProfileImages", 64, 64);

                user.ProfileImageUrl = profileImageUrl;

                user.AvatarImageUrl = avatarImageUrl;
            }

            user.FirstName = input.FirstName;
            user.LastName = input.LastName;
            user.SportType = input.SportType;
            user.Bio = input.Bio;
            user.City = input.City;
            user.Gender = input.Gender;
            user.FacebookUrl = input.FacebookUrl;
            user.InstagramUrl = input.InstagramUrl;
            user.TikTokUrl = input.TikTokUrl;
            user.TwitterUrl = input.TwitterUrl;
            user.WebsiteUrl = input.WebsiteUrl;

            this.usersRepository.Update(user);
            await this.usersRepository.SaveChangesAsync();
        }

        public T GetUserDetails<T>(string id)
        {
            return this.usersRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();
        }

        public int GetUsersCount()
        {
            return this.usersRepository.AllAsNoTracking().Count();
        }

        public bool IsThisUserOwnThisProfile(string currentUserId, string profileOwnerId)
        {
            return this.usersRepository.All()
                .Any(x => x.Id == currentUserId && x.Id == profileOwnerId);
        }
    }
}
