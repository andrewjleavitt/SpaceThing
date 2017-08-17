using System;
using UnityEngine;

public class ShieldBehavior {

    public float amount = 0.0f;
    public float rechargeAmount = 0.0f;
    public float rechargeRate = 0.0f;

    private float capacity = 0.0f;
    private float nextRecharge = 0.0f;
    private string shieldName;

    public ShieldBehavior(string newShieldName, float newCapacity, float newRechargeAmount, float rechargeRate) {
        shieldName = newShieldName;
        capacity = newCapacity;
        rechargeAmount = newRechargeAmount;
        rechargeRate = newRechargeAmount;
        amount = capacity;
    }

    public void Recharge() {
        if (amount == capacity) {
            return;
        }

        if (Time.time < nextRecharge) {
            return;
        }

        amount += rechargeAmount;
        nextRecharge = Time.time + rechargeRate;
    }

    public string Status() {
        return amount.ToString();
    }
}
