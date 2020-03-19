﻿using System.Collections;
using UnityEngine;

public class StartBattleInteraction : Interaction
{
    public EncounterSet encounterSet;
    public Sprite battlegroundSprite;
    private bool finished;
    
    public override void Run(Interactable source)
    {
        finished = false;
        BattleController.Instance.OnBattleEnd.AddListener(FinishStartBattleInteraction);
        BattleController.Instance.BeginBattle(encounterSet, battlegroundSprite);
    }

    private void FinishStartBattleInteraction()
    {
        finished = true;
        BattleController.Instance.OnBattleEnd.RemoveListener(FinishStartBattleInteraction);
    }
    
    public override IEnumerator Completion
    {
        get
        {
            yield return new WaitWhile(() => !finished);
            yield return null;
        }
    }
}
