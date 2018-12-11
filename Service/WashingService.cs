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
            Cloth[] cloths; 

            _kitchen.Clerk.TaskProcessor.AddTask(() =>
            {
                cloths = _kitchen.WashingMachine.Retrieve().ToArray();
            }, 5);

            _kitchen.Clerk.TaskProcessor.AddTask(() =>
            {
                _kitchen.Counter.AddCloths(cloths);
            });
        }

        public bool IsDirtyCuttlery()
        {
            if(_kitchen.DirtyStorage.WasheableTools.Where(x => x.WashRequirement == WashRequirement.DishMachine).Any())
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
            Cloth[] DirtyCloths;

            _kitchen.Clerk.TaskProcessor.AddTask(() =>
            {
                DirtyCloths = _kitchen.DirtyStorage.Cloths;
            });

            _kitchen.Clerk.TaskProcessor.AddTask(() =>
            {
                _kitchen.WashingMachine.AddDirtyCloths(DirtyCloths.ToList());
            });
        }

        public void StartWashingMachine()
        {
            // Task
        }

        public bool IsDirtyTools()
        {
            if (_kitchen.DirtyStorage.WasheableTools.Where(x => x.WashRequirement == WashRequirement.Sink).Any())
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
