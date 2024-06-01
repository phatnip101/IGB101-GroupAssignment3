
using UnityEngine;

public class MaeDoor : MonoBehaviour
{
    Animation maeanimation;
    public bool open = false;
    private float nextDoor;
    private float doorRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        maeanimation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!open && Input.GetKeyDown("f") && Time.time > nextDoor)
        {
            maeanimation.Play("Mae Door Open");
            open = true;
            nextDoor = Time.time + doorRate;
        }
        else if (open && Input.GetKeyDown("f") && Time.time > nextDoor)
        {
            maeanimation.Play("Mae Door Close");
            open = false;
            nextDoor = Time.time + doorRate;
        }
    }
}
