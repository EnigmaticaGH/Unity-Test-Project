using UnityEngine;
using System.Collections;

public class TeleportLeft : Ability
{
    [SerializeField]
    private float teleportDistance;
    void Update()
    {
        if (Input.GetKeyUp(_key) && _status == Status.Ready)
        {
            Activate();
        }
    }

    protected override void Activate()
    {
        StartCoroutine(Active());
    }

    private IEnumerator Active()
    {
        float initialTime = Time.time;
        _status = Status.Active;
        while(Time.time - initialTime <= _activeTime)
        {
            transform.position += Vector3.left * teleportDistance / _activeTime * Time.deltaTime;
            yield return null;
        }
        _status = Status.Cooldown;
        yield return new WaitForSeconds(_cooldownTime);
        _status = Status.Ready;
    }
}
