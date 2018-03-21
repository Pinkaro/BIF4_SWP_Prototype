using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_2_Prototype
{
    class Sword : Weapon
    {
        public Sword(int duration, int damage, float weight, float length, string damageType)
        {
            base.Duration = duration;
            base.Damage = damage;
            base.Weight = weight;
            base.Length = length;
            base.DamageType = damageType; // string = immutable, keine Deepcopy notwendig
        }
        public override Weapon Clone()
        {
            return this.MemberwiseClone() as Weapon;
        }
    }
}
