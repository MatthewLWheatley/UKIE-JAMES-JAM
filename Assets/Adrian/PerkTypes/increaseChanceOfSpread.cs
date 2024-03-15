using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseChanceOfSpread : UISkillInteraction
{
    public float Value;

    public override void TriggerPerkEffect()
    {
        base.TriggerPerkEffect();
        gameManager.SpreadRate += Value;
    }
}
