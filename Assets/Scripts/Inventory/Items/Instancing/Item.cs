﻿using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public abstract ItemSave Serialize();

    [ShowInInspector] public ItemBase Base { get; private set; }

    public Item(ItemBase itemBase)
    {
        Base = itemBase;
    }

    public Item(ItemSave itemSave)
    {
        Base = ItemDatabase.Instance.Items.Find(x => x.uniqueIdentifier == itemSave.baseUid);
    }

    public virtual string InspectorName => Base.itemName;
    public virtual string InspectorDescription => Base.itemText;
}

//Ver como vai ser a serialização dos itens levando em conta os tipos diferentes