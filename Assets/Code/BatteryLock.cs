using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryLock : MonoBehaviour
{
    private Player player;
    private Battery usageBattery;


    private void Update()
    {
        if (usageBattery != null)
            usageBattery.Transf.localPosition = Vector3.zero;
    }

    public void LoadBattery(Battery battery)
    {
        DisableBattery(battery);

        if (usageBattery != null)
        {
            usageBattery.Transf.localPosition = Vector3.right;
            AnableBattery(usageBattery);
            usageBattery.GetComponent<Rigidbody2D>().AddForce(transform.right * 10f);
        }

        usageBattery = battery;
    }

    void DisableBattery(Battery battery)
    {
        battery.gameObject.layer = 0;
        battery.Transf.SetParent(transform);
        battery.GetComponent<Rigidbody2D>().gravityScale = 0;
        battery.GetComponent<Collider2D>().isTrigger = true;

    }

    void AnableBattery(Battery battery)
    {
        battery.gameObject.layer = 8;
        battery.Transf.SetParent(null);
        battery.GetComponent<Rigidbody2D>().gravityScale = 1;
        battery.GetComponent<Collider2D>().isTrigger = false;
    }
}
