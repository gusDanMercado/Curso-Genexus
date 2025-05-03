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
   public class tarjetadepuntos : GXDataArea
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
            A9ClienteID = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A9ClienteID", StringUtil.LTrimStr( (decimal)(A9ClienteID), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A9ClienteID) ;
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
               AV7TarjetaDePuntosID = (int)(Math.Round(NumberUtil.Val( GetPar( "TarjetaDePuntosID"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7TarjetaDePuntosID", StringUtil.LTrimStr( (decimal)(AV7TarjetaDePuntosID), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vTARJETADEPUNTOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TarjetaDePuntosID), "ZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Tarjeta De Puntos", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = cmbTarjetaDePuntosStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("miTienda", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tarjetadepuntos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("miTienda", true);
      }

      public tarjetadepuntos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_TarjetaDePuntosID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TarjetaDePuntosID = aP1_TarjetaDePuntosID;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbTarjetaDePuntosStatus = new GXCombobox();
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
         if ( cmbTarjetaDePuntosStatus.ItemCount > 0 )
         {
            A15TarjetaDePuntosStatus = cmbTarjetaDePuntosStatus.getValidValue(A15TarjetaDePuntosStatus);
            AssignAttri("", false, "A15TarjetaDePuntosStatus", A15TarjetaDePuntosStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTarjetaDePuntosStatus.CurrentValue = StringUtil.RTrim( A15TarjetaDePuntosStatus);
            AssignProp("", false, cmbTarjetaDePuntosStatus_Internalname, "Values", cmbTarjetaDePuntosStatus.ToJavascriptSource(), true);
         }
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Tarjeta De Puntos", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_TarjetaDePuntos.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TarjetaDePuntos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TarjetaDePuntos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TarjetaDePuntos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TarjetaDePuntos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TarjetaDePuntos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTarjetaDePuntosID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTarjetaDePuntosID_Internalname, "Puntos ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTarjetaDePuntosID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TarjetaDePuntosID), 6, 0, ".", "")), StringUtil.LTrim( ((edtTarjetaDePuntosID_Enabled!=0) ? context.localUtil.Format( (decimal)(A14TarjetaDePuntosID), "ZZZZZ9") : context.localUtil.Format( (decimal)(A14TarjetaDePuntosID), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTarjetaDePuntosID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTarjetaDePuntosID_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_TarjetaDePuntos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbTarjetaDePuntosStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTarjetaDePuntosStatus_Internalname, "Puntos Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTarjetaDePuntosStatus, cmbTarjetaDePuntosStatus_Internalname, StringUtil.RTrim( A15TarjetaDePuntosStatus), 1, cmbTarjetaDePuntosStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbTarjetaDePuntosStatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_TarjetaDePuntos.htm");
         cmbTarjetaDePuntosStatus.CurrentValue = StringUtil.RTrim( A15TarjetaDePuntosStatus);
         AssignProp("", false, cmbTarjetaDePuntosStatus_Internalname, "Values", (string)(cmbTarjetaDePuntosStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTarjetaDePuntosPuntos_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTarjetaDePuntosPuntos_Internalname, "Puntos Puntos", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTarjetaDePuntosPuntos_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TarjetaDePuntosPuntos), 6, 0, ".", "")), StringUtil.LTrim( ((edtTarjetaDePuntosPuntos_Enabled!=0) ? context.localUtil.Format( (decimal)(A16TarjetaDePuntosPuntos), "ZZZZZ9") : context.localUtil.Format( (decimal)(A16TarjetaDePuntosPuntos), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTarjetaDePuntosPuntos_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTarjetaDePuntosPuntos_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TarjetaDePuntos.htm");
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
         GxWebStd.gx_single_line_edit( context, edtClienteID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9ClienteID), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A9ClienteID), "ZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteID_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_TarjetaDePuntos.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_9_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_9_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_9_Internalname, sImgUrl, imgprompt_9_Link, "", "", context.GetTheme( ), imgprompt_9_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TarjetaDePuntos.htm");
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
         GxWebStd.gx_single_line_edit( context, edtClienteNombre_Internalname, A10ClienteNombre, StringUtil.RTrim( context.localUtil.Format( A10ClienteNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_TarjetaDePuntos.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TarjetaDePuntos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TarjetaDePuntos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TarjetaDePuntos.htm");
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
         E11052 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z14TarjetaDePuntosID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z14TarjetaDePuntosID"), ".", ","), 18, MidpointRounding.ToEven));
               Z15TarjetaDePuntosStatus = cgiGet( "Z15TarjetaDePuntosStatus");
               Z16TarjetaDePuntosPuntos = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z16TarjetaDePuntosPuntos"), ".", ","), 18, MidpointRounding.ToEven));
               Z9ClienteID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z9ClienteID"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N9ClienteID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N9ClienteID"), ".", ","), 18, MidpointRounding.ToEven));
               AV7TarjetaDePuntosID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vTARJETADEPUNTOSID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV11Insert_ClienteID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CLIENTEID"), ".", ","), 18, MidpointRounding.ToEven));
               AV13Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A14TarjetaDePuntosID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTarjetaDePuntosID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A14TarjetaDePuntosID", StringUtil.LTrimStr( (decimal)(A14TarjetaDePuntosID), 6, 0));
               cmbTarjetaDePuntosStatus.CurrentValue = cgiGet( cmbTarjetaDePuntosStatus_Internalname);
               A15TarjetaDePuntosStatus = cgiGet( cmbTarjetaDePuntosStatus_Internalname);
               AssignAttri("", false, "A15TarjetaDePuntosStatus", A15TarjetaDePuntosStatus);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTarjetaDePuntosPuntos_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTarjetaDePuntosPuntos_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TARJETADEPUNTOSPUNTOS");
                  AnyError = 1;
                  GX_FocusControl = edtTarjetaDePuntosPuntos_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A16TarjetaDePuntosPuntos = 0;
                  AssignAttri("", false, "A16TarjetaDePuntosPuntos", StringUtil.LTrimStr( (decimal)(A16TarjetaDePuntosPuntos), 6, 0));
               }
               else
               {
                  A16TarjetaDePuntosPuntos = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTarjetaDePuntosPuntos_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A16TarjetaDePuntosPuntos", StringUtil.LTrimStr( (decimal)(A16TarjetaDePuntosPuntos), 6, 0));
               }
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
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"TarjetaDePuntos");
               A14TarjetaDePuntosID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTarjetaDePuntosID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A14TarjetaDePuntosID", StringUtil.LTrimStr( (decimal)(A14TarjetaDePuntosID), 6, 0));
               forbiddenHiddens.Add("TarjetaDePuntosID", context.localUtil.Format( (decimal)(A14TarjetaDePuntosID), "ZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A14TarjetaDePuntosID != Z14TarjetaDePuntosID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("tarjetadepuntos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A14TarjetaDePuntosID = (int)(Math.Round(NumberUtil.Val( GetPar( "TarjetaDePuntosID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A14TarjetaDePuntosID", StringUtil.LTrimStr( (decimal)(A14TarjetaDePuntosID), 6, 0));
                  getEqualNoModal( ) ;
                  if ( ! (0==AV7TarjetaDePuntosID) )
                  {
                     A14TarjetaDePuntosID = AV7TarjetaDePuntosID;
                     AssignAttri("", false, "A14TarjetaDePuntosID", StringUtil.LTrimStr( (decimal)(A14TarjetaDePuntosID), 6, 0));
                  }
                  else
                  {
                     if ( IsIns( )  && (0==A14TarjetaDePuntosID) && ( Gx_BScreen == 0 ) )
                     {
                        A14TarjetaDePuntosID = 1;
                        AssignAttri("", false, "A14TarjetaDePuntosID", StringUtil.LTrimStr( (decimal)(A14TarjetaDePuntosID), 6, 0));
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
                     sMode5 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (0==AV7TarjetaDePuntosID) )
                     {
                        A14TarjetaDePuntosID = AV7TarjetaDePuntosID;
                        AssignAttri("", false, "A14TarjetaDePuntosID", StringUtil.LTrimStr( (decimal)(A14TarjetaDePuntosID), 6, 0));
                     }
                     else
                     {
                        if ( IsIns( )  && (0==A14TarjetaDePuntosID) && ( Gx_BScreen == 0 ) )
                        {
                           A14TarjetaDePuntosID = 1;
                           AssignAttri("", false, "A14TarjetaDePuntosID", StringUtil.LTrimStr( (decimal)(A14TarjetaDePuntosID), 6, 0));
                        }
                     }
                     Gx_mode = sMode5;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound5 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_050( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TARJETADEPUNTOSID");
                        AnyError = 1;
                        GX_FocusControl = edtTarjetaDePuntosID_Internalname;
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
                           E11052 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12052 ();
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
            E12052 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll055( ) ;
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
            DisableAttributes055( ) ;
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

      protected void CONFIRM_050( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls055( ) ;
            }
            else
            {
               CheckExtendedTable055( ) ;
               CloseExtendedTableCursors055( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption050( )
      {
      }

      protected void E11052( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV13Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_ClienteID = 0;
         AssignAttri("", false, "AV11Insert_ClienteID", StringUtil.LTrimStr( (decimal)(AV11Insert_ClienteID), 6, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV13Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV14GXV1 = 1;
            AssignAttri("", false, "AV14GXV1", StringUtil.LTrimStr( (decimal)(AV14GXV1), 8, 0));
            while ( AV14GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV14GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "ClienteID") == 0 )
               {
                  AV11Insert_ClienteID = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_ClienteID", StringUtil.LTrimStr( (decimal)(AV11Insert_ClienteID), 6, 0));
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

      protected void E12052( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwtarjetadepuntos.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM055( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z15TarjetaDePuntosStatus = T00053_A15TarjetaDePuntosStatus[0];
               Z16TarjetaDePuntosPuntos = T00053_A16TarjetaDePuntosPuntos[0];
               Z9ClienteID = T00053_A9ClienteID[0];
            }
            else
            {
               Z15TarjetaDePuntosStatus = A15TarjetaDePuntosStatus;
               Z16TarjetaDePuntosPuntos = A16TarjetaDePuntosPuntos;
               Z9ClienteID = A9ClienteID;
            }
         }
         if ( GX_JID == -9 )
         {
            Z14TarjetaDePuntosID = A14TarjetaDePuntosID;
            Z15TarjetaDePuntosStatus = A15TarjetaDePuntosStatus;
            Z16TarjetaDePuntosPuntos = A16TarjetaDePuntosPuntos;
            Z9ClienteID = A9ClienteID;
            Z10ClienteNombre = A10ClienteNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         edtTarjetaDePuntosID_Enabled = 0;
         AssignProp("", false, edtTarjetaDePuntosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTarjetaDePuntosID_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_9_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CLIENTEID"+"'), id:'"+"CLIENTEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtTarjetaDePuntosID_Enabled = 0;
         AssignProp("", false, edtTarjetaDePuntosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTarjetaDePuntosID_Enabled), 5, 0), true);
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
         if ( ! (0==AV7TarjetaDePuntosID) )
         {
            A14TarjetaDePuntosID = AV7TarjetaDePuntosID;
            AssignAttri("", false, "A14TarjetaDePuntosID", StringUtil.LTrimStr( (decimal)(A14TarjetaDePuntosID), 6, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A14TarjetaDePuntosID) && ( Gx_BScreen == 0 ) )
            {
               A14TarjetaDePuntosID = 1;
               AssignAttri("", false, "A14TarjetaDePuntosID", StringUtil.LTrimStr( (decimal)(A14TarjetaDePuntosID), 6, 0));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV13Pgmname = "TarjetaDePuntos";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
            /* Using cursor T00054 */
            pr_default.execute(2, new Object[] {A9ClienteID});
            A10ClienteNombre = T00054_A10ClienteNombre[0];
            AssignAttri("", false, "A10ClienteNombre", A10ClienteNombre);
            pr_default.close(2);
         }
      }

      protected void Load055( )
      {
         /* Using cursor T00055 */
         pr_default.execute(3, new Object[] {A14TarjetaDePuntosID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound5 = 1;
            A15TarjetaDePuntosStatus = T00055_A15TarjetaDePuntosStatus[0];
            AssignAttri("", false, "A15TarjetaDePuntosStatus", A15TarjetaDePuntosStatus);
            A16TarjetaDePuntosPuntos = T00055_A16TarjetaDePuntosPuntos[0];
            AssignAttri("", false, "A16TarjetaDePuntosPuntos", StringUtil.LTrimStr( (decimal)(A16TarjetaDePuntosPuntos), 6, 0));
            A10ClienteNombre = T00055_A10ClienteNombre[0];
            AssignAttri("", false, "A10ClienteNombre", A10ClienteNombre);
            A9ClienteID = T00055_A9ClienteID[0];
            AssignAttri("", false, "A9ClienteID", StringUtil.LTrimStr( (decimal)(A9ClienteID), 6, 0));
            ZM055( -9) ;
         }
         pr_default.close(3);
         OnLoadActions055( ) ;
      }

      protected void OnLoadActions055( )
      {
         AV13Pgmname = "TarjetaDePuntos";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
      }

      protected void CheckExtendedTable055( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV13Pgmname = "TarjetaDePuntos";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         if ( ! ( ( StringUtil.StrCmp(A15TarjetaDePuntosStatus, "N") == 0 ) || ( StringUtil.StrCmp(A15TarjetaDePuntosStatus, "V") == 0 ) ) )
         {
            GX_msglist.addItem("Field Tarjeta De Puntos Status is out of range", "OutOfRange", 1, "TARJETADEPUNTOSSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbTarjetaDePuntosStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00054 */
         pr_default.execute(2, new Object[] {A9ClienteID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10ClienteNombre = T00054_A10ClienteNombre[0];
         AssignAttri("", false, "A10ClienteNombre", A10ClienteNombre);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors055( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_10( int A9ClienteID )
      {
         /* Using cursor T00056 */
         pr_default.execute(4, new Object[] {A9ClienteID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10ClienteNombre = T00056_A10ClienteNombre[0];
         AssignAttri("", false, "A10ClienteNombre", A10ClienteNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A10ClienteNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey055( )
      {
         /* Using cursor T00057 */
         pr_default.execute(5, new Object[] {A14TarjetaDePuntosID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00053 */
         pr_default.execute(1, new Object[] {A14TarjetaDePuntosID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM055( 9) ;
            RcdFound5 = 1;
            A14TarjetaDePuntosID = T00053_A14TarjetaDePuntosID[0];
            AssignAttri("", false, "A14TarjetaDePuntosID", StringUtil.LTrimStr( (decimal)(A14TarjetaDePuntosID), 6, 0));
            A15TarjetaDePuntosStatus = T00053_A15TarjetaDePuntosStatus[0];
            AssignAttri("", false, "A15TarjetaDePuntosStatus", A15TarjetaDePuntosStatus);
            A16TarjetaDePuntosPuntos = T00053_A16TarjetaDePuntosPuntos[0];
            AssignAttri("", false, "A16TarjetaDePuntosPuntos", StringUtil.LTrimStr( (decimal)(A16TarjetaDePuntosPuntos), 6, 0));
            A9ClienteID = T00053_A9ClienteID[0];
            AssignAttri("", false, "A9ClienteID", StringUtil.LTrimStr( (decimal)(A9ClienteID), 6, 0));
            Z14TarjetaDePuntosID = A14TarjetaDePuntosID;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load055( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey055( ) ;
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey055( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey055( ) ;
         if ( RcdFound5 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound5 = 0;
         /* Using cursor T00058 */
         pr_default.execute(6, new Object[] {A14TarjetaDePuntosID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00058_A14TarjetaDePuntosID[0] < A14TarjetaDePuntosID ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00058_A14TarjetaDePuntosID[0] > A14TarjetaDePuntosID ) ) )
            {
               A14TarjetaDePuntosID = T00058_A14TarjetaDePuntosID[0];
               AssignAttri("", false, "A14TarjetaDePuntosID", StringUtil.LTrimStr( (decimal)(A14TarjetaDePuntosID), 6, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound5 = 0;
         /* Using cursor T00059 */
         pr_default.execute(7, new Object[] {A14TarjetaDePuntosID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00059_A14TarjetaDePuntosID[0] > A14TarjetaDePuntosID ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00059_A14TarjetaDePuntosID[0] < A14TarjetaDePuntosID ) ) )
            {
               A14TarjetaDePuntosID = T00059_A14TarjetaDePuntosID[0];
               AssignAttri("", false, "A14TarjetaDePuntosID", StringUtil.LTrimStr( (decimal)(A14TarjetaDePuntosID), 6, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey055( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = cmbTarjetaDePuntosStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert055( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A14TarjetaDePuntosID != Z14TarjetaDePuntosID )
               {
                  A14TarjetaDePuntosID = Z14TarjetaDePuntosID;
                  AssignAttri("", false, "A14TarjetaDePuntosID", StringUtil.LTrimStr( (decimal)(A14TarjetaDePuntosID), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TARJETADEPUNTOSID");
                  AnyError = 1;
                  GX_FocusControl = edtTarjetaDePuntosID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = cmbTarjetaDePuntosStatus_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update055( ) ;
                  GX_FocusControl = cmbTarjetaDePuntosStatus_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A14TarjetaDePuntosID != Z14TarjetaDePuntosID )
               {
                  /* Insert record */
                  GX_FocusControl = cmbTarjetaDePuntosStatus_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert055( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TARJETADEPUNTOSID");
                     AnyError = 1;
                     GX_FocusControl = edtTarjetaDePuntosID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = cmbTarjetaDePuntosStatus_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert055( ) ;
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
         if ( A14TarjetaDePuntosID != Z14TarjetaDePuntosID )
         {
            A14TarjetaDePuntosID = Z14TarjetaDePuntosID;
            AssignAttri("", false, "A14TarjetaDePuntosID", StringUtil.LTrimStr( (decimal)(A14TarjetaDePuntosID), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TARJETADEPUNTOSID");
            AnyError = 1;
            GX_FocusControl = edtTarjetaDePuntosID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = cmbTarjetaDePuntosStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency055( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00052 */
            pr_default.execute(0, new Object[] {A14TarjetaDePuntosID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TarjetaDePuntos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z15TarjetaDePuntosStatus, T00052_A15TarjetaDePuntosStatus[0]) != 0 ) || ( Z16TarjetaDePuntosPuntos != T00052_A16TarjetaDePuntosPuntos[0] ) || ( Z9ClienteID != T00052_A9ClienteID[0] ) )
            {
               if ( StringUtil.StrCmp(Z15TarjetaDePuntosStatus, T00052_A15TarjetaDePuntosStatus[0]) != 0 )
               {
                  GXUtil.WriteLog("tarjetadepuntos:[seudo value changed for attri]"+"TarjetaDePuntosStatus");
                  GXUtil.WriteLogRaw("Old: ",Z15TarjetaDePuntosStatus);
                  GXUtil.WriteLogRaw("Current: ",T00052_A15TarjetaDePuntosStatus[0]);
               }
               if ( Z16TarjetaDePuntosPuntos != T00052_A16TarjetaDePuntosPuntos[0] )
               {
                  GXUtil.WriteLog("tarjetadepuntos:[seudo value changed for attri]"+"TarjetaDePuntosPuntos");
                  GXUtil.WriteLogRaw("Old: ",Z16TarjetaDePuntosPuntos);
                  GXUtil.WriteLogRaw("Current: ",T00052_A16TarjetaDePuntosPuntos[0]);
               }
               if ( Z9ClienteID != T00052_A9ClienteID[0] )
               {
                  GXUtil.WriteLog("tarjetadepuntos:[seudo value changed for attri]"+"ClienteID");
                  GXUtil.WriteLogRaw("Old: ",Z9ClienteID);
                  GXUtil.WriteLogRaw("Current: ",T00052_A9ClienteID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TarjetaDePuntos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM055( 0) ;
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000510 */
                     pr_default.execute(8, new Object[] {A15TarjetaDePuntosStatus, A16TarjetaDePuntosPuntos, A9ClienteID});
                     A14TarjetaDePuntosID = T000510_A14TarjetaDePuntosID[0];
                     AssignAttri("", false, "A14TarjetaDePuntosID", StringUtil.LTrimStr( (decimal)(A14TarjetaDePuntosID), 6, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("TarjetaDePuntos");
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
               Load055( ) ;
            }
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void Update055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000511 */
                     pr_default.execute(9, new Object[] {A15TarjetaDePuntosStatus, A16TarjetaDePuntosPuntos, A9ClienteID, A14TarjetaDePuntosID});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("TarjetaDePuntos");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TarjetaDePuntos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate055( ) ;
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
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void DeferredUpdate055( )
      {
      }

      protected void delete( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls055( ) ;
            AfterConfirm055( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete055( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000512 */
                  pr_default.execute(10, new Object[] {A14TarjetaDePuntosID});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("TarjetaDePuntos");
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
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel055( ) ;
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls055( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "TarjetaDePuntos";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
            /* Using cursor T000513 */
            pr_default.execute(11, new Object[] {A9ClienteID});
            A10ClienteNombre = T000513_A10ClienteNombre[0];
            AssignAttri("", false, "A10ClienteNombre", A10ClienteNombre);
            pr_default.close(11);
         }
      }

      protected void EndLevel055( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete055( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("tarjetadepuntos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues050( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("tarjetadepuntos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart055( )
      {
         /* Scan By routine */
         /* Using cursor T000514 */
         pr_default.execute(12);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound5 = 1;
            A14TarjetaDePuntosID = T000514_A14TarjetaDePuntosID[0];
            AssignAttri("", false, "A14TarjetaDePuntosID", StringUtil.LTrimStr( (decimal)(A14TarjetaDePuntosID), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext055( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound5 = 1;
            A14TarjetaDePuntosID = T000514_A14TarjetaDePuntosID[0];
            AssignAttri("", false, "A14TarjetaDePuntosID", StringUtil.LTrimStr( (decimal)(A14TarjetaDePuntosID), 6, 0));
         }
      }

      protected void ScanEnd055( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm055( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert055( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate055( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete055( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete055( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate055( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes055( )
      {
         edtTarjetaDePuntosID_Enabled = 0;
         AssignProp("", false, edtTarjetaDePuntosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTarjetaDePuntosID_Enabled), 5, 0), true);
         cmbTarjetaDePuntosStatus.Enabled = 0;
         AssignProp("", false, cmbTarjetaDePuntosStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTarjetaDePuntosStatus.Enabled), 5, 0), true);
         edtTarjetaDePuntosPuntos_Enabled = 0;
         AssignProp("", false, edtTarjetaDePuntosPuntos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTarjetaDePuntosPuntos_Enabled), 5, 0), true);
         edtClienteID_Enabled = 0;
         AssignProp("", false, edtClienteID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteID_Enabled), 5, 0), true);
         edtClienteNombre_Enabled = 0;
         AssignProp("", false, edtClienteNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteNombre_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes055( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues050( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tarjetadepuntos.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7TarjetaDePuntosID,6,0))}, new string[] {"Gx_mode","TarjetaDePuntosID"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"TarjetaDePuntos");
         forbiddenHiddens.Add("TarjetaDePuntosID", context.localUtil.Format( (decimal)(A14TarjetaDePuntosID), "ZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("tarjetadepuntos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z14TarjetaDePuntosID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z14TarjetaDePuntosID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z15TarjetaDePuntosStatus", StringUtil.RTrim( Z15TarjetaDePuntosStatus));
         GxWebStd.gx_hidden_field( context, "Z16TarjetaDePuntosPuntos", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16TarjetaDePuntosPuntos), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z9ClienteID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9ClienteID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vTARJETADEPUNTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TarjetaDePuntosID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTARJETADEPUNTOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TarjetaDePuntosID), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_ClienteID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV13Pgmname));
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
         return formatLink("tarjetadepuntos.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7TarjetaDePuntosID,6,0))}, new string[] {"Gx_mode","TarjetaDePuntosID"})  ;
      }

      public override string GetPgmname( )
      {
         return "TarjetaDePuntos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tarjeta De Puntos" ;
      }

      protected void InitializeNonKey055( )
      {
         A15TarjetaDePuntosStatus = "";
         AssignAttri("", false, "A15TarjetaDePuntosStatus", A15TarjetaDePuntosStatus);
         A16TarjetaDePuntosPuntos = 0;
         AssignAttri("", false, "A16TarjetaDePuntosPuntos", StringUtil.LTrimStr( (decimal)(A16TarjetaDePuntosPuntos), 6, 0));
         A10ClienteNombre = "";
         AssignAttri("", false, "A10ClienteNombre", A10ClienteNombre);
         A9ClienteID = 1;
         AssignAttri("", false, "A9ClienteID", StringUtil.LTrimStr( (decimal)(A9ClienteID), 6, 0));
         Z15TarjetaDePuntosStatus = "";
         Z16TarjetaDePuntosPuntos = 0;
         Z9ClienteID = 0;
      }

      protected void InitAll055( )
      {
         A14TarjetaDePuntosID = 1;
         AssignAttri("", false, "A14TarjetaDePuntosID", StringUtil.LTrimStr( (decimal)(A14TarjetaDePuntosID), 6, 0));
         InitializeNonKey055( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A9ClienteID = i9ClienteID;
         AssignAttri("", false, "A9ClienteID", StringUtil.LTrimStr( (decimal)(A9ClienteID), 6, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20255220475933", true, true);
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
         context.AddJavascriptSource("tarjetadepuntos.js", "?20255220475933", false, true);
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
         edtTarjetaDePuntosID_Internalname = "TARJETADEPUNTOSID";
         cmbTarjetaDePuntosStatus_Internalname = "TARJETADEPUNTOSSTATUS";
         edtTarjetaDePuntosPuntos_Internalname = "TARJETADEPUNTOSPUNTOS";
         edtClienteID_Internalname = "CLIENTEID";
         edtClienteNombre_Internalname = "CLIENTENOMBRE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_9_Internalname = "PROMPT_9";
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
         Form.Caption = "Tarjeta De Puntos";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtClienteNombre_Jsonclick = "";
         edtClienteNombre_Enabled = 0;
         imgprompt_9_Visible = 1;
         imgprompt_9_Link = "";
         edtClienteID_Jsonclick = "";
         edtClienteID_Enabled = 1;
         edtTarjetaDePuntosPuntos_Jsonclick = "";
         edtTarjetaDePuntosPuntos_Enabled = 1;
         cmbTarjetaDePuntosStatus_Jsonclick = "";
         cmbTarjetaDePuntosStatus.Enabled = 1;
         edtTarjetaDePuntosID_Jsonclick = "";
         edtTarjetaDePuntosID_Enabled = 0;
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
         cmbTarjetaDePuntosStatus.Name = "TARJETADEPUNTOSSTATUS";
         cmbTarjetaDePuntosStatus.WebTags = "";
         cmbTarjetaDePuntosStatus.addItem("N", "Normal", 0);
         cmbTarjetaDePuntosStatus.addItem("V", "Vip", 0);
         if ( cmbTarjetaDePuntosStatus.ItemCount > 0 )
         {
            A15TarjetaDePuntosStatus = cmbTarjetaDePuntosStatus.getValidValue(A15TarjetaDePuntosStatus);
            AssignAttri("", false, "A15TarjetaDePuntosStatus", A15TarjetaDePuntosStatus);
         }
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

      public void Valid_Clienteid( )
      {
         /* Using cursor T000513 */
         pr_default.execute(11, new Object[] {A9ClienteID});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No matching 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteID_Internalname;
         }
         A10ClienteNombre = T000513_A10ClienteNombre[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A10ClienteNombre", A10ClienteNombre);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7TarjetaDePuntosID","fld":"vTARJETADEPUNTOSID","pic":"ZZZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7TarjetaDePuntosID","fld":"vTARJETADEPUNTOSID","pic":"ZZZZZ9","hsh":true},{"av":"A14TarjetaDePuntosID","fld":"TARJETADEPUNTOSID","pic":"ZZZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12052","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_TARJETADEPUNTOSID","""{"handler":"Valid_Tarjetadepuntosid","iparms":[]}""");
         setEventMetadata("VALID_TARJETADEPUNTOSSTATUS","""{"handler":"Valid_Tarjetadepuntosstatus","iparms":[]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[{"av":"A9ClienteID","fld":"CLIENTEID","pic":"ZZZZZ9"},{"av":"A10ClienteNombre","fld":"CLIENTENOMBRE"}]""");
         setEventMetadata("VALID_CLIENTEID",""","oparms":[{"av":"A10ClienteNombre","fld":"CLIENTENOMBRE"}]}""");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z15TarjetaDePuntosStatus = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A15TarjetaDePuntosStatus = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         imgprompt_9_gximage = "";
         sImgUrl = "";
         A10ClienteNombre = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV11Insert_ClienteID = 1;
         AV13Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode5 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z10ClienteNombre = "";
         T00054_A10ClienteNombre = new string[] {""} ;
         T00055_A14TarjetaDePuntosID = new int[1] ;
         T00055_A15TarjetaDePuntosStatus = new string[] {""} ;
         T00055_A16TarjetaDePuntosPuntos = new int[1] ;
         T00055_A10ClienteNombre = new string[] {""} ;
         T00055_A9ClienteID = new int[1] ;
         T00056_A10ClienteNombre = new string[] {""} ;
         T00057_A14TarjetaDePuntosID = new int[1] ;
         T00053_A14TarjetaDePuntosID = new int[1] ;
         T00053_A15TarjetaDePuntosStatus = new string[] {""} ;
         T00053_A16TarjetaDePuntosPuntos = new int[1] ;
         T00053_A9ClienteID = new int[1] ;
         T00058_A14TarjetaDePuntosID = new int[1] ;
         T00059_A14TarjetaDePuntosID = new int[1] ;
         T00052_A14TarjetaDePuntosID = new int[1] ;
         T00052_A15TarjetaDePuntosStatus = new string[] {""} ;
         T00052_A16TarjetaDePuntosPuntos = new int[1] ;
         T00052_A9ClienteID = new int[1] ;
         T000510_A14TarjetaDePuntosID = new int[1] ;
         T000513_A10ClienteNombre = new string[] {""} ;
         T000514_A14TarjetaDePuntosID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tarjetadepuntos__default(),
            new Object[][] {
                new Object[] {
               T00052_A14TarjetaDePuntosID, T00052_A15TarjetaDePuntosStatus, T00052_A16TarjetaDePuntosPuntos, T00052_A9ClienteID
               }
               , new Object[] {
               T00053_A14TarjetaDePuntosID, T00053_A15TarjetaDePuntosStatus, T00053_A16TarjetaDePuntosPuntos, T00053_A9ClienteID
               }
               , new Object[] {
               T00054_A10ClienteNombre
               }
               , new Object[] {
               T00055_A14TarjetaDePuntosID, T00055_A15TarjetaDePuntosStatus, T00055_A16TarjetaDePuntosPuntos, T00055_A10ClienteNombre, T00055_A9ClienteID
               }
               , new Object[] {
               T00056_A10ClienteNombre
               }
               , new Object[] {
               T00057_A14TarjetaDePuntosID
               }
               , new Object[] {
               T00058_A14TarjetaDePuntosID
               }
               , new Object[] {
               T00059_A14TarjetaDePuntosID
               }
               , new Object[] {
               T000510_A14TarjetaDePuntosID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000513_A10ClienteNombre
               }
               , new Object[] {
               T000514_A14TarjetaDePuntosID
               }
            }
         );
         Z9ClienteID = 1;
         N9ClienteID = 1;
         i9ClienteID = 1;
         A9ClienteID = 1;
         Z14TarjetaDePuntosID = 1;
         A14TarjetaDePuntosID = 1;
         AV13Pgmname = "TarjetaDePuntos";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound5 ;
      private short gxajaxcallmode ;
      private int wcpOAV7TarjetaDePuntosID ;
      private int Z14TarjetaDePuntosID ;
      private int Z16TarjetaDePuntosPuntos ;
      private int Z9ClienteID ;
      private int N9ClienteID ;
      private int A9ClienteID ;
      private int AV7TarjetaDePuntosID ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A14TarjetaDePuntosID ;
      private int edtTarjetaDePuntosID_Enabled ;
      private int A16TarjetaDePuntosPuntos ;
      private int edtTarjetaDePuntosPuntos_Enabled ;
      private int edtClienteID_Enabled ;
      private int imgprompt_9_Visible ;
      private int edtClienteNombre_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV11Insert_ClienteID ;
      private int AV14GXV1 ;
      private int i9ClienteID ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z15TarjetaDePuntosStatus ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string cmbTarjetaDePuntosStatus_Internalname ;
      private string A15TarjetaDePuntosStatus ;
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
      private string edtTarjetaDePuntosID_Internalname ;
      private string edtTarjetaDePuntosID_Jsonclick ;
      private string cmbTarjetaDePuntosStatus_Jsonclick ;
      private string edtTarjetaDePuntosPuntos_Internalname ;
      private string edtTarjetaDePuntosPuntos_Jsonclick ;
      private string edtClienteID_Internalname ;
      private string edtClienteID_Jsonclick ;
      private string imgprompt_9_gximage ;
      private string sImgUrl ;
      private string imgprompt_9_Internalname ;
      private string imgprompt_9_Link ;
      private string edtClienteNombre_Internalname ;
      private string edtClienteNombre_Jsonclick ;
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
      private string sMode5 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private string A10ClienteNombre ;
      private string Z10ClienteNombre ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTarjetaDePuntosStatus ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00054_A10ClienteNombre ;
      private int[] T00055_A14TarjetaDePuntosID ;
      private string[] T00055_A15TarjetaDePuntosStatus ;
      private int[] T00055_A16TarjetaDePuntosPuntos ;
      private string[] T00055_A10ClienteNombre ;
      private int[] T00055_A9ClienteID ;
      private string[] T00056_A10ClienteNombre ;
      private int[] T00057_A14TarjetaDePuntosID ;
      private int[] T00053_A14TarjetaDePuntosID ;
      private string[] T00053_A15TarjetaDePuntosStatus ;
      private int[] T00053_A16TarjetaDePuntosPuntos ;
      private int[] T00053_A9ClienteID ;
      private int[] T00058_A14TarjetaDePuntosID ;
      private int[] T00059_A14TarjetaDePuntosID ;
      private int[] T00052_A14TarjetaDePuntosID ;
      private string[] T00052_A15TarjetaDePuntosStatus ;
      private int[] T00052_A16TarjetaDePuntosPuntos ;
      private int[] T00052_A9ClienteID ;
      private int[] T000510_A14TarjetaDePuntosID ;
      private string[] T000513_A10ClienteNombre ;
      private int[] T000514_A14TarjetaDePuntosID ;
   }

   public class tarjetadepuntos__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00052;
          prmT00052 = new Object[] {
          new ParDef("@TarjetaDePuntosID",GXType.Int32,6,0)
          };
          Object[] prmT00053;
          prmT00053 = new Object[] {
          new ParDef("@TarjetaDePuntosID",GXType.Int32,6,0)
          };
          Object[] prmT00054;
          prmT00054 = new Object[] {
          new ParDef("@ClienteID",GXType.Int32,6,0)
          };
          Object[] prmT00055;
          prmT00055 = new Object[] {
          new ParDef("@TarjetaDePuntosID",GXType.Int32,6,0)
          };
          Object[] prmT00056;
          prmT00056 = new Object[] {
          new ParDef("@ClienteID",GXType.Int32,6,0)
          };
          Object[] prmT00057;
          prmT00057 = new Object[] {
          new ParDef("@TarjetaDePuntosID",GXType.Int32,6,0)
          };
          Object[] prmT00058;
          prmT00058 = new Object[] {
          new ParDef("@TarjetaDePuntosID",GXType.Int32,6,0)
          };
          Object[] prmT00059;
          prmT00059 = new Object[] {
          new ParDef("@TarjetaDePuntosID",GXType.Int32,6,0)
          };
          Object[] prmT000510;
          prmT000510 = new Object[] {
          new ParDef("@TarjetaDePuntosStatus",GXType.NChar,1,0) ,
          new ParDef("@TarjetaDePuntosPuntos",GXType.Int32,6,0) ,
          new ParDef("@ClienteID",GXType.Int32,6,0)
          };
          Object[] prmT000511;
          prmT000511 = new Object[] {
          new ParDef("@TarjetaDePuntosStatus",GXType.NChar,1,0) ,
          new ParDef("@TarjetaDePuntosPuntos",GXType.Int32,6,0) ,
          new ParDef("@ClienteID",GXType.Int32,6,0) ,
          new ParDef("@TarjetaDePuntosID",GXType.Int32,6,0)
          };
          Object[] prmT000512;
          prmT000512 = new Object[] {
          new ParDef("@TarjetaDePuntosID",GXType.Int32,6,0)
          };
          Object[] prmT000513;
          prmT000513 = new Object[] {
          new ParDef("@ClienteID",GXType.Int32,6,0)
          };
          Object[] prmT000514;
          prmT000514 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00052", "SELECT [TarjetaDePuntosID], [TarjetaDePuntosStatus], [TarjetaDePuntosPuntos], [ClienteID] FROM [TarjetaDePuntos] WITH (UPDLOCK) WHERE [TarjetaDePuntosID] = @TarjetaDePuntosID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00052,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00053", "SELECT [TarjetaDePuntosID], [TarjetaDePuntosStatus], [TarjetaDePuntosPuntos], [ClienteID] FROM [TarjetaDePuntos] WHERE [TarjetaDePuntosID] = @TarjetaDePuntosID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00053,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00054", "SELECT [ClienteNombre] FROM [Cliente] WHERE [ClienteID] = @ClienteID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00054,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00055", "SELECT TM1.[TarjetaDePuntosID], TM1.[TarjetaDePuntosStatus], TM1.[TarjetaDePuntosPuntos], T2.[ClienteNombre], TM1.[ClienteID] FROM ([TarjetaDePuntos] TM1 INNER JOIN [Cliente] T2 ON T2.[ClienteID] = TM1.[ClienteID]) WHERE TM1.[TarjetaDePuntosID] = @TarjetaDePuntosID ORDER BY TM1.[TarjetaDePuntosID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00055,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00056", "SELECT [ClienteNombre] FROM [Cliente] WHERE [ClienteID] = @ClienteID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00056,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00057", "SELECT [TarjetaDePuntosID] FROM [TarjetaDePuntos] WHERE [TarjetaDePuntosID] = @TarjetaDePuntosID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00057,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00058", "SELECT TOP 1 [TarjetaDePuntosID] FROM [TarjetaDePuntos] WHERE ( [TarjetaDePuntosID] > @TarjetaDePuntosID) ORDER BY [TarjetaDePuntosID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00058,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00059", "SELECT TOP 1 [TarjetaDePuntosID] FROM [TarjetaDePuntos] WHERE ( [TarjetaDePuntosID] < @TarjetaDePuntosID) ORDER BY [TarjetaDePuntosID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00059,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000510", "INSERT INTO [TarjetaDePuntos]([TarjetaDePuntosStatus], [TarjetaDePuntosPuntos], [ClienteID]) VALUES(@TarjetaDePuntosStatus, @TarjetaDePuntosPuntos, @ClienteID); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000510,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000511", "UPDATE [TarjetaDePuntos] SET [TarjetaDePuntosStatus]=@TarjetaDePuntosStatus, [TarjetaDePuntosPuntos]=@TarjetaDePuntosPuntos, [ClienteID]=@ClienteID  WHERE [TarjetaDePuntosID] = @TarjetaDePuntosID", GxErrorMask.GX_NOMASK,prmT000511)
             ,new CursorDef("T000512", "DELETE FROM [TarjetaDePuntos]  WHERE [TarjetaDePuntosID] = @TarjetaDePuntosID", GxErrorMask.GX_NOMASK,prmT000512)
             ,new CursorDef("T000513", "SELECT [ClienteNombre] FROM [Cliente] WHERE [ClienteID] = @ClienteID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000513,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000514", "SELECT [TarjetaDePuntosID] FROM [TarjetaDePuntos] ORDER BY [TarjetaDePuntosID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000514,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
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
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
