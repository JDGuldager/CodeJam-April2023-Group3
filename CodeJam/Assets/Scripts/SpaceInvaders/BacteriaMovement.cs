using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaMovement : MonoBehaviour
{
    [SerializeField]
    float BacteriaSpeed;
    [SerializeField]
    public float BacteriaMovementRange;
    public float BacteriaSmoothMovement;
    private float BacteriaVelocity;
    [SerializeField]
    private float BacteriaYSpeed;

    // Update is called once per frame
    void Update()
    {
        //makes each enemy moves randomly side to side
        float RandomXMovement = Random.Range(-BacteriaMovementRange, BacteriaMovementRange);

        //makes sure enemy moves down the screen, so game can be lost
        Vector3 targetPosition = transform.position + new Vector3(RandomXMovement, -BacteriaSpeed * Time.deltaTime, 0);

        float makeXSmooth = Mathf.SmoothDamp(transform.position.x, targetPosition.x, ref BacteriaVelocity, BacteriaSmoothMovement);

        transform.position = new Vector3(makeXSmooth, transform.position.y, transform.position.z);

        //Makes sure the bacteria does not leave the border
        float clampedXPos = Mathf.Clamp(transform.position.x, -2f, 2f);
        transform.position = new Vector3(clampedXPos, transform.position.y, transform.position.z);

        transform.position -= new Vector3(0, BacteriaYSpeed * Time.deltaTime, 0);
    }
}
