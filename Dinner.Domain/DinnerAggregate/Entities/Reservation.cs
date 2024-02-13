using BuberDinner.Domain.Bills.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Dinner.Entities
{
    public class Reservation : Entity<ReservationId>
    {
        public int GuestCount { get; }
        public string ReservationStatus { get; }
        public GuestId GuestId { get; }
        public BillId BillId { get; }
        public DateTime? ArrivalDateTime { get; private set; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Reservation(
            ReservationId reservationId,
            int guestCount,
            string reservationStatus,
            GuestId guestId,
            BillId billId,
            DateTime createdDateTime,
            DateTime updatedDateTime)
        : base(reservationId)
        {
            GuestCount = guestCount;
            ReservationStatus = reservationStatus;
            GuestId = guestId;
            BillId = billId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Reservation Create(
            int guestCount,
            string reservationStatus,
            GuestId guestId,
            BillId billId)
        {
            return new(
                ReservationId.CreateUnique(),
                guestCount,
                reservationStatus,
                guestId,
                billId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
