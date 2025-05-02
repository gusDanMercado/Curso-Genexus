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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class productogeneral : GXWebComponent
   {
      public productogeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("miTienda", true);
         }
      }

      public productogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ProductoID )
      {
         this.A19ProductoID = aP0_ProductoID;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ProductoID");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  A19ProductoID = (int)(Math.Round(NumberUtil.Val( GetPar( "ProductoID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A19ProductoID", StringUtil.LTrimStr( (decimal)(A19ProductoID), 6, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)A19ProductoID});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "ProductoID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ProductoID");
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
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA0X2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV11Pgmname = "ProductoGeneral";
               WS0X2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Producto General") ;
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
         }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
            {
               context.WriteHtmlText( " dir=\"rtl\" ") ;
            }
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("productogeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A19ProductoID,6,0))}, new string[] {"ProductoID"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"ProductoGeneral");
         forbiddenHiddens.Add("VendedorID", context.localUtil.Format( (decimal)(A6VendedorID), "ZZZZZ9"));
         forbiddenHiddens.Add("CategoriaID", context.localUtil.Format( (decimal)(A4CategoriaID), "ZZZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("productogeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA19ProductoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA19ProductoID), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm0X2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "ProductoGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Producto General" ;
      }

      protected void WB0X0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "productogeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ww__view__actions-cell", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ww__view__actions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Update", bttBtnupdate_Jsonclick, 7, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e110x1_client"+"'", TempTags, "", 2, "HLP_ProductoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Delete", bttBtndelete_Jsonclick, 7, "Delete", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e120x1_client"+"'", TempTags, "", 2, "HLP_ProductoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributestable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductoID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProductoID_Internalname, "ID", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProductoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProductoID), 6, 0, ".", "")), StringUtil.LTrim( ((edtProductoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A19ProductoID), "ZZZZZ9") : context.localUtil.Format( (decimal)(A19ProductoID), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,18);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductoID_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductoID_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_ProductoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtProductoNombre_Internalname, "Nombre", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProductoNombre_Internalname, A20ProductoNombre, StringUtil.RTrim( context.localUtil.Format( A20ProductoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductoNombre_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductoNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_ProductoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtProductoDescripcion_Internalname, "Descripcion", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProductoDescripcion_Internalname, A21ProductoDescripcion, StringUtil.RTrim( context.localUtil.Format( A21ProductoDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductoDescripcion_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductoDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_ProductoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtProductoPrecio_Internalname, "Precio", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProductoPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( A22ProductoPrecio, 10, 2, ".", "")), StringUtil.LTrim( ((edtProductoPrecio_Enabled!=0) ? context.localUtil.Format( A22ProductoPrecio, "ZZZZZZ9.99") : context.localUtil.Format( A22ProductoPrecio, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,33);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductoPrecio_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductoPrecio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_ProductoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtVendedorID_Internalname, "Vendedor ID", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtVendedorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A6VendedorID), 6, 0, ".", "")), StringUtil.LTrim( ((edtVendedorID_Enabled!=0) ? context.localUtil.Format( (decimal)(A6VendedorID), "ZZZZZ9") : context.localUtil.Format( (decimal)(A6VendedorID), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVendedorID_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtVendedorID_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_ProductoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtVendedorNombre_Internalname, "Vendedor Nombre", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtVendedorNombre_Internalname, A7VendedorNombre, StringUtil.RTrim( context.localUtil.Format( A7VendedorNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtVendedorNombre_Link, "", "", "", edtVendedorNombre_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtVendedorNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_ProductoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtCategoriaID_Internalname, "Categoria ID", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtCategoriaID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CategoriaID), 6, 0, ".", "")), StringUtil.LTrim( ((edtCategoriaID_Enabled!=0) ? context.localUtil.Format( (decimal)(A4CategoriaID), "ZZZZZ9") : context.localUtil.Format( (decimal)(A4CategoriaID), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,48);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoriaID_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCategoriaID_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_ProductoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtCategoriaNombre_Internalname, "Categoria Nombre", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtCategoriaNombre_Internalname, A5CategoriaNombre, StringUtil.RTrim( context.localUtil.Format( A5CategoriaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtCategoriaNombre_Link, "", "", "", edtCategoriaNombre_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCategoriaNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_ProductoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtProductoPaisID_Internalname, "Pais ID", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProductoPaisID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A26ProductoPaisID), 6, 0, ".", "")), StringUtil.LTrim( ((edtProductoPaisID_Enabled!=0) ? context.localUtil.Format( (decimal)(A26ProductoPaisID), "ZZZZZ9") : context.localUtil.Format( (decimal)(A26ProductoPaisID), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,58);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductoPaisID_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductoPaisID_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_ProductoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtProductoPaisNombre_Internalname, "Pais Nombre", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProductoPaisNombre_Internalname, A27ProductoPaisNombre, StringUtil.RTrim( context.localUtil.Format( A27ProductoPaisNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductoPaisNombre_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductoPaisNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_ProductoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divImagestable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Imagen", "col-sm-3 ReadonlyAttributeLabel ReadonlyResponsiveImageAttributeLabel", 0, true, "");
            /* Static Bitmap Variable */
            ClassString = "ReadonlyAttribute ReadonlyResponsiveImageAttribute";
            StyleString = "";
            A23ProductoImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A23ProductoImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProductoImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A23ProductoImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductoImagen)) ? A40000ProductoImagen_GXI : context.PathToRelativeUrl( A23ProductoImagen));
            GxWebStd.gx_bitmap( context, imgProductoImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A23ProductoImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_ProductoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0X2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
               }
            }
            Form.Meta.addItem("description", "Producto General", 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP0X0( ) ;
            }
         }
      }

      protected void WS0X2( )
      {
         START0X2( ) ;
         EVT0X2( ) ;
      }

      protected void EVT0X2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E130X2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E140X2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
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
      }

      protected void WE0X2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0X2( ) ;
            }
         }
      }

      protected void PA0X2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV11Pgmname = "ProductoGeneral";
      }

      protected void RF0X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H000X2 */
            pr_default.execute(0, new Object[] {A19ProductoID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A40000ProductoImagen_GXI = H000X2_A40000ProductoImagen_GXI[0];
               AssignProp(sPrefix, false, imgProductoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductoImagen)) ? A40000ProductoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A23ProductoImagen))), true);
               AssignProp(sPrefix, false, imgProductoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A23ProductoImagen), true);
               A27ProductoPaisNombre = H000X2_A27ProductoPaisNombre[0];
               AssignAttri(sPrefix, false, "A27ProductoPaisNombre", A27ProductoPaisNombre);
               A26ProductoPaisID = H000X2_A26ProductoPaisID[0];
               AssignAttri(sPrefix, false, "A26ProductoPaisID", StringUtil.LTrimStr( (decimal)(A26ProductoPaisID), 6, 0));
               A5CategoriaNombre = H000X2_A5CategoriaNombre[0];
               AssignAttri(sPrefix, false, "A5CategoriaNombre", A5CategoriaNombre);
               A4CategoriaID = H000X2_A4CategoriaID[0];
               AssignAttri(sPrefix, false, "A4CategoriaID", StringUtil.LTrimStr( (decimal)(A4CategoriaID), 6, 0));
               A7VendedorNombre = H000X2_A7VendedorNombre[0];
               AssignAttri(sPrefix, false, "A7VendedorNombre", A7VendedorNombre);
               A6VendedorID = H000X2_A6VendedorID[0];
               AssignAttri(sPrefix, false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
               A22ProductoPrecio = H000X2_A22ProductoPrecio[0];
               AssignAttri(sPrefix, false, "A22ProductoPrecio", StringUtil.LTrimStr( A22ProductoPrecio, 10, 2));
               A21ProductoDescripcion = H000X2_A21ProductoDescripcion[0];
               AssignAttri(sPrefix, false, "A21ProductoDescripcion", A21ProductoDescripcion);
               A20ProductoNombre = H000X2_A20ProductoNombre[0];
               AssignAttri(sPrefix, false, "A20ProductoNombre", A20ProductoNombre);
               A23ProductoImagen = H000X2_A23ProductoImagen[0];
               AssignAttri(sPrefix, false, "A23ProductoImagen", A23ProductoImagen);
               AssignProp(sPrefix, false, imgProductoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductoImagen)) ? A40000ProductoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A23ProductoImagen))), true);
               AssignProp(sPrefix, false, imgProductoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A23ProductoImagen), true);
               A27ProductoPaisNombre = H000X2_A27ProductoPaisNombre[0];
               AssignAttri(sPrefix, false, "A27ProductoPaisNombre", A27ProductoPaisNombre);
               A5CategoriaNombre = H000X2_A5CategoriaNombre[0];
               AssignAttri(sPrefix, false, "A5CategoriaNombre", A5CategoriaNombre);
               A7VendedorNombre = H000X2_A7VendedorNombre[0];
               AssignAttri(sPrefix, false, "A7VendedorNombre", A7VendedorNombre);
               /* Execute user event: Load */
               E140X2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB0X0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0X2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV11Pgmname = "ProductoGeneral";
         edtProductoID_Enabled = 0;
         AssignProp(sPrefix, false, edtProductoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoID_Enabled), 5, 0), true);
         edtProductoNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtProductoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoNombre_Enabled), 5, 0), true);
         edtProductoDescripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtProductoDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoDescripcion_Enabled), 5, 0), true);
         edtProductoPrecio_Enabled = 0;
         AssignProp(sPrefix, false, edtProductoPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoPrecio_Enabled), 5, 0), true);
         edtVendedorID_Enabled = 0;
         AssignProp(sPrefix, false, edtVendedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVendedorID_Enabled), 5, 0), true);
         edtVendedorNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtVendedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVendedorNombre_Enabled), 5, 0), true);
         edtCategoriaID_Enabled = 0;
         AssignProp(sPrefix, false, edtCategoriaID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaID_Enabled), 5, 0), true);
         edtCategoriaNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtCategoriaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaNombre_Enabled), 5, 0), true);
         edtProductoPaisID_Enabled = 0;
         AssignProp(sPrefix, false, edtProductoPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoPaisID_Enabled), 5, 0), true);
         edtProductoPaisNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtProductoPaisNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductoPaisNombre_Enabled), 5, 0), true);
         imgProductoImagen_Enabled = 0;
         AssignProp(sPrefix, false, imgProductoImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProductoImagen_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E130X2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA19ProductoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA19ProductoID"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A20ProductoNombre = cgiGet( edtProductoNombre_Internalname);
            AssignAttri(sPrefix, false, "A20ProductoNombre", A20ProductoNombre);
            A21ProductoDescripcion = cgiGet( edtProductoDescripcion_Internalname);
            AssignAttri(sPrefix, false, "A21ProductoDescripcion", A21ProductoDescripcion);
            A22ProductoPrecio = context.localUtil.CToN( cgiGet( edtProductoPrecio_Internalname), ".", ",");
            AssignAttri(sPrefix, false, "A22ProductoPrecio", StringUtil.LTrimStr( A22ProductoPrecio, 10, 2));
            A6VendedorID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtVendedorID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
            A7VendedorNombre = cgiGet( edtVendedorNombre_Internalname);
            AssignAttri(sPrefix, false, "A7VendedorNombre", A7VendedorNombre);
            A4CategoriaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCategoriaID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A4CategoriaID", StringUtil.LTrimStr( (decimal)(A4CategoriaID), 6, 0));
            A5CategoriaNombre = cgiGet( edtCategoriaNombre_Internalname);
            AssignAttri(sPrefix, false, "A5CategoriaNombre", A5CategoriaNombre);
            A26ProductoPaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductoPaisID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A26ProductoPaisID", StringUtil.LTrimStr( (decimal)(A26ProductoPaisID), 6, 0));
            A27ProductoPaisNombre = cgiGet( edtProductoPaisNombre_Internalname);
            AssignAttri(sPrefix, false, "A27ProductoPaisNombre", A27ProductoPaisNombre);
            A23ProductoImagen = cgiGet( imgProductoImagen_Internalname);
            AssignAttri(sPrefix, false, "A23ProductoImagen", A23ProductoImagen);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"ProductoGeneral");
            A6VendedorID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtVendedorID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A6VendedorID", StringUtil.LTrimStr( (decimal)(A6VendedorID), 6, 0));
            forbiddenHiddens.Add("VendedorID", context.localUtil.Format( (decimal)(A6VendedorID), "ZZZZZ9"));
            A4CategoriaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCategoriaID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A4CategoriaID", StringUtil.LTrimStr( (decimal)(A4CategoriaID), 6, 0));
            forbiddenHiddens.Add("CategoriaID", context.localUtil.Format( (decimal)(A4CategoriaID), "ZZZZZ9"));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("productogeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E130X2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E130X2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV11Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E140X2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtVendedorNombre_Link = formatLink("viewvendedor.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A6VendedorID,6,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"VendedorID","TabCode"}) ;
         AssignProp(sPrefix, false, edtVendedorNombre_Internalname, "Link", edtVendedorNombre_Link, true);
         edtCategoriaNombre_Link = formatLink("viewcategoria.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A4CategoriaID,6,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"CategoriaID","TabCode"}) ;
         AssignProp(sPrefix, false, edtCategoriaNombre_Internalname, "Link", edtCategoriaNombre_Link, true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV11Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = false;
         AV7TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "Producto";
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "ProductoID";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6ProductoID), 6, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A19ProductoID = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "A19ProductoID", StringUtil.LTrimStr( (decimal)(A19ProductoID), 6, 0));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0X2( ) ;
         WS0X2( ) ;
         WE0X2( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlA19ProductoID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0X2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "productogeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0X2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A19ProductoID = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "A19ProductoID", StringUtil.LTrimStr( (decimal)(A19ProductoID), 6, 0));
         }
         wcpOA19ProductoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA19ProductoID"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A19ProductoID != wcpOA19ProductoID ) ) )
         {
            setjustcreated();
         }
         wcpOA19ProductoID = A19ProductoID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA19ProductoID = cgiGet( sPrefix+"A19ProductoID_CTRL");
         if ( StringUtil.Len( sCtrlA19ProductoID) > 0 )
         {
            A19ProductoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA19ProductoID), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A19ProductoID", StringUtil.LTrimStr( (decimal)(A19ProductoID), 6, 0));
         }
         else
         {
            A19ProductoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A19ProductoID_PARM"), ".", ","), 18, MidpointRounding.ToEven));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA0X2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS0X2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A19ProductoID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProductoID), 6, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA19ProductoID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A19ProductoID_CTRL", StringUtil.RTrim( sCtrlA19ProductoID));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE0X2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202552012372", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("productogeneral.js", "?202552012372", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         edtProductoID_Internalname = sPrefix+"PRODUCTOID";
         edtProductoNombre_Internalname = sPrefix+"PRODUCTONOMBRE";
         edtProductoDescripcion_Internalname = sPrefix+"PRODUCTODESCRIPCION";
         edtProductoPrecio_Internalname = sPrefix+"PRODUCTOPRECIO";
         edtVendedorID_Internalname = sPrefix+"VENDEDORID";
         edtVendedorNombre_Internalname = sPrefix+"VENDEDORNOMBRE";
         edtCategoriaID_Internalname = sPrefix+"CATEGORIAID";
         edtCategoriaNombre_Internalname = sPrefix+"CATEGORIANOMBRE";
         edtProductoPaisID_Internalname = sPrefix+"PRODUCTOPAISID";
         edtProductoPaisNombre_Internalname = sPrefix+"PRODUCTOPAISNOMBRE";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
         imgProductoImagen_Internalname = sPrefix+"PRODUCTOIMAGEN";
         divImagestable_Internalname = sPrefix+"IMAGESTABLE";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("miTienda", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         imgProductoImagen_Enabled = 0;
         edtProductoPaisNombre_Jsonclick = "";
         edtProductoPaisNombre_Enabled = 0;
         edtProductoPaisID_Jsonclick = "";
         edtProductoPaisID_Enabled = 0;
         edtCategoriaNombre_Jsonclick = "";
         edtCategoriaNombre_Link = "";
         edtCategoriaNombre_Enabled = 0;
         edtCategoriaID_Jsonclick = "";
         edtCategoriaID_Enabled = 0;
         edtVendedorNombre_Jsonclick = "";
         edtVendedorNombre_Link = "";
         edtVendedorNombre_Enabled = 0;
         edtVendedorID_Jsonclick = "";
         edtVendedorID_Enabled = 0;
         edtProductoPrecio_Jsonclick = "";
         edtProductoPrecio_Enabled = 0;
         edtProductoDescripcion_Jsonclick = "";
         edtProductoDescripcion_Enabled = 0;
         edtProductoNombre_Jsonclick = "";
         edtProductoNombre_Enabled = 0;
         edtProductoID_Jsonclick = "";
         edtProductoID_Enabled = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A19ProductoID","fld":"PRODUCTOID","pic":"ZZZZZ9"},{"av":"A6VendedorID","fld":"VENDEDORID","pic":"ZZZZZ9"},{"av":"A4CategoriaID","fld":"CATEGORIAID","pic":"ZZZZZ9"}]}""");
         setEventMetadata("'DOUPDATE'","""{"handler":"E110X1","iparms":[{"av":"A19ProductoID","fld":"PRODUCTOID","pic":"ZZZZZ9"}]}""");
         setEventMetadata("'DODELETE'","""{"handler":"E120X1","iparms":[{"av":"A19ProductoID","fld":"PRODUCTOID","pic":"ZZZZZ9"}]}""");
         setEventMetadata("VALID_PRODUCTOID","""{"handler":"Valid_Productoid","iparms":[]}""");
         setEventMetadata("VALID_VENDEDORID","""{"handler":"Valid_Vendedorid","iparms":[]}""");
         setEventMetadata("VALID_CATEGORIAID","""{"handler":"Valid_Categoriaid","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTOPAISID","""{"handler":"Valid_Productopaisid","iparms":[]}""");
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

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV11Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A20ProductoNombre = "";
         A21ProductoDescripcion = "";
         A7VendedorNombre = "";
         A5CategoriaNombre = "";
         A27ProductoPaisNombre = "";
         A23ProductoImagen = "";
         A40000ProductoImagen_GXI = "";
         sImgUrl = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         H000X2_A19ProductoID = new int[1] ;
         H000X2_A40000ProductoImagen_GXI = new string[] {""} ;
         H000X2_A27ProductoPaisNombre = new string[] {""} ;
         H000X2_A26ProductoPaisID = new int[1] ;
         H000X2_A5CategoriaNombre = new string[] {""} ;
         H000X2_A4CategoriaID = new int[1] ;
         H000X2_A7VendedorNombre = new string[] {""} ;
         H000X2_A6VendedorID = new int[1] ;
         H000X2_A22ProductoPrecio = new decimal[1] ;
         H000X2_A21ProductoDescripcion = new string[] {""} ;
         H000X2_A20ProductoNombre = new string[] {""} ;
         H000X2_A23ProductoImagen = new string[] {""} ;
         hsh = "";
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV6ProductoID = 1;
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA19ProductoID = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productogeneral__default(),
            new Object[][] {
                new Object[] {
               H000X2_A19ProductoID, H000X2_A40000ProductoImagen_GXI, H000X2_A27ProductoPaisNombre, H000X2_A26ProductoPaisID, H000X2_A5CategoriaNombre, H000X2_A4CategoriaID, H000X2_A7VendedorNombre, H000X2_A6VendedorID, H000X2_A22ProductoPrecio, H000X2_A21ProductoDescripcion,
               H000X2_A20ProductoNombre, H000X2_A23ProductoImagen
               }
            }
         );
         AV11Pgmname = "ProductoGeneral";
         /* GeneXus formulas. */
         AV11Pgmname = "ProductoGeneral";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int A19ProductoID ;
      private int wcpOA19ProductoID ;
      private int A6VendedorID ;
      private int A4CategoriaID ;
      private int edtProductoID_Enabled ;
      private int edtProductoNombre_Enabled ;
      private int edtProductoDescripcion_Enabled ;
      private int edtProductoPrecio_Enabled ;
      private int edtVendedorID_Enabled ;
      private int edtVendedorNombre_Enabled ;
      private int edtCategoriaID_Enabled ;
      private int edtCategoriaNombre_Enabled ;
      private int A26ProductoPaisID ;
      private int edtProductoPaisID_Enabled ;
      private int edtProductoPaisNombre_Enabled ;
      private int imgProductoImagen_Enabled ;
      private int AV6ProductoID ;
      private int idxLst ;
      private decimal A22ProductoPrecio ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV11Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divAttributestable_Internalname ;
      private string edtProductoID_Internalname ;
      private string edtProductoID_Jsonclick ;
      private string edtProductoNombre_Internalname ;
      private string edtProductoNombre_Jsonclick ;
      private string edtProductoDescripcion_Internalname ;
      private string edtProductoDescripcion_Jsonclick ;
      private string edtProductoPrecio_Internalname ;
      private string edtProductoPrecio_Jsonclick ;
      private string edtVendedorID_Internalname ;
      private string edtVendedorID_Jsonclick ;
      private string edtVendedorNombre_Internalname ;
      private string edtVendedorNombre_Link ;
      private string edtVendedorNombre_Jsonclick ;
      private string edtCategoriaID_Internalname ;
      private string edtCategoriaID_Jsonclick ;
      private string edtCategoriaNombre_Internalname ;
      private string edtCategoriaNombre_Link ;
      private string edtCategoriaNombre_Jsonclick ;
      private string edtProductoPaisID_Internalname ;
      private string edtProductoPaisID_Jsonclick ;
      private string edtProductoPaisNombre_Internalname ;
      private string edtProductoPaisNombre_Jsonclick ;
      private string divImagestable_Internalname ;
      private string sImgUrl ;
      private string imgProductoImagen_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string hsh ;
      private string sCtrlA19ProductoID ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool A23ProductoImagen_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string A20ProductoNombre ;
      private string A21ProductoDescripcion ;
      private string A7VendedorNombre ;
      private string A5CategoriaNombre ;
      private string A27ProductoPaisNombre ;
      private string A40000ProductoImagen_GXI ;
      private string A23ProductoImagen ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H000X2_A19ProductoID ;
      private string[] H000X2_A40000ProductoImagen_GXI ;
      private string[] H000X2_A27ProductoPaisNombre ;
      private int[] H000X2_A26ProductoPaisID ;
      private string[] H000X2_A5CategoriaNombre ;
      private int[] H000X2_A4CategoriaID ;
      private string[] H000X2_A7VendedorNombre ;
      private int[] H000X2_A6VendedorID ;
      private decimal[] H000X2_A22ProductoPrecio ;
      private string[] H000X2_A21ProductoDescripcion ;
      private string[] H000X2_A20ProductoNombre ;
      private string[] H000X2_A23ProductoImagen ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV7TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV8TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class productogeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000X2;
          prmH000X2 = new Object[] {
          new ParDef("@ProductoID",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000X2", "SELECT T1.[ProductoID], T1.[ProductoImagen_GXI], T2.[PaisNombre] AS ProductoPaisNombre, T1.[ProductoPaisID] AS ProductoPaisID, T3.[CategoriaNombre], T1.[CategoriaID], T4.[VendedorNombre], T1.[VendedorID], T1.[ProductoPrecio], T1.[ProductoDescripcion], T1.[ProductoNombre], T1.[ProductoImagen] FROM ((([Producto] T1 INNER JOIN [Pais] T2 ON T2.[PaisID] = T1.[ProductoPaisID]) INNER JOIN [Categoria] T3 ON T3.[CategoriaID] = T1.[CategoriaID]) INNER JOIN [Vendedor] T4 ON T4.[VendedorID] = T1.[VendedorID]) WHERE T1.[ProductoID] = @ProductoID ORDER BY T1.[ProductoID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000X2,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(2));
                return;
       }
    }

 }

}
