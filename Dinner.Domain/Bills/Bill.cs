using BuberDinner.Domain.Bills.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Bills
{
    public class Bill : AggregateRoot<BillId>
    {
        public DinnerId DinnerId { get; }
        public GuestId GuestId { get; }
        public HostId hostId { get; }
        public Price Price { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Bill (
            BillId billId,
            DinnerId dinnerId, 
            GuestId guestId, 
            HostId hostId, 
            Price price, 
            DateTime createdDateTime, 
            DateTime updatedDateTime) : base(billId)
        {
            DinnerId = dinnerId;
            GuestId = guestId;
            this.hostId = hostId;
            Price = price;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public Bill Create (
            DinnerId dinnerId,
            GuestId guestId,
            HostId hostId,
            Price price,
            DateTime createdDateTime,
            DateTime updatedDateTime)
        {
            return new Bill(BillId.CreateUnique(), dinnerId, guestId, hostId, price, createdDateTime, updatedDateTime);
        }
    }
}
