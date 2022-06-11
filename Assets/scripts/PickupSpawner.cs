using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject[] pickups;
    public float pickupDeliveryTime = 5f; //延迟
    public float dropRangeLeft;
    public float dropRangeRight;
    public float highHealthThreshold = 75f;//bomb
    public float lowHealthThreshold = 25f;//医疗包

    private PlayerHealth playerHealth;
    void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void Start()
    {
        StartCoroutine(DeliverPickup());
    }

    // Update is called once per frame
    public IEnumerator DeliverPickup()
    {
        yield return new WaitForSeconds(pickupDeliveryTime);
        float dropPosX = Random.Range(dropRangeLeft, dropRangeRight);
        Vector3 dropPos = new Vector3(dropPosX, 15f, 1f);
        if (playerHealth.health >= highHealthThreshold)//炸弹
            Instantiate(pickups[0], dropPos, Quaternion.identity);
        else if (playerHealth.health <= lowHealthThreshold)//医疗包
            Instantiate(pickups[1], dropPos, Quaternion.identity);
        else//随机
        {
            int pickupIndex = Random.Range(0, pickups.Length);
            Instantiate(pickups[pickupIndex], dropPos, Quaternion.identity);
        }
    }
}
