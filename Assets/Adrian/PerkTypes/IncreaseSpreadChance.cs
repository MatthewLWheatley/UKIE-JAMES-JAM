using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSpreadChance : UISkillInteraction
{
    public float spreadChance;
    public override void TriggerPerkEffect()
    {
        base.TriggerPerkEffect();
        gameManager.UpdateSpreadChance(spreadChance);
    }

}
