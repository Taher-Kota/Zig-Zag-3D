using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagers : MonoBehaviour
{
    [SerializeField] public AudioSource Background;
    [SerializeField] public AudioSource CoinCollect;

    public static SoundManagers instance;

    private void Awake()
    {
        instance = this;
    }

}
