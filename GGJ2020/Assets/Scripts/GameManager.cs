using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Checkpoint checkpoint;
    private Vector3 checkpointPosition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            checkpointPosition = checkpoint.transform.position;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCheckpoint(Checkpoint checkpoint)
    {
        this.checkpoint = checkpoint;
    }

    public void LoadGame()
    {
        checkpointPosition = checkpoint.transform.position;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    private void CreatePlayer()
    {
        Debug.Log(checkpointPosition);
        Instantiate(player, (Vector2)checkpointPosition, Quaternion.identity);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CreatePlayer();
    }
}