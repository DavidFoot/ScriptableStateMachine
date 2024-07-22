using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoBoyd.Runtime;
using TMPro;
using ScriptablesObject.Runtime;

namespace StateMachine.Runtime
{
    public class StateMachine : MonoBehaviour
    {
        #region Publics

        #endregion

        #region Unity API

        private void Awake()
        {
            _monologueAudio = GetComponent<AudioSource>();
            _tmpDelayBetweenSentence = _delayBetweenSentence;
            PickAndPlaySentence(_linkToBeginWith);
            _nextSentenceType = GetTransitionByWeight(_linkToBeginWith.m_transitionObject._transitions);
        }
        private void Update()
        {
            if (_autoSkip)
            {
                if (!_monologueAudio.isPlaying)
                {
                    _tmpDelayBetweenSentence -= Time.deltaTime;
                    if (_tmpDelayBetweenSentence < 0)
                    {
                        PlayNewSentence();
                        _tmpDelayBetweenSentence = _delayBetweenSentence;
                    }
                }
            }

        }

        #endregion

        #region Main methods

        public void PlayNewSentence()
        {
            if (_nextSentenceType)
            {
                Debug.Log(_nextSentenceType.name);
                PickAndPlaySentence(_nextSentenceType);
                if(Random.Range(0,1f) <= _matterLineProbability && _isMatterLine == false)
                {
                    _linkToMatterLine.m_transitionObject = _nextSentenceType.m_transitionObject;
                    _nextSentenceType = _linkToMatterLine;
                    _isMatterLine = true;
                    return;
                }
                _nextSentenceType = GetTransitionByWeight(_nextSentenceType.m_transitionObject._transitions);
                _isMatterLine = false;
            }
        }
        public void SanityToggle() => _sanity = !_sanity;
        
        public void AutoSkipToggle() => _autoSkip = !_autoSkip;

        public void LeaveGame()
        {
            Application.Quit();
        }
        #endregion

        #region Utils

        private void PickAndPlaySentence(LinkRessourceToTransition _sentenceRepository)
        {
            _sentenceIndex = Random.Range(0, _sentenceRepository.m_sentencesAndSounds._lines.Length);
            _sentence = _sentenceRepository.m_sentencesAndSounds._lines[_sentenceIndex].m_sentence;
            if (_sanity)
            {
                _sentenceAudio = _sentenceRepository.m_sentencesAndSounds._lines[_sentenceIndex].m_sane;
            }
            else
            {
                _sentenceAudio = _sentenceRepository.m_sentencesAndSounds._lines[_sentenceIndex].m_crazy;
            }
            _monologueText.text = _sentence;
            _monologueAudio.clip = _sentenceAudio;
            _monologueAudio.Play();
            
        }
        private LinkRessourceToTransition GetTransitionByWeight(BoydTransition[] transitions)
        {
            float totalWeight = 0f;
            foreach (BoydTransition transition in transitions)
            {
                totalWeight += transition.m_probability;
            }
            float randomWeightPoint = UnityEngine.Random.Range(0, totalWeight);
            foreach (BoydTransition transition in transitions)
            {
                if (randomWeightPoint < transition.m_probability)
                {
                    return transition.m_state;
                }
                randomWeightPoint -= transition.m_probability;
            }
            return transitions[0].m_state;
        }

        #endregion

        #region Privates & Protected

        [SerializeField] LinkRessourceToTransition _linkToBeginWith;
        [SerializeField] LinkRessourceToTransition _linkToMatterLine;
        [Range(0.0f, 1.0f)]
        [SerializeField] public float _matterLineProbability;
        [SerializeField] TMP_Text _monologueText;
        [SerializeField] float _delayBetweenSentence;
        private bool _isMatterLine;
        private float _tmpDelayBetweenSentence;
        private string _sentence;
        private LinkRessourceToTransition _nextTransition;
        private AudioClip _sentenceAudio;
        private AudioSource _monologueAudio;
        private LinkRessourceToTransition _nextSentenceType;
        int _sentenceIndex;
        bool _sanity = true;
        bool _autoSkip = true;

        #endregion
    }

}
