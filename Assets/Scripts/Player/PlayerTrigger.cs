using UnityEngine;

public class PlayerTrigger
{
    private PlayerManager playerManager;


    public PlayerTrigger(PlayerManager playerManager)
    {
        this.playerManager = playerManager;
    }

    public void TriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("paper"))
        {
            Debug.Log("paper trigger");

            playerManager.minCheckList.SetActive(true);
        }
        if (other.CompareTag("puzzleBooks"))
        {
            if (PlayerManager.valueBook != 0)
            {
                playerManager.cabinets.SetActive(true);
                playerManager.PlayerStop();
            }
        }
    }

}
