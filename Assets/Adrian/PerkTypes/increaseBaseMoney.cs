using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseBaseMoney : UISkillInteraction
{
    public int amount;
    public override void TriggerPerkEffect()
    {
        base.TriggerPerkEffect();
        gameManager.UpdateBaseAmountOfMoney(amount);
    }
}
