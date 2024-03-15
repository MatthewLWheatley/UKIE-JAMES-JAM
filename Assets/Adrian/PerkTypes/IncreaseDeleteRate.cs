using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDeleteRate : UISkillInteraction
{
    public float DeathRateIncrease;

    public override void TriggerPerkEffect()
    {
        base.TriggerPerkEffect();
        gameManager.UpdateDeleteRate(DeathRateIncrease);
    }
}
