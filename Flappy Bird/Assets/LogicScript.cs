using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scoreText.text = playerScore.ToString();
        gameOverScreen.SetActive(false);
    }

    public void addScore ()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
        audioSource.Play();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void returnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void gameOver ()
    {
        gameOverScreen.SetActive(true);
    }
}
