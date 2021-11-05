using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Factory
{
    public abstract class Ability
    {
        public abstract void Process();
    }

    public class ShootAbility : Ability
    {
        private PlayerShoot ps;

        public override void Process()
        {
            ps.Shoot();
        }
    }

    public class AbilityFactory
    {
        public Ability GetAbility(string abilityType)
        {
            switch(abilityType)
            {
                case "shoot":
                    return new ShootAbility();
                default:
                    return null;
            }
        }
    }

}
