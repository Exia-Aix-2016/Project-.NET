﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class WashingService
    {
        private Kitchen _kitchen;

        public WashingService(Kitchen kitchen)
        {
            this._kitchen = kitchen;
        }

        public bool IsWashingMachineFinished()
        {
            return _kitchen.WashingMachine.Available;
        }

        public void FreeWashingMachine()
        {
            // Task
        }

        public bool IsDirtyCuttlery()
        {
            if(_kitchen.DirtyStorage.Tools.Where(x => x.WasherType == WashersType.WashingMachine).Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void FillWashingMachine()
        {
            // Task
        }

        public void StartWashingMachine()
        {
            // Task
        }

        public bool IsDirtyTools()
        {
            if (_kitchen.DirtyStorage.Tools.Where(x => x.WasherType == WashersType.Sink).Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Wash()
        {
            // Task
        }
    }
}
