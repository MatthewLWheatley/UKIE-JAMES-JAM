using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseCorruptionRate : UISkillInteraction
{
    public float corruptionRateChange;
    public override void TriggerPerkEffect()
    {
        base.TriggerPerkEffect();
        gameManager.UpdateCorruptionRate(corruptionRateChange);
    }
}
