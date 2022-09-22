using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    public static UIController instance;
    [SerializeField] private Image heart1, heart2, heart3;
    [SerializeField] private Sprite fullHeartSprite, emptyHeartSprite,halfHeartSprite;
    [SerializeField] private Text gemText;

    public GameObject pausePanel;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseOrUnpause();
        }
    }
    public void PauseOrUnpause()
    {
        if (LevelManager.instance.isPaused)
        {
            LevelManager.instance.isPaused = false;
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
        else
        {
            LevelManager.instance.isPaused = true;
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        LevelManager.instance.isPaused = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void LevelSelect()
    {
        Debug.Log("will be add soon");
        //Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void UpdateHeartDisplay(int health)
    {
        switch (health)
        {
            case 6:
                heart1.sprite = fullHeartSprite;
                heart2.sprite = fullHeartSprite;
                heart3.sprite = fullHeartSprite;
                break;
            case 5:
                heart1.sprite = fullHeartSprite;
                heart2.sprite = fullHeartSprite;
                heart3.sprite = halfHeartSprite;
                break;
            case 4:
                heart1.sprite = fullHeartSprite;
                heart2.sprite = fullHeartSprite;
                heart3.sprite = emptyHeartSprite;
                break;
            case 3:
                heart1.sprite = fullHeartSprite;
                heart2.sprite = halfHeartSprite;
                heart3.sprite = emptyHeartSprite;
                break;
            case 2:
                heart1.sprite = fullHeartSprite;
                heart2.sprite = emptyHeartSprite;
                heart3.sprite = emptyHeartSprite;
                break;
            case 1:
                heart1.sprite = halfHeartSprite;
                heart2.sprite = emptyHeartSprite;
                heart3.sprite = emptyHeartSprite;
                break;
            case 0:
                heart1.sprite = emptyHeartSprite;
                heart2.sprite = emptyHeartSprite;
                heart3.sprite = emptyHeartSprite;
                break;
            default:
                break;
        }
    }

    public void UpdateGemDisplay(int gem)
    {
        gemText.text = gem.ToString();
    }
}