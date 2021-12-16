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
    float endPosition = 6.7f;

    public float cartSpeed = 4f;
    public int cartSpeedLvl = 0;
    public float timeToLoad = 2f;
    public int timeToLoadLvl = 0;
    public float timeToUnload = 1f;
    public int timeToUnloadLvl = 0;
    float loadingDuration = 0f;
    int moveDirection = moveReady;
    public int cartCapacity = 5;
    public int cartCapacityLvl = 0;
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
        var resourcesSprites = SpriteStorage.GetComponent<Sprites>().getCartSprites(ResType);
        fullSprite = resourcesSprites[0];
        halfSprite = resourcesSprites[1];
        quaterSprite = resourcesSprites[2];
        Industry.Carts[CartNumber] = this;
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

    public void Upgrade_Mining_Speed()
    {
        timeToLoadLvl++;
        timeToLoad *= 0.8f;
    }

    public void Upgrade_Moving_Speed()
    {
        cartSpeedLvl++;
        cartSpeed *= 1.2f;
    }

    public void Upgrade_Size()
    {
        cartCapacityLvl++;
        cartCapacity += cartCapacityLvl * 8;
    }

    public void Upgrade_Unloading_Speed()
    {
        timeToUnloadLvl++;
        timeToUnload *= 0.8f;
    }

    public void Buy_Auto()
    {
        
    }
}