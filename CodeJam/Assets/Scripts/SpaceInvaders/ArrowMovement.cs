using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float speed; // adjust this value to control the speed of movement
    private bool goLeft = false;
    private bool goRight = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            goLeft = true;
        }
        else
        {
            goLeft = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            goRight = true;
        }
        else
        {
            goRight = false;
        }

        // calculate the movement vector
        Vector3 movement = Vector3.zero;
        if (goLeft)
        {
            movement += Vector3.left * speed * Time.deltaTime;
        }

        if (goRight)
        {
            movement += Vector3.right * speed * Time.deltaTime;
        }

        // translate the character's position by the movement vector
        transform.Translate(movement);
    }
}
