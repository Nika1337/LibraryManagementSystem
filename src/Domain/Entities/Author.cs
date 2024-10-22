﻿using System;
using System.Collections.Generic;


namespace Nika1337.Library.Domain.Entities;

public class Author : BaseModel
{
    public required string Name { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required bool IsAlive { get; set; }
    public required string Biography { get; set; }
    public ICollection<Book> Books { get; } = [];
}