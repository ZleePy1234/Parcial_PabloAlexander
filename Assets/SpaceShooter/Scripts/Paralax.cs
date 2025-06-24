using UnityEngine;
using UnityEngine.UI;

public class Paralax : MonoBehaviour
{
    public float speedX;
    public float speedY;
    private RawImage bg;

    void Awake()
    {
        bg = GetComponent<RawImage>();
    }

    void Update()
    {
        MoveBackground();
    }

    void MoveBackground()
    {
        bg.uvRect = new Rect( bg.uvRect.position + new Vector2(speedX, speedY) * Time.deltaTime, bg.uvRect.size );
    }
}
