using Unity.VisualScripting;
using UnityEngine;

public class PlayerTrigger
{
    private PlayerManager playerManager;
    public int paper;

    public PlayerTrigger(PlayerManager playerManager)
    {
        this.playerManager = playerManager;
    }

    public void TriggerEnter2D(Collider2D other)
    {

        
        if (other.CompareTag("puzzleBooks"))
        {
            
            if (PlayerManager.valueBook != 0)
            {
                if (ItemPickUp.CanAnswerPuzzle == true)
                {
                    playerManager.ShowCabinets();
                }
            }
        }
        if (other.CompareTag("tapete"))
        {
            playerManager.minMax = true;
        }
    }

}
