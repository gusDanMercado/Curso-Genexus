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
namespace GeneXus.Programs {
   public class acategoria_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new acategoria_dataprovider().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         GXBCCollection<SdtCategoria> aP0_Gxm2rootcol = new GXBCCollection<SdtCategoria>()  ;
         execute(out aP0_Gxm2rootcol);
         return GX.GXRuntime.ExitCode ;
      }

      public acategoria_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("miTienda", true);
      }

      public acategoria_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtCategoria> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtCategoria>( context, "Categoria", "miTienda") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtCategoria> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtCategoria> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtCategoria>( context, "Categoria", "miTienda") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1categoria = new SdtCategoria(context);
         Gxm2rootcol.Add(Gxm1categoria, 0);
         Gxm1categoria.gxTpr_Categorianombre = "Ropa";
         Gxm1categoria = new SdtCategoria(context);
         Gxm2rootcol.Add(Gxm1categoria, 0);
         Gxm1categoria.gxTpr_Categorianombre = "Joyería";
         Gxm1categoria = new SdtCategoria(context);
         Gxm2rootcol.Add(Gxm1categoria, 0);
         Gxm1categoria.gxTpr_Categorianombre = "Entretenimiento";
         Gxm1categoria = new SdtCategoria(context);
         Gxm2rootcol.Add(Gxm1categoria, 0);
         Gxm1categoria.gxTpr_Categorianombre = "Hogar";
         Gxm1categoria = new SdtCategoria(context);
         Gxm2rootcol.Add(Gxm1categoria, 0);
         Gxm1categoria.gxTpr_Categorianombre = "Salud";
         cleanup();
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
         Gxm1categoria = new SdtCategoria(context);
         /* GeneXus formulas. */
      }

      private GXBCCollection<SdtCategoria> Gxm2rootcol ;
      private SdtCategoria Gxm1categoria ;
      private GXBCCollection<SdtCategoria> aP0_Gxm2rootcol ;
   }

}
