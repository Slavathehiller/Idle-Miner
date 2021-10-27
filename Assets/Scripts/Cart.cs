using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    public int CartNumber;

    Vector3 startPosition;
    Vector3 endPosition;

    float cartSpeed = 4f;
    bool moveForward = true;

    public Sprite emptySprite;
    public Sprite fullSprite;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = new Vector3(-4.7f, CartNumber * -4, 0);
        endPosition = new Vector3(5.7f, CartNumber * -4, 0);
        transform.position = startPosition;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, startPosition) < 0.001f)
        {
            moveForward = true;
            transform.Find("CartTop").gameObject.GetComponent<SpriteRenderer>().sprite = emptySprite;
        }
        if (Vector3.Distance(transform.position, endPosition) < 0.001f)
        {
            transform.Find("CartTop").gameObject.GetComponent<SpriteRenderer>().sprite = fullSprite;
            moveForward = false;
        }
        if (moveForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, cartSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, cartSpeed * Time.deltaTime);

        }
    }
}