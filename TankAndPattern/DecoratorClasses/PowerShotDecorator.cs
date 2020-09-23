using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankAndPattern.DecoratorClasses
{
    class PowerShotDecorator : ShotDecorator
    {
        private const int shotModificator = 10;
        public override void SetTank(TanksClasses.Tank tankType)
        {
            tank = tankType;
        }
        public override int GetTankPower()
        {
            return base.GetTankPower() + shotModificator;
        }
    }
}
