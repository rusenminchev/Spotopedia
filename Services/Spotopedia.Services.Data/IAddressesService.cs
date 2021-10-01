namespace Spotopedia.Services.Data
{
    using System.Collections.Generic;

    public interface IAddressesService
    {
        IEnumerable<T> GetAllAddresses<T>();
    }
}
