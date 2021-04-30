using System;
using Skripty.Itemy;
using Unity.UNetWeaver;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public void OnSubmit() {
        if (InventarSkript.MojeInstance._inventar.inventar[Convert.ToInt32(transform.name)] == null) return;
        if (InventarSkript.MojeInstance._inventar.inventar[Convert.ToInt32(transform.name)].item == null) return;
        
        var pozice = Hrac.MojeInstance.gameObject.transform.position;
        pozice.y -= 2;
        
        UIManager.MojeInstance.ShowToolTip(false, Vector3.zero,null);

        ItemSpawner.MojeInstance.SpawniItem(pozice, InventarSkript.MojeInstance._inventar.inventar[Convert.ToInt32(transform.name)].item.Id);
        InventarSkript.MojeInstance._inventar.removeItem(Convert.ToInt32(transform.name));
        
        Hrac.MojeInstance.UpdatujStaty();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (InventarSkript.MojeInstance._inventar.inventar[Convert.ToInt32(transform.name)] == null) return;
        if (InventarSkript.MojeInstance._inventar.inventar[Convert.ToInt32(transform.name)].item == null) return;
        
        var transform1 = transform;
        UIManager.MojeInstance.ShowToolTip(true,transform1.position,InventarSkript.MojeInstance._inventar.inventar[Convert.ToInt32(transform1.name)].item.Popis);
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (InventarSkript.MojeInstance._inventar.inventar[Convert.ToInt32(transform.name)] == null) return;
        if (InventarSkript.MojeInstance._inventar.inventar[Convert.ToInt32(transform.name)].item == null) return;
        
        UIManager.MojeInstance.ShowToolTip(false, Vector3.zero,null);
    }
}
