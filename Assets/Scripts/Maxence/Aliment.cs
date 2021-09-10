using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliment : enumIngredients
{
    public float points = 0f;

    public Rigidbody rigidbodyAliment;

    private bool move = true;
    private bool alreadyFallen = false;

    private float moveTimeP = 0;

    public Sprite icon;

    private void Awake()
    {
        rigidbodyAliment = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Menu.instance.onMenu)
            return;

        AfterCollisionImpact();
        StopMove();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "sandwich" && gameObject.tag != "sandwich")
        {
            gameObject.tag = "sandwich";

            switch(gameObject.name)
            {
                case "Beurre(Clone)":
                    AudioSource.PlayClipAtPoint(SoundManager.instance.beurre, gameObject.transform.position);
                    break;

                case "Fromage(Clone)":
                    AudioSource.PlayClipAtPoint(SoundManager.instance.fromage, gameObject.transform.position);
                    break;

                case "Jambon(Clone)":
                    AudioSource.PlayClipAtPoint(SoundManager.instance.jambon, gameObject.transform.position);
                    break;

                case "Salade(Clone)":
                    AudioSource.PlayClipAtPoint(SoundManager.instance.salade, gameObject.transform.position);
                    break;

                case "Saucisse(Clone)":
                    AudioSource.PlayClipAtPoint(SoundManager.instance.saucicsse, gameObject.transform.position);
                    break;

                case "Steak(Clone)":
                    AudioSource.PlayClipAtPoint(SoundManager.instance.steak, gameObject.transform.position);
                    break;

                case "Pain(Clone)":
                    AudioSource.PlayClipAtPoint(SoundManager.instance.pain, gameObject.transform.position);
                    break;
            }
        }
        else if (collision.gameObject.tag == "Untagged")
        {
            
            gameObject.tag = "Untagged";

            if (alreadyFallen)
            {
                SandwichManager.instance.RemoveIngredient(gameObject);
                StartCoroutine(DestroyObject());
            }
        }
    }

    void AfterCollisionImpact()
    {
        if ((rigidbodyAliment.IsSleeping() && move))
        {
            move = false;
            alreadyFallen = true;

            if (gameObject.CompareTag("sandwich"))
            {
                SandwichManager.instance.AddIngredient(gameObject);
            }
            else if (gameObject.CompareTag("Untagged"))
            {
                SandwichManager.instance.RemoveIngredient(gameObject);

                if (ingredientsDisponible == IngredientsDisponible.Salade)
                    ScoreManager.instance.score += (points * ScoreManager.instance.combo);

                if (TimerManager.instance.reset)
                {
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            AudioSource.PlayClipAtPoint(SoundManager.instance.fall1, gameObject.transform.position);
                            break;

                        case 1:
                            AudioSource.PlayClipAtPoint(SoundManager.instance.fall2, gameObject.transform.position);
                            break;

                        case 2:
                            AudioSource.PlayClipAtPoint(SoundManager.instance.fall3, gameObject.transform.position);
                            break;
                    }

                    TimerManager.instance.reset = false;
                    TimerManager.instance.TimeLess(TimerManager.instance.timeLess);
                }

                StartCoroutine(DestroyObject());
            }

            AlimentsChoiceSpawner.instance.AttributionIngredients();
        }
    }

    void StopMove()
    {
        if(move && gameObject.tag == "sandwich")
        {
            if (moveTimeP < 1f)
                moveTimeP += Time.deltaTime;
            else
                rigidbodyAliment.isKinematic = true;
        }
        else
            rigidbodyAliment.isKinematic = false;
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
