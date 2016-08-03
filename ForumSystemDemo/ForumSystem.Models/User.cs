namespace ForumSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Enums;

    public class User
    {
        private ICollection<Question> questions;
        private ICollection<Answer> answers;
        private ICollection<User> friends;

        public User()
        {
            this.questions = new HashSet<Question>();
            this.answers = new HashSet<Answer>();
            this.friends = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        public UserInfo UserInfo { get; set; }

        public Gender Gender { get; set; }

        public DateTime? Birthday { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        [Column("NickName")]
        public string UserName { get; set; }

        public DateTime RegisteredOn { get; set; }

        public virtual ICollection<Question> Questions
        {
            get
            {
                return this.questions;
            }

            set
            {
                this.questions = value;
            }
        }

        public virtual ICollection<Answer> Answers
        {
            get
            {
                return this.answers;
            }

            set
            {
                this.answers = value;
            }
        }

        public virtual ICollection<User> Friends
        {
            get
            {
                return this.friends;
            }

            set
            {
                this.friends = value;
            }
        }

        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
