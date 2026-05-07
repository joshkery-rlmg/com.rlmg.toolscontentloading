namespace rlmg.Tools.ContentLoading.Examples
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Networking;

    public class ExampleGraphQLContentLoader : GraphQLLoader
    {
        [SerializeField] string imageURL;

        public PokemonData Data;

        protected override IEnumerator AfterAnySuccess(UnityWebRequest webRequest)
        {
            Data = JsonUtility.FromJson<PokemonDataWrapper>(webRequest.downloadHandler.text).data;
            yield return DownloadImages();
        }

        /// <summary>
        /// Downloads images for each retrieved pokemon.
        /// 
        /// Because the PokéAPI's sprite endpoint is complex, this shortcuts getting the image URL endpoints
        /// using a known safe template.
        /// </summary>
        /// <returns></returns>
        private IEnumerator DownloadImages()
        {
            foreach (PokemonSpecies item in Data.pokemonspecies)
            {
                // known safe template for where to retrieve Pokemon images
                string imageEndpoint = imageURL + "/" + item.id + ".png";

                yield return MediaLoadingUtility.LoadTexture2DFromPath(imageEndpoint,
                    tex =>
                    {
                        // store the Texture2D on a NonSerialized field of the PokemonSpecies data item
                        item.Texture = tex;
                    },
                    () =>
                    {
                        Debug.LogError(string.Format("Could not load image at {0}", imageEndpoint));
                    }
                );
            }
        }

        public override string PrettifyJson(string json)
        {
            return JsonUtility.ToJson(JsonUtility.FromJson<PokemonDataWrapper>(json), true);
        }
    }

}