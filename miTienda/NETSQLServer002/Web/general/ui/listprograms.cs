using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.general.ui {
   public class listprograms : GXProcedure
   {
      public listprograms( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("miTienda", true);
      }

      public listprograms( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName> aP0_ProgramNames )
      {
         this.AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName>( context, "ProgramName", "miTienda") ;
         initialize();
         ExecuteImpl();
         aP0_ProgramNames=this.AV9ProgramNames;
      }

      public GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName> executeUdp( )
      {
         execute(out aP0_ProgramNames);
         return AV9ProgramNames ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName> aP0_ProgramNames )
      {
         this.AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName>( context, "ProgramName", "miTienda") ;
         SubmitImpl();
         aP0_ProgramNames=this.AV9ProgramNames;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName>( context, "ProgramName", "miTienda");
         AV11name = "WWCarrito";
         AV12description = "Carritos";
         AV13link = formatLink("wwcarrito.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV11name = "WWCatalogo";
         AV12description = "Catalogos";
         AV13link = formatLink("wwcatalogo.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV11name = "WWCategoria";
         AV12description = "Categorias";
         AV13link = formatLink("wwcategoria.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV11name = "WWCliente";
         AV12description = "Clientes";
         AV13link = formatLink("wwcliente.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV11name = "WWPais";
         AV12description = "Pais";
         AV13link = formatLink("wwpais.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV11name = "WWProducto";
         AV12description = "Productos";
         AV13link = formatLink("wwproducto.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV11name = "WWProveedor";
         AV12description = "Proveedores";
         AV13link = formatLink("wwproveedor.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV11name = "WWTarjetaDePuntos";
         AV12description = "Tarjeta De Puntos";
         AV13link = formatLink("wwtarjetadepuntos.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV11name = "WWVendedor";
         AV12description = "Vendedores";
         AV13link = formatLink("wwvendedor.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'ADDPROGRAM' Routine */
         returnInSub = false;
         AV8IsAuthorized = true;
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.general.security.isauthorized(context ).execute(  AV11name, out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV10ProgramName = new GeneXus.Programs.general.ui.SdtProgramNames_ProgramName(context);
            AV10ProgramName.gxTpr_Name = AV11name;
            AV10ProgramName.gxTpr_Description = AV12description;
            AV10ProgramName.gxTpr_Link = AV13link;
            AV9ProgramNames.Add(AV10ProgramName, 0);
         }
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName>( context, "ProgramName", "miTienda");
         AV11name = "";
         AV12description = "";
         AV13link = "";
         AV10ProgramName = new GeneXus.Programs.general.ui.SdtProgramNames_ProgramName(context);
         /* GeneXus formulas. */
      }

      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private string AV11name ;
      private string AV12description ;
      private string AV13link ;
      private GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName> AV9ProgramNames ;
      private GeneXus.Programs.general.ui.SdtProgramNames_ProgramName AV10ProgramName ;
      private GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName> aP0_ProgramNames ;
   }

}
