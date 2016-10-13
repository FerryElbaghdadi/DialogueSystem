using UnityEngine;
using System.Collections;

public class AnimateText : MonoBehaviour 
{

    public delegate void AnimateTextEventHandler();
    public AnimateTextEventHandler OnAnimatingText;
    public AnimateTextEventHandler OnDoneAnimatingText;

    private string str;

    public string GetAnimatedString
    {
        get { return str; }
    }

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
        }


        yield return new WaitForSeconds(delayText);

        if (OnDoneAnimatingText != null)
            OnDoneAnimatingText();
    }
}
