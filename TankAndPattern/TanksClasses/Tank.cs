using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Policy;

namespace TankAndPattern.TanksClasses
{
    abstract class Tank
    {
        protected int amunition;
        protected int armor;
        protected int maneuverAbility;
        protected Tank(int _amunition, int _armor, int _maneuverAbility)
        {
            amunition = _amunition;
            armor = _armor;
            maneuverAbility = _maneuverAbility;
        }
        public Tank() { }
        public abstract int GetTankPower();
        
    }
}
