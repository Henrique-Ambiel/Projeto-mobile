using System.Collections;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public string ID;
    [SerializeField] private bool isOpen = false;
    [SerializeField] private ManagerDoor managerDoor;
    [SerializeField] GameObject objDoor;
    [SerializeField] GameObject txtDoor;

    IEnumerator Start()
    {
        while (FindAnyObjectByType<ManagerDoor>() == null)
        {
            yield return null; // espera um frame
        }

        managerDoor = FindAnyObjectByType<ManagerDoor>();
        Debug.Log("ManagerDoor encontrado: " + managerDoor.name);
    }

    private void Update()
    {
        if (isOpen)
        {
            ObjDestroy();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isOpen && managerDoor.keyCode == ID)
            {
                isOpen = true;

                if (managerDoor.keyCode == "m")
                {
                    managerDoor.keyCode = "";
                    IAGameManager.SetNivel(1);
                }
                else if (managerDoor.keyCode == "s")
                {
                    managerDoor.keyCode = "";
                    IAGameManager.ZeroSpecial();
                }
                else if (managerDoor.keyCode == "a")
                {
                    managerDoor.keyCode = "";
                    IAGameManager.SetNivel(3);
                }

            }
            else
            {
                Debug.Log("Door is already open.");
            }
        }
    }

    public void ObjDestroy()
    {
        Destroy(objDoor);
        Destroy(txtDoor);
    }

}
