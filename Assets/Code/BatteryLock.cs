using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryLock : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Battery usageBattery;
    [SerializeField] private AudioClip batteryON;


    private void Start()
    {
        player = transform.parent.GetComponent<Player>();
    }

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

        WorldManager.Instance.WorldAudioSource.PlayOneShot(batteryON);
        player.PlayerBattery = battery;
        battery.gameObject.layer = 13;
        battery.Transf.SetParent(transform);
        battery.Transf.eulerAngles = Vector3.zero;

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
