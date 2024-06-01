using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andrew_Door : MonoBehaviour
{
    Animation andrewanimation;
    public bool open = false;
    private float nextDoor;
    private float doorRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        andrewanimation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!open && Input.GetKeyDown("f") && Time.time > nextDoor)
        {
            andrewanimation.Play("Andrew Door Open");
            open = true;
            nextDoor = Time.time + doorRate;
        }
        else if (open && Input.GetKeyDown("f") && Time.time > nextDoor)
        {
            andrewanimation.Play("Andrew Door Close");
            open = false;
            nextDoor = Time.time + doorRate;
        }
    }
}
