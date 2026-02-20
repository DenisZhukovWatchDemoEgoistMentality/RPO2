using System.ComponentModel.DataAnnotations.Schema;

namespace BucketWithBolts.Models
{
    public class Correspondence
    {
        public int Recipient_Id { get; set; }
        public int Sender_Id { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        
        #region
        [ForeignKey(nameof(Recipient_Id))]
        public User Recipient { get; set; }
        [ForeignKey(nameof(Sender_Id))]
        public User Sender { get; set; }
        #endregion
    }
}
