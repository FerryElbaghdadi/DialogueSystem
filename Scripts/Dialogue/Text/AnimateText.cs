using UnityEngine;
using System.Collections;

public class AnimateText : MonoBehaviour 
{
    
    /*
     * This script animates the text.
     * This takes care of displaying the string per character,
     * With an adjustable delay between the characters,
     * And between sentences.
     *
     * RESPONSIBILITY: Animate a string per character.
     */

    private string str;

    public string GetAnimatedString
    {
        get { return str; }
    }
    
    public delegate void AnimateTextEventHandler();
    public AnimateTextEventHandler OnAnimatingText;
    public AnimateTextEventHandler OnDoneAnimatingText;

    public IEnumerator TextAnimator(string strComplete, float txtSpeed, float delayText)
    {
        int i = 0;
        str = "";

        while (i < strComplete.Length)
        {
            str += strComplete[i++];
   
            if (OnAnimatingText != null)
                OnAnimatingText();

            yield return new WaitForSeconds(txtSpeed);
            // The delay that we will use per character.
        }


        yield return new WaitForSeconds(delayText);
        
        // The delay that we will use before ending the text/Letting the player know he can progress.

        if (OnDoneAnimatingText != null)
            OnDoneAnimatingText();
    }
}
