using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackAntiDownload : UISkillInteraction
{
    public float KnockbackAmount;

    public override void TriggerPerkEffect()
    {
        base.TriggerPerkEffect();
        gameManager.UpdateAntiVirusDownload(-KnockbackAmount);
    }
}
