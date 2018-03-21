using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_2_Prototype
{
    abstract class Weapon
    {
        protected int Duration;
        protected int Damage;
        protected float Weight;
        protected float Length; 
        protected string DamageType;

        public abstract Weapon Clone();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Duration: " + Duration + ", ");
            sb.Append("Damage: " + Damage + ", ");
            sb.Append("Weight: " + Weight + ", ");
            sb.Append("Length: " + Length + ", ");
            sb.Append("Damage type: " + DamageType);

            return sb.ToString();
        }
    }
}
