using System;
namespace StukInformationSystem.Data.Definitions.Common.Models {
    public interface IWebVoucherOverview {
        int Id { get; set; }
        string Name { get; set; } 
        string Status { get; set; } 
        double GSWert { get; set; }
        DateTimeOffset? Aufgenomen { get; set; }

    }
}