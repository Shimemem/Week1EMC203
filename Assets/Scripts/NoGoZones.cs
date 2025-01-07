using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoGoZones : MonoBehaviour
{
    [SerializeField] private float DangerRadius = 4f;
    [SerializeField] private float DeathRadius = 1f;
    [SerializeField] private float ShakeSize;
    private Renderer ZoneColor;
    private Vector2 origPos;

    // Start is called before the first frame update
    void Start()
    {
        ZoneColor = GetComponent<Renderer>();
        origPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance <= DangerRadius)
            {
                Shake();
                ZoneColor.material.color = Color.red;
                Debug.Log("InDanger");
            }

            else
            {
                ZoneColor.material.color = Color.white;
            }

            if (distance <= DeathRadius)
            {
                Death();
            }
        }
        
    }

    public void Shake()
    {
        transform.position = new Vector2(origPos.x + Random.Range(-ShakeSize, ShakeSize), origPos.y + Random.Range(-ShakeSize, ShakeSize));
    }

    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
