﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IService
    {
        void insertFile(string[] file);
        void RegisterServices();
        void Disposeservices();
    }
}
