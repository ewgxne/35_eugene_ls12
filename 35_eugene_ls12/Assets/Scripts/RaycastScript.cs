using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaycastScript : MonoBehaviour
{
    public int score;
    public Text ScoreText;
    public Text TimerText;
    public float timerLeft;

    // Start is called before the first frame update
    void Start()
    {
        TimerText.GetComponent<Text>().text = "Timer: " + timerLeft;
        ScoreText.GetComponent<Text>().text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        TimerText.GetComponent<Text>().text = "Timer: " + timerLeft;
        ScoreText.GetComponent<Text>().text = "Score: " + score;

        if (Input.GetMouseButtonDown(0))
        {
            // get mouse position in world space
            Vector3 worldmouseposition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));
            // get direction 
            Vector3 direction = worldmouseposition - Camera.main.transform.position;
            RaycastHit hit;
            // cast a ray from the camera in the given direction
            if (Physics.Raycast(Camera.main.transform.position,direction,out hit, 100f))
            {
                // for testing the casted ray in Scene view
                Debug.DrawLine(Camera.main.transform.position, hit.point, Color.green, 0.5f);
            }
            else
            {
                // for testing the casted ray in Scene view
                Debug.DrawLine(Camera.main.transform.position, worldmouseposition, Color.red, 0.5f);
            }
            if (hit.collider.CompareTag("RedSphere"))
            {
                score -= 1;
                

            }
            if (hit.collider.CompareTag("GreenSphere"))
            {
                score += 1;
            }
        }
        if (score == 15)
        {
            SceneManager.LoadScene("GameWin");
        }
        if (score <= -1)
        {
            SceneManager.LoadScene("GameOver");
        }
        timerLeft += Time.deltaTime;
        if (timerLeft >= 30)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
