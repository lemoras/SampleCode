﻿namespace Member.Domain
{
    public interface IApplicationContext
    {
        int UserId { get; }

        string Token { get; }
    }
}
