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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class carrito : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A33CarritoID = (int)(Math.Round(NumberUtil.Val( GetPar( "CarritoID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A33CarritoID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A9ClienteID = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A9ClienteID", StringUtil.LTrimStr( (decimal)(A9ClienteID), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A9ClienteID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A19ProductoID = (int)(Math.Round(NumberUtil.Val( GetPar( "ProductoID"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A19ProductoID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridcarrito_detallecompra") == 0 )
         {
            gxnrGridcarrito_detallecompra_newrow_invoke( ) ;
            return  ;
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7CarritoID = (int)(Math.Round(NumberUtil.Val( GetPar( "CarritoID"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7CarritoID", StringUtil.LTrimStr( (decimal)(AV7CarritoID), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vCARRITOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CarritoID), "ZZZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", "Carrito", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCarritoFchCompra_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("miTienda", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridcarrito_detallecompra_newrow_invoke( )
      {
         nRC_GXsfl_68 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_68"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_68_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_68_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_68_idx = GetPar( "sGXsfl_68_idx");
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridcarrito_detallecompra_newrow( ) ;
         /* End function gxnrGridcarrito_detallecompra_newrow_invoke */
      }

      public carrito( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("miTienda", true);
      }

      public carrito( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_CarritoID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CarritoID = aP1_CarritoID;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterunanimosidebar", "GeneXus.Programs.general.ui.masterunanimosidebar", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         cleanup();
      }

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Carrito", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Carrito.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Carrito.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Carrito.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Carrito.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Carrito.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Carrito.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCarritoID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCarritoID_Internalname, "ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCarritoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A33CarritoID), 6, 0, ".", "")), StringUtil.LTrim( ((edtCarritoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A33CarritoID), "ZZZZZ9") : context.localUtil.Format( (decimal)(A33CarritoID), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarritoID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCarritoID_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Carrito.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCarritoFchCompra_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCarritoFchCompra_Internalname, "Fch Compra", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCarritoFchCompra_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCarritoFchCompra_Internalname, context.localUtil.Format(A34CarritoFchCompra, "99/99/9999"), context.localUtil.Format( A34CarritoFchCompra, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarritoFchCompra_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCarritoFchCompra_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Fecha", "end", false, "", "HLP_Carrito.htm");
         GxWebStd.gx_bitmap( context, edtCarritoFchCompra_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCarritoFchCompra_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Carrito.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCarritoFchEntrega_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCarritoFchEntrega_Internalname, "Fch Entrega", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCarritoFchEntrega_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCarritoFchEntrega_Internalname, context.localUtil.Format(A35CarritoFchEntrega, "99/99/9999"), context.localUtil.Format( A35CarritoFchEntrega, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarritoFchEntrega_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCarritoFchEntrega_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Fecha", "end", false, "", "HLP_Carrito.htm");
         GxWebStd.gx_bitmap( context, edtCarritoFchEntrega_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCarritoFchEntrega_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Carrito.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteID_Internalname, "Cliente ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9ClienteID), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A9ClienteID), "ZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteID_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Carrito.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_9_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_9_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_9_Internalname, sImgUrl, imgprompt_9_Link, "", "", context.GetTheme( ), imgprompt_9_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Carrito.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteNombre_Internalname, "Cliente Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteNombre_Internalname, A10ClienteNombre, StringUtil.RTrim( context.localUtil.Format( A10ClienteNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Carrito.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCarritoCostoTotalCompra_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCarritoCostoTotalCompra_Internalname, "Total Compra", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCarritoCostoTotalCompra_Internalname, StringUtil.LTrim( StringUtil.NToC( A36CarritoCostoTotalCompra, 10, 2, ".", "")), StringUtil.LTrim( ((edtCarritoCostoTotalCompra_Enabled!=0) ? context.localUtil.Format( A36CarritoCostoTotalCompra, "ZZZZZZ9.99") : context.localUtil.Format( A36CarritoCostoTotalCompra, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarritoCostoTotalCompra_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCarritoCostoTotalCompra_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Importe", "end", false, "", "HLP_Carrito.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divDetallecompratable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitledetallecompra_Internalname, "Detalle Compra", "", "", lblTitledetallecompra_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_Carrito.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridcarrito_detallecompra( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Carrito.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Carrito.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Carrito.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridcarrito_detallecompra( )
      {
         /*  Grid Control  */
         StartGridControl68( ) ;
         nGXsfl_68_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount10 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_10 = 1;
               ScanStart0910( ) ;
               while ( RcdFound10 != 0 )
               {
                  init_level_properties10( ) ;
                  getByPrimaryKey0910( ) ;
                  AddRow0910( ) ;
                  ScanNext0910( ) ;
               }
               ScanEnd0910( ) ;
               nBlankRcdCount10 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B36CarritoCostoTotalCompra = A36CarritoCostoTotalCompra;
            n36CarritoCostoTotalCompra = false;
            AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
            standaloneNotModal0910( ) ;
            standaloneModal0910( ) ;
            sMode10 = Gx_mode;
            while ( nGXsfl_68_idx < nRC_GXsfl_68 )
            {
               bGXsfl_68_Refreshing = true;
               ReadRow0910( ) ;
               edtCarritoDetalleCompraID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARRITODETALLECOMPRAID_"+sGXsfl_68_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCarritoDetalleCompraID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarritoDetalleCompraID_Enabled), 5, 0), !bGXsfl_68_Refreshing);
               edtProductoID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOID_"+sGXsfl_68_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoID_Enabled), 5, 0), !bGXsfl_68_Refreshing);
               edtProductoPrecio_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOPRECIO_"+sGXsfl_68_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductoPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoPrecio_Enabled), 5, 0), !bGXsfl_68_Refreshing);
               edtCategoriaID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CATEGORIAID_"+sGXsfl_68_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCategoriaID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaID_Enabled), 5, 0), !bGXsfl_68_Refreshing);
               edtCarritoDetalleCompraCantidadUn_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARRITODETALLECOMPRACANTIDADUN_"+sGXsfl_68_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCarritoDetalleCompraCantidadUn_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarritoDetalleCompraCantidadUn_Enabled), 5, 0), !bGXsfl_68_Refreshing);
               edtCarritoDetalleCompraCostoTotal_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARRITODETALLECOMPRACOSTOTOTAL_"+sGXsfl_68_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCarritoDetalleCompraCostoTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarritoDetalleCompraCostoTotal_Enabled), 5, 0), !bGXsfl_68_Refreshing);
               imgprompt_9_Link = cgiGet( "PROMPT_19_"+sGXsfl_68_idx+"Link");
               if ( ( nRcdExists_10 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0910( ) ;
               }
               SendRow0910( ) ;
               bGXsfl_68_Refreshing = false;
            }
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A36CarritoCostoTotalCompra = B36CarritoCostoTotalCompra;
            n36CarritoCostoTotalCompra = false;
            AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount10 = 5;
            nRcdExists_10 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0910( ) ;
               while ( RcdFound10 != 0 )
               {
                  sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_6810( ) ;
                  init_level_properties10( ) ;
                  standaloneNotModal0910( ) ;
                  getByPrimaryKey0910( ) ;
                  standaloneModal0910( ) ;
                  AddRow0910( ) ;
                  ScanNext0910( ) ;
               }
               ScanEnd0910( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode10 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx+1), 4, 0), 4, "0");
            SubsflControlProps_6810( ) ;
            InitAll0910( ) ;
            init_level_properties10( ) ;
            B36CarritoCostoTotalCompra = A36CarritoCostoTotalCompra;
            n36CarritoCostoTotalCompra = false;
            AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
            nRcdExists_10 = 0;
            nIsMod_10 = 0;
            nRcdDeleted_10 = 0;
            nBlankRcdCount10 = (short)(nBlankRcdUsr10+nBlankRcdCount10);
            fRowAdded = 0;
            while ( nBlankRcdCount10 > 0 )
            {
               standaloneNotModal0910( ) ;
               standaloneModal0910( ) ;
               AddRow0910( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtCarritoDetalleCompraID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount10 = (short)(nBlankRcdCount10-1);
            }
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A36CarritoCostoTotalCompra = B36CarritoCostoTotalCompra;
            n36CarritoCostoTotalCompra = false;
            AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridcarrito_detallecompraContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridcarrito_detallecompra", Gridcarrito_detallecompraContainer, subGridcarrito_detallecompra_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridcarrito_detallecompraContainerData", Gridcarrito_detallecompraContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridcarrito_detallecompraContainerData"+"V", Gridcarrito_detallecompraContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridcarrito_detallecompraContainerData"+"V"+"\" value='"+Gridcarrito_detallecompraContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11092 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z33CarritoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z33CarritoID"), ".", ","), 18, MidpointRounding.ToEven));
               Z34CarritoFchCompra = context.localUtil.CToD( cgiGet( "Z34CarritoFchCompra"), 0);
               Z9ClienteID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z9ClienteID"), ".", ","), 18, MidpointRounding.ToEven));
               O36CarritoCostoTotalCompra = context.localUtil.CToN( cgiGet( "O36CarritoCostoTotalCompra"), ".", ",");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_68 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_68"), ".", ","), 18, MidpointRounding.ToEven));
               N9ClienteID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N9ClienteID"), ".", ","), 18, MidpointRounding.ToEven));
               AV7CarritoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vCARRITOID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV11Insert_ClienteID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CLIENTEID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               AV16Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A33CarritoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCarritoID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
               if ( context.localUtil.VCDate( cgiGet( edtCarritoFchCompra_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Carrito Fch Compra"}), 1, "CARRITOFCHCOMPRA");
                  AnyError = 1;
                  GX_FocusControl = edtCarritoFchCompra_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A34CarritoFchCompra = DateTime.MinValue;
                  AssignAttri("", false, "A34CarritoFchCompra", context.localUtil.Format(A34CarritoFchCompra, "99/99/9999"));
               }
               else
               {
                  A34CarritoFchCompra = context.localUtil.CToD( cgiGet( edtCarritoFchCompra_Internalname), 1);
                  AssignAttri("", false, "A34CarritoFchCompra", context.localUtil.Format(A34CarritoFchCompra, "99/99/9999"));
               }
               A35CarritoFchEntrega = context.localUtil.CToD( cgiGet( edtCarritoFchEntrega_Internalname), 1);
               AssignAttri("", false, "A35CarritoFchEntrega", context.localUtil.Format(A35CarritoFchEntrega, "99/99/9999"));
               if ( ( ( context.localUtil.CToN( cgiGet( edtClienteID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClienteID_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTEID");
                  AnyError = 1;
                  GX_FocusControl = edtClienteID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A9ClienteID = 0;
                  AssignAttri("", false, "A9ClienteID", StringUtil.LTrimStr( (decimal)(A9ClienteID), 6, 0));
               }
               else
               {
                  A9ClienteID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A9ClienteID", StringUtil.LTrimStr( (decimal)(A9ClienteID), 6, 0));
               }
               A10ClienteNombre = cgiGet( edtClienteNombre_Internalname);
               AssignAttri("", false, "A10ClienteNombre", A10ClienteNombre);
               A36CarritoCostoTotalCompra = context.localUtil.CToN( cgiGet( edtCarritoCostoTotalCompra_Internalname), ".", ",");
               n36CarritoCostoTotalCompra = false;
               AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Carrito");
               A33CarritoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCarritoID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
               forbiddenHiddens.Add("CarritoID", context.localUtil.Format( (decimal)(A33CarritoID), "ZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A33CarritoID != Z33CarritoID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("carrito:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A33CarritoID = (int)(Math.Round(NumberUtil.Val( GetPar( "CarritoID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
                  getEqualNoModal( ) ;
                  if ( ! (0==AV7CarritoID) )
                  {
                     A33CarritoID = AV7CarritoID;
                     AssignAttri("", false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
                  }
                  else
                  {
                     if ( IsIns( )  && (0==A33CarritoID) && ( Gx_BScreen == 0 ) )
                     {
                        A33CarritoID = 1;
                        AssignAttri("", false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
                     }
                  }
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode9 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (0==AV7CarritoID) )
                     {
                        A33CarritoID = AV7CarritoID;
                        AssignAttri("", false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
                     }
                     else
                     {
                        if ( IsIns( )  && (0==A33CarritoID) && ( Gx_BScreen == 0 ) )
                        {
                           A33CarritoID = 1;
                           AssignAttri("", false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
                        }
                     }
                     Gx_mode = sMode9;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound9 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_090( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CARRITOID");
                        AnyError = 1;
                        GX_FocusControl = edtCarritoID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11092 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12092 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E12092 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll099( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes099( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_090( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls099( ) ;
            }
            else
            {
               CheckExtendedTable099( ) ;
               CloseExtendedTableCursors099( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode9 = Gx_mode;
            CONFIRM_0910( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode9;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0910( )
      {
         s36CarritoCostoTotalCompra = O36CarritoCostoTotalCompra;
         n36CarritoCostoTotalCompra = false;
         AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
         nGXsfl_68_idx = 0;
         while ( nGXsfl_68_idx < nRC_GXsfl_68 )
         {
            ReadRow0910( ) ;
            if ( ( nRcdExists_10 != 0 ) || ( nIsMod_10 != 0 ) )
            {
               GetKey0910( ) ;
               if ( ( nRcdExists_10 == 0 ) && ( nRcdDeleted_10 == 0 ) )
               {
                  if ( RcdFound10 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0910( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0910( ) ;
                        CloseExtendedTableCursors0910( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O36CarritoCostoTotalCompra = A36CarritoCostoTotalCompra;
                        n36CarritoCostoTotalCompra = false;
                        AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
                     }
                  }
                  else
                  {
                     GXCCtl = "CARRITODETALLECOMPRAID_" + sGXsfl_68_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtCarritoDetalleCompraID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound10 != 0 )
                  {
                     if ( nRcdDeleted_10 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0910( ) ;
                        Load0910( ) ;
                        BeforeValidate0910( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0910( ) ;
                           O36CarritoCostoTotalCompra = A36CarritoCostoTotalCompra;
                           n36CarritoCostoTotalCompra = false;
                           AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
                        }
                     }
                     else
                     {
                        if ( nIsMod_10 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0910( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0910( ) ;
                              CloseExtendedTableCursors0910( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O36CarritoCostoTotalCompra = A36CarritoCostoTotalCompra;
                              n36CarritoCostoTotalCompra = false;
                              AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_10 == 0 )
                     {
                        GXCCtl = "CARRITODETALLECOMPRAID_" + sGXsfl_68_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCarritoDetalleCompraID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCarritoDetalleCompraID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A37CarritoDetalleCompraID), 6, 0, ".", ""))) ;
            ChangePostValue( edtProductoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProductoID), 6, 0, ".", ""))) ;
            ChangePostValue( edtProductoPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( A22ProductoPrecio, 10, 2, ".", ""))) ;
            ChangePostValue( edtCategoriaID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CategoriaID), 6, 0, ".", ""))) ;
            ChangePostValue( edtCarritoDetalleCompraCantidadUn_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A38CarritoDetalleCompraCantidadUn), 4, 0, ".", ""))) ;
            ChangePostValue( edtCarritoDetalleCompraCostoTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A39CarritoDetalleCompraCostoTotal, 10, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z37CarritoDetalleCompraID_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z37CarritoDetalleCompraID), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z38CarritoDetalleCompraCantidadUn_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z38CarritoDetalleCompraCantidadUn), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z19ProductoID_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19ProductoID), 6, 0, ".", ""))) ;
            ChangePostValue( "T39CarritoDetalleCompraCostoTotal_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( O39CarritoDetalleCompraCostoTotal, 10, 2, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_10_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_10), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_10_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_10), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_10_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_10), 4, 0, ".", ""))) ;
            if ( nIsMod_10 != 0 )
            {
               ChangePostValue( "CARRITODETALLECOMPRAID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCarritoDetalleCompraID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTOID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTOPRECIO_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoPrecio_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CATEGORIAID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoriaID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CARRITODETALLECOMPRACANTIDADUN_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCarritoDetalleCompraCantidadUn_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CARRITODETALLECOMPRACOSTOTOTAL_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCarritoDetalleCompraCostoTotal_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O36CarritoCostoTotalCompra = s36CarritoCostoTotalCompra;
         n36CarritoCostoTotalCompra = false;
         AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption090( )
      {
      }

      protected void E11092( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV16Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV16Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_ClienteID = 0;
         AssignAttri("", false, "AV11Insert_ClienteID", StringUtil.LTrimStr( (decimal)(AV11Insert_ClienteID), 6, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV16Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV17GXV1 = 1;
            AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            while ( AV17GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "ClienteID") == 0 )
               {
                  AV11Insert_ClienteID = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_ClienteID", StringUtil.LTrimStr( (decimal)(AV11Insert_ClienteID), 6, 0));
               }
               AV17GXV1 = (int)(AV17GXV1+1);
               AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E12092( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwcarrito.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM099( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z34CarritoFchCompra = T00096_A34CarritoFchCompra[0];
               Z9ClienteID = T00096_A9ClienteID[0];
            }
            else
            {
               Z34CarritoFchCompra = A34CarritoFchCompra;
               Z9ClienteID = A9ClienteID;
            }
         }
         if ( GX_JID == -15 )
         {
            Z33CarritoID = A33CarritoID;
            Z34CarritoFchCompra = A34CarritoFchCompra;
            Z9ClienteID = A9ClienteID;
            Z36CarritoCostoTotalCompra = A36CarritoCostoTotalCompra;
            Z10ClienteNombre = A10ClienteNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         edtCarritoID_Enabled = 0;
         AssignProp("", false, edtCarritoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarritoID_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         imgprompt_9_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CLIENTEID"+"'), id:'"+"CLIENTEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtCarritoID_Enabled = 0;
         AssignProp("", false, edtCarritoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarritoID_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ClienteID) )
         {
            edtClienteID_Enabled = 0;
            AssignProp("", false, edtClienteID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteID_Enabled), 5, 0), true);
         }
         else
         {
            edtClienteID_Enabled = 1;
            AssignProp("", false, edtClienteID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteID_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7CarritoID) )
         {
            A33CarritoID = AV7CarritoID;
            AssignAttri("", false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A33CarritoID) && ( Gx_BScreen == 0 ) )
            {
               A33CarritoID = 1;
               AssignAttri("", false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ClienteID) )
         {
            A9ClienteID = AV11Insert_ClienteID;
            AssignAttri("", false, "A9ClienteID", StringUtil.LTrimStr( (decimal)(A9ClienteID), 6, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A9ClienteID) && ( Gx_BScreen == 0 ) )
            {
               A9ClienteID = 1;
               AssignAttri("", false, "A9ClienteID", StringUtil.LTrimStr( (decimal)(A9ClienteID), 6, 0));
            }
         }
         if ( IsIns( )  && (DateTime.MinValue==A34CarritoFchCompra) && ( Gx_BScreen == 0 ) )
         {
            A34CarritoFchCompra = Gx_date;
            AssignAttri("", false, "A34CarritoFchCompra", context.localUtil.Format(A34CarritoFchCompra, "99/99/9999"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV16Pgmname = "Carrito";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T00099 */
            pr_default.execute(6, new Object[] {A33CarritoID});
            if ( (pr_default.getStatus(6) != 101) )
            {
               A36CarritoCostoTotalCompra = T00099_A36CarritoCostoTotalCompra[0];
               n36CarritoCostoTotalCompra = T00099_n36CarritoCostoTotalCompra[0];
               AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
            }
            else
            {
               A36CarritoCostoTotalCompra = 0;
               n36CarritoCostoTotalCompra = false;
               AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
            }
            O36CarritoCostoTotalCompra = A36CarritoCostoTotalCompra;
            n36CarritoCostoTotalCompra = false;
            AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
            pr_default.close(6);
            /* Using cursor T00097 */
            pr_default.execute(5, new Object[] {A9ClienteID});
            A10ClienteNombre = T00097_A10ClienteNombre[0];
            AssignAttri("", false, "A10ClienteNombre", A10ClienteNombre);
            pr_default.close(5);
            A35CarritoFchEntrega = DateTimeUtil.DAdd( A34CarritoFchCompra, (5));
            AssignAttri("", false, "A35CarritoFchEntrega", context.localUtil.Format(A35CarritoFchEntrega, "99/99/9999"));
         }
      }

      protected void Load099( )
      {
         /* Using cursor T000911 */
         pr_default.execute(7, new Object[] {A33CarritoID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound9 = 1;
            A34CarritoFchCompra = T000911_A34CarritoFchCompra[0];
            AssignAttri("", false, "A34CarritoFchCompra", context.localUtil.Format(A34CarritoFchCompra, "99/99/9999"));
            A10ClienteNombre = T000911_A10ClienteNombre[0];
            AssignAttri("", false, "A10ClienteNombre", A10ClienteNombre);
            A9ClienteID = T000911_A9ClienteID[0];
            AssignAttri("", false, "A9ClienteID", StringUtil.LTrimStr( (decimal)(A9ClienteID), 6, 0));
            A36CarritoCostoTotalCompra = T000911_A36CarritoCostoTotalCompra[0];
            n36CarritoCostoTotalCompra = T000911_n36CarritoCostoTotalCompra[0];
            AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
            ZM099( -15) ;
         }
         pr_default.close(7);
         OnLoadActions099( ) ;
      }

      protected void OnLoadActions099( )
      {
         O36CarritoCostoTotalCompra = A36CarritoCostoTotalCompra;
         n36CarritoCostoTotalCompra = false;
         AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
         AV16Pgmname = "Carrito";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         A35CarritoFchEntrega = DateTimeUtil.DAdd( A34CarritoFchCompra, (5));
         AssignAttri("", false, "A35CarritoFchEntrega", context.localUtil.Format(A35CarritoFchEntrega, "99/99/9999"));
      }

      protected void CheckExtendedTable099( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV16Pgmname = "Carrito";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         /* Using cursor T00099 */
         pr_default.execute(6, new Object[] {A33CarritoID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A36CarritoCostoTotalCompra = T00099_A36CarritoCostoTotalCompra[0];
            n36CarritoCostoTotalCompra = T00099_n36CarritoCostoTotalCompra[0];
            AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
         }
         else
         {
            A36CarritoCostoTotalCompra = 0;
            n36CarritoCostoTotalCompra = false;
            AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
         }
         pr_default.close(6);
         if ( ! ( (DateTime.MinValue==A34CarritoFchCompra) || ( DateTimeUtil.ResetTime ( A34CarritoFchCompra ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Carrito Fch Compra is out of range", "OutOfRange", 1, "CARRITOFCHCOMPRA");
            AnyError = 1;
            GX_FocusControl = edtCarritoFchCompra_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A35CarritoFchEntrega = DateTimeUtil.DAdd( A34CarritoFchCompra, (5));
         AssignAttri("", false, "A35CarritoFchEntrega", context.localUtil.Format(A35CarritoFchEntrega, "99/99/9999"));
         /* Using cursor T00097 */
         pr_default.execute(5, new Object[] {A9ClienteID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10ClienteNombre = T00097_A10ClienteNombre[0];
         AssignAttri("", false, "A10ClienteNombre", A10ClienteNombre);
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors099( )
      {
         pr_default.close(6);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_17( int A33CarritoID )
      {
         /* Using cursor T000913 */
         pr_default.execute(8, new Object[] {A33CarritoID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A36CarritoCostoTotalCompra = T000913_A36CarritoCostoTotalCompra[0];
            n36CarritoCostoTotalCompra = T000913_n36CarritoCostoTotalCompra[0];
            AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
         }
         else
         {
            A36CarritoCostoTotalCompra = 0;
            n36CarritoCostoTotalCompra = false;
            AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A36CarritoCostoTotalCompra, 10, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_16( int A9ClienteID )
      {
         /* Using cursor T000914 */
         pr_default.execute(9, new Object[] {A9ClienteID});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No matching 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10ClienteNombre = T000914_A10ClienteNombre[0];
         AssignAttri("", false, "A10ClienteNombre", A10ClienteNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A10ClienteNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void GetKey099( )
      {
         /* Using cursor T000915 */
         pr_default.execute(10, new Object[] {A33CarritoID});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00096 */
         pr_default.execute(4, new Object[] {A33CarritoID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM099( 15) ;
            RcdFound9 = 1;
            A33CarritoID = T00096_A33CarritoID[0];
            AssignAttri("", false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
            A34CarritoFchCompra = T00096_A34CarritoFchCompra[0];
            AssignAttri("", false, "A34CarritoFchCompra", context.localUtil.Format(A34CarritoFchCompra, "99/99/9999"));
            A9ClienteID = T00096_A9ClienteID[0];
            AssignAttri("", false, "A9ClienteID", StringUtil.LTrimStr( (decimal)(A9ClienteID), 6, 0));
            Z33CarritoID = A33CarritoID;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load099( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey099( ) ;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey099( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey099( ) ;
         if ( RcdFound9 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound9 = 0;
         /* Using cursor T000916 */
         pr_default.execute(11, new Object[] {A33CarritoID});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000916_A33CarritoID[0] < A33CarritoID ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000916_A33CarritoID[0] > A33CarritoID ) ) )
            {
               A33CarritoID = T000916_A33CarritoID[0];
               AssignAttri("", false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T000917 */
         pr_default.execute(12, new Object[] {A33CarritoID});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T000917_A33CarritoID[0] > A33CarritoID ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T000917_A33CarritoID[0] < A33CarritoID ) ) )
            {
               A33CarritoID = T000917_A33CarritoID[0];
               AssignAttri("", false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey099( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A36CarritoCostoTotalCompra = O36CarritoCostoTotalCompra;
            n36CarritoCostoTotalCompra = false;
            AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
            GX_FocusControl = edtCarritoFchCompra_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert099( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A33CarritoID != Z33CarritoID )
               {
                  A33CarritoID = Z33CarritoID;
                  AssignAttri("", false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CARRITOID");
                  AnyError = 1;
                  GX_FocusControl = edtCarritoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A36CarritoCostoTotalCompra = O36CarritoCostoTotalCompra;
                  n36CarritoCostoTotalCompra = false;
                  AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCarritoFchCompra_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A36CarritoCostoTotalCompra = O36CarritoCostoTotalCompra;
                  n36CarritoCostoTotalCompra = false;
                  AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
                  Update099( ) ;
                  GX_FocusControl = edtCarritoFchCompra_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A33CarritoID != Z33CarritoID )
               {
                  /* Insert record */
                  A36CarritoCostoTotalCompra = O36CarritoCostoTotalCompra;
                  n36CarritoCostoTotalCompra = false;
                  AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
                  GX_FocusControl = edtCarritoFchCompra_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert099( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CARRITOID");
                     AnyError = 1;
                     GX_FocusControl = edtCarritoID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A36CarritoCostoTotalCompra = O36CarritoCostoTotalCompra;
                     n36CarritoCostoTotalCompra = false;
                     AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
                     GX_FocusControl = edtCarritoFchCompra_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert099( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A33CarritoID != Z33CarritoID )
         {
            A33CarritoID = Z33CarritoID;
            AssignAttri("", false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CARRITOID");
            AnyError = 1;
            GX_FocusControl = edtCarritoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A36CarritoCostoTotalCompra = O36CarritoCostoTotalCompra;
            n36CarritoCostoTotalCompra = false;
            AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCarritoFchCompra_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency099( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00095 */
            pr_default.execute(3, new Object[] {A33CarritoID});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Carrito"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( DateTimeUtil.ResetTime ( Z34CarritoFchCompra ) != DateTimeUtil.ResetTime ( T00095_A34CarritoFchCompra[0] ) ) || ( Z9ClienteID != T00095_A9ClienteID[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z34CarritoFchCompra ) != DateTimeUtil.ResetTime ( T00095_A34CarritoFchCompra[0] ) )
               {
                  GXUtil.WriteLog("carrito:[seudo value changed for attri]"+"CarritoFchCompra");
                  GXUtil.WriteLogRaw("Old: ",Z34CarritoFchCompra);
                  GXUtil.WriteLogRaw("Current: ",T00095_A34CarritoFchCompra[0]);
               }
               if ( Z9ClienteID != T00095_A9ClienteID[0] )
               {
                  GXUtil.WriteLog("carrito:[seudo value changed for attri]"+"ClienteID");
                  GXUtil.WriteLogRaw("Old: ",Z9ClienteID);
                  GXUtil.WriteLogRaw("Current: ",T00095_A9ClienteID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Carrito"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM099( 0) ;
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000918 */
                     pr_default.execute(13, new Object[] {A34CarritoFchCompra, A9ClienteID});
                     A33CarritoID = T000918_A33CarritoID[0];
                     AssignAttri("", false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Carrito");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel099( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load099( ) ;
            }
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void Update099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000919 */
                     pr_default.execute(14, new Object[] {A34CarritoFchCompra, A9ClienteID, A33CarritoID});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Carrito");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Carrito"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate099( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel099( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void DeferredUpdate099( )
      {
      }

      protected void delete( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls099( ) ;
            AfterConfirm099( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete099( ) ;
               if ( AnyError == 0 )
               {
                  A36CarritoCostoTotalCompra = O36CarritoCostoTotalCompra;
                  n36CarritoCostoTotalCompra = false;
                  AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
                  ScanStart0910( ) ;
                  while ( RcdFound10 != 0 )
                  {
                     getByPrimaryKey0910( ) ;
                     Delete0910( ) ;
                     ScanNext0910( ) ;
                     O36CarritoCostoTotalCompra = A36CarritoCostoTotalCompra;
                     n36CarritoCostoTotalCompra = false;
                     AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
                  }
                  ScanEnd0910( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000920 */
                     pr_default.execute(15, new Object[] {A33CarritoID});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Carrito");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
         }
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel099( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls099( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV16Pgmname = "Carrito";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T000922 */
            pr_default.execute(16, new Object[] {A33CarritoID});
            if ( (pr_default.getStatus(16) != 101) )
            {
               A36CarritoCostoTotalCompra = T000922_A36CarritoCostoTotalCompra[0];
               n36CarritoCostoTotalCompra = T000922_n36CarritoCostoTotalCompra[0];
               AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
            }
            else
            {
               A36CarritoCostoTotalCompra = 0;
               n36CarritoCostoTotalCompra = false;
               AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
            }
            pr_default.close(16);
            A35CarritoFchEntrega = DateTimeUtil.DAdd( A34CarritoFchCompra, (5));
            AssignAttri("", false, "A35CarritoFchEntrega", context.localUtil.Format(A35CarritoFchEntrega, "99/99/9999"));
            /* Using cursor T000923 */
            pr_default.execute(17, new Object[] {A9ClienteID});
            A10ClienteNombre = T000923_A10ClienteNombre[0];
            AssignAttri("", false, "A10ClienteNombre", A10ClienteNombre);
            pr_default.close(17);
         }
      }

      protected void ProcessNestedLevel0910( )
      {
         s36CarritoCostoTotalCompra = O36CarritoCostoTotalCompra;
         n36CarritoCostoTotalCompra = false;
         AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
         nGXsfl_68_idx = 0;
         while ( nGXsfl_68_idx < nRC_GXsfl_68 )
         {
            ReadRow0910( ) ;
            if ( ( nRcdExists_10 != 0 ) || ( nIsMod_10 != 0 ) )
            {
               standaloneNotModal0910( ) ;
               GetKey0910( ) ;
               if ( ( nRcdExists_10 == 0 ) && ( nRcdDeleted_10 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0910( ) ;
               }
               else
               {
                  if ( RcdFound10 != 0 )
                  {
                     if ( ( nRcdDeleted_10 != 0 ) && ( nRcdExists_10 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0910( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_10 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0910( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_10 == 0 )
                     {
                        GXCCtl = "CARRITODETALLECOMPRAID_" + sGXsfl_68_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCarritoDetalleCompraID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O36CarritoCostoTotalCompra = A36CarritoCostoTotalCompra;
               n36CarritoCostoTotalCompra = false;
               AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
            }
            ChangePostValue( edtCarritoDetalleCompraID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A37CarritoDetalleCompraID), 6, 0, ".", ""))) ;
            ChangePostValue( edtProductoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProductoID), 6, 0, ".", ""))) ;
            ChangePostValue( edtProductoPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( A22ProductoPrecio, 10, 2, ".", ""))) ;
            ChangePostValue( edtCategoriaID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CategoriaID), 6, 0, ".", ""))) ;
            ChangePostValue( edtCarritoDetalleCompraCantidadUn_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A38CarritoDetalleCompraCantidadUn), 4, 0, ".", ""))) ;
            ChangePostValue( edtCarritoDetalleCompraCostoTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A39CarritoDetalleCompraCostoTotal, 10, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z37CarritoDetalleCompraID_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z37CarritoDetalleCompraID), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z38CarritoDetalleCompraCantidadUn_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z38CarritoDetalleCompraCantidadUn), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z19ProductoID_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19ProductoID), 6, 0, ".", ""))) ;
            ChangePostValue( "T39CarritoDetalleCompraCostoTotal_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( O39CarritoDetalleCompraCostoTotal, 10, 2, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_10_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_10), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_10_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_10), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_10_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_10), 4, 0, ".", ""))) ;
            if ( nIsMod_10 != 0 )
            {
               ChangePostValue( "CARRITODETALLECOMPRAID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCarritoDetalleCompraID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTOID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTOPRECIO_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoPrecio_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CATEGORIAID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoriaID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CARRITODETALLECOMPRACANTIDADUN_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCarritoDetalleCompraCantidadUn_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CARRITODETALLECOMPRACOSTOTOTAL_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCarritoDetalleCompraCostoTotal_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0910( ) ;
         if ( AnyError != 0 )
         {
            O36CarritoCostoTotalCompra = s36CarritoCostoTotalCompra;
            n36CarritoCostoTotalCompra = false;
            AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
         }
         nRcdExists_10 = 0;
         nIsMod_10 = 0;
         nRcdDeleted_10 = 0;
      }

      protected void ProcessLevel099( )
      {
         /* Save parent mode. */
         sMode9 = Gx_mode;
         ProcessNestedLevel0910( ) ;
         if ( AnyError != 0 )
         {
            O36CarritoCostoTotalCompra = s36CarritoCostoTotalCompra;
            n36CarritoCostoTotalCompra = false;
            AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
         }
         /* Restore parent mode. */
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel099( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete099( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(17);
            pr_default.close(16);
            pr_default.close(2);
            context.CommitDataStores("carrito",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues090( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(17);
            pr_default.close(16);
            pr_default.close(2);
            context.RollbackDataStores("carrito",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart099( )
      {
         /* Scan By routine */
         /* Using cursor T000924 */
         pr_default.execute(18);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound9 = 1;
            A33CarritoID = T000924_A33CarritoID[0];
            AssignAttri("", false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext099( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound9 = 1;
            A33CarritoID = T000924_A33CarritoID[0];
            AssignAttri("", false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
         }
      }

      protected void ScanEnd099( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm099( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert099( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate099( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete099( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete099( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate099( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes099( )
      {
         edtCarritoID_Enabled = 0;
         AssignProp("", false, edtCarritoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarritoID_Enabled), 5, 0), true);
         edtCarritoFchCompra_Enabled = 0;
         AssignProp("", false, edtCarritoFchCompra_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarritoFchCompra_Enabled), 5, 0), true);
         edtCarritoFchEntrega_Enabled = 0;
         AssignProp("", false, edtCarritoFchEntrega_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarritoFchEntrega_Enabled), 5, 0), true);
         edtClienteID_Enabled = 0;
         AssignProp("", false, edtClienteID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteID_Enabled), 5, 0), true);
         edtClienteNombre_Enabled = 0;
         AssignProp("", false, edtClienteNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteNombre_Enabled), 5, 0), true);
         edtCarritoCostoTotalCompra_Enabled = 0;
         AssignProp("", false, edtCarritoCostoTotalCompra_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarritoCostoTotalCompra_Enabled), 5, 0), true);
      }

      protected void ZM0910( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z38CarritoDetalleCompraCantidadUn = T00093_A38CarritoDetalleCompraCantidadUn[0];
               Z19ProductoID = T00093_A19ProductoID[0];
            }
            else
            {
               Z38CarritoDetalleCompraCantidadUn = A38CarritoDetalleCompraCantidadUn;
               Z19ProductoID = A19ProductoID;
            }
         }
         if ( GX_JID == -18 )
         {
            Z33CarritoID = A33CarritoID;
            Z37CarritoDetalleCompraID = A37CarritoDetalleCompraID;
            Z38CarritoDetalleCompraCantidadUn = A38CarritoDetalleCompraCantidadUn;
            Z19ProductoID = A19ProductoID;
            Z22ProductoPrecio = A22ProductoPrecio;
            Z4CategoriaID = A4CategoriaID;
         }
      }

      protected void standaloneNotModal0910( )
      {
      }

      protected void standaloneModal0910( )
      {
         if ( IsIns( )  && (0==A19ProductoID) && ( Gx_BScreen == 0 ) )
         {
            A19ProductoID = 1;
         }
         if ( IsIns( )  && (0==A37CarritoDetalleCompraID) && ( Gx_BScreen == 0 ) )
         {
            A37CarritoDetalleCompraID = 1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtCarritoDetalleCompraID_Enabled = 0;
            AssignProp("", false, edtCarritoDetalleCompraID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarritoDetalleCompraID_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         }
         else
         {
            edtCarritoDetalleCompraID_Enabled = 1;
            AssignProp("", false, edtCarritoDetalleCompraID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarritoDetalleCompraID_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00094 */
            pr_default.execute(2, new Object[] {A19ProductoID});
            A22ProductoPrecio = T00094_A22ProductoPrecio[0];
            A4CategoriaID = T00094_A4CategoriaID[0];
            pr_default.close(2);
         }
      }

      protected void Load0910( )
      {
         /* Using cursor T000925 */
         pr_default.execute(19, new Object[] {A33CarritoID, A37CarritoDetalleCompraID});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound10 = 1;
            A22ProductoPrecio = T000925_A22ProductoPrecio[0];
            A38CarritoDetalleCompraCantidadUn = T000925_A38CarritoDetalleCompraCantidadUn[0];
            A19ProductoID = T000925_A19ProductoID[0];
            A4CategoriaID = T000925_A4CategoriaID[0];
            ZM0910( -18) ;
         }
         pr_default.close(19);
         OnLoadActions0910( ) ;
      }

      protected void OnLoadActions0910( )
      {
         A39CarritoDetalleCompraCostoTotal = (decimal)(A22ProductoPrecio*A38CarritoDetalleCompraCantidadUn);
         O39CarritoDetalleCompraCostoTotal = A39CarritoDetalleCompraCostoTotal;
         if ( IsIns( )  )
         {
            A36CarritoCostoTotalCompra = (decimal)(O36CarritoCostoTotalCompra+A39CarritoDetalleCompraCostoTotal);
            n36CarritoCostoTotalCompra = false;
            AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A36CarritoCostoTotalCompra = (decimal)(O36CarritoCostoTotalCompra+A39CarritoDetalleCompraCostoTotal-O39CarritoDetalleCompraCostoTotal);
               n36CarritoCostoTotalCompra = false;
               AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A36CarritoCostoTotalCompra = (decimal)(O36CarritoCostoTotalCompra-O39CarritoDetalleCompraCostoTotal);
                  n36CarritoCostoTotalCompra = false;
                  AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
               }
            }
         }
      }

      protected void CheckExtendedTable0910( )
      {
         nIsDirty_10 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0910( ) ;
         /* Using cursor T00094 */
         pr_default.execute(2, new Object[] {A19ProductoID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PRODUCTOID_" + sGXsfl_68_idx;
            GX_msglist.addItem("No matching 'Producto'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A22ProductoPrecio = T00094_A22ProductoPrecio[0];
         A4CategoriaID = T00094_A4CategoriaID[0];
         pr_default.close(2);
         nIsDirty_10 = 1;
         A39CarritoDetalleCompraCostoTotal = (decimal)(A22ProductoPrecio*A38CarritoDetalleCompraCantidadUn);
         if ( IsIns( )  )
         {
            nIsDirty_10 = 1;
            A36CarritoCostoTotalCompra = (decimal)(O36CarritoCostoTotalCompra+A39CarritoDetalleCompraCostoTotal);
            n36CarritoCostoTotalCompra = false;
            AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_10 = 1;
               A36CarritoCostoTotalCompra = (decimal)(O36CarritoCostoTotalCompra+A39CarritoDetalleCompraCostoTotal-O39CarritoDetalleCompraCostoTotal);
               n36CarritoCostoTotalCompra = false;
               AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_10 = 1;
                  A36CarritoCostoTotalCompra = (decimal)(O36CarritoCostoTotalCompra-O39CarritoDetalleCompraCostoTotal);
                  n36CarritoCostoTotalCompra = false;
                  AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
               }
            }
         }
      }

      protected void CloseExtendedTableCursors0910( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0910( )
      {
      }

      protected void gxLoad_19( int A19ProductoID )
      {
         /* Using cursor T000926 */
         pr_default.execute(20, new Object[] {A19ProductoID});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GXCCtl = "PRODUCTOID_" + sGXsfl_68_idx;
            GX_msglist.addItem("No matching 'Producto'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A22ProductoPrecio = T000926_A22ProductoPrecio[0];
         A4CategoriaID = T000926_A4CategoriaID[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A22ProductoPrecio, 10, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CategoriaID), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void GetKey0910( )
      {
         /* Using cursor T000927 */
         pr_default.execute(21, new Object[] {A33CarritoID, A37CarritoDetalleCompraID});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey0910( )
      {
         /* Using cursor T00093 */
         pr_default.execute(1, new Object[] {A33CarritoID, A37CarritoDetalleCompraID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0910( 18) ;
            RcdFound10 = 1;
            InitializeNonKey0910( ) ;
            A37CarritoDetalleCompraID = T00093_A37CarritoDetalleCompraID[0];
            A38CarritoDetalleCompraCantidadUn = T00093_A38CarritoDetalleCompraCantidadUn[0];
            A19ProductoID = T00093_A19ProductoID[0];
            Z33CarritoID = A33CarritoID;
            Z37CarritoDetalleCompraID = A37CarritoDetalleCompraID;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0910( ) ;
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0910( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0910( ) ;
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0910( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0910( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00092 */
            pr_default.execute(0, new Object[] {A33CarritoID, A37CarritoDetalleCompraID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CarritoDetalleCompra"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z38CarritoDetalleCompraCantidadUn != T00092_A38CarritoDetalleCompraCantidadUn[0] ) || ( Z19ProductoID != T00092_A19ProductoID[0] ) )
            {
               if ( Z38CarritoDetalleCompraCantidadUn != T00092_A38CarritoDetalleCompraCantidadUn[0] )
               {
                  GXUtil.WriteLog("carrito:[seudo value changed for attri]"+"CarritoDetalleCompraCantidadUn");
                  GXUtil.WriteLogRaw("Old: ",Z38CarritoDetalleCompraCantidadUn);
                  GXUtil.WriteLogRaw("Current: ",T00092_A38CarritoDetalleCompraCantidadUn[0]);
               }
               if ( Z19ProductoID != T00092_A19ProductoID[0] )
               {
                  GXUtil.WriteLog("carrito:[seudo value changed for attri]"+"ProductoID");
                  GXUtil.WriteLogRaw("Old: ",Z19ProductoID);
                  GXUtil.WriteLogRaw("Current: ",T00092_A19ProductoID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CarritoDetalleCompra"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0910( )
      {
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0910( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0910( 0) ;
            CheckOptimisticConcurrency0910( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0910( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0910( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000928 */
                     pr_default.execute(22, new Object[] {A33CarritoID, A37CarritoDetalleCompraID, A38CarritoDetalleCompraCantidadUn, A19ProductoID});
                     pr_default.close(22);
                     pr_default.SmartCacheProvider.SetUpdated("CarritoDetalleCompra");
                     if ( (pr_default.getStatus(22) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0910( ) ;
            }
            EndLevel0910( ) ;
         }
         CloseExtendedTableCursors0910( ) ;
      }

      protected void Update0910( )
      {
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0910( ) ;
         }
         if ( ( nIsMod_10 != 0 ) || ( nIsDirty_10 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0910( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0910( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0910( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000929 */
                        pr_default.execute(23, new Object[] {A38CarritoDetalleCompraCantidadUn, A19ProductoID, A33CarritoID, A37CarritoDetalleCompraID});
                        pr_default.close(23);
                        pr_default.SmartCacheProvider.SetUpdated("CarritoDetalleCompra");
                        if ( (pr_default.getStatus(23) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CarritoDetalleCompra"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0910( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0910( ) ;
                           }
                        }
                        else
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                           AnyError = 1;
                        }
                     }
                  }
               }
               EndLevel0910( ) ;
            }
         }
         CloseExtendedTableCursors0910( ) ;
      }

      protected void DeferredUpdate0910( )
      {
      }

      protected void Delete0910( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0910( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0910( ) ;
            AfterConfirm0910( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0910( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000930 */
                  pr_default.execute(24, new Object[] {A33CarritoID, A37CarritoDetalleCompraID});
                  pr_default.close(24);
                  pr_default.SmartCacheProvider.SetUpdated("CarritoDetalleCompra");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0910( ) ;
         Gx_mode = sMode10;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0910( )
      {
         standaloneModal0910( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000931 */
            pr_default.execute(25, new Object[] {A19ProductoID});
            A22ProductoPrecio = T000931_A22ProductoPrecio[0];
            A4CategoriaID = T000931_A4CategoriaID[0];
            pr_default.close(25);
            A39CarritoDetalleCompraCostoTotal = (decimal)(A22ProductoPrecio*A38CarritoDetalleCompraCantidadUn);
            if ( IsIns( )  )
            {
               A36CarritoCostoTotalCompra = (decimal)(O36CarritoCostoTotalCompra+A39CarritoDetalleCompraCostoTotal);
               n36CarritoCostoTotalCompra = false;
               AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A36CarritoCostoTotalCompra = (decimal)(O36CarritoCostoTotalCompra+A39CarritoDetalleCompraCostoTotal-O39CarritoDetalleCompraCostoTotal);
                  n36CarritoCostoTotalCompra = false;
                  AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A36CarritoCostoTotalCompra = (decimal)(O36CarritoCostoTotalCompra-O39CarritoDetalleCompraCostoTotal);
                     n36CarritoCostoTotalCompra = false;
                     AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
                  }
               }
            }
         }
      }

      protected void EndLevel0910( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0910( )
      {
         /* Scan By routine */
         /* Using cursor T000932 */
         pr_default.execute(26, new Object[] {A33CarritoID});
         RcdFound10 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound10 = 1;
            A37CarritoDetalleCompraID = T000932_A37CarritoDetalleCompraID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0910( )
      {
         /* Scan next routine */
         pr_default.readNext(26);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound10 = 1;
            A37CarritoDetalleCompraID = T000932_A37CarritoDetalleCompraID[0];
         }
      }

      protected void ScanEnd0910( )
      {
         pr_default.close(26);
      }

      protected void AfterConfirm0910( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0910( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0910( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0910( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0910( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0910( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0910( )
      {
         edtCarritoDetalleCompraID_Enabled = 0;
         AssignProp("", false, edtCarritoDetalleCompraID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarritoDetalleCompraID_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtProductoID_Enabled = 0;
         AssignProp("", false, edtProductoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoID_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtProductoPrecio_Enabled = 0;
         AssignProp("", false, edtProductoPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoPrecio_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtCategoriaID_Enabled = 0;
         AssignProp("", false, edtCategoriaID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaID_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtCarritoDetalleCompraCantidadUn_Enabled = 0;
         AssignProp("", false, edtCarritoDetalleCompraCantidadUn_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarritoDetalleCompraCantidadUn_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtCarritoDetalleCompraCostoTotal_Enabled = 0;
         AssignProp("", false, edtCarritoDetalleCompraCostoTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarritoDetalleCompraCostoTotal_Enabled), 5, 0), !bGXsfl_68_Refreshing);
      }

      protected void send_integrity_lvl_hashes0910( )
      {
      }

      protected void send_integrity_lvl_hashes099( )
      {
      }

      protected void SubsflControlProps_6810( )
      {
         edtCarritoDetalleCompraID_Internalname = "CARRITODETALLECOMPRAID_"+sGXsfl_68_idx;
         edtProductoID_Internalname = "PRODUCTOID_"+sGXsfl_68_idx;
         imgprompt_19_Internalname = "PROMPT_19_"+sGXsfl_68_idx;
         edtProductoPrecio_Internalname = "PRODUCTOPRECIO_"+sGXsfl_68_idx;
         edtCategoriaID_Internalname = "CATEGORIAID_"+sGXsfl_68_idx;
         edtCarritoDetalleCompraCantidadUn_Internalname = "CARRITODETALLECOMPRACANTIDADUN_"+sGXsfl_68_idx;
         edtCarritoDetalleCompraCostoTotal_Internalname = "CARRITODETALLECOMPRACOSTOTOTAL_"+sGXsfl_68_idx;
      }

      protected void SubsflControlProps_fel_6810( )
      {
         edtCarritoDetalleCompraID_Internalname = "CARRITODETALLECOMPRAID_"+sGXsfl_68_fel_idx;
         edtProductoID_Internalname = "PRODUCTOID_"+sGXsfl_68_fel_idx;
         imgprompt_19_Internalname = "PROMPT_19_"+sGXsfl_68_fel_idx;
         edtProductoPrecio_Internalname = "PRODUCTOPRECIO_"+sGXsfl_68_fel_idx;
         edtCategoriaID_Internalname = "CATEGORIAID_"+sGXsfl_68_fel_idx;
         edtCarritoDetalleCompraCantidadUn_Internalname = "CARRITODETALLECOMPRACANTIDADUN_"+sGXsfl_68_fel_idx;
         edtCarritoDetalleCompraCostoTotal_Internalname = "CARRITODETALLECOMPRACOSTOTOTAL_"+sGXsfl_68_fel_idx;
      }

      protected void AddRow0910( )
      {
         nGXsfl_68_idx = (int)(nGXsfl_68_idx+1);
         sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
         SubsflControlProps_6810( ) ;
         SendRow0910( ) ;
      }

      protected void SendRow0910( )
      {
         Gridcarrito_detallecompraRow = GXWebRow.GetNew(context);
         if ( subGridcarrito_detallecompra_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridcarrito_detallecompra_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridcarrito_detallecompra_Class, "") != 0 )
            {
               subGridcarrito_detallecompra_Linesclass = subGridcarrito_detallecompra_Class+"Odd";
            }
         }
         else if ( subGridcarrito_detallecompra_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridcarrito_detallecompra_Backstyle = 0;
            subGridcarrito_detallecompra_Backcolor = subGridcarrito_detallecompra_Allbackcolor;
            if ( StringUtil.StrCmp(subGridcarrito_detallecompra_Class, "") != 0 )
            {
               subGridcarrito_detallecompra_Linesclass = subGridcarrito_detallecompra_Class+"Uniform";
            }
         }
         else if ( subGridcarrito_detallecompra_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridcarrito_detallecompra_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridcarrito_detallecompra_Class, "") != 0 )
            {
               subGridcarrito_detallecompra_Linesclass = subGridcarrito_detallecompra_Class+"Odd";
            }
            subGridcarrito_detallecompra_Backcolor = (int)(0x0);
         }
         else if ( subGridcarrito_detallecompra_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridcarrito_detallecompra_Backstyle = 1;
            if ( ((int)((nGXsfl_68_idx) % (2))) == 0 )
            {
               subGridcarrito_detallecompra_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridcarrito_detallecompra_Class, "") != 0 )
               {
                  subGridcarrito_detallecompra_Linesclass = subGridcarrito_detallecompra_Class+"Even";
               }
            }
            else
            {
               subGridcarrito_detallecompra_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridcarrito_detallecompra_Class, "") != 0 )
               {
                  subGridcarrito_detallecompra_Linesclass = subGridcarrito_detallecompra_Class+"Odd";
               }
            }
         }
         imgprompt_19_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0070.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTOID_"+sGXsfl_68_idx+"'), id:'"+"PRODUCTOID_"+sGXsfl_68_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_10_"+sGXsfl_68_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_10_" + sGXsfl_68_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_68_idx + "',68)\"";
         ROClassString = "Attribute";
         Gridcarrito_detallecompraRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCarritoDetalleCompraID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A37CarritoDetalleCompraID), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A37CarritoDetalleCompraID), "ZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,69);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCarritoDetalleCompraID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCarritoDetalleCompraID_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)68,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_10_" + sGXsfl_68_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 70,'',false,'" + sGXsfl_68_idx + "',68)\"";
         ROClassString = "Attribute";
         Gridcarrito_detallecompraRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductoID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProductoID), 6, 0, ".", "")),StringUtil.LTrim( ((edtProductoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A19ProductoID), "ZZZZZ9") : context.localUtil.Format( (decimal)(A19ProductoID), "ZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,70);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductoID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductoID_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)68,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_19_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_19_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridcarrito_detallecompraRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_19_Internalname,(string)sImgUrl,(string)imgprompt_19_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_19_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_10_" + sGXsfl_68_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_68_idx + "',68)\"";
         ROClassString = "Attribute";
         Gridcarrito_detallecompraRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductoPrecio_Internalname,StringUtil.LTrim( StringUtil.NToC( A22ProductoPrecio, 10, 2, ".", "")),StringUtil.LTrim( ((edtProductoPrecio_Enabled!=0) ? context.localUtil.Format( A22ProductoPrecio, "ZZZZZZ9.99") : context.localUtil.Format( A22ProductoPrecio, "ZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,71);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductoPrecio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductoPrecio_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)68,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_10_" + sGXsfl_68_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 72,'',false,'" + sGXsfl_68_idx + "',68)\"";
         ROClassString = "Attribute";
         Gridcarrito_detallecompraRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoriaID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CategoriaID), 6, 0, ".", "")),StringUtil.LTrim( ((edtCategoriaID_Enabled!=0) ? context.localUtil.Format( (decimal)(A4CategoriaID), "ZZZZZ9") : context.localUtil.Format( (decimal)(A4CategoriaID), "ZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,72);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoriaID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCategoriaID_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)68,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_10_" + sGXsfl_68_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_68_idx + "',68)\"";
         ROClassString = "Attribute";
         Gridcarrito_detallecompraRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCarritoDetalleCompraCantidadUn_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A38CarritoDetalleCompraCantidadUn), 4, 0, ".", "")),StringUtil.LTrim( ((edtCarritoDetalleCompraCantidadUn_Enabled!=0) ? context.localUtil.Format( (decimal)(A38CarritoDetalleCompraCantidadUn), "ZZZ9") : context.localUtil.Format( (decimal)(A38CarritoDetalleCompraCantidadUn), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,73);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCarritoDetalleCompraCantidadUn_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCarritoDetalleCompraCantidadUn_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)68,(short)0,(short)-1,(short)0,(bool)true,(string)"Cantidad",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_10_" + sGXsfl_68_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_68_idx + "',68)\"";
         ROClassString = "Attribute";
         Gridcarrito_detallecompraRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCarritoDetalleCompraCostoTotal_Internalname,StringUtil.LTrim( StringUtil.NToC( A39CarritoDetalleCompraCostoTotal, 10, 2, ".", "")),StringUtil.LTrim( ((edtCarritoDetalleCompraCostoTotal_Enabled!=0) ? context.localUtil.Format( A39CarritoDetalleCompraCostoTotal, "ZZZZZZ9.99") : context.localUtil.Format( A39CarritoDetalleCompraCostoTotal, "ZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,74);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCarritoDetalleCompraCostoTotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCarritoDetalleCompraCostoTotal_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)68,(short)0,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"end",(bool)false,(string)""});
         ajax_sending_grid_row(Gridcarrito_detallecompraRow);
         send_integrity_lvl_hashes0910( ) ;
         GXCCtl = "Z37CarritoDetalleCompraID_" + sGXsfl_68_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z37CarritoDetalleCompraID), 6, 0, ".", "")));
         GXCCtl = "Z38CarritoDetalleCompraCantidadUn_" + sGXsfl_68_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z38CarritoDetalleCompraCantidadUn), 4, 0, ".", "")));
         GXCCtl = "Z19ProductoID_" + sGXsfl_68_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19ProductoID), 6, 0, ".", "")));
         GXCCtl = "O39CarritoDetalleCompraCostoTotal_" + sGXsfl_68_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( O39CarritoDetalleCompraCostoTotal, 10, 2, ".", "")));
         GXCCtl = "nRcdDeleted_10_" + sGXsfl_68_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_10), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_10_" + sGXsfl_68_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_10), 4, 0, ".", "")));
         GXCCtl = "nIsMod_10_" + sGXsfl_68_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_10), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_68_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_68_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vCARRITOID_" + sGXsfl_68_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CarritoID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARRITODETALLECOMPRAID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCarritoDetalleCompraID_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTOID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoID_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTOPRECIO_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoPrecio_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CATEGORIAID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoriaID_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARRITODETALLECOMPRACANTIDADUN_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCarritoDetalleCompraCantidadUn_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARRITODETALLECOMPRACOSTOTOTAL_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCarritoDetalleCompraCostoTotal_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_19_"+sGXsfl_68_idx+"Link", StringUtil.RTrim( imgprompt_19_Link));
         ajax_sending_grid_row(null);
         Gridcarrito_detallecompraContainer.AddRow(Gridcarrito_detallecompraRow);
      }

      protected void ReadRow0910( )
      {
         nGXsfl_68_idx = (int)(nGXsfl_68_idx+1);
         sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
         SubsflControlProps_6810( ) ;
         edtCarritoDetalleCompraID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARRITODETALLECOMPRAID_"+sGXsfl_68_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtProductoID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOID_"+sGXsfl_68_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtProductoPrecio_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTOPRECIO_"+sGXsfl_68_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtCategoriaID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CATEGORIAID_"+sGXsfl_68_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtCarritoDetalleCompraCantidadUn_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARRITODETALLECOMPRACANTIDADUN_"+sGXsfl_68_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtCarritoDetalleCompraCostoTotal_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARRITODETALLECOMPRACOSTOTOTAL_"+sGXsfl_68_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         imgprompt_9_Link = cgiGet( "PROMPT_19_"+sGXsfl_68_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtCarritoDetalleCompraID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCarritoDetalleCompraID_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "CARRITODETALLECOMPRAID_" + sGXsfl_68_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCarritoDetalleCompraID_Internalname;
            wbErr = true;
            A37CarritoDetalleCompraID = 0;
         }
         else
         {
            A37CarritoDetalleCompraID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCarritoDetalleCompraID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtProductoID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductoID_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "PRODUCTOID_" + sGXsfl_68_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductoID_Internalname;
            wbErr = true;
            A19ProductoID = 0;
         }
         else
         {
            A19ProductoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductoID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         }
         A22ProductoPrecio = context.localUtil.CToN( cgiGet( edtProductoPrecio_Internalname), ".", ",");
         A4CategoriaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCategoriaID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtCarritoDetalleCompraCantidadUn_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCarritoDetalleCompraCantidadUn_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "CARRITODETALLECOMPRACANTIDADUN_" + sGXsfl_68_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCarritoDetalleCompraCantidadUn_Internalname;
            wbErr = true;
            A38CarritoDetalleCompraCantidadUn = 0;
         }
         else
         {
            A38CarritoDetalleCompraCantidadUn = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCarritoDetalleCompraCantidadUn_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         }
         A39CarritoDetalleCompraCostoTotal = context.localUtil.CToN( cgiGet( edtCarritoDetalleCompraCostoTotal_Internalname), ".", ",");
         GXCCtl = "Z37CarritoDetalleCompraID_" + sGXsfl_68_idx;
         Z37CarritoDetalleCompraID = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "Z38CarritoDetalleCompraCantidadUn_" + sGXsfl_68_idx;
         Z38CarritoDetalleCompraCantidadUn = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "Z19ProductoID_" + sGXsfl_68_idx;
         Z19ProductoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "O39CarritoDetalleCompraCostoTotal_" + sGXsfl_68_idx;
         O39CarritoDetalleCompraCostoTotal = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "nRcdDeleted_10_" + sGXsfl_68_idx;
         nRcdDeleted_10 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_10_" + sGXsfl_68_idx;
         nRcdExists_10 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_10_" + sGXsfl_68_idx;
         nIsMod_10 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtCarritoDetalleCompraID_Enabled = edtCarritoDetalleCompraID_Enabled;
      }

      protected void ConfirmValues090( )
      {
         nGXsfl_68_idx = 0;
         sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
         SubsflControlProps_6810( ) ;
         while ( nGXsfl_68_idx < nRC_GXsfl_68 )
         {
            nGXsfl_68_idx = (int)(nGXsfl_68_idx+1);
            sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
            SubsflControlProps_6810( ) ;
            ChangePostValue( "Z37CarritoDetalleCompraID_"+sGXsfl_68_idx, cgiGet( "ZT_"+"Z37CarritoDetalleCompraID_"+sGXsfl_68_idx)) ;
            DeletePostValue( "ZT_"+"Z37CarritoDetalleCompraID_"+sGXsfl_68_idx) ;
            ChangePostValue( "Z38CarritoDetalleCompraCantidadUn_"+sGXsfl_68_idx, cgiGet( "ZT_"+"Z38CarritoDetalleCompraCantidadUn_"+sGXsfl_68_idx)) ;
            DeletePostValue( "ZT_"+"Z38CarritoDetalleCompraCantidadUn_"+sGXsfl_68_idx) ;
            ChangePostValue( "Z19ProductoID_"+sGXsfl_68_idx, cgiGet( "ZT_"+"Z19ProductoID_"+sGXsfl_68_idx)) ;
            DeletePostValue( "ZT_"+"Z19ProductoID_"+sGXsfl_68_idx) ;
         }
         ChangePostValue( "O39CarritoDetalleCompraCostoTotal", cgiGet( "T39CarritoDetalleCompraCostoTotal")) ;
         DeletePostValue( "T39CarritoDetalleCompraCostoTotal") ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 239440), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("carrito.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7CarritoID,6,0))}, new string[] {"Gx_mode","CarritoID"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Carrito");
         forbiddenHiddens.Add("CarritoID", context.localUtil.Format( (decimal)(A33CarritoID), "ZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("carrito:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z33CarritoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z33CarritoID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z34CarritoFchCompra", context.localUtil.DToC( Z34CarritoFchCompra, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z9ClienteID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9ClienteID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "O36CarritoCostoTotalCompra", StringUtil.LTrim( StringUtil.NToC( O36CarritoCostoTotalCompra, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_68", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_68_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N9ClienteID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9ClienteID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vCARRITOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CarritoID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCARRITOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CarritoID), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_ClienteID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV16Pgmname));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("carrito.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7CarritoID,6,0))}, new string[] {"Gx_mode","CarritoID"})  ;
      }

      public override string GetPgmname( )
      {
         return "Carrito" ;
      }

      public override string GetPgmdesc( )
      {
         return "Carrito" ;
      }

      protected void InitializeNonKey099( )
      {
         A35CarritoFchEntrega = DateTime.MinValue;
         AssignAttri("", false, "A35CarritoFchEntrega", context.localUtil.Format(A35CarritoFchEntrega, "99/99/9999"));
         A10ClienteNombre = "";
         AssignAttri("", false, "A10ClienteNombre", A10ClienteNombre);
         A36CarritoCostoTotalCompra = 0;
         n36CarritoCostoTotalCompra = false;
         AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
         A9ClienteID = 1;
         AssignAttri("", false, "A9ClienteID", StringUtil.LTrimStr( (decimal)(A9ClienteID), 6, 0));
         A34CarritoFchCompra = Gx_date;
         AssignAttri("", false, "A34CarritoFchCompra", context.localUtil.Format(A34CarritoFchCompra, "99/99/9999"));
         O36CarritoCostoTotalCompra = A36CarritoCostoTotalCompra;
         n36CarritoCostoTotalCompra = false;
         AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
         Z34CarritoFchCompra = DateTime.MinValue;
         Z9ClienteID = 0;
      }

      protected void InitAll099( )
      {
         A33CarritoID = 1;
         AssignAttri("", false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
         InitializeNonKey099( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A9ClienteID = i9ClienteID;
         AssignAttri("", false, "A9ClienteID", StringUtil.LTrimStr( (decimal)(A9ClienteID), 6, 0));
         A34CarritoFchCompra = i34CarritoFchCompra;
         AssignAttri("", false, "A34CarritoFchCompra", context.localUtil.Format(A34CarritoFchCompra, "99/99/9999"));
      }

      protected void InitializeNonKey0910( )
      {
         A39CarritoDetalleCompraCostoTotal = 0;
         A22ProductoPrecio = 0;
         A4CategoriaID = 0;
         A38CarritoDetalleCompraCantidadUn = 0;
         A19ProductoID = 1;
         O39CarritoDetalleCompraCostoTotal = A39CarritoDetalleCompraCostoTotal;
         Z38CarritoDetalleCompraCantidadUn = 0;
         Z19ProductoID = 0;
      }

      protected void InitAll0910( )
      {
         A37CarritoDetalleCompraID = 1;
         InitializeNonKey0910( ) ;
      }

      protected void StandaloneModalInsert0910( )
      {
         A19ProductoID = i19ProductoID;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202552204837", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("carrito.js", "?202552204837", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties10( )
      {
         edtCarritoDetalleCompraID_Enabled = defedtCarritoDetalleCompraID_Enabled;
         AssignProp("", false, edtCarritoDetalleCompraID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarritoDetalleCompraID_Enabled), 5, 0), !bGXsfl_68_Refreshing);
      }

      protected void StartGridControl68( )
      {
         Gridcarrito_detallecompraContainer.AddObjectProperty("GridName", "Gridcarrito_detallecompra");
         Gridcarrito_detallecompraContainer.AddObjectProperty("Header", subGridcarrito_detallecompra_Header);
         Gridcarrito_detallecompraContainer.AddObjectProperty("Class", "Grid");
         Gridcarrito_detallecompraContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridcarrito_detallecompraContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridcarrito_detallecompraContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcarrito_detallecompra_Backcolorstyle), 1, 0, ".", "")));
         Gridcarrito_detallecompraContainer.AddObjectProperty("CmpContext", "");
         Gridcarrito_detallecompraContainer.AddObjectProperty("InMasterPage", "false");
         Gridcarrito_detallecompraColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcarrito_detallecompraColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A37CarritoDetalleCompraID), 6, 0, ".", ""))));
         Gridcarrito_detallecompraColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCarritoDetalleCompraID_Enabled), 5, 0, ".", "")));
         Gridcarrito_detallecompraContainer.AddColumnProperties(Gridcarrito_detallecompraColumn);
         Gridcarrito_detallecompraColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcarrito_detallecompraColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProductoID), 6, 0, ".", ""))));
         Gridcarrito_detallecompraColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoID_Enabled), 5, 0, ".", "")));
         Gridcarrito_detallecompraContainer.AddColumnProperties(Gridcarrito_detallecompraColumn);
         Gridcarrito_detallecompraColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcarrito_detallecompraContainer.AddColumnProperties(Gridcarrito_detallecompraColumn);
         Gridcarrito_detallecompraColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcarrito_detallecompraColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A22ProductoPrecio, 10, 2, ".", ""))));
         Gridcarrito_detallecompraColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductoPrecio_Enabled), 5, 0, ".", "")));
         Gridcarrito_detallecompraContainer.AddColumnProperties(Gridcarrito_detallecompraColumn);
         Gridcarrito_detallecompraColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcarrito_detallecompraColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CategoriaID), 6, 0, ".", ""))));
         Gridcarrito_detallecompraColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCategoriaID_Enabled), 5, 0, ".", "")));
         Gridcarrito_detallecompraContainer.AddColumnProperties(Gridcarrito_detallecompraColumn);
         Gridcarrito_detallecompraColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcarrito_detallecompraColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A38CarritoDetalleCompraCantidadUn), 4, 0, ".", ""))));
         Gridcarrito_detallecompraColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCarritoDetalleCompraCantidadUn_Enabled), 5, 0, ".", "")));
         Gridcarrito_detallecompraContainer.AddColumnProperties(Gridcarrito_detallecompraColumn);
         Gridcarrito_detallecompraColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcarrito_detallecompraColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A39CarritoDetalleCompraCostoTotal, 10, 2, ".", ""))));
         Gridcarrito_detallecompraColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCarritoDetalleCompraCostoTotal_Enabled), 5, 0, ".", "")));
         Gridcarrito_detallecompraContainer.AddColumnProperties(Gridcarrito_detallecompraColumn);
         Gridcarrito_detallecompraContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcarrito_detallecompra_Selectedindex), 4, 0, ".", "")));
         Gridcarrito_detallecompraContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcarrito_detallecompra_Allowselection), 1, 0, ".", "")));
         Gridcarrito_detallecompraContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcarrito_detallecompra_Selectioncolor), 9, 0, ".", "")));
         Gridcarrito_detallecompraContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcarrito_detallecompra_Allowhovering), 1, 0, ".", "")));
         Gridcarrito_detallecompraContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcarrito_detallecompra_Hoveringcolor), 9, 0, ".", "")));
         Gridcarrito_detallecompraContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcarrito_detallecompra_Allowcollapsing), 1, 0, ".", "")));
         Gridcarrito_detallecompraContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcarrito_detallecompra_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtCarritoID_Internalname = "CARRITOID";
         edtCarritoFchCompra_Internalname = "CARRITOFCHCOMPRA";
         edtCarritoFchEntrega_Internalname = "CARRITOFCHENTREGA";
         edtClienteID_Internalname = "CLIENTEID";
         edtClienteNombre_Internalname = "CLIENTENOMBRE";
         edtCarritoCostoTotalCompra_Internalname = "CARRITOCOSTOTOTALCOMPRA";
         lblTitledetallecompra_Internalname = "TITLEDETALLECOMPRA";
         edtCarritoDetalleCompraID_Internalname = "CARRITODETALLECOMPRAID";
         edtProductoID_Internalname = "PRODUCTOID";
         edtProductoPrecio_Internalname = "PRODUCTOPRECIO";
         edtCategoriaID_Internalname = "CATEGORIAID";
         edtCarritoDetalleCompraCantidadUn_Internalname = "CARRITODETALLECOMPRACANTIDADUN";
         edtCarritoDetalleCompraCostoTotal_Internalname = "CARRITODETALLECOMPRACOSTOTOTAL";
         divDetallecompratable_Internalname = "DETALLECOMPRATABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_9_Internalname = "PROMPT_9";
         imgprompt_19_Internalname = "PROMPT_19";
         subGridcarrito_detallecompra_Internalname = "GRIDCARRITO_DETALLECOMPRA";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("miTienda", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridcarrito_detallecompra_Allowcollapsing = 0;
         subGridcarrito_detallecompra_Allowselection = 0;
         subGridcarrito_detallecompra_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Carrito";
         edtCarritoDetalleCompraCostoTotal_Jsonclick = "";
         edtCarritoDetalleCompraCantidadUn_Jsonclick = "";
         edtCategoriaID_Jsonclick = "";
         edtProductoPrecio_Jsonclick = "";
         imgprompt_19_Visible = 1;
         imgprompt_19_Link = "";
         imgprompt_9_Visible = 1;
         edtProductoID_Jsonclick = "";
         edtCarritoDetalleCompraID_Jsonclick = "";
         subGridcarrito_detallecompra_Class = "Grid";
         subGridcarrito_detallecompra_Backcolorstyle = 0;
         edtCarritoDetalleCompraCostoTotal_Enabled = 0;
         edtCarritoDetalleCompraCantidadUn_Enabled = 1;
         edtCategoriaID_Enabled = 0;
         edtProductoPrecio_Enabled = 0;
         edtProductoID_Enabled = 1;
         edtCarritoDetalleCompraID_Enabled = 1;
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCarritoCostoTotalCompra_Jsonclick = "";
         edtCarritoCostoTotalCompra_Enabled = 0;
         edtClienteNombre_Jsonclick = "";
         edtClienteNombre_Enabled = 0;
         imgprompt_9_Visible = 1;
         imgprompt_9_Link = "";
         edtClienteID_Jsonclick = "";
         edtClienteID_Enabled = 1;
         edtCarritoFchEntrega_Jsonclick = "";
         edtCarritoFchEntrega_Enabled = 0;
         edtCarritoFchCompra_Jsonclick = "";
         edtCarritoFchCompra_Enabled = 1;
         edtCarritoID_Jsonclick = "";
         edtCarritoID_Enabled = 0;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridcarrito_detallecompra_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_6810( ) ;
         while ( nGXsfl_68_idx <= nRC_GXsfl_68 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0910( ) ;
            standaloneModal0910( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0910( ) ;
            nGXsfl_68_idx = (int)(nGXsfl_68_idx+1);
            sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
            SubsflControlProps_6810( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridcarrito_detallecompraContainer)) ;
         /* End function gxnrGridcarrito_detallecompra_newrow */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Carritoid( )
      {
         n36CarritoCostoTotalCompra = false;
         /* Using cursor T000922 */
         pr_default.execute(16, new Object[] {A33CarritoID});
         if ( (pr_default.getStatus(16) != 101) )
         {
            A36CarritoCostoTotalCompra = T000922_A36CarritoCostoTotalCompra[0];
            n36CarritoCostoTotalCompra = T000922_n36CarritoCostoTotalCompra[0];
         }
         else
         {
            A36CarritoCostoTotalCompra = 0;
            n36CarritoCostoTotalCompra = false;
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A36CarritoCostoTotalCompra", StringUtil.LTrim( StringUtil.NToC( A36CarritoCostoTotalCompra, 10, 2, ".", "")));
      }

      public void Valid_Clienteid( )
      {
         /* Using cursor T000923 */
         pr_default.execute(17, new Object[] {A9ClienteID});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No matching 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteID_Internalname;
         }
         A10ClienteNombre = T000923_A10ClienteNombre[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A10ClienteNombre", A10ClienteNombre);
      }

      public void Valid_Productoid( )
      {
         /* Using cursor T000931 */
         pr_default.execute(25, new Object[] {A19ProductoID});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GX_msglist.addItem("No matching 'Producto'.", "ForeignKeyNotFound", 1, "PRODUCTOID");
            AnyError = 1;
            GX_FocusControl = edtProductoID_Internalname;
         }
         A22ProductoPrecio = T000931_A22ProductoPrecio[0];
         A4CategoriaID = T000931_A4CategoriaID[0];
         pr_default.close(25);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A22ProductoPrecio", StringUtil.LTrim( StringUtil.NToC( A22ProductoPrecio, 10, 2, ".", "")));
         AssignAttri("", false, "A4CategoriaID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CategoriaID), 6, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7CarritoID","fld":"vCARRITOID","pic":"ZZZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7CarritoID","fld":"vCARRITOID","pic":"ZZZZZ9","hsh":true},{"av":"A33CarritoID","fld":"CARRITOID","pic":"ZZZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12092","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_CARRITOID","""{"handler":"Valid_Carritoid","iparms":[{"av":"A33CarritoID","fld":"CARRITOID","pic":"ZZZZZ9"},{"av":"A36CarritoCostoTotalCompra","fld":"CARRITOCOSTOTOTALCOMPRA","pic":"ZZZZZZ9.99"}]""");
         setEventMetadata("VALID_CARRITOID",""","oparms":[{"av":"A36CarritoCostoTotalCompra","fld":"CARRITOCOSTOTOTALCOMPRA","pic":"ZZZZZZ9.99"}]}""");
         setEventMetadata("VALID_CARRITOFCHCOMPRA","""{"handler":"Valid_Carritofchcompra","iparms":[]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[{"av":"A9ClienteID","fld":"CLIENTEID","pic":"ZZZZZ9"},{"av":"A10ClienteNombre","fld":"CLIENTENOMBRE"}]""");
         setEventMetadata("VALID_CLIENTEID",""","oparms":[{"av":"A10ClienteNombre","fld":"CLIENTENOMBRE"}]}""");
         setEventMetadata("VALID_CARRITODETALLECOMPRAID","""{"handler":"Valid_Carritodetallecompraid","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTOID","""{"handler":"Valid_Productoid","iparms":[{"av":"A19ProductoID","fld":"PRODUCTOID","pic":"ZZZZZ9"},{"av":"A22ProductoPrecio","fld":"PRODUCTOPRECIO","pic":"ZZZZZZ9.99"},{"av":"A4CategoriaID","fld":"CATEGORIAID","pic":"ZZZZZ9"}]""");
         setEventMetadata("VALID_PRODUCTOID",""","oparms":[{"av":"A22ProductoPrecio","fld":"PRODUCTOPRECIO","pic":"ZZZZZZ9.99"},{"av":"A4CategoriaID","fld":"CATEGORIAID","pic":"ZZZZZ9"}]}""");
         setEventMetadata("VALID_PRODUCTOPRECIO","""{"handler":"Valid_Productoprecio","iparms":[]}""");
         setEventMetadata("VALID_CARRITODETALLECOMPRACANTIDADUN","""{"handler":"Valid_Carritodetallecompracantidadun","iparms":[]}""");
         setEventMetadata("VALID_CARRITODETALLECOMPRACOSTOTOTAL","""{"handler":"Valid_Carritodetallecompracostototal","iparms":[]}""");
         return  ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(25);
         pr_default.close(4);
         pr_default.close(17);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z34CarritoFchCompra = DateTime.MinValue;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A34CarritoFchCompra = DateTime.MinValue;
         A35CarritoFchEntrega = DateTime.MinValue;
         imgprompt_9_gximage = "";
         sImgUrl = "";
         A10ClienteNombre = "";
         lblTitledetallecompra_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridcarrito_detallecompraContainer = new GXWebGrid( context);
         sMode10 = "";
         sStyleString = "";
         AV11Insert_ClienteID = 1;
         Gx_date = DateTime.MinValue;
         AV16Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode9 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z10ClienteNombre = "";
         T00099_A36CarritoCostoTotalCompra = new decimal[1] ;
         T00099_n36CarritoCostoTotalCompra = new bool[] {false} ;
         T00097_A10ClienteNombre = new string[] {""} ;
         T000911_A33CarritoID = new int[1] ;
         T000911_A34CarritoFchCompra = new DateTime[] {DateTime.MinValue} ;
         T000911_A10ClienteNombre = new string[] {""} ;
         T000911_A9ClienteID = new int[1] ;
         T000911_A36CarritoCostoTotalCompra = new decimal[1] ;
         T000911_n36CarritoCostoTotalCompra = new bool[] {false} ;
         T000913_A36CarritoCostoTotalCompra = new decimal[1] ;
         T000913_n36CarritoCostoTotalCompra = new bool[] {false} ;
         T000914_A10ClienteNombre = new string[] {""} ;
         T000915_A33CarritoID = new int[1] ;
         T00096_A33CarritoID = new int[1] ;
         T00096_A34CarritoFchCompra = new DateTime[] {DateTime.MinValue} ;
         T00096_A9ClienteID = new int[1] ;
         T000916_A33CarritoID = new int[1] ;
         T000917_A33CarritoID = new int[1] ;
         T00095_A33CarritoID = new int[1] ;
         T00095_A34CarritoFchCompra = new DateTime[] {DateTime.MinValue} ;
         T00095_A9ClienteID = new int[1] ;
         T000918_A33CarritoID = new int[1] ;
         T000922_A36CarritoCostoTotalCompra = new decimal[1] ;
         T000922_n36CarritoCostoTotalCompra = new bool[] {false} ;
         T000923_A10ClienteNombre = new string[] {""} ;
         T000924_A33CarritoID = new int[1] ;
         T00094_A22ProductoPrecio = new decimal[1] ;
         T00094_A4CategoriaID = new int[1] ;
         T000925_A33CarritoID = new int[1] ;
         T000925_A37CarritoDetalleCompraID = new int[1] ;
         T000925_A22ProductoPrecio = new decimal[1] ;
         T000925_A38CarritoDetalleCompraCantidadUn = new short[1] ;
         T000925_A19ProductoID = new int[1] ;
         T000925_A4CategoriaID = new int[1] ;
         T000926_A22ProductoPrecio = new decimal[1] ;
         T000926_A4CategoriaID = new int[1] ;
         T000927_A33CarritoID = new int[1] ;
         T000927_A37CarritoDetalleCompraID = new int[1] ;
         T00093_A33CarritoID = new int[1] ;
         T00093_A37CarritoDetalleCompraID = new int[1] ;
         T00093_A38CarritoDetalleCompraCantidadUn = new short[1] ;
         T00093_A19ProductoID = new int[1] ;
         T00092_A33CarritoID = new int[1] ;
         T00092_A37CarritoDetalleCompraID = new int[1] ;
         T00092_A38CarritoDetalleCompraCantidadUn = new short[1] ;
         T00092_A19ProductoID = new int[1] ;
         T000931_A22ProductoPrecio = new decimal[1] ;
         T000931_A4CategoriaID = new int[1] ;
         T000932_A33CarritoID = new int[1] ;
         T000932_A37CarritoDetalleCompraID = new int[1] ;
         Gridcarrito_detallecompraRow = new GXWebRow();
         subGridcarrito_detallecompra_Linesclass = "";
         ROClassString = "";
         imgprompt_19_gximage = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i34CarritoFchCompra = DateTime.MinValue;
         Gridcarrito_detallecompraColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.carrito__default(),
            new Object[][] {
                new Object[] {
               T00092_A33CarritoID, T00092_A37CarritoDetalleCompraID, T00092_A38CarritoDetalleCompraCantidadUn, T00092_A19ProductoID
               }
               , new Object[] {
               T00093_A33CarritoID, T00093_A37CarritoDetalleCompraID, T00093_A38CarritoDetalleCompraCantidadUn, T00093_A19ProductoID
               }
               , new Object[] {
               T00094_A22ProductoPrecio, T00094_A4CategoriaID
               }
               , new Object[] {
               T00095_A33CarritoID, T00095_A34CarritoFchCompra, T00095_A9ClienteID
               }
               , new Object[] {
               T00096_A33CarritoID, T00096_A34CarritoFchCompra, T00096_A9ClienteID
               }
               , new Object[] {
               T00097_A10ClienteNombre
               }
               , new Object[] {
               T00099_A36CarritoCostoTotalCompra, T00099_n36CarritoCostoTotalCompra
               }
               , new Object[] {
               T000911_A33CarritoID, T000911_A34CarritoFchCompra, T000911_A10ClienteNombre, T000911_A9ClienteID, T000911_A36CarritoCostoTotalCompra, T000911_n36CarritoCostoTotalCompra
               }
               , new Object[] {
               T000913_A36CarritoCostoTotalCompra, T000913_n36CarritoCostoTotalCompra
               }
               , new Object[] {
               T000914_A10ClienteNombre
               }
               , new Object[] {
               T000915_A33CarritoID
               }
               , new Object[] {
               T000916_A33CarritoID
               }
               , new Object[] {
               T000917_A33CarritoID
               }
               , new Object[] {
               T000918_A33CarritoID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000922_A36CarritoCostoTotalCompra, T000922_n36CarritoCostoTotalCompra
               }
               , new Object[] {
               T000923_A10ClienteNombre
               }
               , new Object[] {
               T000924_A33CarritoID
               }
               , new Object[] {
               T000925_A33CarritoID, T000925_A37CarritoDetalleCompraID, T000925_A22ProductoPrecio, T000925_A38CarritoDetalleCompraCantidadUn, T000925_A19ProductoID, T000925_A4CategoriaID
               }
               , new Object[] {
               T000926_A22ProductoPrecio, T000926_A4CategoriaID
               }
               , new Object[] {
               T000927_A33CarritoID, T000927_A37CarritoDetalleCompraID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000931_A22ProductoPrecio, T000931_A4CategoriaID
               }
               , new Object[] {
               T000932_A33CarritoID, T000932_A37CarritoDetalleCompraID
               }
            }
         );
         Z19ProductoID = 1;
         i19ProductoID = 1;
         A19ProductoID = 1;
         Z37CarritoDetalleCompraID = 1;
         A37CarritoDetalleCompraID = 1;
         Z9ClienteID = 1;
         N9ClienteID = 1;
         i9ClienteID = 1;
         A9ClienteID = 1;
         Z33CarritoID = 1;
         A33CarritoID = 1;
         AV16Pgmname = "Carrito";
         Z34CarritoFchCompra = DateTime.MinValue;
         A34CarritoFchCompra = DateTime.MinValue;
         i34CarritoFchCompra = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short nIsMod_10 ;
      private short Z38CarritoDetalleCompraCantidadUn ;
      private short nRcdDeleted_10 ;
      private short nRcdExists_10 ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short nBlankRcdCount10 ;
      private short RcdFound10 ;
      private short nBlankRcdUsr10 ;
      private short RcdFound9 ;
      private short A38CarritoDetalleCompraCantidadUn ;
      private short nIsDirty_10 ;
      private short subGridcarrito_detallecompra_Backcolorstyle ;
      private short subGridcarrito_detallecompra_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridcarrito_detallecompra_Allowselection ;
      private short subGridcarrito_detallecompra_Allowhovering ;
      private short subGridcarrito_detallecompra_Allowcollapsing ;
      private short subGridcarrito_detallecompra_Collapsed ;
      private int wcpOAV7CarritoID ;
      private int Z33CarritoID ;
      private int Z9ClienteID ;
      private int nRC_GXsfl_68 ;
      private int nGXsfl_68_idx=1 ;
      private int N9ClienteID ;
      private int Z37CarritoDetalleCompraID ;
      private int Z19ProductoID ;
      private int A33CarritoID ;
      private int A9ClienteID ;
      private int A19ProductoID ;
      private int AV7CarritoID ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCarritoID_Enabled ;
      private int edtCarritoFchCompra_Enabled ;
      private int edtCarritoFchEntrega_Enabled ;
      private int edtClienteID_Enabled ;
      private int imgprompt_9_Visible ;
      private int edtClienteNombre_Enabled ;
      private int edtCarritoCostoTotalCompra_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtCarritoDetalleCompraID_Enabled ;
      private int edtProductoID_Enabled ;
      private int edtProductoPrecio_Enabled ;
      private int edtCategoriaID_Enabled ;
      private int edtCarritoDetalleCompraCantidadUn_Enabled ;
      private int edtCarritoDetalleCompraCostoTotal_Enabled ;
      private int fRowAdded ;
      private int AV11Insert_ClienteID ;
      private int A37CarritoDetalleCompraID ;
      private int A4CategoriaID ;
      private int AV17GXV1 ;
      private int Z4CategoriaID ;
      private int subGridcarrito_detallecompra_Backcolor ;
      private int subGridcarrito_detallecompra_Allbackcolor ;
      private int imgprompt_19_Visible ;
      private int defedtCarritoDetalleCompraID_Enabled ;
      private int i9ClienteID ;
      private int i19ProductoID ;
      private int idxLst ;
      private int subGridcarrito_detallecompra_Selectedindex ;
      private int subGridcarrito_detallecompra_Selectioncolor ;
      private int subGridcarrito_detallecompra_Hoveringcolor ;
      private long GRIDCARRITO_DETALLECOMPRA_nFirstRecordOnPage ;
      private decimal O36CarritoCostoTotalCompra ;
      private decimal O39CarritoDetalleCompraCostoTotal ;
      private decimal A36CarritoCostoTotalCompra ;
      private decimal B36CarritoCostoTotalCompra ;
      private decimal s36CarritoCostoTotalCompra ;
      private decimal A22ProductoPrecio ;
      private decimal A39CarritoDetalleCompraCostoTotal ;
      private decimal T39CarritoDetalleCompraCostoTotal ;
      private decimal Z36CarritoCostoTotalCompra ;
      private decimal Z22ProductoPrecio ;
      private string sPrefix ;
      private string sGXsfl_68_idx="0001" ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCarritoFchCompra_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtCarritoID_Internalname ;
      private string edtCarritoID_Jsonclick ;
      private string edtCarritoFchCompra_Jsonclick ;
      private string edtCarritoFchEntrega_Internalname ;
      private string edtCarritoFchEntrega_Jsonclick ;
      private string edtClienteID_Internalname ;
      private string edtClienteID_Jsonclick ;
      private string imgprompt_9_gximage ;
      private string sImgUrl ;
      private string imgprompt_9_Internalname ;
      private string imgprompt_9_Link ;
      private string edtClienteNombre_Internalname ;
      private string edtClienteNombre_Jsonclick ;
      private string edtCarritoCostoTotalCompra_Internalname ;
      private string edtCarritoCostoTotalCompra_Jsonclick ;
      private string divDetallecompratable_Internalname ;
      private string lblTitledetallecompra_Internalname ;
      private string lblTitledetallecompra_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode10 ;
      private string edtCarritoDetalleCompraID_Internalname ;
      private string edtProductoID_Internalname ;
      private string edtProductoPrecio_Internalname ;
      private string edtCategoriaID_Internalname ;
      private string edtCarritoDetalleCompraCantidadUn_Internalname ;
      private string edtCarritoDetalleCompraCostoTotal_Internalname ;
      private string sStyleString ;
      private string subGridcarrito_detallecompra_Internalname ;
      private string AV16Pgmname ;
      private string hsh ;
      private string sMode9 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string imgprompt_19_Internalname ;
      private string sGXsfl_68_fel_idx="0001" ;
      private string subGridcarrito_detallecompra_Class ;
      private string subGridcarrito_detallecompra_Linesclass ;
      private string imgprompt_19_Link ;
      private string ROClassString ;
      private string edtCarritoDetalleCompraID_Jsonclick ;
      private string edtProductoID_Jsonclick ;
      private string imgprompt_19_gximage ;
      private string edtProductoPrecio_Jsonclick ;
      private string edtCategoriaID_Jsonclick ;
      private string edtCarritoDetalleCompraCantidadUn_Jsonclick ;
      private string edtCarritoDetalleCompraCostoTotal_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridcarrito_detallecompra_Header ;
      private DateTime Z34CarritoFchCompra ;
      private DateTime A34CarritoFchCompra ;
      private DateTime A35CarritoFchEntrega ;
      private DateTime Gx_date ;
      private DateTime i34CarritoFchCompra ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n36CarritoCostoTotalCompra ;
      private bool bGXsfl_68_Refreshing=false ;
      private bool returnInSub ;
      private string A10ClienteNombre ;
      private string Z10ClienteNombre ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridcarrito_detallecompraContainer ;
      private GXWebRow Gridcarrito_detallecompraRow ;
      private GXWebColumn Gridcarrito_detallecompraColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private decimal[] T00099_A36CarritoCostoTotalCompra ;
      private bool[] T00099_n36CarritoCostoTotalCompra ;
      private string[] T00097_A10ClienteNombre ;
      private int[] T000911_A33CarritoID ;
      private DateTime[] T000911_A34CarritoFchCompra ;
      private string[] T000911_A10ClienteNombre ;
      private int[] T000911_A9ClienteID ;
      private decimal[] T000911_A36CarritoCostoTotalCompra ;
      private bool[] T000911_n36CarritoCostoTotalCompra ;
      private decimal[] T000913_A36CarritoCostoTotalCompra ;
      private bool[] T000913_n36CarritoCostoTotalCompra ;
      private string[] T000914_A10ClienteNombre ;
      private int[] T000915_A33CarritoID ;
      private int[] T00096_A33CarritoID ;
      private DateTime[] T00096_A34CarritoFchCompra ;
      private int[] T00096_A9ClienteID ;
      private int[] T000916_A33CarritoID ;
      private int[] T000917_A33CarritoID ;
      private int[] T00095_A33CarritoID ;
      private DateTime[] T00095_A34CarritoFchCompra ;
      private int[] T00095_A9ClienteID ;
      private int[] T000918_A33CarritoID ;
      private decimal[] T000922_A36CarritoCostoTotalCompra ;
      private bool[] T000922_n36CarritoCostoTotalCompra ;
      private string[] T000923_A10ClienteNombre ;
      private int[] T000924_A33CarritoID ;
      private decimal[] T00094_A22ProductoPrecio ;
      private int[] T00094_A4CategoriaID ;
      private int[] T000925_A33CarritoID ;
      private int[] T000925_A37CarritoDetalleCompraID ;
      private decimal[] T000925_A22ProductoPrecio ;
      private short[] T000925_A38CarritoDetalleCompraCantidadUn ;
      private int[] T000925_A19ProductoID ;
      private int[] T000925_A4CategoriaID ;
      private decimal[] T000926_A22ProductoPrecio ;
      private int[] T000926_A4CategoriaID ;
      private int[] T000927_A33CarritoID ;
      private int[] T000927_A37CarritoDetalleCompraID ;
      private int[] T00093_A33CarritoID ;
      private int[] T00093_A37CarritoDetalleCompraID ;
      private short[] T00093_A38CarritoDetalleCompraCantidadUn ;
      private int[] T00093_A19ProductoID ;
      private int[] T00092_A33CarritoID ;
      private int[] T00092_A37CarritoDetalleCompraID ;
      private short[] T00092_A38CarritoDetalleCompraCantidadUn ;
      private int[] T00092_A19ProductoID ;
      private decimal[] T000931_A22ProductoPrecio ;
      private int[] T000931_A4CategoriaID ;
      private int[] T000932_A33CarritoID ;
      private int[] T000932_A37CarritoDetalleCompraID ;
   }

   public class carrito__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new UpdateCursor(def[22])
         ,new UpdateCursor(def[23])
         ,new UpdateCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00092;
          prmT00092 = new Object[] {
          new ParDef("@CarritoID",GXType.Int32,6,0) ,
          new ParDef("@CarritoDetalleCompraID",GXType.Int32,6,0)
          };
          Object[] prmT00093;
          prmT00093 = new Object[] {
          new ParDef("@CarritoID",GXType.Int32,6,0) ,
          new ParDef("@CarritoDetalleCompraID",GXType.Int32,6,0)
          };
          Object[] prmT00094;
          prmT00094 = new Object[] {
          new ParDef("@ProductoID",GXType.Int32,6,0)
          };
          Object[] prmT00095;
          prmT00095 = new Object[] {
          new ParDef("@CarritoID",GXType.Int32,6,0)
          };
          Object[] prmT00096;
          prmT00096 = new Object[] {
          new ParDef("@CarritoID",GXType.Int32,6,0)
          };
          Object[] prmT00097;
          prmT00097 = new Object[] {
          new ParDef("@ClienteID",GXType.Int32,6,0)
          };
          Object[] prmT00099;
          prmT00099 = new Object[] {
          new ParDef("@CarritoID",GXType.Int32,6,0)
          };
          Object[] prmT000911;
          prmT000911 = new Object[] {
          new ParDef("@CarritoID",GXType.Int32,6,0)
          };
          Object[] prmT000913;
          prmT000913 = new Object[] {
          new ParDef("@CarritoID",GXType.Int32,6,0)
          };
          Object[] prmT000914;
          prmT000914 = new Object[] {
          new ParDef("@ClienteID",GXType.Int32,6,0)
          };
          Object[] prmT000915;
          prmT000915 = new Object[] {
          new ParDef("@CarritoID",GXType.Int32,6,0)
          };
          Object[] prmT000916;
          prmT000916 = new Object[] {
          new ParDef("@CarritoID",GXType.Int32,6,0)
          };
          Object[] prmT000917;
          prmT000917 = new Object[] {
          new ParDef("@CarritoID",GXType.Int32,6,0)
          };
          Object[] prmT000918;
          prmT000918 = new Object[] {
          new ParDef("@CarritoFchCompra",GXType.Date,8,0) ,
          new ParDef("@ClienteID",GXType.Int32,6,0)
          };
          Object[] prmT000919;
          prmT000919 = new Object[] {
          new ParDef("@CarritoFchCompra",GXType.Date,8,0) ,
          new ParDef("@ClienteID",GXType.Int32,6,0) ,
          new ParDef("@CarritoID",GXType.Int32,6,0)
          };
          Object[] prmT000920;
          prmT000920 = new Object[] {
          new ParDef("@CarritoID",GXType.Int32,6,0)
          };
          Object[] prmT000922;
          prmT000922 = new Object[] {
          new ParDef("@CarritoID",GXType.Int32,6,0)
          };
          Object[] prmT000923;
          prmT000923 = new Object[] {
          new ParDef("@ClienteID",GXType.Int32,6,0)
          };
          Object[] prmT000924;
          prmT000924 = new Object[] {
          };
          Object[] prmT000925;
          prmT000925 = new Object[] {
          new ParDef("@CarritoID",GXType.Int32,6,0) ,
          new ParDef("@CarritoDetalleCompraID",GXType.Int32,6,0)
          };
          Object[] prmT000926;
          prmT000926 = new Object[] {
          new ParDef("@ProductoID",GXType.Int32,6,0)
          };
          Object[] prmT000927;
          prmT000927 = new Object[] {
          new ParDef("@CarritoID",GXType.Int32,6,0) ,
          new ParDef("@CarritoDetalleCompraID",GXType.Int32,6,0)
          };
          Object[] prmT000928;
          prmT000928 = new Object[] {
          new ParDef("@CarritoID",GXType.Int32,6,0) ,
          new ParDef("@CarritoDetalleCompraID",GXType.Int32,6,0) ,
          new ParDef("@CarritoDetalleCompraCantidadUn",GXType.Int16,4,0) ,
          new ParDef("@ProductoID",GXType.Int32,6,0)
          };
          Object[] prmT000929;
          prmT000929 = new Object[] {
          new ParDef("@CarritoDetalleCompraCantidadUn",GXType.Int16,4,0) ,
          new ParDef("@ProductoID",GXType.Int32,6,0) ,
          new ParDef("@CarritoID",GXType.Int32,6,0) ,
          new ParDef("@CarritoDetalleCompraID",GXType.Int32,6,0)
          };
          Object[] prmT000930;
          prmT000930 = new Object[] {
          new ParDef("@CarritoID",GXType.Int32,6,0) ,
          new ParDef("@CarritoDetalleCompraID",GXType.Int32,6,0)
          };
          Object[] prmT000931;
          prmT000931 = new Object[] {
          new ParDef("@ProductoID",GXType.Int32,6,0)
          };
          Object[] prmT000932;
          prmT000932 = new Object[] {
          new ParDef("@CarritoID",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00092", "SELECT [CarritoID], [CarritoDetalleCompraID], [CarritoDetalleCompraCantidadUn], [ProductoID] FROM [CarritoDetalleCompra] WITH (UPDLOCK) WHERE [CarritoID] = @CarritoID AND [CarritoDetalleCompraID] = @CarritoDetalleCompraID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00092,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00093", "SELECT [CarritoID], [CarritoDetalleCompraID], [CarritoDetalleCompraCantidadUn], [ProductoID] FROM [CarritoDetalleCompra] WHERE [CarritoID] = @CarritoID AND [CarritoDetalleCompraID] = @CarritoDetalleCompraID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00093,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00094", "SELECT [ProductoPrecio], [CategoriaID] FROM [Producto] WHERE [ProductoID] = @ProductoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00094,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00095", "SELECT [CarritoID], [CarritoFchCompra], [ClienteID] FROM [Carrito] WITH (UPDLOCK) WHERE [CarritoID] = @CarritoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00095,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00096", "SELECT [CarritoID], [CarritoFchCompra], [ClienteID] FROM [Carrito] WHERE [CarritoID] = @CarritoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00096,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00097", "SELECT [ClienteNombre] FROM [Cliente] WHERE [ClienteID] = @ClienteID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00097,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00099", "SELECT COALESCE( T1.[CarritoCostoTotalCompra], 0) AS CarritoCostoTotalCompra FROM (SELECT SUM(T3.[ProductoPrecio] * CAST(T2.[CarritoDetalleCompraCantidadUn] AS decimal( 20, 10))) AS CarritoCostoTotalCompra, T2.[CarritoID] FROM ([CarritoDetalleCompra] T2 WITH (UPDLOCK) INNER JOIN [Producto] T3 ON T3.[ProductoID] = T2.[ProductoID]) GROUP BY T2.[CarritoID] ) T1 WHERE T1.[CarritoID] = @CarritoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00099,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000911", "SELECT TM1.[CarritoID], TM1.[CarritoFchCompra], T3.[ClienteNombre], TM1.[ClienteID], COALESCE( T2.[CarritoCostoTotalCompra], 0) AS CarritoCostoTotalCompra FROM (([Carrito] TM1 LEFT JOIN (SELECT SUM(T5.[ProductoPrecio] * CAST(T4.[CarritoDetalleCompraCantidadUn] AS decimal( 20, 10))) AS CarritoCostoTotalCompra, T4.[CarritoID] FROM ([CarritoDetalleCompra] T4 INNER JOIN [Producto] T5 ON T5.[ProductoID] = T4.[ProductoID]) GROUP BY T4.[CarritoID] ) T2 ON T2.[CarritoID] = TM1.[CarritoID]) INNER JOIN [Cliente] T3 ON T3.[ClienteID] = TM1.[ClienteID]) WHERE TM1.[CarritoID] = @CarritoID ORDER BY TM1.[CarritoID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000911,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000913", "SELECT COALESCE( T1.[CarritoCostoTotalCompra], 0) AS CarritoCostoTotalCompra FROM (SELECT SUM(T3.[ProductoPrecio] * CAST(T2.[CarritoDetalleCompraCantidadUn] AS decimal( 20, 10))) AS CarritoCostoTotalCompra, T2.[CarritoID] FROM ([CarritoDetalleCompra] T2 WITH (UPDLOCK) INNER JOIN [Producto] T3 ON T3.[ProductoID] = T2.[ProductoID]) GROUP BY T2.[CarritoID] ) T1 WHERE T1.[CarritoID] = @CarritoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000913,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000914", "SELECT [ClienteNombre] FROM [Cliente] WHERE [ClienteID] = @ClienteID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000914,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000915", "SELECT [CarritoID] FROM [Carrito] WHERE [CarritoID] = @CarritoID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000915,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000916", "SELECT TOP 1 [CarritoID] FROM [Carrito] WHERE ( [CarritoID] > @CarritoID) ORDER BY [CarritoID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000916,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000917", "SELECT TOP 1 [CarritoID] FROM [Carrito] WHERE ( [CarritoID] < @CarritoID) ORDER BY [CarritoID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000917,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000918", "INSERT INTO [Carrito]([CarritoFchCompra], [ClienteID]) VALUES(@CarritoFchCompra, @ClienteID); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000918,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000919", "UPDATE [Carrito] SET [CarritoFchCompra]=@CarritoFchCompra, [ClienteID]=@ClienteID  WHERE [CarritoID] = @CarritoID", GxErrorMask.GX_NOMASK,prmT000919)
             ,new CursorDef("T000920", "DELETE FROM [Carrito]  WHERE [CarritoID] = @CarritoID", GxErrorMask.GX_NOMASK,prmT000920)
             ,new CursorDef("T000922", "SELECT COALESCE( T1.[CarritoCostoTotalCompra], 0) AS CarritoCostoTotalCompra FROM (SELECT SUM(T3.[ProductoPrecio] * CAST(T2.[CarritoDetalleCompraCantidadUn] AS decimal( 20, 10))) AS CarritoCostoTotalCompra, T2.[CarritoID] FROM ([CarritoDetalleCompra] T2 WITH (UPDLOCK) INNER JOIN [Producto] T3 ON T3.[ProductoID] = T2.[ProductoID]) GROUP BY T2.[CarritoID] ) T1 WHERE T1.[CarritoID] = @CarritoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000922,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000923", "SELECT [ClienteNombre] FROM [Cliente] WHERE [ClienteID] = @ClienteID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000923,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000924", "SELECT [CarritoID] FROM [Carrito] ORDER BY [CarritoID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000924,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000925", "SELECT T1.[CarritoID], T1.[CarritoDetalleCompraID], T2.[ProductoPrecio], T1.[CarritoDetalleCompraCantidadUn], T1.[ProductoID], T2.[CategoriaID] FROM ([CarritoDetalleCompra] T1 INNER JOIN [Producto] T2 ON T2.[ProductoID] = T1.[ProductoID]) WHERE T1.[CarritoID] = @CarritoID and T1.[CarritoDetalleCompraID] = @CarritoDetalleCompraID ORDER BY T1.[CarritoID], T1.[CarritoDetalleCompraID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000925,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000926", "SELECT [ProductoPrecio], [CategoriaID] FROM [Producto] WHERE [ProductoID] = @ProductoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000926,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000927", "SELECT [CarritoID], [CarritoDetalleCompraID] FROM [CarritoDetalleCompra] WHERE [CarritoID] = @CarritoID AND [CarritoDetalleCompraID] = @CarritoDetalleCompraID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000927,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000928", "INSERT INTO [CarritoDetalleCompra]([CarritoID], [CarritoDetalleCompraID], [CarritoDetalleCompraCantidadUn], [ProductoID]) VALUES(@CarritoID, @CarritoDetalleCompraID, @CarritoDetalleCompraCantidadUn, @ProductoID)", GxErrorMask.GX_NOMASK,prmT000928)
             ,new CursorDef("T000929", "UPDATE [CarritoDetalleCompra] SET [CarritoDetalleCompraCantidadUn]=@CarritoDetalleCompraCantidadUn, [ProductoID]=@ProductoID  WHERE [CarritoID] = @CarritoID AND [CarritoDetalleCompraID] = @CarritoDetalleCompraID", GxErrorMask.GX_NOMASK,prmT000929)
             ,new CursorDef("T000930", "DELETE FROM [CarritoDetalleCompra]  WHERE [CarritoID] = @CarritoID AND [CarritoDetalleCompraID] = @CarritoDetalleCompraID", GxErrorMask.GX_NOMASK,prmT000930)
             ,new CursorDef("T000931", "SELECT [ProductoPrecio], [CategoriaID] FROM [Producto] WHERE [ProductoID] = @ProductoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000931,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000932", "SELECT [CarritoID], [CarritoDetalleCompraID] FROM [CarritoDetalleCompra] WHERE [CarritoID] = @CarritoID ORDER BY [CarritoID], [CarritoDetalleCompraID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000932,11, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 6 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
             case 8 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 16 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 20 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 25 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 26 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
