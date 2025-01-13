using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    public float speed;

    public Vector3 dir;

    [SerializeField] private GameObject particles;

    public static PlayerControl instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        dir = Vector3.zero;
        InvokeRepeating("IncreaseSpeed", 12f, 12f);
        Invoke("PlaySound", 1f);
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetMouseButtonDown(0))
            {
                if (dir == Vector3.forward)
                {
                    dir = Vector3.right;
                }
                else
                {
                    dir = Vector3.forward;
                }
                GameManagers.instance.GameStart();
            }
        float amountToMove = speed * Time.deltaTime;
        transform.Translate(dir * amountToMove);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Diamond")
        {
            ScoreManagers.instance.Score++;
            UIManagers.instance.LiveScore.text = ScoreManagers.instance.Score.ToString();
            GameObject particle = Instantiate(particles, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            SoundManagers.instance.CoinCollect.Play();
            Destroy(particle, 2f);
        }
        else if (collision.gameObject.tag == "Monster")
        {
            ScoreManagers.instance.Score--;
            UIManagers.instance.LiveScore.text = ScoreManagers.instance.Score.ToString();
            Destroy(collision.gameObject);
            SoundManagers.instance.CoinCollect.Play();
        }
    }

    void IncreaseSpeed()
    {
        speed += .35f;
    }

    public void PlaySound()
    {
        SoundManagers.instance.Background.Play();
    }
}
