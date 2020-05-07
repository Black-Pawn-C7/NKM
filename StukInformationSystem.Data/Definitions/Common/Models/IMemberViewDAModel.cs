using NKM.Base.Definition.Enums;

namespace StukInformationSystem.Data.Definitions.Common.Models {
    public interface IMemberViewDAModel {
        int Id { get; set; }

        string Name { get; set; }

        decimal Dienste { get; set; }

        decimal AEs { get; set; }

        ItemRowState ItemState { get; set; }
    }
}