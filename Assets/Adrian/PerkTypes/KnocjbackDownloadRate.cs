using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnocjbackDownloadRate : UISkillInteraction
{
    public float RateDecreaseAmount;
    public override void TriggerPerkEffect()
    {
        base.TriggerPerkEffect();
        gameManager.UpdateDownloadRate(-RateDecreaseAmount);
    }

}
