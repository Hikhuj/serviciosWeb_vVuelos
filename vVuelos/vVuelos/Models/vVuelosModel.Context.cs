﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace vVuelos.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class vVuelosEntities : DbContext
    {
        public vVuelosEntities()
            : base("name=vVuelosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<airline> airlines { get; set; }
        public virtual DbSet<airport_gates> airport_gates { get; set; }
        public virtual DbSet<card> cards { get; set; }
        public virtual DbSet<city> cities { get; set; }
        public virtual DbSet<consecutive> consecutives { get; set; }
        public virtual DbSet<country> countries { get; set; }
        public virtual DbSet<error> errors { get; set; }
        public virtual DbSet<flight_tickets> flight_tickets { get; set; }
        public virtual DbSet<flight> flights { get; set; }
        public virtual DbSet<log_book> log_book { get; set; }
        public virtual DbSet<reservation> reservations { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<transaction> transactions { get; set; }
        public virtual DbSet<user> users { get; set; }
    
        public virtual int sp_add_airline(string nAME, string cOUNTRY, string iMAGE, Nullable<bool> sTATUS)
        {
            var nAMEParameter = nAME != null ?
                new ObjectParameter("NAME", nAME) :
                new ObjectParameter("NAME", typeof(string));
    
            var cOUNTRYParameter = cOUNTRY != null ?
                new ObjectParameter("COUNTRY", cOUNTRY) :
                new ObjectParameter("COUNTRY", typeof(string));
    
            var iMAGEParameter = iMAGE != null ?
                new ObjectParameter("IMAGE", iMAGE) :
                new ObjectParameter("IMAGE", typeof(string));
    
            var sTATUSParameter = sTATUS.HasValue ?
                new ObjectParameter("STATUS", sTATUS) :
                new ObjectParameter("STATUS", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_add_airline", nAMEParameter, cOUNTRYParameter, iMAGEParameter, sTATUSParameter);
        }
    
        public virtual int sp_add_country(string nAME, string iMAGE)
        {
            var nAMEParameter = nAME != null ?
                new ObjectParameter("NAME", nAME) :
                new ObjectParameter("NAME", typeof(string));
    
            var iMAGEParameter = iMAGE != null ?
                new ObjectParameter("IMAGE", iMAGE) :
                new ObjectParameter("IMAGE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_add_country", nAMEParameter, iMAGEParameter);
        }
    
        public virtual int sp_add_fligths(string cODE, string aIRLINE_ID, Nullable<int> cITY_ID, Nullable<System.DateTime> aRRIVAL_DATE, Nullable<System.TimeSpan> aRRIVAL_TIME, string aIRPORT_GATE_ID, string sTATUS, Nullable<bool> oNFLIGHT)
        {
            var cODEParameter = cODE != null ?
                new ObjectParameter("CODE", cODE) :
                new ObjectParameter("CODE", typeof(string));
    
            var aIRLINE_IDParameter = aIRLINE_ID != null ?
                new ObjectParameter("AIRLINE_ID", aIRLINE_ID) :
                new ObjectParameter("AIRLINE_ID", typeof(string));
    
            var cITY_IDParameter = cITY_ID.HasValue ?
                new ObjectParameter("CITY_ID", cITY_ID) :
                new ObjectParameter("CITY_ID", typeof(int));
    
            var aRRIVAL_DATEParameter = aRRIVAL_DATE.HasValue ?
                new ObjectParameter("ARRIVAL_DATE", aRRIVAL_DATE) :
                new ObjectParameter("ARRIVAL_DATE", typeof(System.DateTime));
    
            var aRRIVAL_TIMEParameter = aRRIVAL_TIME.HasValue ?
                new ObjectParameter("ARRIVAL_TIME", aRRIVAL_TIME) :
                new ObjectParameter("ARRIVAL_TIME", typeof(System.TimeSpan));
    
            var aIRPORT_GATE_IDParameter = aIRPORT_GATE_ID != null ?
                new ObjectParameter("AIRPORT_GATE_ID", aIRPORT_GATE_ID) :
                new ObjectParameter("AIRPORT_GATE_ID", typeof(string));
    
            var sTATUSParameter = sTATUS != null ?
                new ObjectParameter("STATUS", sTATUS) :
                new ObjectParameter("STATUS", typeof(string));
    
            var oNFLIGHTParameter = oNFLIGHT.HasValue ?
                new ObjectParameter("ONFLIGHT", oNFLIGHT) :
                new ObjectParameter("ONFLIGHT", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_add_fligths", cODEParameter, aIRLINE_IDParameter, cITY_IDParameter, aRRIVAL_DATEParameter, aRRIVAL_TIMEParameter, aIRPORT_GATE_IDParameter, sTATUSParameter, oNFLIGHTParameter);
        }
    
        public virtual int sp_add_gates(Nullable<int> nUMBER, Nullable<bool> sTATUS)
        {
            var nUMBERParameter = nUMBER.HasValue ?
                new ObjectParameter("NUMBER", nUMBER) :
                new ObjectParameter("NUMBER", typeof(int));
    
            var sTATUSParameter = sTATUS.HasValue ?
                new ObjectParameter("STATUS", sTATUS) :
                new ObjectParameter("STATUS", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_add_gates", nUMBERParameter, sTATUSParameter);
        }
    
        public virtual int sp_add_reservations(Nullable<int> uSERID, string bOOKING_ID, Nullable<int> aMOUNT, Nullable<int> tOTAL, Nullable<System.DateTime> aLERT)
        {
            var uSERIDParameter = uSERID.HasValue ?
                new ObjectParameter("USERID", uSERID) :
                new ObjectParameter("USERID", typeof(int));
    
            var bOOKING_IDParameter = bOOKING_ID != null ?
                new ObjectParameter("BOOKING_ID", bOOKING_ID) :
                new ObjectParameter("BOOKING_ID", typeof(string));
    
            var aMOUNTParameter = aMOUNT.HasValue ?
                new ObjectParameter("AMOUNT", aMOUNT) :
                new ObjectParameter("AMOUNT", typeof(int));
    
            var tOTALParameter = tOTAL.HasValue ?
                new ObjectParameter("TOTAL", tOTAL) :
                new ObjectParameter("TOTAL", typeof(int));
    
            var aLERTParameter = aLERT.HasValue ?
                new ObjectParameter("ALERT", aLERT) :
                new ObjectParameter("ALERT", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_add_reservations", uSERIDParameter, bOOKING_IDParameter, aMOUNTParameter, tOTALParameter, aLERTParameter);
        }
    
        public virtual int sp_add_tickets(Nullable<int> uSERID, string cONSECUTIVE_COUNTRY)
        {
            var uSERIDParameter = uSERID.HasValue ?
                new ObjectParameter("USERID", uSERID) :
                new ObjectParameter("USERID", typeof(int));
    
            var cONSECUTIVE_COUNTRYParameter = cONSECUTIVE_COUNTRY != null ?
                new ObjectParameter("CONSECUTIVE_COUNTRY", cONSECUTIVE_COUNTRY) :
                new ObjectParameter("CONSECUTIVE_COUNTRY", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_add_tickets", uSERIDParameter, cONSECUTIVE_COUNTRYParameter);
        }
    
        public virtual int sp_add_user(string uSERNAME, string eMAIL, string pASSWORD, string nAME, string mIDDLE_NAME, string lAST_NAME, string sECOND_LAST, string sECURITY_Q, string cOUNTRY, string aNSWER)
        {
            var uSERNAMEParameter = uSERNAME != null ?
                new ObjectParameter("USERNAME", uSERNAME) :
                new ObjectParameter("USERNAME", typeof(string));
    
            var eMAILParameter = eMAIL != null ?
                new ObjectParameter("EMAIL", eMAIL) :
                new ObjectParameter("EMAIL", typeof(string));
    
            var pASSWORDParameter = pASSWORD != null ?
                new ObjectParameter("PASSWORD", pASSWORD) :
                new ObjectParameter("PASSWORD", typeof(string));
    
            var nAMEParameter = nAME != null ?
                new ObjectParameter("NAME", nAME) :
                new ObjectParameter("NAME", typeof(string));
    
            var mIDDLE_NAMEParameter = mIDDLE_NAME != null ?
                new ObjectParameter("MIDDLE_NAME", mIDDLE_NAME) :
                new ObjectParameter("MIDDLE_NAME", typeof(string));
    
            var lAST_NAMEParameter = lAST_NAME != null ?
                new ObjectParameter("LAST_NAME", lAST_NAME) :
                new ObjectParameter("LAST_NAME", typeof(string));
    
            var sECOND_LASTParameter = sECOND_LAST != null ?
                new ObjectParameter("SECOND_LAST", sECOND_LAST) :
                new ObjectParameter("SECOND_LAST", typeof(string));
    
            var sECURITY_QParameter = sECURITY_Q != null ?
                new ObjectParameter("SECURITY_Q", sECURITY_Q) :
                new ObjectParameter("SECURITY_Q", typeof(string));
    
            var cOUNTRYParameter = cOUNTRY != null ?
                new ObjectParameter("COUNTRY", cOUNTRY) :
                new ObjectParameter("COUNTRY", typeof(string));
    
            var aNSWERParameter = aNSWER != null ?
                new ObjectParameter("ANSWER", aNSWER) :
                new ObjectParameter("ANSWER", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_add_user", uSERNAMEParameter, eMAILParameter, pASSWORDParameter, nAMEParameter, mIDDLE_NAMEParameter, lAST_NAMEParameter, sECOND_LASTParameter, sECURITY_QParameter, cOUNTRYParameter, aNSWERParameter);
        }
    
        public virtual int sp_add_wallet()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_add_wallet");
        }
    
        public virtual int sp_change_pw()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_change_pw");
        }
    
        public virtual int sp_create_consecutive(string dESCRIPTION, Nullable<int> vALUE, string pREFIX, Nullable<int> rANGEINT, Nullable<int> rANGEOUT)
        {
            var dESCRIPTIONParameter = dESCRIPTION != null ?
                new ObjectParameter("DESCRIPTION", dESCRIPTION) :
                new ObjectParameter("DESCRIPTION", typeof(string));
    
            var vALUEParameter = vALUE.HasValue ?
                new ObjectParameter("VALUE", vALUE) :
                new ObjectParameter("VALUE", typeof(int));
    
            var pREFIXParameter = pREFIX != null ?
                new ObjectParameter("PREFIX", pREFIX) :
                new ObjectParameter("PREFIX", typeof(string));
    
            var rANGEINTParameter = rANGEINT.HasValue ?
                new ObjectParameter("RANGEINT", rANGEINT) :
                new ObjectParameter("RANGEINT", typeof(int));
    
            var rANGEOUTParameter = rANGEOUT.HasValue ?
                new ObjectParameter("RANGEOUT", rANGEOUT) :
                new ObjectParameter("RANGEOUT", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_create_consecutive", dESCRIPTIONParameter, vALUEParameter, pREFIXParameter, rANGEINTParameter, rANGEOUTParameter);
        }
    
        public virtual int sp_login_user()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_login_user");
        }
    
        public virtual int sp_remove_wallet()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_remove_wallet");
        }
    
        public virtual int sp_update_airline(string iD, string nAME, string cOUNTRY, string iMAGE, Nullable<bool> sTATUS)
        {
            var iDParameter = iD != null ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(string));
    
            var nAMEParameter = nAME != null ?
                new ObjectParameter("NAME", nAME) :
                new ObjectParameter("NAME", typeof(string));
    
            var cOUNTRYParameter = cOUNTRY != null ?
                new ObjectParameter("COUNTRY", cOUNTRY) :
                new ObjectParameter("COUNTRY", typeof(string));
    
            var iMAGEParameter = iMAGE != null ?
                new ObjectParameter("IMAGE", iMAGE) :
                new ObjectParameter("IMAGE", typeof(string));
    
            var sTATUSParameter = sTATUS.HasValue ?
                new ObjectParameter("STATUS", sTATUS) :
                new ObjectParameter("STATUS", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_update_airline", iDParameter, nAMEParameter, cOUNTRYParameter, iMAGEParameter, sTATUSParameter);
        }
    
        public virtual int sp_update_consecutive(Nullable<int> iD, string dESCRIPTION, Nullable<int> vALUE, string pREFIX, Nullable<int> rANGEINT, Nullable<int> rANGEOUT)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var dESCRIPTIONParameter = dESCRIPTION != null ?
                new ObjectParameter("DESCRIPTION", dESCRIPTION) :
                new ObjectParameter("DESCRIPTION", typeof(string));
    
            var vALUEParameter = vALUE.HasValue ?
                new ObjectParameter("VALUE", vALUE) :
                new ObjectParameter("VALUE", typeof(int));
    
            var pREFIXParameter = pREFIX != null ?
                new ObjectParameter("PREFIX", pREFIX) :
                new ObjectParameter("PREFIX", typeof(string));
    
            var rANGEINTParameter = rANGEINT.HasValue ?
                new ObjectParameter("RANGEINT", rANGEINT) :
                new ObjectParameter("RANGEINT", typeof(int));
    
            var rANGEOUTParameter = rANGEOUT.HasValue ?
                new ObjectParameter("RANGEOUT", rANGEOUT) :
                new ObjectParameter("RANGEOUT", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_update_consecutive", iDParameter, dESCRIPTIONParameter, vALUEParameter, pREFIXParameter, rANGEINTParameter, rANGEOUTParameter);
        }
    
        public virtual int sp_update_country(string cONSECUTIVE_ID, string nAME, string iMAGE)
        {
            var cONSECUTIVE_IDParameter = cONSECUTIVE_ID != null ?
                new ObjectParameter("CONSECUTIVE_ID", cONSECUTIVE_ID) :
                new ObjectParameter("CONSECUTIVE_ID", typeof(string));
    
            var nAMEParameter = nAME != null ?
                new ObjectParameter("NAME", nAME) :
                new ObjectParameter("NAME", typeof(string));
    
            var iMAGEParameter = iMAGE != null ?
                new ObjectParameter("IMAGE", iMAGE) :
                new ObjectParameter("IMAGE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_update_country", cONSECUTIVE_IDParameter, nAMEParameter, iMAGEParameter);
        }
    
        public virtual int sp_update_gate(string iD, Nullable<int> nUMBER, Nullable<bool> sTATUS)
        {
            var iDParameter = iD != null ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(string));
    
            var nUMBERParameter = nUMBER.HasValue ?
                new ObjectParameter("NUMBER", nUMBER) :
                new ObjectParameter("NUMBER", typeof(int));
    
            var sTATUSParameter = sTATUS.HasValue ?
                new ObjectParameter("STATUS", sTATUS) :
                new ObjectParameter("STATUS", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_update_gate", iDParameter, nUMBERParameter, sTATUSParameter);
        }
    
        public virtual int sp_update_password(Nullable<int> userid, string old_password, string new_password)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var old_passwordParameter = old_password != null ?
                new ObjectParameter("old_password", old_password) :
                new ObjectParameter("old_password", typeof(string));
    
            var new_passwordParameter = new_password != null ?
                new ObjectParameter("new_password", new_password) :
                new ObjectParameter("new_password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_update_password", useridParameter, old_passwordParameter, new_passwordParameter);
        }
    
        public virtual int sp_update_reservation(string iD, Nullable<int> uSERID, string bOOKING_ID, Nullable<int> aMOUNT, Nullable<int> tOTAL, Nullable<System.DateTime> aLERT)
        {
            var iDParameter = iD != null ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(string));
    
            var uSERIDParameter = uSERID.HasValue ?
                new ObjectParameter("USERID", uSERID) :
                new ObjectParameter("USERID", typeof(int));
    
            var bOOKING_IDParameter = bOOKING_ID != null ?
                new ObjectParameter("BOOKING_ID", bOOKING_ID) :
                new ObjectParameter("BOOKING_ID", typeof(string));
    
            var aMOUNTParameter = aMOUNT.HasValue ?
                new ObjectParameter("AMOUNT", aMOUNT) :
                new ObjectParameter("AMOUNT", typeof(int));
    
            var tOTALParameter = tOTAL.HasValue ?
                new ObjectParameter("TOTAL", tOTAL) :
                new ObjectParameter("TOTAL", typeof(int));
    
            var aLERTParameter = aLERT.HasValue ?
                new ObjectParameter("ALERT", aLERT) :
                new ObjectParameter("ALERT", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_update_reservation", iDParameter, uSERIDParameter, bOOKING_IDParameter, aMOUNTParameter, tOTALParameter, aLERTParameter);
        }
    
        public virtual int sp_update_tickets(string iD, Nullable<int> uSERID, string cONSECUTIVE_COUNTRY)
        {
            var iDParameter = iD != null ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(string));
    
            var uSERIDParameter = uSERID.HasValue ?
                new ObjectParameter("USERID", uSERID) :
                new ObjectParameter("USERID", typeof(int));
    
            var cONSECUTIVE_COUNTRYParameter = cONSECUTIVE_COUNTRY != null ?
                new ObjectParameter("CONSECUTIVE_COUNTRY", cONSECUTIVE_COUNTRY) :
                new ObjectParameter("CONSECUTIVE_COUNTRY", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_update_tickets", iDParameter, uSERIDParameter, cONSECUTIVE_COUNTRYParameter);
        }
    
        public virtual int sp_update_user_information(Nullable<int> userid, string username, string email, string firstname, string middle, string lastname, string secondlast)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var firstnameParameter = firstname != null ?
                new ObjectParameter("firstname", firstname) :
                new ObjectParameter("firstname", typeof(string));
    
            var middleParameter = middle != null ?
                new ObjectParameter("middle", middle) :
                new ObjectParameter("middle", typeof(string));
    
            var lastnameParameter = lastname != null ?
                new ObjectParameter("lastname", lastname) :
                new ObjectParameter("lastname", typeof(string));
    
            var secondlastParameter = secondlast != null ?
                new ObjectParameter("secondlast", secondlast) :
                new ObjectParameter("secondlast", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_update_user_information", useridParameter, usernameParameter, emailParameter, firstnameParameter, middleParameter, lastnameParameter, secondlastParameter);
        }
    
        public virtual int sp_update_wallet()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_update_wallet");
        }
    
        public virtual int usp_GetErrorInfo()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_GetErrorInfo");
        }
    }
}
