﻿using Microsoft.AspNetCore.Identity;
using Nika1337.Library.ApplicationCore.Entities;
using System.Collections.Generic;

namespace Nika1337.Library.Infrastructure.Identity.Entities;

public class IdentityEmployeeRole : IdentityRole
{
    public ICollection<NavigationMenuItem> NavigationMenuItems { get; set; } = [];
}
