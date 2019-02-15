using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainScript : MonoBehaviour
{
    public float speed = 2f;
    public float timeout = 30f;
    public bool isClone = false;
    public bool waiting = false;

    private float timer = 0;

    private float timerMax = 0;

    void Start()
    { 
        if (isClone)
        {
            Object.Destroy(gameObject, 15f);
        }
        else
        {
            InvokeRepeating("spawn", 1f, 15f);
        }
    }

    void Update()
    {
        if(isClone)
        {
            if(transform.position.x >= 0)
            {
                if(waiting == false) { 
                    waiting = true;
                }
                else
                {
                    if (!Waited(5)) return;
                        waiting = false;
                }

            }
            if (!waiting)
            {
                transform.position += transform.right * Time.deltaTime * speed;
            }

        }

    }

    void spawn()
    {
        GameObject clone;
        clone = Instantiate<GameObject>(this.gameObject, transform.position, transform.rotation);
        clone.GetComponent<TrainScript>().isClone = true;
    }




    private bool Waited(float seconds)
    {
        timerMax = seconds;

        timer += Time.deltaTime;

        if (timer >= timerMax)
        {
            return true;
        }

        return false;
    }
}
