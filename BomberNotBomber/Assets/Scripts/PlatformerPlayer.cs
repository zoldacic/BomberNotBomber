using UnityEngine;
using System.Collections;

public class PlatformerPlayer : MonoBehaviour
{
    public float Speed = 250.0f;
    public float JumpForce = 1;

    private Rigidbody2D _body;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        #if UNITY_STANDALONE || UNITY_WEBPLAYER

        float deltaX = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;

        // Somtimes need more TLC?
        //if (!Mathf.Approximately(0, deltaX))
        //{
        //    transform.rotation = deltaX > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        //}

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_body.velocity.y) < 0.001f)
        {
            _body.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        #elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE

        #endif //End of mobile platform dependendent compilation section started above with #elif
    }
} 