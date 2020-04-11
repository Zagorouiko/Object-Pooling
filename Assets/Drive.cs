using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject bullet;
    public Slider healthbar;
    

    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);

        if (Input.GetKeyDown("space"))
        {
            //Instantiate(bullet, transform.position, Quaternion.identity);
            GameObject bullet = Pool.singleton.Get("bullet");
            if (bullet != null)
            {
                bullet.transform.position = transform.position;
                bullet.SetActive(true);
            }
        }

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position) + new Vector3(0, -130, 0);
        healthbar.transform.position = screenPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {
            healthbar.value -= 50f;
            collision.gameObject.SetActive(false);

            if (healthbar.value <= 0)
            {
                Destroy(healthbar.gameObject, 0.1f);
                Destroy(gameObject, 0.1f);               
            }
        }
    }
}