using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
	[SerializeField] private float _maxVolume = 1.0f;
	[SerializeField] private float _fadeSpeed = 0.1f;
	[SerializeField] private string _intruderTag = "Intruder";

	private AudioSource _audioSource;
	private Coroutine _coroutine;

	private void Start()
	{
		_audioSource = GetComponent<AudioSource>();
		_audioSource.volume = 0.0f;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(_intruderTag))
		{
			if (_coroutine != null)
				StopCoroutine(_coroutine);

			_coroutine = StartCoroutine(ChangeVolume(_maxVolume));
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag(_intruderTag))
		{
			if (_coroutine != null)
				StopCoroutine(_coroutine);

			_coroutine = StartCoroutine(ChangeVolume(0));
		}
	}

	private IEnumerator ChangeVolume(float target)
	{
		do
		{
			_audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _fadeSpeed * Time.deltaTime);
			yield return null;
		} while (_audioSource.volume != target);
	}
}
