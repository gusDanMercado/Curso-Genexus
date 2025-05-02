using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class adetallecompra : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("miTienda", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "carritoID");
            if ( ! entryPointCalled )
            {
               AV8carritoID = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public adetallecompra( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("miTienda", true);
      }

      public adetallecompra( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_carritoID )
      {
         this.AV8carritoID = aP0_carritoID;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( int aP0_carritoID )
      {
         this.AV8carritoID = aP0_carritoID;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("DetalleCompra");
         setOutputType("PDF");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            /* Execute user subroutine: 'BUSCAR CARRITO' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'BUSCAR PRODUCTOS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0F0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'BUSCAR CARRITO' Routine */
         returnInSub = false;
         /* Using cursor P000F3 */
         pr_default.execute(0, new Object[] {AV8carritoID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A9ClienteID = P000F3_A9ClienteID[0];
            A1PaisID = P000F3_A1PaisID[0];
            A33CarritoID = P000F3_A33CarritoID[0];
            A2PaisNombre = P000F3_A2PaisNombre[0];
            A11ClienteDireccion = P000F3_A11ClienteDireccion[0];
            A10ClienteNombre = P000F3_A10ClienteNombre[0];
            A36CarritoCostoTotalCompra = P000F3_A36CarritoCostoTotalCompra[0];
            n36CarritoCostoTotalCompra = P000F3_n36CarritoCostoTotalCompra[0];
            A34CarritoFchCompra = P000F3_A34CarritoFchCompra[0];
            A1PaisID = P000F3_A1PaisID[0];
            A11ClienteDireccion = P000F3_A11ClienteDireccion[0];
            A10ClienteNombre = P000F3_A10ClienteNombre[0];
            A2PaisNombre = P000F3_A2PaisNombre[0];
            A36CarritoCostoTotalCompra = P000F3_A36CarritoCostoTotalCompra[0];
            n36CarritoCostoTotalCompra = P000F3_n36CarritoCostoTotalCompra[0];
            A35CarritoFchEntrega = DateTimeUtil.DAdd( A34CarritoFchCompra, (5));
            H0F0( false, 303) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 20, true, false, false, false, 0, 255, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Mi Carrito de Compras", 358, Gx_line+67, 663, Gx_line+99, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Compra ID:", 67, Gx_line+183, 134, Gx_line+197, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Fecha Compra:", 317, Gx_line+183, 407, Gx_line+197, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Fecha Entrega:", 542, Gx_line+183, 634, Gx_line+197, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Cliente:", 67, Gx_line+217, 113, Gx_line+231, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( A34CarritoFchCompra, "99/99/9999"), 400, Gx_line+183, 500, Gx_line+198, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A35CarritoFchEntrega, "99/99/9999"), 625, Gx_line+183, 728, Gx_line+198, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A10ClienteNombre, "")), 117, Gx_line+217, 242, Gx_line+232, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A11ClienteDireccion, "")), 242, Gx_line+217, 484, Gx_line+232, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2PaisNombre, "")), 483, Gx_line+217, 626, Gx_line+232, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8carritoID), "ZZZZZ9")), 125, Gx_line+183, 208, Gx_line+198, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A36CarritoCostoTotalCompra, "ZZZZZZ9.99")), 658, Gx_line+250, 791, Gx_line+265, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(17, Gx_line+300, 817, Gx_line+300, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Total: $", 608, Gx_line+250, 655, Gx_line+264, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total", 758, Gx_line+283, 789, Gx_line+297, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Cantidad", 517, Gx_line+283, 570, Gx_line+297, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Precio", 442, Gx_line+283, 481, Gx_line+297, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Producto", 50, Gx_line+283, 104, Gx_line+297, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "4a145eed-199b-41c2-9fee-46fb6955c62c", "", context.GetTheme( )), 183, Gx_line+0, 358, Gx_line+167) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+303);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      protected void S121( )
      {
         /* 'BUSCAR PRODUCTOS' Routine */
         returnInSub = false;
         /* Using cursor P000F4 */
         pr_default.execute(1, new Object[] {AV8carritoID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A19ProductoID = P000F4_A19ProductoID[0];
            A33CarritoID = P000F4_A33CarritoID[0];
            A40000ProductoImagen_GXI = P000F4_A40000ProductoImagen_GXI[0];
            A20ProductoNombre = P000F4_A20ProductoNombre[0];
            A22ProductoPrecio = P000F4_A22ProductoPrecio[0];
            A38CarritoDetalleCompraCantidadUn = P000F4_A38CarritoDetalleCompraCantidadUn[0];
            A37CarritoDetalleCompraID = P000F4_A37CarritoDetalleCompraID[0];
            A23ProductoImagen = P000F4_A23ProductoImagen[0];
            A40000ProductoImagen_GXI = P000F4_A40000ProductoImagen_GXI[0];
            A20ProductoNombre = P000F4_A20ProductoNombre[0];
            A22ProductoPrecio = P000F4_A22ProductoPrecio[0];
            A23ProductoImagen = P000F4_A23ProductoImagen[0];
            A39CarritoDetalleCompraCostoTotal = (decimal)(A22ProductoPrecio*A38CarritoDetalleCompraCantidadUn);
            H0F0( false, 51) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A20ProductoNombre, "")), 133, Gx_line+17, 333, Gx_line+32, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A22ProductoPrecio, "ZZZZZZ9.99")), 342, Gx_line+17, 475, Gx_line+32, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A38CarritoDetalleCompraCantidadUn), "ZZZ9")), 492, Gx_line+17, 584, Gx_line+32, 1, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A39CarritoDetalleCompraCostoTotal, "ZZZZZZ9.99")), 592, Gx_line+17, 792, Gx_line+32, 2, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductoImagen)) ? A40000ProductoImagen_GXI : A23ProductoImagen);
            getPrinter().GxDrawBitMap(sImgUrl, 25, Gx_line+0, 117, Gx_line+50) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+51);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void H0F0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         P000F3_A9ClienteID = new int[1] ;
         P000F3_A1PaisID = new int[1] ;
         P000F3_A33CarritoID = new int[1] ;
         P000F3_A2PaisNombre = new string[] {""} ;
         P000F3_A11ClienteDireccion = new string[] {""} ;
         P000F3_A10ClienteNombre = new string[] {""} ;
         P000F3_A36CarritoCostoTotalCompra = new decimal[1] ;
         P000F3_n36CarritoCostoTotalCompra = new bool[] {false} ;
         P000F3_A34CarritoFchCompra = new DateTime[] {DateTime.MinValue} ;
         A2PaisNombre = "";
         A11ClienteDireccion = "";
         A10ClienteNombre = "";
         A34CarritoFchCompra = DateTime.MinValue;
         A35CarritoFchEntrega = DateTime.MinValue;
         P000F4_A19ProductoID = new int[1] ;
         P000F4_A33CarritoID = new int[1] ;
         P000F4_A40000ProductoImagen_GXI = new string[] {""} ;
         P000F4_A20ProductoNombre = new string[] {""} ;
         P000F4_A22ProductoPrecio = new decimal[1] ;
         P000F4_A38CarritoDetalleCompraCantidadUn = new short[1] ;
         P000F4_A37CarritoDetalleCompraID = new int[1] ;
         P000F4_A23ProductoImagen = new string[] {""} ;
         A40000ProductoImagen_GXI = "";
         A20ProductoNombre = "";
         A23ProductoImagen = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.adetallecompra__default(),
            new Object[][] {
                new Object[] {
               P000F3_A9ClienteID, P000F3_A1PaisID, P000F3_A33CarritoID, P000F3_A2PaisNombre, P000F3_A11ClienteDireccion, P000F3_A10ClienteNombre, P000F3_A36CarritoCostoTotalCompra, P000F3_n36CarritoCostoTotalCompra, P000F3_A34CarritoFchCompra
               }
               , new Object[] {
               P000F4_A19ProductoID, P000F4_A33CarritoID, P000F4_A40000ProductoImagen_GXI, P000F4_A20ProductoNombre, P000F4_A22ProductoPrecio, P000F4_A38CarritoDetalleCompraCantidadUn, P000F4_A37CarritoDetalleCompraID, P000F4_A23ProductoImagen
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A38CarritoDetalleCompraCantidadUn ;
      private int AV8carritoID ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A9ClienteID ;
      private int A1PaisID ;
      private int A33CarritoID ;
      private int Gx_OldLine ;
      private int A19ProductoID ;
      private int A37CarritoDetalleCompraID ;
      private decimal A36CarritoCostoTotalCompra ;
      private decimal A22ProductoPrecio ;
      private decimal A39CarritoDetalleCompraCostoTotal ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string sImgUrl ;
      private DateTime A34CarritoFchCompra ;
      private DateTime A35CarritoFchEntrega ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool n36CarritoCostoTotalCompra ;
      private string A2PaisNombre ;
      private string A11ClienteDireccion ;
      private string A10ClienteNombre ;
      private string A40000ProductoImagen_GXI ;
      private string A20ProductoNombre ;
      private string A23ProductoImagen ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P000F3_A9ClienteID ;
      private int[] P000F3_A1PaisID ;
      private int[] P000F3_A33CarritoID ;
      private string[] P000F3_A2PaisNombre ;
      private string[] P000F3_A11ClienteDireccion ;
      private string[] P000F3_A10ClienteNombre ;
      private decimal[] P000F3_A36CarritoCostoTotalCompra ;
      private bool[] P000F3_n36CarritoCostoTotalCompra ;
      private DateTime[] P000F3_A34CarritoFchCompra ;
      private int[] P000F4_A19ProductoID ;
      private int[] P000F4_A33CarritoID ;
      private string[] P000F4_A40000ProductoImagen_GXI ;
      private string[] P000F4_A20ProductoNombre ;
      private decimal[] P000F4_A22ProductoPrecio ;
      private short[] P000F4_A38CarritoDetalleCompraCantidadUn ;
      private int[] P000F4_A37CarritoDetalleCompraID ;
      private string[] P000F4_A23ProductoImagen ;
   }

   public class adetallecompra__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000F3;
          prmP000F3 = new Object[] {
          new ParDef("@AV8carritoID",GXType.Int32,6,0)
          };
          Object[] prmP000F4;
          prmP000F4 = new Object[] {
          new ParDef("@AV8carritoID",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000F3", "SELECT T1.[ClienteID], T2.[PaisID], T1.[CarritoID], T3.[PaisNombre], T2.[ClienteDireccion], T2.[ClienteNombre], COALESCE( T4.[CarritoCostoTotalCompra], 0) AS CarritoCostoTotalCompra, T1.[CarritoFchCompra] FROM ((([Carrito] T1 INNER JOIN [Cliente] T2 ON T2.[ClienteID] = T1.[ClienteID]) INNER JOIN [Pais] T3 ON T3.[PaisID] = T2.[PaisID]) LEFT JOIN (SELECT SUM(T6.[ProductoPrecio] * CAST(T5.[CarritoDetalleCompraCantidadUn] AS decimal( 20, 10))) AS CarritoCostoTotalCompra, T5.[CarritoID] FROM ([CarritoDetalleCompra] T5 INNER JOIN [Producto] T6 ON T6.[ProductoID] = T5.[ProductoID]) GROUP BY T5.[CarritoID] ) T4 ON T4.[CarritoID] = T1.[CarritoID]) WHERE T1.[CarritoID] = @AV8carritoID ORDER BY T1.[CarritoID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P000F4", "SELECT T1.[ProductoID], T1.[CarritoID], T2.[ProductoImagen_GXI], T2.[ProductoNombre], T2.[ProductoPrecio], T1.[CarritoDetalleCompraCantidadUn], T1.[CarritoDetalleCompraID], T2.[ProductoImagen] FROM ([CarritoDetalleCompra] T1 INNER JOIN [Producto] T2 ON T2.[ProductoID] = T1.[ProductoID]) WHERE T1.[CarritoID] = @AV8carritoID ORDER BY T1.[CarritoID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F4,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
                return;
       }
    }

 }

}
