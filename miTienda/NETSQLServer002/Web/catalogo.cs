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
   public class catalogo : GXDataArea
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
               AV7CatalogoID = (int)(Math.Round(NumberUtil.Val( GetPar( "CatalogoID"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7CatalogoID", StringUtil.LTrimStr( (decimal)(AV7CatalogoID), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vCATALOGOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CatalogoID), "ZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Catalogo", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCatalogoDescripcion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("miTienda", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public catalogo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("miTienda", true);
      }

      public catalogo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_CatalogoID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CatalogoID = aP1_CatalogoID;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Catalogo", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Catalogo.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Catalogo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Catalogo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Catalogo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Catalogo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Catalogo.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCatalogoID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCatalogoID_Internalname, "ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCatalogoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A28CatalogoID), 6, 0, ".", "")), StringUtil.LTrim( ((edtCatalogoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A28CatalogoID), "ZZZZZ9") : context.localUtil.Format( (decimal)(A28CatalogoID), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCatalogoID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCatalogoID_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Catalogo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCatalogoDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCatalogoDescripcion_Internalname, "Descripcion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCatalogoDescripcion_Internalname, A29CatalogoDescripcion, StringUtil.RTrim( context.localUtil.Format( A29CatalogoDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCatalogoDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCatalogoDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Catalogo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgCatalogoImagen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Imagen", "col-sm-3 ImageLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Image";
         StyleString = "";
         A30CatalogoImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A30CatalogoImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000CatalogoImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A30CatalogoImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A30CatalogoImagen)) ? A40000CatalogoImagen_GXI : context.PathToRelativeUrl( A30CatalogoImagen));
         GxWebStd.gx_bitmap( context, imgCatalogoImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgCatalogoImagen_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", "", "", 0, A30CatalogoImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Catalogo.htm");
         AssignProp("", false, imgCatalogoImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A30CatalogoImagen)) ? A40000CatalogoImagen_GXI : context.PathToRelativeUrl( A30CatalogoImagen)), true);
         AssignProp("", false, imgCatalogoImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A30CatalogoImagen_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCatalogoFchInicio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCatalogoFchInicio_Internalname, "Fch Inicio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCatalogoFchInicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCatalogoFchInicio_Internalname, context.localUtil.Format(A31CatalogoFchInicio, "99/99/99"), context.localUtil.Format( A31CatalogoFchInicio, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCatalogoFchInicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCatalogoFchInicio_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Catalogo.htm");
         GxWebStd.gx_bitmap( context, edtCatalogoFchInicio_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCatalogoFchInicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Catalogo.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCatalogoFchFin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCatalogoFchFin_Internalname, "Fch Fin", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCatalogoFchFin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCatalogoFchFin_Internalname, context.localUtil.Format(A32CatalogoFchFin, "99/99/99"), context.localUtil.Format( A32CatalogoFchFin, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCatalogoFchFin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCatalogoFchFin_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Catalogo.htm");
         GxWebStd.gx_bitmap( context, edtCatalogoFchFin_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCatalogoFchFin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Catalogo.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Catalogo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Catalogo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Catalogo.htm");
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
         E11082 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z28CatalogoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z28CatalogoID"), ".", ","), 18, MidpointRounding.ToEven));
               Z29CatalogoDescripcion = cgiGet( "Z29CatalogoDescripcion");
               Z31CatalogoFchInicio = context.localUtil.CToD( cgiGet( "Z31CatalogoFchInicio"), 0);
               Z32CatalogoFchFin = context.localUtil.CToD( cgiGet( "Z32CatalogoFchFin"), 0);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7CatalogoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vCATALOGOID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               A40000CatalogoImagen_GXI = cgiGet( "CATALOGOIMAGEN_GXI");
               AV11Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A28CatalogoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCatalogoID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A28CatalogoID", StringUtil.LTrimStr( (decimal)(A28CatalogoID), 6, 0));
               A29CatalogoDescripcion = cgiGet( edtCatalogoDescripcion_Internalname);
               AssignAttri("", false, "A29CatalogoDescripcion", A29CatalogoDescripcion);
               A30CatalogoImagen = cgiGet( imgCatalogoImagen_Internalname);
               AssignAttri("", false, "A30CatalogoImagen", A30CatalogoImagen);
               if ( context.localUtil.VCDate( cgiGet( edtCatalogoFchInicio_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Catalogo Fch Inicio"}), 1, "CATALOGOFCHINICIO");
                  AnyError = 1;
                  GX_FocusControl = edtCatalogoFchInicio_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A31CatalogoFchInicio = DateTime.MinValue;
                  AssignAttri("", false, "A31CatalogoFchInicio", context.localUtil.Format(A31CatalogoFchInicio, "99/99/99"));
               }
               else
               {
                  A31CatalogoFchInicio = context.localUtil.CToD( cgiGet( edtCatalogoFchInicio_Internalname), 1);
                  AssignAttri("", false, "A31CatalogoFchInicio", context.localUtil.Format(A31CatalogoFchInicio, "99/99/99"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtCatalogoFchFin_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Catalogo Fch Fin"}), 1, "CATALOGOFCHFIN");
                  AnyError = 1;
                  GX_FocusControl = edtCatalogoFchFin_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A32CatalogoFchFin = DateTime.MinValue;
                  AssignAttri("", false, "A32CatalogoFchFin", context.localUtil.Format(A32CatalogoFchFin, "99/99/99"));
               }
               else
               {
                  A32CatalogoFchFin = context.localUtil.CToD( cgiGet( edtCatalogoFchFin_Internalname), 1);
                  AssignAttri("", false, "A32CatalogoFchFin", context.localUtil.Format(A32CatalogoFchFin, "99/99/99"));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgCatalogoImagen_Internalname, ref  A30CatalogoImagen, ref  A40000CatalogoImagen_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Catalogo");
               A28CatalogoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCatalogoID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A28CatalogoID", StringUtil.LTrimStr( (decimal)(A28CatalogoID), 6, 0));
               forbiddenHiddens.Add("CatalogoID", context.localUtil.Format( (decimal)(A28CatalogoID), "ZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A28CatalogoID != Z28CatalogoID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("catalogo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A28CatalogoID = (int)(Math.Round(NumberUtil.Val( GetPar( "CatalogoID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A28CatalogoID", StringUtil.LTrimStr( (decimal)(A28CatalogoID), 6, 0));
                  getEqualNoModal( ) ;
                  if ( ! (0==AV7CatalogoID) )
                  {
                     A28CatalogoID = AV7CatalogoID;
                     AssignAttri("", false, "A28CatalogoID", StringUtil.LTrimStr( (decimal)(A28CatalogoID), 6, 0));
                  }
                  else
                  {
                     if ( IsIns( )  && (0==A28CatalogoID) && ( Gx_BScreen == 0 ) )
                     {
                        A28CatalogoID = 1;
                        AssignAttri("", false, "A28CatalogoID", StringUtil.LTrimStr( (decimal)(A28CatalogoID), 6, 0));
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
                     sMode8 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (0==AV7CatalogoID) )
                     {
                        A28CatalogoID = AV7CatalogoID;
                        AssignAttri("", false, "A28CatalogoID", StringUtil.LTrimStr( (decimal)(A28CatalogoID), 6, 0));
                     }
                     else
                     {
                        if ( IsIns( )  && (0==A28CatalogoID) && ( Gx_BScreen == 0 ) )
                        {
                           A28CatalogoID = 1;
                           AssignAttri("", false, "A28CatalogoID", StringUtil.LTrimStr( (decimal)(A28CatalogoID), 6, 0));
                        }
                     }
                     Gx_mode = sMode8;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound8 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_080( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CATALOGOID");
                        AnyError = 1;
                        GX_FocusControl = edtCatalogoID_Internalname;
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
                           E11082 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12082 ();
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
            E12082 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll088( ) ;
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
            DisableAttributes088( ) ;
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

      protected void CONFIRM_080( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls088( ) ;
            }
            else
            {
               CheckExtendedTable088( ) ;
               CloseExtendedTableCursors088( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption080( )
      {
      }

      protected void E11082( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV11Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E12082( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwcatalogo.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM088( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z29CatalogoDescripcion = T00083_A29CatalogoDescripcion[0];
               Z31CatalogoFchInicio = T00083_A31CatalogoFchInicio[0];
               Z32CatalogoFchFin = T00083_A32CatalogoFchFin[0];
            }
            else
            {
               Z29CatalogoDescripcion = A29CatalogoDescripcion;
               Z31CatalogoFchInicio = A31CatalogoFchInicio;
               Z32CatalogoFchFin = A32CatalogoFchFin;
            }
         }
         if ( GX_JID == -6 )
         {
            Z28CatalogoID = A28CatalogoID;
            Z29CatalogoDescripcion = A29CatalogoDescripcion;
            Z30CatalogoImagen = A30CatalogoImagen;
            Z40000CatalogoImagen_GXI = A40000CatalogoImagen_GXI;
            Z31CatalogoFchInicio = A31CatalogoFchInicio;
            Z32CatalogoFchFin = A32CatalogoFchFin;
         }
      }

      protected void standaloneNotModal( )
      {
         edtCatalogoID_Enabled = 0;
         AssignProp("", false, edtCatalogoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCatalogoID_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtCatalogoID_Enabled = 0;
         AssignProp("", false, edtCatalogoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCatalogoID_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
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
         if ( ! (0==AV7CatalogoID) )
         {
            A28CatalogoID = AV7CatalogoID;
            AssignAttri("", false, "A28CatalogoID", StringUtil.LTrimStr( (decimal)(A28CatalogoID), 6, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A28CatalogoID) && ( Gx_BScreen == 0 ) )
            {
               A28CatalogoID = 1;
               AssignAttri("", false, "A28CatalogoID", StringUtil.LTrimStr( (decimal)(A28CatalogoID), 6, 0));
            }
         }
      }

      protected void Load088( )
      {
         /* Using cursor T00084 */
         pr_default.execute(2, new Object[] {A28CatalogoID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound8 = 1;
            A29CatalogoDescripcion = T00084_A29CatalogoDescripcion[0];
            AssignAttri("", false, "A29CatalogoDescripcion", A29CatalogoDescripcion);
            A40000CatalogoImagen_GXI = T00084_A40000CatalogoImagen_GXI[0];
            AssignProp("", false, imgCatalogoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A30CatalogoImagen)) ? A40000CatalogoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A30CatalogoImagen))), true);
            AssignProp("", false, imgCatalogoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A30CatalogoImagen), true);
            A31CatalogoFchInicio = T00084_A31CatalogoFchInicio[0];
            AssignAttri("", false, "A31CatalogoFchInicio", context.localUtil.Format(A31CatalogoFchInicio, "99/99/99"));
            A32CatalogoFchFin = T00084_A32CatalogoFchFin[0];
            AssignAttri("", false, "A32CatalogoFchFin", context.localUtil.Format(A32CatalogoFchFin, "99/99/99"));
            A30CatalogoImagen = T00084_A30CatalogoImagen[0];
            AssignAttri("", false, "A30CatalogoImagen", A30CatalogoImagen);
            AssignProp("", false, imgCatalogoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A30CatalogoImagen)) ? A40000CatalogoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A30CatalogoImagen))), true);
            AssignProp("", false, imgCatalogoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A30CatalogoImagen), true);
            ZM088( -6) ;
         }
         pr_default.close(2);
         OnLoadActions088( ) ;
      }

      protected void OnLoadActions088( )
      {
         AV11Pgmname = "Catalogo";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CheckExtendedTable088( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV11Pgmname = "Catalogo";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         if ( ! ( (DateTime.MinValue==A31CatalogoFchInicio) || ( DateTimeUtil.ResetTime ( A31CatalogoFchInicio ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Catalogo Fch Inicio is out of range", "OutOfRange", 1, "CATALOGOFCHINICIO");
            AnyError = 1;
            GX_FocusControl = edtCatalogoFchInicio_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( DateTimeUtil.ResetTime ( A31CatalogoFchInicio ) > DateTimeUtil.ResetTime ( A32CatalogoFchFin ) )
         {
            GX_msglist.addItem("Error, la fecha de inicio es mayor a la de Fin", 1, "CATALOGOFCHINICIO");
            AnyError = 1;
            GX_FocusControl = edtCatalogoFchInicio_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A32CatalogoFchFin) || ( DateTimeUtil.ResetTime ( A32CatalogoFchFin ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Catalogo Fch Fin is out of range", "OutOfRange", 1, "CATALOGOFCHFIN");
            AnyError = 1;
            GX_FocusControl = edtCatalogoFchFin_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors088( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey088( )
      {
         /* Using cursor T00085 */
         pr_default.execute(3, new Object[] {A28CatalogoID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00083 */
         pr_default.execute(1, new Object[] {A28CatalogoID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM088( 6) ;
            RcdFound8 = 1;
            A28CatalogoID = T00083_A28CatalogoID[0];
            AssignAttri("", false, "A28CatalogoID", StringUtil.LTrimStr( (decimal)(A28CatalogoID), 6, 0));
            A29CatalogoDescripcion = T00083_A29CatalogoDescripcion[0];
            AssignAttri("", false, "A29CatalogoDescripcion", A29CatalogoDescripcion);
            A40000CatalogoImagen_GXI = T00083_A40000CatalogoImagen_GXI[0];
            AssignProp("", false, imgCatalogoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A30CatalogoImagen)) ? A40000CatalogoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A30CatalogoImagen))), true);
            AssignProp("", false, imgCatalogoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A30CatalogoImagen), true);
            A31CatalogoFchInicio = T00083_A31CatalogoFchInicio[0];
            AssignAttri("", false, "A31CatalogoFchInicio", context.localUtil.Format(A31CatalogoFchInicio, "99/99/99"));
            A32CatalogoFchFin = T00083_A32CatalogoFchFin[0];
            AssignAttri("", false, "A32CatalogoFchFin", context.localUtil.Format(A32CatalogoFchFin, "99/99/99"));
            A30CatalogoImagen = T00083_A30CatalogoImagen[0];
            AssignAttri("", false, "A30CatalogoImagen", A30CatalogoImagen);
            AssignProp("", false, imgCatalogoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A30CatalogoImagen)) ? A40000CatalogoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A30CatalogoImagen))), true);
            AssignProp("", false, imgCatalogoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A30CatalogoImagen), true);
            Z28CatalogoID = A28CatalogoID;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load088( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey088( ) ;
            }
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey088( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey088( ) ;
         if ( RcdFound8 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound8 = 0;
         /* Using cursor T00086 */
         pr_default.execute(4, new Object[] {A28CatalogoID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00086_A28CatalogoID[0] < A28CatalogoID ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00086_A28CatalogoID[0] > A28CatalogoID ) ) )
            {
               A28CatalogoID = T00086_A28CatalogoID[0];
               AssignAttri("", false, "A28CatalogoID", StringUtil.LTrimStr( (decimal)(A28CatalogoID), 6, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound8 = 0;
         /* Using cursor T00087 */
         pr_default.execute(5, new Object[] {A28CatalogoID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00087_A28CatalogoID[0] > A28CatalogoID ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00087_A28CatalogoID[0] < A28CatalogoID ) ) )
            {
               A28CatalogoID = T00087_A28CatalogoID[0];
               AssignAttri("", false, "A28CatalogoID", StringUtil.LTrimStr( (decimal)(A28CatalogoID), 6, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey088( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCatalogoDescripcion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert088( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A28CatalogoID != Z28CatalogoID )
               {
                  A28CatalogoID = Z28CatalogoID;
                  AssignAttri("", false, "A28CatalogoID", StringUtil.LTrimStr( (decimal)(A28CatalogoID), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CATALOGOID");
                  AnyError = 1;
                  GX_FocusControl = edtCatalogoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCatalogoDescripcion_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update088( ) ;
                  GX_FocusControl = edtCatalogoDescripcion_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A28CatalogoID != Z28CatalogoID )
               {
                  /* Insert record */
                  GX_FocusControl = edtCatalogoDescripcion_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert088( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CATALOGOID");
                     AnyError = 1;
                     GX_FocusControl = edtCatalogoID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCatalogoDescripcion_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert088( ) ;
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
         if ( A28CatalogoID != Z28CatalogoID )
         {
            A28CatalogoID = Z28CatalogoID;
            AssignAttri("", false, "A28CatalogoID", StringUtil.LTrimStr( (decimal)(A28CatalogoID), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CATALOGOID");
            AnyError = 1;
            GX_FocusControl = edtCatalogoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCatalogoDescripcion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency088( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00082 */
            pr_default.execute(0, new Object[] {A28CatalogoID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Catalogo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z29CatalogoDescripcion, T00082_A29CatalogoDescripcion[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z31CatalogoFchInicio ) != DateTimeUtil.ResetTime ( T00082_A31CatalogoFchInicio[0] ) ) || ( DateTimeUtil.ResetTime ( Z32CatalogoFchFin ) != DateTimeUtil.ResetTime ( T00082_A32CatalogoFchFin[0] ) ) )
            {
               if ( StringUtil.StrCmp(Z29CatalogoDescripcion, T00082_A29CatalogoDescripcion[0]) != 0 )
               {
                  GXUtil.WriteLog("catalogo:[seudo value changed for attri]"+"CatalogoDescripcion");
                  GXUtil.WriteLogRaw("Old: ",Z29CatalogoDescripcion);
                  GXUtil.WriteLogRaw("Current: ",T00082_A29CatalogoDescripcion[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z31CatalogoFchInicio ) != DateTimeUtil.ResetTime ( T00082_A31CatalogoFchInicio[0] ) )
               {
                  GXUtil.WriteLog("catalogo:[seudo value changed for attri]"+"CatalogoFchInicio");
                  GXUtil.WriteLogRaw("Old: ",Z31CatalogoFchInicio);
                  GXUtil.WriteLogRaw("Current: ",T00082_A31CatalogoFchInicio[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z32CatalogoFchFin ) != DateTimeUtil.ResetTime ( T00082_A32CatalogoFchFin[0] ) )
               {
                  GXUtil.WriteLog("catalogo:[seudo value changed for attri]"+"CatalogoFchFin");
                  GXUtil.WriteLogRaw("Old: ",Z32CatalogoFchFin);
                  GXUtil.WriteLogRaw("Current: ",T00082_A32CatalogoFchFin[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Catalogo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert088( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM088( 0) ;
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00088 */
                     pr_default.execute(6, new Object[] {A29CatalogoDescripcion, A30CatalogoImagen, A40000CatalogoImagen_GXI, A31CatalogoFchInicio, A32CatalogoFchFin});
                     A28CatalogoID = T00088_A28CatalogoID[0];
                     AssignAttri("", false, "A28CatalogoID", StringUtil.LTrimStr( (decimal)(A28CatalogoID), 6, 0));
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Catalogo");
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
               Load088( ) ;
            }
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void Update088( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00089 */
                     pr_default.execute(7, new Object[] {A29CatalogoDescripcion, A31CatalogoFchInicio, A32CatalogoFchFin, A28CatalogoID});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Catalogo");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Catalogo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate088( ) ;
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
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void DeferredUpdate088( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000810 */
            pr_default.execute(8, new Object[] {A30CatalogoImagen, A40000CatalogoImagen_GXI, A28CatalogoID});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("Catalogo");
         }
      }

      protected void delete( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls088( ) ;
            AfterConfirm088( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete088( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000811 */
                  pr_default.execute(9, new Object[] {A28CatalogoID});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Catalogo");
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel088( ) ;
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls088( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV11Pgmname = "Catalogo";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         }
      }

      protected void EndLevel088( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete088( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("catalogo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues080( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("catalogo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart088( )
      {
         /* Scan By routine */
         /* Using cursor T000812 */
         pr_default.execute(10);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound8 = 1;
            A28CatalogoID = T000812_A28CatalogoID[0];
            AssignAttri("", false, "A28CatalogoID", StringUtil.LTrimStr( (decimal)(A28CatalogoID), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext088( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound8 = 1;
            A28CatalogoID = T000812_A28CatalogoID[0];
            AssignAttri("", false, "A28CatalogoID", StringUtil.LTrimStr( (decimal)(A28CatalogoID), 6, 0));
         }
      }

      protected void ScanEnd088( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm088( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert088( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate088( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete088( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete088( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate088( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes088( )
      {
         edtCatalogoID_Enabled = 0;
         AssignProp("", false, edtCatalogoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCatalogoID_Enabled), 5, 0), true);
         edtCatalogoDescripcion_Enabled = 0;
         AssignProp("", false, edtCatalogoDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCatalogoDescripcion_Enabled), 5, 0), true);
         imgCatalogoImagen_Enabled = 0;
         AssignProp("", false, imgCatalogoImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgCatalogoImagen_Enabled), 5, 0), true);
         edtCatalogoFchInicio_Enabled = 0;
         AssignProp("", false, edtCatalogoFchInicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCatalogoFchInicio_Enabled), 5, 0), true);
         edtCatalogoFchFin_Enabled = 0;
         AssignProp("", false, edtCatalogoFchFin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCatalogoFchFin_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes088( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues080( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("catalogo.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7CatalogoID,6,0))}, new string[] {"Gx_mode","CatalogoID"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Catalogo");
         forbiddenHiddens.Add("CatalogoID", context.localUtil.Format( (decimal)(A28CatalogoID), "ZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("catalogo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z28CatalogoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z28CatalogoID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z29CatalogoDescripcion", Z29CatalogoDescripcion);
         GxWebStd.gx_hidden_field( context, "Z31CatalogoFchInicio", context.localUtil.DToC( Z31CatalogoFchInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z32CatalogoFchFin", context.localUtil.DToC( Z32CatalogoFchFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vCATALOGOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CatalogoID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCATALOGOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CatalogoID), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CATALOGOIMAGEN_GXI", A40000CatalogoImagen_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV11Pgmname));
         GXCCtlgxBlob = "CATALOGOIMAGEN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A30CatalogoImagen);
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
         return formatLink("catalogo.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7CatalogoID,6,0))}, new string[] {"Gx_mode","CatalogoID"})  ;
      }

      public override string GetPgmname( )
      {
         return "Catalogo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Catalogo" ;
      }

      protected void InitializeNonKey088( )
      {
         A29CatalogoDescripcion = "";
         AssignAttri("", false, "A29CatalogoDescripcion", A29CatalogoDescripcion);
         A30CatalogoImagen = "";
         AssignAttri("", false, "A30CatalogoImagen", A30CatalogoImagen);
         AssignProp("", false, imgCatalogoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A30CatalogoImagen)) ? A40000CatalogoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A30CatalogoImagen))), true);
         AssignProp("", false, imgCatalogoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A30CatalogoImagen), true);
         A40000CatalogoImagen_GXI = "";
         AssignProp("", false, imgCatalogoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A30CatalogoImagen)) ? A40000CatalogoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A30CatalogoImagen))), true);
         AssignProp("", false, imgCatalogoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A30CatalogoImagen), true);
         A31CatalogoFchInicio = DateTime.MinValue;
         AssignAttri("", false, "A31CatalogoFchInicio", context.localUtil.Format(A31CatalogoFchInicio, "99/99/99"));
         A32CatalogoFchFin = DateTime.MinValue;
         AssignAttri("", false, "A32CatalogoFchFin", context.localUtil.Format(A32CatalogoFchFin, "99/99/99"));
         Z29CatalogoDescripcion = "";
         Z31CatalogoFchInicio = DateTime.MinValue;
         Z32CatalogoFchFin = DateTime.MinValue;
      }

      protected void InitAll088( )
      {
         A28CatalogoID = 1;
         AssignAttri("", false, "A28CatalogoID", StringUtil.LTrimStr( (decimal)(A28CatalogoID), 6, 0));
         InitializeNonKey088( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202552012395", true, true);
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
         context.AddJavascriptSource("catalogo.js", "?202552012395", false, true);
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
         edtCatalogoID_Internalname = "CATALOGOID";
         edtCatalogoDescripcion_Internalname = "CATALOGODESCRIPCION";
         imgCatalogoImagen_Internalname = "CATALOGOIMAGEN";
         edtCatalogoFchInicio_Internalname = "CATALOGOFCHINICIO";
         edtCatalogoFchFin_Internalname = "CATALOGOFCHFIN";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
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
         Form.Caption = "Catalogo";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCatalogoFchFin_Jsonclick = "";
         edtCatalogoFchFin_Enabled = 1;
         edtCatalogoFchInicio_Jsonclick = "";
         edtCatalogoFchInicio_Enabled = 1;
         imgCatalogoImagen_Enabled = 1;
         edtCatalogoDescripcion_Jsonclick = "";
         edtCatalogoDescripcion_Enabled = 1;
         edtCatalogoID_Jsonclick = "";
         edtCatalogoID_Enabled = 0;
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7CatalogoID","fld":"vCATALOGOID","pic":"ZZZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7CatalogoID","fld":"vCATALOGOID","pic":"ZZZZZ9","hsh":true},{"av":"A28CatalogoID","fld":"CATALOGOID","pic":"ZZZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12082","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_CATALOGOID","""{"handler":"Valid_Catalogoid","iparms":[]}""");
         setEventMetadata("VALID_CATALOGOFCHINICIO","""{"handler":"Valid_Catalogofchinicio","iparms":[]}""");
         setEventMetadata("VALID_CATALOGOFCHFIN","""{"handler":"Valid_Catalogofchfin","iparms":[]}""");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z29CatalogoDescripcion = "";
         Z31CatalogoFchInicio = DateTime.MinValue;
         Z32CatalogoFchFin = DateTime.MinValue;
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
         A29CatalogoDescripcion = "";
         A30CatalogoImagen = "";
         A40000CatalogoImagen_GXI = "";
         sImgUrl = "";
         A31CatalogoFchInicio = DateTime.MinValue;
         A32CatalogoFchFin = DateTime.MinValue;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV11Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode8 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z30CatalogoImagen = "";
         Z40000CatalogoImagen_GXI = "";
         T00084_A28CatalogoID = new int[1] ;
         T00084_A29CatalogoDescripcion = new string[] {""} ;
         T00084_A40000CatalogoImagen_GXI = new string[] {""} ;
         T00084_A31CatalogoFchInicio = new DateTime[] {DateTime.MinValue} ;
         T00084_A32CatalogoFchFin = new DateTime[] {DateTime.MinValue} ;
         T00084_A30CatalogoImagen = new string[] {""} ;
         T00085_A28CatalogoID = new int[1] ;
         T00083_A28CatalogoID = new int[1] ;
         T00083_A29CatalogoDescripcion = new string[] {""} ;
         T00083_A40000CatalogoImagen_GXI = new string[] {""} ;
         T00083_A31CatalogoFchInicio = new DateTime[] {DateTime.MinValue} ;
         T00083_A32CatalogoFchFin = new DateTime[] {DateTime.MinValue} ;
         T00083_A30CatalogoImagen = new string[] {""} ;
         T00086_A28CatalogoID = new int[1] ;
         T00087_A28CatalogoID = new int[1] ;
         T00082_A28CatalogoID = new int[1] ;
         T00082_A29CatalogoDescripcion = new string[] {""} ;
         T00082_A40000CatalogoImagen_GXI = new string[] {""} ;
         T00082_A31CatalogoFchInicio = new DateTime[] {DateTime.MinValue} ;
         T00082_A32CatalogoFchFin = new DateTime[] {DateTime.MinValue} ;
         T00082_A30CatalogoImagen = new string[] {""} ;
         T00088_A28CatalogoID = new int[1] ;
         T000812_A28CatalogoID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.catalogo__default(),
            new Object[][] {
                new Object[] {
               T00082_A28CatalogoID, T00082_A29CatalogoDescripcion, T00082_A40000CatalogoImagen_GXI, T00082_A31CatalogoFchInicio, T00082_A32CatalogoFchFin, T00082_A30CatalogoImagen
               }
               , new Object[] {
               T00083_A28CatalogoID, T00083_A29CatalogoDescripcion, T00083_A40000CatalogoImagen_GXI, T00083_A31CatalogoFchInicio, T00083_A32CatalogoFchFin, T00083_A30CatalogoImagen
               }
               , new Object[] {
               T00084_A28CatalogoID, T00084_A29CatalogoDescripcion, T00084_A40000CatalogoImagen_GXI, T00084_A31CatalogoFchInicio, T00084_A32CatalogoFchFin, T00084_A30CatalogoImagen
               }
               , new Object[] {
               T00085_A28CatalogoID
               }
               , new Object[] {
               T00086_A28CatalogoID
               }
               , new Object[] {
               T00087_A28CatalogoID
               }
               , new Object[] {
               T00088_A28CatalogoID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000812_A28CatalogoID
               }
            }
         );
         Z28CatalogoID = 1;
         A28CatalogoID = 1;
         AV11Pgmname = "Catalogo";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound8 ;
      private short gxajaxcallmode ;
      private int wcpOAV7CatalogoID ;
      private int Z28CatalogoID ;
      private int AV7CatalogoID ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A28CatalogoID ;
      private int edtCatalogoID_Enabled ;
      private int edtCatalogoDescripcion_Enabled ;
      private int imgCatalogoImagen_Enabled ;
      private int edtCatalogoFchInicio_Enabled ;
      private int edtCatalogoFchFin_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
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
      private string edtCatalogoDescripcion_Internalname ;
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
      private string edtCatalogoID_Internalname ;
      private string edtCatalogoID_Jsonclick ;
      private string edtCatalogoDescripcion_Jsonclick ;
      private string imgCatalogoImagen_Internalname ;
      private string sImgUrl ;
      private string edtCatalogoFchInicio_Internalname ;
      private string edtCatalogoFchInicio_Jsonclick ;
      private string edtCatalogoFchFin_Internalname ;
      private string edtCatalogoFchFin_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV11Pgmname ;
      private string hsh ;
      private string sMode8 ;
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
      private DateTime Z31CatalogoFchInicio ;
      private DateTime Z32CatalogoFchFin ;
      private DateTime A31CatalogoFchInicio ;
      private DateTime A32CatalogoFchFin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A30CatalogoImagen_IsBlob ;
      private bool returnInSub ;
      private string Z29CatalogoDescripcion ;
      private string A29CatalogoDescripcion ;
      private string A40000CatalogoImagen_GXI ;
      private string Z40000CatalogoImagen_GXI ;
      private string A30CatalogoImagen ;
      private string Z30CatalogoImagen ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] T00084_A28CatalogoID ;
      private string[] T00084_A29CatalogoDescripcion ;
      private string[] T00084_A40000CatalogoImagen_GXI ;
      private DateTime[] T00084_A31CatalogoFchInicio ;
      private DateTime[] T00084_A32CatalogoFchFin ;
      private string[] T00084_A30CatalogoImagen ;
      private int[] T00085_A28CatalogoID ;
      private int[] T00083_A28CatalogoID ;
      private string[] T00083_A29CatalogoDescripcion ;
      private string[] T00083_A40000CatalogoImagen_GXI ;
      private DateTime[] T00083_A31CatalogoFchInicio ;
      private DateTime[] T00083_A32CatalogoFchFin ;
      private string[] T00083_A30CatalogoImagen ;
      private int[] T00086_A28CatalogoID ;
      private int[] T00087_A28CatalogoID ;
      private int[] T00082_A28CatalogoID ;
      private string[] T00082_A29CatalogoDescripcion ;
      private string[] T00082_A40000CatalogoImagen_GXI ;
      private DateTime[] T00082_A31CatalogoFchInicio ;
      private DateTime[] T00082_A32CatalogoFchFin ;
      private string[] T00082_A30CatalogoImagen ;
      private int[] T00088_A28CatalogoID ;
      private int[] T000812_A28CatalogoID ;
   }

   public class catalogo__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00082;
          prmT00082 = new Object[] {
          new ParDef("@CatalogoID",GXType.Int32,6,0)
          };
          Object[] prmT00083;
          prmT00083 = new Object[] {
          new ParDef("@CatalogoID",GXType.Int32,6,0)
          };
          Object[] prmT00084;
          prmT00084 = new Object[] {
          new ParDef("@CatalogoID",GXType.Int32,6,0)
          };
          Object[] prmT00085;
          prmT00085 = new Object[] {
          new ParDef("@CatalogoID",GXType.Int32,6,0)
          };
          Object[] prmT00086;
          prmT00086 = new Object[] {
          new ParDef("@CatalogoID",GXType.Int32,6,0)
          };
          Object[] prmT00087;
          prmT00087 = new Object[] {
          new ParDef("@CatalogoID",GXType.Int32,6,0)
          };
          Object[] prmT00088;
          prmT00088 = new Object[] {
          new ParDef("@CatalogoDescripcion",GXType.NVarChar,80,0) ,
          new ParDef("@CatalogoImagen",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@CatalogoImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="Catalogo", Fld="CatalogoImagen"} ,
          new ParDef("@CatalogoFchInicio",GXType.Date,8,0) ,
          new ParDef("@CatalogoFchFin",GXType.Date,8,0)
          };
          Object[] prmT00089;
          prmT00089 = new Object[] {
          new ParDef("@CatalogoDescripcion",GXType.NVarChar,80,0) ,
          new ParDef("@CatalogoFchInicio",GXType.Date,8,0) ,
          new ParDef("@CatalogoFchFin",GXType.Date,8,0) ,
          new ParDef("@CatalogoID",GXType.Int32,6,0)
          };
          Object[] prmT000810;
          prmT000810 = new Object[] {
          new ParDef("@CatalogoImagen",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@CatalogoImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Catalogo", Fld="CatalogoImagen"} ,
          new ParDef("@CatalogoID",GXType.Int32,6,0)
          };
          Object[] prmT000811;
          prmT000811 = new Object[] {
          new ParDef("@CatalogoID",GXType.Int32,6,0)
          };
          Object[] prmT000812;
          prmT000812 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00082", "SELECT [CatalogoID], [CatalogoDescripcion], [CatalogoImagen_GXI], [CatalogoFchInicio], [CatalogoFchFin], [CatalogoImagen] FROM [Catalogo] WITH (UPDLOCK) WHERE [CatalogoID] = @CatalogoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00082,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00083", "SELECT [CatalogoID], [CatalogoDescripcion], [CatalogoImagen_GXI], [CatalogoFchInicio], [CatalogoFchFin], [CatalogoImagen] FROM [Catalogo] WHERE [CatalogoID] = @CatalogoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00083,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00084", "SELECT TM1.[CatalogoID], TM1.[CatalogoDescripcion], TM1.[CatalogoImagen_GXI], TM1.[CatalogoFchInicio], TM1.[CatalogoFchFin], TM1.[CatalogoImagen] FROM [Catalogo] TM1 WHERE TM1.[CatalogoID] = @CatalogoID ORDER BY TM1.[CatalogoID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00084,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00085", "SELECT [CatalogoID] FROM [Catalogo] WHERE [CatalogoID] = @CatalogoID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00085,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00086", "SELECT TOP 1 [CatalogoID] FROM [Catalogo] WHERE ( [CatalogoID] > @CatalogoID) ORDER BY [CatalogoID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00086,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00087", "SELECT TOP 1 [CatalogoID] FROM [Catalogo] WHERE ( [CatalogoID] < @CatalogoID) ORDER BY [CatalogoID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00087,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00088", "INSERT INTO [Catalogo]([CatalogoDescripcion], [CatalogoImagen], [CatalogoImagen_GXI], [CatalogoFchInicio], [CatalogoFchFin]) VALUES(@CatalogoDescripcion, @CatalogoImagen, @CatalogoImagen_GXI, @CatalogoFchInicio, @CatalogoFchFin); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT00088,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00089", "UPDATE [Catalogo] SET [CatalogoDescripcion]=@CatalogoDescripcion, [CatalogoFchInicio]=@CatalogoFchInicio, [CatalogoFchFin]=@CatalogoFchFin  WHERE [CatalogoID] = @CatalogoID", GxErrorMask.GX_NOMASK,prmT00089)
             ,new CursorDef("T000810", "UPDATE [Catalogo] SET [CatalogoImagen]=@CatalogoImagen, [CatalogoImagen_GXI]=@CatalogoImagen_GXI  WHERE [CatalogoID] = @CatalogoID", GxErrorMask.GX_NOMASK,prmT000810)
             ,new CursorDef("T000811", "DELETE FROM [Catalogo]  WHERE [CatalogoID] = @CatalogoID", GxErrorMask.GX_NOMASK,prmT000811)
             ,new CursorDef("T000812", "SELECT [CatalogoID] FROM [Catalogo] ORDER BY [CatalogoID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000812,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
