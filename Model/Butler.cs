﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Butler : ITaskProcessorContainer
    {

        private ITaskProcessor _TaskProcessor;
        public ITaskProcessor TaskProcessor { get; }
    }
}
