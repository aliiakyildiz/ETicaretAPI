﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstraction.Storage
{
    public interface IStorageService : IStorage
    {
        public string StorageName { get; }
    }
}
