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

    float startPosition;
    float endPosition = 5.7f;

    float cartSpeed = 4f;
    public float timeToLoad = 2f;
    const float timeToUnload = 1f;
    float loadingDuration = 0f;
    int moveDirection = moveReady;
    public int cartCapacity = 5;
    public int ResType;
    public GameObject SpriteStorage;

    public Sprite emptySprite;
    Sprite fullSprite;
    Sprite halfSprite;
    Sprite quaterSprite;
     
    void Start()
    {
        startPosition = transform.position.x;
        Time.timeScale = 1f;
        var resourcesSprites = SpriteStorage.GetComponent<Sprites>().getResourceSprites(ResType);
        fullSprite = resourcesSprites[0];
        halfSprite = resourcesSprites[1];
        quaterSprite = resourcesSprites[2];
    }

    private void OnMouseDown()
    {
        if (moveDirection == moveReady)
        {
            moveDirection = moveForward;
            GetComponent<Animator>().enabled = true;
        }
    }

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
            if (Mathf.Abs(transform.position.x - endPosition) < MoveDistance)
            {
                moveDirection = moveLoad;
            }
            else
                //transform.position = Vector3.MoveTowards(transform.position, endPosition, cartSpeed * Time.deltaTime);
                transform.Translate(new Vector3(MoveDistance, 0, 0));
        }

        
        if (moveDirection == moveBackward)
        {
            if (Mathf.Abs(transform.position.x - startPosition) < MoveDistance)
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