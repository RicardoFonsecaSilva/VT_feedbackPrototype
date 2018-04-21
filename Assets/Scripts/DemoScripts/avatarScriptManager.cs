//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class avatarScriptManager : MonoBehaviour {

//    private string male = "Joao";
//    private string female = "Maria";

//    [SerializeField]
//    private AvatarManager manager;

//    private enum GAZE_DIR
//    {
//        LEFT = 1,
//        RIGHT = 2
//    }

//    public void express(string who, Expression expression)
//    {
//        manager.Express(new Tutor(who), expression);
//    }

//    public void mood(string who, Emotion emotion)
//    {
//        manager.Feel(new Tutor(who, emotion));
//    }

//    public void talkFor(string who, float sec)
//    {
//        StartCoroutine(avatarTalkFor(new Tutor(who), sec));
//    }

//    IEnumerator avatarTalkFor(Tutor tutor, float wait)
//    {
//        manager.Act(tutor, new HeadAction("Talk", ""));
//        yield return new WaitForSeconds(wait);
//        manager.Act(tutor, new HeadAction("Talk", "End"));
//    }

//    public void gazeFor(string who, float sec, int dir)
//    {
//        StartCoroutine(avatarGazeFor(new Tutor(who), sec, (GAZE_DIR)dir));
//    }

//    IEnumerator avatarGazeFor(Tutor tutor, float wait, GAZE_DIR gazeDir)
//    {
//        if (gazeDir == GAZE_DIR.LEFT)
//        {
//            manager.Act(tutor, new HeadAction("Gaze", "Middle to Left"));
//            yield return new WaitForSeconds(wait + 1);
//            manager.Act(tutor, new HeadAction("Gaze", "Left to Middle"));
//        }
//        if (gazeDir == GAZE_DIR.RIGHT)
//        {
//            manager.Act(tutor, new HeadAction("Gaze", "Middle to Right"));
//            yield return new WaitForSeconds(wait + 1);
//            manager.Act(tutor, new HeadAction("Gaze", "Right to Middle"));
//        }
//    }
//}