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
   public class vendedor : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A1PaisID = (int)(Math.Round(NumberUtil.Val( GetPar( "PaisID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1PaisID", StringUtil.LTrimStr( (decimal)(A1PaisID), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A1PaisID) ;
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
               AV7VendedorID = (int)(Math.Round(NumberUtil.Val( GetPar( "VendedorID"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7VendedorID", StringUtil.LTrimStr( (decimal)(AV7VendedorID), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vVENDEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7VendedorID), "ZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Vendedor", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtVendedorNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("miTienda", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public vendedor( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("miTienda", true);
      }

      public vendedor( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_VendedorID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7VendedorID = aP1_VendedorID;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Vendedor", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Vendedor.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vendedor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vendedor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vendedor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vendedor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Vendedor.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVendedorID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVendedorID_Internalname, "ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVendedorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A6VendedorID), 6, 0, ".", "")), StringUtil.LTrim( ((edtVendedorID_Enabled!=0) ? context.localUtil.Format( (decimal)(A6VendedorID), "ZZZZZ9") : context.localUtil.Format( (decimal)(A6VendedorID), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVendedorID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVendedorID_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Vendedor.htm");
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
         GxWebStd.gx_label_element( context, edtVendedorNombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVendedorNombre_Internalname, A7VendedorNombre, StringUtil.RTrim( context.localUtil.Format( A7VendedorNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVendedorNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVendedorNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Vendedor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgVendedorFoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Foto", "col-sm-3 ImageLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Image";
         StyleString = "";
         A8VendedorFoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000VendedorFoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)) ? A40000VendedorFoto_GXI : context.PathToRelativeUrl( A8VendedorFoto));
         GxWebStd.gx_bitmap( context, imgVendedorFoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgVendedorFoto_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", "", "", 0, A8VendedorFoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Vendedor.htm");
         AssignProp("", false, imgVendedorFoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)) ? A40000VendedorFoto_GXI : context.PathToRelativeUrl( A8VendedorFoto)), true);
         AssignProp("", false, imgVendedorFoto_Internalname, "IsBlob", StringUtil.BoolToStr( A8VendedorFoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisID_Internalname, "Pais ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1PaisID), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A1PaisID), "ZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisID_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Vendedor.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_1_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_1_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_1_Internalname, sImgUrl, imgprompt_1_Link, "", "", context.GetTheme( ), imgprompt_1_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Vendedor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisNombre_Internalname, "Pais Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisNombre_Internalname, A2PaisNombre, StringUtil.RTrim( context.localUtil.Format( A2PaisNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Vendedor.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vendedor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vendedor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vendedor.htm");
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
         E11032 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z6VendedorID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z6VendedorID"), ".", ","), 18, MidpointRounding.ToEven));
               Z7VendedorNombre = cgiGet( "Z7VendedorNombre");
               Z1PaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z1PaisID"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N1PaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N1PaisID"), ".", ","), 18, MidpointRounding.ToEven));
               AV7VendedorID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vVENDEDORID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV11Insert_PaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PAISID"), ".", ","), 18, MidpointRounding.ToEven));
               A40000VendedorFoto_GXI = cgiGet( "VENDEDORFOTO_GXI");
               AV13Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A6VendedorID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtVendedorID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
               A7VendedorNombre = cgiGet( edtVendedorNombre_Internalname);
               AssignAttri("", false, "A7VendedorNombre", A7VendedorNombre);
               A8VendedorFoto = cgiGet( imgVendedorFoto_Internalname);
               AssignAttri("", false, "A8VendedorFoto", A8VendedorFoto);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPaisID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPaisID_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAISID");
                  AnyError = 1;
                  GX_FocusControl = edtPaisID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1PaisID = 0;
                  AssignAttri("", false, "A1PaisID", StringUtil.LTrimStr( (decimal)(A1PaisID), 6, 0));
               }
               else
               {
                  A1PaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPaisID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1PaisID", StringUtil.LTrimStr( (decimal)(A1PaisID), 6, 0));
               }
               A2PaisNombre = cgiGet( edtPaisNombre_Internalname);
               AssignAttri("", false, "A2PaisNombre", A2PaisNombre);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgVendedorFoto_Internalname, ref  A8VendedorFoto, ref  A40000VendedorFoto_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Vendedor");
               A6VendedorID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtVendedorID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
               forbiddenHiddens.Add("VendedorID", context.localUtil.Format( (decimal)(A6VendedorID), "ZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A6VendedorID != Z6VendedorID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("vendedor:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A6VendedorID = (int)(Math.Round(NumberUtil.Val( GetPar( "VendedorID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
                  getEqualNoModal( ) ;
                  if ( ! (0==AV7VendedorID) )
                  {
                     A6VendedorID = AV7VendedorID;
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
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode3 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (0==AV7VendedorID) )
                     {
                        A6VendedorID = AV7VendedorID;
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
                     Gx_mode = sMode3;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound3 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_030( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "VENDEDORID");
                        AnyError = 1;
                        GX_FocusControl = edtVendedorID_Internalname;
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
                           E11032 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12032 ();
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
            E12032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll033( ) ;
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
            DisableAttributes033( ) ;
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

      protected void CONFIRM_030( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls033( ) ;
            }
            else
            {
               CheckExtendedTable033( ) ;
               CloseExtendedTableCursors033( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption030( )
      {
      }

      protected void E11032( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV13Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_PaisID = 0;
         AssignAttri("", false, "AV11Insert_PaisID", StringUtil.LTrimStr( (decimal)(AV11Insert_PaisID), 6, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV13Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV14GXV1 = 1;
            AssignAttri("", false, "AV14GXV1", StringUtil.LTrimStr( (decimal)(AV14GXV1), 8, 0));
            while ( AV14GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV14GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "PaisID") == 0 )
               {
                  AV11Insert_PaisID = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_PaisID", StringUtil.LTrimStr( (decimal)(AV11Insert_PaisID), 6, 0));
               }
               AV14GXV1 = (int)(AV14GXV1+1);
               AssignAttri("", false, "AV14GXV1", StringUtil.LTrimStr( (decimal)(AV14GXV1), 8, 0));
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

      protected void E12032( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwvendedor.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z7VendedorNombre = T00033_A7VendedorNombre[0];
               Z1PaisID = T00033_A1PaisID[0];
            }
            else
            {
               Z7VendedorNombre = A7VendedorNombre;
               Z1PaisID = A1PaisID;
            }
         }
         if ( GX_JID == -9 )
         {
            Z6VendedorID = A6VendedorID;
            Z7VendedorNombre = A7VendedorNombre;
            Z8VendedorFoto = A8VendedorFoto;
            Z40000VendedorFoto_GXI = A40000VendedorFoto_GXI;
            Z1PaisID = A1PaisID;
            Z2PaisNombre = A2PaisNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         edtVendedorID_Enabled = 0;
         AssignProp("", false, edtVendedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVendedorID_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_1_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PAISID"+"'), id:'"+"PAISID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtVendedorID_Enabled = 0;
         AssignProp("", false, edtVendedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVendedorID_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PaisID) )
         {
            edtPaisID_Enabled = 0;
            AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         }
         else
         {
            edtPaisID_Enabled = 1;
            AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
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
         if ( ! (0==AV7VendedorID) )
         {
            A6VendedorID = AV7VendedorID;
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PaisID) )
         {
            A1PaisID = AV11Insert_PaisID;
            AssignAttri("", false, "A1PaisID", StringUtil.LTrimStr( (decimal)(A1PaisID), 6, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A1PaisID) && ( Gx_BScreen == 0 ) )
            {
               A1PaisID = 1;
               AssignAttri("", false, "A1PaisID", StringUtil.LTrimStr( (decimal)(A1PaisID), 6, 0));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV13Pgmname = "Vendedor";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
            /* Using cursor T00034 */
            pr_default.execute(2, new Object[] {A1PaisID});
            A2PaisNombre = T00034_A2PaisNombre[0];
            AssignAttri("", false, "A2PaisNombre", A2PaisNombre);
            pr_default.close(2);
         }
      }

      protected void Load033( )
      {
         /* Using cursor T00035 */
         pr_default.execute(3, new Object[] {A6VendedorID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound3 = 1;
            A7VendedorNombre = T00035_A7VendedorNombre[0];
            AssignAttri("", false, "A7VendedorNombre", A7VendedorNombre);
            A40000VendedorFoto_GXI = T00035_A40000VendedorFoto_GXI[0];
            AssignProp("", false, imgVendedorFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)) ? A40000VendedorFoto_GXI : context.convertURL( context.PathToRelativeUrl( A8VendedorFoto))), true);
            AssignProp("", false, imgVendedorFoto_Internalname, "SrcSet", context.GetImageSrcSet( A8VendedorFoto), true);
            A2PaisNombre = T00035_A2PaisNombre[0];
            AssignAttri("", false, "A2PaisNombre", A2PaisNombre);
            A1PaisID = T00035_A1PaisID[0];
            AssignAttri("", false, "A1PaisID", StringUtil.LTrimStr( (decimal)(A1PaisID), 6, 0));
            A8VendedorFoto = T00035_A8VendedorFoto[0];
            AssignAttri("", false, "A8VendedorFoto", A8VendedorFoto);
            AssignProp("", false, imgVendedorFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)) ? A40000VendedorFoto_GXI : context.convertURL( context.PathToRelativeUrl( A8VendedorFoto))), true);
            AssignProp("", false, imgVendedorFoto_Internalname, "SrcSet", context.GetImageSrcSet( A8VendedorFoto), true);
            ZM033( -9) ;
         }
         pr_default.close(3);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
         AV13Pgmname = "Vendedor";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
      }

      protected void CheckExtendedTable033( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV13Pgmname = "Vendedor";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A7VendedorNombre)) )
         {
            GX_msglist.addItem("Error, El nombre del Vendedor es obligatorio!!!", 1, "VENDEDORNOMBRE");
            AnyError = 1;
            GX_FocusControl = edtVendedorNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00034 */
         pr_default.execute(2, new Object[] {A1PaisID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2PaisNombre = T00034_A2PaisNombre[0];
         AssignAttri("", false, "A2PaisNombre", A2PaisNombre);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors033( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_10( int A1PaisID )
      {
         /* Using cursor T00036 */
         pr_default.execute(4, new Object[] {A1PaisID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2PaisNombre = T00036_A2PaisNombre[0];
         AssignAttri("", false, "A2PaisNombre", A2PaisNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A2PaisNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey033( )
      {
         /* Using cursor T00037 */
         pr_default.execute(5, new Object[] {A6VendedorID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00033 */
         pr_default.execute(1, new Object[] {A6VendedorID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM033( 9) ;
            RcdFound3 = 1;
            A6VendedorID = T00033_A6VendedorID[0];
            AssignAttri("", false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
            A7VendedorNombre = T00033_A7VendedorNombre[0];
            AssignAttri("", false, "A7VendedorNombre", A7VendedorNombre);
            A40000VendedorFoto_GXI = T00033_A40000VendedorFoto_GXI[0];
            AssignProp("", false, imgVendedorFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)) ? A40000VendedorFoto_GXI : context.convertURL( context.PathToRelativeUrl( A8VendedorFoto))), true);
            AssignProp("", false, imgVendedorFoto_Internalname, "SrcSet", context.GetImageSrcSet( A8VendedorFoto), true);
            A1PaisID = T00033_A1PaisID[0];
            AssignAttri("", false, "A1PaisID", StringUtil.LTrimStr( (decimal)(A1PaisID), 6, 0));
            A8VendedorFoto = T00033_A8VendedorFoto[0];
            AssignAttri("", false, "A8VendedorFoto", A8VendedorFoto);
            AssignProp("", false, imgVendedorFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)) ? A40000VendedorFoto_GXI : context.convertURL( context.PathToRelativeUrl( A8VendedorFoto))), true);
            AssignProp("", false, imgVendedorFoto_Internalname, "SrcSet", context.GetImageSrcSet( A8VendedorFoto), true);
            Z6VendedorID = A6VendedorID;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound3 = 0;
         /* Using cursor T00038 */
         pr_default.execute(6, new Object[] {A6VendedorID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00038_A6VendedorID[0] < A6VendedorID ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00038_A6VendedorID[0] > A6VendedorID ) ) )
            {
               A6VendedorID = T00038_A6VendedorID[0];
               AssignAttri("", false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound3 = 0;
         /* Using cursor T00039 */
         pr_default.execute(7, new Object[] {A6VendedorID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00039_A6VendedorID[0] > A6VendedorID ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00039_A6VendedorID[0] < A6VendedorID ) ) )
            {
               A6VendedorID = T00039_A6VendedorID[0];
               AssignAttri("", false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtVendedorNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert033( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A6VendedorID != Z6VendedorID )
               {
                  A6VendedorID = Z6VendedorID;
                  AssignAttri("", false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "VENDEDORID");
                  AnyError = 1;
                  GX_FocusControl = edtVendedorID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtVendedorNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update033( ) ;
                  GX_FocusControl = edtVendedorNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A6VendedorID != Z6VendedorID )
               {
                  /* Insert record */
                  GX_FocusControl = edtVendedorNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert033( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "VENDEDORID");
                     AnyError = 1;
                     GX_FocusControl = edtVendedorID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtVendedorNombre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert033( ) ;
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
         if ( A6VendedorID != Z6VendedorID )
         {
            A6VendedorID = Z6VendedorID;
            AssignAttri("", false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "VENDEDORID");
            AnyError = 1;
            GX_FocusControl = edtVendedorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtVendedorNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00032 */
            pr_default.execute(0, new Object[] {A6VendedorID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Vendedor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z7VendedorNombre, T00032_A7VendedorNombre[0]) != 0 ) || ( Z1PaisID != T00032_A1PaisID[0] ) )
            {
               if ( StringUtil.StrCmp(Z7VendedorNombre, T00032_A7VendedorNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("vendedor:[seudo value changed for attri]"+"VendedorNombre");
                  GXUtil.WriteLogRaw("Old: ",Z7VendedorNombre);
                  GXUtil.WriteLogRaw("Current: ",T00032_A7VendedorNombre[0]);
               }
               if ( Z1PaisID != T00032_A1PaisID[0] )
               {
                  GXUtil.WriteLog("vendedor:[seudo value changed for attri]"+"PaisID");
                  GXUtil.WriteLogRaw("Old: ",Z1PaisID);
                  GXUtil.WriteLogRaw("Current: ",T00032_A1PaisID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Vendedor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000310 */
                     pr_default.execute(8, new Object[] {A7VendedorNombre, A8VendedorFoto, A40000VendedorFoto_GXI, A1PaisID});
                     A6VendedorID = T000310_A6VendedorID[0];
                     AssignAttri("", false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Vendedor");
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
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000311 */
                     pr_default.execute(9, new Object[] {A7VendedorNombre, A1PaisID, A6VendedorID});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Vendedor");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Vendedor"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate033( ) ;
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
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000312 */
            pr_default.execute(10, new Object[] {A8VendedorFoto, A40000VendedorFoto_GXI, A6VendedorID});
            pr_default.close(10);
            pr_default.SmartCacheProvider.SetUpdated("Vendedor");
         }
      }

      protected void delete( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000313 */
                  pr_default.execute(11, new Object[] {A6VendedorID});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Vendedor");
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
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel033( ) ;
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "Vendedor";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
            /* Using cursor T000314 */
            pr_default.execute(12, new Object[] {A1PaisID});
            A2PaisNombre = T000314_A2PaisNombre[0];
            AssignAttri("", false, "A2PaisNombre", A2PaisNombre);
            pr_default.close(12);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000315 */
            pr_default.execute(13, new Object[] {A6VendedorID});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Producto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel033( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(12);
            context.CommitDataStores("vendedor",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues030( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(12);
            context.RollbackDataStores("vendedor",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart033( )
      {
         /* Scan By routine */
         /* Using cursor T000316 */
         pr_default.execute(14);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound3 = 1;
            A6VendedorID = T000316_A6VendedorID[0];
            AssignAttri("", false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound3 = 1;
            A6VendedorID = T000316_A6VendedorID[0];
            AssignAttri("", false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
         }
      }

      protected void ScanEnd033( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
         edtVendedorID_Enabled = 0;
         AssignProp("", false, edtVendedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVendedorID_Enabled), 5, 0), true);
         edtVendedorNombre_Enabled = 0;
         AssignProp("", false, edtVendedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVendedorNombre_Enabled), 5, 0), true);
         imgVendedorFoto_Enabled = 0;
         AssignProp("", false, imgVendedorFoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgVendedorFoto_Enabled), 5, 0), true);
         edtPaisID_Enabled = 0;
         AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         edtPaisNombre_Enabled = 0;
         AssignProp("", false, edtPaisNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisNombre_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues030( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("vendedor.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7VendedorID,6,0))}, new string[] {"Gx_mode","VendedorID"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Vendedor");
         forbiddenHiddens.Add("VendedorID", context.localUtil.Format( (decimal)(A6VendedorID), "ZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("vendedor:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z6VendedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z6VendedorID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z7VendedorNombre", Z7VendedorNombre);
         GxWebStd.gx_hidden_field( context, "Z1PaisID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1PaisID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N1PaisID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1PaisID), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vVENDEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7VendedorID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vVENDEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7VendedorID), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PAISID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_PaisID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "VENDEDORFOTO_GXI", A40000VendedorFoto_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV13Pgmname));
         GXCCtlgxBlob = "VENDEDORFOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A8VendedorFoto);
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
         return formatLink("vendedor.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7VendedorID,6,0))}, new string[] {"Gx_mode","VendedorID"})  ;
      }

      public override string GetPgmname( )
      {
         return "Vendedor" ;
      }

      public override string GetPgmdesc( )
      {
         return "Vendedor" ;
      }

      protected void InitializeNonKey033( )
      {
         A7VendedorNombre = "";
         AssignAttri("", false, "A7VendedorNombre", A7VendedorNombre);
         A8VendedorFoto = "";
         AssignAttri("", false, "A8VendedorFoto", A8VendedorFoto);
         AssignProp("", false, imgVendedorFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)) ? A40000VendedorFoto_GXI : context.convertURL( context.PathToRelativeUrl( A8VendedorFoto))), true);
         AssignProp("", false, imgVendedorFoto_Internalname, "SrcSet", context.GetImageSrcSet( A8VendedorFoto), true);
         A40000VendedorFoto_GXI = "";
         AssignProp("", false, imgVendedorFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)) ? A40000VendedorFoto_GXI : context.convertURL( context.PathToRelativeUrl( A8VendedorFoto))), true);
         AssignProp("", false, imgVendedorFoto_Internalname, "SrcSet", context.GetImageSrcSet( A8VendedorFoto), true);
         A2PaisNombre = "";
         AssignAttri("", false, "A2PaisNombre", A2PaisNombre);
         A1PaisID = 1;
         AssignAttri("", false, "A1PaisID", StringUtil.LTrimStr( (decimal)(A1PaisID), 6, 0));
         Z7VendedorNombre = "";
         Z1PaisID = 0;
      }

      protected void InitAll033( )
      {
         A6VendedorID = 1;
         AssignAttri("", false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
         InitializeNonKey033( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1PaisID = i1PaisID;
         AssignAttri("", false, "A1PaisID", StringUtil.LTrimStr( (decimal)(A1PaisID), 6, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20255220475850", true, true);
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
         context.AddJavascriptSource("vendedor.js", "?20255220475850", false, true);
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
         edtVendedorID_Internalname = "VENDEDORID";
         edtVendedorNombre_Internalname = "VENDEDORNOMBRE";
         imgVendedorFoto_Internalname = "VENDEDORFOTO";
         edtPaisID_Internalname = "PAISID";
         edtPaisNombre_Internalname = "PAISNOMBRE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_1_Internalname = "PROMPT_1";
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
         Form.Caption = "Vendedor";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPaisNombre_Jsonclick = "";
         edtPaisNombre_Enabled = 0;
         imgprompt_1_Visible = 1;
         imgprompt_1_Link = "";
         edtPaisID_Jsonclick = "";
         edtPaisID_Enabled = 1;
         imgVendedorFoto_Enabled = 1;
         edtVendedorNombre_Jsonclick = "";
         edtVendedorNombre_Enabled = 1;
         edtVendedorID_Jsonclick = "";
         edtVendedorID_Enabled = 0;
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

      public void Valid_Paisid( )
      {
         /* Using cursor T000314 */
         pr_default.execute(12, new Object[] {A1PaisID});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No matching 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisID_Internalname;
         }
         A2PaisNombre = T000314_A2PaisNombre[0];
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2PaisNombre", A2PaisNombre);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7VendedorID","fld":"vVENDEDORID","pic":"ZZZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7VendedorID","fld":"vVENDEDORID","pic":"ZZZZZ9","hsh":true},{"av":"A6VendedorID","fld":"VENDEDORID","pic":"ZZZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12032","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_VENDEDORID","""{"handler":"Valid_Vendedorid","iparms":[]}""");
         setEventMetadata("VALID_VENDEDORNOMBRE","""{"handler":"Valid_Vendedornombre","iparms":[]}""");
         setEventMetadata("VALID_PAISID","""{"handler":"Valid_Paisid","iparms":[{"av":"A1PaisID","fld":"PAISID","pic":"ZZZZZ9"},{"av":"A2PaisNombre","fld":"PAISNOMBRE"}]""");
         setEventMetadata("VALID_PAISID",""","oparms":[{"av":"A2PaisNombre","fld":"PAISNOMBRE"}]}""");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z7VendedorNombre = "";
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
         A7VendedorNombre = "";
         A8VendedorFoto = "";
         A40000VendedorFoto_GXI = "";
         sImgUrl = "";
         imgprompt_1_gximage = "";
         A2PaisNombre = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV11Insert_PaisID = 1;
         AV13Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode3 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z8VendedorFoto = "";
         Z40000VendedorFoto_GXI = "";
         Z2PaisNombre = "";
         T00034_A2PaisNombre = new string[] {""} ;
         T00035_A6VendedorID = new int[1] ;
         T00035_A7VendedorNombre = new string[] {""} ;
         T00035_A40000VendedorFoto_GXI = new string[] {""} ;
         T00035_A2PaisNombre = new string[] {""} ;
         T00035_A1PaisID = new int[1] ;
         T00035_A8VendedorFoto = new string[] {""} ;
         T00036_A2PaisNombre = new string[] {""} ;
         T00037_A6VendedorID = new int[1] ;
         T00033_A6VendedorID = new int[1] ;
         T00033_A7VendedorNombre = new string[] {""} ;
         T00033_A40000VendedorFoto_GXI = new string[] {""} ;
         T00033_A1PaisID = new int[1] ;
         T00033_A8VendedorFoto = new string[] {""} ;
         T00038_A6VendedorID = new int[1] ;
         T00039_A6VendedorID = new int[1] ;
         T00032_A6VendedorID = new int[1] ;
         T00032_A7VendedorNombre = new string[] {""} ;
         T00032_A40000VendedorFoto_GXI = new string[] {""} ;
         T00032_A1PaisID = new int[1] ;
         T00032_A8VendedorFoto = new string[] {""} ;
         T000310_A6VendedorID = new int[1] ;
         T000314_A2PaisNombre = new string[] {""} ;
         T000315_A19ProductoID = new int[1] ;
         T000316_A6VendedorID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.vendedor__default(),
            new Object[][] {
                new Object[] {
               T00032_A6VendedorID, T00032_A7VendedorNombre, T00032_A40000VendedorFoto_GXI, T00032_A1PaisID, T00032_A8VendedorFoto
               }
               , new Object[] {
               T00033_A6VendedorID, T00033_A7VendedorNombre, T00033_A40000VendedorFoto_GXI, T00033_A1PaisID, T00033_A8VendedorFoto
               }
               , new Object[] {
               T00034_A2PaisNombre
               }
               , new Object[] {
               T00035_A6VendedorID, T00035_A7VendedorNombre, T00035_A40000VendedorFoto_GXI, T00035_A2PaisNombre, T00035_A1PaisID, T00035_A8VendedorFoto
               }
               , new Object[] {
               T00036_A2PaisNombre
               }
               , new Object[] {
               T00037_A6VendedorID
               }
               , new Object[] {
               T00038_A6VendedorID
               }
               , new Object[] {
               T00039_A6VendedorID
               }
               , new Object[] {
               T000310_A6VendedorID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000314_A2PaisNombre
               }
               , new Object[] {
               T000315_A19ProductoID
               }
               , new Object[] {
               T000316_A6VendedorID
               }
            }
         );
         Z1PaisID = 1;
         N1PaisID = 1;
         i1PaisID = 1;
         A1PaisID = 1;
         Z6VendedorID = 1;
         A6VendedorID = 1;
         AV13Pgmname = "Vendedor";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound3 ;
      private short gxajaxcallmode ;
      private int wcpOAV7VendedorID ;
      private int Z6VendedorID ;
      private int Z1PaisID ;
      private int N1PaisID ;
      private int A1PaisID ;
      private int AV7VendedorID ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A6VendedorID ;
      private int edtVendedorID_Enabled ;
      private int edtVendedorNombre_Enabled ;
      private int imgVendedorFoto_Enabled ;
      private int edtPaisID_Enabled ;
      private int imgprompt_1_Visible ;
      private int edtPaisNombre_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV11Insert_PaisID ;
      private int AV14GXV1 ;
      private int i1PaisID ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtVendedorNombre_Internalname ;
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
      private string edtVendedorID_Internalname ;
      private string edtVendedorID_Jsonclick ;
      private string edtVendedorNombre_Jsonclick ;
      private string imgVendedorFoto_Internalname ;
      private string sImgUrl ;
      private string edtPaisID_Internalname ;
      private string edtPaisID_Jsonclick ;
      private string imgprompt_1_gximage ;
      private string imgprompt_1_Internalname ;
      private string imgprompt_1_Link ;
      private string edtPaisNombre_Internalname ;
      private string edtPaisNombre_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV13Pgmname ;
      private string hsh ;
      private string sMode3 ;
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
      private bool A8VendedorFoto_IsBlob ;
      private bool returnInSub ;
      private string Z7VendedorNombre ;
      private string A7VendedorNombre ;
      private string A40000VendedorFoto_GXI ;
      private string A2PaisNombre ;
      private string Z40000VendedorFoto_GXI ;
      private string Z2PaisNombre ;
      private string A8VendedorFoto ;
      private string Z8VendedorFoto ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00034_A2PaisNombre ;
      private int[] T00035_A6VendedorID ;
      private string[] T00035_A7VendedorNombre ;
      private string[] T00035_A40000VendedorFoto_GXI ;
      private string[] T00035_A2PaisNombre ;
      private int[] T00035_A1PaisID ;
      private string[] T00035_A8VendedorFoto ;
      private string[] T00036_A2PaisNombre ;
      private int[] T00037_A6VendedorID ;
      private int[] T00033_A6VendedorID ;
      private string[] T00033_A7VendedorNombre ;
      private string[] T00033_A40000VendedorFoto_GXI ;
      private int[] T00033_A1PaisID ;
      private string[] T00033_A8VendedorFoto ;
      private int[] T00038_A6VendedorID ;
      private int[] T00039_A6VendedorID ;
      private int[] T00032_A6VendedorID ;
      private string[] T00032_A7VendedorNombre ;
      private string[] T00032_A40000VendedorFoto_GXI ;
      private int[] T00032_A1PaisID ;
      private string[] T00032_A8VendedorFoto ;
      private int[] T000310_A6VendedorID ;
      private string[] T000314_A2PaisNombre ;
      private int[] T000315_A19ProductoID ;
      private int[] T000316_A6VendedorID ;
   }

   public class vendedor__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00032;
          prmT00032 = new Object[] {
          new ParDef("@VendedorID",GXType.Int32,6,0)
          };
          Object[] prmT00033;
          prmT00033 = new Object[] {
          new ParDef("@VendedorID",GXType.Int32,6,0)
          };
          Object[] prmT00034;
          prmT00034 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,6,0)
          };
          Object[] prmT00035;
          prmT00035 = new Object[] {
          new ParDef("@VendedorID",GXType.Int32,6,0)
          };
          Object[] prmT00036;
          prmT00036 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,6,0)
          };
          Object[] prmT00037;
          prmT00037 = new Object[] {
          new ParDef("@VendedorID",GXType.Int32,6,0)
          };
          Object[] prmT00038;
          prmT00038 = new Object[] {
          new ParDef("@VendedorID",GXType.Int32,6,0)
          };
          Object[] prmT00039;
          prmT00039 = new Object[] {
          new ParDef("@VendedorID",GXType.Int32,6,0)
          };
          Object[] prmT000310;
          prmT000310 = new Object[] {
          new ParDef("@VendedorNombre",GXType.NVarChar,80,0) ,
          new ParDef("@VendedorFoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@VendedorFoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="Vendedor", Fld="VendedorFoto"} ,
          new ParDef("@PaisID",GXType.Int32,6,0)
          };
          Object[] prmT000311;
          prmT000311 = new Object[] {
          new ParDef("@VendedorNombre",GXType.NVarChar,80,0) ,
          new ParDef("@PaisID",GXType.Int32,6,0) ,
          new ParDef("@VendedorID",GXType.Int32,6,0)
          };
          Object[] prmT000312;
          prmT000312 = new Object[] {
          new ParDef("@VendedorFoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@VendedorFoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Vendedor", Fld="VendedorFoto"} ,
          new ParDef("@VendedorID",GXType.Int32,6,0)
          };
          Object[] prmT000313;
          prmT000313 = new Object[] {
          new ParDef("@VendedorID",GXType.Int32,6,0)
          };
          Object[] prmT000314;
          prmT000314 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,6,0)
          };
          Object[] prmT000315;
          prmT000315 = new Object[] {
          new ParDef("@VendedorID",GXType.Int32,6,0)
          };
          Object[] prmT000316;
          prmT000316 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00032", "SELECT [VendedorID], [VendedorNombre], [VendedorFoto_GXI], [PaisID], [VendedorFoto] FROM [Vendedor] WITH (UPDLOCK) WHERE [VendedorID] = @VendedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00032,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00033", "SELECT [VendedorID], [VendedorNombre], [VendedorFoto_GXI], [PaisID], [VendedorFoto] FROM [Vendedor] WHERE [VendedorID] = @VendedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00033,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00034", "SELECT [PaisNombre] FROM [Pais] WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00034,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00035", "SELECT TM1.[VendedorID], TM1.[VendedorNombre], TM1.[VendedorFoto_GXI], T2.[PaisNombre], TM1.[PaisID], TM1.[VendedorFoto] FROM ([Vendedor] TM1 INNER JOIN [Pais] T2 ON T2.[PaisID] = TM1.[PaisID]) WHERE TM1.[VendedorID] = @VendedorID ORDER BY TM1.[VendedorID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00035,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00036", "SELECT [PaisNombre] FROM [Pais] WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00036,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00037", "SELECT [VendedorID] FROM [Vendedor] WHERE [VendedorID] = @VendedorID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00037,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00038", "SELECT TOP 1 [VendedorID] FROM [Vendedor] WHERE ( [VendedorID] > @VendedorID) ORDER BY [VendedorID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00038,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00039", "SELECT TOP 1 [VendedorID] FROM [Vendedor] WHERE ( [VendedorID] < @VendedorID) ORDER BY [VendedorID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00039,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000310", "INSERT INTO [Vendedor]([VendedorNombre], [VendedorFoto], [VendedorFoto_GXI], [PaisID]) VALUES(@VendedorNombre, @VendedorFoto, @VendedorFoto_GXI, @PaisID); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000310,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000311", "UPDATE [Vendedor] SET [VendedorNombre]=@VendedorNombre, [PaisID]=@PaisID  WHERE [VendedorID] = @VendedorID", GxErrorMask.GX_NOMASK,prmT000311)
             ,new CursorDef("T000312", "UPDATE [Vendedor] SET [VendedorFoto]=@VendedorFoto, [VendedorFoto_GXI]=@VendedorFoto_GXI  WHERE [VendedorID] = @VendedorID", GxErrorMask.GX_NOMASK,prmT000312)
             ,new CursorDef("T000313", "DELETE FROM [Vendedor]  WHERE [VendedorID] = @VendedorID", GxErrorMask.GX_NOMASK,prmT000313)
             ,new CursorDef("T000314", "SELECT [PaisNombre] FROM [Pais] WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000314,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000315", "SELECT TOP 1 [ProductoID] FROM [Producto] WHERE [VendedorID] = @VendedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000315,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000316", "SELECT [VendedorID] FROM [Vendedor] ORDER BY [VendedorID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000316,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(3));
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(3));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
