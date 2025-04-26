using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "Empleado" )]
   [XmlType(TypeName =  "Empleado" , Namespace = "parques" )]
   [Serializable]
   public class SdtEmpleado : GxSilentTrnSdt
   {
      public SdtEmpleado( )
      {
      }

      public SdtEmpleado( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( short AV1EmpleadoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV1EmpleadoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"EmpleadoId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Empleado");
         metadata.Set("BT", "Empleado");
         metadata.Set("PK", "[ \"EmpleadoId\" ]");
         metadata.Set("PKAssigned", "[ \"EmpleadoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"parqueAtraccionId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Empleadoid_Z");
         state.Add("gxTpr_Empleadonombre_Z");
         state.Add("gxTpr_Empleadoapellido_Z");
         state.Add("gxTpr_Empleadodireccion_Z");
         state.Add("gxTpr_Empleadotelefono_Z");
         state.Add("gxTpr_Empleadoemail_Z");
         state.Add("gxTpr_Empleadofch_alta_Z_Nullable");
         state.Add("gxTpr_Empleadofcha_mod_Z_Nullable");
         state.Add("gxTpr_Empleadofch_cad_Z_Nullable");
         state.Add("gxTpr_Empleadousu_alta_Z");
         state.Add("gxTpr_Empleadousu_mod_Z");
         state.Add("gxTpr_Empleadouso_cad_Z");
         state.Add("gxTpr_Parqueatraccionid_Z");
         state.Add("gxTpr_Parqueatraccionnombre_Z");
         state.Add("gxTpr_Empleadodireccion_N");
         state.Add("gxTpr_Empleadotelefono_N");
         state.Add("gxTpr_Empleadoemail_N");
         state.Add("gxTpr_Empleadofch_alta_N");
         state.Add("gxTpr_Empleadofcha_mod_N");
         state.Add("gxTpr_Empleadofch_cad_N");
         state.Add("gxTpr_Empleadousu_alta_N");
         state.Add("gxTpr_Empleadousu_mod_N");
         state.Add("gxTpr_Empleadouso_cad_N");
         state.Add("gxTpr_Parqueatraccionid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtEmpleado sdt;
         sdt = (SdtEmpleado)(source);
         gxTv_SdtEmpleado_Empleadoid = sdt.gxTv_SdtEmpleado_Empleadoid ;
         gxTv_SdtEmpleado_Empleadonombre = sdt.gxTv_SdtEmpleado_Empleadonombre ;
         gxTv_SdtEmpleado_Empleadoapellido = sdt.gxTv_SdtEmpleado_Empleadoapellido ;
         gxTv_SdtEmpleado_Empleadodireccion = sdt.gxTv_SdtEmpleado_Empleadodireccion ;
         gxTv_SdtEmpleado_Empleadotelefono = sdt.gxTv_SdtEmpleado_Empleadotelefono ;
         gxTv_SdtEmpleado_Empleadoemail = sdt.gxTv_SdtEmpleado_Empleadoemail ;
         gxTv_SdtEmpleado_Empleadofch_alta = sdt.gxTv_SdtEmpleado_Empleadofch_alta ;
         gxTv_SdtEmpleado_Empleadofcha_mod = sdt.gxTv_SdtEmpleado_Empleadofcha_mod ;
         gxTv_SdtEmpleado_Empleadofch_cad = sdt.gxTv_SdtEmpleado_Empleadofch_cad ;
         gxTv_SdtEmpleado_Empleadousu_alta = sdt.gxTv_SdtEmpleado_Empleadousu_alta ;
         gxTv_SdtEmpleado_Empleadousu_mod = sdt.gxTv_SdtEmpleado_Empleadousu_mod ;
         gxTv_SdtEmpleado_Empleadouso_cad = sdt.gxTv_SdtEmpleado_Empleadouso_cad ;
         gxTv_SdtEmpleado_Parqueatraccionid = sdt.gxTv_SdtEmpleado_Parqueatraccionid ;
         gxTv_SdtEmpleado_Parqueatraccionnombre = sdt.gxTv_SdtEmpleado_Parqueatraccionnombre ;
         gxTv_SdtEmpleado_Mode = sdt.gxTv_SdtEmpleado_Mode ;
         gxTv_SdtEmpleado_Initialized = sdt.gxTv_SdtEmpleado_Initialized ;
         gxTv_SdtEmpleado_Empleadoid_Z = sdt.gxTv_SdtEmpleado_Empleadoid_Z ;
         gxTv_SdtEmpleado_Empleadonombre_Z = sdt.gxTv_SdtEmpleado_Empleadonombre_Z ;
         gxTv_SdtEmpleado_Empleadoapellido_Z = sdt.gxTv_SdtEmpleado_Empleadoapellido_Z ;
         gxTv_SdtEmpleado_Empleadodireccion_Z = sdt.gxTv_SdtEmpleado_Empleadodireccion_Z ;
         gxTv_SdtEmpleado_Empleadotelefono_Z = sdt.gxTv_SdtEmpleado_Empleadotelefono_Z ;
         gxTv_SdtEmpleado_Empleadoemail_Z = sdt.gxTv_SdtEmpleado_Empleadoemail_Z ;
         gxTv_SdtEmpleado_Empleadofch_alta_Z = sdt.gxTv_SdtEmpleado_Empleadofch_alta_Z ;
         gxTv_SdtEmpleado_Empleadofcha_mod_Z = sdt.gxTv_SdtEmpleado_Empleadofcha_mod_Z ;
         gxTv_SdtEmpleado_Empleadofch_cad_Z = sdt.gxTv_SdtEmpleado_Empleadofch_cad_Z ;
         gxTv_SdtEmpleado_Empleadousu_alta_Z = sdt.gxTv_SdtEmpleado_Empleadousu_alta_Z ;
         gxTv_SdtEmpleado_Empleadousu_mod_Z = sdt.gxTv_SdtEmpleado_Empleadousu_mod_Z ;
         gxTv_SdtEmpleado_Empleadouso_cad_Z = sdt.gxTv_SdtEmpleado_Empleadouso_cad_Z ;
         gxTv_SdtEmpleado_Parqueatraccionid_Z = sdt.gxTv_SdtEmpleado_Parqueatraccionid_Z ;
         gxTv_SdtEmpleado_Parqueatraccionnombre_Z = sdt.gxTv_SdtEmpleado_Parqueatraccionnombre_Z ;
         gxTv_SdtEmpleado_Empleadodireccion_N = sdt.gxTv_SdtEmpleado_Empleadodireccion_N ;
         gxTv_SdtEmpleado_Empleadotelefono_N = sdt.gxTv_SdtEmpleado_Empleadotelefono_N ;
         gxTv_SdtEmpleado_Empleadoemail_N = sdt.gxTv_SdtEmpleado_Empleadoemail_N ;
         gxTv_SdtEmpleado_Empleadofch_alta_N = sdt.gxTv_SdtEmpleado_Empleadofch_alta_N ;
         gxTv_SdtEmpleado_Empleadofcha_mod_N = sdt.gxTv_SdtEmpleado_Empleadofcha_mod_N ;
         gxTv_SdtEmpleado_Empleadofch_cad_N = sdt.gxTv_SdtEmpleado_Empleadofch_cad_N ;
         gxTv_SdtEmpleado_Empleadousu_alta_N = sdt.gxTv_SdtEmpleado_Empleadousu_alta_N ;
         gxTv_SdtEmpleado_Empleadousu_mod_N = sdt.gxTv_SdtEmpleado_Empleadousu_mod_N ;
         gxTv_SdtEmpleado_Empleadouso_cad_N = sdt.gxTv_SdtEmpleado_Empleadouso_cad_N ;
         gxTv_SdtEmpleado_Parqueatraccionid_N = sdt.gxTv_SdtEmpleado_Parqueatraccionid_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("EmpleadoId", gxTv_SdtEmpleado_Empleadoid, false, includeNonInitialized);
         AddObjectProperty("EmpleadoNombre", gxTv_SdtEmpleado_Empleadonombre, false, includeNonInitialized);
         AddObjectProperty("EmpleadoApellido", gxTv_SdtEmpleado_Empleadoapellido, false, includeNonInitialized);
         AddObjectProperty("EmpleadoDireccion", gxTv_SdtEmpleado_Empleadodireccion, false, includeNonInitialized);
         AddObjectProperty("EmpleadoDireccion_N", gxTv_SdtEmpleado_Empleadodireccion_N, false, includeNonInitialized);
         AddObjectProperty("EmpleadoTelefono", gxTv_SdtEmpleado_Empleadotelefono, false, includeNonInitialized);
         AddObjectProperty("EmpleadoTelefono_N", gxTv_SdtEmpleado_Empleadotelefono_N, false, includeNonInitialized);
         AddObjectProperty("EmpleadoEmail", gxTv_SdtEmpleado_Empleadoemail, false, includeNonInitialized);
         AddObjectProperty("EmpleadoEmail_N", gxTv_SdtEmpleado_Empleadoemail_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtEmpleado_Empleadofch_alta;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("EmpleadoFch_Alta", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("EmpleadoFch_Alta_N", gxTv_SdtEmpleado_Empleadofch_alta_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtEmpleado_Empleadofcha_mod;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("EmpleadoFcha_Mod", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("EmpleadoFcha_Mod_N", gxTv_SdtEmpleado_Empleadofcha_mod_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtEmpleado_Empleadofch_cad;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("EmpleadoFch_Cad", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("EmpleadoFch_Cad_N", gxTv_SdtEmpleado_Empleadofch_cad_N, false, includeNonInitialized);
         AddObjectProperty("EmpleadoUsu_Alta", gxTv_SdtEmpleado_Empleadousu_alta, false, includeNonInitialized);
         AddObjectProperty("EmpleadoUsu_Alta_N", gxTv_SdtEmpleado_Empleadousu_alta_N, false, includeNonInitialized);
         AddObjectProperty("EmpleadoUsu_Mod", gxTv_SdtEmpleado_Empleadousu_mod, false, includeNonInitialized);
         AddObjectProperty("EmpleadoUsu_Mod_N", gxTv_SdtEmpleado_Empleadousu_mod_N, false, includeNonInitialized);
         AddObjectProperty("EmpleadoUso_Cad", gxTv_SdtEmpleado_Empleadouso_cad, false, includeNonInitialized);
         AddObjectProperty("EmpleadoUso_Cad_N", gxTv_SdtEmpleado_Empleadouso_cad_N, false, includeNonInitialized);
         AddObjectProperty("parqueAtraccionId", gxTv_SdtEmpleado_Parqueatraccionid, false, includeNonInitialized);
         AddObjectProperty("parqueAtraccionId_N", gxTv_SdtEmpleado_Parqueatraccionid_N, false, includeNonInitialized);
         AddObjectProperty("parqueAtraccionNombre", gxTv_SdtEmpleado_Parqueatraccionnombre, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtEmpleado_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtEmpleado_Initialized, false, includeNonInitialized);
            AddObjectProperty("EmpleadoId_Z", gxTv_SdtEmpleado_Empleadoid_Z, false, includeNonInitialized);
            AddObjectProperty("EmpleadoNombre_Z", gxTv_SdtEmpleado_Empleadonombre_Z, false, includeNonInitialized);
            AddObjectProperty("EmpleadoApellido_Z", gxTv_SdtEmpleado_Empleadoapellido_Z, false, includeNonInitialized);
            AddObjectProperty("EmpleadoDireccion_Z", gxTv_SdtEmpleado_Empleadodireccion_Z, false, includeNonInitialized);
            AddObjectProperty("EmpleadoTelefono_Z", gxTv_SdtEmpleado_Empleadotelefono_Z, false, includeNonInitialized);
            AddObjectProperty("EmpleadoEmail_Z", gxTv_SdtEmpleado_Empleadoemail_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtEmpleado_Empleadofch_alta_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("EmpleadoFch_Alta_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtEmpleado_Empleadofcha_mod_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("EmpleadoFcha_Mod_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtEmpleado_Empleadofch_cad_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("EmpleadoFch_Cad_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("EmpleadoUsu_Alta_Z", gxTv_SdtEmpleado_Empleadousu_alta_Z, false, includeNonInitialized);
            AddObjectProperty("EmpleadoUsu_Mod_Z", gxTv_SdtEmpleado_Empleadousu_mod_Z, false, includeNonInitialized);
            AddObjectProperty("EmpleadoUso_Cad_Z", gxTv_SdtEmpleado_Empleadouso_cad_Z, false, includeNonInitialized);
            AddObjectProperty("parqueAtraccionId_Z", gxTv_SdtEmpleado_Parqueatraccionid_Z, false, includeNonInitialized);
            AddObjectProperty("parqueAtraccionNombre_Z", gxTv_SdtEmpleado_Parqueatraccionnombre_Z, false, includeNonInitialized);
            AddObjectProperty("EmpleadoDireccion_N", gxTv_SdtEmpleado_Empleadodireccion_N, false, includeNonInitialized);
            AddObjectProperty("EmpleadoTelefono_N", gxTv_SdtEmpleado_Empleadotelefono_N, false, includeNonInitialized);
            AddObjectProperty("EmpleadoEmail_N", gxTv_SdtEmpleado_Empleadoemail_N, false, includeNonInitialized);
            AddObjectProperty("EmpleadoFch_Alta_N", gxTv_SdtEmpleado_Empleadofch_alta_N, false, includeNonInitialized);
            AddObjectProperty("EmpleadoFcha_Mod_N", gxTv_SdtEmpleado_Empleadofcha_mod_N, false, includeNonInitialized);
            AddObjectProperty("EmpleadoFch_Cad_N", gxTv_SdtEmpleado_Empleadofch_cad_N, false, includeNonInitialized);
            AddObjectProperty("EmpleadoUsu_Alta_N", gxTv_SdtEmpleado_Empleadousu_alta_N, false, includeNonInitialized);
            AddObjectProperty("EmpleadoUsu_Mod_N", gxTv_SdtEmpleado_Empleadousu_mod_N, false, includeNonInitialized);
            AddObjectProperty("EmpleadoUso_Cad_N", gxTv_SdtEmpleado_Empleadouso_cad_N, false, includeNonInitialized);
            AddObjectProperty("parqueAtraccionId_N", gxTv_SdtEmpleado_Parqueatraccionid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtEmpleado sdt )
      {
         if ( sdt.IsDirty("EmpleadoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadoid = sdt.gxTv_SdtEmpleado_Empleadoid ;
         }
         if ( sdt.IsDirty("EmpleadoNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadonombre = sdt.gxTv_SdtEmpleado_Empleadonombre ;
         }
         if ( sdt.IsDirty("EmpleadoApellido") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadoapellido = sdt.gxTv_SdtEmpleado_Empleadoapellido ;
         }
         if ( sdt.IsDirty("EmpleadoDireccion") )
         {
            gxTv_SdtEmpleado_Empleadodireccion_N = (short)(sdt.gxTv_SdtEmpleado_Empleadodireccion_N);
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadodireccion = sdt.gxTv_SdtEmpleado_Empleadodireccion ;
         }
         if ( sdt.IsDirty("EmpleadoTelefono") )
         {
            gxTv_SdtEmpleado_Empleadotelefono_N = (short)(sdt.gxTv_SdtEmpleado_Empleadotelefono_N);
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadotelefono = sdt.gxTv_SdtEmpleado_Empleadotelefono ;
         }
         if ( sdt.IsDirty("EmpleadoEmail") )
         {
            gxTv_SdtEmpleado_Empleadoemail_N = (short)(sdt.gxTv_SdtEmpleado_Empleadoemail_N);
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadoemail = sdt.gxTv_SdtEmpleado_Empleadoemail ;
         }
         if ( sdt.IsDirty("EmpleadoFch_Alta") )
         {
            gxTv_SdtEmpleado_Empleadofch_alta_N = (short)(sdt.gxTv_SdtEmpleado_Empleadofch_alta_N);
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadofch_alta = sdt.gxTv_SdtEmpleado_Empleadofch_alta ;
         }
         if ( sdt.IsDirty("EmpleadoFcha_Mod") )
         {
            gxTv_SdtEmpleado_Empleadofcha_mod_N = (short)(sdt.gxTv_SdtEmpleado_Empleadofcha_mod_N);
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadofcha_mod = sdt.gxTv_SdtEmpleado_Empleadofcha_mod ;
         }
         if ( sdt.IsDirty("EmpleadoFch_Cad") )
         {
            gxTv_SdtEmpleado_Empleadofch_cad_N = (short)(sdt.gxTv_SdtEmpleado_Empleadofch_cad_N);
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadofch_cad = sdt.gxTv_SdtEmpleado_Empleadofch_cad ;
         }
         if ( sdt.IsDirty("EmpleadoUsu_Alta") )
         {
            gxTv_SdtEmpleado_Empleadousu_alta_N = (short)(sdt.gxTv_SdtEmpleado_Empleadousu_alta_N);
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadousu_alta = sdt.gxTv_SdtEmpleado_Empleadousu_alta ;
         }
         if ( sdt.IsDirty("EmpleadoUsu_Mod") )
         {
            gxTv_SdtEmpleado_Empleadousu_mod_N = (short)(sdt.gxTv_SdtEmpleado_Empleadousu_mod_N);
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadousu_mod = sdt.gxTv_SdtEmpleado_Empleadousu_mod ;
         }
         if ( sdt.IsDirty("EmpleadoUso_Cad") )
         {
            gxTv_SdtEmpleado_Empleadouso_cad_N = (short)(sdt.gxTv_SdtEmpleado_Empleadouso_cad_N);
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadouso_cad = sdt.gxTv_SdtEmpleado_Empleadouso_cad ;
         }
         if ( sdt.IsDirty("parqueAtraccionId") )
         {
            gxTv_SdtEmpleado_Parqueatraccionid_N = (short)(sdt.gxTv_SdtEmpleado_Parqueatraccionid_N);
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Parqueatraccionid = sdt.gxTv_SdtEmpleado_Parqueatraccionid ;
         }
         if ( sdt.IsDirty("parqueAtraccionNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Parqueatraccionnombre = sdt.gxTv_SdtEmpleado_Parqueatraccionnombre ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "EmpleadoId" )]
      [  XmlElement( ElementName = "EmpleadoId"   )]
      public short gxTpr_Empleadoid
      {
         get {
            return gxTv_SdtEmpleado_Empleadoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtEmpleado_Empleadoid != value )
            {
               gxTv_SdtEmpleado_Mode = "INS";
               this.gxTv_SdtEmpleado_Empleadoid_Z_SetNull( );
               this.gxTv_SdtEmpleado_Empleadonombre_Z_SetNull( );
               this.gxTv_SdtEmpleado_Empleadoapellido_Z_SetNull( );
               this.gxTv_SdtEmpleado_Empleadodireccion_Z_SetNull( );
               this.gxTv_SdtEmpleado_Empleadotelefono_Z_SetNull( );
               this.gxTv_SdtEmpleado_Empleadoemail_Z_SetNull( );
               this.gxTv_SdtEmpleado_Empleadofch_alta_Z_SetNull( );
               this.gxTv_SdtEmpleado_Empleadofcha_mod_Z_SetNull( );
               this.gxTv_SdtEmpleado_Empleadofch_cad_Z_SetNull( );
               this.gxTv_SdtEmpleado_Empleadousu_alta_Z_SetNull( );
               this.gxTv_SdtEmpleado_Empleadousu_mod_Z_SetNull( );
               this.gxTv_SdtEmpleado_Empleadouso_cad_Z_SetNull( );
               this.gxTv_SdtEmpleado_Parqueatraccionid_Z_SetNull( );
               this.gxTv_SdtEmpleado_Parqueatraccionnombre_Z_SetNull( );
            }
            gxTv_SdtEmpleado_Empleadoid = value;
            SetDirty("Empleadoid");
         }

      }

      [  SoapElement( ElementName = "EmpleadoNombre" )]
      [  XmlElement( ElementName = "EmpleadoNombre"   )]
      public string gxTpr_Empleadonombre
      {
         get {
            return gxTv_SdtEmpleado_Empleadonombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadonombre = value;
            SetDirty("Empleadonombre");
         }

      }

      [  SoapElement( ElementName = "EmpleadoApellido" )]
      [  XmlElement( ElementName = "EmpleadoApellido"   )]
      public string gxTpr_Empleadoapellido
      {
         get {
            return gxTv_SdtEmpleado_Empleadoapellido ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadoapellido = value;
            SetDirty("Empleadoapellido");
         }

      }

      [  SoapElement( ElementName = "EmpleadoDireccion" )]
      [  XmlElement( ElementName = "EmpleadoDireccion"   )]
      public string gxTpr_Empleadodireccion
      {
         get {
            return gxTv_SdtEmpleado_Empleadodireccion ;
         }

         set {
            gxTv_SdtEmpleado_Empleadodireccion_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadodireccion = value;
            SetDirty("Empleadodireccion");
         }

      }

      public void gxTv_SdtEmpleado_Empleadodireccion_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadodireccion_N = 1;
         gxTv_SdtEmpleado_Empleadodireccion = "";
         SetDirty("Empleadodireccion");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadodireccion_IsNull( )
      {
         return (gxTv_SdtEmpleado_Empleadodireccion_N==1) ;
      }

      [  SoapElement( ElementName = "EmpleadoTelefono" )]
      [  XmlElement( ElementName = "EmpleadoTelefono"   )]
      public string gxTpr_Empleadotelefono
      {
         get {
            return gxTv_SdtEmpleado_Empleadotelefono ;
         }

         set {
            gxTv_SdtEmpleado_Empleadotelefono_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadotelefono = value;
            SetDirty("Empleadotelefono");
         }

      }

      public void gxTv_SdtEmpleado_Empleadotelefono_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadotelefono_N = 1;
         gxTv_SdtEmpleado_Empleadotelefono = "";
         SetDirty("Empleadotelefono");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadotelefono_IsNull( )
      {
         return (gxTv_SdtEmpleado_Empleadotelefono_N==1) ;
      }

      [  SoapElement( ElementName = "EmpleadoEmail" )]
      [  XmlElement( ElementName = "EmpleadoEmail"   )]
      public string gxTpr_Empleadoemail
      {
         get {
            return gxTv_SdtEmpleado_Empleadoemail ;
         }

         set {
            gxTv_SdtEmpleado_Empleadoemail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadoemail = value;
            SetDirty("Empleadoemail");
         }

      }

      public void gxTv_SdtEmpleado_Empleadoemail_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadoemail_N = 1;
         gxTv_SdtEmpleado_Empleadoemail = "";
         SetDirty("Empleadoemail");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadoemail_IsNull( )
      {
         return (gxTv_SdtEmpleado_Empleadoemail_N==1) ;
      }

      [  SoapElement( ElementName = "EmpleadoFch_Alta" )]
      [  XmlElement( ElementName = "EmpleadoFch_Alta"  , IsNullable=true )]
      public string gxTpr_Empleadofch_alta_Nullable
      {
         get {
            if ( gxTv_SdtEmpleado_Empleadofch_alta == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtEmpleado_Empleadofch_alta).value ;
         }

         set {
            gxTv_SdtEmpleado_Empleadofch_alta_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtEmpleado_Empleadofch_alta = DateTime.MinValue;
            else
               gxTv_SdtEmpleado_Empleadofch_alta = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Empleadofch_alta
      {
         get {
            return gxTv_SdtEmpleado_Empleadofch_alta ;
         }

         set {
            gxTv_SdtEmpleado_Empleadofch_alta_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadofch_alta = value;
            SetDirty("Empleadofch_alta");
         }

      }

      public void gxTv_SdtEmpleado_Empleadofch_alta_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadofch_alta_N = 1;
         gxTv_SdtEmpleado_Empleadofch_alta = (DateTime)(DateTime.MinValue);
         SetDirty("Empleadofch_alta");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadofch_alta_IsNull( )
      {
         return (gxTv_SdtEmpleado_Empleadofch_alta_N==1) ;
      }

      [  SoapElement( ElementName = "EmpleadoFcha_Mod" )]
      [  XmlElement( ElementName = "EmpleadoFcha_Mod"  , IsNullable=true )]
      public string gxTpr_Empleadofcha_mod_Nullable
      {
         get {
            if ( gxTv_SdtEmpleado_Empleadofcha_mod == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtEmpleado_Empleadofcha_mod).value ;
         }

         set {
            gxTv_SdtEmpleado_Empleadofcha_mod_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtEmpleado_Empleadofcha_mod = DateTime.MinValue;
            else
               gxTv_SdtEmpleado_Empleadofcha_mod = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Empleadofcha_mod
      {
         get {
            return gxTv_SdtEmpleado_Empleadofcha_mod ;
         }

         set {
            gxTv_SdtEmpleado_Empleadofcha_mod_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadofcha_mod = value;
            SetDirty("Empleadofcha_mod");
         }

      }

      public void gxTv_SdtEmpleado_Empleadofcha_mod_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadofcha_mod_N = 1;
         gxTv_SdtEmpleado_Empleadofcha_mod = (DateTime)(DateTime.MinValue);
         SetDirty("Empleadofcha_mod");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadofcha_mod_IsNull( )
      {
         return (gxTv_SdtEmpleado_Empleadofcha_mod_N==1) ;
      }

      [  SoapElement( ElementName = "EmpleadoFch_Cad" )]
      [  XmlElement( ElementName = "EmpleadoFch_Cad"  , IsNullable=true )]
      public string gxTpr_Empleadofch_cad_Nullable
      {
         get {
            if ( gxTv_SdtEmpleado_Empleadofch_cad == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtEmpleado_Empleadofch_cad).value ;
         }

         set {
            gxTv_SdtEmpleado_Empleadofch_cad_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtEmpleado_Empleadofch_cad = DateTime.MinValue;
            else
               gxTv_SdtEmpleado_Empleadofch_cad = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Empleadofch_cad
      {
         get {
            return gxTv_SdtEmpleado_Empleadofch_cad ;
         }

         set {
            gxTv_SdtEmpleado_Empleadofch_cad_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadofch_cad = value;
            SetDirty("Empleadofch_cad");
         }

      }

      public void gxTv_SdtEmpleado_Empleadofch_cad_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadofch_cad_N = 1;
         gxTv_SdtEmpleado_Empleadofch_cad = (DateTime)(DateTime.MinValue);
         SetDirty("Empleadofch_cad");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadofch_cad_IsNull( )
      {
         return (gxTv_SdtEmpleado_Empleadofch_cad_N==1) ;
      }

      [  SoapElement( ElementName = "EmpleadoUsu_Alta" )]
      [  XmlElement( ElementName = "EmpleadoUsu_Alta"   )]
      public string gxTpr_Empleadousu_alta
      {
         get {
            return gxTv_SdtEmpleado_Empleadousu_alta ;
         }

         set {
            gxTv_SdtEmpleado_Empleadousu_alta_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadousu_alta = value;
            SetDirty("Empleadousu_alta");
         }

      }

      public void gxTv_SdtEmpleado_Empleadousu_alta_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadousu_alta_N = 1;
         gxTv_SdtEmpleado_Empleadousu_alta = "";
         SetDirty("Empleadousu_alta");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadousu_alta_IsNull( )
      {
         return (gxTv_SdtEmpleado_Empleadousu_alta_N==1) ;
      }

      [  SoapElement( ElementName = "EmpleadoUsu_Mod" )]
      [  XmlElement( ElementName = "EmpleadoUsu_Mod"   )]
      public string gxTpr_Empleadousu_mod
      {
         get {
            return gxTv_SdtEmpleado_Empleadousu_mod ;
         }

         set {
            gxTv_SdtEmpleado_Empleadousu_mod_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadousu_mod = value;
            SetDirty("Empleadousu_mod");
         }

      }

      public void gxTv_SdtEmpleado_Empleadousu_mod_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadousu_mod_N = 1;
         gxTv_SdtEmpleado_Empleadousu_mod = "";
         SetDirty("Empleadousu_mod");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadousu_mod_IsNull( )
      {
         return (gxTv_SdtEmpleado_Empleadousu_mod_N==1) ;
      }

      [  SoapElement( ElementName = "EmpleadoUso_Cad" )]
      [  XmlElement( ElementName = "EmpleadoUso_Cad"   )]
      public string gxTpr_Empleadouso_cad
      {
         get {
            return gxTv_SdtEmpleado_Empleadouso_cad ;
         }

         set {
            gxTv_SdtEmpleado_Empleadouso_cad_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadouso_cad = value;
            SetDirty("Empleadouso_cad");
         }

      }

      public void gxTv_SdtEmpleado_Empleadouso_cad_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadouso_cad_N = 1;
         gxTv_SdtEmpleado_Empleadouso_cad = "";
         SetDirty("Empleadouso_cad");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadouso_cad_IsNull( )
      {
         return (gxTv_SdtEmpleado_Empleadouso_cad_N==1) ;
      }

      [  SoapElement( ElementName = "parqueAtraccionId" )]
      [  XmlElement( ElementName = "parqueAtraccionId"   )]
      public short gxTpr_Parqueatraccionid
      {
         get {
            return gxTv_SdtEmpleado_Parqueatraccionid ;
         }

         set {
            gxTv_SdtEmpleado_Parqueatraccionid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Parqueatraccionid = value;
            SetDirty("Parqueatraccionid");
         }

      }

      public void gxTv_SdtEmpleado_Parqueatraccionid_SetNull( )
      {
         gxTv_SdtEmpleado_Parqueatraccionid_N = 1;
         gxTv_SdtEmpleado_Parqueatraccionid = 0;
         SetDirty("Parqueatraccionid");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Parqueatraccionid_IsNull( )
      {
         return (gxTv_SdtEmpleado_Parqueatraccionid_N==1) ;
      }

      [  SoapElement( ElementName = "parqueAtraccionNombre" )]
      [  XmlElement( ElementName = "parqueAtraccionNombre"   )]
      public string gxTpr_Parqueatraccionnombre
      {
         get {
            return gxTv_SdtEmpleado_Parqueatraccionnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Parqueatraccionnombre = value;
            SetDirty("Parqueatraccionnombre");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtEmpleado_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtEmpleado_Mode_SetNull( )
      {
         gxTv_SdtEmpleado_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtEmpleado_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtEmpleado_Initialized_SetNull( )
      {
         gxTv_SdtEmpleado_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpleadoId_Z" )]
      [  XmlElement( ElementName = "EmpleadoId_Z"   )]
      public short gxTpr_Empleadoid_Z
      {
         get {
            return gxTv_SdtEmpleado_Empleadoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadoid_Z = value;
            SetDirty("Empleadoid_Z");
         }

      }

      public void gxTv_SdtEmpleado_Empleadoid_Z_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadoid_Z = 0;
         SetDirty("Empleadoid_Z");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpleadoNombre_Z" )]
      [  XmlElement( ElementName = "EmpleadoNombre_Z"   )]
      public string gxTpr_Empleadonombre_Z
      {
         get {
            return gxTv_SdtEmpleado_Empleadonombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadonombre_Z = value;
            SetDirty("Empleadonombre_Z");
         }

      }

      public void gxTv_SdtEmpleado_Empleadonombre_Z_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadonombre_Z = "";
         SetDirty("Empleadonombre_Z");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadonombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpleadoApellido_Z" )]
      [  XmlElement( ElementName = "EmpleadoApellido_Z"   )]
      public string gxTpr_Empleadoapellido_Z
      {
         get {
            return gxTv_SdtEmpleado_Empleadoapellido_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadoapellido_Z = value;
            SetDirty("Empleadoapellido_Z");
         }

      }

      public void gxTv_SdtEmpleado_Empleadoapellido_Z_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadoapellido_Z = "";
         SetDirty("Empleadoapellido_Z");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadoapellido_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpleadoDireccion_Z" )]
      [  XmlElement( ElementName = "EmpleadoDireccion_Z"   )]
      public string gxTpr_Empleadodireccion_Z
      {
         get {
            return gxTv_SdtEmpleado_Empleadodireccion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadodireccion_Z = value;
            SetDirty("Empleadodireccion_Z");
         }

      }

      public void gxTv_SdtEmpleado_Empleadodireccion_Z_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadodireccion_Z = "";
         SetDirty("Empleadodireccion_Z");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadodireccion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpleadoTelefono_Z" )]
      [  XmlElement( ElementName = "EmpleadoTelefono_Z"   )]
      public string gxTpr_Empleadotelefono_Z
      {
         get {
            return gxTv_SdtEmpleado_Empleadotelefono_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadotelefono_Z = value;
            SetDirty("Empleadotelefono_Z");
         }

      }

      public void gxTv_SdtEmpleado_Empleadotelefono_Z_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadotelefono_Z = "";
         SetDirty("Empleadotelefono_Z");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadotelefono_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpleadoEmail_Z" )]
      [  XmlElement( ElementName = "EmpleadoEmail_Z"   )]
      public string gxTpr_Empleadoemail_Z
      {
         get {
            return gxTv_SdtEmpleado_Empleadoemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadoemail_Z = value;
            SetDirty("Empleadoemail_Z");
         }

      }

      public void gxTv_SdtEmpleado_Empleadoemail_Z_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadoemail_Z = "";
         SetDirty("Empleadoemail_Z");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadoemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpleadoFch_Alta_Z" )]
      [  XmlElement( ElementName = "EmpleadoFch_Alta_Z"  , IsNullable=true )]
      public string gxTpr_Empleadofch_alta_Z_Nullable
      {
         get {
            if ( gxTv_SdtEmpleado_Empleadofch_alta_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtEmpleado_Empleadofch_alta_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtEmpleado_Empleadofch_alta_Z = DateTime.MinValue;
            else
               gxTv_SdtEmpleado_Empleadofch_alta_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Empleadofch_alta_Z
      {
         get {
            return gxTv_SdtEmpleado_Empleadofch_alta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadofch_alta_Z = value;
            SetDirty("Empleadofch_alta_Z");
         }

      }

      public void gxTv_SdtEmpleado_Empleadofch_alta_Z_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadofch_alta_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Empleadofch_alta_Z");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadofch_alta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpleadoFcha_Mod_Z" )]
      [  XmlElement( ElementName = "EmpleadoFcha_Mod_Z"  , IsNullable=true )]
      public string gxTpr_Empleadofcha_mod_Z_Nullable
      {
         get {
            if ( gxTv_SdtEmpleado_Empleadofcha_mod_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtEmpleado_Empleadofcha_mod_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtEmpleado_Empleadofcha_mod_Z = DateTime.MinValue;
            else
               gxTv_SdtEmpleado_Empleadofcha_mod_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Empleadofcha_mod_Z
      {
         get {
            return gxTv_SdtEmpleado_Empleadofcha_mod_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadofcha_mod_Z = value;
            SetDirty("Empleadofcha_mod_Z");
         }

      }

      public void gxTv_SdtEmpleado_Empleadofcha_mod_Z_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadofcha_mod_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Empleadofcha_mod_Z");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadofcha_mod_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpleadoFch_Cad_Z" )]
      [  XmlElement( ElementName = "EmpleadoFch_Cad_Z"  , IsNullable=true )]
      public string gxTpr_Empleadofch_cad_Z_Nullable
      {
         get {
            if ( gxTv_SdtEmpleado_Empleadofch_cad_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtEmpleado_Empleadofch_cad_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtEmpleado_Empleadofch_cad_Z = DateTime.MinValue;
            else
               gxTv_SdtEmpleado_Empleadofch_cad_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Empleadofch_cad_Z
      {
         get {
            return gxTv_SdtEmpleado_Empleadofch_cad_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadofch_cad_Z = value;
            SetDirty("Empleadofch_cad_Z");
         }

      }

      public void gxTv_SdtEmpleado_Empleadofch_cad_Z_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadofch_cad_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Empleadofch_cad_Z");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadofch_cad_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpleadoUsu_Alta_Z" )]
      [  XmlElement( ElementName = "EmpleadoUsu_Alta_Z"   )]
      public string gxTpr_Empleadousu_alta_Z
      {
         get {
            return gxTv_SdtEmpleado_Empleadousu_alta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadousu_alta_Z = value;
            SetDirty("Empleadousu_alta_Z");
         }

      }

      public void gxTv_SdtEmpleado_Empleadousu_alta_Z_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadousu_alta_Z = "";
         SetDirty("Empleadousu_alta_Z");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadousu_alta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpleadoUsu_Mod_Z" )]
      [  XmlElement( ElementName = "EmpleadoUsu_Mod_Z"   )]
      public string gxTpr_Empleadousu_mod_Z
      {
         get {
            return gxTv_SdtEmpleado_Empleadousu_mod_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadousu_mod_Z = value;
            SetDirty("Empleadousu_mod_Z");
         }

      }

      public void gxTv_SdtEmpleado_Empleadousu_mod_Z_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadousu_mod_Z = "";
         SetDirty("Empleadousu_mod_Z");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadousu_mod_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpleadoUso_Cad_Z" )]
      [  XmlElement( ElementName = "EmpleadoUso_Cad_Z"   )]
      public string gxTpr_Empleadouso_cad_Z
      {
         get {
            return gxTv_SdtEmpleado_Empleadouso_cad_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadouso_cad_Z = value;
            SetDirty("Empleadouso_cad_Z");
         }

      }

      public void gxTv_SdtEmpleado_Empleadouso_cad_Z_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadouso_cad_Z = "";
         SetDirty("Empleadouso_cad_Z");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadouso_cad_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "parqueAtraccionId_Z" )]
      [  XmlElement( ElementName = "parqueAtraccionId_Z"   )]
      public short gxTpr_Parqueatraccionid_Z
      {
         get {
            return gxTv_SdtEmpleado_Parqueatraccionid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Parqueatraccionid_Z = value;
            SetDirty("Parqueatraccionid_Z");
         }

      }

      public void gxTv_SdtEmpleado_Parqueatraccionid_Z_SetNull( )
      {
         gxTv_SdtEmpleado_Parqueatraccionid_Z = 0;
         SetDirty("Parqueatraccionid_Z");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Parqueatraccionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "parqueAtraccionNombre_Z" )]
      [  XmlElement( ElementName = "parqueAtraccionNombre_Z"   )]
      public string gxTpr_Parqueatraccionnombre_Z
      {
         get {
            return gxTv_SdtEmpleado_Parqueatraccionnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Parqueatraccionnombre_Z = value;
            SetDirty("Parqueatraccionnombre_Z");
         }

      }

      public void gxTv_SdtEmpleado_Parqueatraccionnombre_Z_SetNull( )
      {
         gxTv_SdtEmpleado_Parqueatraccionnombre_Z = "";
         SetDirty("Parqueatraccionnombre_Z");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Parqueatraccionnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpleadoDireccion_N" )]
      [  XmlElement( ElementName = "EmpleadoDireccion_N"   )]
      public short gxTpr_Empleadodireccion_N
      {
         get {
            return gxTv_SdtEmpleado_Empleadodireccion_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadodireccion_N = value;
            SetDirty("Empleadodireccion_N");
         }

      }

      public void gxTv_SdtEmpleado_Empleadodireccion_N_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadodireccion_N = 0;
         SetDirty("Empleadodireccion_N");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadodireccion_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpleadoTelefono_N" )]
      [  XmlElement( ElementName = "EmpleadoTelefono_N"   )]
      public short gxTpr_Empleadotelefono_N
      {
         get {
            return gxTv_SdtEmpleado_Empleadotelefono_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadotelefono_N = value;
            SetDirty("Empleadotelefono_N");
         }

      }

      public void gxTv_SdtEmpleado_Empleadotelefono_N_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadotelefono_N = 0;
         SetDirty("Empleadotelefono_N");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadotelefono_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpleadoEmail_N" )]
      [  XmlElement( ElementName = "EmpleadoEmail_N"   )]
      public short gxTpr_Empleadoemail_N
      {
         get {
            return gxTv_SdtEmpleado_Empleadoemail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadoemail_N = value;
            SetDirty("Empleadoemail_N");
         }

      }

      public void gxTv_SdtEmpleado_Empleadoemail_N_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadoemail_N = 0;
         SetDirty("Empleadoemail_N");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadoemail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpleadoFch_Alta_N" )]
      [  XmlElement( ElementName = "EmpleadoFch_Alta_N"   )]
      public short gxTpr_Empleadofch_alta_N
      {
         get {
            return gxTv_SdtEmpleado_Empleadofch_alta_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadofch_alta_N = value;
            SetDirty("Empleadofch_alta_N");
         }

      }

      public void gxTv_SdtEmpleado_Empleadofch_alta_N_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadofch_alta_N = 0;
         SetDirty("Empleadofch_alta_N");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadofch_alta_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpleadoFcha_Mod_N" )]
      [  XmlElement( ElementName = "EmpleadoFcha_Mod_N"   )]
      public short gxTpr_Empleadofcha_mod_N
      {
         get {
            return gxTv_SdtEmpleado_Empleadofcha_mod_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadofcha_mod_N = value;
            SetDirty("Empleadofcha_mod_N");
         }

      }

      public void gxTv_SdtEmpleado_Empleadofcha_mod_N_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadofcha_mod_N = 0;
         SetDirty("Empleadofcha_mod_N");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadofcha_mod_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpleadoFch_Cad_N" )]
      [  XmlElement( ElementName = "EmpleadoFch_Cad_N"   )]
      public short gxTpr_Empleadofch_cad_N
      {
         get {
            return gxTv_SdtEmpleado_Empleadofch_cad_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadofch_cad_N = value;
            SetDirty("Empleadofch_cad_N");
         }

      }

      public void gxTv_SdtEmpleado_Empleadofch_cad_N_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadofch_cad_N = 0;
         SetDirty("Empleadofch_cad_N");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadofch_cad_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpleadoUsu_Alta_N" )]
      [  XmlElement( ElementName = "EmpleadoUsu_Alta_N"   )]
      public short gxTpr_Empleadousu_alta_N
      {
         get {
            return gxTv_SdtEmpleado_Empleadousu_alta_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadousu_alta_N = value;
            SetDirty("Empleadousu_alta_N");
         }

      }

      public void gxTv_SdtEmpleado_Empleadousu_alta_N_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadousu_alta_N = 0;
         SetDirty("Empleadousu_alta_N");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadousu_alta_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpleadoUsu_Mod_N" )]
      [  XmlElement( ElementName = "EmpleadoUsu_Mod_N"   )]
      public short gxTpr_Empleadousu_mod_N
      {
         get {
            return gxTv_SdtEmpleado_Empleadousu_mod_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadousu_mod_N = value;
            SetDirty("Empleadousu_mod_N");
         }

      }

      public void gxTv_SdtEmpleado_Empleadousu_mod_N_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadousu_mod_N = 0;
         SetDirty("Empleadousu_mod_N");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadousu_mod_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpleadoUso_Cad_N" )]
      [  XmlElement( ElementName = "EmpleadoUso_Cad_N"   )]
      public short gxTpr_Empleadouso_cad_N
      {
         get {
            return gxTv_SdtEmpleado_Empleadouso_cad_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Empleadouso_cad_N = value;
            SetDirty("Empleadouso_cad_N");
         }

      }

      public void gxTv_SdtEmpleado_Empleadouso_cad_N_SetNull( )
      {
         gxTv_SdtEmpleado_Empleadouso_cad_N = 0;
         SetDirty("Empleadouso_cad_N");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Empleadouso_cad_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "parqueAtraccionId_N" )]
      [  XmlElement( ElementName = "parqueAtraccionId_N"   )]
      public short gxTpr_Parqueatraccionid_N
      {
         get {
            return gxTv_SdtEmpleado_Parqueatraccionid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpleado_Parqueatraccionid_N = value;
            SetDirty("Parqueatraccionid_N");
         }

      }

      public void gxTv_SdtEmpleado_Parqueatraccionid_N_SetNull( )
      {
         gxTv_SdtEmpleado_Parqueatraccionid_N = 0;
         SetDirty("Parqueatraccionid_N");
         return  ;
      }

      public bool gxTv_SdtEmpleado_Parqueatraccionid_N_IsNull( )
      {
         return false ;
      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         gxTv_SdtEmpleado_Empleadoid = 1;
         sdtIsNull = 1;
         gxTv_SdtEmpleado_Empleadonombre = "";
         gxTv_SdtEmpleado_Empleadoapellido = "";
         gxTv_SdtEmpleado_Empleadodireccion = "";
         gxTv_SdtEmpleado_Empleadotelefono = "";
         gxTv_SdtEmpleado_Empleadoemail = "";
         gxTv_SdtEmpleado_Empleadofch_alta = DateTimeUtil.ResetTime( DateTimeUtil.Today( (IGxContext)(context)) ) ;
         gxTv_SdtEmpleado_Empleadofcha_mod = (DateTime)(DateTime.MinValue);
         gxTv_SdtEmpleado_Empleadofch_cad = (DateTime)(DateTime.MinValue);
         gxTv_SdtEmpleado_Empleadousu_alta = "";
         gxTv_SdtEmpleado_Empleadousu_mod = "";
         gxTv_SdtEmpleado_Empleadouso_cad = "";
         gxTv_SdtEmpleado_Parqueatraccionid = 1;
         gxTv_SdtEmpleado_Parqueatraccionnombre = "";
         gxTv_SdtEmpleado_Mode = "";
         gxTv_SdtEmpleado_Empleadonombre_Z = "";
         gxTv_SdtEmpleado_Empleadoapellido_Z = "";
         gxTv_SdtEmpleado_Empleadodireccion_Z = "";
         gxTv_SdtEmpleado_Empleadotelefono_Z = "";
         gxTv_SdtEmpleado_Empleadoemail_Z = "";
         gxTv_SdtEmpleado_Empleadofch_alta_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtEmpleado_Empleadofcha_mod_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtEmpleado_Empleadofch_cad_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtEmpleado_Empleadousu_alta_Z = "";
         gxTv_SdtEmpleado_Empleadousu_mod_Z = "";
         gxTv_SdtEmpleado_Empleadouso_cad_Z = "";
         gxTv_SdtEmpleado_Parqueatraccionnombre_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "empleado", "GeneXus.Programs.empleado_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtEmpleado_Empleadoid ;
      private short sdtIsNull ;
      private short gxTv_SdtEmpleado_Parqueatraccionid ;
      private short gxTv_SdtEmpleado_Initialized ;
      private short gxTv_SdtEmpleado_Empleadoid_Z ;
      private short gxTv_SdtEmpleado_Parqueatraccionid_Z ;
      private short gxTv_SdtEmpleado_Empleadodireccion_N ;
      private short gxTv_SdtEmpleado_Empleadotelefono_N ;
      private short gxTv_SdtEmpleado_Empleadoemail_N ;
      private short gxTv_SdtEmpleado_Empleadofch_alta_N ;
      private short gxTv_SdtEmpleado_Empleadofcha_mod_N ;
      private short gxTv_SdtEmpleado_Empleadofch_cad_N ;
      private short gxTv_SdtEmpleado_Empleadousu_alta_N ;
      private short gxTv_SdtEmpleado_Empleadousu_mod_N ;
      private short gxTv_SdtEmpleado_Empleadouso_cad_N ;
      private short gxTv_SdtEmpleado_Parqueatraccionid_N ;
      private string gxTv_SdtEmpleado_Empleadotelefono ;
      private string gxTv_SdtEmpleado_Mode ;
      private string gxTv_SdtEmpleado_Empleadotelefono_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtEmpleado_Empleadofch_alta ;
      private DateTime gxTv_SdtEmpleado_Empleadofcha_mod ;
      private DateTime gxTv_SdtEmpleado_Empleadofch_cad ;
      private DateTime gxTv_SdtEmpleado_Empleadofch_alta_Z ;
      private DateTime gxTv_SdtEmpleado_Empleadofcha_mod_Z ;
      private DateTime gxTv_SdtEmpleado_Empleadofch_cad_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtEmpleado_Empleadonombre ;
      private string gxTv_SdtEmpleado_Empleadoapellido ;
      private string gxTv_SdtEmpleado_Empleadodireccion ;
      private string gxTv_SdtEmpleado_Empleadoemail ;
      private string gxTv_SdtEmpleado_Empleadousu_alta ;
      private string gxTv_SdtEmpleado_Empleadousu_mod ;
      private string gxTv_SdtEmpleado_Empleadouso_cad ;
      private string gxTv_SdtEmpleado_Parqueatraccionnombre ;
      private string gxTv_SdtEmpleado_Empleadonombre_Z ;
      private string gxTv_SdtEmpleado_Empleadoapellido_Z ;
      private string gxTv_SdtEmpleado_Empleadodireccion_Z ;
      private string gxTv_SdtEmpleado_Empleadoemail_Z ;
      private string gxTv_SdtEmpleado_Empleadousu_alta_Z ;
      private string gxTv_SdtEmpleado_Empleadousu_mod_Z ;
      private string gxTv_SdtEmpleado_Empleadouso_cad_Z ;
      private string gxTv_SdtEmpleado_Parqueatraccionnombre_Z ;
   }

   [DataContract(Name = @"Empleado", Namespace = "parques")]
   [GxJsonSerialization("default")]
   public class SdtEmpleado_RESTInterface : GxGenericCollectionItem<SdtEmpleado>
   {
      public SdtEmpleado_RESTInterface( ) : base()
      {
      }

      public SdtEmpleado_RESTInterface( SdtEmpleado psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EmpleadoId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Empleadoid
      {
         get {
            return sdt.gxTpr_Empleadoid ;
         }

         set {
            sdt.gxTpr_Empleadoid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "EmpleadoNombre" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Empleadonombre
      {
         get {
            return sdt.gxTpr_Empleadonombre ;
         }

         set {
            sdt.gxTpr_Empleadonombre = value;
         }

      }

      [DataMember( Name = "EmpleadoApellido" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Empleadoapellido
      {
         get {
            return sdt.gxTpr_Empleadoapellido ;
         }

         set {
            sdt.gxTpr_Empleadoapellido = value;
         }

      }

      [DataMember( Name = "EmpleadoDireccion" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Empleadodireccion
      {
         get {
            return sdt.gxTpr_Empleadodireccion ;
         }

         set {
            sdt.gxTpr_Empleadodireccion = value;
         }

      }

      [DataMember( Name = "EmpleadoTelefono" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Empleadotelefono
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Empleadotelefono) ;
         }

         set {
            sdt.gxTpr_Empleadotelefono = value;
         }

      }

      [DataMember( Name = "EmpleadoEmail" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Empleadoemail
      {
         get {
            return sdt.gxTpr_Empleadoemail ;
         }

         set {
            sdt.gxTpr_Empleadoemail = value;
         }

      }

      [DataMember( Name = "EmpleadoFch_Alta" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Empleadofch_alta
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Empleadofch_alta, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Empleadofch_alta = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "EmpleadoFcha_Mod" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Empleadofcha_mod
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Empleadofcha_mod, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Empleadofcha_mod = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "EmpleadoFch_Cad" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Empleadofch_cad
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Empleadofch_cad, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Empleadofch_cad = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "EmpleadoUsu_Alta" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Empleadousu_alta
      {
         get {
            return sdt.gxTpr_Empleadousu_alta ;
         }

         set {
            sdt.gxTpr_Empleadousu_alta = value;
         }

      }

      [DataMember( Name = "EmpleadoUsu_Mod" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Empleadousu_mod
      {
         get {
            return sdt.gxTpr_Empleadousu_mod ;
         }

         set {
            sdt.gxTpr_Empleadousu_mod = value;
         }

      }

      [DataMember( Name = "EmpleadoUso_Cad" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Empleadouso_cad
      {
         get {
            return sdt.gxTpr_Empleadouso_cad ;
         }

         set {
            sdt.gxTpr_Empleadouso_cad = value;
         }

      }

      [DataMember( Name = "parqueAtraccionId" , Order = 12 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Parqueatraccionid
      {
         get {
            return sdt.gxTpr_Parqueatraccionid ;
         }

         set {
            sdt.gxTpr_Parqueatraccionid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "parqueAtraccionNombre" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Parqueatraccionnombre
      {
         get {
            return sdt.gxTpr_Parqueatraccionnombre ;
         }

         set {
            sdt.gxTpr_Parqueatraccionnombre = value;
         }

      }

      public SdtEmpleado sdt
      {
         get {
            return (SdtEmpleado)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtEmpleado() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 14 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Empleado", Namespace = "parques")]
   [GxJsonSerialization("default")]
   public class SdtEmpleado_RESTLInterface : GxGenericCollectionItem<SdtEmpleado>
   {
      public SdtEmpleado_RESTLInterface( ) : base()
      {
      }

      public SdtEmpleado_RESTLInterface( SdtEmpleado psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EmpleadoNombre" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Empleadonombre
      {
         get {
            return sdt.gxTpr_Empleadonombre ;
         }

         set {
            sdt.gxTpr_Empleadonombre = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtEmpleado sdt
      {
         get {
            return (SdtEmpleado)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtEmpleado() ;
         }
      }

   }

}
