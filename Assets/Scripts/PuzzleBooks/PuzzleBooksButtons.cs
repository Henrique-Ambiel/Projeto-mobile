using UnityEngine;

public class PuzzleBooksButtons : MonoBehaviour
{
    public string answer = "";
    public string correct = "";
    public Sprite btOn;
    public GameObject[] bts;
    public GameObject[] books;
    public int i = -1;
    public GameObject backgroundCabinets;
    public Animator animDoor;
    public GameObject colDoor;
    public bool[] booksCorrects;

    private void Start()
    {
        i = -1;
    }
    public void BtC()
    {
        answer = "C";

        if (answer == correct)
        {
            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;
            backgroundCabinets.SetActive(false);
            ItemPickUp.CanAnswerPuzzle = false;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }

        }
        else
        {
            ItemPickUp.CanAnswerPuzzle = false;
            backgroundCabinets.SetActive(false);
            switch (correct)
            {
                case "C_Libras":
                    books[0].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "Y":
                    books[1].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "G":
                    books[2].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "F_Libras":
                    books[3].gameObject.SetActive(true);
                    correct = "";
                    break;
            }
        }

    }
    public void BtC_libras()
    {
        answer = "C_Libras";

        if (answer == correct)
        {
            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;
            backgroundCabinets.SetActive(false);
            ItemPickUp.CanAnswerPuzzle = false;

            booksCorrects[0] = true;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }
        }
        else
        {
            ItemPickUp.CanAnswerPuzzle = false;
            backgroundCabinets.SetActive(false);

            switch (correct)
            {
                case "C_Libras":
                    books[0].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "Y":
                    books[1].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "G":
                    books[2].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "F_Libras":
                    books[3].gameObject.SetActive(true);
                    correct = "";
                    break;
            }
        }
    }
    public void BtF_libras()
    {
        answer = "F_Libras";
        if (answer == correct)
        {
            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;
            backgroundCabinets.SetActive(false);
            ItemPickUp.CanAnswerPuzzle = false;

            booksCorrects[3] = true;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }
        }
        else
        {
            ItemPickUp.CanAnswerPuzzle = false;
            backgroundCabinets.SetActive(false);
            switch (correct)
            {
                case "C_Libras":
                    books[0].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "Y":
                    books[1].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "G":
                    books[2].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "F_Libras":
                    books[3].gameObject.SetActive(true);
                    correct = "";
                    break;
            }
        }
    }
    public void BtG()
    {
        answer = "G";
        backgroundCabinets.SetActive(false);
        if (answer == correct)
        {
            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;
            backgroundCabinets.SetActive(false);
            ItemPickUp.CanAnswerPuzzle = false;

            booksCorrects[2] = true;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }
        }
        else
        {
            ItemPickUp.CanAnswerPuzzle = false;
            backgroundCabinets.SetActive(false);
            switch (correct)
            {
                case "C_Libras":
                    books[0].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "Y":
                    books[1].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "G":
                    books[2].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "F_Libras":
                    books[3].gameObject.SetActive(true);
                    correct = "";
                    break;
            }
        }
    }
    public void BtG_libras()
    {
        answer = "G_Libras";
        backgroundCabinets.SetActive(false);
        if (answer == correct)
        {
            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;
            backgroundCabinets.SetActive(false);
            ItemPickUp.CanAnswerPuzzle = false;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }
        }
        else
        {
            ItemPickUp.CanAnswerPuzzle = false;
            backgroundCabinets.SetActive(false);
            switch (correct)
            {
                case "C_Libras":
                    books[0].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "Y":
                    books[1].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "G":
                    books[2].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "F_Libras":
                    books[3].gameObject.SetActive(true);
                    correct = "";
                    break;
            }
        }
    }
    public void BtT_libras()
    {
        answer = "T_Libras";
        backgroundCabinets.SetActive(false);
        if (answer == correct)
        {
            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;
            backgroundCabinets.SetActive(false);
            ItemPickUp.CanAnswerPuzzle = false;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }
        }
        else
        {
            ItemPickUp.CanAnswerPuzzle = false;
            backgroundCabinets.SetActive(false);
            switch (correct)
            {
                case "C_Libras":
                    books[0].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "Y":
                    books[1].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "G":
                    books[2].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "F_Libras":
                    books[3].gameObject.SetActive(true);
                    correct = "";
                    break;
            }
        }
    }
    public void BtV()
    {
        answer = "V";
        backgroundCabinets.SetActive(false);
        if (answer == correct)
        {
            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;
            backgroundCabinets.SetActive(false);
            ItemPickUp.CanAnswerPuzzle = false;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }
        }
        else
        {
            ItemPickUp.CanAnswerPuzzle = false;
            backgroundCabinets.SetActive(false);
            switch (correct)
            {
                case "C_Libras":
                    books[0].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "Y":
                    books[1].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "G":
                    books[2].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "F_Libras":
                    books[3].gameObject.SetActive(true);
                    correct = "";
                    break;
            }
        }
    }
    public void BtY()
    {
        answer = "Y";
        backgroundCabinets.SetActive(false);
        if (answer == correct)
        {
            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;
            backgroundCabinets.SetActive(false);
            ItemPickUp.CanAnswerPuzzle = false;

            booksCorrects[1] = true;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }
        }
        else
        {
            ItemPickUp.CanAnswerPuzzle = false;
            backgroundCabinets.SetActive(false);
            switch (correct)
            {
                case "C_Libras":
                    books[0].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "Y":
                    books[1].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "G":
                    books[2].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "F_Libras":
                    books[3].gameObject.SetActive(true);
                    correct = "";
                    break;
            }
        }
    }


}
