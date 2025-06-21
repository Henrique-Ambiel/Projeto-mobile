using UnityEngine;

public class IAGameManager : MonoBehaviour
{
    public static int IA_Lvl = 0;
    public static int distanceChaseIA = 2; // Distância de patrulha, pode ser ajustada conforme necessário
    public static int distanceIA = 2; // Distância de detecção do jogador
    public static float moveSpeedIA = 3f;
    public ManagerDoor managerDoor;
    private static bool b_special = false;

    private void Start()
    {
        b_special = false;
        SetNivel(0);
    }
    private void Update()
    {
        if (IA_Lvl == 0 && !b_special)
        {
            distanceChaseIA = 5;
            distanceIA = 5;
            moveSpeedIA = 2f;
        }
        if(IA_Lvl == 1)
        {
            distanceChaseIA = 4;
            distanceIA = 4;
            moveSpeedIA = 3f;
        }
        if (IA_Lvl == 2)
        {
            distanceChaseIA = 6;
            distanceIA = 6;
            moveSpeedIA = 3f;
        }
        if (IA_Lvl == 3)
        {
            distanceChaseIA = 5;
            distanceIA = 5;
            moveSpeedIA = 6f;
        }
    }
    public static void AumentarNivel()
    {
        IA_Lvl++;
        Debug.Log("IA_Lvl aumentado para: " + IA_Lvl);
    }

    public static void SetNivel(int novoNivel)
    {
        IA_Lvl = novoNivel;
        Debug.Log("IA_Lvl definido para: " + IA_Lvl);
    }

    public static void ZeroSpecial()
    {
        b_special = true;
        moveSpeedIA = 4f;
        distanceIA = 10;
        distanceChaseIA = 10;
        SetNivel(0);
    }
}
