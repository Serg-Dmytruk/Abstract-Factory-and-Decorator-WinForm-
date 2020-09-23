using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankAndPattern.AbstractFactoryClasses
{
    class PzKpfv : TanksClasses.Tank
    {
        public Image texture { get; set; }
        public PzKpfv(int _amunition, int _armor, int _maneuverAbility) : base(_amunition, _armor, _maneuverAbility) { texture = Resource1.Pz_Kpfw_IV_G_preview; }
        public override int GetTankPower()
        {
            return armor + amunition + maneuverAbility;
        }
    }
}
