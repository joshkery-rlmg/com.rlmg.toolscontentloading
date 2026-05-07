namespace rlmg.Tools.ContentLoading.Examples
{
    using System.Net;
    using TMPro;
    using UnityEngine;
    using UnityEngine.Networking;

    /// <summary>
    /// Just displays text based on response - success/fail and json if succeeded
    /// </summary>
    public class ExampleContentLoaderListener : MonoBehaviour
    {
        /// <summary>
        /// Any ContentLoader in the scene
        /// </summary>
        ContentLoader contentLoader;

        [SerializeField] TMP_Text heading, body;

        private void Awake()
        {
            contentLoader = FindAnyObjectByType<ContentLoader>();
        }

        private void OnEnable()
        {
            contentLoader.AllLoadingStarted.AddListener(OnLoadStarted);
            contentLoader.AnyLoadSucceeded.AddListener(OnLoadSucceeded);
            contentLoader.AnyLoadFailed.AddListener(OnLoadFailed);
        }

        private void OnDisable()
        {
            contentLoader.AllLoadingStarted.RemoveListener(OnLoadStarted);
            contentLoader.AnyLoadSucceeded.RemoveListener(OnLoadSucceeded);
            contentLoader.AnyLoadFailed.RemoveListener(OnLoadFailed);
        }

        private void OnLoadStarted()
        {
            heading.text = "Loading...";
            body.text = "";
        }

        private void OnLoadSucceeded(UnityWebRequest request)
        {
            heading.text = "Loaded successfully!";
            body.text = contentLoader.PrettifyJson( request.downloadHandler.text );
        }
            
        private void OnLoadFailed(UnityWebRequest request)
        {
            heading.text = "Load failed!";
            body.text = $"An error occurred while loading the config from\n{request.uri}:\n{request.error}";
        }
    }

}