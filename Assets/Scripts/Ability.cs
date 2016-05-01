using UnityEngine;
using System.Collections;

public enum Status
{
    Ready,
    Active,
    Cooldown
}
public abstract class Ability : MonoBehaviour
{
    [SerializeField]
    protected string _name;
    [SerializeField]
    protected float _activeTime;
    [SerializeField]
    protected float _cooldownTime;
    [SerializeField]
    protected KeyCode _key;
    protected Status _status;
    public string Name { get { return _name; } }
    protected abstract void Activate();
}
