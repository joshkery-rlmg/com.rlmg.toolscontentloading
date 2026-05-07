namespace rlmg.Tools.ContentLoading.Examples
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Represents a serializable container for Pokémon data.
    /// </summary>
    /// <remarks>To use with JsonUtility, classes like this must be explicitly marked Serializable.</remarks>
    [Serializable]
    public class PokemonDataWrapper
    {
        public PokemonData data;
    }

    /// <summary>
    /// Represents serializable Pokémon data.
    /// </summary>
    /// <remarks>To use with JsonUtility, classes like this must be explicitly marked Serializable.</remarks>
    [Serializable]
    public class PokemonData
    {
        public PokemonSpecies[] pokemonspecies;
    }

    /// <summary>
    /// Represents serializable data for a single Pokémon species item.
    /// </summary>
    /// <remarks>To use with JsonUtility, classes like this must be explicitly marked Serializable.</remarks>
    [Serializable]
    public class PokemonSpecies
    {
        /// <summary>
        /// Pokédex ID. Bulbasaur is 1.
        /// </summary>
        public int id;

        /// <summary>
        /// Name of Pokémon. 
        /// </summary>
        public string name;

        /// <summary>
        /// Flavor texts for the Pokémon.
        /// The text is different across game versions so that's why this is a list, because multiple
        /// flavor texts are assigned to a single Pokémon.
        /// </summary>
        public PokemonSpeciesFlavorText[] pokemonspeciesflavortexts;

        /// <summary>
        /// Field to which the ContentLoader will assign a Pokémon image.
        /// A NonSerialized property like this is useful for accessing images closely related to specific data classes.
        /// </summary>
        [NonSerialized]
        public Texture2D Texture;
    }

    /// <summary>
    /// Represents localized flavor text for a Pokémon species. 
    /// </summary>
    [Serializable]
    public class PokemonSpeciesFlavorText
    {
        public string flavor_text;
    }

}