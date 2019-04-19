using SQLite;
using System;

namespace timesheet.Models
{
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public bool Type { get; set; }
        [Unique]
        public string Mail { get; set; }
        [Unique]
        public string Password { get; set; }
        public DateTime MD_Date { get; set; }
        public DateTime CR_Date { get; set; }
    }
}
