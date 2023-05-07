using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    public List<GameObject> patients;
    public GameObject firstPatient;
    public float swipeMinimum = 50f;
    public Rigidbody2D rb;

    public int currentPatientIndex = 0;
    private Vector2 startPosition;  //Start position of mouse
    private Vector2 endPosition;    //End position of mouse

    Vector2 patientPosition;
    public GameObject leftSide, rightSide;
    public float speed = 10f;
    public TextMeshProUGUI countingDown;    //Text for time
    public Slider countdownBar; //Slider of countdown bar
    public float maxDuration = 10f;

    public AudioClip happyRed;
    public AudioClip dissapointedRed;

    // Start is called before the first frame update
    void Start()
    {
        Timer.timerTillNextScene = maxDuration; //Time is set to 10
        countdownBar.maxValue = Timer.timerTillNextScene; //Make sure maxvalue is 10

        // Set the first patient as the current patient
        firstPatient = patients[currentPatientIndex];
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SwipeMechanism();
        if(Timer.timerTillNextScene <= 0f)
		{
            SoundManager.instance.PlaySound(dissapointedRed);
            Timer.GameOver();
		}

        countdownBar.value = Timer.timerTillNextScene; //Changes value to duration
        countingDown.text = Mathf.Round(Timer.timerTillNextScene).ToString();   //From Time to text        
    }

    IEnumerator MovePatient(Vector3 start, Vector3 target)
    {
        float distance = Vector3.Distance(start, target);   //Distance from patient to off screen
        float duration = distance / speed;  //How long it takes to cover the distance
        float startTime = Time.time;    //The time in the start of the frame

        while (Time.time < startTime + duration)
        {
            float interpolationRatio = (Time.time - startTime) / duration;  //Current time divided by total time
            firstPatient.transform.position = Vector3.Lerp(start, target, interpolationRatio); // Cooler version of MoveTowards  

            yield return null;
        }

        //Travel destination reached
        CheckoutPatient(target.normalized.x);

        currentPatientIndex++;

        //
        if (currentPatientIndex <= patients.Count - 1)
        {
            firstPatient = patients[currentPatientIndex];
        }
    }

    public void CheckoutPatient(float endLocation)
    {
        switch (firstPatient.GetComponent<assignCategories>().objectCategory)
        {
            case assignCategories.Category.Injured:
                if (endLocation < 0)
                {
                    SoundManager.instance.PlaySound(happyRed);
                    Debug.Log("Correct, I'm Injured");
                    if (currentPatientIndex >= patients.Count-1) 
                    {
                        Timer.NextScene();
                    }

                }
                else if (endLocation > 0)
                {
                    SoundManager.instance.PlaySound(dissapointedRed);
                    Debug.Log("Incorrect, I'm Injured");
                    Timer.GameOver();
                }
                break;
            case assignCategories.Category.Recovered:
                if (endLocation < 0)
                {
                    SoundManager.instance.PlaySound(dissapointedRed);
                    Debug.Log("Incorrect, I'm Recovered");
                    Timer.GameOver();

                }
                else if (endLocation > 0)
                {
                    SoundManager.instance.PlaySound(happyRed);
                    Debug.Log("Correct, I'm Recovered");
                    if (currentPatientIndex >= patients.Count - 1)
                    {
                        Timer.NextScene();
                    }
                }
                

                break;
        }
    }

    void SwipeMechanism()
    {
            // Check if the current patient is the first patient in the list
            if (patients[currentPatientIndex] == firstPatient)
            {
                // By the click of the mouse, get mouseposition
                if (Input.GetMouseButtonDown(0))
                {
                    startPosition = Input.mousePosition;
                }

                //Letting go of the mouse will get another position
                if (Input.GetMouseButtonUp(0))
                {
                    endPosition = Input.mousePosition;

                    //Returns the length of the vector between mousedown and mouseup position
                    float swipeDistance = (endPosition - startPosition).magnitude;

                    //Minimum swipe distance reached?
                    if (swipeDistance > swipeMinimum)
                    {
                        // Gets the swipe direction in a simple digit.
                        Vector2 swipeDirection = (endPosition - startPosition).normalized;

                        // Moves patient to the left if direction is left
                        if (swipeDirection.x < 0)
                        {
                            if (Vector2.Distance(patientPosition, leftSide.GetComponent<Transform>().position) > 0)
                            {
                                StartCoroutine(MovePatient(patientPosition, leftSide.transform.position));
                            }
                        }

                        // Moves patient to the right if direction is right
                        if (swipeDirection.x > 0)
                        {
                            if (Vector2.Distance(patientPosition, rightSide.GetComponent<Transform>().position) > 0)
                            {
                                StartCoroutine(MovePatient(patientPosition, rightSide.GetComponent<Transform>().position));
                            }
                        }
                    }
                }
            }
        }
    

    void OnCollisionEnter2D(Collision2D col)
    {
            if (col.gameObject.name == "Venstre")
            {
                StartCoroutine(MovePatient(patientPosition, leftSide.transform.position));
                rb.transform.position = new Vector3(0, rb.transform.position.y, rb.transform.position.z);
            }
            else if (col.gameObject.name == "Højre")
            {
                StartCoroutine(MovePatient(patientPosition, rightSide.GetComponent<Transform>().position));
                rb.transform.position = new Vector3(0, rb.transform.position.y, rb.transform.position.z);
            }
        } 
    }
