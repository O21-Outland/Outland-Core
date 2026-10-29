using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace Outland
{
    [StaticConstructorOnStartup]
    public static class Util_DiceRoll
    {
        public enum DiceRollResult
        {
            CriticalFail,
            RoughFail,
            Fail,
            CloseSuccess,
            Success,
            CriticalSuccess
        }

        public static int Roll20Raw(out bool success, int min = 10)
        {
            int D20Rolled = Rand.Range(1, 20);
            if(D20Rolled < min)
            {
                success = false;
            }
            else
            {
                success = true;
            }
            return D20Rolled;
        }

        public static DiceRollResult RollD20(int min = 10)
        {
            DiceRollResult result = DiceRollResult.Success;
            int D20Rolled = Rand.Range(1, 20);

            if (min >= 21)
            {
                // You knew you couldn't but tried anyway, get fucked.
                return DiceRollResult.CriticalFail;
            }
            if (min <= 0)
            {
                // Guaranteed success.
                if(D20Rolled == 20)
                {
                    return DiceRollResult.CriticalSuccess;
                }
                return DiceRollResult.Success;
            }

            if (D20Rolled < min)
            {
                if (D20Rolled == 1)
                {
                    result = DiceRollResult.CriticalFail;
                }
                else if (D20Rolled < (min / 2))
                {
                    result = DiceRollResult.RoughFail;
                }
                else
                {
                    result = DiceRollResult.Fail;
                }
            }
            else
            {
                if(D20Rolled == 20)
                {
                    result = DiceRollResult.CriticalSuccess;
                }
                else if(D20Rolled == min)
                {
                    result = DiceRollResult.CloseSuccess;
                }
                else
                {
                    result = DiceRollResult.Success;
                }
            }
            return result;
        }
    }
}
