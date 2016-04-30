using UnityEngine;
using System.Collections;

public class PlayerAbilities : MonoBehaviour
{
    Ability ability;
    void Start()
    {
        ability = new Ability("Ability 1", Active, 2.5f, 1);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && ability.AbilityStatus == Ability.Status.Ready)
        {
            ability.Activate();
        }
    }

    void Active()
    {
        StartCoroutine(AbilityActive());
    }

    IEnumerator AbilityActive()
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
