using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perceval : MonoBehaviour
{
    [SerializeField] private float duration;

    [SerializeField] private AudioSource audioSource;

    private float randomPercevalApparition;

    private bool playOnce = false;
    [HideInInspector]
    public bool pdgIndependant = false;

    public static Perceval instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        randomPercevalApparition = Random.Range(15, TimerManager.instance.timer - 15);
        Debug.Log(randomPercevalApparition);
    }

    // Update is called once per frame
    void Update()
    {
        PaysDeGalleIndependant();
    }

    private void PaysDeGalleIndependant()
    {
        if(!playOnce && TimerManager.instance.timer <= randomPercevalApparition)
        {
            playOnce = true;
            pdgIndependant = true;
            
            StartCoroutine(Shake(duration));
            
            audioSource.PlayOneShot(SoundManager.instance.paysDeGalleIndependant);
        }
    }

    IEnumerator Shake(float duration)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(originalPos.x - 0.2f, originalPos.x + 0.2f);
            float y = Random.Range(originalPos.y - 0.2f, originalPos.y + 0.2f);

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
        pdgIndependant = false;
    }
}
