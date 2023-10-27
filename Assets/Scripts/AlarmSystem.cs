using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
	[SerializeField] private float _maxVolume = 1.0f;
	[SerializeField] private float _fadeSpeed = 0.1f;
	[SerializeField] private string _intruderTag = "Intruder";

	private AudioSource _audioSource;
	private bool _intruderInside = false;

	private void Start()
	{
		_audioSource = GetComponent<AudioSource>();
		_audioSource.volume = 0.0f;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(_intruderTag))
		{
			_intruderInside = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag(_intruderTag))
		{
			_intruderInside = false;
		}
	}

	private void Update()
	{
		if (_intruderInside)
		{
			_audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _fadeSpeed * Time.deltaTime);
		}
		else
		{
			_audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0.0f, _fadeSpeed * Time.deltaTime);
		}
	}
}
