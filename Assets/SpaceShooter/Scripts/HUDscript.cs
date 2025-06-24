using UnityEngine;

public class HUDscript : MonoBehaviour
{
    private PlayerScript playerScript;
    private Animator portraitAnimator;
    private TMPro.TextMeshProUGUI asteroidCounter;
    public TMPro.TextMeshProUGUI timer;
    private TMPro.TextMeshProUGUI hp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
        portraitAnimator = GetComponentInChildren<Animator>();
        asteroidCounter = GameObject.FindWithTag("AsteroidCounter").GetComponent<TMPro.TextMeshProUGUI>();
        timer = GameObject.FindWithTag("Timer").GetComponent<TMPro.TextMeshProUGUI>();
        hp = GameObject.FindWithTag("health").GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        HPdisplay();
        AsteroidCounter();
    }
    
    [HideInInspector]public float elapsedTime = 0f;
    void Timer()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void HPdisplay()
    {
        portraitAnimator.SetInteger("health", playerScript.health);
        hp.text = playerScript.health.ToString() + "/3";
    }
    void AsteroidCounter()
    {
        asteroidCounter.text = playerScript.asteroidsDestroyed.ToString();
    }

    void LateUpdate()
    {
        Timer();
    }
}
