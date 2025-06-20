using UnityEngine;

/// <summary>
/// AmmoBox - Item bo sung dan cho Player.
/// </summary>
public class AmmoBox : ItemPickup
{
    [Header("Ammo Settings")]
    public int  ammoAmount = 30;
    public bool refillAll  = false;

    protected override void OnPickup(GameObject player)
    {
        var gun = player.GetComponentInChildren<GunController>();
        if (gun == null) return;

        if (refillAll)
            gun.RefillAllAmmo();
        else
            gun.AddAmmo(ammoAmount);

        Debug.Log($"[AmmoBox] +{(refillAll ? "MAX" : ammoAmount.ToString())} dan!");
    }
}