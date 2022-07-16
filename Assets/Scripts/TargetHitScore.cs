using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHitScore : MonoBehaviour
{
    public int targetScore = 1;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        // Get the GameController script
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

 // Add score on collision
    private void OnTriggerEnter(Collider other)
    {
        gameController.AddScore(targetScore);
    }
}
