using UnityEngine;
using GameScripts.GameElementSystem;

public abstract class ItemElement : MonoBehaviour
{
    public abstract bool _isEquiped { get; set; }

    public abstract bool _isDisable { get; set; }

    public abstract GameObject _gameObject { get; set; }

    public virtual ItemElement itemElement { get { return this; } set { } }

    public virtual void Do()
    {

    }
  

    public virtual void Special()
    {

    }

    public virtual void Charge()
    {

    }
}
