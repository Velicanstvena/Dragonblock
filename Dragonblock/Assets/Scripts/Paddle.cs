using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // configuration parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    // cached references
    GameSession gameSession;
    Ball ball;


    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        //float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits; // vraca poziciju misa na x osi izrazenu u unity units

        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y); // prilikom svakog update-a, x i y ostaju gde su
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX); // menja se pozicija misa na x-osi tako da bude u okviru granica
        transform.position = paddlePos; // pomeramo paddle
    }

    private float GetXPos()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else 
        { 
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    
    }
}
