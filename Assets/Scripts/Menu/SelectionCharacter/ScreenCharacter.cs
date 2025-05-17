using System.Collections;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class ScreenCharacter : MonoBehaviour
{
    [Header("Verifications")]
    public bool isSelection = false; // Controle de seleção de personagem
    public bool isName = false; // Controle de nome do personagem

    [Header("Shake System")]
    public float intensity = 0.1f;       // Intensidade do tremor
    public float speed = 1f;             // Velocidade do tremor
    public GameObject[] characters;      // 0 = boy, 1 = girl

    [Header("Check Start game")]
    public TMP_InputField nameCharacter; // Campo de entrada para o nome do personagem

    private Vector3[] originalPositions; // pega a posição inicial de cada gameobject para quando parar de tremer, fazer o retorno
    private bool[] isTrembling; // controle de tremor de cada personagem
    private float[] noiseOffsets; // controle de offset para cada personagem
    private Color originalColor; // Cor original do personagem
    public Color select; // Cor de seleção do personagem

    public string text = ""; // Variável estática para armazenar a skin do jogador

    void Start()
    {
        PlayerSpawn.PlayerSkin = ""; // sempre começa sem valor para não dar erro na hora de instanciar o personagem

        originalColor = characters[0].GetComponent<Image>().color;  // pega a cor original do personagem
        int count = characters.Length; // número de personagens
        originalPositions = new Vector3[count]; // armazena a posição original de cada personagem
        isTrembling = new bool[count]; // controle de tremor de cada personagem
        noiseOffsets = new float[count]; // controle de offset para cada personagem

        for (int i = 0; i < count; i++)
        {
            originalPositions[i] = characters[i].transform.localPosition; // armazena a posição original de cada personagem
            isTrembling[i] = false; // inicia o tremor como falso para ambos os personagens
            noiseOffsets[i] = Random.Range(0f, 100f); // Garante variação de início diferente por personagem
        }

        isSelection = false; // inicia a seleção como falsa

        nameCharacter.onValueChanged.AddListener(CheckTextLength); // adiciona o listener para verificar o tamanho do texto
    }

    void Update()
    {
        float time = Time.time; // tempo atual para calcular o tremor

        for (int i = 0; i < characters.Length; i++)
        {
            if (isTrembling[i])
            {
                float x = Mathf.PerlinNoise(time * speed + noiseOffsets[i], 0f) - 0.5f; // gera um valor de Perlin Noise para o eixo X
                float y = Mathf.PerlinNoise(0f, time * speed + noiseOffsets[i]) - 0.5f; // gera um valor de Perlin Noise para o eixo Y

                Vector3 offset = new Vector3(x, y, 0f) * intensity; // cria um vetor de deslocamento baseado no Perlin Noise
                characters[i].transform.localPosition = originalPositions[i] + offset; // aplica o deslocamento à posição original do personagem
            }
            else
            {
                characters[i].transform.localPosition = originalPositions[i]; // retorna à posição original se não estiver tremendo
            }
        }

        if (isTrembling[0])
            characters[0].GetComponent<Image>().color = select; // cor de seleção do personagem Boy
        else characters[0].GetComponent<Image>().color = originalColor; // cor original do personagem
        if (isTrembling[1])
            characters[1].GetComponent<Image>().color = select; // cor de seleção do personagem Girl
        else characters[1].GetComponent<Image>().color = originalColor; // cor original do personagem
    }

    public void Boy()
    {
        isSelection = true; // ativa a seleção do personagem

        PlayerSpawn.PlayerSkin = "Boy"; // ativa a bool para o spawn com prefab do jogador Boy

        isTrembling[0] = true; // ativa tremor no personagem Boy
        isTrembling[1] = false; // desativa tremor no personagem Girl
        Debug.Log("Boy trembling");
    }

    public void Girl()
    {
        isSelection = true; // ativa a seleção do personagem

        PlayerSpawn.PlayerSkin = "Girl"; // ativa a bool para o spawn com prefab do jogador Boy

        isTrembling[0] = false; // desativa tremor no personagem Boy
        isTrembling[1] = true; // ativa tremor no personagem Girl
        Debug.Log("Girl trembling");
    }

    public void StartGame()
    {
        if (isSelection && isName)
        {
            SceneManager.LoadScene("GameplayScene"); // carrega a cena do jogo
        }
        else
        {
            if (!isSelection)
            {
                Debug.Log("Select a character"); // mensagem de erro se não houver seleção
            }
            if (!isName)
            {
                Debug.Log("Enter a name"); // mensagem de erro se o nome não estiver definido
            }
        }
    }

    void CheckTextLength(string text)
    {
        
        if (text.Length > 3) // verifica se o texto tem mais de 3 letras
        {
            isName = true;
        }
        else
        {
            isName = false;
        }

        // Log para mostrar o status
        Debug.Log("Texto maior que 3 letras: " + isName);
    }
}
