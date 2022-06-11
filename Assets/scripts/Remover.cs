using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Remover : MonoBehaviour
{
    public GameObject splash;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            if(GameObject.FindGameObjectWithTag("HealthBar").activeSelf)
            {
                GameObject.FindGameObjectWithTag("HealthBar").SetActive(false);//物体在场景中不可见
            }
            Instantiate(splash, collision.transform.position, transform.rotation);//生成水花
            Destroy(collision.gameObject);//销毁主角
            StartCoroutine("ReloadGame");//启动协程
        }
        else//碰到敌人的情况
        {
            Instantiate(splash, collision.transform.position, transform.rotation);
            Destroy(collision.gameObject);
        }
    }
    IEnumerator ReloadGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
