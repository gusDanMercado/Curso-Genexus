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
   public class juego : GXDataArea
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
         gxfirstwebparm = GetNextPar( );
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A13parqueAtraccionId = (short)(Math.Round(NumberUtil.Val( GetPar( "parqueAtraccionId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A13parqueAtraccionId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A26CategoriaId = (short)(Math.Round(NumberUtil.Val( GetPar( "CategoriaId"), "."), 18, MidpointRounding.ToEven));
            n26CategoriaId = false;
            AssignAttri("", false, "A26CategoriaId", StringUtil.LTrimStr( (decimal)(A26CategoriaId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A26CategoriaId) ;
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
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
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
         Form.Meta.addItem("description", "Juego", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtJuegoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("parques", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public juego( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("parques", true);
      }

      public juego( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Juego", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Juego.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Juego.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Juego.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Juego.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Juego.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"JUEGOID"+"'), id:'"+"JUEGOID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Juego.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtJuegoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtJuegoId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtJuegoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A24JuegoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtJuegoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A24JuegoId), "ZZZ9") : context.localUtil.Format( (decimal)(A24JuegoId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtJuegoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtJuegoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Juego.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtJuegoNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtJuegoNombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtJuegoNombre_Internalname, A25JuegoNombre, StringUtil.RTrim( context.localUtil.Format( A25JuegoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtJuegoNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtJuegoNombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Juego.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtparqueAtraccionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtparqueAtraccionId_Internalname, "parque Atraccion Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtparqueAtraccionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13parqueAtraccionId), 4, 0, ",", "")), StringUtil.LTrim( ((edtparqueAtraccionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A13parqueAtraccionId), "ZZZ9") : context.localUtil.Format( (decimal)(A13parqueAtraccionId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtparqueAtraccionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtparqueAtraccionId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Juego.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_13_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_13_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_13_Internalname, sImgUrl, imgprompt_13_Link, "", "", context.GetTheme( ), imgprompt_13_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Juego.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtparqueAtraccionNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtparqueAtraccionNombre_Internalname, "parque Atraccion Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtparqueAtraccionNombre_Internalname, A14parqueAtraccionNombre, StringUtil.RTrim( context.localUtil.Format( A14parqueAtraccionNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtparqueAtraccionNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtparqueAtraccionNombre_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Juego.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtparqueAtraccionSitioWeb_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtparqueAtraccionSitioWeb_Internalname, "parque Atraccion Sitio Web", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtparqueAtraccionSitioWeb_Internalname, A15parqueAtraccionSitioWeb, StringUtil.RTrim( context.localUtil.Format( A15parqueAtraccionSitioWeb, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtparqueAtraccionSitioWeb_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtparqueAtraccionSitioWeb_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Juego.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgparqueAtraccionFoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "parque Atraccion Foto", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A17parqueAtraccionFoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000parqueAtraccionFoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.PathToRelativeUrl( A17parqueAtraccionFoto));
         GxWebStd.gx_bitmap( context, imgparqueAtraccionFoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgparqueAtraccionFoto_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", "", "", 0, A17parqueAtraccionFoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Juego.htm");
         AssignProp("", false, imgparqueAtraccionFoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.PathToRelativeUrl( A17parqueAtraccionFoto)), true);
         AssignProp("", false, imgparqueAtraccionFoto_Internalname, "IsBlob", StringUtil.BoolToStr( A17parqueAtraccionFoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCategoriaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCategoriaId_Internalname, "Categoria Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCategoriaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A26CategoriaId), 4, 0, ",", "")), StringUtil.LTrim( ((edtCategoriaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A26CategoriaId), "ZZZ9") : context.localUtil.Format( (decimal)(A26CategoriaId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoriaId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCategoriaId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Juego.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_26_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_26_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_26_Internalname, sImgUrl, imgprompt_26_Link, "", "", context.GetTheme( ), imgprompt_26_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Juego.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCategoriaNombre_Internalname, A27CategoriaNombre, StringUtil.RTrim( context.localUtil.Format( A27CategoriaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoriaNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCategoriaNombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Juego.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Juego.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Juego.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Juego.htm");
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
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z24JuegoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z24JuegoId"), ",", "."), 18, MidpointRounding.ToEven));
            Z25JuegoNombre = cgiGet( "Z25JuegoNombre");
            Z13parqueAtraccionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z13parqueAtraccionId"), ",", "."), 18, MidpointRounding.ToEven));
            Z26CategoriaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z26CategoriaId"), ",", "."), 18, MidpointRounding.ToEven));
            n26CategoriaId = ((0==A26CategoriaId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
            A40000parqueAtraccionFoto_GXI = cgiGet( "PARQUEATRACCIONFOTO_GXI");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtJuegoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtJuegoId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "JUEGOID");
               AnyError = 1;
               GX_FocusControl = edtJuegoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A24JuegoId = 0;
               AssignAttri("", false, "A24JuegoId", StringUtil.LTrimStr( (decimal)(A24JuegoId), 4, 0));
            }
            else
            {
               A24JuegoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtJuegoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A24JuegoId", StringUtil.LTrimStr( (decimal)(A24JuegoId), 4, 0));
            }
            A25JuegoNombre = cgiGet( edtJuegoNombre_Internalname);
            AssignAttri("", false, "A25JuegoNombre", A25JuegoNombre);
            if ( ( ( context.localUtil.CToN( cgiGet( edtparqueAtraccionId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtparqueAtraccionId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARQUEATRACCIONID");
               AnyError = 1;
               GX_FocusControl = edtparqueAtraccionId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A13parqueAtraccionId = 0;
               AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
            }
            else
            {
               A13parqueAtraccionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtparqueAtraccionId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
            }
            A14parqueAtraccionNombre = cgiGet( edtparqueAtraccionNombre_Internalname);
            AssignAttri("", false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
            A15parqueAtraccionSitioWeb = cgiGet( edtparqueAtraccionSitioWeb_Internalname);
            AssignAttri("", false, "A15parqueAtraccionSitioWeb", A15parqueAtraccionSitioWeb);
            A17parqueAtraccionFoto = cgiGet( imgparqueAtraccionFoto_Internalname);
            AssignAttri("", false, "A17parqueAtraccionFoto", A17parqueAtraccionFoto);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCategoriaId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCategoriaId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CATEGORIAID");
               AnyError = 1;
               GX_FocusControl = edtCategoriaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A26CategoriaId = 0;
               n26CategoriaId = false;
               AssignAttri("", false, "A26CategoriaId", StringUtil.LTrimStr( (decimal)(A26CategoriaId), 4, 0));
            }
            else
            {
               A26CategoriaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCategoriaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n26CategoriaId = false;
               AssignAttri("", false, "A26CategoriaId", StringUtil.LTrimStr( (decimal)(A26CategoriaId), 4, 0));
            }
            n26CategoriaId = ((0==A26CategoriaId) ? true : false);
            A27CategoriaNombre = cgiGet( edtCategoriaNombre_Internalname);
            AssignAttri("", false, "A27CategoriaNombre", A27CategoriaNombre);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgparqueAtraccionFoto_Internalname, ref  A17parqueAtraccionFoto, ref  A40000parqueAtraccionFoto_GXI);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A24JuegoId = (short)(Math.Round(NumberUtil.Val( GetPar( "JuegoId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A24JuegoId", StringUtil.LTrimStr( (decimal)(A24JuegoId), 4, 0));
               getEqualNoModal( ) ;
               if ( IsIns( )  && (0==A24JuegoId) && ( Gx_BScreen == 0 ) )
               {
                  A24JuegoId = 1;
                  AssignAttri("", false, "A24JuegoId", StringUtil.LTrimStr( (decimal)(A24JuegoId), 4, 0));
               }
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               getEqualNoModal( ) ;
               standaloneModal( ) ;
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
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
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes055( ) ;
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

      protected void ResetCaption050( )
      {
      }

      protected void ZM055( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z25JuegoNombre = T00053_A25JuegoNombre[0];
               Z13parqueAtraccionId = T00053_A13parqueAtraccionId[0];
               Z26CategoriaId = T00053_A26CategoriaId[0];
            }
            else
            {
               Z25JuegoNombre = A25JuegoNombre;
               Z13parqueAtraccionId = A13parqueAtraccionId;
               Z26CategoriaId = A26CategoriaId;
            }
         }
         if ( GX_JID == -4 )
         {
            Z24JuegoId = A24JuegoId;
            Z25JuegoNombre = A25JuegoNombre;
            Z13parqueAtraccionId = A13parqueAtraccionId;
            Z26CategoriaId = A26CategoriaId;
            Z14parqueAtraccionNombre = A14parqueAtraccionNombre;
            Z15parqueAtraccionSitioWeb = A15parqueAtraccionSitioWeb;
            Z17parqueAtraccionFoto = A17parqueAtraccionFoto;
            Z40000parqueAtraccionFoto_GXI = A40000parqueAtraccionFoto_GXI;
            Z27CategoriaNombre = A27CategoriaNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_13_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PARQUEATRACCIONID"+"'), id:'"+"PARQUEATRACCIONID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_26_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0060.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CATEGORIAID"+"'), id:'"+"CATEGORIAID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A26CategoriaId) && ( Gx_BScreen == 0 ) )
         {
            A26CategoriaId = 1;
            n26CategoriaId = false;
            AssignAttri("", false, "A26CategoriaId", StringUtil.LTrimStr( (decimal)(A26CategoriaId), 4, 0));
         }
         if ( IsIns( )  && (0==A13parqueAtraccionId) && ( Gx_BScreen == 0 ) )
         {
            A13parqueAtraccionId = 1;
            AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
         }
         if ( IsIns( )  && (0==A24JuegoId) && ( Gx_BScreen == 0 ) )
         {
            A24JuegoId = 1;
            AssignAttri("", false, "A24JuegoId", StringUtil.LTrimStr( (decimal)(A24JuegoId), 4, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00055 */
            pr_default.execute(3, new Object[] {n26CategoriaId, A26CategoriaId});
            A27CategoriaNombre = T00055_A27CategoriaNombre[0];
            AssignAttri("", false, "A27CategoriaNombre", A27CategoriaNombre);
            pr_default.close(3);
            /* Using cursor T00054 */
            pr_default.execute(2, new Object[] {A13parqueAtraccionId});
            A14parqueAtraccionNombre = T00054_A14parqueAtraccionNombre[0];
            AssignAttri("", false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
            A15parqueAtraccionSitioWeb = T00054_A15parqueAtraccionSitioWeb[0];
            AssignAttri("", false, "A15parqueAtraccionSitioWeb", A15parqueAtraccionSitioWeb);
            A40000parqueAtraccionFoto_GXI = T00054_A40000parqueAtraccionFoto_GXI[0];
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A17parqueAtraccionFoto))), true);
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A17parqueAtraccionFoto), true);
            A17parqueAtraccionFoto = T00054_A17parqueAtraccionFoto[0];
            AssignAttri("", false, "A17parqueAtraccionFoto", A17parqueAtraccionFoto);
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A17parqueAtraccionFoto))), true);
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A17parqueAtraccionFoto), true);
            pr_default.close(2);
         }
      }

      protected void Load055( )
      {
         /* Using cursor T00056 */
         pr_default.execute(4, new Object[] {A24JuegoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound5 = 1;
            A25JuegoNombre = T00056_A25JuegoNombre[0];
            AssignAttri("", false, "A25JuegoNombre", A25JuegoNombre);
            A14parqueAtraccionNombre = T00056_A14parqueAtraccionNombre[0];
            AssignAttri("", false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
            A15parqueAtraccionSitioWeb = T00056_A15parqueAtraccionSitioWeb[0];
            AssignAttri("", false, "A15parqueAtraccionSitioWeb", A15parqueAtraccionSitioWeb);
            A40000parqueAtraccionFoto_GXI = T00056_A40000parqueAtraccionFoto_GXI[0];
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A17parqueAtraccionFoto))), true);
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A17parqueAtraccionFoto), true);
            A27CategoriaNombre = T00056_A27CategoriaNombre[0];
            AssignAttri("", false, "A27CategoriaNombre", A27CategoriaNombre);
            A13parqueAtraccionId = T00056_A13parqueAtraccionId[0];
            AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
            A26CategoriaId = T00056_A26CategoriaId[0];
            n26CategoriaId = T00056_n26CategoriaId[0];
            AssignAttri("", false, "A26CategoriaId", StringUtil.LTrimStr( (decimal)(A26CategoriaId), 4, 0));
            A17parqueAtraccionFoto = T00056_A17parqueAtraccionFoto[0];
            AssignAttri("", false, "A17parqueAtraccionFoto", A17parqueAtraccionFoto);
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A17parqueAtraccionFoto))), true);
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A17parqueAtraccionFoto), true);
            ZM055( -4) ;
         }
         pr_default.close(4);
         OnLoadActions055( ) ;
      }

      protected void OnLoadActions055( )
      {
      }

      protected void CheckExtendedTable055( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00054 */
         pr_default.execute(2, new Object[] {A13parqueAtraccionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'parque Atraccion'.", "ForeignKeyNotFound", 1, "PARQUEATRACCIONID");
            AnyError = 1;
            GX_FocusControl = edtparqueAtraccionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A14parqueAtraccionNombre = T00054_A14parqueAtraccionNombre[0];
         AssignAttri("", false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
         A15parqueAtraccionSitioWeb = T00054_A15parqueAtraccionSitioWeb[0];
         AssignAttri("", false, "A15parqueAtraccionSitioWeb", A15parqueAtraccionSitioWeb);
         A40000parqueAtraccionFoto_GXI = T00054_A40000parqueAtraccionFoto_GXI[0];
         AssignProp("", false, imgparqueAtraccionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A17parqueAtraccionFoto))), true);
         AssignProp("", false, imgparqueAtraccionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A17parqueAtraccionFoto), true);
         A17parqueAtraccionFoto = T00054_A17parqueAtraccionFoto[0];
         AssignAttri("", false, "A17parqueAtraccionFoto", A17parqueAtraccionFoto);
         AssignProp("", false, imgparqueAtraccionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A17parqueAtraccionFoto))), true);
         AssignProp("", false, imgparqueAtraccionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A17parqueAtraccionFoto), true);
         pr_default.close(2);
         /* Using cursor T00055 */
         pr_default.execute(3, new Object[] {n26CategoriaId, A26CategoriaId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A26CategoriaId) ) )
            {
               GX_msglist.addItem("No existe 'Categoria'.", "ForeignKeyNotFound", 1, "CATEGORIAID");
               AnyError = 1;
               GX_FocusControl = edtCategoriaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A27CategoriaNombre = T00055_A27CategoriaNombre[0];
         AssignAttri("", false, "A27CategoriaNombre", A27CategoriaNombre);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors055( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( short A13parqueAtraccionId )
      {
         /* Using cursor T00057 */
         pr_default.execute(5, new Object[] {A13parqueAtraccionId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'parque Atraccion'.", "ForeignKeyNotFound", 1, "PARQUEATRACCIONID");
            AnyError = 1;
            GX_FocusControl = edtparqueAtraccionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A14parqueAtraccionNombre = T00057_A14parqueAtraccionNombre[0];
         AssignAttri("", false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
         A15parqueAtraccionSitioWeb = T00057_A15parqueAtraccionSitioWeb[0];
         AssignAttri("", false, "A15parqueAtraccionSitioWeb", A15parqueAtraccionSitioWeb);
         A40000parqueAtraccionFoto_GXI = T00057_A40000parqueAtraccionFoto_GXI[0];
         AssignProp("", false, imgparqueAtraccionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A17parqueAtraccionFoto))), true);
         AssignProp("", false, imgparqueAtraccionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A17parqueAtraccionFoto), true);
         A17parqueAtraccionFoto = T00057_A17parqueAtraccionFoto[0];
         AssignAttri("", false, "A17parqueAtraccionFoto", A17parqueAtraccionFoto);
         AssignProp("", false, imgparqueAtraccionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A17parqueAtraccionFoto))), true);
         AssignProp("", false, imgparqueAtraccionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A17parqueAtraccionFoto), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A14parqueAtraccionNombre)+"\""+","+"\""+GXUtil.EncodeJSConstant( A15parqueAtraccionSitioWeb)+"\""+","+"\""+GXUtil.EncodeJSConstant( A17parqueAtraccionFoto)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000parqueAtraccionFoto_GXI)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_6( short A26CategoriaId )
      {
         /* Using cursor T00058 */
         pr_default.execute(6, new Object[] {n26CategoriaId, A26CategoriaId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A26CategoriaId) ) )
            {
               GX_msglist.addItem("No existe 'Categoria'.", "ForeignKeyNotFound", 1, "CATEGORIAID");
               AnyError = 1;
               GX_FocusControl = edtCategoriaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A27CategoriaNombre = T00058_A27CategoriaNombre[0];
         AssignAttri("", false, "A27CategoriaNombre", A27CategoriaNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A27CategoriaNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey055( )
      {
         /* Using cursor T00059 */
         pr_default.execute(7, new Object[] {A24JuegoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00053 */
         pr_default.execute(1, new Object[] {A24JuegoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM055( 4) ;
            RcdFound5 = 1;
            A24JuegoId = T00053_A24JuegoId[0];
            AssignAttri("", false, "A24JuegoId", StringUtil.LTrimStr( (decimal)(A24JuegoId), 4, 0));
            A25JuegoNombre = T00053_A25JuegoNombre[0];
            AssignAttri("", false, "A25JuegoNombre", A25JuegoNombre);
            A13parqueAtraccionId = T00053_A13parqueAtraccionId[0];
            AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
            A26CategoriaId = T00053_A26CategoriaId[0];
            n26CategoriaId = T00053_n26CategoriaId[0];
            AssignAttri("", false, "A26CategoriaId", StringUtil.LTrimStr( (decimal)(A26CategoriaId), 4, 0));
            Z24JuegoId = A24JuegoId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
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
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound5 = 0;
         /* Using cursor T000510 */
         pr_default.execute(8, new Object[] {A24JuegoId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000510_A24JuegoId[0] < A24JuegoId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000510_A24JuegoId[0] > A24JuegoId ) ) )
            {
               A24JuegoId = T000510_A24JuegoId[0];
               AssignAttri("", false, "A24JuegoId", StringUtil.LTrimStr( (decimal)(A24JuegoId), 4, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound5 = 0;
         /* Using cursor T000511 */
         pr_default.execute(9, new Object[] {A24JuegoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000511_A24JuegoId[0] > A24JuegoId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000511_A24JuegoId[0] < A24JuegoId ) ) )
            {
               A24JuegoId = T000511_A24JuegoId[0];
               AssignAttri("", false, "A24JuegoId", StringUtil.LTrimStr( (decimal)(A24JuegoId), 4, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey055( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtJuegoId_Internalname;
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
               if ( A24JuegoId != Z24JuegoId )
               {
                  A24JuegoId = Z24JuegoId;
                  AssignAttri("", false, "A24JuegoId", StringUtil.LTrimStr( (decimal)(A24JuegoId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "JUEGOID");
                  AnyError = 1;
                  GX_FocusControl = edtJuegoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtJuegoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update055( ) ;
                  GX_FocusControl = edtJuegoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A24JuegoId != Z24JuegoId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtJuegoId_Internalname;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "JUEGOID");
                     AnyError = 1;
                     GX_FocusControl = edtJuegoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtJuegoId_Internalname;
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
      }

      protected void btn_delete( )
      {
         if ( A24JuegoId != Z24JuegoId )
         {
            A24JuegoId = Z24JuegoId;
            AssignAttri("", false, "A24JuegoId", StringUtil.LTrimStr( (decimal)(A24JuegoId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "JUEGOID");
            AnyError = 1;
            GX_FocusControl = edtJuegoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtJuegoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "JUEGOID");
            AnyError = 1;
            GX_FocusControl = edtJuegoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtJuegoNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtJuegoNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd055( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtJuegoNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtJuegoNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound5 != 0 )
            {
               ScanNext055( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtJuegoNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd055( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency055( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00052 */
            pr_default.execute(0, new Object[] {A24JuegoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Juego"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z25JuegoNombre, T00052_A25JuegoNombre[0]) != 0 ) || ( Z13parqueAtraccionId != T00052_A13parqueAtraccionId[0] ) || ( Z26CategoriaId != T00052_A26CategoriaId[0] ) )
            {
               if ( StringUtil.StrCmp(Z25JuegoNombre, T00052_A25JuegoNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("juego:[seudo value changed for attri]"+"JuegoNombre");
                  GXUtil.WriteLogRaw("Old: ",Z25JuegoNombre);
                  GXUtil.WriteLogRaw("Current: ",T00052_A25JuegoNombre[0]);
               }
               if ( Z13parqueAtraccionId != T00052_A13parqueAtraccionId[0] )
               {
                  GXUtil.WriteLog("juego:[seudo value changed for attri]"+"parqueAtraccionId");
                  GXUtil.WriteLogRaw("Old: ",Z13parqueAtraccionId);
                  GXUtil.WriteLogRaw("Current: ",T00052_A13parqueAtraccionId[0]);
               }
               if ( Z26CategoriaId != T00052_A26CategoriaId[0] )
               {
                  GXUtil.WriteLog("juego:[seudo value changed for attri]"+"CategoriaId");
                  GXUtil.WriteLogRaw("Old: ",Z26CategoriaId);
                  GXUtil.WriteLogRaw("Current: ",T00052_A26CategoriaId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Juego"}), "RecordWasChanged", 1, "");
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
                     /* Using cursor T000512 */
                     pr_default.execute(10, new Object[] {A25JuegoNombre, A13parqueAtraccionId, n26CategoriaId, A26CategoriaId});
                     A24JuegoId = T000512_A24JuegoId[0];
                     AssignAttri("", false, "A24JuegoId", StringUtil.LTrimStr( (decimal)(A24JuegoId), 4, 0));
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Juego");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption050( ) ;
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
                     /* Using cursor T000513 */
                     pr_default.execute(11, new Object[] {A25JuegoNombre, A13parqueAtraccionId, n26CategoriaId, A26CategoriaId, A24JuegoId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Juego");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Juego"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate055( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption050( ) ;
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
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
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
                  /* Using cursor T000514 */
                  pr_default.execute(12, new Object[] {A24JuegoId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("Juego");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound5 == 0 )
                        {
                           InitAll055( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption050( ) ;
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
            /* Using cursor T000515 */
            pr_default.execute(13, new Object[] {A13parqueAtraccionId});
            A14parqueAtraccionNombre = T000515_A14parqueAtraccionNombre[0];
            AssignAttri("", false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
            A15parqueAtraccionSitioWeb = T000515_A15parqueAtraccionSitioWeb[0];
            AssignAttri("", false, "A15parqueAtraccionSitioWeb", A15parqueAtraccionSitioWeb);
            A40000parqueAtraccionFoto_GXI = T000515_A40000parqueAtraccionFoto_GXI[0];
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A17parqueAtraccionFoto))), true);
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A17parqueAtraccionFoto), true);
            A17parqueAtraccionFoto = T000515_A17parqueAtraccionFoto[0];
            AssignAttri("", false, "A17parqueAtraccionFoto", A17parqueAtraccionFoto);
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A17parqueAtraccionFoto))), true);
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A17parqueAtraccionFoto), true);
            pr_default.close(13);
            /* Using cursor T000516 */
            pr_default.execute(14, new Object[] {n26CategoriaId, A26CategoriaId});
            A27CategoriaNombre = T000516_A27CategoriaNombre[0];
            AssignAttri("", false, "A27CategoriaNombre", A27CategoriaNombre);
            pr_default.close(14);
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
            pr_default.close(13);
            pr_default.close(14);
            context.CommitDataStores("juego",pr_default);
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
            pr_default.close(13);
            pr_default.close(14);
            context.RollbackDataStores("juego",pr_default);
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
         /* Using cursor T000517 */
         pr_default.execute(15);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound5 = 1;
            A24JuegoId = T000517_A24JuegoId[0];
            AssignAttri("", false, "A24JuegoId", StringUtil.LTrimStr( (decimal)(A24JuegoId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext055( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound5 = 1;
            A24JuegoId = T000517_A24JuegoId[0];
            AssignAttri("", false, "A24JuegoId", StringUtil.LTrimStr( (decimal)(A24JuegoId), 4, 0));
         }
      }

      protected void ScanEnd055( )
      {
         pr_default.close(15);
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
         edtJuegoId_Enabled = 0;
         AssignProp("", false, edtJuegoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtJuegoId_Enabled), 5, 0), true);
         edtJuegoNombre_Enabled = 0;
         AssignProp("", false, edtJuegoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtJuegoNombre_Enabled), 5, 0), true);
         edtparqueAtraccionId_Enabled = 0;
         AssignProp("", false, edtparqueAtraccionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtparqueAtraccionId_Enabled), 5, 0), true);
         edtparqueAtraccionNombre_Enabled = 0;
         AssignProp("", false, edtparqueAtraccionNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtparqueAtraccionNombre_Enabled), 5, 0), true);
         edtparqueAtraccionSitioWeb_Enabled = 0;
         AssignProp("", false, edtparqueAtraccionSitioWeb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtparqueAtraccionSitioWeb_Enabled), 5, 0), true);
         imgparqueAtraccionFoto_Enabled = 0;
         AssignProp("", false, imgparqueAtraccionFoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgparqueAtraccionFoto_Enabled), 5, 0), true);
         edtCategoriaId_Enabled = 0;
         AssignProp("", false, edtCategoriaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaId_Enabled), 5, 0), true);
         edtCategoriaNombre_Enabled = 0;
         AssignProp("", false, edtCategoriaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaNombre_Enabled), 5, 0), true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("juego.aspx") +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z24JuegoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z24JuegoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z25JuegoNombre", Z25JuegoNombre);
         GxWebStd.gx_hidden_field( context, "Z13parqueAtraccionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13parqueAtraccionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z26CategoriaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26CategoriaId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PARQUEATRACCIONFOTO_GXI", A40000parqueAtraccionFoto_GXI);
         GXCCtlgxBlob = "PARQUEATRACCIONFOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A17parqueAtraccionFoto);
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
         return formatLink("juego.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Juego" ;
      }

      public override string GetPgmdesc( )
      {
         return "Juego" ;
      }

      protected void InitializeNonKey055( )
      {
         A25JuegoNombre = "";
         AssignAttri("", false, "A25JuegoNombre", A25JuegoNombre);
         A14parqueAtraccionNombre = "";
         AssignAttri("", false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
         A15parqueAtraccionSitioWeb = "";
         AssignAttri("", false, "A15parqueAtraccionSitioWeb", A15parqueAtraccionSitioWeb);
         A17parqueAtraccionFoto = "";
         AssignAttri("", false, "A17parqueAtraccionFoto", A17parqueAtraccionFoto);
         AssignProp("", false, imgparqueAtraccionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A17parqueAtraccionFoto))), true);
         AssignProp("", false, imgparqueAtraccionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A17parqueAtraccionFoto), true);
         A40000parqueAtraccionFoto_GXI = "";
         AssignProp("", false, imgparqueAtraccionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A17parqueAtraccionFoto))), true);
         AssignProp("", false, imgparqueAtraccionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A17parqueAtraccionFoto), true);
         A27CategoriaNombre = "";
         AssignAttri("", false, "A27CategoriaNombre", A27CategoriaNombre);
         A13parqueAtraccionId = 1;
         AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
         A26CategoriaId = 1;
         n26CategoriaId = false;
         AssignAttri("", false, "A26CategoriaId", StringUtil.LTrimStr( (decimal)(A26CategoriaId), 4, 0));
         Z25JuegoNombre = "";
         Z13parqueAtraccionId = 0;
         Z26CategoriaId = 0;
      }

      protected void InitAll055( )
      {
         A24JuegoId = 1;
         AssignAttri("", false, "A24JuegoId", StringUtil.LTrimStr( (decimal)(A24JuegoId), 4, 0));
         InitializeNonKey055( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A26CategoriaId = i26CategoriaId;
         n26CategoriaId = false;
         AssignAttri("", false, "A26CategoriaId", StringUtil.LTrimStr( (decimal)(A26CategoriaId), 4, 0));
         A13parqueAtraccionId = i13parqueAtraccionId;
         AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20254122151285", true, true);
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
         context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("juego.js", "?20254122151285", false, true);
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
         edtJuegoId_Internalname = "JUEGOID";
         edtJuegoNombre_Internalname = "JUEGONOMBRE";
         edtparqueAtraccionId_Internalname = "PARQUEATRACCIONID";
         edtparqueAtraccionNombre_Internalname = "PARQUEATRACCIONNOMBRE";
         edtparqueAtraccionSitioWeb_Internalname = "PARQUEATRACCIONSITIOWEB";
         imgparqueAtraccionFoto_Internalname = "PARQUEATRACCIONFOTO";
         edtCategoriaId_Internalname = "CATEGORIAID";
         edtCategoriaNombre_Internalname = "CATEGORIANOMBRE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_13_Internalname = "PROMPT_13";
         imgprompt_26_Internalname = "PROMPT_26";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("parques", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Juego";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCategoriaNombre_Jsonclick = "";
         edtCategoriaNombre_Enabled = 0;
         imgprompt_26_Visible = 1;
         imgprompt_26_Link = "";
         edtCategoriaId_Jsonclick = "";
         edtCategoriaId_Enabled = 1;
         imgparqueAtraccionFoto_Enabled = 0;
         edtparqueAtraccionSitioWeb_Jsonclick = "";
         edtparqueAtraccionSitioWeb_Enabled = 0;
         edtparqueAtraccionNombre_Jsonclick = "";
         edtparqueAtraccionNombre_Enabled = 0;
         imgprompt_13_Visible = 1;
         imgprompt_13_Link = "";
         edtparqueAtraccionId_Jsonclick = "";
         edtparqueAtraccionId_Enabled = 1;
         edtJuegoNombre_Jsonclick = "";
         edtJuegoNombre_Enabled = 1;
         edtJuegoId_Jsonclick = "";
         edtJuegoId_Enabled = 1;
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

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtJuegoNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
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

      public void Valid_Juegoid( )
      {
         n26CategoriaId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A25JuegoNombre", A25JuegoNombre);
         AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13parqueAtraccionId), 4, 0, ".", "")));
         AssignAttri("", false, "A26CategoriaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A26CategoriaId), 4, 0, ".", "")));
         AssignAttri("", false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
         AssignAttri("", false, "A15parqueAtraccionSitioWeb", A15parqueAtraccionSitioWeb);
         AssignAttri("", false, "A17parqueAtraccionFoto", context.PathToRelativeUrl( A17parqueAtraccionFoto));
         GXCCtlgxBlob = "PARQUEATRACCIONFOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A17parqueAtraccionFoto));
         AssignAttri("", false, "A40000parqueAtraccionFoto_GXI", A40000parqueAtraccionFoto_GXI);
         AssignAttri("", false, "A27CategoriaNombre", A27CategoriaNombre);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z24JuegoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z24JuegoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z25JuegoNombre", Z25JuegoNombre);
         GxWebStd.gx_hidden_field( context, "Z13parqueAtraccionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13parqueAtraccionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z26CategoriaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26CategoriaId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z14parqueAtraccionNombre", Z14parqueAtraccionNombre);
         GxWebStd.gx_hidden_field( context, "Z15parqueAtraccionSitioWeb", Z15parqueAtraccionSitioWeb);
         GxWebStd.gx_hidden_field( context, "Z17parqueAtraccionFoto", context.PathToRelativeUrl( Z17parqueAtraccionFoto));
         GxWebStd.gx_hidden_field( context, "Z40000parqueAtraccionFoto_GXI", Z40000parqueAtraccionFoto_GXI);
         GxWebStd.gx_hidden_field( context, "Z27CategoriaNombre", Z27CategoriaNombre);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Parqueatraccionid( )
      {
         /* Using cursor T000515 */
         pr_default.execute(13, new Object[] {A13parqueAtraccionId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'parque Atraccion'.", "ForeignKeyNotFound", 1, "PARQUEATRACCIONID");
            AnyError = 1;
            GX_FocusControl = edtparqueAtraccionId_Internalname;
         }
         A14parqueAtraccionNombre = T000515_A14parqueAtraccionNombre[0];
         A15parqueAtraccionSitioWeb = T000515_A15parqueAtraccionSitioWeb[0];
         A40000parqueAtraccionFoto_GXI = T000515_A40000parqueAtraccionFoto_GXI[0];
         A17parqueAtraccionFoto = T000515_A17parqueAtraccionFoto[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
         AssignAttri("", false, "A15parqueAtraccionSitioWeb", A15parqueAtraccionSitioWeb);
         AssignAttri("", false, "A17parqueAtraccionFoto", context.PathToRelativeUrl( A17parqueAtraccionFoto));
         GXCCtlgxBlob = "PARQUEATRACCIONFOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A17parqueAtraccionFoto));
         AssignAttri("", false, "A40000parqueAtraccionFoto_GXI", A40000parqueAtraccionFoto_GXI);
      }

      public void Valid_Categoriaid( )
      {
         n26CategoriaId = false;
         /* Using cursor T000516 */
         pr_default.execute(14, new Object[] {n26CategoriaId, A26CategoriaId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A26CategoriaId) ) )
            {
               GX_msglist.addItem("No existe 'Categoria'.", "ForeignKeyNotFound", 1, "CATEGORIAID");
               AnyError = 1;
               GX_FocusControl = edtCategoriaId_Internalname;
            }
         }
         A27CategoriaNombre = T000516_A27CategoriaNombre[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A27CategoriaNombre", A27CategoriaNombre);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_JUEGOID","""{"handler":"Valid_Juegoid","iparms":[{"av":"A24JuegoId","fld":"JUEGOID","pic":"ZZZ9"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A26CategoriaId","fld":"CATEGORIAID","pic":"ZZZ9"},{"av":"A13parqueAtraccionId","fld":"PARQUEATRACCIONID","pic":"ZZZ9"}]""");
         setEventMetadata("VALID_JUEGOID",""","oparms":[{"av":"A25JuegoNombre","fld":"JUEGONOMBRE"},{"av":"A13parqueAtraccionId","fld":"PARQUEATRACCIONID","pic":"ZZZ9"},{"av":"A26CategoriaId","fld":"CATEGORIAID","pic":"ZZZ9"},{"av":"A14parqueAtraccionNombre","fld":"PARQUEATRACCIONNOMBRE"},{"av":"A15parqueAtraccionSitioWeb","fld":"PARQUEATRACCIONSITIOWEB"},{"av":"A17parqueAtraccionFoto","fld":"PARQUEATRACCIONFOTO"},{"av":"A40000parqueAtraccionFoto_GXI","fld":"PARQUEATRACCIONFOTO_GXI"},{"av":"A27CategoriaNombre","fld":"CATEGORIANOMBRE"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z24JuegoId"},{"av":"Z25JuegoNombre"},{"av":"Z13parqueAtraccionId"},{"av":"Z26CategoriaId"},{"av":"Z14parqueAtraccionNombre"},{"av":"Z15parqueAtraccionSitioWeb"},{"av":"Z17parqueAtraccionFoto"},{"av":"Z40000parqueAtraccionFoto_GXI"},{"av":"Z27CategoriaNombre"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_PARQUEATRACCIONID","""{"handler":"Valid_Parqueatraccionid","iparms":[{"av":"A13parqueAtraccionId","fld":"PARQUEATRACCIONID","pic":"ZZZ9"},{"av":"A14parqueAtraccionNombre","fld":"PARQUEATRACCIONNOMBRE"},{"av":"A15parqueAtraccionSitioWeb","fld":"PARQUEATRACCIONSITIOWEB"},{"av":"A17parqueAtraccionFoto","fld":"PARQUEATRACCIONFOTO"},{"av":"A40000parqueAtraccionFoto_GXI","fld":"PARQUEATRACCIONFOTO_GXI"}]""");
         setEventMetadata("VALID_PARQUEATRACCIONID",""","oparms":[{"av":"A14parqueAtraccionNombre","fld":"PARQUEATRACCIONNOMBRE"},{"av":"A15parqueAtraccionSitioWeb","fld":"PARQUEATRACCIONSITIOWEB"},{"av":"A17parqueAtraccionFoto","fld":"PARQUEATRACCIONFOTO"},{"av":"A40000parqueAtraccionFoto_GXI","fld":"PARQUEATRACCIONFOTO_GXI"}]}""");
         setEventMetadata("VALID_CATEGORIAID","""{"handler":"Valid_Categoriaid","iparms":[{"av":"A26CategoriaId","fld":"CATEGORIAID","pic":"ZZZ9"},{"av":"A27CategoriaNombre","fld":"CATEGORIANOMBRE"}]""");
         setEventMetadata("VALID_CATEGORIAID",""","oparms":[{"av":"A27CategoriaNombre","fld":"CATEGORIANOMBRE"}]}""");
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
         pr_default.close(13);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z25JuegoNombre = "";
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
         A25JuegoNombre = "";
         imgprompt_13_gximage = "";
         sImgUrl = "";
         A14parqueAtraccionNombre = "";
         A15parqueAtraccionSitioWeb = "";
         A17parqueAtraccionFoto = "";
         A40000parqueAtraccionFoto_GXI = "";
         imgprompt_26_gximage = "";
         A27CategoriaNombre = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z14parqueAtraccionNombre = "";
         Z15parqueAtraccionSitioWeb = "";
         Z17parqueAtraccionFoto = "";
         Z40000parqueAtraccionFoto_GXI = "";
         Z27CategoriaNombre = "";
         T00055_A27CategoriaNombre = new string[] {""} ;
         T00054_A14parqueAtraccionNombre = new string[] {""} ;
         T00054_A15parqueAtraccionSitioWeb = new string[] {""} ;
         T00054_A40000parqueAtraccionFoto_GXI = new string[] {""} ;
         T00054_A17parqueAtraccionFoto = new string[] {""} ;
         T00056_A24JuegoId = new short[1] ;
         T00056_A25JuegoNombre = new string[] {""} ;
         T00056_A14parqueAtraccionNombre = new string[] {""} ;
         T00056_A15parqueAtraccionSitioWeb = new string[] {""} ;
         T00056_A40000parqueAtraccionFoto_GXI = new string[] {""} ;
         T00056_A27CategoriaNombre = new string[] {""} ;
         T00056_A13parqueAtraccionId = new short[1] ;
         T00056_A26CategoriaId = new short[1] ;
         T00056_n26CategoriaId = new bool[] {false} ;
         T00056_A17parqueAtraccionFoto = new string[] {""} ;
         T00057_A14parqueAtraccionNombre = new string[] {""} ;
         T00057_A15parqueAtraccionSitioWeb = new string[] {""} ;
         T00057_A40000parqueAtraccionFoto_GXI = new string[] {""} ;
         T00057_A17parqueAtraccionFoto = new string[] {""} ;
         T00058_A27CategoriaNombre = new string[] {""} ;
         T00059_A24JuegoId = new short[1] ;
         T00053_A24JuegoId = new short[1] ;
         T00053_A25JuegoNombre = new string[] {""} ;
         T00053_A13parqueAtraccionId = new short[1] ;
         T00053_A26CategoriaId = new short[1] ;
         T00053_n26CategoriaId = new bool[] {false} ;
         sMode5 = "";
         T000510_A24JuegoId = new short[1] ;
         T000511_A24JuegoId = new short[1] ;
         T00052_A24JuegoId = new short[1] ;
         T00052_A25JuegoNombre = new string[] {""} ;
         T00052_A13parqueAtraccionId = new short[1] ;
         T00052_A26CategoriaId = new short[1] ;
         T00052_n26CategoriaId = new bool[] {false} ;
         T000512_A24JuegoId = new short[1] ;
         T000515_A14parqueAtraccionNombre = new string[] {""} ;
         T000515_A15parqueAtraccionSitioWeb = new string[] {""} ;
         T000515_A40000parqueAtraccionFoto_GXI = new string[] {""} ;
         T000515_A17parqueAtraccionFoto = new string[] {""} ;
         T000516_A27CategoriaNombre = new string[] {""} ;
         T000517_A24JuegoId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         ZZ25JuegoNombre = "";
         ZZ14parqueAtraccionNombre = "";
         ZZ15parqueAtraccionSitioWeb = "";
         ZZ17parqueAtraccionFoto = "";
         ZZ40000parqueAtraccionFoto_GXI = "";
         ZZ27CategoriaNombre = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.juego__default(),
            new Object[][] {
                new Object[] {
               T00052_A24JuegoId, T00052_A25JuegoNombre, T00052_A13parqueAtraccionId, T00052_A26CategoriaId, T00052_n26CategoriaId
               }
               , new Object[] {
               T00053_A24JuegoId, T00053_A25JuegoNombre, T00053_A13parqueAtraccionId, T00053_A26CategoriaId, T00053_n26CategoriaId
               }
               , new Object[] {
               T00054_A14parqueAtraccionNombre, T00054_A15parqueAtraccionSitioWeb, T00054_A40000parqueAtraccionFoto_GXI, T00054_A17parqueAtraccionFoto
               }
               , new Object[] {
               T00055_A27CategoriaNombre
               }
               , new Object[] {
               T00056_A24JuegoId, T00056_A25JuegoNombre, T00056_A14parqueAtraccionNombre, T00056_A15parqueAtraccionSitioWeb, T00056_A40000parqueAtraccionFoto_GXI, T00056_A27CategoriaNombre, T00056_A13parqueAtraccionId, T00056_A26CategoriaId, T00056_n26CategoriaId, T00056_A17parqueAtraccionFoto
               }
               , new Object[] {
               T00057_A14parqueAtraccionNombre, T00057_A15parqueAtraccionSitioWeb, T00057_A40000parqueAtraccionFoto_GXI, T00057_A17parqueAtraccionFoto
               }
               , new Object[] {
               T00058_A27CategoriaNombre
               }
               , new Object[] {
               T00059_A24JuegoId
               }
               , new Object[] {
               T000510_A24JuegoId
               }
               , new Object[] {
               T000511_A24JuegoId
               }
               , new Object[] {
               T000512_A24JuegoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000515_A14parqueAtraccionNombre, T000515_A15parqueAtraccionSitioWeb, T000515_A40000parqueAtraccionFoto_GXI, T000515_A17parqueAtraccionFoto
               }
               , new Object[] {
               T000516_A27CategoriaNombre
               }
               , new Object[] {
               T000517_A24JuegoId
               }
            }
         );
         Z26CategoriaId = 1;
         n26CategoriaId = false;
         i26CategoriaId = 1;
         n26CategoriaId = false;
         A26CategoriaId = 1;
         n26CategoriaId = false;
         Z13parqueAtraccionId = 1;
         i13parqueAtraccionId = 1;
         A13parqueAtraccionId = 1;
         Z24JuegoId = 1;
         A24JuegoId = 1;
      }

      private short Z24JuegoId ;
      private short Z13parqueAtraccionId ;
      private short Z26CategoriaId ;
      private short GxWebError ;
      private short A13parqueAtraccionId ;
      private short A26CategoriaId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A24JuegoId ;
      private short Gx_BScreen ;
      private short RcdFound5 ;
      private short gxajaxcallmode ;
      private short i26CategoriaId ;
      private short i13parqueAtraccionId ;
      private short ZZ24JuegoId ;
      private short ZZ13parqueAtraccionId ;
      private short ZZ26CategoriaId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtJuegoId_Enabled ;
      private int edtJuegoNombre_Enabled ;
      private int edtparqueAtraccionId_Enabled ;
      private int imgprompt_13_Visible ;
      private int edtparqueAtraccionNombre_Enabled ;
      private int edtparqueAtraccionSitioWeb_Enabled ;
      private int imgparqueAtraccionFoto_Enabled ;
      private int edtCategoriaId_Enabled ;
      private int imgprompt_26_Visible ;
      private int edtCategoriaNombre_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtJuegoId_Internalname ;
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
      private string edtJuegoId_Jsonclick ;
      private string edtJuegoNombre_Internalname ;
      private string edtJuegoNombre_Jsonclick ;
      private string edtparqueAtraccionId_Internalname ;
      private string edtparqueAtraccionId_Jsonclick ;
      private string imgprompt_13_gximage ;
      private string sImgUrl ;
      private string imgprompt_13_Internalname ;
      private string imgprompt_13_Link ;
      private string edtparqueAtraccionNombre_Internalname ;
      private string edtparqueAtraccionNombre_Jsonclick ;
      private string edtparqueAtraccionSitioWeb_Internalname ;
      private string edtparqueAtraccionSitioWeb_Jsonclick ;
      private string imgparqueAtraccionFoto_Internalname ;
      private string edtCategoriaId_Internalname ;
      private string edtCategoriaId_Jsonclick ;
      private string imgprompt_26_gximage ;
      private string imgprompt_26_Internalname ;
      private string imgprompt_26_Link ;
      private string edtCategoriaNombre_Internalname ;
      private string edtCategoriaNombre_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode5 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n26CategoriaId ;
      private bool wbErr ;
      private bool A17parqueAtraccionFoto_IsBlob ;
      private string Z25JuegoNombre ;
      private string A25JuegoNombre ;
      private string A14parqueAtraccionNombre ;
      private string A15parqueAtraccionSitioWeb ;
      private string A40000parqueAtraccionFoto_GXI ;
      private string A27CategoriaNombre ;
      private string Z14parqueAtraccionNombre ;
      private string Z15parqueAtraccionSitioWeb ;
      private string Z40000parqueAtraccionFoto_GXI ;
      private string Z27CategoriaNombre ;
      private string ZZ25JuegoNombre ;
      private string ZZ14parqueAtraccionNombre ;
      private string ZZ15parqueAtraccionSitioWeb ;
      private string ZZ40000parqueAtraccionFoto_GXI ;
      private string ZZ27CategoriaNombre ;
      private string A17parqueAtraccionFoto ;
      private string Z17parqueAtraccionFoto ;
      private string ZZ17parqueAtraccionFoto ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00055_A27CategoriaNombre ;
      private string[] T00054_A14parqueAtraccionNombre ;
      private string[] T00054_A15parqueAtraccionSitioWeb ;
      private string[] T00054_A40000parqueAtraccionFoto_GXI ;
      private string[] T00054_A17parqueAtraccionFoto ;
      private short[] T00056_A24JuegoId ;
      private string[] T00056_A25JuegoNombre ;
      private string[] T00056_A14parqueAtraccionNombre ;
      private string[] T00056_A15parqueAtraccionSitioWeb ;
      private string[] T00056_A40000parqueAtraccionFoto_GXI ;
      private string[] T00056_A27CategoriaNombre ;
      private short[] T00056_A13parqueAtraccionId ;
      private short[] T00056_A26CategoriaId ;
      private bool[] T00056_n26CategoriaId ;
      private string[] T00056_A17parqueAtraccionFoto ;
      private string[] T00057_A14parqueAtraccionNombre ;
      private string[] T00057_A15parqueAtraccionSitioWeb ;
      private string[] T00057_A40000parqueAtraccionFoto_GXI ;
      private string[] T00057_A17parqueAtraccionFoto ;
      private string[] T00058_A27CategoriaNombre ;
      private short[] T00059_A24JuegoId ;
      private short[] T00053_A24JuegoId ;
      private string[] T00053_A25JuegoNombre ;
      private short[] T00053_A13parqueAtraccionId ;
      private short[] T00053_A26CategoriaId ;
      private bool[] T00053_n26CategoriaId ;
      private short[] T000510_A24JuegoId ;
      private short[] T000511_A24JuegoId ;
      private short[] T00052_A24JuegoId ;
      private string[] T00052_A25JuegoNombre ;
      private short[] T00052_A13parqueAtraccionId ;
      private short[] T00052_A26CategoriaId ;
      private bool[] T00052_n26CategoriaId ;
      private short[] T000512_A24JuegoId ;
      private string[] T000515_A14parqueAtraccionNombre ;
      private string[] T000515_A15parqueAtraccionSitioWeb ;
      private string[] T000515_A40000parqueAtraccionFoto_GXI ;
      private string[] T000515_A17parqueAtraccionFoto ;
      private string[] T000516_A27CategoriaNombre ;
      private short[] T000517_A24JuegoId ;
   }

   public class juego__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00052;
          prmT00052 = new Object[] {
          new ParDef("@JuegoId",GXType.Int16,4,0)
          };
          Object[] prmT00053;
          prmT00053 = new Object[] {
          new ParDef("@JuegoId",GXType.Int16,4,0)
          };
          Object[] prmT00054;
          prmT00054 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0)
          };
          Object[] prmT00055;
          prmT00055 = new Object[] {
          new ParDef("@CategoriaId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00056;
          prmT00056 = new Object[] {
          new ParDef("@JuegoId",GXType.Int16,4,0)
          };
          Object[] prmT00057;
          prmT00057 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0)
          };
          Object[] prmT00058;
          prmT00058 = new Object[] {
          new ParDef("@CategoriaId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00059;
          prmT00059 = new Object[] {
          new ParDef("@JuegoId",GXType.Int16,4,0)
          };
          Object[] prmT000510;
          prmT000510 = new Object[] {
          new ParDef("@JuegoId",GXType.Int16,4,0)
          };
          Object[] prmT000511;
          prmT000511 = new Object[] {
          new ParDef("@JuegoId",GXType.Int16,4,0)
          };
          Object[] prmT000512;
          prmT000512 = new Object[] {
          new ParDef("@JuegoNombre",GXType.NVarChar,40,0) ,
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0) ,
          new ParDef("@CategoriaId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000513;
          prmT000513 = new Object[] {
          new ParDef("@JuegoNombre",GXType.NVarChar,40,0) ,
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0) ,
          new ParDef("@CategoriaId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@JuegoId",GXType.Int16,4,0)
          };
          Object[] prmT000514;
          prmT000514 = new Object[] {
          new ParDef("@JuegoId",GXType.Int16,4,0)
          };
          Object[] prmT000515;
          prmT000515 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0)
          };
          Object[] prmT000516;
          prmT000516 = new Object[] {
          new ParDef("@CategoriaId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000517;
          prmT000517 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00052", "SELECT [JuegoId], [JuegoNombre], [parqueAtraccionId], [CategoriaId] FROM [Juego] WITH (UPDLOCK) WHERE [JuegoId] = @JuegoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00052,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00053", "SELECT [JuegoId], [JuegoNombre], [parqueAtraccionId], [CategoriaId] FROM [Juego] WHERE [JuegoId] = @JuegoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00053,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00054", "SELECT [parqueAtraccionNombre], [parqueAtraccionSitioWeb], [parqueAtraccionFoto_GXI], [parqueAtraccionFoto] FROM [parqueAtraccion] WHERE [parqueAtraccionId] = @parqueAtraccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00054,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00055", "SELECT [CategoriaNombre] FROM [Categoria] WHERE [CategoriaId] = @CategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00055,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00056", "SELECT TM1.[JuegoId], TM1.[JuegoNombre], T2.[parqueAtraccionNombre], T2.[parqueAtraccionSitioWeb], T2.[parqueAtraccionFoto_GXI], T3.[CategoriaNombre], TM1.[parqueAtraccionId], TM1.[CategoriaId], T2.[parqueAtraccionFoto] FROM (([Juego] TM1 INNER JOIN [parqueAtraccion] T2 ON T2.[parqueAtraccionId] = TM1.[parqueAtraccionId]) LEFT JOIN [Categoria] T3 ON T3.[CategoriaId] = TM1.[CategoriaId]) WHERE TM1.[JuegoId] = @JuegoId ORDER BY TM1.[JuegoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00056,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00057", "SELECT [parqueAtraccionNombre], [parqueAtraccionSitioWeb], [parqueAtraccionFoto_GXI], [parqueAtraccionFoto] FROM [parqueAtraccion] WHERE [parqueAtraccionId] = @parqueAtraccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00057,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00058", "SELECT [CategoriaNombre] FROM [Categoria] WHERE [CategoriaId] = @CategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00058,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00059", "SELECT [JuegoId] FROM [Juego] WHERE [JuegoId] = @JuegoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00059,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000510", "SELECT TOP 1 [JuegoId] FROM [Juego] WHERE ( [JuegoId] > @JuegoId) ORDER BY [JuegoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000510,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000511", "SELECT TOP 1 [JuegoId] FROM [Juego] WHERE ( [JuegoId] < @JuegoId) ORDER BY [JuegoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000511,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000512", "INSERT INTO [Juego]([JuegoNombre], [parqueAtraccionId], [CategoriaId]) VALUES(@JuegoNombre, @parqueAtraccionId, @CategoriaId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000512,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000513", "UPDATE [Juego] SET [JuegoNombre]=@JuegoNombre, [parqueAtraccionId]=@parqueAtraccionId, [CategoriaId]=@CategoriaId  WHERE [JuegoId] = @JuegoId", GxErrorMask.GX_NOMASK,prmT000513)
             ,new CursorDef("T000514", "DELETE FROM [Juego]  WHERE [JuegoId] = @JuegoId", GxErrorMask.GX_NOMASK,prmT000514)
             ,new CursorDef("T000515", "SELECT [parqueAtraccionNombre], [parqueAtraccionSitioWeb], [parqueAtraccionFoto_GXI], [parqueAtraccionFoto] FROM [parqueAtraccion] WHERE [parqueAtraccionId] = @parqueAtraccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000515,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000516", "SELECT [CategoriaNombre] FROM [Categoria] WHERE [CategoriaId] = @CategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000516,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000517", "SELECT [JuegoId] FROM [Juego] ORDER BY [JuegoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000517,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
