using System;
using NKM.Base.Definition.Enums;

namespace StukInformationSystem.Data.Definitions.Common.Models {
    public interface IMemberTinyModel {
        int Id { get; set; }

        string Name { get; set; }
    }
}