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
   public class producto : GXDataArea
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
            A6VendedorID = (int)(Math.Round(NumberUtil.Val( GetPar( "VendedorID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A6VendedorID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A26ProductoPaisID = (int)(Math.Round(NumberUtil.Val( GetPar( "ProductoPaisID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A26ProductoPaisID", StringUtil.LTrimStr( (decimal)(A26ProductoPaisID), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A26ProductoPaisID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A4CategoriaID = (int)(Math.Round(NumberUtil.Val( GetPar( "CategoriaID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A4CategoriaID", StringUtil.LTrimStr( (decimal)(A4CategoriaID), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A4CategoriaID) ;
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
               AV7ProductoID = (int)(Math.Round(NumberUtil.Val( GetPar( "ProductoID"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7ProductoID", StringUtil.LTrimStr( (decimal)(AV7ProductoID), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProductoID), "ZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Producto", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProductoNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("miTienda", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public producto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("miTienda", true);
      }

      public producto( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_ProductoID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ProductoID = aP1_ProductoID;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Producto", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Producto.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Producto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Producto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Producto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Producto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Producto.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductoID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductoID_Internalname, "ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProductoID), 6, 0, ".", "")), StringUtil.LTrim( ((edtProductoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A19ProductoID), "ZZZZZ9") : context.localUtil.Format( (decimal)(A19ProductoID), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductoID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductoID_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Producto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductoNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductoNombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductoNombre_Internalname, A20ProductoNombre, StringUtil.RTrim( context.localUtil.Format( A20ProductoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductoNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductoNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Producto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductoDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductoDescripcion_Internalname, "Descripcion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductoDescripcion_Internalname, A21ProductoDescripcion, StringUtil.RTrim( context.localUtil.Format( A21ProductoDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductoDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductoDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Producto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductoPrecio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductoPrecio_Internalname, "Precio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductoPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( A22ProductoPrecio, 10, 2, ".", "")), StringUtil.LTrim( ((edtProductoPrecio_Enabled!=0) ? context.localUtil.Format( A22ProductoPrecio, "ZZZZZZ9.99") : context.localUtil.Format( A22ProductoPrecio, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductoPrecio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductoPrecio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_Producto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgProductoImagen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Imagen", "col-sm-3 ImageLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Image";
         StyleString = "";
         A23ProductoImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A23ProductoImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProductoImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A23ProductoImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductoImagen)) ? A40000ProductoImagen_GXI : context.PathToRelativeUrl( A23ProductoImagen));
         GxWebStd.gx_bitmap( context, imgProductoImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgProductoImagen_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", "", "", 0, A23ProductoImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Producto.htm");
         AssignProp("", false, imgProductoImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductoImagen)) ? A40000ProductoImagen_GXI : context.PathToRelativeUrl( A23ProductoImagen)), true);
         AssignProp("", false, imgProductoImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A23ProductoImagen_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVendedorID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVendedorID_Internalname, "Vendedor ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVendedorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A6VendedorID), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A6VendedorID), "ZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVendedorID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVendedorID_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Producto.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_6_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_6_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_6_Internalname, sImgUrl, imgprompt_6_Link, "", "", context.GetTheme( ), imgprompt_6_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Producto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVendedorNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVendedorNombre_Internalname, "Vendedor Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVendedorNombre_Internalname, A7VendedorNombre, StringUtil.RTrim( context.localUtil.Format( A7VendedorNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVendedorNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVendedorNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Producto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductoPaisID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductoPaisID_Internalname, "Pais ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductoPaisID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A26ProductoPaisID), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A26ProductoPaisID), "ZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductoPaisID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductoPaisID_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Producto.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_26_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_26_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_26_Internalname, sImgUrl, imgprompt_26_Link, "", "", context.GetTheme( ), imgprompt_26_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Producto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductoPaisNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductoPaisNombre_Internalname, "Pais Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductoPaisNombre_Internalname, A27ProductoPaisNombre, StringUtil.RTrim( context.localUtil.Format( A27ProductoPaisNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductoPaisNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductoPaisNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Producto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCategoriaID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCategoriaID_Internalname, "Categoria ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCategoriaID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CategoriaID), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A4CategoriaID), "ZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoriaID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCategoriaID_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Producto.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Producto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCategoriaNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCategoriaNombre_Internalname, "Categoria Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCategoriaNombre_Internalname, A5CategoriaNombre, StringUtil.RTrim( context.localUtil.Format( A5CategoriaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoriaNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCategoriaNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Producto.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Producto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Producto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Producto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         E11072 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z19ProductoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z19ProductoID"), ".", ","), 18, MidpointRounding.ToEven));
               Z20ProductoNombre = cgiGet( "Z20ProductoNombre");
               Z21ProductoDescripcion = cgiGet( "Z21ProductoDescripcion");
               Z22ProductoPrecio = context.localUtil.CToN( cgiGet( "Z22ProductoPrecio"), ".", ",");
               Z6VendedorID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z6VendedorID"), ".", ","), 18, MidpointRounding.ToEven));
               Z4CategoriaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z4CategoriaID"), ".", ","), 18, MidpointRounding.ToEven));
               Z26ProductoPaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z26ProductoPaisID"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N6VendedorID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N6VendedorID"), ".", ","), 18, MidpointRounding.ToEven));
               N26ProductoPaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N26ProductoPaisID"), ".", ","), 18, MidpointRounding.ToEven));
               N4CategoriaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N4CategoriaID"), ".", ","), 18, MidpointRounding.ToEven));
               AV7ProductoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vPRODUCTOID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV11Insert_VendedorID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_VENDEDORID"), ".", ","), 18, MidpointRounding.ToEven));
               AV15Insert_ProductoPaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PRODUCTOPAISID"), ".", ","), 18, MidpointRounding.ToEven));
               AV13Insert_CategoriaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CATEGORIAID"), ".", ","), 18, MidpointRounding.ToEven));
               A40000ProductoImagen_GXI = cgiGet( "PRODUCTOIMAGEN_GXI");
               AV16Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A19ProductoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductoID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A19ProductoID", StringUtil.LTrimStr( (decimal)(A19ProductoID), 6, 0));
               A20ProductoNombre = cgiGet( edtProductoNombre_Internalname);
               AssignAttri("", false, "A20ProductoNombre", A20ProductoNombre);
               A21ProductoDescripcion = cgiGet( edtProductoDescripcion_Internalname);
               AssignAttri("", false, "A21ProductoDescripcion", A21ProductoDescripcion);
               if ( ( ( context.localUtil.CToN( cgiGet( edtProductoPrecio_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductoPrecio_Internalname), ".", ",") > 9999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTOPRECIO");
                  AnyError = 1;
                  GX_FocusControl = edtProductoPrecio_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A22ProductoPrecio = 0;
                  AssignAttri("", false, "A22ProductoPrecio", StringUtil.LTrimStr( A22ProductoPrecio, 10, 2));
               }
               else
               {
                  A22ProductoPrecio = context.localUtil.CToN( cgiGet( edtProductoPrecio_Internalname), ".", ",");
                  AssignAttri("", false, "A22ProductoPrecio", StringUtil.LTrimStr( A22ProductoPrecio, 10, 2));
               }
               A23ProductoImagen = cgiGet( imgProductoImagen_Internalname);
               AssignAttri("", false, "A23ProductoImagen", A23ProductoImagen);
               if ( ( ( context.localUtil.CToN( cgiGet( edtVendedorID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVendedorID_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VENDEDORID");
                  AnyError = 1;
                  GX_FocusControl = edtVendedorID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A6VendedorID = 0;
                  AssignAttri("", false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
               }
               else
               {
                  A6VendedorID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtVendedorID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
               }
               A7VendedorNombre = cgiGet( edtVendedorNombre_Internalname);
               AssignAttri("", false, "A7VendedorNombre", A7VendedorNombre);
               if ( ( ( context.localUtil.CToN( cgiGet( edtProductoPaisID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductoPaisID_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTOPAISID");
                  AnyError = 1;
                  GX_FocusControl = edtProductoPaisID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A26ProductoPaisID = 0;
                  AssignAttri("", false, "A26ProductoPaisID", StringUtil.LTrimStr( (decimal)(A26ProductoPaisID), 6, 0));
               }
               else
               {
                  A26ProductoPaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductoPaisID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A26ProductoPaisID", StringUtil.LTrimStr( (decimal)(A26ProductoPaisID), 6, 0));
               }
               A27ProductoPaisNombre = cgiGet( edtProductoPaisNombre_Internalname);
               AssignAttri("", false, "A27ProductoPaisNombre", A27ProductoPaisNombre);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCategoriaID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCategoriaID_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CATEGORIAID");
                  AnyError = 1;
                  GX_FocusControl = edtCategoriaID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A4CategoriaID = 0;
                  AssignAttri("", false, "A4CategoriaID", StringUtil.LTrimStr( (decimal)(A4CategoriaID), 6, 0));
               }
               else
               {
                  A4CategoriaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCategoriaID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A4CategoriaID", StringUtil.LTrimStr( (decimal)(A4CategoriaID), 6, 0));
               }
               A5CategoriaNombre = cgiGet( edtCategoriaNombre_Internalname);
               AssignAttri("", false, "A5CategoriaNombre", A5CategoriaNombre);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgProductoImagen_Internalname, ref  A23ProductoImagen, ref  A40000ProductoImagen_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Producto");
               A19ProductoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductoID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A19ProductoID", StringUtil.LTrimStr( (decimal)(A19ProductoID), 6, 0));
               forbiddenHiddens.Add("ProductoID", context.localUtil.Format( (decimal)(A19ProductoID), "ZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A19ProductoID != Z19ProductoID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("producto:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A19ProductoID = (int)(Math.Round(NumberUtil.Val( GetPar( "ProductoID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A19ProductoID", StringUtil.LTrimStr( (decimal)(A19ProductoID), 6, 0));
                  getEqualNoModal( ) ;
                  if ( ! (0==AV7ProductoID) )
                  {
                     A19ProductoID = AV7ProductoID;
                     AssignAttri("", false, "A19ProductoID", StringUtil.LTrimStr( (decimal)(A19ProductoID), 6, 0));
                  }
                  else
                  {
                     if ( IsIns( )  && (0==A19ProductoID) && ( Gx_BScreen == 0 ) )
                     {
                        A19ProductoID = 1;
                        AssignAttri("", false, "A19ProductoID", StringUtil.LTrimStr( (decimal)(A19ProductoID), 6, 0));
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
                     sMode7 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (0==AV7ProductoID) )
                     {
                        A19ProductoID = AV7ProductoID;
                        AssignAttri("", false, "A19ProductoID", StringUtil.LTrimStr( (decimal)(A19ProductoID), 6, 0));
                     }
                     else
                     {
                        if ( IsIns( )  && (0==A19ProductoID) && ( Gx_BScreen == 0 ) )
                        {
                           A19ProductoID = 1;
                           AssignAttri("", false, "A19ProductoID", StringUtil.LTrimStr( (decimal)(A19ProductoID), 6, 0));
                        }
                     }
                     Gx_mode = sMode7;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound7 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_070( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PRODUCTOID");
                        AnyError = 1;
                        GX_FocusControl = edtProductoID_Internalname;
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
                           E11072 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12072 ();
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
            E12072 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll077( ) ;
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
            DisableAttributes077( ) ;
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

      protected void CONFIRM_070( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls077( ) ;
            }
            else
            {
               CheckExtendedTable077( ) ;
               CloseExtendedTableCursors077( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption070( )
      {
      }

      protected void E11072( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV16Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV16Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_VendedorID = 0;
         AssignAttri("", false, "AV11Insert_VendedorID", StringUtil.LTrimStr( (decimal)(AV11Insert_VendedorID), 6, 0));
         AV15Insert_ProductoPaisID = 0;
         AssignAttri("", false, "AV15Insert_ProductoPaisID", StringUtil.LTrimStr( (decimal)(AV15Insert_ProductoPaisID), 6, 0));
         AV13Insert_CategoriaID = 0;
         AssignAttri("", false, "AV13Insert_CategoriaID", StringUtil.LTrimStr( (decimal)(AV13Insert_CategoriaID), 6, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV16Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV17GXV1 = 1;
            AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            while ( AV17GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "VendedorID") == 0 )
               {
                  AV11Insert_VendedorID = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_VendedorID", StringUtil.LTrimStr( (decimal)(AV11Insert_VendedorID), 6, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ProductoPaisID") == 0 )
               {
                  AV15Insert_ProductoPaisID = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV15Insert_ProductoPaisID", StringUtil.LTrimStr( (decimal)(AV15Insert_ProductoPaisID), 6, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CategoriaID") == 0 )
               {
                  AV13Insert_CategoriaID = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_CategoriaID", StringUtil.LTrimStr( (decimal)(AV13Insert_CategoriaID), 6, 0));
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

      protected void E12072( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwproducto.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM077( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z20ProductoNombre = T00073_A20ProductoNombre[0];
               Z21ProductoDescripcion = T00073_A21ProductoDescripcion[0];
               Z22ProductoPrecio = T00073_A22ProductoPrecio[0];
               Z6VendedorID = T00073_A6VendedorID[0];
               Z4CategoriaID = T00073_A4CategoriaID[0];
               Z26ProductoPaisID = T00073_A26ProductoPaisID[0];
            }
            else
            {
               Z20ProductoNombre = A20ProductoNombre;
               Z21ProductoDescripcion = A21ProductoDescripcion;
               Z22ProductoPrecio = A22ProductoPrecio;
               Z6VendedorID = A6VendedorID;
               Z4CategoriaID = A4CategoriaID;
               Z26ProductoPaisID = A26ProductoPaisID;
            }
         }
         if ( GX_JID == -16 )
         {
            Z19ProductoID = A19ProductoID;
            Z20ProductoNombre = A20ProductoNombre;
            Z21ProductoDescripcion = A21ProductoDescripcion;
            Z22ProductoPrecio = A22ProductoPrecio;
            Z23ProductoImagen = A23ProductoImagen;
            Z40000ProductoImagen_GXI = A40000ProductoImagen_GXI;
            Z6VendedorID = A6VendedorID;
            Z4CategoriaID = A4CategoriaID;
            Z26ProductoPaisID = A26ProductoPaisID;
            Z7VendedorNombre = A7VendedorNombre;
            Z27ProductoPaisNombre = A27ProductoPaisNombre;
            Z5CategoriaNombre = A5CategoriaNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         edtProductoID_Enabled = 0;
         AssignProp("", false, edtProductoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoID_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_6_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"VENDEDORID"+"'), id:'"+"VENDEDORID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_26_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTOPAISID"+"'), id:'"+"PRODUCTOPAISID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CATEGORIAID"+"'), id:'"+"CATEGORIAID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtProductoID_Enabled = 0;
         AssignProp("", false, edtProductoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoID_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_VendedorID) )
         {
            edtVendedorID_Enabled = 0;
            AssignProp("", false, edtVendedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVendedorID_Enabled), 5, 0), true);
         }
         else
         {
            edtVendedorID_Enabled = 1;
            AssignProp("", false, edtVendedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVendedorID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV15Insert_ProductoPaisID) )
         {
            edtProductoPaisID_Enabled = 0;
            AssignProp("", false, edtProductoPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoPaisID_Enabled), 5, 0), true);
         }
         else
         {
            edtProductoPaisID_Enabled = 1;
            AssignProp("", false, edtProductoPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoPaisID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_CategoriaID) )
         {
            edtCategoriaID_Enabled = 0;
            AssignProp("", false, edtCategoriaID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaID_Enabled), 5, 0), true);
         }
         else
         {
            edtCategoriaID_Enabled = 1;
            AssignProp("", false, edtCategoriaID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaID_Enabled), 5, 0), true);
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
         if ( ! (0==AV7ProductoID) )
         {
            A19ProductoID = AV7ProductoID;
            AssignAttri("", false, "A19ProductoID", StringUtil.LTrimStr( (decimal)(A19ProductoID), 6, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A19ProductoID) && ( Gx_BScreen == 0 ) )
            {
               A19ProductoID = 1;
               AssignAttri("", false, "A19ProductoID", StringUtil.LTrimStr( (decimal)(A19ProductoID), 6, 0));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_VendedorID) )
         {
            A6VendedorID = AV11Insert_VendedorID;
            AssignAttri("", false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A6VendedorID) && ( Gx_BScreen == 0 ) )
            {
               A6VendedorID = 1;
               AssignAttri("", false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV15Insert_ProductoPaisID) )
         {
            A26ProductoPaisID = AV15Insert_ProductoPaisID;
            AssignAttri("", false, "A26ProductoPaisID", StringUtil.LTrimStr( (decimal)(A26ProductoPaisID), 6, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A26ProductoPaisID) && ( Gx_BScreen == 0 ) )
            {
               A26ProductoPaisID = 1;
               AssignAttri("", false, "A26ProductoPaisID", StringUtil.LTrimStr( (decimal)(A26ProductoPaisID), 6, 0));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_CategoriaID) )
         {
            A4CategoriaID = AV13Insert_CategoriaID;
            AssignAttri("", false, "A4CategoriaID", StringUtil.LTrimStr( (decimal)(A4CategoriaID), 6, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A4CategoriaID) && ( Gx_BScreen == 0 ) )
            {
               A4CategoriaID = 1;
               AssignAttri("", false, "A4CategoriaID", StringUtil.LTrimStr( (decimal)(A4CategoriaID), 6, 0));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV16Pgmname = "Producto";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T00074 */
            pr_default.execute(2, new Object[] {A6VendedorID});
            A7VendedorNombre = T00074_A7VendedorNombre[0];
            AssignAttri("", false, "A7VendedorNombre", A7VendedorNombre);
            pr_default.close(2);
            /* Using cursor T00076 */
            pr_default.execute(4, new Object[] {A26ProductoPaisID});
            A27ProductoPaisNombre = T00076_A27ProductoPaisNombre[0];
            AssignAttri("", false, "A27ProductoPaisNombre", A27ProductoPaisNombre);
            pr_default.close(4);
            /* Using cursor T00075 */
            pr_default.execute(3, new Object[] {A4CategoriaID});
            A5CategoriaNombre = T00075_A5CategoriaNombre[0];
            AssignAttri("", false, "A5CategoriaNombre", A5CategoriaNombre);
            pr_default.close(3);
         }
      }

      protected void Load077( )
      {
         /* Using cursor T00077 */
         pr_default.execute(5, new Object[] {A19ProductoID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound7 = 1;
            A20ProductoNombre = T00077_A20ProductoNombre[0];
            AssignAttri("", false, "A20ProductoNombre", A20ProductoNombre);
            A21ProductoDescripcion = T00077_A21ProductoDescripcion[0];
            AssignAttri("", false, "A21ProductoDescripcion", A21ProductoDescripcion);
            A22ProductoPrecio = T00077_A22ProductoPrecio[0];
            AssignAttri("", false, "A22ProductoPrecio", StringUtil.LTrimStr( A22ProductoPrecio, 10, 2));
            A40000ProductoImagen_GXI = T00077_A40000ProductoImagen_GXI[0];
            AssignProp("", false, imgProductoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductoImagen)) ? A40000ProductoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A23ProductoImagen))), true);
            AssignProp("", false, imgProductoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A23ProductoImagen), true);
            A7VendedorNombre = T00077_A7VendedorNombre[0];
            AssignAttri("", false, "A7VendedorNombre", A7VendedorNombre);
            A27ProductoPaisNombre = T00077_A27ProductoPaisNombre[0];
            AssignAttri("", false, "A27ProductoPaisNombre", A27ProductoPaisNombre);
            A5CategoriaNombre = T00077_A5CategoriaNombre[0];
            AssignAttri("", false, "A5CategoriaNombre", A5CategoriaNombre);
            A6VendedorID = T00077_A6VendedorID[0];
            AssignAttri("", false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
            A4CategoriaID = T00077_A4CategoriaID[0];
            AssignAttri("", false, "A4CategoriaID", StringUtil.LTrimStr( (decimal)(A4CategoriaID), 6, 0));
            A26ProductoPaisID = T00077_A26ProductoPaisID[0];
            AssignAttri("", false, "A26ProductoPaisID", StringUtil.LTrimStr( (decimal)(A26ProductoPaisID), 6, 0));
            A23ProductoImagen = T00077_A23ProductoImagen[0];
            AssignAttri("", false, "A23ProductoImagen", A23ProductoImagen);
            AssignProp("", false, imgProductoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductoImagen)) ? A40000ProductoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A23ProductoImagen))), true);
            AssignProp("", false, imgProductoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A23ProductoImagen), true);
            ZM077( -16) ;
         }
         pr_default.close(5);
         OnLoadActions077( ) ;
      }

      protected void OnLoadActions077( )
      {
         AV16Pgmname = "Producto";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
      }

      protected void CheckExtendedTable077( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV16Pgmname = "Producto";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A20ProductoNombre)) )
         {
            GX_msglist.addItem("Error, El nombre del Producto es Obligatorio!!!", 1, "PRODUCTONOMBRE");
            AnyError = 1;
            GX_FocusControl = edtProductoNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (Convert.ToDecimal(0)==A22ProductoPrecio) )
         {
            GX_msglist.addItem("Error, El precio es Obligatorio!!!", 1, "PRODUCTOPRECIO");
            AnyError = 1;
            GX_FocusControl = edtProductoPrecio_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00074 */
         pr_default.execute(2, new Object[] {A6VendedorID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Vendedor'.", "ForeignKeyNotFound", 1, "VENDEDORID");
            AnyError = 1;
            GX_FocusControl = edtVendedorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A7VendedorNombre = T00074_A7VendedorNombre[0];
         AssignAttri("", false, "A7VendedorNombre", A7VendedorNombre);
         pr_default.close(2);
         /* Using cursor T00076 */
         pr_default.execute(4, new Object[] {A26ProductoPaisID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Pais Producto'.", "ForeignKeyNotFound", 1, "PRODUCTOPAISID");
            AnyError = 1;
            GX_FocusControl = edtProductoPaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A27ProductoPaisNombre = T00076_A27ProductoPaisNombre[0];
         AssignAttri("", false, "A27ProductoPaisNombre", A27ProductoPaisNombre);
         pr_default.close(4);
         /* Using cursor T00075 */
         pr_default.execute(3, new Object[] {A4CategoriaID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching 'Categoria'.", "ForeignKeyNotFound", 1, "CATEGORIAID");
            AnyError = 1;
            GX_FocusControl = edtCategoriaID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A5CategoriaNombre = T00075_A5CategoriaNombre[0];
         AssignAttri("", false, "A5CategoriaNombre", A5CategoriaNombre);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors077( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_17( int A6VendedorID )
      {
         /* Using cursor T00078 */
         pr_default.execute(6, new Object[] {A6VendedorID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching 'Vendedor'.", "ForeignKeyNotFound", 1, "VENDEDORID");
            AnyError = 1;
            GX_FocusControl = edtVendedorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A7VendedorNombre = T00078_A7VendedorNombre[0];
         AssignAttri("", false, "A7VendedorNombre", A7VendedorNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A7VendedorNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_19( int A26ProductoPaisID )
      {
         /* Using cursor T00079 */
         pr_default.execute(7, new Object[] {A26ProductoPaisID});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No matching 'Pais Producto'.", "ForeignKeyNotFound", 1, "PRODUCTOPAISID");
            AnyError = 1;
            GX_FocusControl = edtProductoPaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A27ProductoPaisNombre = T00079_A27ProductoPaisNombre[0];
         AssignAttri("", false, "A27ProductoPaisNombre", A27ProductoPaisNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A27ProductoPaisNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_18( int A4CategoriaID )
      {
         /* Using cursor T000710 */
         pr_default.execute(8, new Object[] {A4CategoriaID});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No matching 'Categoria'.", "ForeignKeyNotFound", 1, "CATEGORIAID");
            AnyError = 1;
            GX_FocusControl = edtCategoriaID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A5CategoriaNombre = T000710_A5CategoriaNombre[0];
         AssignAttri("", false, "A5CategoriaNombre", A5CategoriaNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A5CategoriaNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey077( )
      {
         /* Using cursor T000711 */
         pr_default.execute(9, new Object[] {A19ProductoID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00073 */
         pr_default.execute(1, new Object[] {A19ProductoID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM077( 16) ;
            RcdFound7 = 1;
            A19ProductoID = T00073_A19ProductoID[0];
            AssignAttri("", false, "A19ProductoID", StringUtil.LTrimStr( (decimal)(A19ProductoID), 6, 0));
            A20ProductoNombre = T00073_A20ProductoNombre[0];
            AssignAttri("", false, "A20ProductoNombre", A20ProductoNombre);
            A21ProductoDescripcion = T00073_A21ProductoDescripcion[0];
            AssignAttri("", false, "A21ProductoDescripcion", A21ProductoDescripcion);
            A22ProductoPrecio = T00073_A22ProductoPrecio[0];
            AssignAttri("", false, "A22ProductoPrecio", StringUtil.LTrimStr( A22ProductoPrecio, 10, 2));
            A40000ProductoImagen_GXI = T00073_A40000ProductoImagen_GXI[0];
            AssignProp("", false, imgProductoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductoImagen)) ? A40000ProductoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A23ProductoImagen))), true);
            AssignProp("", false, imgProductoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A23ProductoImagen), true);
            A6VendedorID = T00073_A6VendedorID[0];
            AssignAttri("", false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
            A4CategoriaID = T00073_A4CategoriaID[0];
            AssignAttri("", false, "A4CategoriaID", StringUtil.LTrimStr( (decimal)(A4CategoriaID), 6, 0));
            A26ProductoPaisID = T00073_A26ProductoPaisID[0];
            AssignAttri("", false, "A26ProductoPaisID", StringUtil.LTrimStr( (decimal)(A26ProductoPaisID), 6, 0));
            A23ProductoImagen = T00073_A23ProductoImagen[0];
            AssignAttri("", false, "A23ProductoImagen", A23ProductoImagen);
            AssignProp("", false, imgProductoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductoImagen)) ? A40000ProductoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A23ProductoImagen))), true);
            AssignProp("", false, imgProductoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A23ProductoImagen), true);
            Z19ProductoID = A19ProductoID;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load077( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey077( ) ;
            }
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey077( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey077( ) ;
         if ( RcdFound7 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound7 = 0;
         /* Using cursor T000712 */
         pr_default.execute(10, new Object[] {A19ProductoID});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000712_A19ProductoID[0] < A19ProductoID ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000712_A19ProductoID[0] > A19ProductoID ) ) )
            {
               A19ProductoID = T000712_A19ProductoID[0];
               AssignAttri("", false, "A19ProductoID", StringUtil.LTrimStr( (decimal)(A19ProductoID), 6, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound7 = 0;
         /* Using cursor T000713 */
         pr_default.execute(11, new Object[] {A19ProductoID});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000713_A19ProductoID[0] > A19ProductoID ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000713_A19ProductoID[0] < A19ProductoID ) ) )
            {
               A19ProductoID = T000713_A19ProductoID[0];
               AssignAttri("", false, "A19ProductoID", StringUtil.LTrimStr( (decimal)(A19ProductoID), 6, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey077( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProductoNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert077( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( A19ProductoID != Z19ProductoID )
               {
                  A19ProductoID = Z19ProductoID;
                  AssignAttri("", false, "A19ProductoID", StringUtil.LTrimStr( (decimal)(A19ProductoID), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PRODUCTOID");
                  AnyError = 1;
                  GX_FocusControl = edtProductoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProductoNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update077( ) ;
                  GX_FocusControl = edtProductoNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A19ProductoID != Z19ProductoID )
               {
                  /* Insert record */
                  GX_FocusControl = edtProductoNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert077( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PRODUCTOID");
                     AnyError = 1;
                     GX_FocusControl = edtProductoID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtProductoNombre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert077( ) ;
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
         if ( A19ProductoID != Z19ProductoID )
         {
            A19ProductoID = Z19ProductoID;
            AssignAttri("", false, "A19ProductoID", StringUtil.LTrimStr( (decimal)(A19ProductoID), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PRODUCTOID");
            AnyError = 1;
            GX_FocusControl = edtProductoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProductoNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency077( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00072 */
            pr_default.execute(0, new Object[] {A19ProductoID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Producto"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z20ProductoNombre, T00072_A20ProductoNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z21ProductoDescripcion, T00072_A21ProductoDescripcion[0]) != 0 ) || ( Z22ProductoPrecio != T00072_A22ProductoPrecio[0] ) || ( Z6VendedorID != T00072_A6VendedorID[0] ) || ( Z4CategoriaID != T00072_A4CategoriaID[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z26ProductoPaisID != T00072_A26ProductoPaisID[0] ) )
            {
               if ( StringUtil.StrCmp(Z20ProductoNombre, T00072_A20ProductoNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("producto:[seudo value changed for attri]"+"ProductoNombre");
                  GXUtil.WriteLogRaw("Old: ",Z20ProductoNombre);
                  GXUtil.WriteLogRaw("Current: ",T00072_A20ProductoNombre[0]);
               }
               if ( StringUtil.StrCmp(Z21ProductoDescripcion, T00072_A21ProductoDescripcion[0]) != 0 )
               {
                  GXUtil.WriteLog("producto:[seudo value changed for attri]"+"ProductoDescripcion");
                  GXUtil.WriteLogRaw("Old: ",Z21ProductoDescripcion);
                  GXUtil.WriteLogRaw("Current: ",T00072_A21ProductoDescripcion[0]);
               }
               if ( Z22ProductoPrecio != T00072_A22ProductoPrecio[0] )
               {
                  GXUtil.WriteLog("producto:[seudo value changed for attri]"+"ProductoPrecio");
                  GXUtil.WriteLogRaw("Old: ",Z22ProductoPrecio);
                  GXUtil.WriteLogRaw("Current: ",T00072_A22ProductoPrecio[0]);
               }
               if ( Z6VendedorID != T00072_A6VendedorID[0] )
               {
                  GXUtil.WriteLog("producto:[seudo value changed for attri]"+"VendedorID");
                  GXUtil.WriteLogRaw("Old: ",Z6VendedorID);
                  GXUtil.WriteLogRaw("Current: ",T00072_A6VendedorID[0]);
               }
               if ( Z4CategoriaID != T00072_A4CategoriaID[0] )
               {
                  GXUtil.WriteLog("producto:[seudo value changed for attri]"+"CategoriaID");
                  GXUtil.WriteLogRaw("Old: ",Z4CategoriaID);
                  GXUtil.WriteLogRaw("Current: ",T00072_A4CategoriaID[0]);
               }
               if ( Z26ProductoPaisID != T00072_A26ProductoPaisID[0] )
               {
                  GXUtil.WriteLog("producto:[seudo value changed for attri]"+"ProductoPaisID");
                  GXUtil.WriteLogRaw("Old: ",Z26ProductoPaisID);
                  GXUtil.WriteLogRaw("Current: ",T00072_A26ProductoPaisID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Producto"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert077( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM077( 0) ;
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000714 */
                     pr_default.execute(12, new Object[] {A20ProductoNombre, A21ProductoDescripcion, A22ProductoPrecio, A23ProductoImagen, A40000ProductoImagen_GXI, A6VendedorID, A4CategoriaID, A26ProductoPaisID});
                     A19ProductoID = T000714_A19ProductoID[0];
                     AssignAttri("", false, "A19ProductoID", StringUtil.LTrimStr( (decimal)(A19ProductoID), 6, 0));
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Producto");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
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
            else
            {
               Load077( ) ;
            }
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void Update077( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000715 */
                     pr_default.execute(13, new Object[] {A20ProductoNombre, A21ProductoDescripcion, A22ProductoPrecio, A6VendedorID, A4CategoriaID, A26ProductoPaisID, A19ProductoID});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Producto");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Producto"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate077( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
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
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void DeferredUpdate077( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000716 */
            pr_default.execute(14, new Object[] {A23ProductoImagen, A40000ProductoImagen_GXI, A19ProductoID});
            pr_default.close(14);
            pr_default.SmartCacheProvider.SetUpdated("Producto");
         }
      }

      protected void delete( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls077( ) ;
            AfterConfirm077( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete077( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000717 */
                  pr_default.execute(15, new Object[] {A19ProductoID});
                  pr_default.close(15);
                  pr_default.SmartCacheProvider.SetUpdated("Producto");
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
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel077( ) ;
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls077( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV16Pgmname = "Producto";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T000718 */
            pr_default.execute(16, new Object[] {A6VendedorID});
            A7VendedorNombre = T000718_A7VendedorNombre[0];
            AssignAttri("", false, "A7VendedorNombre", A7VendedorNombre);
            pr_default.close(16);
            /* Using cursor T000719 */
            pr_default.execute(17, new Object[] {A26ProductoPaisID});
            A27ProductoPaisNombre = T000719_A27ProductoPaisNombre[0];
            AssignAttri("", false, "A27ProductoPaisNombre", A27ProductoPaisNombre);
            pr_default.close(17);
            /* Using cursor T000720 */
            pr_default.execute(18, new Object[] {A4CategoriaID});
            A5CategoriaNombre = T000720_A5CategoriaNombre[0];
            AssignAttri("", false, "A5CategoriaNombre", A5CategoriaNombre);
            pr_default.close(18);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000721 */
            pr_default.execute(19, new Object[] {A19ProductoID});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle Compra"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
         }
      }

      protected void EndLevel077( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete077( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(16);
            pr_default.close(18);
            pr_default.close(17);
            context.CommitDataStores("producto",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues070( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(16);
            pr_default.close(18);
            pr_default.close(17);
            context.RollbackDataStores("producto",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart077( )
      {
         /* Scan By routine */
         /* Using cursor T000722 */
         pr_default.execute(20);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound7 = 1;
            A19ProductoID = T000722_A19ProductoID[0];
            AssignAttri("", false, "A19ProductoID", StringUtil.LTrimStr( (decimal)(A19ProductoID), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext077( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound7 = 1;
            A19ProductoID = T000722_A19ProductoID[0];
            AssignAttri("", false, "A19ProductoID", StringUtil.LTrimStr( (decimal)(A19ProductoID), 6, 0));
         }
      }

      protected void ScanEnd077( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm077( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert077( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate077( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete077( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete077( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate077( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes077( )
      {
         edtProductoID_Enabled = 0;
         AssignProp("", false, edtProductoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoID_Enabled), 5, 0), true);
         edtProductoNombre_Enabled = 0;
         AssignProp("", false, edtProductoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoNombre_Enabled), 5, 0), true);
         edtProductoDescripcion_Enabled = 0;
         AssignProp("", false, edtProductoDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoDescripcion_Enabled), 5, 0), true);
         edtProductoPrecio_Enabled = 0;
         AssignProp("", false, edtProductoPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoPrecio_Enabled), 5, 0), true);
         imgProductoImagen_Enabled = 0;
         AssignProp("", false, imgProductoImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProductoImagen_Enabled), 5, 0), true);
         edtVendedorID_Enabled = 0;
         AssignProp("", false, edtVendedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVendedorID_Enabled), 5, 0), true);
         edtVendedorNombre_Enabled = 0;
         AssignProp("", false, edtVendedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVendedorNombre_Enabled), 5, 0), true);
         edtProductoPaisID_Enabled = 0;
         AssignProp("", false, edtProductoPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoPaisID_Enabled), 5, 0), true);
         edtProductoPaisNombre_Enabled = 0;
         AssignProp("", false, edtProductoPaisNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoPaisNombre_Enabled), 5, 0), true);
         edtCategoriaID_Enabled = 0;
         AssignProp("", false, edtCategoriaID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaID_Enabled), 5, 0), true);
         edtCategoriaNombre_Enabled = 0;
         AssignProp("", false, edtCategoriaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaNombre_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes077( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues070( )
      {
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("producto.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ProductoID,6,0))}, new string[] {"Gx_mode","ProductoID"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Producto");
         forbiddenHiddens.Add("ProductoID", context.localUtil.Format( (decimal)(A19ProductoID), "ZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("producto:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z19ProductoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19ProductoID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z20ProductoNombre", Z20ProductoNombre);
         GxWebStd.gx_hidden_field( context, "Z21ProductoDescripcion", Z21ProductoDescripcion);
         GxWebStd.gx_hidden_field( context, "Z22ProductoPrecio", StringUtil.LTrim( StringUtil.NToC( Z22ProductoPrecio, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z6VendedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z6VendedorID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z4CategoriaID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4CategoriaID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z26ProductoPaisID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26ProductoPaisID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N6VendedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A6VendedorID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N26ProductoPaisID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A26ProductoPaisID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N4CategoriaID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CategoriaID), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vPRODUCTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ProductoID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProductoID), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_VENDEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_VendedorID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PRODUCTOPAISID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15Insert_ProductoPaisID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CATEGORIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_CategoriaID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTOIMAGEN_GXI", A40000ProductoImagen_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV16Pgmname));
         GXCCtlgxBlob = "PRODUCTOIMAGEN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A23ProductoImagen);
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
         return formatLink("producto.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ProductoID,6,0))}, new string[] {"Gx_mode","ProductoID"})  ;
      }

      public override string GetPgmname( )
      {
         return "Producto" ;
      }

      public override string GetPgmdesc( )
      {
         return "Producto" ;
      }

      protected void InitializeNonKey077( )
      {
         A20ProductoNombre = "";
         AssignAttri("", false, "A20ProductoNombre", A20ProductoNombre);
         A21ProductoDescripcion = "";
         AssignAttri("", false, "A21ProductoDescripcion", A21ProductoDescripcion);
         A22ProductoPrecio = 0;
         AssignAttri("", false, "A22ProductoPrecio", StringUtil.LTrimStr( A22ProductoPrecio, 10, 2));
         A23ProductoImagen = "";
         AssignAttri("", false, "A23ProductoImagen", A23ProductoImagen);
         AssignProp("", false, imgProductoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductoImagen)) ? A40000ProductoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A23ProductoImagen))), true);
         AssignProp("", false, imgProductoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A23ProductoImagen), true);
         A40000ProductoImagen_GXI = "";
         AssignProp("", false, imgProductoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductoImagen)) ? A40000ProductoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A23ProductoImagen))), true);
         AssignProp("", false, imgProductoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A23ProductoImagen), true);
         A7VendedorNombre = "";
         AssignAttri("", false, "A7VendedorNombre", A7VendedorNombre);
         A27ProductoPaisNombre = "";
         AssignAttri("", false, "A27ProductoPaisNombre", A27ProductoPaisNombre);
         A5CategoriaNombre = "";
         AssignAttri("", false, "A5CategoriaNombre", A5CategoriaNombre);
         A6VendedorID = 1;
         AssignAttri("", false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
         A26ProductoPaisID = 1;
         AssignAttri("", false, "A26ProductoPaisID", StringUtil.LTrimStr( (decimal)(A26ProductoPaisID), 6, 0));
         A4CategoriaID = 1;
         AssignAttri("", false, "A4CategoriaID", StringUtil.LTrimStr( (decimal)(A4CategoriaID), 6, 0));
         Z20ProductoNombre = "";
         Z21ProductoDescripcion = "";
         Z22ProductoPrecio = 0;
         Z6VendedorID = 0;
         Z4CategoriaID = 0;
         Z26ProductoPaisID = 0;
      }

      protected void InitAll077( )
      {
         A19ProductoID = 1;
         AssignAttri("", false, "A19ProductoID", StringUtil.LTrimStr( (decimal)(A19ProductoID), 6, 0));
         InitializeNonKey077( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A6VendedorID = i6VendedorID;
         AssignAttri("", false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
         A26ProductoPaisID = i26ProductoPaisID;
         AssignAttri("", false, "A26ProductoPaisID", StringUtil.LTrimStr( (decimal)(A26ProductoPaisID), 6, 0));
         A4CategoriaID = i4CategoriaID;
         AssignAttri("", false, "A4CategoriaID", StringUtil.LTrimStr( (decimal)(A4CategoriaID), 6, 0));
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025522048058", true, true);
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
         context.AddJavascriptSource("producto.js", "?2025522048058", false, true);
         /* End function include_jscripts */
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
         edtProductoID_Internalname = "PRODUCTOID";
         edtProductoNombre_Internalname = "PRODUCTONOMBRE";
         edtProductoDescripcion_Internalname = "PRODUCTODESCRIPCION";
         edtProductoPrecio_Internalname = "PRODUCTOPRECIO";
         imgProductoImagen_Internalname = "PRODUCTOIMAGEN";
         edtVendedorID_Internalname = "VENDEDORID";
         edtVendedorNombre_Internalname = "VENDEDORNOMBRE";
         edtProductoPaisID_Internalname = "PRODUCTOPAISID";
         edtProductoPaisNombre_Internalname = "PRODUCTOPAISNOMBRE";
         edtCategoriaID_Internalname = "CATEGORIAID";
         edtCategoriaNombre_Internalname = "CATEGORIANOMBRE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_6_Internalname = "PROMPT_6";
         imgprompt_26_Internalname = "PROMPT_26";
         imgprompt_4_Internalname = "PROMPT_4";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("miTienda", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Producto";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCategoriaNombre_Jsonclick = "";
         edtCategoriaNombre_Enabled = 0;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtCategoriaID_Jsonclick = "";
         edtCategoriaID_Enabled = 1;
         edtProductoPaisNombre_Jsonclick = "";
         edtProductoPaisNombre_Enabled = 0;
         imgprompt_26_Visible = 1;
         imgprompt_26_Link = "";
         edtProductoPaisID_Jsonclick = "";
         edtProductoPaisID_Enabled = 1;
         edtVendedorNombre_Jsonclick = "";
         edtVendedorNombre_Enabled = 0;
         imgprompt_6_Visible = 1;
         imgprompt_6_Link = "";
         edtVendedorID_Jsonclick = "";
         edtVendedorID_Enabled = 1;
         imgProductoImagen_Enabled = 1;
         edtProductoPrecio_Jsonclick = "";
         edtProductoPrecio_Enabled = 1;
         edtProductoDescripcion_Jsonclick = "";
         edtProductoDescripcion_Enabled = 1;
         edtProductoNombre_Jsonclick = "";
         edtProductoNombre_Enabled = 1;
         edtProductoID_Jsonclick = "";
         edtProductoID_Enabled = 0;
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

      public void Valid_Vendedorid( )
      {
         /* Using cursor T000718 */
         pr_default.execute(16, new Object[] {A6VendedorID});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No matching 'Vendedor'.", "ForeignKeyNotFound", 1, "VENDEDORID");
            AnyError = 1;
            GX_FocusControl = edtVendedorID_Internalname;
         }
         A7VendedorNombre = T000718_A7VendedorNombre[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A7VendedorNombre", A7VendedorNombre);
      }

      public void Valid_Productopaisid( )
      {
         /* Using cursor T000719 */
         pr_default.execute(17, new Object[] {A26ProductoPaisID});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No matching 'Pais Producto'.", "ForeignKeyNotFound", 1, "PRODUCTOPAISID");
            AnyError = 1;
            GX_FocusControl = edtProductoPaisID_Internalname;
         }
         A27ProductoPaisNombre = T000719_A27ProductoPaisNombre[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A27ProductoPaisNombre", A27ProductoPaisNombre);
      }

      public void Valid_Categoriaid( )
      {
         /* Using cursor T000720 */
         pr_default.execute(18, new Object[] {A4CategoriaID});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No matching 'Categoria'.", "ForeignKeyNotFound", 1, "CATEGORIAID");
            AnyError = 1;
            GX_FocusControl = edtCategoriaID_Internalname;
         }
         A5CategoriaNombre = T000720_A5CategoriaNombre[0];
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A5CategoriaNombre", A5CategoriaNombre);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7ProductoID","fld":"vPRODUCTOID","pic":"ZZZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7ProductoID","fld":"vPRODUCTOID","pic":"ZZZZZ9","hsh":true},{"av":"A19ProductoID","fld":"PRODUCTOID","pic":"ZZZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12072","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_PRODUCTOID","""{"handler":"Valid_Productoid","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTONOMBRE","""{"handler":"Valid_Productonombre","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTOPRECIO","""{"handler":"Valid_Productoprecio","iparms":[]}""");
         setEventMetadata("VALID_VENDEDORID","""{"handler":"Valid_Vendedorid","iparms":[{"av":"A6VendedorID","fld":"VENDEDORID","pic":"ZZZZZ9"},{"av":"A7VendedorNombre","fld":"VENDEDORNOMBRE"}]""");
         setEventMetadata("VALID_VENDEDORID",""","oparms":[{"av":"A7VendedorNombre","fld":"VENDEDORNOMBRE"}]}""");
         setEventMetadata("VALID_PRODUCTOPAISID","""{"handler":"Valid_Productopaisid","iparms":[{"av":"A26ProductoPaisID","fld":"PRODUCTOPAISID","pic":"ZZZZZ9"},{"av":"A27ProductoPaisNombre","fld":"PRODUCTOPAISNOMBRE"}]""");
         setEventMetadata("VALID_PRODUCTOPAISID",""","oparms":[{"av":"A27ProductoPaisNombre","fld":"PRODUCTOPAISNOMBRE"}]}""");
         setEventMetadata("VALID_CATEGORIAID","""{"handler":"Valid_Categoriaid","iparms":[{"av":"A4CategoriaID","fld":"CATEGORIAID","pic":"ZZZZZ9"},{"av":"A5CategoriaNombre","fld":"CATEGORIANOMBRE"}]""");
         setEventMetadata("VALID_CATEGORIAID",""","oparms":[{"av":"A5CategoriaNombre","fld":"CATEGORIANOMBRE"}]}""");
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
         pr_default.close(16);
         pr_default.close(18);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z20ProductoNombre = "";
         Z21ProductoDescripcion = "";
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
         A20ProductoNombre = "";
         A21ProductoDescripcion = "";
         A23ProductoImagen = "";
         A40000ProductoImagen_GXI = "";
         sImgUrl = "";
         imgprompt_6_gximage = "";
         A7VendedorNombre = "";
         imgprompt_26_gximage = "";
         A27ProductoPaisNombre = "";
         imgprompt_4_gximage = "";
         A5CategoriaNombre = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV11Insert_VendedorID = 1;
         AV15Insert_ProductoPaisID = 1;
         AV13Insert_CategoriaID = 1;
         AV16Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode7 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z23ProductoImagen = "";
         Z40000ProductoImagen_GXI = "";
         Z7VendedorNombre = "";
         Z27ProductoPaisNombre = "";
         Z5CategoriaNombre = "";
         T00074_A7VendedorNombre = new string[] {""} ;
         T00076_A27ProductoPaisNombre = new string[] {""} ;
         T00075_A5CategoriaNombre = new string[] {""} ;
         T00077_A19ProductoID = new int[1] ;
         T00077_A20ProductoNombre = new string[] {""} ;
         T00077_A21ProductoDescripcion = new string[] {""} ;
         T00077_A22ProductoPrecio = new decimal[1] ;
         T00077_A40000ProductoImagen_GXI = new string[] {""} ;
         T00077_A7VendedorNombre = new string[] {""} ;
         T00077_A27ProductoPaisNombre = new string[] {""} ;
         T00077_A5CategoriaNombre = new string[] {""} ;
         T00077_A6VendedorID = new int[1] ;
         T00077_A4CategoriaID = new int[1] ;
         T00077_A26ProductoPaisID = new int[1] ;
         T00077_A23ProductoImagen = new string[] {""} ;
         T00078_A7VendedorNombre = new string[] {""} ;
         T00079_A27ProductoPaisNombre = new string[] {""} ;
         T000710_A5CategoriaNombre = new string[] {""} ;
         T000711_A19ProductoID = new int[1] ;
         T00073_A19ProductoID = new int[1] ;
         T00073_A20ProductoNombre = new string[] {""} ;
         T00073_A21ProductoDescripcion = new string[] {""} ;
         T00073_A22ProductoPrecio = new decimal[1] ;
         T00073_A40000ProductoImagen_GXI = new string[] {""} ;
         T00073_A6VendedorID = new int[1] ;
         T00073_A4CategoriaID = new int[1] ;
         T00073_A26ProductoPaisID = new int[1] ;
         T00073_A23ProductoImagen = new string[] {""} ;
         T000712_A19ProductoID = new int[1] ;
         T000713_A19ProductoID = new int[1] ;
         T00072_A19ProductoID = new int[1] ;
         T00072_A20ProductoNombre = new string[] {""} ;
         T00072_A21ProductoDescripcion = new string[] {""} ;
         T00072_A22ProductoPrecio = new decimal[1] ;
         T00072_A40000ProductoImagen_GXI = new string[] {""} ;
         T00072_A6VendedorID = new int[1] ;
         T00072_A4CategoriaID = new int[1] ;
         T00072_A26ProductoPaisID = new int[1] ;
         T00072_A23ProductoImagen = new string[] {""} ;
         T000714_A19ProductoID = new int[1] ;
         T000718_A7VendedorNombre = new string[] {""} ;
         T000719_A27ProductoPaisNombre = new string[] {""} ;
         T000720_A5CategoriaNombre = new string[] {""} ;
         T000721_A33CarritoID = new int[1] ;
         T000721_A37CarritoDetalleCompraID = new int[1] ;
         T000722_A19ProductoID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.producto__default(),
            new Object[][] {
                new Object[] {
               T00072_A19ProductoID, T00072_A20ProductoNombre, T00072_A21ProductoDescripcion, T00072_A22ProductoPrecio, T00072_A40000ProductoImagen_GXI, T00072_A6VendedorID, T00072_A4CategoriaID, T00072_A26ProductoPaisID, T00072_A23ProductoImagen
               }
               , new Object[] {
               T00073_A19ProductoID, T00073_A20ProductoNombre, T00073_A21ProductoDescripcion, T00073_A22ProductoPrecio, T00073_A40000ProductoImagen_GXI, T00073_A6VendedorID, T00073_A4CategoriaID, T00073_A26ProductoPaisID, T00073_A23ProductoImagen
               }
               , new Object[] {
               T00074_A7VendedorNombre
               }
               , new Object[] {
               T00075_A5CategoriaNombre
               }
               , new Object[] {
               T00076_A27ProductoPaisNombre
               }
               , new Object[] {
               T00077_A19ProductoID, T00077_A20ProductoNombre, T00077_A21ProductoDescripcion, T00077_A22ProductoPrecio, T00077_A40000ProductoImagen_GXI, T00077_A7VendedorNombre, T00077_A27ProductoPaisNombre, T00077_A5CategoriaNombre, T00077_A6VendedorID, T00077_A4CategoriaID,
               T00077_A26ProductoPaisID, T00077_A23ProductoImagen
               }
               , new Object[] {
               T00078_A7VendedorNombre
               }
               , new Object[] {
               T00079_A27ProductoPaisNombre
               }
               , new Object[] {
               T000710_A5CategoriaNombre
               }
               , new Object[] {
               T000711_A19ProductoID
               }
               , new Object[] {
               T000712_A19ProductoID
               }
               , new Object[] {
               T000713_A19ProductoID
               }
               , new Object[] {
               T000714_A19ProductoID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000718_A7VendedorNombre
               }
               , new Object[] {
               T000719_A27ProductoPaisNombre
               }
               , new Object[] {
               T000720_A5CategoriaNombre
               }
               , new Object[] {
               T000721_A33CarritoID, T000721_A37CarritoDetalleCompraID
               }
               , new Object[] {
               T000722_A19ProductoID
               }
            }
         );
         Z4CategoriaID = 1;
         N4CategoriaID = 1;
         i4CategoriaID = 1;
         A4CategoriaID = 1;
         Z26ProductoPaisID = 1;
         N26ProductoPaisID = 1;
         i26ProductoPaisID = 1;
         A26ProductoPaisID = 1;
         Z6VendedorID = 1;
         N6VendedorID = 1;
         i6VendedorID = 1;
         A6VendedorID = 1;
         Z19ProductoID = 1;
         A19ProductoID = 1;
         AV16Pgmname = "Producto";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound7 ;
      private short gxajaxcallmode ;
      private int wcpOAV7ProductoID ;
      private int Z19ProductoID ;
      private int Z6VendedorID ;
      private int Z4CategoriaID ;
      private int Z26ProductoPaisID ;
      private int N6VendedorID ;
      private int N26ProductoPaisID ;
      private int N4CategoriaID ;
      private int A6VendedorID ;
      private int A26ProductoPaisID ;
      private int A4CategoriaID ;
      private int AV7ProductoID ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A19ProductoID ;
      private int edtProductoID_Enabled ;
      private int edtProductoNombre_Enabled ;
      private int edtProductoDescripcion_Enabled ;
      private int edtProductoPrecio_Enabled ;
      private int imgProductoImagen_Enabled ;
      private int edtVendedorID_Enabled ;
      private int imgprompt_6_Visible ;
      private int edtVendedorNombre_Enabled ;
      private int edtProductoPaisID_Enabled ;
      private int imgprompt_26_Visible ;
      private int edtProductoPaisNombre_Enabled ;
      private int edtCategoriaID_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtCategoriaNombre_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV11Insert_VendedorID ;
      private int AV15Insert_ProductoPaisID ;
      private int AV13Insert_CategoriaID ;
      private int AV17GXV1 ;
      private int i6VendedorID ;
      private int i26ProductoPaisID ;
      private int i4CategoriaID ;
      private int idxLst ;
      private decimal Z22ProductoPrecio ;
      private decimal A22ProductoPrecio ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProductoNombre_Internalname ;
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
      private string edtProductoID_Internalname ;
      private string edtProductoID_Jsonclick ;
      private string edtProductoNombre_Jsonclick ;
      private string edtProductoDescripcion_Internalname ;
      private string edtProductoDescripcion_Jsonclick ;
      private string edtProductoPrecio_Internalname ;
      private string edtProductoPrecio_Jsonclick ;
      private string imgProductoImagen_Internalname ;
      private string sImgUrl ;
      private string edtVendedorID_Internalname ;
      private string edtVendedorID_Jsonclick ;
      private string imgprompt_6_gximage ;
      private string imgprompt_6_Internalname ;
      private string imgprompt_6_Link ;
      private string edtVendedorNombre_Internalname ;
      private string edtVendedorNombre_Jsonclick ;
      private string edtProductoPaisID_Internalname ;
      private string edtProductoPaisID_Jsonclick ;
      private string imgprompt_26_gximage ;
      private string imgprompt_26_Internalname ;
      private string imgprompt_26_Link ;
      private string edtProductoPaisNombre_Internalname ;
      private string edtProductoPaisNombre_Jsonclick ;
      private string edtCategoriaID_Internalname ;
      private string edtCategoriaID_Jsonclick ;
      private string imgprompt_4_gximage ;
      private string imgprompt_4_Internalname ;
      private string imgprompt_4_Link ;
      private string edtCategoriaNombre_Internalname ;
      private string edtCategoriaNombre_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV16Pgmname ;
      private string hsh ;
      private string sMode7 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A23ProductoImagen_IsBlob ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z20ProductoNombre ;
      private string Z21ProductoDescripcion ;
      private string A20ProductoNombre ;
      private string A21ProductoDescripcion ;
      private string A40000ProductoImagen_GXI ;
      private string A7VendedorNombre ;
      private string A27ProductoPaisNombre ;
      private string A5CategoriaNombre ;
      private string Z40000ProductoImagen_GXI ;
      private string Z7VendedorNombre ;
      private string Z27ProductoPaisNombre ;
      private string Z5CategoriaNombre ;
      private string A23ProductoImagen ;
      private string Z23ProductoImagen ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00074_A7VendedorNombre ;
      private string[] T00076_A27ProductoPaisNombre ;
      private string[] T00075_A5CategoriaNombre ;
      private int[] T00077_A19ProductoID ;
      private string[] T00077_A20ProductoNombre ;
      private string[] T00077_A21ProductoDescripcion ;
      private decimal[] T00077_A22ProductoPrecio ;
      private string[] T00077_A40000ProductoImagen_GXI ;
      private string[] T00077_A7VendedorNombre ;
      private string[] T00077_A27ProductoPaisNombre ;
      private string[] T00077_A5CategoriaNombre ;
      private int[] T00077_A6VendedorID ;
      private int[] T00077_A4CategoriaID ;
      private int[] T00077_A26ProductoPaisID ;
      private string[] T00077_A23ProductoImagen ;
      private string[] T00078_A7VendedorNombre ;
      private string[] T00079_A27ProductoPaisNombre ;
      private string[] T000710_A5CategoriaNombre ;
      private int[] T000711_A19ProductoID ;
      private int[] T00073_A19ProductoID ;
      private string[] T00073_A20ProductoNombre ;
      private string[] T00073_A21ProductoDescripcion ;
      private decimal[] T00073_A22ProductoPrecio ;
      private string[] T00073_A40000ProductoImagen_GXI ;
      private int[] T00073_A6VendedorID ;
      private int[] T00073_A4CategoriaID ;
      private int[] T00073_A26ProductoPaisID ;
      private string[] T00073_A23ProductoImagen ;
      private int[] T000712_A19ProductoID ;
      private int[] T000713_A19ProductoID ;
      private int[] T00072_A19ProductoID ;
      private string[] T00072_A20ProductoNombre ;
      private string[] T00072_A21ProductoDescripcion ;
      private decimal[] T00072_A22ProductoPrecio ;
      private string[] T00072_A40000ProductoImagen_GXI ;
      private int[] T00072_A6VendedorID ;
      private int[] T00072_A4CategoriaID ;
      private int[] T00072_A26ProductoPaisID ;
      private string[] T00072_A23ProductoImagen ;
      private int[] T000714_A19ProductoID ;
      private string[] T000718_A7VendedorNombre ;
      private string[] T000719_A27ProductoPaisNombre ;
      private string[] T000720_A5CategoriaNombre ;
      private int[] T000721_A33CarritoID ;
      private int[] T000721_A37CarritoDetalleCompraID ;
      private int[] T000722_A19ProductoID ;
   }

   public class producto__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00072;
          prmT00072 = new Object[] {
          new ParDef("@ProductoID",GXType.Int32,6,0)
          };
          Object[] prmT00073;
          prmT00073 = new Object[] {
          new ParDef("@ProductoID",GXType.Int32,6,0)
          };
          Object[] prmT00074;
          prmT00074 = new Object[] {
          new ParDef("@VendedorID",GXType.Int32,6,0)
          };
          Object[] prmT00075;
          prmT00075 = new Object[] {
          new ParDef("@CategoriaID",GXType.Int32,6,0)
          };
          Object[] prmT00076;
          prmT00076 = new Object[] {
          new ParDef("@ProductoPaisID",GXType.Int32,6,0)
          };
          Object[] prmT00077;
          prmT00077 = new Object[] {
          new ParDef("@ProductoID",GXType.Int32,6,0)
          };
          Object[] prmT00078;
          prmT00078 = new Object[] {
          new ParDef("@VendedorID",GXType.Int32,6,0)
          };
          Object[] prmT00079;
          prmT00079 = new Object[] {
          new ParDef("@ProductoPaisID",GXType.Int32,6,0)
          };
          Object[] prmT000710;
          prmT000710 = new Object[] {
          new ParDef("@CategoriaID",GXType.Int32,6,0)
          };
          Object[] prmT000711;
          prmT000711 = new Object[] {
          new ParDef("@ProductoID",GXType.Int32,6,0)
          };
          Object[] prmT000712;
          prmT000712 = new Object[] {
          new ParDef("@ProductoID",GXType.Int32,6,0)
          };
          Object[] prmT000713;
          prmT000713 = new Object[] {
          new ParDef("@ProductoID",GXType.Int32,6,0)
          };
          Object[] prmT000714;
          prmT000714 = new Object[] {
          new ParDef("@ProductoNombre",GXType.NVarChar,80,0) ,
          new ParDef("@ProductoDescripcion",GXType.NVarChar,80,0) ,
          new ParDef("@ProductoPrecio",GXType.Decimal,10,2) ,
          new ParDef("@ProductoImagen",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@ProductoImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=3, Tbl="Producto", Fld="ProductoImagen"} ,
          new ParDef("@VendedorID",GXType.Int32,6,0) ,
          new ParDef("@CategoriaID",GXType.Int32,6,0) ,
          new ParDef("@ProductoPaisID",GXType.Int32,6,0)
          };
          Object[] prmT000715;
          prmT000715 = new Object[] {
          new ParDef("@ProductoNombre",GXType.NVarChar,80,0) ,
          new ParDef("@ProductoDescripcion",GXType.NVarChar,80,0) ,
          new ParDef("@ProductoPrecio",GXType.Decimal,10,2) ,
          new ParDef("@VendedorID",GXType.Int32,6,0) ,
          new ParDef("@CategoriaID",GXType.Int32,6,0) ,
          new ParDef("@ProductoPaisID",GXType.Int32,6,0) ,
          new ParDef("@ProductoID",GXType.Int32,6,0)
          };
          Object[] prmT000716;
          prmT000716 = new Object[] {
          new ParDef("@ProductoImagen",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@ProductoImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Producto", Fld="ProductoImagen"} ,
          new ParDef("@ProductoID",GXType.Int32,6,0)
          };
          Object[] prmT000717;
          prmT000717 = new Object[] {
          new ParDef("@ProductoID",GXType.Int32,6,0)
          };
          Object[] prmT000718;
          prmT000718 = new Object[] {
          new ParDef("@VendedorID",GXType.Int32,6,0)
          };
          Object[] prmT000719;
          prmT000719 = new Object[] {
          new ParDef("@ProductoPaisID",GXType.Int32,6,0)
          };
          Object[] prmT000720;
          prmT000720 = new Object[] {
          new ParDef("@CategoriaID",GXType.Int32,6,0)
          };
          Object[] prmT000721;
          prmT000721 = new Object[] {
          new ParDef("@ProductoID",GXType.Int32,6,0)
          };
          Object[] prmT000722;
          prmT000722 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00072", "SELECT [ProductoID], [ProductoNombre], [ProductoDescripcion], [ProductoPrecio], [ProductoImagen_GXI], [VendedorID], [CategoriaID], [ProductoPaisID] AS ProductoPaisID, [ProductoImagen] FROM [Producto] WITH (UPDLOCK) WHERE [ProductoID] = @ProductoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00073", "SELECT [ProductoID], [ProductoNombre], [ProductoDescripcion], [ProductoPrecio], [ProductoImagen_GXI], [VendedorID], [CategoriaID], [ProductoPaisID] AS ProductoPaisID, [ProductoImagen] FROM [Producto] WHERE [ProductoID] = @ProductoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00074", "SELECT [VendedorNombre] FROM [Vendedor] WHERE [VendedorID] = @VendedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00074,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00075", "SELECT [CategoriaNombre] FROM [Categoria] WHERE [CategoriaID] = @CategoriaID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00075,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00076", "SELECT [PaisNombre] AS ProductoPaisNombre FROM [Pais] WHERE [PaisID] = @ProductoPaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00076,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00077", "SELECT TM1.[ProductoID], TM1.[ProductoNombre], TM1.[ProductoDescripcion], TM1.[ProductoPrecio], TM1.[ProductoImagen_GXI], T2.[VendedorNombre], T3.[PaisNombre] AS ProductoPaisNombre, T4.[CategoriaNombre], TM1.[VendedorID], TM1.[CategoriaID], TM1.[ProductoPaisID] AS ProductoPaisID, TM1.[ProductoImagen] FROM ((([Producto] TM1 INNER JOIN [Vendedor] T2 ON T2.[VendedorID] = TM1.[VendedorID]) INNER JOIN [Pais] T3 ON T3.[PaisID] = TM1.[ProductoPaisID]) INNER JOIN [Categoria] T4 ON T4.[CategoriaID] = TM1.[CategoriaID]) WHERE TM1.[ProductoID] = @ProductoID ORDER BY TM1.[ProductoID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00077,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00078", "SELECT [VendedorNombre] FROM [Vendedor] WHERE [VendedorID] = @VendedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00078,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00079", "SELECT [PaisNombre] AS ProductoPaisNombre FROM [Pais] WHERE [PaisID] = @ProductoPaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00079,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000710", "SELECT [CategoriaNombre] FROM [Categoria] WHERE [CategoriaID] = @CategoriaID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000710,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000711", "SELECT [ProductoID] FROM [Producto] WHERE [ProductoID] = @ProductoID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000711,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000712", "SELECT TOP 1 [ProductoID] FROM [Producto] WHERE ( [ProductoID] > @ProductoID) ORDER BY [ProductoID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000712,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000713", "SELECT TOP 1 [ProductoID] FROM [Producto] WHERE ( [ProductoID] < @ProductoID) ORDER BY [ProductoID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000713,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000714", "INSERT INTO [Producto]([ProductoNombre], [ProductoDescripcion], [ProductoPrecio], [ProductoImagen], [ProductoImagen_GXI], [VendedorID], [CategoriaID], [ProductoPaisID]) VALUES(@ProductoNombre, @ProductoDescripcion, @ProductoPrecio, @ProductoImagen, @ProductoImagen_GXI, @VendedorID, @CategoriaID, @ProductoPaisID); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000714,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000715", "UPDATE [Producto] SET [ProductoNombre]=@ProductoNombre, [ProductoDescripcion]=@ProductoDescripcion, [ProductoPrecio]=@ProductoPrecio, [VendedorID]=@VendedorID, [CategoriaID]=@CategoriaID, [ProductoPaisID]=@ProductoPaisID  WHERE [ProductoID] = @ProductoID", GxErrorMask.GX_NOMASK,prmT000715)
             ,new CursorDef("T000716", "UPDATE [Producto] SET [ProductoImagen]=@ProductoImagen, [ProductoImagen_GXI]=@ProductoImagen_GXI  WHERE [ProductoID] = @ProductoID", GxErrorMask.GX_NOMASK,prmT000716)
             ,new CursorDef("T000717", "DELETE FROM [Producto]  WHERE [ProductoID] = @ProductoID", GxErrorMask.GX_NOMASK,prmT000717)
             ,new CursorDef("T000718", "SELECT [VendedorNombre] FROM [Vendedor] WHERE [VendedorID] = @VendedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000718,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000719", "SELECT [PaisNombre] AS ProductoPaisNombre FROM [Pais] WHERE [PaisID] = @ProductoPaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000719,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000720", "SELECT [CategoriaNombre] FROM [Categoria] WHERE [CategoriaID] = @CategoriaID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000720,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000721", "SELECT TOP 1 [CarritoID], [CarritoDetalleCompraID] FROM [CarritoDetalleCompra] WHERE [ProductoID] = @ProductoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000721,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000722", "SELECT [ProductoID] FROM [Producto] ORDER BY [ProductoID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000722,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(5));
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
