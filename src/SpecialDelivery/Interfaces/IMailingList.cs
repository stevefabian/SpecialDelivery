using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecialDelivery.Interfaces
{
    public interface IMailingListRepository
    {
        Models.MailingList Add(Models.MailingList mailingList);
        IEnumerable<Models.MailingList> GetMailingLists();
        Models.MailingList Find(string id);
        Models.MailingList Remove(string id);
        Models.MailingList Update(Models.MailingList mailingList);
    }
}
