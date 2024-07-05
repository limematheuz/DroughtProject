﻿using System.ComponentModel.DataAnnotations;

namespace DroughtProject.Models;

public class Users
{
    [Key]
    public  int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}