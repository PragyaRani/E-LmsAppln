﻿namespace User.Microservice.Repository
{
    internal class UserResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}