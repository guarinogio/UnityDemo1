//Teravision Games
//This script is usefull for Vfx and other objects that need to be destroyed in an amount of time.

using UnityEngine;
using System.Collections;

/// <summary>
/// Destroy me. Destroys a game object after specified time 
/// </summary>
public class DestroyMe : MonoBehaviour {
	/// <summary>
  /// The destroy time.
  /// </summary>
  //version 2.0
  //Modified the default time from 5 secs to 2 secs.
  public float destroyTime = 1f;
	

  /// <summary>
  /// Start this instance.
  /// </summary>
  void Start () {
        UnityExtensions.Instance.Destroy(this.gameObject, this.destroyTime);
//		Destroy(this.gameObject,destroyTime);
	}
	
}
