﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class Users
    {
        [Key]
        [Column("user_id")]
        public int user_id {  get; set; }
        public string username {  get; set; }
        public string password {  get; set; }
        public string role {  get; set; }
    }
}
