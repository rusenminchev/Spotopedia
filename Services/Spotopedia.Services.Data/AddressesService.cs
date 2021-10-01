namespace Spotopedia.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using Spotopedia.Data.Common.Repositories;
    using Spotopedia.Data.Models;
    using Spotopedia.Services.Mapping;

    public class AddressesService : IAddressesService
    {
        private readonly IDeletableEntityRepository<Address> addressesRepository;

        public AddressesService(IDeletableEntityRepository<Address> addressesRepository)
        {
            this.addressesRepository = addressesRepository;
        }

        public IEnumerable<T> GetAllAddresses<T>()
        {
            return this.addressesRepository.All()
                 .To<T>()
                 .ToList();
        }
    }
}
