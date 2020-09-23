using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankAndPattern.TanksClasses;

namespace TankAndPattern.DecoratorClasses
{
    abstract class ShotDecorator : Tank
    {
        protected Tank tank;
        public abstract void SetTank(Tank tankType);
        public override int GetTankPower()
        {
            if (tank != null)
                return tank.GetTankPower();
            else
                return -1;
        }

    }
}
