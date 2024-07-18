using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoBoyd.Runtime;

namespace StateMachine.Runtime
{
    public class StateMachine : MonoBehaviour
    {
        #region Publics
	
        #endregion

        #region Unity API
	
        #endregion

        #region Main methods



        #endregion

        #region Utils

        #endregion

        #region Privates & Protected

        [SerializeField] SoBoydTextSound TheConspirators;
        [SerializeField] SoBoydTextSound VictimLinkLines;
        [SerializeField] SoBoydTextSound Victims;
        [SerializeField] SoBoydTextSound TerminalActions;
        [SerializeField] SoBoydTextSound SemiTerminalActions;
        [SerializeField] SoBoydTextSound Reactions;
        [SerializeField] SoBoydTextSound LoopingActions;
        [SerializeField] SoBoydTextSound LinkableLines;

        #endregion
    }

}
