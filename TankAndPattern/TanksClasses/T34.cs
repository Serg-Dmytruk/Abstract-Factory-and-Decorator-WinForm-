using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TankAndPattern.AbstractFactoryClasses
{
    class T34 : TanksClasses.Tank
    {
        public Image texture { get; set;}
        public T34(int _amunition, int _armor, int _maneuverAbility) : base (_amunition, _armor, _maneuverAbility) { texture = Resource1.T34_preview; }
        public override int GetTankPower()
        {
            return armor + amunition + maneuverAbility;
        }
    }
}
