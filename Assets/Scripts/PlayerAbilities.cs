using UnityEngine;
using System.Collections;

public class PlayerAbilities : MonoBehaviour
{
    private Ability[] abilities;

    void Awake()
    {
        abilities = new Ability[]
        {
            new Ability("Random Move", KeyCode.Space, Active, 2, 10)
        };
    }

    void Update()
    {
        foreach(Ability a in abilities)
        {
            if (GameInput.Up(a.Name) && a.AbilityStatus == Ability.Status.Ready)
            {
                a.Activate();
            }
        }
    }

    void Active(Ability activeAbility)
    {
        StartCoroutine(AbilityActive(activeAbility));
    }

    IEnumerator AbilityActive(Ability ability)
    {
        float x = Random.Range(-5, 5);
        float y = Random.Range(-5, 5);
        float z = Random.Range(-5, 5);
        float t = 0;
        Vector3 oldPosition = transform.position;
        Vector3 newPosition = transform.position + new Vector3(x, y, z);
        while ((t += Time.deltaTime) < ability.ActiveTime)
        {
            yield return null;
            transform.position = Vector3.Lerp(oldPosition, newPosition, t / ability.ActiveTime);
        }
    }
}
