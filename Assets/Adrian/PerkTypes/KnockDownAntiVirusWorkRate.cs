using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockDownAntiVirusWorkRate : UISkillInteraction
{
    public float WorkRateKnockback;

    public override void TriggerPerkEffect()
    {
        base.TriggerPerkEffect();
        gameManager.UpdateAntiVirusWorkRate(-WorkRateKnockback);
    }
}
