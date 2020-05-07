// MCDB Client Beta
// StukInformationSystem.Data
// MasterDienst.cs
// 
// 08 04 2019
// 
// Katharina Bentsche

using System;
using NKM.Base.Definition.Enums;
using NKM.File.Definitions.Common.Dienst;
using NKM.File.Definitions.Common.Person;
using StukInformationSystem.Data.Business.Data.Selects.Admin;

namespace StukInformationSystem.Data.Common.Models.EditDienst {
    public class MasterDienst : IMasterDienst {
        public int DienstID { get; internal set; }
        public DateTime Beginn { get; set; }
        public DateTime Ende { get; set; }
        public int AV { get; set; }
        public bool Abgeschlossen { get; set; }
        public IMemberShort BV { get; set; }
        public ItemRowState ItemState { get; set; }
        public IMasterDienst OrginalRowState { get; set; }
        public int Gaeste { get; set; }
        internal MasterDienst() { }
        public MasterDienst(int dienstId) {
            var mdienst = SingleDienst.DienstByID(dienstId);
            DienstID = mdienst.Value.DienstID;
            Beginn = mdienst.Value.Beginn;
            Ende = mdienst.Value.Ende;
            AV = mdienst.Value.AV;
            BV = mdienst.Value.BV;
            Abgeschlossen = mdienst.Value.Abgeschlossen;
            Gaeste = mdienst.Value.Gaeste;
            ItemState = ItemRowState.Unchanged;
            OrginalRowState = mdienst.Value;
        }
    }
}