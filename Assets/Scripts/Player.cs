using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{
    public Transform newPos; // Reference to the Miami game space
    private Transform targetPosition;

    private bool isMoving = false;
    private bool isOnPos = false;
    private bool canMove = true;

    float moveSpeed = 5.0f;
    
    TextMeshProUGUI textField;
    
    // Array of players
    public Player[] players;
    private int currentPlayer;

    private void Start()
    {
        // player go to miami
        targetPosition = newPos;
        textField = GameObject.Find("FeedBack").GetComponent<TextMeshProUGUI>();
        textField.text = "Press space to move";
    }

    private void Update()
    {
        // Check if play is on a certain position
        isOnPos = transform.position == newPos.position;

        // Treat the disease
        if (Input.GetKeyDown(KeyCode.T) && isOnPos && !isMoving)
        {
            newPos.GetComponent<GameSpace>().TreatDisease();
        }

        // if player is able to move and presses space
        if (canMove && Input.GetKeyDown(KeyCode.Space))
        {
            textField.text = "Press T to remove diseases";
            canMove = false; // cannot move again while moving
            goToNextPlayer();
        }

        if (isMoving)
        {
            float move = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, move);

            // See of player has reached the gamespot
            if (transform.position == targetPosition.position)
            {
                isMoving = false; // stop moving
                canMove = true; // other player can move again
            }
        }
    }

    private void goToNextPlayer()
    {
        // looks at array of players
        if (currentPlayer >= 0 && currentPlayer < players.Length)
        {
            // stop movement of first player
            players[currentPlayer].SetPlayerControl(false);

            // make current player player 2
            currentPlayer = (currentPlayer + 1) % players.Length;

            // allow player 2 to move
            players[currentPlayer].SetPlayerControl(true);
        }
    }

    public void SetPlayerControl(bool isEnabled)
    {
        // allow disabling or enabling of player movement
        isMoving = isEnabled;
    }
}
