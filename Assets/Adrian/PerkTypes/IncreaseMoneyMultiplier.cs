using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseMoneyMultiplier : UISkillInteraction
{
    public float AmountToIncrease;
    public override void TriggerPerkEffect()
    {
        base.TriggerPerkEffect();
        gameManager.UpdateMoneyGainRate(AmountToIncrease);
    }

}
