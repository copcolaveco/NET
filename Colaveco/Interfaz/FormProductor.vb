Imports System.Net
Imports System.Net.FtpWebRequest
Imports System.Text
Imports System.Security.Cryptography
Public Class FormProductor
    Private carpeta As Long = 0
    Private prodweb_com As String = ""
    Private prodweb_uy As String = ""
    Private password_cifrado As String
    Private idnuevoproductor As Long = 0
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
    Public Sub New(ByVal u As dUsuario, ByVal idprodnuevo As Long)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarLista()
        cargarComboLocalidad()
        cargarComboDepartamento()
        cargarComboTipoUsuario()
        cargarComboTecnicos()
        cargarComboAgencia()
        limpiar()
        idnuevoproductor = idprodnuevo
        If idnuevoproductor <> 0 Then
            cargarnuevoproductor()
        End If
    End Sub

#End Region
    Private Sub cargarnuevoproductor()
        Dim np As New dNuevoProductor
        np.ID = idnuevoproductor
        np = np.buscar
        If Not np Is Nothing Then
            TextNombre.Text = np.NOMBRE
            TextEmail1.Text = np.EMAIL
            TextEnvio.Text = np.DIRECCIONENVIO
            TextRazonSocial.Text = np.RAZON_SOCIAL
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
            ComboTecnicos.SelectedItem = Nothing
            Dim t As dCliente
            For Each t In ComboTecnicos.Items
                If t.ID = np.TECNICO Then
                    ComboTecnicos.SelectedItem = t
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
        Dim p As New dCliente
        Dim lista As New ArrayList
        lista = p.listartodos
        ListProductores.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each p In lista
                    ListProductores.Items.Add(p)
                Next
            End If
        End If
    End Sub

    Private Sub ListProductores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListProductores.SelectedIndexChanged
        If ListProductores.SelectedItems.Count = 1 Then
            Dim pro As dProductor = CType(ListProductores.SelectedItem, dProductor)
            TextId.Text = pro.ID
            TextNombre.Text = pro.NOMBRE
            TextEmail1.Text = pro.EMAIL1
            TextEmail2.Text = pro.EMAIL2
            TextEmail3.Text = pro.EMAIL3
            TextEnvio.Text = pro.ENVIO
            TextUsuarioWeb.Text = pro.USUARIO_WEB
            TextRazonSocial.Text = pro.RAZON_SOCIAL
            TextTelefono2.Text = pro.TELEFONO_2
            TextTelefono3.Text = pro.TELEFONO_3
            TextCelular1.Text = pro.CELULAR_1
            TextCelular2.Text = pro.CELULAR_2
            TextCelular3.Text = pro.CELULAR_3
            TextRut.Text = pro.RUT
            TextFigaro.Text = pro.CODIGOFIGARO
            ComboTipoUsuario.SelectedItem = Nothing
            Dim tu As dTipoUsuario
            For Each tu In ComboTipoUsuario.Items
                If tu.ID = pro.TIPOUSUARIO Then
                    ComboTipoUsuario.SelectedItem = tu
                    Exit For
                End If
            Next
            TextDireccion.Text = pro.DIRECCION
            TextTelefono1.Text = pro.TELEFONO
            TextFax.Text = pro.FAX
            TextDicose.Text = pro.DICOSE
            ComboDepartamento.SelectedItem = Nothing
            Dim d As dDepartamento
            For Each d In ComboDepartamento.Items
                If d.ID = pro.IDDEPARTAMENTO Then
                    ComboDepartamento.SelectedItem = d
                    Exit For
                End If
            Next
            ComboLocalidad.SelectedItem = Nothing
            Dim l As dLocalidad
            For Each l In ComboLocalidad.Items
                If l.ID = pro.IDLOCALIDAD Then
                    ComboLocalidad.SelectedItem = l
                    Exit For
                End If
            Next
            ComboTecnicos.SelectedItem = Nothing
            Dim t As dCliente
            For Each t In ComboTecnicos.Items
                If t.ID = pro.TECNICO Then
                    ComboTecnicos.SelectedItem = t
                    Exit For
                End If
            Next
            ComboTecnicos2.SelectedItem = Nothing
            Dim t2 As dCliente
            For Each t2 In ComboTecnicos2.Items
                If t2.ID = pro.TECNICO2 Then
                    ComboTecnicos2.SelectedItem = t2
                    Exit For
                End If
            Next
            ComboTecnicos3.SelectedItem = Nothing
            Dim t3 As dCliente
            For Each t3 In ComboTecnicos3.Items
                If t3.ID = pro.TECNICO3 Then
                    ComboTecnicos3.SelectedItem = t3
                    Exit For
                End If
            Next
            ComboAgencia.SelectedItem = Nothing
            Dim a As dEmpresaT
            For Each a In ComboAgencia.Items
                If a.ID = pro.IDAGENCIA Then
                    ComboAgencia.SelectedItem = a
                    Exit For
                End If
            Next
            If pro.CONTRATO = 1 Then
                CheckContrato.Checked = True
            Else
                CheckContrato.Checked = False
            End If
            If pro.SOCIO = 1 Then
                CheckSocio.Checked = True
            Else
                CheckSocio.Checked = False
            End If
            If pro.NOUSAR = 1 Then
                CheckNousar.Checked = True
            Else
                CheckNousar.Checked = False
            End If
            If pro.MOROSO = 1 Then
                CheckMoroso.Checked = True
            Else
                CheckMoroso.Checked = False
            End If
            If pro.CONTADO = 1 Then
                CheckContado.Checked = True
            Else
                CheckContado.Checked = False
            End If
            If pro.CARAVANAS = 1 Then
                CheckCaravanas.Checked = True
            Else
                CheckCaravanas.Checked = False
            End If
            If pro.PROLESA = 1 Then
                CheckProlesa.Checked = True
            Else
                CheckProlesa.Checked = False
            End If
            TextObservaciones.Text = pro.OBSERVACIONES
            TextId.Focus()
        End If
    End Sub

    Private Sub TextBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBuscar.TextChanged
        Dim nombre As String = TextBuscar.Text.Trim
        ListProductores.Items.Clear()
        If nombre.Length > 0 Then
            Dim unPro As New dCliente
            Dim lista As New ArrayList
            lista = unPro.buscarPorNombreTodos(nombre)
            If Not lista Is Nothing And lista.Count > 0 Then

                For Each s As dProductor In lista
                    ListProductores.Items.Add(s)
                Next
                ListProductores.Sorted = True
            End If
        Else : ListProductores.Items.Clear()
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
        TextEmail1.Text = ""
        TextEmail2.Text = ""
        TextEmail3.Text = ""
        TextEnvio.Text = ""
        TextUsuarioWeb.Text = ""
        TextRazonSocial.Text = ""
        TextTelefono1.Text = ""
        TextTelefono2.Text = ""
        TextTelefono3.Text = ""
        TextCelular1.Text = ""
        TextCelular2.Text = ""
        TextCelular3.Text = ""
        TextRut.Text = ""
        TextFigaro.Text = ""
        ComboTipoUsuario.Text = ""
        TextDireccion.Text = ""
        TextFax.Text = ""
        TextDicose.Text = ""
        ComboDepartamento.Text = ""
        ComboLocalidad.Text = ""
        ComboTecnicos.Text = ""
        ComboTecnicos2.Text = ""
        ComboTecnicos3.Text = ""
        ComboAgencia.Text = ""
        CheckContrato.Checked = False
        CheckSocio.Checked = False
        CheckNousar.Checked = False
        CheckMoroso.Checked = False
        CheckContado.Checked = False
        CheckCaravanas.Checked = False
        CheckProlesa.Checked = False
        TextObservaciones.Text = ""
        TextId.Focus()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        cargarLista()
        limpiar()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim nombre As String = TextNombre.Text.Trim
        Dim email1 As String = TextEmail1.Text.Trim
        Dim email2 As String = TextEmail2.Text.Trim
        Dim email3 As String = TextEmail3.Text.Trim
        Dim envio As String = TextEnvio.Text.Trim
        'If TextUsuarioWeb.Text.Trim.Length = 0 Then MsgBox("Debe ingresar usuario web", MsgBoxStyle.Exclamation, "Atención") : TextUsuarioWeb.Focus() : Exit Sub
        Dim usuarioweb As String = TextUsuarioWeb.Text.Trim
        Dim razonsocial As String = TextRazonSocial.Text.Trim
        Dim telefono2 As String = TextTelefono2.Text.Trim
        Dim telefono3 As String = TextTelefono3.Text.Trim
        Dim celular1 As String = TextCelular1.Text.Trim
        Dim celular2 As String = TextCelular2.Text.Trim
        Dim celular3 As String = TextCelular3.Text.Trim
        Dim rut As String = TextRut.Text.Trim
        Dim figaro As String = TextFigaro.Text.Trim
        Dim tipousuario As dTipoUsuario = CType(ComboTipoUsuario.SelectedItem, dTipoUsuario)
        Dim direccion As String = TextDireccion.Text.Trim
        Dim telefono1 As String = TextTelefono1.Text.Trim
        Dim fax As String = TextFax.Text.Trim
        Dim dicose As String = TextDicose.Text.Trim
        Dim departamento As dDepartamento = CType(ComboDepartamento.SelectedItem, dDepartamento)
        Dim localidad As dLocalidad = CType(ComboLocalidad.SelectedItem, dLocalidad)
        Dim tecnico As dCliente = CType(ComboTecnicos.SelectedItem, dCliente)
        Dim tecnico2 As dCliente = CType(ComboTecnicos2.SelectedItem, dCliente)
        Dim tecnico3 As dCliente = CType(ComboTecnicos3.SelectedItem, dCliente)
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
        Dim moroso As Integer
        If CheckMoroso.Checked = True Then
            moroso = 1
        Else
            moroso = 0
        End If
        Dim contado As Integer
        If CheckContado.Checked = True Then
            contado = 1
        Else
            contado = 0
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
        Dim observaciones As String = ""
        If TextObservaciones.Text <> "" Then
            observaciones = TextObservaciones.Text.Trim
        End If
        If Not ListProductores.SelectedItem Is Nothing And TextId.Text.Trim.Length > 0 Then
            If TextNombre.Text.Trim.Length > 0 Then
                Dim pro As New dProductor()
                Dim pw_com As New dProductorWeb_com
                Dim nocargaenweb As Integer = 0
                'Dim pw_uy As New dProductorWeb_uy
                pw_com.USUARIO = TextUsuarioWeb.Text.Trim
                pw_com = pw_com.buscar
                Dim idproductorweb_com As Long
                'Dim idproductorweb_uy As Long


                If Not pw_com Is Nothing Then
                    idproductorweb_com = pw_com.ID
                Else
                    Dim result = MessageBox.Show("No existe el usuario web, desea continuar de todos modos?", "Atención", MessageBoxButtons.YesNo)
                    If result = DialogResult.No Then
                        Exit Sub
                    ElseIf result = DialogResult.Yes Then
                        nocargaenweb = 1
                        'idproductorweb_com = 4119
                    End If

                End If
                'pw_uy.USUARIO = TextUsuarioWeb.Text.Trim
                'pw_uy = pw_uy.buscar
                'If Not pw_uy Is Nothing Then
                'idproductorweb_uy = pw_uy.ID
                'Else
                'MsgBox("No existe el usuario web (.uy)")
                'Exit Sub
                'End If

                'NET*************************************
                Dim id As Long = TextId.Text.Trim
                pro.ID = id
                pro.NOMBRE = nombre
                pro.EMAIL1 = email1
                pro.EMAIL2 = email2
                pro.EMAIL3 = email3
                pro.ENVIO = envio
                pro.USUARIO_WEB = usuarioweb
                pro.RAZON_SOCIAL = razonsocial
                pro.TELEFONO_2 = telefono2
                pro.TELEFONO_3 = telefono3
                pro.CELULAR_1 = celular1
                pro.CELULAR_2 = celular2
                pro.CELULAR_3 = celular3
                pro.RUT = rut
                pro.CODIGOFIGARO = figaro
                pro.TIPOUSUARIO = tipousuario.ID
                pro.DIRECCION = direccion
                pro.TELEFONO = telefono1
                pro.FAX = fax
                pro.DICOSE = dicose
                If departamento Is Nothing Then
                    pro.IDDEPARTAMENTO = 999
                Else
                    pro.IDDEPARTAMENTO = departamento.ID
                End If
                If localidad Is Nothing Then
                    pro.IDLOCALIDAD = 999
                Else
                    pro.IDLOCALIDAD = localidad.ID
                End If
                If tecnico Is Nothing Then
                    pro.TECNICO = 3282
                Else
                    pro.TECNICO = tecnico.ID
                End If
                If tecnico2 Is Nothing Then
                    pro.TECNICO2 = 3282
                Else
                    pro.TECNICO2 = tecnico2.ID
                End If
                If tecnico3 Is Nothing Then
                    pro.TECNICO3 = 3282
                Else
                    pro.TECNICO3 = tecnico3.ID
                End If
                If Not agencia Is Nothing Then
                    pro.IDAGENCIA = agencia.ID
                End If
                pro.CONTRATO = contrato
                pro.SOCIO = socio
                pro.NOUSAR = nousar
                pro.MOROSO = moroso
                pro.CONTADO = contado
                pro.CARAVANAS = caravanas
                pro.PROLESA = prolesa
                pro.OBSERVACIONES = observaciones
                'COM**********************************
                If nocargaenweb = 0 Then
                    pw_com.ID = idproductorweb_com
                    pw_com.NOMBRE = nombre
                    pw_com.EMAIL_1 = email1
                    pw_com.EMAIL_2 = email2
                    pw_com.EMAIL_3 = email3
                    pw_com.USUARIO = usuarioweb
                    pw_com.PASSWORD = usuarioweb
                    pw_com.RAZON_SOCIAL = razonsocial
                    pw_com.TELEFONO_2 = telefono2
                    pw_com.TELEFONO_3 = telefono3
                    pw_com.CELULAR_1 = celular1
                    pw_com.CELULAR_2 = celular2
                    pw_com.CELULAR_3 = celular3
                    pw_com.RUT = rut
                    pw_com.CODIGOFIGARO = figaro
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
                'UY****************************************
                'pw_uy.ID = idproductorweb_com
                'pw_uy.NOMBRE = nombre
                'pw_uy.EMAIL_1 = email1
                'pw_uy.EMAIL_2 = email2
                'pw_uy.EMAIL_3 = email3
                'pw_uy.USUARIO = usuarioweb
                'pw_uy.PASSWORD = usuarioweb
                'pw_uy.RAZON_SOCIAL = razonsocial
                'pw_uy.TELEFONO_2 = telefono2
                'pw_uy.TELEFONO_3 = telefono3
                'pw_uy.CELULAR_1 = celular1
                'pw_uy.CELULAR_2 = celular2
                'pw_uy.CELULAR_3 = celular3
                'pw_uy.RUT = rut
                'pw_uy.CODIGOFIGARO = figaro
                'pw_uy.TIPO_USUARIO_ID = tipousuario.ID
                'pw_uy.DIRECCION = direccion
                'pw_uy.TELEFONO_1 = telefono1
                'pw_uy.DICOSE = dicose
                'pw_uy.VER_CONTROL_LECHERO = 1
                'pw_uy.VER_AGUA = 1
                'pw_uy.VER_PAL = 1
                'pw_uy.VER_SEROLOGIA = 1
                'pw_uy.VER_ANTIBIOGRAMA = 1
                'pw_uy.VER_PARASITOLOGIA = 1
                'pw_uy.VER_PRODUCTOS_SUBPRODUCTOS = 1
                'pw_uy.VER_PATOLOGIA = 1
                'pw_uy.VER_CALIDAD_DE_LECHE = 1

                If (pro.modificar(Usuario)) Then
                    If nocargaenweb = 0 Then
                        pw_com.modificar(Usuario)
                    End If
                    'pw_uy.modificar(Usuario)

                    MsgBox("Productor modificado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        Else
            If TextNombre.Text.Trim.Length > 0 Then
                Dim pro As New dProductor()
                Dim pw_com As New dProductorWeb_com
                'Dim pw_uy As New dProductorWeb_uy
                'NET***********************************
                'pro.ID = id
                pro.NOMBRE = nombre
                pro.EMAIL1 = email1
                pro.EMAIL2 = email2
                pro.EMAIL3 = email3
                pro.ENVIO = envio
                pro.USUARIO_WEB = usuarioweb
                prodweb_com = usuarioweb
                pro.RAZON_SOCIAL = razonsocial
                pro.TELEFONO_2 = telefono2
                pro.TELEFONO_3 = telefono3
                pro.CELULAR_1 = celular1
                pro.CELULAR_2 = celular2
                pro.CELULAR_3 = celular3
                pro.RUT = rut
                pro.CODIGOFIGARO = figaro
                pro.TIPOUSUARIO = tipousuario.ID
                pro.DIRECCION = direccion
                pro.TELEFONO = telefono1
                pro.FAX = fax
                pro.DICOSE = dicose
                If departamento Is Nothing Then
                    pro.IDDEPARTAMENTO = 999
                Else
                    pro.IDDEPARTAMENTO = departamento.ID
                End If
                If localidad Is Nothing Then
                    pro.IDLOCALIDAD = 999
                Else
                    pro.IDLOCALIDAD = localidad.ID
                End If
                If tecnico Is Nothing Then
                    pro.TECNICO = 3282
                Else
                    pro.TECNICO = tecnico.ID
                End If
                If tecnico2 Is Nothing Then
                    pro.TECNICO2 = 3282
                Else
                    pro.TECNICO2 = tecnico2.ID
                End If
                If tecnico3 Is Nothing Then
                    pro.TECNICO3 = 3282
                Else
                    pro.TECNICO3 = tecnico3.ID
                End If
                If Not agencia Is Nothing Then
                    pro.IDAGENCIA = agencia.ID
                End If
                pro.CONTRATO = contrato
                pro.SOCIO = socio
                pro.NOUSAR = nousar
                pro.MOROSO = moroso
                pro.CONTADO = contado
                pro.CARAVANAS = caravanas
                pro.PROLESA = prolesa
                pro.OBSERVACIONES = observaciones
                'COM**********************************
                'pw_com.ID = idproductorweb_com
                pw_com.NOMBRE = nombre
                pw_com.EMAIL_1 = email1
                pw_com.EMAIL_2 = email2
                pw_com.EMAIL_3 = email3
                pw_com.USUARIO = usuarioweb
                pw_com.PASSWORD = usuarioweb
                prodweb_uy = usuarioweb
                pw_com.RAZON_SOCIAL = razonsocial
                pw_com.TELEFONO_2 = telefono2
                pw_com.TELEFONO_3 = telefono3
                pw_com.CELULAR_1 = celular1
                pw_com.CELULAR_2 = celular2
                pw_com.CELULAR_3 = celular3
                pw_com.RUT = rut
                pw_com.CODIGOFIGARO = figaro
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

                'UY****************************************
                'pw_uy.NOMBRE = nombre
                'pw_uy.EMAIL_1 = email1
                'pw_uy.EMAIL_2 = email2
                'pw_uy.EMAIL_3 = email3
                'pw_uy.USUARIO = usuarioweb
                'pw_uy.PASSWORD = usuarioweb
                'pw_uy.RAZON_SOCIAL = razonsocial
                'pw_uy.TELEFONO_2 = telefono2
                'pw_uy.TELEFONO_3 = telefono3
                'pw_uy.CELULAR_1 = celular1
                'pw_uy.CELULAR_2 = celular2
                'pw_uy.CELULAR_3 = celular3
                'pw_uy.RUT = rut
                'pw_uy.CODIGOFIGARO = figaro
                'pw_uy.TIPO_USUARIO_ID = tipousuario.ID
                'pw_uy.DIRECCION = direccion
                'pw_uy.TELEFONO_1 = telefono1
                'pw_uy.DICOSE = dicose
                'pw_uy.VER_CONTROL_LECHERO = 1
                'pw_uy.VER_AGUA = 1
                'pw_uy.VER_PAL = 1
                'pw_uy.VER_SEROLOGIA = 1
                'pw_uy.VER_ANTIBIOGRAMA = 1
                'pw_uy.VER_PARASITOLOGIA = 1
                'pw_uy.VER_PRODUCTOS_SUBPRODUCTOS = 1
                'pw_uy.VER_PATOLOGIA = 1
                'pw_uy.VER_CALIDAD_DE_LECHE = 1
                '**********************************************
                'CIFRA LA CONTRASEÑA DEL PRODUCTOR
                'Dim cadena As String = usuarioweb
                'generarClaveSHA1(cadena)
                'pw_com.PASSWORD = password_cifrado
                '**********************************************
                If (pro.guardar(Usuario)) Then
                    pw_com.guardar(Usuario)
                    'pw_uy.guardar(Usuario)
                    crearcarpetas_com()
                    'crearcarpetas_uy()
                    MsgBox("Productor guardado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        cargarLista()
    End Sub
    Private Sub crearcarpetas_com()
        Dim pw_com As New dProductorWeb_com
        pw_com.USUARIO = prodweb_com
        pw_com = pw_com.buscar
        If Not pw_com Is Nothing Then
            carpeta = pw_com.ID
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
    Private Sub crearcarpetas_uy()
        Dim pw_uy As New dProductorWeb_uy
        pw_uy.USUARIO = prodweb_uy
        pw_uy = pw_uy.buscar
        If Not pw_uy Is Nothing Then
            carpeta = pw_uy.ID
        Else
            MsgBox("No existe el usuario web (.com)")
        End If
        crea_carpeta_uy()
        crea_agro_nutricion_uy()
        crea_agua_uy()
        crea_ambiental_uy()
        crea_antibiograma_uy()
        crea_calidad_de_leche_uy()
        crea_control_lechero_uy()
        crea_lactometros_chequeos_maquina_uy()
        crea_otros_servicios_uy()
        crea_pal_uy()
        crea_parasitologia_uy()
        crea_patologia_uy()
        crea_productos_subproductos_uy()
        crea_serologia_uy()
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
        Dim t As New dCliente
        Dim lista As New ArrayList
        lista = t.listar
        ComboTecnicos.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each t In lista
                    ComboTecnicos.Items.Add(t)
                    ComboTecnicos2.Items.Add(t)
                    ComboTecnicos3.Items.Add(t)
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
            Dim idproductor As Long = TextId.Text.Trim
            Dim v As New FormProductorEmpresa(Usuario, idproductor)
            v.ShowDialog()
        End If
    End Sub
    Public Sub crea_carpeta_com()
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
    Public Sub crea_carpeta_uy()
        Dim pweb_com As New dProductorWeb_uy
        Dim user As String = "colav0"
        Dim pass As String = "colaveco5311"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
    Public Sub crea_control_lechero_uy()
        Dim pweb_com As New dProductorWeb_uy
        Dim user As String = "colav0"
        Dim pass As String = "colaveco5311"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
    Public Sub crea_agua_uy()
        Dim pweb_com As New dProductorWeb_uy
        Dim user As String = "colav0"
        Dim pass As String = "colaveco5311"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
    Public Sub crea_antibiograma_uy()
        Dim pweb_com As New dProductorWeb_uy
        Dim user As String = "colav0"
        Dim pass As String = "colaveco5311"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
    Public Sub crea_pal_uy()
        Dim pweb_com As New dProductorWeb_uy
        Dim user As String = "colav0"
        Dim pass As String = "colaveco5311"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
    Public Sub crea_parasitologia_uy()
        Dim pweb_com As New dProductorWeb_uy
        Dim user As String = "colav0"
        Dim pass As String = "colaveco5311"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
    Public Sub crea_productos_subproductos_uy()
        Dim pweb_com As New dProductorWeb_uy
        Dim user As String = "colav0"
        Dim pass As String = "colaveco5311"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
    Public Sub crea_serologia_uy()
        Dim pweb_com As New dProductorWeb_uy
        Dim user As String = "colav0"
        Dim pass As String = "colaveco5311"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
    Public Sub crea_patologia_uy()
        Dim pweb_com As New dProductorWeb_uy
        Dim user As String = "colav0"
        Dim pass As String = "colaveco5311"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
    Public Sub crea_calidad_de_leche_uy()
        Dim pweb_com As New dProductorWeb_uy
        Dim user As String = "colav0"
        Dim pass As String = "colaveco5311"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
    Public Sub crea_ambiental_uy()
        Dim pweb_com As New dProductorWeb_uy
        Dim user As String = "colav0"
        Dim pass As String = "colaveco5311"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
    Public Sub crea_lactometros_chequeos_maquina_uy()
        Dim pweb_com As New dProductorWeb_uy
        Dim user As String = "colav0"
        Dim pass As String = "colaveco5311"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
    Public Sub crea_agro_nutricion_uy()
        Dim pweb_com As New dProductorWeb_uy
        Dim user As String = "colav0"
        Dim pass As String = "colaveco5311"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
    Public Sub crea_otros_servicios_uy()
        Dim pweb_com As New dProductorWeb_uy
        Dim user As String = "colav0"
        Dim pass As String = "colaveco5311"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
End Class