using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public GameObject obstacle;
    private bool closed;
    public bool locked;
    // Start is called before the first frame update
    void Start()
    {
        closed = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        if (closed && !locked)
        {
            closed = false;
            obstacle.SetActive(false);
            //play open animation
        }
        else 
        {
            Close();
        }
    }

    private void Close()
    {
        closed = true;
        obstacle.SetActive(true);
        //play closed animation
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            //show interact prompt
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            //hide interact prompt
            if (!closed)
                Close();
        }
    }
}
