using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveDataCup : MonoBehaviour
{
    public static int ballsCaught = 0;
    public UpdateMosaic um;
    //Remove data when it touches cup and update image
    private void OnTriggerEnter2D(Collider2D other) {
        ballsCaught++;
	Destroy(other.gameObject);
        um.UpdateImage(ballsCaught);
    }
}
