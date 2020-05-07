using NKM.Base.Definition.Enums;

namespace StukInformationSystem.Data.Definitions.Common.Models.Lager
{
    public interface IArtikelArtViewModel {
        int ID { get; set; }
        string ArtikelArt { get; set; }
        ItemRowState ItemState { get; set; }
    }
}
