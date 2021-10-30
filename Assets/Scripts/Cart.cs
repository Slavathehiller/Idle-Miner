using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    public int CartNumber;

    const int moveStop = 0;
    const int moveForward = 1;
    const int moveBackward = 2;

    Vector3 startPosition;
    Vector3 endPosition;

    float cartSpeed = 4f;
    int moveDirection = moveStop;

    public Sprite emptySprite;
    public Sprite fullSprite;

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
        if (moveDirection == moveStop)
        {
            moveDirection = moveForward;
            GetComponent<Animator>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moveDirection == moveForward)
        {
            if (Vector3.Distance(transform.position, endPosition) < 0.001f)           
            {
                transform.Find("CartTop").gameObject.GetComponent<SpriteRenderer>().sprite = fullSprite;
                moveDirection = moveBackward;
            }
            else
                transform.position = Vector3.MoveTowards(transform.position, endPosition, cartSpeed * Time.deltaTime);
        }


        if (moveDirection == moveBackward)
        {
            if (Vector3.Distance(transform.position, startPosition) < 0.001f)
            {
                transform.Find("CartTop").gameObject.GetComponent<SpriteRenderer>().sprite = emptySprite;
                moveDirection = moveStop;
                GetComponent<Animator>().enabled = false;
            }
            else
                transform.position = Vector3.MoveTowards(transform.position, startPosition, cartSpeed * Time.deltaTime);
        }

    }
}