using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private GameObject nextShape = null;
    private GameObject currentActiveShape = null;
    [SerializeField] private GameObject[] shapesToSpawn;
    [SerializeField] private GameObject hoverArea;
    [SerializeField] private float shapeSpawnDelay = 2f;
    private int points = 0;
    [SerializeField] private TextMeshProUGUI pointsText;

    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentActiveShape = SpawnNewShape();
        nextShape = SpawnNewShape();
    }

    public GameObject SpawnNewShape()
    {
        int randomIndex = Random.Range(0, shapesToSpawn.Length);
        return SpawnShape(shapesToSpawn[randomIndex], new Vector3(1, 6, 0));
    }

    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
        pointsText.text = points.ToString();
    }

    public GameObject SpawnShape(GameObject shape, Vector3 position)
    {
        return Instantiate(shape, position, Quaternion.identity);
    }

    public void UpdateActiveShape()
    {
        currentActiveShape = nextShape;
        nextShape = null;
        currentActiveShape.transform.position = new Vector3(-5.2f, 6, 0);
        nextShape = SpawnNewShape();
    }

    public void SetActiveShapePosition(Vector3 position)
    {
        if (currentActiveShape != null)
        {
            currentActiveShape.transform.position = position;
        }
    }

    public void DropShape()
    {
        if (currentActiveShape != null)
        {
            currentActiveShape.GetComponent<Rigidbody>().isKinematic = false;
            currentActiveShape = null;
            Invoke("UpdateActiveShape", shapeSpawnDelay);
        }
    }
}
