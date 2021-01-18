using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    private float _volumeChangeStep;
    private AudioSource _signaling;

    private void Start()
    {
        _signaling = GetComponent<AudioSource>();
        _volumeChangeStep = .01f;
        _signaling.volume = 0;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            StopAllCoroutines();
            StartCoroutine(AddVolume());
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            StopAllCoroutines();
            StartCoroutine(RemoveVolume());
        }
    }

    private IEnumerator AddVolume()
    {
        _signaling.Play();
        while(_signaling.volume < 1)
        {
        _signaling.volume += _volumeChangeStep;
        yield return null;
        }
    }

    private IEnumerator RemoveVolume()
    {
        while (_signaling.volume > 0)
        {
            _signaling.volume -= _volumeChangeStep;
            yield return null;
        }
        _signaling.Stop();
    }
}
