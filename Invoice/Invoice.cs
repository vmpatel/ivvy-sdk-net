using Ivvy.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ivvy.Invoice
{
    public class Invoice
    {
        public enum StatusOptions
        {
            NotPaid = 0,
            UnConfirmedPaid = 1,
            Paid = 2,
            WrittenOff = 3,
            Cancelled = 4,
            Refunded = 5
        }

        public enum RefTypes
        {
            Custom = 0,
            EventRegistration = 1,
            MembershipSignUp = 2,
            MembershipRenewal = 3,
            VenueBooking = 4
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("totalCost")]
        public float? TotalCost { get; set; }

        [JsonProperty("totalTaxCost")]
        public float? TotalTaxCost { get; set; }

        [JsonProperty("amountPaid")]
        public float? AmountPaid { get; set; }

        [JsonProperty("toContactEmail")]
        public string ToContactEmail { get; set; }

        [JsonProperty("toContactName")]
        public string ToContactName { get; set; }

        [JsonProperty("currentStatus")]
        public StatusOptions CurrentStatus { get; set; }

        [JsonProperty("createdDate")]
        public string CreatedDate { get; set; }

        [JsonProperty("modifiedDate")]
        public string ModifiedDate { get; set; }

        [JsonProperty("refType")]
        public RefTypes RefType { get; set; }

        [JsonProperty("refId")]
        public string refId { get; set; }

        [JsonProperty("taxRateUsed")]
        public string taxRateUsed { get; set; }

        [JsonProperty("isTaxCharged")]
        public string isTaxCharged { get; set; }

        [JsonProperty("paymentDueDate")]
        public string PaymentDueDate { get; set; }

        [JsonProperty("eventId")]
        public long? EventId { get; set; }

        [JsonProperty("venueId")]
        public long? VenueId { get; set; }

        [JsonProperty("toContactId")]
        public string ToContactId { get; set; }

        [JsonProperty("Contact")]
        public Contact.Contact Contact { get; set; }

        [JsonProperty("toAddress")]
        public Address ToAddress { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [JsonProperty("payments")]
        public List<InvoicePayment> Payments { get; set; }

        [JsonProperty("bookingCode")]
        public string BookingCode { get; set; }
    }
}
