namespace HCI.Models.Database
{
    using HCI.Utils;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("mails")]
    public class Mail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [Index("ix_mails_receiverid")]
        public int receiver_id { get; set; }

        [Required]
        [Index("ix_mails_senderid")]
        public int sender_id { get; set; }

        [Required]
        public MailType mail_type { get; set; }

        [Required]
        public YesNo readed { get; set; }

        [Required]
        [StringLength(255)]
        public string subject { get; set; }

        [StringLength(4000)]
        public string content { get; set; }
        public User Receiver { get; set; }

        public User Sender { get; set; }

        public int related_id_01 { get; set; }

        public int related_id_02 { get; set; }

    }
}