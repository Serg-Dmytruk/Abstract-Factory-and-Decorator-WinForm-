using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankAndPattern.TanksClasses;

namespace TankAndPattern.AbstractFactoryClasses
{
    class NaziTankFactory : AbstractTankFactory
    {
        public override Tank CreateTank()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            return new PzKpfv(rand.Next(0, 100), rand.Next(0, 100), rand.Next(0, 100));
        }
    }
}
