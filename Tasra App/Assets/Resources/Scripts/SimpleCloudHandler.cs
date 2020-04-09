using System;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class SimpleCloudHandler : MonoBehaviour, IObjectRecoEventHandler
{
    #region PRIVATE_MEMBER_VARIABLES

    private CloudRecoBehaviour mCloudRecoBehaviour;
    private ObjectTracker mImageTracker;
    private bool mIsScanning = false;
    private string mTargetName = "";
    private string mTargetMetadata = "";
    private GameObject newImageTarget;

    #endregion // PRIVATE_MEMBER_VARIABLES

    #region EXPOSED_PUBLIC_VARIABLES

    /// <summary>
    /// can be set in the Unity inspector to reference a ImageTargetBehaviour that is used for augmentations of new cloud reco results.
    /// </summary>
    public ImageTargetBehaviour ImageTargetTemplate;
    public ImageTargetBehaviour ImageTargetBehaviour;
    public Text title;
    public Text description;
    public AudioSource audioSource;

    [System.Serializable]
    public class AugmentationObject
    {
        public string targetName;
        public GameObject augmentation;
    }

    public AugmentationObject[] AugmentationObjects;

    [System.Serializable]
    public class SoundObject
    {
        public string targetName;
        public AudioClip sound;
    }

    public SoundObject[] SoundObjects; 

    #endregion

    #region UNTIY_MONOBEHAVIOUR_METHODS

    /// <summary>
    /// register for events at the CloudRecoBehaviour
    /// </summary>
    void Start()
    {
        // register this event handler at the cloud reco behaviour
        CloudRecoBehaviour cloudRecoBehaviour = GetComponent<CloudRecoBehaviour>();
        if (cloudRecoBehaviour)
        {
            cloudRecoBehaviour.RegisterEventHandler(this);
        }

        // remember cloudRecoBehaviour for later
        mCloudRecoBehaviour = cloudRecoBehaviour;
    }

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS


    #region ICloudRecoEventHandler_IMPLEMENTATION

    /// <summary>
    /// called when TargetFinder has been initialized successfully
    /// </summary>
    /// 
    public void OnInitialized(TargetFinder targetFinder)
    {
        mImageTracker = (ObjectTracker)TrackerManager.Instance.GetTracker<ObjectTracker>();
    }

    /// <summary>
    /// visualize initialization errors
    /// </summary>
    public void OnInitError(TargetFinder.InitState initError)
    {
    }

    /// <summary>
    /// visualize update errors
    /// </summary>
    public void OnUpdateError(TargetFinder.UpdateState updateError)
    {
    }

    /// <summary>
    /// when we start scanning, unregister Trackable from the ImageTargetTemplate, then delete all trackables
    /// </summary>
    public void OnStateChanged(bool scanning)
    {

        mIsScanning = scanning;
        if (scanning)
        {
            // clear all known trackables

            ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
            tracker.GetTargetFinder<ImageTargetFinder>().ClearTrackables(false);

        }
    }


    /// <summary>
    /// Handles new search results
    /// </summary>
    /// <param name="targetSearchResult"></param>
    public void OnNewSearchResult(TargetFinder.TargetSearchResult targetSearchResult)
    {

        TargetFinder.CloudRecoSearchResult cloudRecoSearchResult = (TargetFinder.CloudRecoSearchResult)targetSearchResult;

        // duplicate the referenced image target
        newImageTarget = Instantiate(ImageTargetTemplate.gameObject) as GameObject;
        GameObject augmentation = null;

        if (augmentation != null) { 
        augmentation.transform.parent = newImageTarget.transform;
           
        }

        // enable the new result with the same ImageTargetBehaviour:
        ImageTargetBehaviour = (ImageTargetBehaviour)mImageTracker.GetTargetFinder<ImageTargetFinder>().EnableTracking(targetSearchResult, newImageTarget);
        
        mTargetName = cloudRecoSearchResult.TargetName;
        mTargetMetadata = cloudRecoSearchResult.MetaData;

        for (int i = 0; i < ImageTargetBehaviour.gameObject.transform.childCount; i++)
        {
            if (ImageTargetBehaviour.gameObject.transform.GetChild(i).gameObject.name != mTargetName)
            {
                ImageTargetBehaviour.gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < SoundObjects.Length; i++)
        {
            if(SoundObjects[i].targetName == mTargetName)
            {
                audioSource.clip = SoundObjects[i].sound;
            }
        }

        title.text = mTargetName;

        if (UIManager.instance.isEnglish)
        {
            description.text = mTargetMetadata.Substring(0, mTargetMetadata.IndexOf('~'));
        }
        else
        {
            description.text = mTargetMetadata.Substring(mTargetMetadata.IndexOf('~') + 1);
        }

        if (!mIsScanning)
        {
            // stop the target finder
            mCloudRecoBehaviour.CloudRecoEnabled = true;
        }
    }

    public void PlayAudio()
    {
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }

    public void ClearInfo()
    {
        title.text = "";
        description.text = "";
    }


    #endregion // ICloudRecoEventHandler_IMPLEMENTATION
}