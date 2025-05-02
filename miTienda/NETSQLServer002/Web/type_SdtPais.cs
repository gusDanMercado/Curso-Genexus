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
   [XmlRoot(ElementName = "Pais" )]
   [XmlType(TypeName =  "Pais" , Namespace = "miTienda" )]
   [Serializable]
   public class SdtPais : GxSilentTrnSdt
   {
      public SdtPais( )
      {
      }

      public SdtPais( IGxContext context )
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

      public void Load( int AV1PaisID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV1PaisID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PaisID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Pais");
         metadata.Set("BT", "Pais");
         metadata.Set("PK", "[ \"PaisID\" ]");
         metadata.Set("PKAssigned", "[ \"PaisID\" ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Paisbandera_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Paisid_Z");
         state.Add("gxTpr_Paisnombre_Z");
         state.Add("gxTpr_Paisbandera_gxi_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPais sdt;
         sdt = (SdtPais)(source);
         gxTv_SdtPais_Paisid = sdt.gxTv_SdtPais_Paisid ;
         gxTv_SdtPais_Paisnombre = sdt.gxTv_SdtPais_Paisnombre ;
         gxTv_SdtPais_Paisbandera = sdt.gxTv_SdtPais_Paisbandera ;
         gxTv_SdtPais_Paisbandera_gxi = sdt.gxTv_SdtPais_Paisbandera_gxi ;
         gxTv_SdtPais_Mode = sdt.gxTv_SdtPais_Mode ;
         gxTv_SdtPais_Initialized = sdt.gxTv_SdtPais_Initialized ;
         gxTv_SdtPais_Paisid_Z = sdt.gxTv_SdtPais_Paisid_Z ;
         gxTv_SdtPais_Paisnombre_Z = sdt.gxTv_SdtPais_Paisnombre_Z ;
         gxTv_SdtPais_Paisbandera_gxi_Z = sdt.gxTv_SdtPais_Paisbandera_gxi_Z ;
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
         AddObjectProperty("PaisID", gxTv_SdtPais_Paisid, false, includeNonInitialized);
         AddObjectProperty("PaisNombre", gxTv_SdtPais_Paisnombre, false, includeNonInitialized);
         AddObjectProperty("PaisBandera", gxTv_SdtPais_Paisbandera, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("PaisBandera_GXI", gxTv_SdtPais_Paisbandera_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtPais_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPais_Initialized, false, includeNonInitialized);
            AddObjectProperty("PaisID_Z", gxTv_SdtPais_Paisid_Z, false, includeNonInitialized);
            AddObjectProperty("PaisNombre_Z", gxTv_SdtPais_Paisnombre_Z, false, includeNonInitialized);
            AddObjectProperty("PaisBandera_GXI_Z", gxTv_SdtPais_Paisbandera_gxi_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPais sdt )
      {
         if ( sdt.IsDirty("PaisID") )
         {
            sdtIsNull = 0;
            gxTv_SdtPais_Paisid = sdt.gxTv_SdtPais_Paisid ;
         }
         if ( sdt.IsDirty("PaisNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtPais_Paisnombre = sdt.gxTv_SdtPais_Paisnombre ;
         }
         if ( sdt.IsDirty("PaisBandera") )
         {
            sdtIsNull = 0;
            gxTv_SdtPais_Paisbandera = sdt.gxTv_SdtPais_Paisbandera ;
         }
         if ( sdt.IsDirty("PaisBandera") )
         {
            sdtIsNull = 0;
            gxTv_SdtPais_Paisbandera_gxi = sdt.gxTv_SdtPais_Paisbandera_gxi ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PaisID" )]
      [  XmlElement( ElementName = "PaisID"   )]
      public int gxTpr_Paisid
      {
         get {
            return gxTv_SdtPais_Paisid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtPais_Paisid != value )
            {
               gxTv_SdtPais_Mode = "INS";
               this.gxTv_SdtPais_Paisid_Z_SetNull( );
               this.gxTv_SdtPais_Paisnombre_Z_SetNull( );
               this.gxTv_SdtPais_Paisbandera_gxi_Z_SetNull( );
            }
            gxTv_SdtPais_Paisid = value;
            SetDirty("Paisid");
         }

      }

      [  SoapElement( ElementName = "PaisNombre" )]
      [  XmlElement( ElementName = "PaisNombre"   )]
      public string gxTpr_Paisnombre
      {
         get {
            return gxTv_SdtPais_Paisnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPais_Paisnombre = value;
            SetDirty("Paisnombre");
         }

      }

      [  SoapElement( ElementName = "PaisBandera" )]
      [  XmlElement( ElementName = "PaisBandera"   )]
      [GxUpload()]
      public string gxTpr_Paisbandera
      {
         get {
            return gxTv_SdtPais_Paisbandera ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPais_Paisbandera = value;
            SetDirty("Paisbandera");
         }

      }

      [  SoapElement( ElementName = "PaisBandera_GXI" )]
      [  XmlElement( ElementName = "PaisBandera_GXI"   )]
      public string gxTpr_Paisbandera_gxi
      {
         get {
            return gxTv_SdtPais_Paisbandera_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPais_Paisbandera_gxi = value;
            SetDirty("Paisbandera_gxi");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPais_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPais_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPais_Mode_SetNull( )
      {
         gxTv_SdtPais_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPais_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPais_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPais_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPais_Initialized_SetNull( )
      {
         gxTv_SdtPais_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPais_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisID_Z" )]
      [  XmlElement( ElementName = "PaisID_Z"   )]
      public int gxTpr_Paisid_Z
      {
         get {
            return gxTv_SdtPais_Paisid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPais_Paisid_Z = value;
            SetDirty("Paisid_Z");
         }

      }

      public void gxTv_SdtPais_Paisid_Z_SetNull( )
      {
         gxTv_SdtPais_Paisid_Z = 0;
         SetDirty("Paisid_Z");
         return  ;
      }

      public bool gxTv_SdtPais_Paisid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisNombre_Z" )]
      [  XmlElement( ElementName = "PaisNombre_Z"   )]
      public string gxTpr_Paisnombre_Z
      {
         get {
            return gxTv_SdtPais_Paisnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPais_Paisnombre_Z = value;
            SetDirty("Paisnombre_Z");
         }

      }

      public void gxTv_SdtPais_Paisnombre_Z_SetNull( )
      {
         gxTv_SdtPais_Paisnombre_Z = "";
         SetDirty("Paisnombre_Z");
         return  ;
      }

      public bool gxTv_SdtPais_Paisnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisBandera_GXI_Z" )]
      [  XmlElement( ElementName = "PaisBandera_GXI_Z"   )]
      public string gxTpr_Paisbandera_gxi_Z
      {
         get {
            return gxTv_SdtPais_Paisbandera_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPais_Paisbandera_gxi_Z = value;
            SetDirty("Paisbandera_gxi_Z");
         }

      }

      public void gxTv_SdtPais_Paisbandera_gxi_Z_SetNull( )
      {
         gxTv_SdtPais_Paisbandera_gxi_Z = "";
         SetDirty("Paisbandera_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtPais_Paisbandera_gxi_Z_IsNull( )
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
         gxTv_SdtPais_Paisid = 1;
         sdtIsNull = 1;
         gxTv_SdtPais_Paisnombre = "";
         gxTv_SdtPais_Paisbandera = "";
         gxTv_SdtPais_Paisbandera_gxi = "";
         gxTv_SdtPais_Mode = "";
         gxTv_SdtPais_Paisnombre_Z = "";
         gxTv_SdtPais_Paisbandera_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "pais", "GeneXus.Programs.pais_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short sdtIsNull ;
      private short gxTv_SdtPais_Initialized ;
      private int gxTv_SdtPais_Paisid ;
      private int gxTv_SdtPais_Paisid_Z ;
      private string gxTv_SdtPais_Mode ;
      private string gxTv_SdtPais_Paisnombre ;
      private string gxTv_SdtPais_Paisbandera_gxi ;
      private string gxTv_SdtPais_Paisnombre_Z ;
      private string gxTv_SdtPais_Paisbandera_gxi_Z ;
      private string gxTv_SdtPais_Paisbandera ;
   }

   [DataContract(Name = @"Pais", Namespace = "miTienda")]
   [GxJsonSerialization("default")]
   public class SdtPais_RESTInterface : GxGenericCollectionItem<SdtPais>
   {
      public SdtPais_RESTInterface( ) : base()
      {
      }

      public SdtPais_RESTInterface( SdtPais psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PaisID" , Order = 0 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Paisid
      {
         get {
            return sdt.gxTpr_Paisid ;
         }

         set {
            sdt.gxTpr_Paisid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PaisNombre" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Paisnombre
      {
         get {
            return sdt.gxTpr_Paisnombre ;
         }

         set {
            sdt.gxTpr_Paisnombre = value;
         }

      }

      [DataMember( Name = "PaisBandera" , Order = 2 )]
      [GxUpload()]
      public string gxTpr_Paisbandera
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Paisbandera)) ? PathUtil.RelativeURL( sdt.gxTpr_Paisbandera) : StringUtil.RTrim( sdt.gxTpr_Paisbandera_gxi)) ;
         }

         set {
            sdt.gxTpr_Paisbandera = value;
         }

      }

      public SdtPais sdt
      {
         get {
            return (SdtPais)Sdt ;
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
            sdt = new SdtPais() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 3 )]
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

   [DataContract(Name = @"Pais", Namespace = "miTienda")]
   [GxJsonSerialization("default")]
   public class SdtPais_RESTLInterface : GxGenericCollectionItem<SdtPais>
   {
      public SdtPais_RESTLInterface( ) : base()
      {
      }

      public SdtPais_RESTLInterface( SdtPais psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PaisNombre" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Paisnombre
      {
         get {
            return sdt.gxTpr_Paisnombre ;
         }

         set {
            sdt.gxTpr_Paisnombre = value;
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

      public SdtPais sdt
      {
         get {
            return (SdtPais)Sdt ;
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
            sdt = new SdtPais() ;
         }
      }

   }

}
