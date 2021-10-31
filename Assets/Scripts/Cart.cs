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

    public Sprite emptySprite;
    public Sprite fullSprite;
    public Sprite halfSprite;
    public Sprite quaterSprite;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = new Vector3(-3f, CartNumber * -4, 0);
        endPosition = new Vector3(5.7f, CartNumber * -4, 0);
        transform.position = startPosition;
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
            if (Vector3.Distance(transform.position, endPosition) < 0.001f)           
            {
                moveDirection = moveLoad;
            }
            else
                transform.position = Vector3.MoveTowards(transform.position, endPosition, cartSpeed * Time.deltaTime);
        }

        
        if (moveDirection == moveBackward)
        {
            if (Vector3.Distance(transform.position, startPosition) < 0.001f)
            {
                moveDirection = moveUnload;
                GetComponent<Animator>().enabled = false;
            }
            else
                transform.position = Vector3.MoveTowards(transform.position, startPosition, cartSpeed * Time.deltaTime);
        }

        if(moveDirection == moveUnload)
        {
            if(loadingDuration >= timeToUnload)
            {
                loadingDuration = 0;
                transform.Find("CartTop").gameObject.GetComponent<SpriteRenderer>().sprite = emptySprite;
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