using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shore : Suspect
{
    private bool startPitchingDown;
    private void Update()
    {
        if (startPitchingDown)
        {
            if (backgroundMusicSource.pitch > 0.5)
            {
                backgroundMusicSource.pitch -= Time.deltaTime * 1 / 5f;
            }
            if (backgroundMusicSource.pitch <= 0.5)
            {
                startPitchingDown = false;
            }
        }
    }
    public override void UnlockDialogue()
    {
        base.UnlockDialogue();
        startPitchingDown = true;
    }
}
