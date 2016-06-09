using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpecialDelivery.Models;
using System.Collections.Concurrent;

namespace SpecialDelivery.Repositories
{
    public class MailingListRepository : Interfaces.IMailingListRepository
    {
        static ConcurrentDictionary<string, Models.MailingList> _mailingListItems =
            new ConcurrentDictionary<string, MailingList>();

        public MailingListRepository()
        {
            Add(new MailingList { Name = "Sample Mailing List" });
            Add(new MailingList { Name = "Another Mailing List" });
        }

        public MailingList Add(MailingList mailingList)
        {
            mailingList.Id = Guid.NewGuid().ToString();
            _mailingListItems[mailingList.Id] = mailingList;
            return mailingList;
        }

        public MailingList Find(string id)
        {
            return _mailingListItems[id];
        }

        public IEnumerable<MailingList> GetMailingLists()
        {
            return _mailingListItems.Values;
        }

        public MailingList Remove(string id)
        {
            MailingList item;
            _mailingListItems.TryRemove(id, out item);
            return item;
        }

        public MailingList Update(MailingList mailingList)
        {
            _mailingListItems[mailingList.Id] = mailingList;
            return mailingList;
        }
    }
}
