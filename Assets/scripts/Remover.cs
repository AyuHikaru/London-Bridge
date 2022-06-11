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
                GameObject.FindGameObjectWithTag("HealthBar").SetActive(false);//�����ڳ����в��ɼ�
            }
            Instantiate(splash, collision.transform.position, transform.rotation);//����ˮ��
            Destroy(collision.gameObject);//��������
            StartCoroutine("ReloadGame");//����Э��
        }
        else//�������˵����
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
