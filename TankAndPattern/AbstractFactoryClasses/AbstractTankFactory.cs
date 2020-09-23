using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankAndPattern.AbstractFactoryClasses
{
    abstract class AbstractTankFactory
    {
        public abstract TankAndPattern.TanksClasses.Tank CreateTank();
    }
}
