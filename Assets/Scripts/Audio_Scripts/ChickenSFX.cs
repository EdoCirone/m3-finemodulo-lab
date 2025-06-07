using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ChickenSFX : MonoBehaviour
{

    [SerializeField] AudioClip _hitSFX;
    [SerializeField] AudioClip _idleSFX;
    [SerializeField] AudioClip _deathSFX;
    AudioSource _audioSrc;
    LifeController _lifeController;

    private float _timer;
    private bool _hit;

    private void Awake()
    {
        _audioSrc = GetComponent<AudioSource>();
        _lifeController = GetComponent<LifeController>();
    }
    private void Start()
    {

        PlayIdleLoop();

    }

    private void Update()
    {
        if (_hit)
        {
            _timer -= Time.deltaTime;

            if (_timer < 0)

            {
                PlayIdleLoop();
                _hit = false;

            }

        }

        CheckPlayDeath();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_hit) return;

        if (!_audioSrc.enabled) { _audioSrc.enabled = true; }

        if (collision.gameObject.GetComponent<Bullet>() != null)
        {

            _audioSrc.loop = false;
            _audioSrc.clip = _hitSFX;
            _audioSrc.Play();

            _timer = _audioSrc.clip.length;
            _hit = true;
        }
    }

    private void PlayIdleLoop()
    {
        if (_audioSrc.clip != _idleSFX && _idleSFX != null)

        {

            _audioSrc.loop = true;
            _audioSrc.clip = _idleSFX;
            _audioSrc.Play();

        }

    }

    private void CheckPlayDeath()
    {

        if (!_lifeController.IsAlive)
        {
            _audioSrc.loop = false;
            _audioSrc.clip = _deathSFX;
            _audioSrc.Play();

            _timer = _audioSrc.clip.length;
            _hit = true;
        }

    }



}
