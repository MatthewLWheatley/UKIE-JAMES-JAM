using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackAntiVirusCurrentState : UISkillInteraction
{
    public float KnockbackValue;

    public override void TriggerPerkEffect()
    {
        base.TriggerPerkEffect();
        gameManager.UpdateCurrentAntiVirusState(-KnockbackValue);
    }
}
