using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    Rigidbody2D rb;

    public GameObject canvas;
    [SerializeField]private GameObject winZone;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float speedX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float speedY = Input.GetAxisRaw("Vertical") * moveSpeed;
        rb.velocity = new Vector2(speedX, speedY);

        float winDistance = Vector2.Distance(transform.position, winZone.transform.position);
        float winRadius = 2f;
        if (winDistance <= winRadius)
        {
            canvas.SetActive(true);
        }
    }
}
