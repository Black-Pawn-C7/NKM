using Newtonsoft.Json;
using NKM.Base.Definition.Enums;
using StukInformationSystem.Data.Definitions.Common.Models.Lager;
using System;
using System.Collections;
using System.Collections.Generic;

namespace StukInformationSystem.Data.Common.Models.Lager
{
    public class ArtikelArtViewModel : IArtikelArtViewModel
    {

        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("ArtikelArt")]
        public string ArtikelArt { get; set; }
        [JsonIgnore]
        public ItemRowState ItemState { get; set; }
    }
    //public class ArtikelArt : IEnumerable
    //{
    //    private ArtikelArtViewModel[] _artikelarten;
    //    public ArtikelArt(ArtikelArtViewModel[] aArray)
    //    {
    //        _artikelarten = new ArtikelArtViewModel[aArray.Length];

    //        for (int i = 0; i < aArray.Length; i++)
    //        {
    //            _artikelarten[i] = aArray[i];
    //        }
    //    }

    //    // Implementation for the GetEnumerator method.
    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return (IEnumerator)GetEnumerator();
    //    }

    //    public ArtikelArtEnum GetEnumerator()
    //    {
    //        return new ArtikelArtEnum(_artikelarten);
    //    }
    //}

    //// When you implement IEnumerable, you must also implement IEnumerator.
    //public class ArtikelArtEnum : IEnumerator
    //{
    //    public ArtikelArtViewModel[] _artikelarten;

    //    // Enumerators are positioned before the first element
    //    // until the first MoveNext() call.
    //    int position = -1;

    //    public ArtikelArtEnum(ArtikelArtViewModel[] list)
    //    {
    //        _artikelarten = list;
    //    }

    //    public bool MoveNext()
    //    {
    //        position++;
    //        return (position < _artikelarten.Length);
    //    }

    //    public void Reset()
    //    {
    //        position = -1;
    //    }

    //    object IEnumerator.Current
    //    {
    //        get
    //        {
    //            return Current;
    //        }
    //    }

    //    public ArtikelArtViewModel Current
    //    {
    //        get
    //        {
    //            try
    //            {
    //                return _artikelarten[position];
    //            }
    //            catch (IndexOutOfRangeException)
    //            {
    //                throw new InvalidOperationException();
    //            }
    //        }
    //    }
    //}
}
