using IS_Proekt.Domain;
using System;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IPublisherService
    {
        IEnumerable<Publisher> GetAllPublishers();
        Publisher GetPublisherDetails(Guid publisherId);
        bool AddPublisher(Publisher publisher);
        bool UpdatePublisher(Publisher publisher);
        bool DeletePublisher(Guid publisherId);
    }
}
