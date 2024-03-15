using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseBaseMoney : UISkillInteraction
{
    int amount;
    public override void TriggerPerkEffect()
    {
        base.TriggerPerkEffect();
        gameManager.UpdateMoney(amount);
    }
}
