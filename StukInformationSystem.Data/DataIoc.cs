using NKM.Base.Common.Ioc;
using StukInformationSystem.Data.Business.Converter;
using StukInformationSystem.Data.Business.Data.Insert;
using StukInformationSystem.Data.Business.Data.RawTables;
using StukInformationSystem.Data.Business.Data.RawTables.View;
using StukInformationSystem.Data.Business.Data.Selects;
using StukInformationSystem.Data.Business.Data.Selects.Admin;
using StukInformationSystem.Data.Business.Data.Update;
using StukInformationSystem.Data.Definitions.Business;
using StukInformationSystem.Data.Definitions.Business.Converter;
using StukInformationSystem.Data.Definitions.Business.Data.Selects;
using StukInformationSystem.Data.Definitions.Business.Data.Insert;
using StukInformationSystem.Data.Definitions.Business.Data.RawTables;
using StukInformationSystem.Data.Definitions.Business.Data.RawTables.View;
using StukInformationSystem.Data.Definitions.Business.Data.Selects.Admin;
using StukInformationSystem.Data.Definitions.Business.Data.Update;
using StukInformationSystem.Data.Definitions.Select;
using StukInformationSystem.Data.Select;

namespace StukInformationSystem.Data {
    public class DataIoc {
        public static IocFactory Ioc { get; } = RegisterIoc();

        //public DataIoc() => Ioc = new IocFactory();

        private static IocFactory RegisterIoc() {
            var ic = new IocFactory();
            ic.RegisterSingleton<IMitglieder, Mitglieder>();
            ic.RegisterSingleton<IDienstAdminViewEdit, DienstAdminViewEdit>();
            ic.RegisterSingleton<IJsonSerializerDeserialize, JsonSerializerDeserialize>();
            ic.RegisterSingleton<IAuswählenAdmin, AuswählenAdmin>();
            ic.RegisterSingleton<IAuswählen, Auswählen>();
            ic.RegisterSingleton<IAuswählenView, AuswählenView>();
            ic.RegisterSingleton<ISetSettings, SetSettings>();
            ic.RegisterSingleton<IFromSettings, FromSettings>();
            ic.RegisterSingleton<IIntoSettings, IntoSettings>();
            ic.RegisterSingleton<IGeneralSelects, GeneralSelects>();
            ic.RegisterSingleton<IIntoCoupon, IntoCoupon>();
            return ic;
        }
    }
}