using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryPanel : ItemPanel
{
    public override void Onclick(int id)
    {
        GameManager.instance.dragAndDropController.Onclick(inventory.slots[id]);
        Show();
    }

}
