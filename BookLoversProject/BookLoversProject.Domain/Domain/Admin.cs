﻿namespace BookLoversProject.Domain.Domain
{
    public class Admin : Entity, IUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
