using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject[] pickups;
    public float pickupDeliveryTime = 5f; //�ӳ�
    public float dropRangeLeft;
    public float dropRangeRight;
    public float highHealthThreshold = 75f;//bomb
    public float lowHealthThreshold = 25f;//ҽ�ư�

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
        if (playerHealth.health >= highHealthThreshold)//ը��
            Instantiate(pickups[0], dropPos, Quaternion.identity);
        else if (playerHealth.health <= lowHealthThreshold)//ҽ�ư�
            Instantiate(pickups[1], dropPos, Quaternion.identity);
        else//���
        {
            int pickupIndex = Random.Range(0, pickups.Length);
            Instantiate(pickups[pickupIndex], dropPos, Quaternion.identity);
        }
    }
}
