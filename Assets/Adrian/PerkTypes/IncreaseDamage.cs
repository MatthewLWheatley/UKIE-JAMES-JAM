using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDamage : UISkillInteraction
{
    public int damageValue;
    public override void TriggerPerkEffect()
    {
        base.TriggerPerkEffect();
        gameManager.UpdateDamage(damageValue);

    }
}
