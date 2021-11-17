using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    public int CartNumber;

    const int moveReady = 0;
    const int moveUnload = 1;
    const int moveForward = 2;
    const int moveBackward = 3;
    const int moveLoad = 4;

    Vector3 startPosition;
    Vector3 endPosition;

    float cartSpeed = 4f;
    public float timeToLoad = 2f;
    const float timeToUnload = 1f;
    float loadingDuration = 0f;
    int moveDirection = moveReady;
    public int cartCapacity = 5;
    public int ResType;
    private float StartX = -2.8f;
    private float EndX = 5.7f;
    private float DistanceBetweenCarts = 4.6f;

    public Sprite emptySprite;
    public Sprite fullSprite;
    public Sprite halfSprite;
    public Sprite quaterSprite;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(StartX, 0, 0);
        transform.Translate(new Vector3(0, CartNumber * -DistanceBetweenCarts, 0), Space.Self);
        //startPosition = new Vector3(StartX, CartNumber * -DistanceBetweenCarts, 0);
        startPosition = transform.position;
        endPosition = new Vector3(EndX, startPosition.y, 0);
        //transform.position = startPosition;
        Time.timeScale = 1f;
    }

    private void OnMouseDown()
    {
        if (moveDirection == moveReady)
        {
            moveDirection = moveForward;
            GetComponent<Animator>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float MoveDistance = cartSpeed * Time.deltaTime;
        if (moveDirection == moveLoad)
        {
            if (loadingDuration >= timeToLoad)
            {
                loadingDuration = 0;
                transform.Find("CartTop").gameObject.GetComponent<SpriteRenderer>().sprite = fullSprite;
                moveDirection = moveBackward;
            }
            else
            {
                loadingDuration += Time.deltaTime;
            }
        }

        if (moveDirection == moveForward)
        {
            if (Mathf.Abs(transform.position.x - endPosition.x) < MoveDistance)
            {
                moveDirection = moveLoad;
            }
            else
                //transform.position = Vector3.MoveTowards(transform.position, endPosition, cartSpeed * Time.deltaTime);
                transform.Translate(new Vector3(MoveDistance, 0, 0));
        }

        
        if (moveDirection == moveBackward)
        {
            if (Mathf.Abs(transform.position.x - startPosition.x) < MoveDistance)
            {
                moveDirection = moveUnload;
                GetComponent<Animator>().enabled = false;
            }
            else
                transform.Translate(new Vector3(-MoveDistance, 0, 0));
        }

        if(moveDirection == moveUnload)
        {
            if(loadingDuration >= timeToUnload)
            {
                loadingDuration = 0;
                transform.Find("CartTop").gameObject.GetComponent<SpriteRenderer>().sprite = emptySprite;
		        Stash.ResourceCount[ResType] += cartCapacity;
                moveDirection = moveReady;

            }
            else
            {
                loadingDuration += Time.deltaTime;
                if (loadingDuration >= timeToUnload * 0.75f)
                {
                    transform.Find("CartTop").gameObject.GetComponent<SpriteRenderer>().sprite = quaterSprite;
                }
                else
                {
                    if (loadingDuration >= timeToUnload * 0.5f)
                    {
                        transform.Find("CartTop").gameObject.GetComponent<SpriteRenderer>().sprite = halfSprite;
                    }
                }
                
            }
        }

    }
}