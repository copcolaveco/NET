Imports System.Net
Imports System.Net.FtpWebRequest
Imports System.Text
Imports System.Security.Cryptography

Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections
Imports Newtonsoft.Json

Public Class FormClientes
    Private carpeta As Long = 0
    Private clienteweb_com As String = ""
    Private clienteweb_uy As String = ""
    Private password_cifrado As String
    Private idnuevocliente As Long = 0
#Region "Atributos"
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario, ByVal idclientenuevo As Long)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarLista()
        cargarLista2()
        cargarComboLocalidad()
        cargarComboDepartamento()
        cargarcomboProlesa()
        cargarComboGiro()
        cargarComboTipoUsuario()
        cargarComboTecnicos()
        cargarComboAgencia()
        limpiar()
        idnuevocliente = idclientenuevo
        If idnuevocliente <> 0 Then
            cargarnuevocliente()
        End If
    End Sub

#End Region
    
    Private Sub cargarnuevocliente()
        Dim np As New dNuevocliente
        np.ID = idnuevocliente
        np = np.buscar
        If Not np Is Nothing Then
            TextNombre.Text = np.NOMBRE
            TextEmail1.Text = np.EMAIL
            TextEnvio.Text = np.DIRECCIONENVIO
            TextFacRsocial.Text = np.RAZON_SOCIAL
            TextCelular1.Text = np.CELULAR
            TextRut.Text = np.RUT
            ComboTipoUsuario.SelectedItem = Nothing
            Dim tu As dTipoUsuario
            For Each tu In ComboTipoUsuario.Items
                If tu.ID = np.TIPOUSUARIO Then
                    ComboTipoUsuario.SelectedItem = tu
                    Exit For
                End If
            Next
            TextDireccion.Text = np.DIRECCION
            TextTelefono1.Text = np.TELEFONO
            TextDicose.Text = np.DICOSE
            ComboDepartamento.SelectedItem = Nothing
            Dim d As dDepartamento
            For Each d In ComboDepartamento.Items
                If d.ID = np.IDDEPARTAMENTO Then
                    ComboDepartamento.SelectedItem = d
                    Exit For
                End If
            Next
            ComboLocalidad.SelectedItem = Nothing
            Dim l As dLocalidad
            For Each l In ComboLocalidad.Items
                If l.ID = np.IDLOCALIDAD Then
                    ComboLocalidad.SelectedItem = l
                    Exit For
                End If
            Next
            ComboTecnico1.SelectedItem = Nothing
            Dim t As dCliente
            For Each t In ComboTecnico1.Items
                If t.ID = np.TECNICO Then
                    ComboTecnico1.SelectedItem = t
                    Exit For
                End If
            Next
            ComboAgencia.SelectedItem = Nothing
            Dim a As dEmpresaT
            For Each a In ComboAgencia.Items
                If a.ID = np.IDAGENCIA Then
                    ComboAgencia.SelectedItem = a
                    Exit For
                End If
            Next
            TextId.Focus()
        End If
    End Sub

    Public Sub cargarLista()
        Dim c As New dCliente
        Dim lista As New ArrayList
        lista = c.listartodos
        ListClientes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    ListClientes.Items.Add(c)
                Next
            End If
        End If
    End Sub
    Public Sub cargarLista2()
        Dim c As New dCliente
        Dim lista As New ArrayList
        lista = c.listartodos
        ListSocios.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    ListSocios.Items.Add(c)
                Next
            End If
        End If
    End Sub

    Private Sub listproductores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListProductores.SelectedIndexChanged
        If ListProductores.SelectedItems.Count = 1 Then
            Dim cli As dCliente = CType(listproductores.SelectedItem, dCliente)
            TextId.Text = cli.ID
            TextNombre.Text = cli.NOMBRE
            TextEmail1.Text = cli.EMAIL1
            TextEnvio.Text = cli.ENVIO
            TextUsuarioWeb.Text = cli.USUARIO_WEB
            TextCelular1.Text = cli.CELULAR
            ComboTipoUsuario.SelectedItem = Nothing
            Dim tu As dTipoUsuario
            For Each tu In ComboTipoUsuario.Items
                If tu.ID = cli.TIPOUSUARIO Then
                    ComboTipoUsuario.SelectedItem = tu
                    Exit For
                End If
            Next
            TextDireccion.Text = cli.DIRECCION
            TextTelefono1.Text = cli.TELEFONO1
            TextFax.Text = cli.FAX
            TextDicose.Text = cli.DICOSE
            ComboDepartamento.SelectedItem = Nothing
            Dim d As dDepartamento
            For Each d In ComboDepartamento.Items
                If d.ID = cli.IDDEPARTAMENTO Then
                    ComboDepartamento.SelectedItem = d
                    Exit For
                End If
            Next
            ComboLocalidad.SelectedItem = Nothing
            Dim l As dLocalidad
            For Each l In ComboLocalidad.Items
                If l.ID = cli.IDLOCALIDAD Then
                    ComboLocalidad.SelectedItem = l
                    Exit For
                End If
            Next
            ComboTecnico1.SelectedItem = Nothing
            Dim t As dCliente
            For Each t In ComboTecnico1.Items
                If t.ID = cli.TECNICO1 Then
                    ComboTecnico1.SelectedItem = t
                    Exit For
                End If
            Next
            ComboTecnico2.SelectedItem = Nothing
            Dim t2 As dCliente
            For Each t2 In ComboTecnico2.Items
                If t2.ID = cli.TECNICO2 Then
                    ComboTecnico2.SelectedItem = t2
                    Exit For
                End If
            Next
            ComboAgencia.SelectedItem = Nothing
            Dim a As dEmpresaT
            For Each a In ComboAgencia.Items
                If a.ID = cli.IDAGENCIA Then
                    ComboAgencia.SelectedItem = a
                    Exit For
                End If
            Next
            If cli.CONTRATO = 1 Then
                CheckContrato.Checked = True
            Else
                CheckContrato.Checked = False
            End If
            If cli.SOCIO = 1 Then
                CheckSocio.Checked = True
            Else
                CheckSocio.Checked = False
            End If
            If cli.NOUSAR = 1 Then
                CheckNousar.Checked = True
            Else
                CheckNousar.Checked = False
            End If
            If cli.CARAVANAS = 1 Then
                CheckCaravanas.Checked = True
            Else
                CheckCaravanas.Checked = False
            End If
            If cli.PROLESA = 1 Then
                CheckProlesa.Checked = True
            Else
                CheckProlesa.Checked = False
            End If
            TextObservaciones.Text = cli.OBSERVACIONES
            TextId.Focus()
        End If
    End Sub

    Private Sub TextBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBuscar.TextChanged
        Dim nombre As String = TextBuscar.Text.Trim
        ListClientes.Items.Clear()
        If nombre.Length > 0 Then
            Dim uncli As New dcliente
            Dim lista As New ArrayList
            lista = uncli.buscarPorNombreTodos(nombre)
            If Not lista Is Nothing And lista.Count > 0 Then

                For Each s As dcliente In lista
                    ListClientes.Items.Add(s)
                Next
                ListClientes.Sorted = True
            End If
        Else : ListClientes.Items.Clear()
        End If
    End Sub

    Private Sub ButtonTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTodos.Click
        TextBuscar.Text = ""
        cargarLista()
        TextBuscar.Focus()
    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        TextNombre.Text = ""
        textemail.text = ""
        TextNEmail1.Text = ""
        TextEmail1.Text = ""
        TextNEmail2.Text = ""
        TextEmail2.Text = ""
        TextEnvio.Text = ""
        TextUsuarioWeb.Text = ""
        TextNCelular1.Text = ""
        TextCelular1.Text = ""
        TextNCelular2.Text = ""
        TextCelular2.Text = ""
        TextFigaro.Text = ""
        ComboTipoUsuario.Text = ""
        TextDireccion.Text = ""
        TextNTelefono1.Text = ""
        TextTelefono1.Text = ""
        TextNTelefono2.Text = ""
        TextTelefono2.Text = ""
        TextFax.Text = ""
        TextDicose.Text = ""
        ComboDepartamento.SelectedItem = Nothing
        ComboDepartamento.Text = ""
        ComboLocalidad.SelectedItem = Nothing
        ComboLocalidad.Text = ""
        ComboTecnico1.SelectedItem = Nothing
        ComboTecnico1.Text = ""
        ComboTecnico2.SelectedItem = Nothing
        ComboTecnico2.Text = ""
        ComboAgencia.SelectedItem = Nothing
        ComboAgencia.Text = ""
        CheckContrato.Checked = False
        CheckSocio.Checked = False
        CheckNousar.Checked = False
        CheckCodigoBarrras.Checked = False
        CheckCaravanas.Checked = False
        CheckProlesa.Checked = False
        ComboProlesa.SelectedItem = Nothing
        ComboProlesa.Text = ""
        ComboProlesa.Enabled = False
        TextProlesaMat.Text = ""
        TextObservaciones.Text = ""
        TextFacRsocial.Text = ""
        TextCedula.Text = ""
        TextRut.Text = ""
        TextFacDireccion.Text = ""
        TextFacLocalidad.Text = ""
        ComboFacDepartamento.SelectedItem = Nothing
        ComboFacDepartamento.Text = ""
        TextFacCpostal.Text = ""
        ComboFacGiro.SelectedItem = Nothing
        ComboFacGiro.Text = ""
        TextCobNTelefono1.Text = ""
        TextCobTelefono1.Text = ""
        TextCobNTelefono2.Text = ""
        TextCobTelefono2.Text = ""
        TextCobNCelular1.Text = ""
        TextCobCelular1.Text = ""
        TextCobNCelular2.Text = ""
        TextCobCelular2.Text = ""
        TextCobNEmail1.Text = ""
        TextCobEmail1.Text = ""
        TextCobNEmail2.Text = ""
        TextCobEmail2.Text = ""
        TextFacFax.Text = ""
        TextFacEmailFE.Text = ""
        TextFacContacto.Text = ""
        TextFacObservaciones.Text = ""
        CheckContado.Checked = False
        NumericLista.Value = 1
        TextEmailFrasco1.Text = ""
        TextEmailFrasco2.Text = ""
        TextEmailMuestra1.Text = ""
        TextEmailMuestra2.Text = ""
        TextEmailAnalisis1.Text = ""
        TextEmailAnalisis2.Text = ""
        TextEmailGeneral1.Text = ""
        TextEmailGeneral2.Text = ""
        CheckIncobrable.Checked = False
        TextId.Focus()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        cargarLista()
        limpiar()
    End Sub
    Private Sub guardar()
        Dim nombre As String = TextNombre.Text.Trim
        Dim email As String = ""
        If TextEmail.Text <> "" Then
            email = TextEmail.Text.Trim
        End If
        Dim nemail1 As String = ""
        If TextNEmail1.Text <> "" Then
            nemail1 = TextNEmail1.Text.Trim
        End If
        Dim email1 As String = ""
        If TextEmail1.Text <> "" Then
            email1 = TextEmail1.Text.Trim
        End If
        Dim nemail2 As String = ""
        If TextNEmail2.Text <> "" Then
            nemail2 = TextNEmail2.Text.Trim
        End If
        Dim email2 As String = ""
        If TextEmail2.Text <> "" Then
            email2 = TextEmail2.Text.Trim
        End If
        Dim envio As String = ""
        If TextEnvio.Text <> "" Then
            envio = TextEnvio.Text.Trim
        End If
        If ComboDepartamento.Text.Trim.Length = 0 Then MsgBox("Debe ingresar un departamento", MsgBoxStyle.Exclamation, "Atención") : ComboDepartamento.Focus() : Exit Sub
        If ComboLocalidad.Text.Trim.Length = 0 Then MsgBox("Debe ingresar una localidad", MsgBoxStyle.Exclamation, "Atención") : ComboLocalidad.Focus() : Exit Sub
        If ComboLocalidad.Text = "No aportado" Then
            Dim result2 = MessageBox.Show("No tiene localidad aportada, desea seguir de todos modos?", "Atención!", MessageBoxButtons.YesNo)
            If result2 = DialogResult.No Then
                Exit Sub
            End If
        End If
        If TextUsuarioWeb.Text.Trim.Length = 0 Then MsgBox("Debe ingresar un usuario web", MsgBoxStyle.Exclamation, "Atención") : TextUsuarioWeb.Focus() : Exit Sub
        Dim usuarioweb As String = TextUsuarioWeb.Text.Trim
        Dim ncelular1 As String = ""
        If TextNCelular1.Text <> "" Then
            ncelular1 = TextNCelular1.Text.Trim
        End If
        Dim celular1 As String = ""
        If TextCelular1.Text <> "" Then
            celular1 = TextCelular1.Text
        End If
        Dim ncelular2 As String = ""
        If TextNCelular2.Text <> "" Then
            ncelular2 = TextNCelular2.Text.Trim
        End If
        Dim celular2 As String = ""
        If TextCelular2.Text <> "" Then
            celular2 = TextCelular2.Text
        End If
        Dim figaro As String = ""
        If TextFigaro.Text <> "" Then
            figaro = TextFigaro.Text.Trim
        End If
        Dim tipousuario As dTipoUsuario = CType(ComboTipoUsuario.SelectedItem, dTipoUsuario)
        Dim admin As Boolean = False
        If tipousuario.ID = 97 Then
            admin = True
        Else
            admin = False
        End If

        Dim direccion As String = TextDireccion.Text.Trim
        Dim ntelefono1 As String = TextNTelefono1.Text.Trim
        Dim telefono1 As String = TextTelefono1.Text.Trim
        Dim ntelefono2 As String = TextNTelefono2.Text.Trim
        Dim telefono2 As String = TextTelefono2.Text.Trim
        Dim fax As String = TextFax.Text.Trim
        Dim dicose As String = TextDicose.Text.Trim
        Dim departamento As dDepartamento = CType(ComboDepartamento.SelectedItem, dDepartamento)
        Dim localidad As dLocalidad = CType(ComboLocalidad.SelectedItem, dLocalidad)
        Dim tecnico1 As dCliente = CType(ComboTecnico1.SelectedItem, dCliente)
        Dim tecnico2 As dCliente = CType(ComboTecnico2.SelectedItem, dCliente)
        Dim tecnico_1 As Long = 0
        Dim tecnico_2 As Long = 0
        If ComboAgencia.Text.Trim.Length = 0 Then MsgBox("Debe ingresar una agencia!", MsgBoxStyle.Exclamation, "Atención") : ComboAgencia.Focus() : Exit Sub
        Dim agencia As dEmpresaT = CType(ComboAgencia.SelectedItem, dEmpresaT)
        Dim contrato As Integer
        If CheckContrato.Checked = True Then
            contrato = 1
        Else
            contrato = 0
        End If
        Dim socio As Integer
        If CheckSocio.Checked = True Then
            socio = 1
        Else
            socio = 0
        End If
        Dim nousar As Integer
        If CheckNousar.Checked = True Then
            nousar = 1
        Else
            nousar = 0
        End If
        Dim codbar As Integer
        If CheckCodigoBarrras.Checked = True Then
            codbar = 1
        Else
            codbar = 0
        End If
        Dim caravanas As Integer
        If CheckCaravanas.Checked = True Then
            caravanas = 1
        Else
            caravanas = 0
        End If
        Dim prolesa As Integer
        If CheckProlesa.Checked = True Then
            prolesa = 1
        Else
            prolesa = 0
        End If
        Dim prolesasuc As dProlesa = CType(ComboProlesa.SelectedItem, dProlesa)
        Dim prolesamat As Long = 0
        If TextProlesaMat.Text <> "" And TextProlesaMat.Text <> "0" Then
            prolesamat = TextProlesaMat.Text.Trim
        Else
            If CheckProlesa.Checked = True Then
                MsgBox("Debe asignarle un número de matrícula de Prolesa!")
                Exit Sub
            End If
        End If
        Dim observaciones As String = ""
        If TextObservaciones.Text <> "" Then
            observaciones = TextObservaciones.Text.Trim
        
        End If
        Dim facrsocial As String = ""
        If TextFacRsocial.Text <> "" Then
            facrsocial = TextFacRsocial.Text.Trim
        End If
        Dim fac_cedula As String = ""
        If TextCedula.Text <> "" Then
            fac_cedula = TextCedula.Text.Trim
        End If
        Dim fac_rut As String = ""
        If TextRut.Text <> "" Then
            fac_rut = TextRut.Text.Trim
        End If
        Dim facdireccion As String = ""
        If TextFacDireccion.Text <> "" Then
            facdireccion = TextFacDireccion.Text.Trim
        End If
        Dim faclocalidad As String = ""
        If TextFacLocalidad.Text <> "" Then
            faclocalidad = TextFacLocalidad.Text.Trim
        End If
        Dim facdepartamento As dDepartamento = CType(ComboFacDepartamento.SelectedItem, dDepartamento)
        Dim fac_departamento As Integer = 0
        Dim faccpostal As String = ""
        If TextFacCpostal.Text <> "" Then
            faccpostal = TextFacCpostal.Text.Trim
        End If
        Dim facgiro As dGiro = CType(ComboFacGiro.SelectedItem, dGiro)
        Dim cobntelefono1 As String = ""
        If TextCobNTelefono1.Text <> "" Then
            cobntelefono1 = TextCobNTelefono1.Text.Trim
        End If
        Dim cobtelefono1 As String = ""
        If TextCobTelefono1.Text <> "" Then
            cobtelefono1 = TextCobTelefono1.Text.Trim
        End If
        Dim cobntelefono2 As String = ""
        If TextCobNTelefono2.Text <> "" Then
            cobntelefono2 = TextCobNTelefono2.Text.Trim
        End If
        Dim cobtelefono2 As String = ""
        If TextCobTelefono2.Text <> "" Then
            cobtelefono2 = TextCobTelefono2.Text.Trim
        End If
        Dim cobncelular1 As String = ""
        If TextCobNCelular1.Text <> "" Then
            cobncelular1 = TextCobNCelular1.Text.Trim
        End If
        Dim cobcelular1 As String = ""
        If TextCobCelular1.Text <> "" Then
            cobcelular1 = TextCobCelular1.Text.Trim
        End If
        Dim cobncelular2 As String = ""
        If TextCobNCelular2.Text <> "" Then
            cobncelular2 = TextCobNCelular2.Text.Trim
        End If
        Dim cobcelular2 As String = ""
        If TextCobCelular2.Text <> "" Then
            cobcelular2 = TextCobCelular2.Text.Trim
        End If
        Dim cobnemail1 As String = ""
        If TextCobNEmail1.Text <> "" Then
            cobnemail1 = TextCobNEmail1.Text.Trim
        End If
        Dim cobemail1 As String = ""
        If TextCobEmail1.Text <> "" Then
            cobemail1 = TextCobEmail1.Text.Trim
        End If
        Dim cobnemail2 As String = ""
        If TextCobNEmail2.Text <> "" Then
            cobnemail2 = TextCobNEmail2.Text.Trim
        End If
        Dim cobemail2 As String = ""
        If TextCobEmail2.Text <> "" Then
            cobemail2 = TextCobEmail2.Text.Trim
        End If
        Dim facfax As String = ""
        If TextFacFax.Text <> "" Then
            facfax = TextFacFax.Text.Trim
        End If
        Dim facemail_fe As String = ""
        If TextFacEmailFE.Text <> "" Then
            facemail_fe = TextFacEmailFE.Text.Trim
        End If
        Dim faccontacto As String = ""
        If TextFacContacto.Text <> "" Then
            faccontacto = TextFacContacto.Text.Trim
        End If
        Dim facobservaciones As String = ""
        If TextFacObservaciones.Text <> "" Then
            facobservaciones = TextFacObservaciones.Text.Trim
        End If
        Dim faclista As Integer = NumericLista.Value
        Dim contado As Integer = 0
        If CheckContado.Checked = True Then
            contado = 1
        End If
        Dim notemail_frasco1 As String = ""
        If TextEmailFrasco1.Text <> "" Then
            notemail_frasco1 = TextEmailFrasco1.Text.Trim
        End If
        Dim notemail_frasco2 As String = ""
        If TextEmailFrasco2.Text <> "" Then
            notemail_frasco2 = TextEmailFrasco2.Text.Trim
        End If
        Dim notemail_muestra1 As String = ""
        If TextEmailMuestra1.Text <> "" Then
            notemail_muestra1 = TextEmailMuestra1.Text.Trim
        End If
        Dim notemail_muestra2 As String = ""
        If TextEmailMuestra2.Text <> "" Then
            notemail_muestra2 = TextEmailMuestra2.Text.Trim
        End If
        Dim notemail_analisis1 As String = ""
        If TextEmailAnalisis1.Text <> "" Then
            notemail_analisis1 = TextEmailAnalisis1.Text.Trim
        End If
        Dim notemail_analisis2 As String = ""
        If TextEmailAnalisis2.Text <> "" Then
            notemail_analisis2 = TextEmailAnalisis2.Text.Trim
        End If
        Dim notemail_general1 As String = ""
        If TextEmailGeneral1.Text <> "" Then
            notemail_general1 = TextEmailGeneral1.Text.Trim
        End If
        Dim notemail_general2 As String = ""
        If TextEmailGeneral2.Text <> "" Then
            notemail_general2 = TextEmailGeneral2.Text.Trim
        End If
        Dim incobrable As Integer = 0
        If CheckIncobrable.Checked = True Then
            incobrable = 1
        End If
        If TextId.Text.Trim.Length > 0 Then
            If TextNombre.Text.Trim.Length > 0 Then
                Dim cli As New dCliente()
                Dim pw_com As New dClienteWeb_com
                Dim pw_com2 As New dClienteWeb_com
                Dim nocargaenweb As Integer = 0

                pw_com.USUARIO = TextUsuarioWeb.Text.Trim
                pw_com = pw_com.buscar
                Dim idclienteweb_com As Long


                If Not pw_com Is Nothing Then
                    idclienteweb_com = pw_com.ID
                Else
                    Dim result = MessageBox.Show("No existe el usuario web, desea continuar de todos modos?", "Atención", MessageBoxButtons.YesNo)
                    If result = DialogResult.No Then
                        Exit Sub
                    ElseIf result = DialogResult.Yes Then
                        nocargaenweb = 1
                    End If

                End If
              

                'NET*************************************
                Dim id As Long = TextId.Text.Trim
                cli.ID = id
                cli.NOMBRE = nombre
                cli.EMAIL = email
                cli.NOMBRE_EMAIL1 = nemail1
                cli.EMAIL1 = email1
                cli.NOMBRE_EMAIL2 = nemail2
                cli.EMAIL2 = email2
                cli.ENVIO = envio
                cli.USUARIO_WEB = usuarioweb
                cli.NOMBRE_CELULAR1 = ncelular1
                cli.CELULAR = celular1
                cli.NOMBRE_CELULAR2 = ncelular2
                cli.CELULAR2 = celular2
                cli.CODIGOFIGARO = figaro
                cli.TIPOUSUARIO = tipousuario.ID
                cli.DIRECCION = direccion
                cli.NOMBRE_TELEFONO1 = ntelefono1
                cli.TELEFONO1 = telefono1
                cli.NOMBRE_TELEFONO2 = ntelefono2
                cli.TELEFONO2 = telefono2
                cli.FAX = fax
                cli.DICOSE = dicose
                If departamento Is Nothing Then
                    cli.IDDEPARTAMENTO = 999
                Else
                    cli.IDDEPARTAMENTO = departamento.ID
                End If
                If localidad Is Nothing Then
                    cli.IDLOCALIDAD = 999
                Else
                    cli.IDLOCALIDAD = localidad.ID
                End If
                If tecnico1 Is Nothing Then
                    cli.TECNICO1 = 3197
                    tecnico_1 = 3197
                Else
                    cli.TECNICO1 = tecnico1.ID
                    tecnico_1 = tecnico1.ID
                End If
                If tecnico2 Is Nothing Then
                    cli.TECNICO2 = 3197
                    tecnico_2 = 3197
                Else
                    cli.TECNICO2 = tecnico2.ID
                    tecnico_2 = tecnico2.ID
                End If
                If Not agencia Is Nothing Then
                    cli.IDAGENCIA = agencia.ID
                End If
                cli.CONTRATO = contrato
                cli.SOCIO = socio
                cli.NOUSAR = nousar
                cli.CODBAR = codbar
                cli.CARAVANAS = caravanas
                cli.PROLESA = prolesa
                If prolesasuc Is Nothing Then
                    cli.PROLESASUC = 0
                Else
                    cli.PROLESASUC = prolesasuc.ID
                End If
                cli.PROLESAMAT = prolesamat
                cli.OBSERVACIONES = observaciones
                cli.FAC_RSOCIAL = facrsocial
                cli.FAC_CEDULA = fac_cedula
                cli.FAC_RUT = fac_rut
                cli.FAC_DIRECCION = facdireccion
                cli.FAC_LOCALIDAD = faclocalidad
                If facdepartamento Is Nothing Then
                    cli.FAC_DEPARTAMENTO = 999
                    fac_departamento = 999
                Else
                    cli.FAC_DEPARTAMENTO = facdepartamento.ID
                    fac_departamento = facdepartamento.ID
                End If
                cli.FAC_CPOSTAL = faccpostal
                If facgiro Is Nothing Then
                    cli.FAC_GIRO = 16
                Else
                    cli.FAC_GIRO = facgiro.ID
                End If
                cli.COB_NOMBRE_TELEFONO1 = cobntelefono1
                cli.FAC_TELEFONOS = cobtelefono1
                cli.COB_NOMBRE_TELEFONO2 = cobntelefono2
                cli.COB_TELEFONO2 = cobtelefono2
                cli.COB_NOMBRE_CELULAR1 = cobncelular1
                cli.COB_CELULAR1 = cobcelular1
                cli.COB_NOMBRE_CELULAR2 = cobncelular2
                cli.COB_CELULAR2 = cobcelular2
                cli.COB_NOMBRE_EMAIL1 = cobnemail1
                cli.COB_EMAIL1 = cobemail1
                cli.COB_NOMBRE_EMAIL2 = cobnemail2
                cli.COB_EMAIL2 = cobemail2
                cli.FAC_FAX = facfax
                cli.FAC_EMAIL = facemail_fe
                cli.FAC_CONTACTO = faccontacto
                cli.FAC_OBSERVACIONES = facobservaciones
                cli.FAC_LISTA = faclista
                cli.FAC_CONTADO = contado
                cli.NOT_EMAIL_FRASCOS1 = notemail_frasco1
                cli.NOT_EMAIL_FRASCOS2 = notemail_frasco2
                cli.NOT_EMAIL_MUESTRAS1 = notemail_muestra1
                cli.NOT_EMAIL_MUESTRAS2 = notemail_muestra2
                cli.NOT_EMAIL_ANALISIS1 = notemail_analisis1
                cli.NOT_EMAIL_ANALISIS2 = notemail_analisis2
                cli.NOT_EMAIL_GENERAL1 = notemail_general1
                cli.NOT_EMAIL_GENERAL2 = notemail_general2
                cli.INCOBRABLE = incobrable
                'COM**********************************
                If nocargaenweb = 0 Then
                    pw_com.ID = idclienteweb_com
                    pw_com.NOMBRE = nombre
                    pw_com.EMAIL_1 = email
                    pw_com.USUARIO = usuarioweb
                    pw_com.PASSWORD = usuarioweb
                    pw_com.RAZON_SOCIAL = facrsocial
                    pw_com.CELULAR_1 = celular1
                    pw_com.RUT = fac_rut
                    pw_com.TIPO_USUARIO_ID = tipousuario.ID
                    pw_com.DIRECCION = direccion
                    pw_com.TELEFONO_1 = telefono1
                    pw_com.DICOSE = dicose
                    pw_com.VER_CONTROL_LECHERO = 1
                    pw_com.VER_AGUA = 1
                    pw_com.VER_PAL = 1
                    pw_com.VER_SEROLOGIA = 1
                    pw_com.VER_ANTIBIOGRAMA = 1
                    pw_com.VER_PARASITOLOGIA = 1
                    pw_com.VER_PRODUCTOS_SUBPRODUCTOS = 1
                    pw_com.VER_PATOLOGIA = 1
                    pw_com.VER_CALIDAD_DE_LECHE = 1
                Else
                    pw_com2.ID = idclienteweb_com
                    pw_com2.NOMBRE = nombre
                    pw_com2.EMAIL_1 = email
                    pw_com2.USUARIO = usuarioweb
                    pw_com2.PASSWORD = usuarioweb
                    pw_com2.RAZON_SOCIAL = facrsocial
                    pw_com2.CELULAR_1 = celular1
                    pw_com2.RUT = fac_rut
                    pw_com2.TIPO_USUARIO_ID = tipousuario.ID
                    pw_com2.DIRECCION = direccion
                    pw_com2.TELEFONO_1 = telefono1
                    pw_com2.DICOSE = dicose
                    pw_com2.VER_CONTROL_LECHERO = 1
                    pw_com2.VER_AGUA = 1
                    pw_com2.VER_PAL = 1
                    pw_com2.VER_SEROLOGIA = 1
                    pw_com2.VER_ANTIBIOGRAMA = 1
                    pw_com2.VER_PARASITOLOGIA = 1
                    pw_com2.VER_PRODUCTOS_SUBPRODUCTOS = 1
                    pw_com2.VER_PATOLOGIA = 1
                    pw_com2.VER_CALIDAD_DE_LECHE = 1
                End If

                If (cli.modificar(Usuario)) Then
                    If nocargaenweb = 0 Then
                        pw_com.modificar(Usuario)
                    Else
                        pw_com2.guardar(Usuario)
                    End If
                    'pw_uy.modificar(Usuario)

                    MsgBox("cliente modificado", MsgBoxStyle.Information, "Atención")
                    limpiar()
                    cargarLista()
                    cargarLista2()

                    '*** CREA USUARIO EN GESTOR NUEVO *******************************************************************************************
                    Dim usuariogestor As New Dictionary(Of String, dUsuarioGestor)

                    Dim ug As New dUsuarioGestor

                    ug.email = email
                    'ug.password = usuarioweb
                    'ug.password_confirmation = usuarioweb
                    ug.usuario_web = usuarioweb
                    ug.nombre = nombre
                    ug.direccion = direccion
                    ug.dicose = dicose
                    ug.razon_social = facrsocial
                    ug.cedula = fac_cedula
                    ug.rut = fac_rut
                    ug.idnet = id
                    ug.direccion_frasco = envio
                    ug.agencia_frasco = agencia.ID
                    ug.notificacion_frasco_1 = notemail_frasco1
                    ug.notificacion_frasco_2 = notemail_frasco2
                    ug.notificacion_solicitud_1 = notemail_muestra1
                    ug.notificacion_solicitud_2 = notemail_muestra2
                    ug.notificacion_resultado_1 = notemail_analisis1
                    ug.notificacion_resultado_2 = notemail_analisis2
                    ug.notificacion_avisos_1 = notemail_general1
                    ug.notificacion_avisos_2 = notemail_general2
                    ug.tecnico_celular_1 = celular1
                    ug.tecnico_celular_2 = celular2
                    ug.tecnico_celular_nombre_1 = ncelular1
                    ug.tecnico_celular_nombre_2 = ncelular2
                    ug.tecnico_telefono_1 = telefono1
                    ug.tecnico_telefono_2 = telefono2
                    ug.tecnico_telefono_nombre_1 = ntelefono1
                    ug.tecnico_telefono_nombre_2 = ntelefono2
                    ug.tecnico_email_1 = email1
                    ug.tecnico_email_2 = email2
                    ug.tecnico_email_nombre_1 = nemail1
                    ug.tecnico_email_nombre_2 = nemail2
                    ug.fac_direccion = facdireccion
                    ug.fac_localidad = faclocalidad
                    ug.fac_departamento = facdepartamento.ID
                    ug.fac_email_envio = facemail_fe
                    ug.cobranza_celular_1 = cobcelular1
                    ug.cobranza_celular_2 = cobcelular2
                    ug.cobranza_celular_nombre_1 = cobncelular1
                    ug.cobranza_celular_nombre_2 = cobncelular2
                    ug.cobranza_telefono_1 = cobtelefono1
                    ug.cobranza_telefono_2 = cobtelefono2
                    ug.cobranza_telefono_nombre_1 = cobntelefono1
                    ug.cobranza_telefono_nombre_2 = cobntelefono2
                    ug.cobranza_email_1 = cobemail1
                    ug.cobranza_email_2 = cobemail2
                    ug.cobranza_email_nombre_1 = cobnemail1
                    ug.cobranza_email_nombre_2 = cobnemail2
                    ug.admin = admin
                    ug.id_tecnico_1 = tecnico1.ID
                    ug.id_tecnico_2 = tecnico2.ID
                    usuariogestor.Add("user", ug)

                    Dim parameters As String = JsonConvert.SerializeObject(usuariogestor, Formatting.None)

                    Dim status As HttpStatusCode = HttpStatusCode.ExpectationFailed
                    Dim response As Byte() = PostResponse("http://colaveco-gestor.herokuapp.com/users", "POST", parameters, status)

                    '****************************************************************************************************************************

                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        Else
            If TextNombre.Text.Trim.Length > 0 Then
                Dim cli As New dCliente()
                Dim cw_com As New dClienteWeb_com
                'Dim pw_uy As New dclienteWeb_uy
                'NET***********************************
                'cli.ID = id
                cli.NOMBRE = nombre
                cli.EMAIL = email
                cli.NOMBRE_EMAIL1 = nemail1
                cli.EMAIL1 = email1
                cli.NOMBRE_EMAIL2 = nemail2
                cli.EMAIL2 = email2
                cli.ENVIO = envio
                cli.USUARIO_WEB = usuarioweb
                clienteweb_com = usuarioweb
                cli.NOMBRE_CELULAR1 = ncelular1
                cli.CELULAR = celular1
                cli.NOMBRE_CELULAR2 = ncelular2
                cli.CELULAR2 = celular2
                cli.CODIGOFIGARO = figaro
                cli.TIPOUSUARIO = tipousuario.ID
                cli.DIRECCION = direccion
                cli.NOMBRE_TELEFONO1 = ntelefono1
                cli.TELEFONO1 = telefono1
                cli.NOMBRE_TELEFONO2 = ntelefono2
                cli.TELEFONO2 = telefono2
                cli.FAX = fax
                cli.DICOSE = dicose
                If departamento Is Nothing Then
                    cli.IDDEPARTAMENTO = 999
                Else
                    cli.IDDEPARTAMENTO = departamento.ID
                End If
                If localidad Is Nothing Then
                    cli.IDLOCALIDAD = 999
                Else
                    cli.IDLOCALIDAD = localidad.ID
                End If
                If tecnico1 Is Nothing Then
                    cli.TECNICO1 = 3197
                    tecnico_1 = 3197
                Else
                    cli.TECNICO1 = tecnico1.ID
                End If
                If tecnico2 Is Nothing Then
                    cli.TECNICO2 = 3197
                    tecnico_2 = 3197
                Else
                    cli.TECNICO2 = tecnico2.ID
                End If
                If Not agencia Is Nothing Then
                    cli.IDAGENCIA = agencia.ID
                End If
                cli.CONTRATO = contrato
                cli.SOCIO = socio
                cli.NOUSAR = nousar
                cli.CODBAR = codbar
                cli.CARAVANAS = caravanas
                cli.PROLESA = prolesa
                If prolesasuc Is Nothing Then
                    cli.PROLESASUC = 0
                Else
                    cli.PROLESASUC = prolesasuc.ID
                End If
                cli.PROLESAMAT = prolesamat
                cli.OBSERVACIONES = observaciones
                cli.FAC_RSOCIAL = facrsocial
                cli.FAC_CEDULA = fac_cedula
                cli.FAC_RUT = fac_rut
                cli.FAC_DIRECCION = facdireccion
                cli.FAC_LOCALIDAD = faclocalidad
                If facdepartamento Is Nothing Then
                    cli.FAC_DEPARTAMENTO = 999
                    fac_departamento = 999
                Else
                    cli.FAC_DEPARTAMENTO = facdepartamento.ID
                End If
                cli.FAC_CPOSTAL = faccpostal
                If facgiro Is Nothing Then
                    cli.FAC_GIRO = 16
                Else
                    cli.FAC_GIRO = facgiro.ID
                End If
                cli.COB_NOMBRE_TELEFONO1 = cobntelefono1
                cli.FAC_TELEFONOS = cobtelefono1
                cli.COB_NOMBRE_TELEFONO2 = cobntelefono2
                cli.COB_TELEFONO2 = cobtelefono2
                cli.COB_NOMBRE_CELULAR1 = cobncelular1
                cli.COB_CELULAR1 = cobcelular1
                cli.COB_NOMBRE_CELULAR2 = cobncelular2
                cli.COB_CELULAR2 = cobcelular2
                cli.COB_NOMBRE_EMAIL1 = cobnemail1
                cli.COB_EMAIL1 = cobemail1
                cli.COB_NOMBRE_EMAIL2 = cobnemail2
                cli.COB_EMAIL2 = cobemail2
                cli.FAC_FAX = facfax
                cli.FAC_EMAIL = facemail_fe
                cli.FAC_CONTACTO = faccontacto
                cli.FAC_OBSERVACIONES = facobservaciones
                cli.FAC_LISTA = faclista
                cli.FAC_CONTADO = contado
                cli.NOT_EMAIL_FRASCOS1 = notemail_frasco1
                cli.NOT_EMAIL_FRASCOS2 = notemail_frasco2
                cli.NOT_EMAIL_MUESTRAS1 = notemail_muestra1
                cli.NOT_EMAIL_MUESTRAS2 = notemail_muestra2
                cli.NOT_EMAIL_ANALISIS1 = notemail_analisis1
                cli.NOT_EMAIL_ANALISIS2 = notemail_analisis2
                cli.NOT_EMAIL_GENERAL1 = notemail_general1
                cli.NOT_EMAIL_GENERAL2 = notemail_general2
                cli.INCOBRABLE = incobrable
                'COM**********************************
                'cw_com.ID = idclienteweb_com
                cw_com.NOMBRE = nombre
                cw_com.EMAIL_1 = email
                cw_com.USUARIO = usuarioweb
                cw_com.PASSWORD = usuarioweb
                clienteweb_uy = usuarioweb
                cw_com.RAZON_SOCIAL = facrsocial
                cw_com.CELULAR_1 = celular1
                cw_com.RUT = fac_rut
                cw_com.TIPO_USUARIO_ID = tipousuario.ID
                cw_com.DIRECCION = direccion
                cw_com.TELEFONO_1 = telefono1
                cw_com.DICOSE = dicose
                cw_com.VER_CONTROL_LECHERO = 1
                cw_com.VER_AGUA = 1
                cw_com.VER_PAL = 1
                cw_com.VER_SEROLOGIA = 1
                cw_com.VER_ANTIBIOGRAMA = 1
                cw_com.VER_PARASITOLOGIA = 1
                cw_com.VER_PRODUCTOS_SUBPRODUCTOS = 1
                cw_com.VER_PATOLOGIA = 1
                cw_com.VER_CALIDAD_DE_LECHE = 1



                If (cli.guardar(Usuario)) Then
                    cw_com.guardar(Usuario)
                    'BUSCAR ULTIMO ID **************
                    Dim c As New dCliente
                    Dim nuevoid As Long = 0
                    c = c.buscarultimo
                    If Not c Is Nothing Then
                        nuevoid = c.ID
                    End If
                    '*******************************
                    '*** CREA USUARIO EN GESTOR NUEVO *******************************************************************************************
                    Dim usuariogestor As New Dictionary(Of String, dUsuarioGestor)

                    Dim ug As New dUsuarioGestor

                    ug.email = email
                    ug.password = usuarioweb
                    ug.password_confirmation = usuarioweb
                    ug.usuario_web = usuarioweb
                    ug.nombre = nombre
                    ug.direccion = direccion
                    ug.dicose = dicose
                    ug.razon_social = facrsocial
                    ug.cedula = fac_cedula
                    ug.rut = fac_rut
                    ug.idnet = nuevoid
                    ug.direccion_frasco = envio
                    ug.agencia_frasco = agencia.ID
                    ug.notificacion_frasco_1 = notemail_frasco1
                    ug.notificacion_frasco_2 = notemail_frasco2
                    ug.notificacion_solicitud_1 = notemail_muestra1
                    ug.notificacion_solicitud_2 = notemail_muestra2
                    ug.notificacion_resultado_1 = notemail_analisis1
                    ug.notificacion_resultado_2 = notemail_analisis2
                    ug.notificacion_avisos_1 = notemail_general1
                    ug.notificacion_avisos_2 = notemail_general2
                    ug.tecnico_celular_1 = celular1
                    ug.tecnico_celular_2 = celular2
                    ug.tecnico_celular_nombre_1 = ncelular1
                    ug.tecnico_celular_nombre_2 = ncelular2
                    ug.tecnico_telefono_1 = telefono1
                    ug.tecnico_telefono_2 = telefono2
                    ug.tecnico_telefono_nombre_1 = ntelefono1
                    ug.tecnico_telefono_nombre_2 = ntelefono2
                    ug.tecnico_email_1 = email1
                    ug.tecnico_email_2 = email2
                    ug.tecnico_email_nombre_1 = nemail1
                    ug.tecnico_email_nombre_2 = nemail2
                    ug.fac_direccion = facdireccion
                    ug.fac_localidad = faclocalidad
                    ug.fac_departamento = fac_departamento
                    ug.fac_email_envio = facemail_fe
                    ug.cobranza_celular_1 = cobcelular1
                    ug.cobranza_celular_2 = cobcelular2
                    ug.cobranza_celular_nombre_1 = cobncelular1
                    ug.cobranza_celular_nombre_2 = cobncelular2
                    ug.cobranza_telefono_1 = cobtelefono1
                    ug.cobranza_telefono_2 = cobtelefono2
                    ug.cobranza_telefono_nombre_1 = cobntelefono1
                    ug.cobranza_telefono_nombre_2 = cobntelefono2
                    ug.cobranza_email_1 = cobemail1
                    ug.cobranza_email_2 = cobemail2
                    ug.cobranza_email_nombre_1 = cobnemail1
                    ug.cobranza_email_nombre_2 = cobnemail2
                    ug.admin = admin
                    ug.id_tecnico_1 = tecnico_1
                    ug.id_tecnico_2 = tecnico_2
                    usuariogestor.Add("user", ug)

                    Dim parameters As String = JsonConvert.SerializeObject(usuariogestor, Formatting.None)

                    Dim status As HttpStatusCode = HttpStatusCode.ExpectationFailed
                    Dim response As Byte() = PostResponse("http://colaveco-gestor.herokuapp.com/users", "POST", parameters, status)

                    '****************************************************************************************************************************



                    crearcarpetas_com()
                    MsgBox("Cliente guardado", MsgBoxStyle.Information, "Atención")
                    MsgBox("Dar de alta en el sistema de gestión", MsgBoxStyle.Information, "Atención")
                    limpiar()
                    cargarLista()
                    cargarLista2()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
    End Sub
    Public Function PostResponse(ByVal url As String, ByVal metodo As String, ByVal content As String, ByRef statusCode As HttpStatusCode) As Byte()

        Dim responseFromServer As Byte() = Nothing
        Dim dataStream As Stream = Nothing

        Try
            Dim request As WebRequest = WebRequest.Create(url)

            request.Timeout = 120000

            request.Method = metodo


            Dim byteArray As Byte() = System.Text.Encoding.UTF8.GetBytes(content)

            request.ContentType = "application/json"

            request.ContentLength = byteArray.Length

            dataStream = request.GetRequestStream()

            dataStream.Write(byteArray, 0, byteArray.Length)

            dataStream.Close()



            Dim response As WebResponse = request.GetResponse()

            dataStream = response.GetResponseStream()

            Dim ms As New MemoryStream()

            Dim thisRead As Integer = 0

            Dim buff As Byte() = New Byte(1023) {}

            Do
                thisRead = dataStream.Read(buff, 0, buff.Length)

                If thisRead = 0 Then
                    Exit Do
                End If


                ms.Write(buff, 0, thisRead)
            Loop While True

            responseFromServer = ms.ToArray()

            dataStream.Close()

            response.Close()

            statusCode = HttpStatusCode.OK

        Catch ex As WebException
            If ex.Response IsNot Nothing Then
                dataStream = ex.Response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                Dim resp As String = reader.ReadToEnd()
                statusCode = DirectCast(ex.Response, HttpWebResponse).StatusCode
            Else
                Dim resp As String = ""

                statusCode = HttpStatusCode.ExpectationFailed

            End If

        Catch ex As Exception
            statusCode = HttpStatusCode.ExpectationFailed
        End Try



        Return responseFromServer

    End Function

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()

    End Sub
    Private Sub crearcarpetas_com()
        Dim cw_com As New dClienteWeb_com
        cw_com.USUARIO = clienteweb_com
        cw_com = cw_com.buscar
        If Not cw_com Is Nothing Then
            carpeta = cw_com.ID
        Else
            MsgBox("No existe el usuario web (.com)")
        End If
        crea_carpeta_com()
        crea_agro_nutricion_com()
        crea_agua_com()
        crea_ambiental_com()
        crea_antibiograma_com()
        crea_calidad_de_leche_com()
        crea_control_lechero_com()
        crea_lactometros_chequeos_maquina_com()
        crea_otros_servicios_com()
        crea_pal_com()
        crea_parasitologia_com()
        crea_patologia_com()
        crea_productos_subproductos_com()
        crea_serologia_com()
        crea_agro_suelos_com()
        crea_brucelosis_leche_com()

    End Sub

    Public Sub cargarComboDepartamento()
        Dim d As New dDepartamento
        Dim lista As New ArrayList
        lista = d.listar
        ComboDepartamento.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each d In lista
                    ComboDepartamento.Items.Add(d)
                    ComboFacDepartamento.Items.Add(d)
                Next
            End If
        End If
    End Sub
    Public Sub cargarcomboProlesa()
        Dim p As New dProlesa
        Dim lista As New ArrayList
        lista = p.listar
        ComboProlesa.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each p In lista
                    ComboProlesa.Items.Add(p)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboGiro()
        Dim g As New dGiro
        Dim lista As New ArrayList
        lista = g.listar
        ComboFacGiro.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each g In lista
                    ComboFacGiro.Items.Add(g)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboLocalidad()
        Dim l As New dLocalidad
        Dim lista As New ArrayList
        lista = l.listar
        ComboLocalidad.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each l In lista
                    ComboLocalidad.Items.Add(l)
                Next
            End If
        End If
    End Sub

    Public Sub cargarComboTipoUsuario()
        Dim tu As New dTipoUsuario
        Dim lista As New ArrayList
        lista = tu.listar
        ComboTipoUsuario.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each tu In lista
                    ComboTipoUsuario.Items.Add(tu)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboTecnicos()
        'Dim t As New dTecnicos
        'Dim lista As New ArrayList
        'lista = t.listar
        'ComboTecnicos.Items.Clear()
        'If Not lista Is Nothing Then
        '    If lista.Count > 0 Then
        '        For Each t In lista
        '            ComboTecnicos.Items.Add(t)
        '            ComboTecnicos2.Items.Add(t)
        '            ComboTecnicos3.Items.Add(t)
        '        Next
        '    End If
        'End If
        Dim c As New dCliente
        Dim lista As New ArrayList
        lista = c.listar
        ComboTecnico1.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    ComboTecnico1.Items.Add(c)
                    ComboTecnico2.Items.Add(c)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboAgencia()
        Dim a As New dEmpresaT
        Dim lista As New ArrayList
        lista = a.listar
        ComboAgencia.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each a In lista
                    ComboAgencia.Items.Add(a)
                Next
            End If
        End If
    End Sub

    Private Sub ButtonEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEmpresa.Click
        If TextId.Text <> "" Then
            Dim idcliente As Long = TextId.Text.Trim
            Dim v As New FormProductorEmpresa(Usuario, idcliente)
            v.ShowDialog()
        End If
    End Sub
    Public Sub crea_carpeta_com()
        Dim cweb_com As New dClienteWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "HSy7TS8sfuv"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = cweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = cweb_com.ID
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & ""

        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory

        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try

    End Sub
    Public Sub crea_control_lechero_com()
        Dim cweb_com As New dClienteWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "HSy7TS8sfuv"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = cweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = cweb_com.ID
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/control_lechero/"

        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory

        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try

    End Sub
    Public Sub crea_agua_com()
        Dim cweb_com As New dClienteWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "HSy7TS8sfuv"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = cweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = cweb_com.ID
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/agua/"

        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory

        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try

    End Sub
    Public Sub crea_antibiograma_com()
        Dim cweb_com As New dClienteWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "HSy7TS8sfuv"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = cweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = cweb_com.ID
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/antibiograma/"

        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory

        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try

    End Sub
    Public Sub crea_pal_com()
        Dim cweb_com As New dClienteWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "HSy7TS8sfuv"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = cweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = cweb_com.ID
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/pal/"

        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory

        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try

    End Sub
    Public Sub crea_parasitologia_com()
        Dim cweb_com As New dClienteWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "HSy7TS8sfuv"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = cweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = cweb_com.ID
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/parasitologia/"

        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory

        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try

    End Sub
    Public Sub crea_productos_subproductos_com()
        Dim cweb_com As New dClienteWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "HSy7TS8sfuv"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = cweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = cweb_com.ID
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/productos_subproductos/"

        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory

        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try

    End Sub
    Public Sub crea_serologia_com()
        Dim cweb_com As New dClienteWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "HSy7TS8sfuv"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = cweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = cweb_com.ID
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/serologia/"

        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory

        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try

    End Sub
    Public Sub crea_patologia_com()
        Dim cweb_com As New dClienteWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "HSy7TS8sfuv"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = cweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = cweb_com.ID
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/patologia/"

        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory

        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try

    End Sub
    Public Sub crea_calidad_de_leche_com()
        Dim cweb_com As New dClienteWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "HSy7TS8sfuv"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = cweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = cweb_com.ID
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/calidad_de_leche/"

        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory

        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try

    End Sub
    Public Sub crea_ambiental_com()
        Dim cweb_com As New dClienteWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "HSy7TS8sfuv"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = cweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = cweb_com.ID
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/ambiental/"

        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory

        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try

    End Sub
    Public Sub crea_lactometros_chequeos_maquina_com()
        Dim cweb_com As New dClienteWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "HSy7TS8sfuv"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = cweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = cweb_com.ID
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/lactometros_chequeos_maquina/"

        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory

        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try

    End Sub
    Public Sub crea_agro_nutricion_com()
        Dim cweb_com As New dClienteWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "HSy7TS8sfuv"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = cweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = cweb_com.ID
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/agro_nutricion/"

        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory

        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try

    End Sub
    Public Sub crea_agro_suelos_com()
        Dim cweb_com As New dClienteWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "HSy7TS8sfuv"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = cweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = cweb_com.ID
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/agro_suelos/"

        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory

        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try

    End Sub
    Public Sub crea_brucelosis_leche_com()
        Dim cweb_com As New dClienteWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "HSy7TS8sfuv"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = cweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = cweb_com.ID
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/brucelosis_leche/"

        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory

        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try

    End Sub
    Public Sub crea_otros_servicios_com()
        Dim cweb_com As New dClienteWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "HSy7TS8sfuv"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = cweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = cweb_com.ID
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/otros_servicios/"

        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory

        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try

    End Sub


    Function generarClaveSHA1(ByVal cadena As String) As String

        Dim enc As New UTF8Encoding
        Dim data() As Byte = enc.GetBytes(cadena)
        Dim result() As Byte

        Dim sha As New SHA1CryptoServiceProvider

        result = sha.ComputeHash(data)

        Dim sb As New StringBuilder
        Dim max As Int32 = result.Length



        For i As Integer = 0 To max - 1


            'Convertimos los valores en hexadecimal
            'cuando tiene una cifra hay que rellenarlo con cero
            'para que siempre ocupen dos dígitos.
            If (result(i) < 16) Then
                sb.Append("0")
            End If

            sb.Append(result(i).ToString("x"))


        Next


        'Devolvemos la cadena con el hash en mayúsculas para que quede más chuli :)
        generarClaveSHA1 = sb.ToString().ToUpper()
        password_cifrado = sb.ToString().ToUpper()

    End Function


    Private Sub ComboDepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboDepartamento.SelectedIndexChanged
        cargarLocalidades()
    End Sub
    Public Sub cargarLocalidades()
        Dim l As New dLocalidad
        Dim lista As New ArrayList
        Dim iddepartamento As dDepartamento = CType(ComboDepartamento.SelectedItem, dDepartamento)
        If Not iddepartamento Is Nothing Then
            Dim texto As Long = iddepartamento.ID
            lista = l.listarpordepartamento(texto)
            ComboLocalidad.Items.Clear()
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each l In lista
                        ComboLocalidad.Items.Add(l)
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub ButtonFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFiltrar.Click
        Dim v As New FormFiltrarProductor(Usuario)
        v.Show()
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ButtonSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalir.Click
        Me.Close()
    End Sub

    Private Sub ButtonNuevo2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo2.Click
        cargarLista()
        limpiar()
    End Sub

    Private Sub ButtonNuevo3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo3.Click
        cargarLista()
        limpiar()
    End Sub

    Private Sub ButtonGuardar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar2.Click
        guardar()
        'limpiar()
        'cargarLista()
    End Sub

    Private Sub ButtonGuardar3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar3.Click
        guardar()
        'limpiar()
        'cargarLista()
    End Sub

    Private Sub ButtonEmpresa2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEmpresa2.Click
        If TextId.Text <> "" Then
            Dim idcliente As Long = TextId.Text.Trim
            Dim v As New FormProductorEmpresa(Usuario, idcliente)
            v.ShowDialog()
        End If
    End Sub

    Private Sub ButtonEmpresa3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEmpresa3.Click
        If TextId.Text <> "" Then
            Dim idcliente As Long = TextId.Text.Trim
            Dim v As New FormProductorEmpresa(Usuario, idcliente)
            v.ShowDialog()
        End If
    End Sub

    Private Sub ButtonSalir2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalir2.Click
        Me.Close()
    End Sub

    Private Sub ButtonSalir3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalir3.Click
        Me.Close()
    End Sub

    Private Sub ButtonFiltrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFiltrar2.Click
        Dim v As New FormFiltrarProductor(Usuario)
        v.Show()
    End Sub

    Private Sub ButtonFiltrar3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFiltrar3.Click
        Dim v As New FormFiltrarProductor(Usuario)
        v.Show()
    End Sub

    Private Sub ListClientes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ListClientes_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListClientes.SelectedIndexChanged
        If ListClientes.SelectedItems.Count = 1 Then
            Dim cli As dCliente = CType(ListClientes.SelectedItem, dCliente)
            TextId.Text = cli.ID
            TextNombre.Text = cli.NOMBRE
            TextEmail.Text = cli.EMAIL
            TextNEmail1.Text = cli.NOMBRE_EMAIL1
            TextEmail1.Text = cli.EMAIL1
            TextNEmail2.Text = cli.NOMBRE_EMAIL2
            TextEmail2.Text = cli.EMAIL2
            TextEnvio.Text = cli.ENVIO
            TextUsuarioWeb.Text = cli.USUARIO_WEB
            TextNCelular1.Text = cli.NOMBRE_CELULAR1
            TextCelular1.Text = cli.CELULAR
            TextNCelular2.Text = cli.NOMBRE_CELULAR2
            TextCelular2.Text = cli.CELULAR2
            TextFigaro.Text = cli.CODIGOFIGARO
            ComboTipoUsuario.SelectedItem = Nothing
            Dim tu As dTipoUsuario
            For Each tu In ComboTipoUsuario.Items
                If tu.ID = cli.TIPOUSUARIO Then
                    ComboTipoUsuario.SelectedItem = tu
                    Exit For
                End If
            Next
            TextDireccion.Text = cli.DIRECCION
            TextNTelefono1.Text = cli.NOMBRE_TELEFONO1
            TextTelefono1.Text = cli.TELEFONO1
            TextNTelefono2.Text = cli.NOMBRE_TELEFONO2
            TextTelefono2.Text = cli.TELEFONO2
            TextFax.Text = cli.FAX
            TextDicose.Text = cli.DICOSE
            ComboDepartamento.SelectedItem = Nothing
            Dim d As dDepartamento
            For Each d In ComboDepartamento.Items
                If d.ID = cli.IDDEPARTAMENTO Then
                    ComboDepartamento.SelectedItem = d
                    cargarLocalidades()
                    Exit For
                End If
            Next
            ComboLocalidad.SelectedItem = Nothing
            Dim l As dLocalidad
            For Each l In ComboLocalidad.Items
                If l.ID = cli.IDLOCALIDAD Then
                    ComboLocalidad.SelectedItem = l
                    Exit For
                End If
            Next
            ComboTecnico1.SelectedItem = Nothing
            Dim t As dCliente
            For Each t In ComboTecnico1.Items
                If t.ID = cli.TECNICO1 Then
                    ComboTecnico1.SelectedItem = t
                    Exit For
                End If
            Next
            ComboTecnico2.SelectedItem = Nothing
            Dim t2 As dCliente
            For Each t2 In ComboTecnico2.Items
                If t2.ID = cli.TECNICO2 Then
                    ComboTecnico2.SelectedItem = t2
                    Exit For
                End If
            Next
            ComboAgencia.SelectedItem = Nothing
            Dim a As dEmpresaT
            For Each a In ComboAgencia.Items
                If a.ID = cli.IDAGENCIA Then
                    ComboAgencia.SelectedItem = a
                    Exit For
                End If
            Next
            If cli.CONTRATO = 1 Then
                CheckContrato.Checked = True
            Else
                CheckContrato.Checked = False
            End If
            If cli.SOCIO = 1 Then
                CheckSocio.Checked = True
            Else
                CheckSocio.Checked = False
            End If
            If cli.NOUSAR = 1 Then
                CheckNousar.Checked = True
            Else
                CheckNousar.Checked = False
            End If
            If cli.CODBAR = 1 Then
                CheckCodigoBarrras.Checked = True
            Else
                CheckCodigoBarrras.Checked = False
            End If
            If cli.CARAVANAS = 1 Then
                CheckCaravanas.Checked = True
            Else
                CheckCaravanas.Checked = False
            End If
            If cli.PROLESA = 1 Then
                CheckProlesa.Checked = True
            Else
                CheckProlesa.Checked = False
            End If
            Dim ps As dProlesa
            For Each ps In ComboProlesa.Items
                If ps.ID = cli.PROLESASUC Then
                    ComboProlesa.SelectedItem = ps
                    Exit For
                End If
            Next
            TextProlesaMat.Text = cli.PROLESAMAT
            TextObservaciones.Text = cli.OBSERVACIONES
            TextFacRsocial.Text = cli.FAC_RSOCIAL
            TextCedula.Text = cli.FAC_CEDULA
            TextRut.Text = cli.FAC_RUT
            TextFacDireccion.Text = cli.FAC_DIRECCION
            TextFacLocalidad.Text = cli.FAC_LOCALIDAD
            ComboFacDepartamento.SelectedItem = Nothing
            Dim dd As dDepartamento
            For Each dd In ComboFacDepartamento.Items
                If dd.ID = cli.FAC_DEPARTAMENTO Then
                    ComboFacDepartamento.SelectedItem = dd
                    Exit For
                End If
            Next
            TextFacCpostal.Text = cli.FAC_CPOSTAL
            ComboFacGiro.SelectedItem = Nothing
            Dim g As dGiro
            For Each g In ComboFacGiro.Items
                If g.ID = cli.FAC_GIRO Then
                    ComboFacGiro.SelectedItem = g
                    Exit For
                End If
            Next
            TextCobNTelefono1.Text = cli.COB_NOMBRE_TELEFONO1
            TextCobTelefono1.Text = cli.FAC_TELEFONOS
            TextCobNTelefono2.Text = cli.COB_NOMBRE_TELEFONO2
            TextCobTelefono2.Text = cli.COB_TELEFONO2
            TextCobNCelular1.Text = cli.COB_NOMBRE_CELULAR1
            TextCobCelular1.Text = cli.COB_CELULAR1
            TextCobNCelular2.Text = cli.COB_NOMBRE_CELULAR2
            TextCobCelular2.Text = cli.COB_CELULAR2
            TextCobNEmail1.Text = cli.COB_NOMBRE_EMAIL1
            TextCobEmail1.Text = cli.COB_EMAIL1
            TextCobNEmail2.Text = cli.COB_NOMBRE_EMAIL2
            TextCobEmail2.Text = cli.COB_EMAIL2
            TextFacFax.Text = cli.FAC_FAX
            TextFacEmailFE.Text = cli.FAC_EMAIL
            TextFacContacto.Text = cli.FAC_CONTACTO
            TextFacObservaciones.Text = cli.FAC_OBSERVACIONES
            NumericLista.Value = cli.FAC_LISTA
            If cli.FAC_CONTADO = 1 Then
                CheckContado.Checked = True
            Else
                CheckContado.Checked = False
            End If
            TextEmailFrasco1.Text = cli.NOT_EMAIL_FRASCOS1
            TextEmailFrasco2.Text = cli.NOT_EMAIL_FRASCOS2
            TextEmailMuestra1.Text = cli.NOT_EMAIL_MUESTRAS1
            TextEmailMuestra2.Text = cli.NOT_EMAIL_MUESTRAS2
            TextEmailAnalisis1.Text = cli.NOT_EMAIL_ANALISIS1
            TextEmailAnalisis2.Text = cli.NOT_EMAIL_ANALISIS2
            TextEmailGeneral1.Text = cli.NOT_EMAIL_GENERAL1
            TextEmailGeneral2.Text = cli.NOT_EMAIL_GENERAL2
            If cli.INCOBRABLE = 1 Then
                CheckIncobrable.Checked = True
            Else
                CheckIncobrable.Checked = False
            End If
            TextId.Focus()
        End If
    End Sub

    Private Sub CheckProlesa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckProlesa.CheckedChanged
        prolesa()
    End Sub
    Private Sub prolesa()
        If CheckProlesa.Checked = True Then
            ComboProlesa.Enabled = True
        Else
            ComboProlesa.SelectedItem = Nothing
            ComboProlesa.Text = ""
            ComboProlesa.Enabled = False

        End If
    End Sub

    Private Sub CheckListarSocios_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckListarSocios.CheckedChanged
        If CheckListarSocios.Checked = True Then
            listarsocios()
        Else
            cargarLista2()
        End If
    End Sub
    Private Sub listarsocios()
        Dim c As New dCliente
        Dim lista As New ArrayList
        lista = c.listarsocios
        ListSocios.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    ListSocios.Items.Add(c)
                Next
            End If
        End If
    End Sub

    Private Sub ListSocios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListSocios.SelectedIndexChanged
        If ListSocios.SelectedItems.Count = 1 Then
            Dim cli As dCliente = CType(ListSocios.SelectedItem, dCliente)
            TextId.Text = cli.ID
            TextNombre.Text = cli.NOMBRE
            TextEmail1.Text = cli.EMAIL1
            TextEnvio.Text = cli.ENVIO
            TextUsuarioWeb.Text = cli.USUARIO_WEB
            TextCelular1.Text = cli.CELULAR
            TextFigaro.Text = cli.CODIGOFIGARO
            ComboTipoUsuario.SelectedItem = Nothing
            Dim tu As dTipoUsuario
            For Each tu In ComboTipoUsuario.Items
                If tu.ID = cli.TIPOUSUARIO Then
                    ComboTipoUsuario.SelectedItem = tu
                    Exit For
                End If
            Next
            TextDireccion.Text = cli.DIRECCION
            TextTelefono1.Text = cli.TELEFONO1
            TextFax.Text = cli.FAX
            TextDicose.Text = cli.DICOSE
            ComboDepartamento.SelectedItem = Nothing
            Dim d As dDepartamento
            For Each d In ComboDepartamento.Items
                If d.ID = cli.IDDEPARTAMENTO Then
                    ComboDepartamento.SelectedItem = d
                    Exit For
                End If
            Next
            ComboLocalidad.SelectedItem = Nothing
            Dim l As dLocalidad
            For Each l In ComboLocalidad.Items
                If l.ID = cli.IDLOCALIDAD Then
                    ComboLocalidad.SelectedItem = l
                    Exit For
                End If
            Next
            ComboTecnico1.SelectedItem = Nothing
            Dim t As dCliente
            For Each t In ComboTecnico1.Items
                If t.ID = cli.TECNICO1 Then
                    ComboTecnico1.SelectedItem = t
                    Exit For
                End If
            Next
            ComboTecnico2.SelectedItem = Nothing
            Dim t2 As dCliente
            For Each t2 In ComboTecnico2.Items
                If t2.ID = cli.TECNICO2 Then
                    ComboTecnico2.SelectedItem = t2
                    Exit For
                End If
            Next
            ComboAgencia.SelectedItem = Nothing
            Dim a As dEmpresaT
            For Each a In ComboAgencia.Items
                If a.ID = cli.IDAGENCIA Then
                    ComboAgencia.SelectedItem = a
                    Exit For
                End If
            Next
            If cli.CONTRATO = 1 Then
                CheckContrato.Checked = True
            Else
                CheckContrato.Checked = False
            End If
            If cli.SOCIO = 1 Then
                CheckSocio.Checked = True
            Else
                CheckSocio.Checked = False
            End If
            If cli.NOUSAR = 1 Then
                CheckNousar.Checked = True
            Else
                CheckNousar.Checked = False
            End If
            If cli.CODBAR = 1 Then
                CheckCodigoBarrras.Checked = True
            Else
                CheckCodigoBarrras.Checked = False
            End If
            If cli.CARAVANAS = 1 Then
                CheckCaravanas.Checked = True
            Else
                CheckCaravanas.Checked = False
            End If
            If cli.PROLESA = 1 Then
                CheckProlesa.Checked = True
            Else
                CheckProlesa.Checked = False
            End If
            Dim ps As dProlesa
            For Each ps In ComboProlesa.Items
                If ps.ID = cli.PROLESASUC Then
                    ComboProlesa.SelectedItem = ps
                    Exit For
                End If
            Next
            TextProlesaMat.Text = cli.PROLESAMAT
            TextObservaciones.Text = cli.OBSERVACIONES
            TextFacRsocial.Text = cli.FAC_RSOCIAL
            TextCedula.Text = cli.FAC_CEDULA
            TextRut.Text = cli.FAC_RUT
            TextFacDireccion.Text = cli.FAC_DIRECCION
            TextFacLocalidad.Text = cli.FAC_LOCALIDAD
            ComboFacDepartamento.SelectedItem = Nothing
            Dim dd As dDepartamento
            For Each dd In ComboFacDepartamento.Items
                If dd.ID = cli.FAC_DEPARTAMENTO Then
                    ComboFacDepartamento.SelectedItem = dd
                    Exit For
                End If
            Next
            TextFacCpostal.Text = cli.FAC_CPOSTAL
            ComboFacGiro.SelectedItem = Nothing
            Dim g As dGiro
            For Each g In ComboFacGiro.Items
                If g.ID = cli.FAC_GIRO Then
                    ComboFacGiro.SelectedItem = g
                    Exit For
                End If
            Next
            TextCobTelefono1.Text = cli.FAC_TELEFONOS
            TextFacFax.Text = cli.FAC_FAX
            TextFacEmailFE.Text = cli.COB_EMAIL1
            TextFacContacto.Text = cli.FAC_CONTACTO
            TextFacObservaciones.Text = cli.FAC_OBSERVACIONES
            NumericLista.Value = cli.FAC_LISTA
            If cli.FAC_CONTADO = 1 Then
                CheckContado.Checked = True
            Else
                CheckContado.Checked = False
            End If
            TextId.Focus()
        End If
    End Sub
    Private Sub guardarsinsalir()
        Dim nombre As String = TextNombre.Text.Trim
        Dim email As String = ""
        If TextEmail.Text <> "" Then
            email = TextEmail.Text.Trim
        End If
        Dim nemail1 As String = ""
        If TextNEmail1.Text <> "" Then
            nemail1 = TextNEmail1.Text.Trim
        End If
        Dim email1 As String = ""
        If TextEmail1.Text <> "" Then
            email1 = TextEmail1.Text.Trim
        End If
        Dim nemail2 As String = ""
        If TextNEmail2.Text <> "" Then
            nemail2 = TextNEmail2.Text.Trim
        End If
        Dim email2 As String = ""
        If TextEmail2.Text <> "" Then
            email2 = TextEmail2.Text.Trim
        End If
        Dim envio As String = ""
        If TextEnvio.Text <> "" Then
            envio = TextEnvio.Text.Trim
        End If
        If ComboDepartamento.Text.Trim.Length = 0 Then MsgBox("Debe ingresar un departamento", MsgBoxStyle.Exclamation, "Atención") : ComboDepartamento.Focus() : Exit Sub
        If ComboLocalidad.Text.Trim.Length = 0 Then MsgBox("Debe ingresar una localidad", MsgBoxStyle.Exclamation, "Atención") : ComboLocalidad.Focus() : Exit Sub
        If ComboTecnico1.Text.Trim.Length = 0 Then MsgBox("Debe ingresar un técnico", MsgBoxStyle.Exclamation, "Atención") : ComboTecnico1.Focus() : Exit Sub
        If TextUsuarioWeb.Text.Trim.Length = 0 Then MsgBox("Debe ingresar un usuario web", MsgBoxStyle.Exclamation, "Atención") : TextUsuarioWeb.Focus() : Exit Sub
        Dim usuarioweb As String = TextUsuarioWeb.Text.Trim
        Dim ncelular1 As String = ""
        If TextNCelular1.Text <> "" Then
            ncelular1 = TextNCelular1.Text.Trim
        End If
        Dim celular1 As String = ""
        If TextCelular1.Text <> "" Then
            celular1 = TextCelular1.Text
        End If
        Dim ncelular2 As String = ""
        If TextNCelular2.Text <> "" Then
            ncelular2 = TextNCelular2.Text.Trim
        End If
        Dim celular2 As String = ""
        If TextCelular2.Text <> "" Then
            celular2 = TextCelular2.Text
        End If
        Dim figaro As String = ""
        If TextFigaro.Text <> "" Then
            figaro = TextFigaro.Text.Trim
        End If
        Dim tipousuario As dTipoUsuario = CType(ComboTipoUsuario.SelectedItem, dTipoUsuario)
        Dim direccion As String = TextDireccion.Text.Trim
        Dim ntelefono1 As String = TextNTelefono1.Text.Trim
        Dim telefono1 As String = TextTelefono1.Text.Trim
        Dim ntelefono2 As String = TextNTelefono2.Text.Trim
        Dim telefono2 As String = TextTelefono2.Text.Trim
        Dim fax As String = TextFax.Text.Trim
        Dim dicose As String = TextDicose.Text.Trim
        Dim departamento As dDepartamento = CType(ComboDepartamento.SelectedItem, dDepartamento)
        Dim localidad As dLocalidad = CType(ComboLocalidad.SelectedItem, dLocalidad)
        'Dim tecnico As dTecnicos = CType(ComboTecnicos.SelectedItem, dTecnicos)
        'Dim tecnico2 As dTecnicos = CType(ComboTecnicos2.SelectedItem, dTecnicos)
        'Dim tecnico3 As dTecnicos = CType(ComboTecnicos3.SelectedItem, dTecnicos)
        Dim tecnico1 As dCliente = CType(ComboTecnico1.SelectedItem, dCliente)
        Dim tecnico2 As dCliente = CType(ComboTecnico2.SelectedItem, dCliente)
        Dim agencia As dEmpresaT = CType(ComboAgencia.SelectedItem, dEmpresaT)
        Dim contrato As Integer
        If CheckContrato.Checked = True Then
            contrato = 1
        Else
            contrato = 0
        End If
        Dim socio As Integer
        If CheckSocio.Checked = True Then
            socio = 1
        Else
            socio = 0
        End If
        Dim nousar As Integer
        If CheckNousar.Checked = True Then
            nousar = 1
        Else
            nousar = 0
        End If
        Dim caravanas As Integer
        If CheckCaravanas.Checked = True Then
            caravanas = 1
        Else
            caravanas = 0
        End If
        Dim prolesa As Integer
        If CheckProlesa.Checked = True Then
            prolesa = 1
        Else
            prolesa = 0
        End If
        Dim prolesasuc As dProlesa = CType(ComboProlesa.SelectedItem, dProlesa)
        Dim prolesamat As Long = 0
        Dim observaciones As String = ""
        If TextObservaciones.Text <> "" Then
            observaciones = TextObservaciones.Text.Trim
        End If
        Dim facrsocial As String = ""
        If TextFacRsocial.Text <> "" Then
            facrsocial = TextFacRsocial.Text.Trim
        End If
        Dim fac_cedula As String = ""
        If TextCedula.Text <> "" Then
            fac_cedula = TextCedula.Text.Trim
        End If
        Dim fac_rut As String = ""
        If TextRut.Text <> "" Then
            fac_rut = TextRut.Text.Trim
        End If
        Dim facdireccion As String = ""
        If TextFacDireccion.Text <> "" Then
            facdireccion = TextFacDireccion.Text.Trim
        End If
        Dim faclocalidad As String = ""
        If TextFacLocalidad.Text <> "" Then
            faclocalidad = TextFacLocalidad.Text.Trim
        End If
        Dim facdepartamento As dDepartamento = CType(ComboFacDepartamento.SelectedItem, dDepartamento)
        Dim faccpostal As String = ""
        If TextFacCpostal.Text <> "" Then
            faccpostal = TextFacCpostal.Text.Trim
        End If
        Dim facgiro As dGiro = CType(ComboFacGiro.SelectedItem, dGiro)
        Dim cobntelefono1 As String = ""
        If TextCobNTelefono1.Text <> "" Then
            cobntelefono1 = TextCobNTelefono1.Text.Trim
        End If
        Dim cobtelefono1 As String = ""
        If TextCobTelefono1.Text <> "" Then
            cobtelefono1 = TextCobTelefono1.Text.Trim
        End If
        Dim cobntelefono2 As String = ""
        If TextCobNTelefono2.Text <> "" Then
            cobntelefono2 = TextCobNTelefono2.Text.Trim
        End If
        Dim cobtelefono2 As String = ""
        If TextCobTelefono2.Text <> "" Then
            cobtelefono2 = TextCobTelefono2.Text.Trim
        End If
        Dim cobncelular1 As String = ""
        If TextCobNCelular1.Text <> "" Then
            cobncelular1 = TextCobNCelular1.Text.Trim
        End If
        Dim cobcelular1 As String = ""
        If TextCobCelular1.Text <> "" Then
            cobcelular1 = TextCobCelular1.Text.Trim
        End If
        Dim cobncelular2 As String = ""
        If TextCobNCelular2.Text <> "" Then
            cobncelular2 = TextCobNCelular2.Text.Trim
        End If
        Dim cobcelular2 As String = ""
        If TextCobCelular2.Text <> "" Then
            cobcelular2 = TextCobCelular2.Text.Trim
        End If
        Dim cobnemail1 As String = ""
        If TextCobNEmail1.Text <> "" Then
            cobnemail1 = TextCobNEmail1.Text.Trim
        End If
        Dim cobemail1 As String = ""
        If TextCobEmail1.Text <> "" Then
            cobemail1 = TextCobEmail1.Text.Trim
        End If
        Dim cobnemail2 As String = ""
        If TextCobNEmail2.Text <> "" Then
            cobnemail2 = TextCobNEmail2.Text.Trim
        End If
        Dim cobemail2 As String = ""
        If TextCobEmail2.Text <> "" Then
            cobemail2 = TextCobEmail2.Text.Trim
        End If
        Dim facfax As String = ""
        If TextFacFax.Text <> "" Then
            facfax = TextFacFax.Text.Trim
        End If
        Dim facemail_fe As String = ""
        If TextFacEmailFE.Text <> "" Then
            facemail_fe = TextFacEmailFE.Text.Trim
        End If
        Dim faccontacto As String = ""
        If TextFacContacto.Text <> "" Then
            faccontacto = TextFacContacto.Text.Trim
        End If
        Dim facobservaciones As String = ""
        If TextFacObservaciones.Text <> "" Then
            facobservaciones = TextFacObservaciones.Text.Trim
        End If
        Dim faclista As Integer = NumericLista.Value
        Dim contado As Integer = 0
        If CheckContado.Checked = True Then
            contado = 1
        End If
        Dim notemail_frasco1 As String = ""
        If TextEmailFrasco1.Text <> "" Then
            notemail_frasco1 = TextEmailFrasco1.Text.Trim
        End If
        Dim notemail_frasco2 As String = ""
        If TextEmailFrasco2.Text <> "" Then
            notemail_frasco2 = TextEmailFrasco2.Text.Trim
        End If
        Dim notemail_muestra1 As String = ""
        If TextEmailMuestra1.Text <> "" Then
            notemail_muestra1 = TextEmailMuestra1.Text.Trim
        End If
        Dim notemail_muestra2 As String = ""
        If TextEmailMuestra2.Text <> "" Then
            notemail_muestra2 = TextEmailMuestra2.Text.Trim
        End If
        Dim notemail_analisis1 As String = ""
        If TextEmailAnalisis1.Text <> "" Then
            notemail_analisis1 = TextEmailAnalisis1.Text.Trim
        End If
        Dim notemail_analisis2 As String = ""
        If TextEmailAnalisis2.Text <> "" Then
            notemail_analisis2 = TextEmailAnalisis2.Text.Trim
        End If
        Dim notemail_general1 As String = ""
        If TextEmailGeneral1.Text <> "" Then
            notemail_general1 = TextEmailGeneral1.Text.Trim
        End If
        Dim notemail_general2 As String = ""
        If TextEmailGeneral2.Text <> "" Then
            notemail_general2 = TextEmailGeneral2.Text.Trim
        End If
        'If Not ListClientes.SelectedItem Is Nothing And TextId.Text.Trim.Length > 0 Then
        If TextId.Text.Trim.Length > 0 Then
            If TextNombre.Text.Trim.Length > 0 Then
                Dim cli As New dCliente()
                Dim pw_com As New dClienteWeb_com
                Dim nocargaenweb As Integer = 0
                'Dim pw_uy As New dclienteWeb_uy
                pw_com.USUARIO = TextUsuarioWeb.Text.Trim
                pw_com = pw_com.buscar
                Dim idclienteweb_com As Long
                'Dim idclienteweb_uy As Long

                If Not pw_com Is Nothing Then
                    idclienteweb_com = pw_com.ID
                Else
                    Dim result = MessageBox.Show("No existe el usuario web, desea continuar de todos modos?", "Atención", MessageBoxButtons.YesNo)
                    If result = DialogResult.No Then
                        Exit Sub
                    ElseIf result = DialogResult.Yes Then
                        nocargaenweb = 1
                        'idclienteweb_com = 4119
                    End If

                End If
                'pw_uy.USUARIO = TextUsuarioWeb.Text.Trim
                'pw_uy = pw_uy.buscar
                'If Not pw_uy Is Nothing Then
                'idclienteweb_uy = pw_uy.ID
                'Else
                'MsgBox("No existe el usuario web (.uy)")
                'Exit Sub
                'End If

                'NET*************************************
                Dim id As Long = TextId.Text.Trim
                cli.ID = id
                cli.NOMBRE = nombre
                cli.EMAIL = email
                cli.NOMBRE_EMAIL1 = nemail1
                cli.EMAIL1 = email1
                cli.NOMBRE_EMAIL2 = nemail2
                cli.EMAIL2 = email2
                cli.ENVIO = envio
                cli.USUARIO_WEB = usuarioweb
                cli.NOMBRE_CELULAR1 = ncelular1
                cli.CELULAR = celular1
                cli.NOMBRE_CELULAR2 = ncelular2
                cli.CELULAR2 = celular2
                cli.CODIGOFIGARO = figaro
                cli.TIPOUSUARIO = tipousuario.ID
                cli.DIRECCION = direccion
                cli.NOMBRE_TELEFONO1 = ntelefono1
                cli.TELEFONO1 = telefono1
                cli.NOMBRE_TELEFONO2 = ntelefono2
                cli.TELEFONO2 = telefono2
                cli.FAX = fax
                cli.DICOSE = dicose
                If departamento Is Nothing Then
                    cli.IDDEPARTAMENTO = 999
                Else
                    cli.IDDEPARTAMENTO = departamento.ID
                End If
                If localidad Is Nothing Then
                    cli.IDLOCALIDAD = 999
                Else
                    cli.IDLOCALIDAD = localidad.ID
                End If
                If tecnico1 Is Nothing Then
                    cli.TECNICO1 = 3197
                Else
                    cli.TECNICO1 = tecnico1.ID
                End If
                If tecnico2 Is Nothing Then
                    cli.TECNICO2 = 3197
                Else
                    cli.TECNICO2 = tecnico2.ID
                End If
                If Not agencia Is Nothing Then
                    cli.IDAGENCIA = agencia.ID
                End If
                cli.CONTRATO = contrato
                cli.SOCIO = socio
                cli.NOUSAR = nousar
                cli.CARAVANAS = caravanas
                cli.PROLESA = prolesa
                If prolesasuc Is Nothing Then
                    cli.PROLESASUC = 0
                Else
                    cli.PROLESASUC = prolesasuc.ID
                End If
                cli.PROLESAMAT = prolesamat
                cli.OBSERVACIONES = observaciones
                cli.FAC_RSOCIAL = facrsocial
                cli.FAC_CEDULA = fac_cedula
                cli.FAC_RUT = fac_rut
                cli.FAC_DIRECCION = facdireccion
                cli.FAC_LOCALIDAD = faclocalidad
                If facdepartamento Is Nothing Then
                    cli.FAC_DEPARTAMENTO = 999
                Else
                    cli.FAC_DEPARTAMENTO = facdepartamento.ID
                End If
                cli.FAC_CPOSTAL = faccpostal
                If facgiro Is Nothing Then
                    cli.FAC_GIRO = 16
                Else
                    cli.FAC_GIRO = facgiro.ID
                End If
                cli.COB_NOMBRE_TELEFONO1 = cobntelefono1
                cli.FAC_TELEFONOS = cobtelefono1
                cli.COB_NOMBRE_TELEFONO2 = cobntelefono2
                cli.COB_TELEFONO2 = cobtelefono2
                cli.COB_NOMBRE_CELULAR1 = cobncelular1
                cli.COB_CELULAR1 = cobcelular1
                cli.COB_NOMBRE_CELULAR2 = cobncelular2
                cli.COB_CELULAR2 = cobcelular2
                cli.COB_NOMBRE_EMAIL1 = cobnemail1
                cli.COB_EMAIL1 = cobemail1
                cli.COB_NOMBRE_EMAIL2 = cobnemail2
                cli.COB_EMAIL2 = cobemail2
                cli.FAC_FAX = facfax
                cli.FAC_EMAIL = facemail_fe
                cli.FAC_CONTACTO = faccontacto
                cli.FAC_OBSERVACIONES = facobservaciones
                cli.FAC_LISTA = faclista
                cli.FAC_CONTADO = contado
                cli.NOT_EMAIL_FRASCOS1 = notemail_frasco1
                cli.NOT_EMAIL_FRASCOS2 = notemail_frasco2
                cli.NOT_EMAIL_MUESTRAS1 = notemail_muestra1
                cli.NOT_EMAIL_MUESTRAS2 = notemail_muestra2
                cli.NOT_EMAIL_ANALISIS1 = notemail_analisis1
                cli.NOT_EMAIL_ANALISIS2 = notemail_analisis2
                cli.NOT_EMAIL_GENERAL1 = notemail_general1
                cli.NOT_EMAIL_GENERAL2 = notemail_general2
                'COM**********************************
                If nocargaenweb = 0 Then
                    pw_com.ID = idclienteweb_com
                    pw_com.NOMBRE = nombre
                    pw_com.EMAIL_1 = email
                    pw_com.USUARIO = usuarioweb
                    pw_com.PASSWORD = usuarioweb
                    pw_com.RAZON_SOCIAL = facrsocial
                    pw_com.CELULAR_1 = celular1
                    pw_com.RUT = fac_rut
                    pw_com.TIPO_USUARIO_ID = tipousuario.ID
                    pw_com.DIRECCION = direccion
                    pw_com.TELEFONO_1 = telefono1
                    pw_com.DICOSE = dicose
                    pw_com.VER_CONTROL_LECHERO = 1
                    pw_com.VER_AGUA = 1
                    pw_com.VER_PAL = 1
                    pw_com.VER_SEROLOGIA = 1
                    pw_com.VER_ANTIBIOGRAMA = 1
                    pw_com.VER_PARASITOLOGIA = 1
                    pw_com.VER_PRODUCTOS_SUBPRODUCTOS = 1
                    pw_com.VER_PATOLOGIA = 1
                    pw_com.VER_CALIDAD_DE_LECHE = 1
                End If

                If (cli.modificar(Usuario)) Then
                    If nocargaenweb = 0 Then
                        pw_com.modificar(Usuario)
                    End If
                    'pw_uy.modificar(Usuario)

                    MsgBox("cliente modificado", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                    'cargarLista()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        Else
            If TextNombre.Text.Trim.Length > 0 Then
                Dim cli As New dCliente()
                Dim cw_com As New dClienteWeb_com
                'Dim pw_uy As New dclienteWeb_uy
                'NET***********************************
                'cli.ID = id
                cli.NOMBRE = nombre
                cli.EMAIL = email
                cli.NOMBRE_EMAIL1 = nemail1
                cli.EMAIL1 = email1
                cli.NOMBRE_EMAIL2 = nemail2
                cli.EMAIL2 = email2
                cli.ENVIO = envio
                cli.USUARIO_WEB = usuarioweb
                clienteweb_com = usuarioweb
                cli.NOMBRE_CELULAR1 = ncelular1
                cli.CELULAR = celular1
                cli.NOMBRE_CELULAR2 = ncelular2
                cli.CELULAR2 = celular2
                cli.CODIGOFIGARO = figaro
                cli.TIPOUSUARIO = tipousuario.ID
                cli.DIRECCION = direccion
                cli.NOMBRE_TELEFONO1 = ntelefono1
                cli.TELEFONO1 = telefono1
                cli.NOMBRE_TELEFONO2 = ntelefono2
                cli.TELEFONO2 = telefono2
                cli.FAX = fax
                cli.DICOSE = dicose
                If departamento Is Nothing Then
                    cli.IDDEPARTAMENTO = 999
                Else
                    cli.IDDEPARTAMENTO = departamento.ID
                End If
                If localidad Is Nothing Then
                    cli.IDLOCALIDAD = 999
                Else
                    cli.IDLOCALIDAD = localidad.ID
                End If
                If tecnico1 Is Nothing Then
                    cli.TECNICO1 = 3197
                Else
                    cli.TECNICO1 = tecnico1.ID
                End If
                If tecnico2 Is Nothing Then
                    cli.TECNICO2 = 3197
                Else
                    cli.TECNICO2 = tecnico2.ID
                End If
                If Not agencia Is Nothing Then
                    cli.IDAGENCIA = agencia.ID
                End If
                cli.CONTRATO = contrato
                cli.SOCIO = socio
                cli.NOUSAR = nousar
                cli.CARAVANAS = caravanas
                cli.PROLESA = prolesa
                If prolesasuc Is Nothing Then
                    cli.PROLESASUC = 0
                Else
                    cli.PROLESASUC = prolesasuc.ID
                End If
                cli.PROLESAMAT = prolesamat
                cli.OBSERVACIONES = observaciones
                cli.FAC_RSOCIAL = facrsocial
                cli.FAC_CEDULA = fac_cedula
                cli.FAC_RUT = fac_rut
                cli.FAC_DIRECCION = facdireccion
                cli.FAC_LOCALIDAD = faclocalidad
                If facdepartamento Is Nothing Then
                    cli.FAC_DEPARTAMENTO = 999
                Else
                    cli.FAC_DEPARTAMENTO = facdepartamento.ID
                End If
                cli.FAC_CPOSTAL = faccpostal
                If facgiro Is Nothing Then
                    cli.FAC_GIRO = 16
                Else
                    cli.FAC_GIRO = facgiro.ID
                End If
                cli.COB_NOMBRE_TELEFONO1 = cobntelefono1
                cli.FAC_TELEFONOS = cobtelefono1
                cli.COB_NOMBRE_TELEFONO2 = cobntelefono2
                cli.COB_TELEFONO2 = cobtelefono2
                cli.COB_NOMBRE_CELULAR1 = cobncelular1
                cli.COB_CELULAR1 = cobcelular1
                cli.COB_NOMBRE_CELULAR2 = cobncelular2
                cli.COB_CELULAR2 = cobcelular2
                cli.COB_NOMBRE_EMAIL1 = cobnemail1
                cli.COB_EMAIL1 = cobemail1
                cli.COB_NOMBRE_EMAIL2 = cobnemail2
                cli.COB_EMAIL2 = cobemail2
                cli.FAC_FAX = facfax
                cli.FAC_EMAIL = facemail_fe
                cli.FAC_CONTACTO = faccontacto
                cli.FAC_OBSERVACIONES = facobservaciones
                cli.FAC_LISTA = faclista
                cli.FAC_CONTADO = contado
                cli.NOT_EMAIL_FRASCOS1 = notemail_frasco1
                cli.NOT_EMAIL_FRASCOS2 = notemail_frasco2
                cli.NOT_EMAIL_MUESTRAS1 = notemail_muestra1
                cli.NOT_EMAIL_MUESTRAS2 = notemail_muestra2
                cli.NOT_EMAIL_ANALISIS1 = notemail_analisis1
                cli.NOT_EMAIL_ANALISIS2 = notemail_analisis2
                cli.NOT_EMAIL_GENERAL1 = notemail_general1
                cli.NOT_EMAIL_GENERAL2 = notemail_general2
                'COM**********************************
                'cw_com.ID = idclienteweb_com
                cw_com.NOMBRE = nombre
                cw_com.EMAIL_1 = email
                cw_com.USUARIO = usuarioweb
                cw_com.PASSWORD = usuarioweb
                clienteweb_uy = usuarioweb
                cw_com.RAZON_SOCIAL = facrsocial
                cw_com.CELULAR_1 = celular1
                cw_com.RUT = fac_rut
                cw_com.TIPO_USUARIO_ID = tipousuario.ID
                cw_com.DIRECCION = direccion
                cw_com.TELEFONO_1 = telefono1
                cw_com.DICOSE = dicose
                cw_com.VER_CONTROL_LECHERO = 1
                cw_com.VER_AGUA = 1
                cw_com.VER_PAL = 1
                cw_com.VER_SEROLOGIA = 1
                cw_com.VER_ANTIBIOGRAMA = 1
                cw_com.VER_PARASITOLOGIA = 1
                cw_com.VER_PRODUCTOS_SUBPRODUCTOS = 1
                cw_com.VER_PATOLOGIA = 1
                cw_com.VER_CALIDAD_DE_LECHE = 1



                If (cli.guardar(Usuario)) Then
                    cw_com.guardar(Usuario)
                    'BUSCAR ULTIMO ID **************
                    Dim c As New dCliente
                    Dim nuevoid As Long = 0
                    c = c.buscarultimo
                    If Not c Is Nothing Then
                        nuevoid = c.ID
                    End If
                    '*******************************
                    '*** CREA USUARIO EN GESTOR NUEVO *******************************************************************************************
                    Dim usuariogestor As New Dictionary(Of String, dUsuarioGestor)

                    Dim ug As New dUsuarioGestor

                    ug.email = email
                    ug.password = usuarioweb
                    ug.password_confirmation = usuarioweb
                    ug.usuario_web = usuarioweb
                    ug.nombre = nombre
                    ug.direccion = direccion
                    ug.dicose = dicose
                    ug.razon_social = facrsocial
                    ug.rut = fac_rut
                    ug.idnet = nuevoid
                    ug.direccion_frasco = envio
                    ug.agencia_frasco = agencia.ID
                    ug.notificacion_frasco_1 = notemail_frasco1
                    ug.notificacion_frasco_2 = notemail_frasco2
                    ug.notificacion_solicitud_1 = notemail_muestra1
                    ug.notificacion_solicitud_2 = notemail_muestra2
                    ug.notificacion_resultado_1 = notemail_analisis1
                    ug.notificacion_resultado_2 = notemail_analisis2
                    ug.notificacion_avisos_1 = notemail_general1
                    ug.notificacion_avisos_2 = notemail_general2
                    ug.tecnico_celular_1 = celular1
                    ug.tecnico_celular_2 = celular2
                    ug.tecnico_celular_nombre_1 = ncelular1
                    ug.tecnico_celular_nombre_2 = ncelular2
                    ug.tecnico_telefono_1 = telefono1
                    ug.tecnico_telefono_2 = telefono2
                    ug.tecnico_telefono_nombre_1 = ntelefono1
                    ug.tecnico_telefono_nombre_2 = ntelefono2
                    ug.tecnico_email_1 = email1
                    ug.tecnico_email_2 = email2
                    ug.tecnico_email_nombre_1 = nemail1
                    ug.tecnico_email_nombre_2 = nemail2
                    ug.fac_direccion = facdireccion
                    ug.fac_localidad = faclocalidad
                    ug.fac_departamento = facdepartamento.ID
                    ug.fac_email_envio = facemail_fe
                    ug.cobranza_celular_1 = cobcelular1
                    ug.cobranza_celular_2 = cobcelular2
                    ug.cobranza_celular_nombre_1 = cobncelular1
                    ug.cobranza_celular_nombre_2 = cobncelular2
                    ug.cobranza_telefono_1 = cobtelefono1
                    ug.cobranza_telefono_2 = cobtelefono2
                    ug.cobranza_telefono_nombre_1 = cobntelefono1
                    ug.cobranza_telefono_nombre_2 = cobntelefono2
                    ug.cobranza_email_1 = cobemail1
                    ug.cobranza_email_2 = cobemail2
                    ug.cobranza_email_nombre_1 = cobnemail1
                    ug.cobranza_email_nombre_2 = cobnemail2
                    usuariogestor.Add("user", ug)

                    Dim parameters As String = JsonConvert.SerializeObject(usuariogestor, Formatting.None)

                    Dim status As HttpStatusCode = HttpStatusCode.ExpectationFailed
                    Dim response As Byte() = PostResponse("http://colaveco-gestor.herokuapp.com/users", "POST", parameters, status)

                    '****************************************************************************************************************************



                    crearcarpetas_com()
                    MsgBox("cliente guardado", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                    'cargarLista()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
    End Sub

    Private Sub ButtonGuardar4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar4.Click
        guardarsinsalir()
    End Sub

    Private Sub CheckCaravanas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckCaravanas.CheckedChanged
        caravanas()
    End Sub
    Private Sub caravanas()
        If CheckCaravanas.Checked = True Then
            marcar_caravana()
        ElseIf CheckCaravanas.Checked = False Then
            desmarcar_caravana()
        End If
    End Sub
    Private Sub marcar_caravana()
        If TextId.Text <> "" Then
            Dim cli As Integer = TextId.Text.Trim
            Dim c As New dCliente
            c.marcarcaravana(Usuario, cli)
        End If
    End Sub
    Private Sub desmarcar_caravana()
        If TextId.Text <> "" Then
            Dim cli As Integer = TextId.Text.Trim
            Dim c As New dCliente
            c.desmarcarcaravana(Usuario, cli)
        End If
    End Sub

    Private Sub ButtonConvenios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonConvenios.Click
        Dim cli As Long = 0
        If TextId.Text <> "" Then
            cli = TextId.Text
        End If
        If cli = 0 Then
            MsgBox("Debe seleccionar un cliente o guardar el que esta creando!")
        Else
            Dim v As New FormClienteConvenio(Usuario, cli)
            v.ShowDialog()
        End If
       
    End Sub
End Class