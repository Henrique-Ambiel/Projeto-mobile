using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenCharacter : MonoBehaviour
{
    [Header("Verifications")]
    public bool isName;          // Verifica se o personagem é o menino
    public bool isSelection;

    [Header("Shake options")]
    public float intensity = 0.1f;       // Intensidade do tremor
    public float speed = 1f;             // Velocidade do tremor
    public GameObject[] characters;      // 0 = boy, 1 = girl
    private Vector3[] originalPositions;
    private bool[] isTrembling;
    private float[] noiseOffsets;

    public static TMP_InputField inputField;      // Referência ao InputField
    public static string namePlayer; // Nome do jogador
    public bool isTextLongEnough = false; // Bool que indica se o texto tem mais que 3 letras

    public Color selectedColor; // Cor do texto quando selecionado
    private Color originalColor; // Cor original do texto

    void Start()
    {
        inputField = GameObject.FindAnyObjectByType<TMP_InputField>();
        inputField.onValueChanged.AddListener(CheckTextLength);
        originalColor = characters[0].GetComponent<Image>().color; // Armazena a cor original do texto


        int count = characters.Length;
        originalPositions = new Vector3[count];
        isTrembling = new bool[count];
        noiseOffsets = new float[count];

        for (int i = 0; i < count; i++)
        {
            originalPositions[i] = characters[i].transform.localPosition;
            isTrembling[i] = false;
            noiseOffsets[i] = Random.Range(0f, 100f); // Garante variação de início diferente por personagem
        }
    }

    void Update()
    {
        float time = Time.time;

        for (int i = 0; i < characters.Length; i++)
        {
            if (isTrembling[i])
            {
                float x = Mathf.PerlinNoise(time * speed + noiseOffsets[i], 0f) - 0.5f;
                float y = Mathf.PerlinNoise(0f, time * speed + noiseOffsets[i]) - 0.5f;

                Vector3 offset = new Vector3(x, y, 0f) * intensity;
                characters[i].transform.localPosition = originalPositions[i] + offset;
            }
            else
            {
                characters[i].transform.localPosition = originalPositions[i];
            }
        }

        if(isTrembling[0]) characters[0].GetComponent<Image>().color = selectedColor;
        else characters[0].GetComponent<Image>().color = originalColor;
        if (isTrembling[1]) characters[1].GetComponent<Image>().color = selectedColor;
        else characters[1].GetComponent<Image>().color = originalColor;
    }

    public void Boy()
    {
        isSelection = true; // Ativa a seleção
        PlayerSpawn.PlayerSkin = "Boy";

        isTrembling[0] = true;
        isTrembling[1] = false;
        Debug.Log("Boy trembling");
    }

    public void Girl()
    {
        isSelection = true; // Ativa a seleção
        PlayerSpawn.PlayerSkin = "Girl";

        isTrembling[0] = false;
        isTrembling[1] = true;
        Debug.Log("Girl trembling");
    }

    public void StartGame()
    {
        if (isName && isSelection)
        {
            namePlayer = inputField.text; 
            SceneManager.LoadScene("GameplayScene");
        }
        else
        {
            Debug.Log("Select name and character");
            return;
        }
    }
    public void StopTremble()
    {
        isTrembling[0] = false;
        isTrembling[1] = false;
    }

    void CheckTextLength(string text)
    {
        // Verifica se o texto tem mais de 2 letras
        if (text.Length > 2)
        {
            isTextLongEnough = true;
            isName = true;
        }
        else
        {
            isTextLongEnough = false;
            isName = false;
        }

        // Log para mostrar o status
        Debug.Log("Texto maior que 2 letras: " + isTextLongEnough);
    }
}
