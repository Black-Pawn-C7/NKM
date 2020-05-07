using System;

namespace StukInformationSystem.Data.Definitions.Common.Models.Lager
{
    interface IFirmenViewModel
    {
        int ID { get; set; }
        string Name { get; set; }
        string Straße { get; set; }
        int Nr { get; set; }
        string Plz { get; set; }
        string Ort { get; set; }
        string Land { get; set; }
        string Kundennummer { get; set; }
        string Telefon { get; set; }
        string Telefon2 { get; set; }
        string Fax { get; set; }
        string EMail { get; set; }
        string Ansprechpartner { get; set; }
        string ATelefon { get; set; }
        string AMobil { get; set; }
        string AFax { get; set; }
        string AEMail { get; set; }
        bool Lieferung { get; set; }
        bool Vermietung { get; set; }
        bool Presse { get; set; }
        bool Inaktiv { get; set; }
        int SteuerNr { get; set; }
        string UstNr { get; set; }
        DateTime Stand { get; set; }
        int Bearbeiter { get; set; }
        string Bemerkung { get; set; }
    }
}