Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections
Imports System.Net.FtpWebRequest
Imports System.Net
Imports Newtonsoft.Json
Public Class FormSolicitudAnalisis
    Private productorweb_com As String
    Private idproductorweb_com As Long
    Private idficha As String
    Private tipoinforme As String
    Private _usuario As dUsuario
    Private email As String
    Private celular As String
    Private nficha As String
    Private idprod As Long = 0
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario, ByVal idpro As Long)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarComboInformes()
        cargarComboSubInformes()
        cargarComboTecnicos()
        cargarComboTipoFicha()
        'cargarComboMuestras()
        cargarComboAgencia()
        cargarComboCajas()
        limpiar()
        buscarultimaficha()
        idprod = idpro
        If idprod <> 0 Then
            Dim pro As New dCliente
            pro.ID = idprod
            pro = pro.buscar
            If Not pro Is Nothing Then
                'TextIdProductor.Text = pro.ID
                'TextProductor.Text = pro.NOMBRE
                If pro.CONTRATO = 0 Then
                    MsgBox("El cliente no tiene contrato firmado.")
                End If
                'If pro.MOROSO = 1 Then
                '    MsgBox("El cliente tiene deuda, no se puede continuar con la solicitud.")
                '    '/*Comentado por pedido de Noelia, asi no tienen que salir y desmarcar moroso
                '    'TextIdProductor.Text = ""
                '    'TextProductor.Text = ""
                '    'TextDicose.Text = ""
                '    'ComboTecnico.SelectedItem = Nothing
                '    'Exit Sub
                'End If
                TextIdProductor.Text = pro.ID
                TextProductor.Text = pro.NOMBRE
                TextDicose.Text = pro.DICOSE
                ComboTecnico.SelectedItem = Nothing
                Dim t As dCliente
                For Each t In ComboTecnico.Items
                    If t.ID = pro.TECNICO1 Then
                        ComboTecnico.SelectedItem = t
                        Exit For
                    End If
                Next
                guardar()
                ComboTipoInforme.Focus()
            End If
        End If
    End Sub
#End Region
    Private Sub buscarultimaficha()
        Dim ultimaf As New dUltimoNumero
        ultimaf = ultimaf.buscar
        TextId.Text = ultimaf.FICHAS + 1
    End Sub
    Public Sub cargarComboCajas()
        Dim c As New dCajas
        Dim lista As New ArrayList
        lista = c.listarenClientes
        ComboCajas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    ComboCajas.Items.Add(c)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboTecnicos()
        Dim t As New dCliente
        Dim lista As New ArrayList
        lista = t.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each t In lista
                    ComboTecnico.Items.Add(t)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboInformes()
        Dim ti As New dTipoInforme
        Dim lista As New ArrayList
        lista = ti.listar_viejos
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ti In lista
                    ComboTipoInforme.Items.Add(ti)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboSubInformes()
        Dim si As New dSubInforme
        Dim lista As New ArrayList
        lista = si.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each si In lista
                    ComboSubInforme.Items.Add(si)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboMuestras()
        Dim m As New dMuestras
        Dim lista As New ArrayList
        Dim idtipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        Dim texto As Long = idtipoinforme.ID
        ComboMuestra.Items.Clear()
        lista = m.listarxinforme(texto)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each m In lista
                    ComboMuestra.Items.Add(m)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboTipoFicha()
        Dim tf As New dTipoFicha
        Dim lista As New ArrayList
        lista = tf.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each tf In lista
                    ComboTipoFicha.Items.Add(tf)
                Next
            End If
        End If
        ComboTipoFicha.SelectedIndex = 0
    End Sub
    Private Sub ButtonBuscarProductor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProductor.Click
        If TextId.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de ficha", MsgBoxStyle.Exclamation, "Atención") : TextId.Focus() : Exit Sub
        Dim v As New FormBuscarCliente
        v.ShowDialog()
        productorweb_com = ""
        If Not v.Cliente Is Nothing Then
            Dim cli As dCliente = v.Cliente
            '*** ROBOT SE ENCARGA DE ESTO **********************
            'productorweb_com = pro.USUARIO_WEB
            'Dim pw_com As New dProductorWeb_com
            'pw_com.USUARIO = productorweb_com
            'pw_com = pw_com.buscar
            'If Not pw_com Is Nothing Then
            '    idproductorweb_com = pw_com.ID
            '    email = RTrim(pw_com.ENVIAR_EMAIL)
            '    celular = Replace(pw_com.ENVIAR_SMS, " ", "")
            'Else
            '    MsgBox("No coincide el usuario web (.com)")
            '    'comentado por error en la web
            '    'Exit Sub
            'End If
            '*** FIN ROBOT *************************************
            If cli.CONTRATO = 0 Then
                MsgBox("El cliente no tiene contrato firmado.")
            End If
            If cli.FAC_CONTADO = 1 Then
                MsgBox("Este cliente es solo CONTADO!")
            End If
            If cli.PROLESA = 1 Then
                MsgBox("Este cliente es de PROLESA!")
            End If
            '*** VERIFICA SI EL CLIENTE TIENE DEUDA ***************************************
            Dim mc As New dMovCte
            Dim listamc As New ArrayList
            Dim idcli As Long = cli.ID
            Dim fechaactual As Date = Now.ToString("yyyy-MM-dd")
            Dim fechaact As String = Format(fechaactual, "yyyy-MM-dd")
            Dim vencido As Integer = 0
            listamc = mc.listarxcli(idcli)
            If Not listamc Is Nothing Then
                For Each mc In listamc
                    Dim fechavto As Date = mc.MCCVTO
                    Dim fecvto As String = Format(fechavto, "yyyy-MM-dd")
                    If fecvto < fechaact Then
                        If mc.MCCPAG < mc.MCCIMP Then
                            Dim diferencia As Double = 0
                            diferencia = mc.MCCIMP - mc.MCCPAG
                            If diferencia > 100 Then
                                vencido = 1
                            End If
                        End If
                    End If
                Next
            End If
            If vencido = 1 Then
                MsgBox("El cliente tiene deuda, no se puede continuar con la solicitud.")
            End If
            '*******************************************************************************
            'If cli.MOROSO = 1 Then
            '    MsgBox("El cliente tiene deuda, no se puede continuar con la solicitud.")
            '/*Comentado por pedido de Noelia, asi no tienen que salir y desmarcar moroso
            'TextIdProductor.Text = ""
            'TextProductor.Text = ""
            'TextDicose.Text = ""
            'ComboTecnico.SelectedItem = Nothing
            'Exit Sub
            'End If
            TextIdProductor.Text = cli.ID
            TextProductor.Text = cli.NOMBRE
            TextDicose.Text = cli.DICOSE
            ComboTecnico.SelectedItem = Nothing
            Dim t As dCliente
            For Each t In ComboTecnico.Items
                If t.ID = cli.TECNICO1 Then
                    ComboTecnico.SelectedItem = t
                    Exit For
                End If
            Next
            ComboTipoInforme.Focus()
        End If
        guardar()
        If TextId.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de ficha", MsgBoxStyle.Exclamation, "Atención") : TextId.Focus() : Exit Sub
    End Sub
    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        'InsertarRegistro_com()
        'CONTROLA QUE SE INGRESARON CAJAS ******************************************************************
        Dim idtipoinforme2 As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        If Not idtipoinforme2 Is Nothing Then
            Dim tipoinforme As Integer = idtipoinforme2.ID
            If tipoinforme = 1 Then
                If ListCajas.Items.Count = 0 And TextOtros.Text = "" Then
                    MsgBox("Debe completar algún campo en cajas recibidas!")
                    Exit Sub
                End If
            End If
            If tipoinforme = 3 Then
                If ListCajas.Items.Count = 0 And TextOtros.Text = "" Then
                    MsgBox("Debe completar algún campo en cajas recibidas!")
                    Exit Sub
                End If
            End If
        End If
        '****************************************************************************************************
        tipoinforme = ComboTipoInforme.Text
        If TextId.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de ficha", MsgBoxStyle.Exclamation, "Atención") : TextId.Focus() : Exit Sub
        Dim id As Long = TextId.Text.Trim
        Dim fechaingreso As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
        If TextIdProductor.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de productor", MsgBoxStyle.Exclamation, "Atención") : TextIdProductor.Focus() : Exit Sub
        Dim idproductor As Long = TextIdProductor.Text.Trim
        Dim idtipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        Dim idsubinforme As dSubInforme = CType(ComboSubInforme.SelectedItem, dSubInforme)
        Dim idtipoficha As dTipoFicha = CType(ComboTipoFicha.SelectedItem, dTipoFicha)
        Dim observaciones As String = TextObservaciones.Text.Trim
        If aguaclorada = 1 Then
            observaciones = observaciones & " - *** CLORADA ***"
            If observaciones <> "" Then
                TextObservaciones.Text = observaciones
            End If
            aguaclorada = 0
        End If
        Dim nmuestras As Integer
        If TextNMuestras.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado cantidad de muestras", MsgBoxStyle.Exclamation, "Atención") : TextNMuestras.Focus() : Exit Sub
        nmuestras = TextNMuestras.Text.Trim
        Dim idmuestra As dMuestras = CType(ComboMuestra.SelectedItem, dMuestras)
        Dim idtecnico As dCliente = CType(ComboTecnico.SelectedItem, dCliente)
        Dim sinsolicitud As Integer
        If CheckSinSolicitud.Checked = True Then
            sinsolicitud = 1
        Else
            sinsolicitud = 0
        End If
        Dim sinconservante As Integer
        If CheckSinConservante.Checked = True Then
            sinconservante = 1
        Else
            sinconservante = 0
        End If
        Dim temperatura As Double
        If TextTemperatura.Text <> "" Then
            temperatura = TextTemperatura.Text.Trim
        Else
            If idtipoinforme.ID = 1 Or idtipoinforme.ID = 10 Or idtipoinforme.ID = 3 Or idtipoinforme.ID = 4 Or idtipoinforme.ID = 7 Or idtipoinforme.ID = 11 Then
                MsgBox("Falta ingresar temperatura de arribo!")
                TextTemperatura.Focus()
                Exit Sub
            End If
        End If
        Dim derramadas As Integer
        If CheckDerramadas.Checked = True Then
            derramadas = 1
        Else
            derramadas = 0
        End If
        Dim desvioautorizado As Integer
        If CheckDesvio.Checked = True Then
            desvioautorizado = 1
        Else
            desvioautorizado = 0
        End If
        Dim idfactura As Long
        If TextIdFactura.Text <> "" Then
            idfactura = TextIdFactura.Text.Trim
        End If
        Dim web As Integer
        If CheckWeb.Checked = True Then
            web = 1
        Else
            web = 0
        End If
        Dim personal As Integer
        If CheckPersonal.Checked = True Then
            personal = 1
        Else
            personal = 0
        End If
        Dim mail As Integer
        If CheckEmail.Checked = True Then
            mail = 1
        Else
            mail = 0
        End If
        Dim fechaenvio As Date = DateFechaEnvio.Value.ToString("yyyy-MM-dd")
        Dim ultimaficha As Long = TextId.Text.Trim
        Dim sm As New dRelSolicitudMuestras
        sm.FICHA = id
        sm = sm.buscar
        If tipoinforme = "Calidad de leche" Or tipoinforme = "Control Lechero" Or tipoinforme = "PAL" Or tipoinforme = "Serología" Or tipoinforme = "Nutrición" Or tipoinforme = "Suelos" Then
        Else
            If Not sm Is Nothing Then
            Else
                MsgBox("No se han ingresado muestras", MsgBoxStyle.Exclamation, "Atención") : TextMuestras.Focus() : Exit Sub
            End If
        End If
        Dim pago As Integer = 0
        If CheckPago.Checked = True Then
            pago = 1
        Else
            pago = 0
        End If
        Dim kmts As Integer = 0
        If TextKmts.Text <> "" Then
            kmts = TextKmts.Text.Trim
        End If
        If TextId.Text.Trim.Length > 0 Then
            Dim sol As New dSolicitudAnalisis()
            Dim sw As New dSolicitudWeb
            Dim un As New dUltimoNumero
            un = un.buscar
            Dim fecing As String
            Dim fecenv As String
            fecing = Format(fechaingreso, "yyyy-MM-dd")
            fecenv = Format(fechaenvio, "yyyy-MM-dd")
            sol.ID = id
            sol.FECHAINGRESO = fecing
            sol.IDPRODUCTOR = idproductor
            If Not idtipoinforme Is Nothing Then
                sol.IDTIPOINFORME = idtipoinforme.ID
            End If
            If Not idsubinforme Is Nothing Then
                sol.IDSUBINFORME = idsubinforme.ID
            End If
            If Not idtipoficha Is Nothing Then
                sol.IDTIPOFICHA = idtipoficha.ID
            End If
            sol.OBSERVACIONES = observaciones
            sol.NMUESTRAS = nmuestras
            If Not idmuestra Is Nothing Then
                sol.IDMUESTRA = idmuestra.ID
            End If
            If Not idtecnico Is Nothing Then
                sol.IDTECNICO = idtecnico.ID
            End If
            sol.SINCOLICITUD = sinsolicitud
            sol.SINCONSERVANTE = sinconservante
            sol.TEMPERATURA = temperatura
            sol.DERRAMADAS = derramadas
            sol.DESVIOAUTORIZADO = desvioautorizado
            sol.IDFACTURA = idfactura
            sol.WEB = web
            sol.PERSONAL = personal
            sol.EMAIL = mail
            sol.FECHAENVIO = fecenv
            sol.PAGO = pago
            sol.KMTS = kmts
            sol.FECHAPROCESO = fecenv
            sw.FICHA = id
            sw.GESTOR = 0
            If (sol.modificar(Usuario)) Then
                If ultimaficha > un.FICHAS Then
                    un.FICHAS = ultimaficha
                    un.modificar()
                End If
                sw.guardar(Usuario)
                MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                '*** ESTO LO HACE ROBOT ******
                'enviomail()
                'enviosms()
                '*** FIN ROBOT ***************
                facturacion()
                imprimir_solicitud()
                Dim result2 = MessageBox.Show("Desea imprimir un ticket para el cliente?", "Atención!", MessageBoxButtons.YesNoCancel)
                If result2 = DialogResult.Cancel Then
                    imprimir_ticket3()
                ElseIf result2 = DialogResult.No Then
                    imprimir_ticket3()
                ElseIf result2 = DialogResult.Yes Then
                    Dim result5 = MessageBox.Show("Desea imprimir un ticket para el cliente con usuario y contraseña?", "Atención!", MessageBoxButtons.YesNoCancel)
                    If result5 = DialogResult.Cancel Then
                        imprimir_ticket2()
                    ElseIf result5 = DialogResult.No Then
                        imprimir_ticket2()
                    Else
                        imprimir_ticket2_cliente()
                    End If
                End If
                If idsubinforme.ID = 22 Then
                    Dim r As New dRosaBengalaDescarte
                    r.FICHA = id
                    r.FECHA = fecing
                    r.DESCARTADA = 0
                    r.FECHAD = fecing
                    r.MARCADA = 0
                    r.FECHAM = fecing
                    r.guardar(Usuario)
                End If
                If idproductor = 4870 Then
                    Dim result = MessageBox.Show("Enviar e-mail a PULSA S.A. con la solicitud de análisis? (Antes de enviar debe cerrar excel)", "Atención!", MessageBoxButtons.YesNoCancel)
                    If result = DialogResult.Cancel Then
                    ElseIf result = DialogResult.No Then
                    ElseIf result = DialogResult.Yes Then
                        enviomailpulsa()
                    End If
                End If
                limpiar()
                limpiar2()
                ' Grabar estado de la ficha
                Dim est As New dEstados
                est.FICHA = id
                est.ESTADO = 1
                est.FECHA = fecing
                est.guardar(Usuario)
                est = Nothing
                '****************************
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            If TextIdProductor.Text.Trim.Length > 0 Then
                Dim sol As New dSolicitudAnalisis()
                Dim un As New dUltimoNumero
                un = un.buscar
                Dim fecing As String
                Dim fecenv As String
                fecing = Format(fechaingreso, "yyyy-MM-dd")
                fecenv = Format(fechaenvio, "yyyy-MM-dd")
                sol.ID = id
                sol.FECHAINGRESO = fecing
                sol.IDPRODUCTOR = idproductor
                If Not idtipoinforme Is Nothing Then
                    sol.IDTIPOINFORME = idtipoinforme.ID
                End If
                If Not idsubinforme Is Nothing Then
                    sol.IDSUBINFORME = idsubinforme.ID
                End If
                If Not idtipoficha Is Nothing Then
                    sol.IDTIPOFICHA = idtipoficha.ID
                End If
                sol.OBSERVACIONES = observaciones
                sol.NMUESTRAS = nmuestras
                If Not idtecnico Is Nothing Then
                    sol.IDTECNICO = idtecnico.ID
                End If
                sol.SINCOLICITUD = sinsolicitud
                sol.SINCONSERVANTE = sinconservante
                sol.TEMPERATURA = temperatura
                sol.DERRAMADAS = derramadas
                sol.DESVIOAUTORIZADO = desvioautorizado
                sol.IDFACTURA = idfactura
                sol.WEB = web
                sol.PERSONAL = personal
                sol.EMAIL = mail
                sol.FECHAENVIO = fecenv
                sol.PAGO = pago
                sol.KMTS = kmts
                sol.FECHAPROCESO = fecenv
                If (sol.guardar(Usuario)) Then
                    If ultimaficha > un.FICHAS Then
                        un.FICHAS = ultimaficha
                        un.modificar()
                    End If
                    MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    enviomail()
                    enviosms()
                    imprimir_solicitud()
                    Dim result3 = MessageBox.Show("Desea imprimir un ticket para el cliente?", "Atención!", MessageBoxButtons.YesNoCancel)
                    If result3 = DialogResult.Cancel Then
                        imprimir_ticket2()
                    ElseIf result3 = DialogResult.No Then
                        imprimir_ticket2()
                    ElseIf result3 = DialogResult.Yes Then
                        Dim result4 = MessageBox.Show("Desea imprimir un ticket para el cliente con usuario y contraseña?", "Atención!", MessageBoxButtons.YesNoCancel)
                        If result4 = DialogResult.Cancel Then
                            imprimir_ticket2()
                        ElseIf result4 = DialogResult.No Then
                            imprimir_ticket2()
                        Else
                            imprimir_ticket2_cliente()
                        End If
                    End If
                    If idsubinforme.ID = 22 Then
                        Dim r As New dRosaBengalaDescarte
                        r.FICHA = id
                        r.FECHA = fecing
                        r.DESCARTADA = 0
                        r.FECHAD = fecing
                        r.MARCADA = 0
                        r.FECHAM = fecing
                        r.guardar(Usuario)
                    End If
                    limpiar()
                    limpiar2()
                    ' Grabar estado de la ficha
                    Dim est As New dEstados
                    est.FICHA = id
                    est.ESTADO = 1
                    est.FECHA = fecing
                    est.guardar(Usuario)
                    '****************************
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        Me.Close()
    End Sub
    Private Sub facturacion()
        Dim sa As New dSolicitudAnalisis
        Dim ti As Integer = 0
        Dim sti As Integer = 0
        Dim ficha As Long = 0
        Dim muestras As Integer = 0
        ficha = TextId.Text.Trim
        sa.ID = TextId.Text.Trim
        sa = sa.buscar
        If Not sa Is Nothing Then
            ti = sa.IDTIPOINFORME
            sti = sa.IDSUBINFORME
            muestras = sa.NMUESTRAS
        End If
        If ti = 1 Then ' Control lechero
            factura_control()
        ElseIf ti = 3 Then 'Agua
            factura_agua()
        ElseIf ti = 4 Then 'ATB
            factura_atb()
        ElseIf ti = 6 Then
            factura_parasitologia()
        ElseIf ti = 7 Then 'Alimentos
            factura_subproductos()
        ElseIf ti = 8 Then 'Serología
            factura_serologia()
        ElseIf ti = 10 Then 'Calidad
            factura_calidad()
        ElseIf ti = 11 Then 'Ambiental
            factura_ambiental()
        ElseIf ti = 13 Then 'Nutrición
            factura_nutricion()
        ElseIf ti = 14 Then 'Suelos
            factura_suelos()
        ElseIf ti = 15 Then 'Brucelosis en leche
            factura_brucelosisleche()
        ElseIf ti = 16 Then 'Brucelosis en leche
            factura_efluentes()
        End If
    End Sub
    Private Sub factura_control()
        Dim sa As New dSolicitudAnalisis
        Dim ti As Integer = 0
        Dim sti As Integer = 0
        Dim ficha As Long = 0
        Dim muestras As Integer = 0
        ficha = TextId.Text.Trim
        sa.ID = TextId.Text.Trim
        sa = sa.buscar
        If Not sa Is Nothing Then
            ti = sa.IDTIPOINFORME
            sti = sa.IDSUBINFORME
            muestras = sa.NMUESTRAS
        End If
        Dim listamuestras As New ArrayList
        Dim total1 As Double = 0
        Dim total2 As Double = 0
        Dim total3 As Double = 0
        Dim total4 As Double = 0
        Dim lp As New dListaPrecios
        Dim idrc_comp As Integer = 116
        Dim idrc_comp_urea As Integer = 117
        Dim idrc_comp_caseina As Integer = 157
        Dim idrc_comp_urea_caseina As Integer = 158
        Dim preciorc_comp As Double
        Dim preciorc_comp_urea As Double
        Dim preciorc_comp_caseina As Double
        Dim preciorc_comp_urea_caseina As Double
        Dim c As New dCliente
        Dim precio As Integer = 0
        c.ID = TextIdProductor.Text.Trim
        c = c.buscar
        If Not c Is Nothing Then
            precio = c.FAC_LISTA
        End If
        If precio = 1 Then
            lp.ID = idrc_comp
            lp = lp.buscar
            preciorc_comp = lp.PRECIO1
            lp.ID = idrc_comp_urea
            lp = lp.buscar
            preciorc_comp_urea = lp.PRECIO1
            lp.ID = idrc_comp_caseina
            lp = lp.buscar
            preciorc_comp_caseina = lp.PRECIO1
            lp.ID = idrc_comp_urea_caseina
            lp = lp.buscar
            preciorc_comp_urea_caseina = lp.PRECIO1
        ElseIf precio = 2 Then
            lp.ID = idrc_comp
            lp = lp.buscar
            preciorc_comp = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciorc_comp = lp.PRECIO1
            End If
            lp.ID = idrc_comp_urea
            lp = lp.buscar
            preciorc_comp_urea = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciorc_comp_urea = lp.PRECIO1
            End If
            lp.ID = idrc_comp_caseina
            lp = lp.buscar
            preciorc_comp_caseina = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciorc_comp_caseina = lp.PRECIO1
            End If
            lp.ID = idrc_comp_urea_caseina
            lp = lp.buscar
            preciorc_comp_urea_caseina = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciorc_comp_urea_caseina = lp.PRECIO1
            End If
        ElseIf precio = 3 Then
            lp.ID = idrc_comp
            lp = lp.buscar
            preciorc_comp = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciorc_comp = lp.PRECIO1
            End If
            lp.ID = idrc_comp_urea
            lp = lp.buscar
            preciorc_comp_urea = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciorc_comp_urea = lp.PRECIO1
            End If
            lp.ID = idrc_comp_caseina
            lp = lp.buscar
            preciorc_comp_caseina = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciorc_comp_caseina = lp.PRECIO1
            End If
            lp.ID = idrc_comp_urea_caseina
            lp = lp.buscar
            preciorc_comp_urea_caseina = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciorc_comp_urea_caseina = lp.PRECIO1
            End If
        ElseIf precio = 4 Then
            lp.ID = idrc_comp
            lp = lp.buscar
            preciorc_comp = lp.PRECIO4
            lp.ID = idrc_comp_urea
            lp = lp.buscar
            preciorc_comp_urea = lp.PRECIO4
            lp.ID = idrc_comp_caseina
            lp = lp.buscar
            preciorc_comp_caseina = lp.PRECIO4
            lp.ID = idrc_comp_urea_caseina
            lp = lp.buscar
            preciorc_comp_urea_caseina = lp.PRECIO4
        ElseIf precio = 5 Then
            lp.ID = idrc_comp
            lp = lp.buscar
            preciorc_comp = lp.PRECIO5
            lp.ID = idrc_comp_urea
            lp = lp.buscar
            preciorc_comp_urea = lp.PRECIO5
            lp.ID = idrc_comp_caseina
            lp = lp.buscar
            preciorc_comp_caseina = lp.PRECIO5
            lp.ID = idrc_comp_urea_caseina
            lp = lp.buscar
            preciorc_comp_urea_caseina = lp.PRECIO5
        ElseIf precio = 6 Then
            lp.ID = idrc_comp
            lp = lp.buscar
            preciorc_comp = lp.PRECIO6
            lp.ID = idrc_comp_urea
            lp = lp.buscar
            preciorc_comp_urea = lp.PRECIO6
            lp.ID = idrc_comp_caseina
            lp = lp.buscar
            preciorc_comp_caseina = lp.PRECIO6
            lp.ID = idrc_comp_urea_caseina
            lp = lp.buscar
            preciorc_comp_urea_caseina = lp.PRECIO6
        ElseIf precio = 7 Then
            lp.ID = idrc_comp
            lp = lp.buscar
            preciorc_comp = lp.PRECIO7
            lp.ID = idrc_comp_urea
            lp = lp.buscar
            preciorc_comp_urea = lp.PRECIO7
            lp.ID = idrc_comp_caseina
            lp = lp.buscar
            preciorc_comp_caseina = lp.PRECIO7
            lp.ID = idrc_comp_urea_caseina
            lp = lp.buscar
            preciorc_comp_urea_caseina = lp.PRECIO7
        End If
        If muestras > 0 And muestras < 20 Then
            muestras = 20
        End If
        Dim subtipo As Integer
        subtipo = sti
        If subtipo = 1 Then
            total1 = muestras * preciorc_comp
        ElseIf subtipo = 32 Then
            total2 = muestras * preciorc_comp_urea
        ElseIf subtipo = 53 Then
            total3 = muestras * preciorc_comp_caseina
        ElseIf subtipo = 54 Then
            total4 = muestras * preciorc_comp_urea_caseina
        End If

        Dim analisis As Integer = 0
        Dim precio1 As Double = 0
        Dim precio2 As Double = 0
        Dim precio3 As Double = 0
        Dim precio4 As Double = 0
        Dim subtotal As Double = 0

        If sti = 1 Then
            analisis = 116
            precio1 = preciorc_comp
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = muestras
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = total1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        ElseIf sti = 32 Then
            analisis = 117
            precio2 = preciorc_comp_urea
            Dim f2 As New dFacturacion
            f2.FICHA = ficha
            f2.CANTIDAD = muestras
            f2.ANALISIS = analisis
            f2.PRECIO = precio2
            f2.SUBTOTAL = total2
            f2.FACTURA = 0
            f2.guardar(Usuario)
            f2 = Nothing
        ElseIf sti = 53 Then
            analisis = 157
            precio3 = preciorc_comp_caseina
            Dim f3 As New dFacturacion
            f3.FICHA = ficha
            f3.CANTIDAD = muestras
            f3.ANALISIS = analisis
            f3.PRECIO = precio3
            f3.SUBTOTAL = total3
            f3.FACTURA = 0
            f3.guardar(Usuario)
            f3 = Nothing
        ElseIf sti = 54 Then
            analisis = 158
            precio4 = preciorc_comp_urea_caseina
            Dim f4 As New dFacturacion
            f4.FICHA = ficha
            f4.CANTIDAD = muestras
            f4.ANALISIS = analisis
            f4.PRECIO = precio4
            f4.SUBTOTAL = total4
            f4.FACTURA = 0
            f4.guardar(Usuario)
            f4 = Nothing
        End If
    End Sub
    Private Sub factura_agua()
        Dim sa As New dSolicitudAnalisis
        Dim a2 As New dAgua2 'Analisis realizados (valores)
        Dim listamuestras As New ArrayList
        Dim ficha As Long = 0
        ficha = TextId.Text.Trim
        listamuestras = a2.listarporid2(ficha)
        sa.ID = ficha
        sa = sa.buscar
        Dim c As New dCliente
        Dim precio As Integer = 0
        c.ID = TextIdProductor.Text.Trim
        c = c.buscar
        If Not c Is Nothing Then
            precio = c.FAC_LISTA
        End If
        Dim lp As New dListaPrecios
        Dim idcompleto As Integer = 87
        Dim idfqcompleto As Integer = 89
        Dim idbacteriologico As Integer = 88
        Dim idconductividad As Integer = 59
        Dim idph As Integer = 150
        Dim idcloro As Integer = 91
        Dim idheterotroficos22 As Integer = 73
        Dim idheterotroficos35 As Integer = 55
        Dim idheterotroficos37 As Integer = 74
        Dim idecoli As Integer = 93
        Dim idsulfitoreductores As Integer = 149
        Dim identerococos As Integer = 167
        Dim idestreptococos As Integer = 166
        Dim idpaqmacro As Integer = 174
        Dim idca As Integer = 168
        Dim idmg As Integer = 169
        Dim idna As Integer = 170
        Dim idfe As Integer = 171
        Dim idk As Integer = 172
        Dim idal As Integer = 176
        Dim idcd As Integer = 177
        Dim idcr As Integer = 178
        Dim idcu As Integer = 179
        Dim idpb As Integer = 180
        Dim idmn As Integer = 181
        Dim idfem As Integer = 182
        Dim idzn As Integer = 183
        Dim idse As Integer = 190
        Dim idalcalinidad As Integer = 184

        Dim preciocompleto As Double
        Dim preciofqcompleto As Double
        Dim preciobacteriologico As Double
        Dim precioconductividad As Double
        Dim precioph As Double
        Dim preciocloro As Double
        Dim precioheterotroficos22 As Double
        Dim precioheterotroficos35 As Double
        Dim precioheterotroficos37 As Double
        Dim precioecoli As Double
        Dim preciosulfitoreductores As Double
        Dim precioenterococos As Double
        Dim precioestreptococos As Double
        Dim preciopaqmacro As Double
        Dim precioca As Double
        Dim preciomg As Double
        Dim preciona As Double
        Dim preciofe As Double
        Dim preciok As Double
        Dim precioal As Double
        Dim preciocd As Double
        Dim preciocr As Double
        Dim preciocu As Double
        Dim preciopb As Double
        Dim preciomn As Double
        Dim preciofem As Double
        Dim preciozn As Double
        Dim preciose As Double
        Dim precioalcalinidad As Double

        If precio = 1 Then
            lp.ID = idcompleto
            lp = lp.buscar
            preciocompleto = lp.PRECIO1
            lp.ID = idfqcompleto
            lp = lp.buscar
            preciofqcompleto = lp.PRECIO1
            lp.ID = idbacteriologico
            lp = lp.buscar
            preciobacteriologico = lp.PRECIO1
            lp.ID = idconductividad
            lp = lp.buscar
            precioconductividad = lp.PRECIO1
            lp.ID = idph
            lp = lp.buscar
            precioph = lp.PRECIO1
            lp.ID = idcloro
            lp = lp.buscar
            preciocloro = lp.PRECIO1
            lp.ID = idheterotroficos22
            lp = lp.buscar
            precioheterotroficos22 = lp.PRECIO1
            lp.ID = idheterotroficos35
            lp = lp.buscar
            precioheterotroficos35 = lp.PRECIO1
            lp.ID = idheterotroficos37
            lp = lp.buscar
            precioheterotroficos37 = lp.PRECIO1
            lp.ID = idecoli
            lp = lp.buscar
            precioecoli = lp.PRECIO1
            lp.ID = idsulfitoreductores
            lp = lp.buscar
            preciosulfitoreductores = lp.PRECIO1
            lp.ID = identerococos
            lp = lp.buscar
            precioenterococos = lp.PRECIO1
            lp.ID = idestreptococos
            lp = lp.buscar
            precioestreptococos = lp.PRECIO1
            lp.ID = idpaqmacro
            lp = lp.buscar
            preciopaqmacro = lp.PRECIO1
            lp.ID = idca
            lp = lp.buscar
            precioca = lp.PRECIO1
            lp.ID = idmg
            lp = lp.buscar
            preciomg = lp.PRECIO1
            lp.ID = idna
            lp = lp.buscar
            preciona = lp.PRECIO1
            lp.ID = idfe
            lp = lp.buscar
            preciofe = lp.PRECIO1
            lp.ID = idk
            lp = lp.buscar
            preciok = lp.PRECIO1
            lp.ID = idal
            lp = lp.buscar
            precioal = lp.PRECIO1
            lp.ID = idcd
            lp = lp.buscar
            preciocd = lp.PRECIO1
            lp.ID = idcr
            lp = lp.buscar
            preciocr = lp.PRECIO1
            lp.ID = idcu
            lp = lp.buscar
            preciocu = lp.PRECIO1
            lp.ID = idpb
            lp = lp.buscar
            preciopb = lp.PRECIO1
            lp.ID = idmn
            lp = lp.buscar
            preciomn = lp.PRECIO1
            lp.ID = idfem
            lp = lp.buscar
            preciofem = lp.PRECIO1
            lp.ID = idzn
            lp = lp.buscar
            preciozn = lp.PRECIO1
            lp.ID = idse
            lp = lp.buscar
            preciose = lp.PRECIO1
            lp.ID = idalcalinidad
            lp = lp.buscar
            precioalcalinidad = lp.PRECIO1
        ElseIf precio = 2 Then
            lp.ID = idcompleto
            lp = lp.buscar
            preciocompleto = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocompleto = lp.PRECIO1
            End If
            lp.ID = idfqcompleto
            lp = lp.buscar
            preciofqcompleto = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciofqcompleto = lp.PRECIO1
            End If
            lp.ID = idbacteriologico
            lp = lp.buscar
            preciobacteriologico = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciobacteriologico = lp.PRECIO1
            End If
            lp.ID = idconductividad
            lp = lp.buscar
            precioconductividad = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioconductividad = lp.PRECIO1
            End If
            lp.ID = idph
            lp = lp.buscar
            precioph = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioph = lp.PRECIO1
            End If
            lp.ID = idcloro
            lp = lp.buscar
            preciocloro = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocloro = lp.PRECIO1
            End If
            lp.ID = idheterotroficos22
            lp = lp.buscar
            precioheterotroficos22 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioheterotroficos22 = lp.PRECIO1
            End If
            lp.ID = idheterotroficos35
            lp = lp.buscar
            precioheterotroficos35 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioheterotroficos35 = lp.PRECIO1
            End If
            lp.ID = idheterotroficos37
            lp = lp.buscar
            precioheterotroficos37 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioheterotroficos37 = lp.PRECIO1
            End If
            lp.ID = idecoli
            lp = lp.buscar
            precioecoli = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioecoli = lp.PRECIO1
            End If
            lp.ID = idsulfitoreductores
            lp = lp.buscar
            preciosulfitoreductores = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciosulfitoreductores = lp.PRECIO1
            End If
            lp.ID = identerococos
            lp = lp.buscar
            precioenterococos = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioenterococos = lp.PRECIO1
            End If
            lp.ID = idestreptococos
            lp = lp.buscar
            precioestreptococos = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioestreptococos = lp.PRECIO1
            End If
            lp.ID = idpaqmacro
            lp = lp.buscar
            preciopaqmacro = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaqmacro = lp.PRECIO1
            End If
            lp.ID = idca
            lp = lp.buscar
            precioca = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioca = lp.PRECIO1
            End If
            lp.ID = idmg
            lp = lp.buscar
            preciomg = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciomg = lp.PRECIO1
            End If
            lp.ID = idna
            lp = lp.buscar
            preciona = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciona = lp.PRECIO1
            End If
            lp.ID = idfe
            lp = lp.buscar
            preciofe = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciofe = lp.PRECIO1
            End If
            lp.ID = idk
            lp = lp.buscar
            preciok = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciok = lp.PRECIO1
            End If
            lp.ID = idal
            lp = lp.buscar
            precioal = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioal = lp.PRECIO1
            End If
            lp.ID = idcd
            lp = lp.buscar
            preciocd = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocd = lp.PRECIO1
            End If
            lp.ID = idcr
            lp = lp.buscar
            preciocr = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocr = lp.PRECIO1
            End If
            lp.ID = idcu
            lp = lp.buscar
            preciocu = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocu = lp.PRECIO1
            End If
            lp.ID = idpb
            lp = lp.buscar
            preciopb = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopb = lp.PRECIO1
            End If
            lp.ID = idmn
            lp = lp.buscar
            preciomn = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciomn = lp.PRECIO1
            End If
            lp.ID = idfem
            lp = lp.buscar
            preciofem = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciofem = lp.PRECIO1
            End If
            lp.ID = idzn
            lp = lp.buscar
            preciozn = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciozn = lp.PRECIO1
            End If
            lp.ID = idse
            lp = lp.buscar
            preciose = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciose = lp.PRECIO1
            End If
            lp.ID = idalcalinidad
            lp = lp.buscar
            precioalcalinidad = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioalcalinidad = lp.PRECIO1
            End If
        ElseIf precio = 3 Then
            lp.ID = idcompleto
            lp = lp.buscar
            preciocompleto = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocompleto = lp.PRECIO1
            End If
            lp.ID = idfqcompleto
            lp = lp.buscar
            preciofqcompleto = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciofqcompleto = lp.PRECIO1
            End If
            lp.ID = idbacteriologico
            lp = lp.buscar
            preciobacteriologico = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciobacteriologico = lp.PRECIO1
            End If
            lp.ID = idconductividad
            lp = lp.buscar
            precioconductividad = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioconductividad = lp.PRECIO1
            End If
            lp.ID = idph
            lp = lp.buscar
            precioph = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioph = lp.PRECIO1
            End If
            lp.ID = idcloro
            lp = lp.buscar
            preciocloro = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocloro = lp.PRECIO1
            End If
            lp.ID = idheterotroficos22
            lp = lp.buscar
            precioheterotroficos22 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioheterotroficos22 = lp.PRECIO1
            End If
            lp.ID = idheterotroficos35
            lp = lp.buscar
            precioheterotroficos35 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioheterotroficos35 = lp.PRECIO1
            End If
            lp.ID = idheterotroficos37
            lp = lp.buscar
            precioheterotroficos37 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioheterotroficos37 = lp.PRECIO1
            End If
            lp.ID = idecoli
            lp = lp.buscar
            precioecoli = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioecoli = lp.PRECIO1
            End If
            lp.ID = idsulfitoreductores
            lp = lp.buscar
            preciosulfitoreductores = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciosulfitoreductores = lp.PRECIO1
            End If
            lp.ID = identerococos
            lp = lp.buscar
            precioenterococos = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioenterococos = lp.PRECIO1
            End If
            lp.ID = idestreptococos
            lp = lp.buscar
            precioestreptococos = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioestreptococos = lp.PRECIO1
            End If
            lp.ID = idpaqmacro
            lp = lp.buscar
            preciopaqmacro = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaqmacro = lp.PRECIO1
            End If
            lp.ID = idca
            lp = lp.buscar
            precioca = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioca = lp.PRECIO1
            End If
            lp.ID = idmg
            lp = lp.buscar
            preciomg = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciomg = lp.PRECIO1
            End If
            lp.ID = idna
            lp = lp.buscar
            preciona = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciona = lp.PRECIO1
            End If
            lp.ID = idfe
            lp = lp.buscar
            preciofe = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciofe = lp.PRECIO1
            End If
            lp.ID = idk
            lp = lp.buscar
            preciok = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciok = lp.PRECIO1
            End If
            lp.ID = idal
            lp = lp.buscar
            precioal = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioal = lp.PRECIO1
            End If
            lp.ID = idcd
            lp = lp.buscar
            preciocd = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocd = lp.PRECIO1
            End If
            lp.ID = idcr
            lp = lp.buscar
            preciocr = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocr = lp.PRECIO1
            End If
            lp.ID = idcu
            lp = lp.buscar
            preciocu = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocu = lp.PRECIO1
            End If
            lp.ID = idpb
            lp = lp.buscar
            preciopb = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopb = lp.PRECIO1
            End If
            lp.ID = idmn
            lp = lp.buscar
            preciomn = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciomn = lp.PRECIO1
            End If
            lp.ID = idfem
            lp = lp.buscar
            preciofem = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciofem = lp.PRECIO1
            End If
            lp.ID = idzn
            lp = lp.buscar
            preciozn = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciozn = lp.PRECIO1
            End If
            lp.ID = idse
            lp = lp.buscar
            preciose = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciose = lp.PRECIO1
            End If
            lp.ID = idalcalinidad
            lp = lp.buscar
            precioalcalinidad = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioalcalinidad = lp.PRECIO1
            End If
        End If

        Dim subtipo As Integer
        Dim contadorh As Integer = 0
        Dim contadorcph As Integer = 0
        Dim contadorc As Integer = 0
        Dim muestras As Integer
        muestras = listamuestras.Count
        subtipo = sa.IDSUBINFORME
        Dim analisis As Integer = 0
        Dim precio1 As Double = 0
        Dim precio2 As Double = 0
        Dim precio3 As Double = 0
        Dim precio4 As Double = 0

        If subtipo = 2 Then
            analisis = 87
            precio1 = preciocompleto
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = muestras
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = muestras * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If subtipo = 29 Then
            analisis = 89
            precio1 = preciofqcompleto
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = muestras
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = muestras * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If subtipo = 30 Then
            analisis = 88
            precio1 = preciobacteriologico
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = muestras
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = muestras * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        Dim a1 As New dAgua 'Analisis que solicita
        'a1.FICHA = ficha
        'a1 = a1.buscar
        Dim listaanalisis As New ArrayList
        listaanalisis = a1.listarporsolicitud(ficha)
        If Not listaanalisis Is Nothing Then
            For Each a1 In listaanalisis
                If a1.HET22 = 1 Then
                    analisis = 73
                    precio1 = precioheterotroficos22
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If a1.HET35 = 1 Then
                    analisis = 55
                    precio1 = precioheterotroficos35
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If a1.HET37 = 1 Then
                    analisis = 74
                    precio1 = precioheterotroficos37
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If a1.CLORO = 1 Then
                    analisis = 91
                    precio1 = preciocloro
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If a1.CONDUCTIVIDAD = 1 Then
                    analisis = 59
                    precio1 = precioconductividad
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If a1.PH = 1 Then
                    analisis = 150
                    precio1 = precioph
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If a1.ECOLI = 1 Then
                    analisis = 93
                    precio1 = precioecoli
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If a1.SULFITOREDUCTORES = 1 Then
                    analisis = 149
                    precio1 = preciosulfitoreductores
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If a1.ENTEROCOCOS = 1 Then
                    analisis = 167
                    precio1 = precioenterococos
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If a1.ESTREPTOCOCOS = 1 Then
                    analisis = 166
                    precio1 = precioestreptococos
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If a1.PAQMACRO = 1 Then
                    analisis = 174
                    precio1 = preciopaqmacro
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If a1.PAQMACRO = 0 Then
                    If a1.CA = 1 Then
                        analisis = 168
                        precio1 = precioca
                        Dim f1 As New dFacturacion
                        f1.FICHA = ficha
                        f1.CANTIDAD = muestras
                        f1.ANALISIS = analisis
                        f1.PRECIO = precio1
                        f1.SUBTOTAL = muestras * precio1
                        f1.FACTURA = 0
                        f1.guardar(Usuario)
                        f1 = Nothing
                    End If
                    If a1.MG = 1 Then
                        analisis = 169
                        precio1 = preciomg
                        Dim f1 As New dFacturacion
                        f1.FICHA = ficha
                        f1.CANTIDAD = muestras
                        f1.ANALISIS = analisis
                        f1.PRECIO = precio1
                        f1.SUBTOTAL = muestras * precio1
                        f1.FACTURA = 0
                        f1.guardar(Usuario)
                        f1 = Nothing
                    End If
                    If a1.NA = 1 Then
                        analisis = 170
                        precio1 = preciona
                        Dim f1 As New dFacturacion
                        f1.FICHA = ficha
                        f1.CANTIDAD = muestras
                        f1.ANALISIS = analisis
                        f1.PRECIO = precio1
                        f1.SUBTOTAL = muestras * precio1
                        f1.FACTURA = 0
                        f1.guardar(Usuario)
                        f1 = Nothing
                    End If
                    If a1.FE = 1 Then
                        analisis = 171
                        precio1 = preciofe
                        Dim f1 As New dFacturacion
                        f1.FICHA = ficha
                        f1.CANTIDAD = muestras
                        f1.ANALISIS = analisis
                        f1.PRECIO = precio1
                        f1.SUBTOTAL = muestras * precio1
                        f1.FACTURA = 0
                        f1.guardar(Usuario)
                        f1 = Nothing
                    End If
                    If a1.K = 1 Then
                        analisis = 172
                        precio1 = preciok
                        Dim f1 As New dFacturacion
                        f1.FICHA = ficha
                        f1.CANTIDAD = muestras
                        f1.ANALISIS = analisis
                        f1.PRECIO = precio1
                        f1.SUBTOTAL = muestras * precio1
                        f1.FACTURA = 0
                        f1.guardar(Usuario)
                        f1 = Nothing
                    End If
                End If
                If a1.AL = 1 Then
                    analisis = 176
                    precio1 = precioal
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If a1.CD = 1 Then
                    analisis = 177
                    precio1 = preciocd
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If a1.CR = 1 Then
                    analisis = 178
                    precio1 = preciocr
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If a1.CU = 1 Then
                    analisis = 179
                    precio1 = preciocu
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If a1.PB = 1 Then
                    analisis = 180
                    precio1 = preciopb
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If a1.MN = 1 Then
                    analisis = 181
                    precio1 = preciomn
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If a1.FEM = 1 Then
                    analisis = 182
                    precio1 = preciofem
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If a1.ZN = 1 Then
                    analisis = 183
                    precio1 = preciozn
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If a1.SE = 1 Then
                    analisis = 190
                    precio1 = preciose
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If a1.ALCALINIDAD = 1 Then
                    analisis = 184
                    precio1 = precioalcalinidad
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
            Next
        End If
    End Sub
    Private Sub factura_atb()
        Dim ficha As Long = 0
        ficha = TextId.Text.Trim
        Dim atb As New dAntibiograma
        Dim atb2 As New dAntibiograma2
        Dim listamuestras As New ArrayList
        Dim listatipo As New ArrayList
        Dim muestras As Integer = 0
        Dim tipo As Integer = 0
        listamuestras = atb.listarporsolicitud(ficha)
        If Not listamuestras Is Nothing Then
            muestras = listamuestras.Count
        End If
        listatipo = atb2.listarporsolicitud(ficha)
        If Not listatipo Is Nothing Then
            For Each atb2 In listatipo
                If atb2.ANTIBIOGRAMA = 1 Then
                    tipo = 2
                Else
                    tipo = 1
                End If
            Next
        End If
        Dim lp As New dListaPrecios
        Dim idatb As Integer = 12
        Dim idloteatb As Integer = 85
        Dim idaislamiento As Integer = 11
        Dim idloteaislamiento As Integer = 240
        Dim idbactanque As Integer = 7
        Dim precioatb As Double = 0
        Dim precioloteatb As Double = 0
        Dim precioaislamiento As Double = 0
        Dim precioloteaislamiento As Double = 0
        Dim preciobactanque As Double = 0
        Dim analisis As Integer = 0
        Dim precio1 As Double = 0

        Dim c As New dCliente
        Dim precio As Integer = 0
        c.ID = TextIdProductor.Text.Trim
        c = c.buscar
        If Not c Is Nothing Then
            precio = c.FAC_LISTA
        End If
        If precio = 1 Then
            lp.ID = idatb
            lp = lp.buscar
            precioatb = lp.PRECIO1
            lp.ID = idloteatb
            lp = lp.buscar
            precioloteatb = lp.PRECIO1
            lp.ID = idaislamiento
            lp = lp.buscar
            precioaislamiento = lp.PRECIO1
            lp.ID = idloteaislamiento
            lp = lp.buscar
            precioloteaislamiento = lp.PRECIO1
            lp.ID = idbactanque
            lp = lp.buscar
            preciobactanque = lp.PRECIO1
        ElseIf precio = 2 Then
            lp.ID = idatb
            lp = lp.buscar
            precioatb = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioatb = lp.PRECIO1
            End If
            lp.ID = idloteatb
            lp = lp.buscar
            precioloteatb = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioloteatb = lp.PRECIO1
            End If
            lp.ID = idaislamiento
            lp = lp.buscar
            precioaislamiento = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioaislamiento = lp.PRECIO1
            End If
            lp.ID = idloteaislamiento
            lp = lp.buscar
            precioloteaislamiento = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioloteaislamiento = lp.PRECIO1
            End If
            lp.ID = idbactanque
            lp = lp.buscar
            preciobactanque = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciobactanque = lp.PRECIO1
            End If
        ElseIf precio = 3 Then
            lp.ID = idatb
            lp = lp.buscar
            precioatb = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioatb = lp.PRECIO1
            End If
            lp.ID = idloteatb
            lp = lp.buscar
            precioloteatb = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioloteatb = lp.PRECIO1
            End If
            lp.ID = idaislamiento
            lp = lp.buscar
            precioaislamiento = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioaislamiento = lp.PRECIO1
            End If
            lp.ID = idloteaislamiento
            lp = lp.buscar
            precioloteaislamiento = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioloteaislamiento = lp.PRECIO1
            End If
            lp.ID = idbactanque
            lp = lp.buscar
            preciobactanque = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciobactanque = lp.PRECIO1
            End If
        End If
        If tipo = 1 Then
            If muestras > 5 Then
                analisis = 240
                precio1 = precioloteaislamiento
                Dim f1 As New dFacturacion
                f1.FICHA = ficha
                f1.CANTIDAD = muestras
                f1.ANALISIS = analisis
                f1.PRECIO = precio1
                f1.SUBTOTAL = muestras * precio1
                f1.FACTURA = 0
                f1.guardar(Usuario)
                f1 = Nothing
            Else
                analisis = 11
                precio1 = precioaislamiento
                Dim f1 As New dFacturacion
                f1.FICHA = ficha
                f1.CANTIDAD = muestras
                f1.ANALISIS = analisis
                f1.PRECIO = precio1
                f1.SUBTOTAL = muestras * precio1
                f1.FACTURA = 0
                f1.guardar(Usuario)
                f1 = Nothing
            End If
        ElseIf tipo = 2 Then
            If muestras > 5 Then
                analisis = 85
                precio1 = precioloteatb
                Dim f1 As New dFacturacion
                f1.FICHA = ficha
                f1.CANTIDAD = muestras
                f1.ANALISIS = analisis
                f1.PRECIO = precio1
                f1.SUBTOTAL = muestras * precio1
                f1.FACTURA = 0
                f1.guardar(Usuario)
                f1 = Nothing
            Else
                analisis = 12
                precio1 = precioatb
                Dim f1 As New dFacturacion
                f1.FICHA = ficha
                f1.CANTIDAD = muestras
                f1.ANALISIS = analisis
                f1.PRECIO = precio1
                f1.SUBTOTAL = muestras * precio1
                f1.FACTURA = 0
                f1.guardar(Usuario)
                f1 = Nothing
            End If
        End If
        Dim sa As New dSolicitudAnalisis
        sa.ID = ficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            If sa.IDSUBINFORME = 10 Then
                analisis = 7
                precio1 = preciobactanque
                Dim f1 As New dFacturacion
                f1.FICHA = ficha
                f1.CANTIDAD = sa.NMUESTRAS
                f1.ANALISIS = analisis
                f1.PRECIO = precio1
                f1.SUBTOTAL = muestras * precio1
                f1.FACTURA = 0
                f1.guardar(Usuario)
                f1 = Nothing
            End If
        End If
    End Sub
    Private Sub factura_subproductos()
        Dim lp As New dListaPrecios
        Dim idpaquete1 As Integer = 94
        Dim idpaquete2 As Integer = 95
        Dim idpaquete3 As Integer = 96
        Dim idpaquete4 As Integer = 230
        Dim idhumedad As Integer = 29
        Dim idgrasa As Integer = 30
        Dim idph As Integer = 31
        Dim idcloruros As Integer = 10
        Dim idproteinas As Integer = 32
        Dim idcenizas As Integer = 64
        Dim idestaf As Integer = 24
        Dim idcf As Integer = 84
        Dim idct As Integer = 83
        Dim idmohos As Integer = 28
        Dim idecoli As Integer = 23
        Dim idecoli157 As Integer = 185
        Dim idsalmonella As Integer = 27
        Dim idlistspp As Integer = 25
        Dim idlistmono As Integer = 141
        Dim idesporulados As Integer = 8
        Dim idtermoduricos As Integer = 62
        Dim idpsicrotrofos As Integer = 61
        Dim identerobacterias As Integer = 9
        Dim idrb As Integer = 1
        Dim idsalmonellapool As Integer = 232
        Dim idlisteriapool As Integer = 231

        Dim preciopaquete1 As Double = 0
        Dim preciopaquete2 As Double = 0
        Dim preciopaquete3 As Double = 0
        Dim preciopaquete4 As Double = 0
        Dim preciohumedad As Double = 0
        Dim preciograsa As Double = 0
        Dim precioph As Double = 0
        Dim preciocloruros As Double = 0
        Dim precioproteinas As Double = 0
        Dim preciocenizas As Double = 0
        Dim precioestaf As Double = 0
        Dim preciocf As Double = 0
        Dim precioct As Double = 0
        Dim preciomohos As Double = 0
        Dim precioecoli As Double = 0
        Dim precioecoli157 As Double = 0
        Dim preciosalmonella As Double = 0
        Dim preciolistspp As Double = 0
        Dim preciolistmono As Double = 0
        Dim precioesporulados As Double = 0
        Dim preciotermoduricos As Double = 0
        Dim preciopsicrotrofos As Double = 0
        Dim precioenterobacterias As Double = 0
        Dim preciorb As Double = 0
        Dim preciosalmonellapool As Double = 0
        Dim preciolisteriapool As Double = 0

        Dim c As New dCliente
        Dim precio As Integer = 0
        c.ID = TextIdProductor.Text.Trim
        c = c.buscar
        If Not c Is Nothing Then
            precio = c.FAC_LISTA
        End If

        If precio = 1 Then
            lp.ID = idpaquete1
            lp = lp.buscar
            preciopaquete1 = lp.PRECIO1
            lp.ID = idpaquete2
            lp = lp.buscar
            preciopaquete2 = lp.PRECIO1
            lp.ID = idpaquete3
            lp = lp.buscar
            preciopaquete3 = lp.PRECIO1
            lp.ID = idpaquete4
            lp = lp.buscar
            preciopaquete4 = lp.PRECIO1
            lp.ID = idhumedad
            lp = lp.buscar
            preciohumedad = lp.PRECIO1
            lp.ID = idgrasa
            lp = lp.buscar
            preciograsa = lp.PRECIO1
            lp.ID = idph
            lp = lp.buscar
            precioph = lp.PRECIO1
            lp.ID = idcloruros
            lp = lp.buscar
            preciocloruros = lp.PRECIO1
            lp.ID = idproteinas
            lp = lp.buscar
            precioproteinas = lp.PRECIO1
            lp.ID = idcenizas
            lp = lp.buscar
            preciocenizas = lp.PRECIO1
            lp.ID = idestaf
            lp = lp.buscar
            precioestaf = lp.PRECIO1
            lp.ID = idcf
            lp = lp.buscar
            preciocf = lp.PRECIO1
            lp.ID = idct
            lp = lp.buscar
            precioct = lp.PRECIO1
            lp.ID = idmohos
            lp = lp.buscar
            preciomohos = lp.PRECIO1
            lp.ID = idecoli
            lp = lp.buscar
            precioecoli = lp.PRECIO1
            lp.ID = idecoli157
            lp = lp.buscar
            precioecoli157 = lp.PRECIO1
            lp.ID = idsalmonella
            lp = lp.buscar
            preciosalmonella = lp.PRECIO1
            lp.ID = idlistmono
            lp = lp.buscar
            preciolistmono = lp.PRECIO1
            lp.ID = idesporulados
            lp = lp.buscar
            precioesporulados = lp.PRECIO1
            lp.ID = idtermoduricos
            lp = lp.buscar
            preciotermoduricos = lp.PRECIO1
            lp.ID = idpsicrotrofos
            lp = lp.buscar
            preciopsicrotrofos = lp.PRECIO1
            lp.ID = identerobacterias
            lp = lp.buscar
            precioenterobacterias = lp.PRECIO1
            lp.ID = idrb
            lp = lp.buscar
            preciorb = lp.PRECIO1
            lp.ID = idsalmonellapool
            lp = lp.buscar
            preciosalmonellapool = lp.PRECIO1
            lp.ID = idlisteriapool
            lp = lp.buscar
            preciolisteriapool = lp.PRECIO1
        ElseIf precio = 2 Then
            lp.ID = idpaquete1
            lp = lp.buscar
            preciopaquete1 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaquete1 = lp.PRECIO1
            End If
            lp.ID = idpaquete2
            lp = lp.buscar
            preciopaquete2 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaquete2 = lp.PRECIO1
            End If
            lp.ID = idpaquete3
            lp = lp.buscar
            preciopaquete3 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaquete3 = lp.PRECIO1
            End If
            lp.ID = idpaquete4
            lp = lp.buscar
            preciopaquete4 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaquete4 = lp.PRECIO1
            End If
            lp.ID = idhumedad
            lp = lp.buscar
            preciohumedad = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciohumedad = lp.PRECIO1
            End If
            lp.ID = idgrasa
            lp = lp.buscar
            preciograsa = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciograsa = lp.PRECIO1
            End If
            lp.ID = idph
            lp = lp.buscar
            precioph = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioph = lp.PRECIO1
            End If
            lp.ID = idcloruros
            lp = lp.buscar
            preciocloruros = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocloruros = lp.PRECIO1
            End If
            lp.ID = idproteinas
            lp = lp.buscar
            precioproteinas = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioproteinas = lp.PRECIO1
            End If
            lp.ID = idcenizas
            lp = lp.buscar
            preciocenizas = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocenizas = lp.PRECIO1
            End If
            lp.ID = idestaf
            lp = lp.buscar
            precioestaf = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioestaf = lp.PRECIO1
            End If
            lp.ID = idcf
            lp = lp.buscar
            preciocf = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocf = lp.PRECIO1
            End If
            lp.ID = idct
            lp = lp.buscar
            precioct = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioct = lp.PRECIO1
            End If
            lp.ID = idmohos
            lp = lp.buscar
            preciomohos = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciomohos = lp.PRECIO1
            End If
            lp.ID = idecoli
            lp = lp.buscar
            precioecoli = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioecoli = lp.PRECIO1
            End If
            lp.ID = idecoli157
            lp = lp.buscar
            precioecoli157 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioecoli157 = lp.PRECIO1
            End If
            lp.ID = idsalmonella
            lp = lp.buscar
            preciosalmonella = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciosalmonella = lp.PRECIO1
            End If
            lp.ID = idlistmono
            lp = lp.buscar
            preciolistmono = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciolistmono = lp.PRECIO1
            End If
            lp.ID = idesporulados
            lp = lp.buscar
            precioesporulados = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioesporulados = lp.PRECIO1
            End If
            lp.ID = idtermoduricos
            lp = lp.buscar
            preciotermoduricos = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciotermoduricos = lp.PRECIO1
            End If
            lp.ID = idpsicrotrofos
            lp = lp.buscar
            preciopsicrotrofos = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopsicrotrofos = lp.PRECIO1
            End If
            lp.ID = identerobacterias
            lp = lp.buscar
            precioenterobacterias = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioenterobacterias = lp.PRECIO1
            End If
            lp.ID = idrb
            lp = lp.buscar
            preciorb = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciorb = lp.PRECIO1
            End If
            lp.ID = idsalmonellapool
            lp = lp.buscar
            preciosalmonellapool = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciosalmonellapool = lp.PRECIO1
            End If
            lp.ID = idlisteriapool
            lp = lp.buscar
            preciolisteriapool = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciolisteriapool = lp.PRECIO1
            End If
        ElseIf precio = 3 Then
            lp.ID = idpaquete1
            lp = lp.buscar
            preciopaquete1 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaquete1 = lp.PRECIO1
            End If
            lp.ID = idpaquete2
            lp = lp.buscar
            preciopaquete2 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaquete2 = lp.PRECIO1
            End If
            lp.ID = idpaquete3
            lp = lp.buscar
            preciopaquete3 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaquete3 = lp.PRECIO1
            End If
            lp.ID = idpaquete4
            lp = lp.buscar
            preciopaquete4 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaquete4 = lp.PRECIO1
            End If
            lp.ID = idhumedad
            lp = lp.buscar
            preciohumedad = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciohumedad = lp.PRECIO1
            End If
            lp.ID = idgrasa
            lp = lp.buscar
            preciograsa = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciograsa = lp.PRECIO1
            End If
            lp.ID = idph
            lp = lp.buscar
            precioph = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioph = lp.PRECIO1
            End If
            lp.ID = idcloruros
            lp = lp.buscar
            preciocloruros = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocloruros = lp.PRECIO1
            End If
            lp.ID = idproteinas
            lp = lp.buscar
            precioproteinas = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioproteinas = lp.PRECIO1
            End If
            lp.ID = idcenizas
            lp = lp.buscar
            preciocenizas = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocenizas = lp.PRECIO1
            End If
            lp.ID = idestaf
            lp = lp.buscar
            precioestaf = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioestaf = lp.PRECIO1
            End If
            lp.ID = idcf
            lp = lp.buscar
            preciocf = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocf = lp.PRECIO1
            End If
            lp.ID = idct
            lp = lp.buscar
            precioct = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioct = lp.PRECIO1
            End If
            lp.ID = idmohos
            lp = lp.buscar
            preciomohos = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciomohos = lp.PRECIO1
            End If
            lp.ID = idecoli
            lp = lp.buscar
            precioecoli = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioecoli = lp.PRECIO1
            End If
            lp.ID = idecoli157
            lp = lp.buscar
            precioecoli157 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioecoli157 = lp.PRECIO1
            End If
            lp.ID = idsalmonella
            lp = lp.buscar
            preciosalmonella = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciosalmonella = lp.PRECIO1
            End If
            lp.ID = idlistmono
            lp = lp.buscar
            preciolistmono = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciolistmono = lp.PRECIO1
            End If
            lp.ID = idesporulados
            lp = lp.buscar
            precioesporulados = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioesporulados = lp.PRECIO1
            End If
            lp.ID = idtermoduricos
            lp = lp.buscar
            preciotermoduricos = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciotermoduricos = lp.PRECIO1
            End If
            lp.ID = idpsicrotrofos
            lp = lp.buscar
            preciopsicrotrofos = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopsicrotrofos = lp.PRECIO1
            End If
            lp.ID = identerobacterias
            lp = lp.buscar
            precioenterobacterias = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioenterobacterias = lp.PRECIO1
            End If
            lp.ID = idrb
            lp = lp.buscar
            preciorb = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciorb = lp.PRECIO1
            End If
            lp.ID = idsalmonellapool
            lp = lp.buscar
            preciosalmonellapool = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciosalmonellapool = lp.PRECIO1
            End If
            lp.ID = idlisteriapool
            lp = lp.buscar
            preciolisteriapool = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciolisteriapool = lp.PRECIO1
            End If
        End If

        Dim ficha As Long = 0
        Dim subp2 As New dSubproducto2
        Dim subp As New dSubproducto
        Dim sa As New dSolicitudAnalisis
        Dim listamuestras As New ArrayList
        Dim listaanalisis As New ArrayList
        Dim muestras As Integer = 0
        ficha = TextId.Text.Trim
        sa.ID = ficha
        sa = sa.buscar
        subp.FICHA = ficha
        subp = subp.buscarxsolicitud
        listamuestras = subp2.listarporid(ficha)
        listaanalisis = subp.listarporsolicitud(ficha)
        Dim subtipo As Integer
        subtipo = sa.IDSUBINFORME
        Dim analisis As Integer = 0
        Dim precio1 As Double = 0
        If Not listamuestras Is Nothing Then
            muestras = listamuestras.Count
        End If
        If Not listaanalisis Is Nothing Then
            'For Each subp In listaanalisis
            If subtipo = 14 Then
                analisis = 94
                precio1 = preciopaquete1
                Dim f1 As New dFacturacion
                f1.FICHA = ficha
                f1.CANTIDAD = muestras
                f1.ANALISIS = analisis
                f1.PRECIO = precio1
                f1.SUBTOTAL = muestras * precio1
                f1.FACTURA = 0
                f1.guardar(Usuario)
                f1 = Nothing
                If subp.HUMEDAD = 1 Then
                    analisis = 29
                    precio1 = preciohumedad
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.MGRASA = 1 Then
                    analisis = 30
                    precio1 = preciograsa
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.PH = 1 Then
                    analisis = 31
                    precio1 = precioph
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.CLORUROS = 1 Then
                    analisis = 10
                    precio1 = preciocloruros
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.PROTEINAS = 1 Then
                    analisis = 32
                    precio1 = precioproteinas
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.CENIZAS = 1 Then
                    analisis = 64
                    precio1 = preciocenizas
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ESPORANAERMESOFILO = 1 Then
                    analisis = 8
                    precio1 = precioesporulados
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.TERMOFILOS = 1 Then
                    analisis = 62
                    precio1 = preciotermoduricos
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.PSICROTROFOS = 1 Then
                    analisis = 61
                    precio1 = preciopsicrotrofos
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ENTEROBACTERIAS = 1 Then
                    analisis = 9
                    precio1 = precioenterobacterias
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
            End If
            If subtipo = 15 Then
                analisis = 95
                precio1 = preciopaquete2
                Dim f1 As New dFacturacion
                f1.FICHA = ficha
                f1.CANTIDAD = muestras
                f1.ANALISIS = analisis
                f1.PRECIO = precio1
                f1.SUBTOTAL = muestras * precio1
                f1.FACTURA = 0
                f1.guardar(Usuario)
                f1 = Nothing
                If subp.HUMEDAD = 1 Then
                    analisis = 29
                    precio1 = preciohumedad
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.MGRASA = 1 Then
                    analisis = 30
                    precio1 = preciograsa
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.PH = 1 Then
                    analisis = 31
                    precio1 = precioph
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.CLORUROS = 1 Then
                    analisis = 10
                    precio1 = preciocloruros
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.PROTEINAS = 1 Then
                    analisis = 32
                    precio1 = precioproteinas
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.CENIZAS = 1 Then
                    analisis = 64
                    precio1 = preciocenizas
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ESPORANAERMESOFILO = 1 Then
                    analisis = 8
                    precio1 = precioesporulados
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.TERMOFILOS = 1 Then
                    analisis = 62
                    precio1 = preciotermoduricos
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.PSICROTROFOS = 1 Then
                    analisis = 61
                    precio1 = preciopsicrotrofos
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ENTEROBACTERIAS = 1 Then
                    analisis = 9
                    precio1 = precioenterobacterias
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                'If subp.MOHOSYLEVADURAS = 1 Then
                '    analisis = 28
                '    precio1 = preciomohos
                '    Dim f2 As New dFacturacion
                '    f2.FICHA = ficha
                '    f2.CANTIDAD = muestras
                '    f2.ANALISIS = analisis
                '    f2.PRECIO = precio1
                '    f2.SUBTOTAL = muestras * precio1
                '    f2.FACTURA = 0
                '    f2.guardar(Usuario)
                '    f2 = Nothing
                'End If
                If subp.ECOLI = 1 Then
                    analisis = 23
                    precio1 = precioecoli
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
            End If
            If subtipo = 17 Then
                analisis = 96
                precio1 = preciopaquete3
                Dim f1 As New dFacturacion
                f1.FICHA = ficha
                f1.CANTIDAD = muestras
                f1.ANALISIS = analisis
                f1.PRECIO = precio1
                f1.SUBTOTAL = muestras * precio1
                f1.FACTURA = 0
                f1.guardar(Usuario)
                f1 = Nothing
                If subp.HUMEDAD = 1 Then
                    analisis = 29
                    precio1 = preciohumedad
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.MGRASA = 1 Then
                    analisis = 30
                    precio1 = preciograsa
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.PH = 1 Then
                    analisis = 31
                    precio1 = precioph
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.CLORUROS = 1 Then
                    analisis = 10
                    precio1 = preciocloruros
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.PROTEINAS = 1 Then
                    analisis = 32
                    precio1 = precioproteinas
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.CENIZAS = 1 Then
                    analisis = 64
                    precio1 = preciocenizas
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ESPORANAERMESOFILO = 1 Then
                    analisis = 8
                    precio1 = precioesporulados
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.TERMOFILOS = 1 Then
                    analisis = 62
                    precio1 = preciotermoduricos
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.PSICROTROFOS = 1 Then
                    analisis = 61
                    precio1 = preciopsicrotrofos
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ENTEROBACTERIAS = 1 Then
                    analisis = 9
                    precio1 = precioenterobacterias
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
            End If
            If subtipo = 20 Then
                If subp.HUMEDAD = 1 Then
                    analisis = 29
                    precio1 = preciohumedad
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.MGRASA = 1 Then
                    analisis = 30
                    precio1 = preciograsa
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.PH = 1 Then
                    analisis = 31
                    precio1 = precioph
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.CLORUROS = 1 Then
                    analisis = 10
                    precio1 = preciocloruros
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.PROTEINAS = 1 Then
                    analisis = 32
                    precio1 = precioproteinas
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.CENIZAS = 1 Then
                    analisis = 64
                    precio1 = preciocenizas
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ESPORANAERMESOFILO = 1 Then
                    analisis = 8
                    precio1 = precioesporulados
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.TERMOFILOS = 1 Then
                    analisis = 62
                    precio1 = preciotermoduricos
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.PSICROTROFOS = 1 Then
                    analisis = 61
                    precio1 = preciopsicrotrofos
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ENTEROBACTERIAS = 1 Then
                    analisis = 9
                    precio1 = precioenterobacterias
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ESTAFCOAGPOSITIVO = 1 Then
                    analisis = 24
                    precio1 = precioestaf
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.CF = 1 Then
                    analisis = 84
                    precio1 = preciocf
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.CT = 1 Then
                    analisis = 83
                    precio1 = precioct
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ECOLI = 1 Then
                    analisis = 23
                    precio1 = precioecoli
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ECOLI157 = 1 Then
                    analisis = 185
                    precio1 = precioecoli157
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.SALMONELLA = 1 Then
                    analisis = 27
                    precio1 = preciosalmonella
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.LISTERIASPP = 1 Then
                    analisis = 25
                    precio1 = preciolistspp
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.LISTERIAMONOCITOGENES = 1 Then
                    analisis = 141
                    precio1 = preciolistmono
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.RB = 1 Then
                    analisis = 1
                    precio1 = preciorb
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.MOHOSYLEVADURAS = 1 Then
                    analisis = 28
                    precio1 = preciomohos
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
            End If
            If subtipo = 35 Then
                If subp.HUMEDAD = 1 Then
                    analisis = 29
                    precio1 = preciohumedad
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.MGRASA = 1 Then
                    analisis = 30
                    precio1 = preciograsa
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.PH = 1 Then
                    analisis = 31
                    precio1 = precioph
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.CLORUROS = 1 Then
                    analisis = 10
                    precio1 = preciocloruros
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.PROTEINAS = 1 Then
                    analisis = 32
                    precio1 = precioproteinas
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.CENIZAS = 1 Then
                    analisis = 64
                    precio1 = preciocenizas
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ESPORANAERMESOFILO = 1 Then
                    analisis = 8
                    precio1 = precioesporulados
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.TERMOFILOS = 1 Then
                    analisis = 62
                    precio1 = preciotermoduricos
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.PSICROTROFOS = 1 Then
                    analisis = 61
                    precio1 = preciopsicrotrofos
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ENTEROBACTERIAS = 1 Then
                    analisis = 9
                    precio1 = precioenterobacterias
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ESTAFCOAGPOSITIVO = 1 Then
                    analisis = 24
                    precio1 = precioestaf
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.CF = 1 Then
                    analisis = 84
                    precio1 = preciocf
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.CT = 1 Then
                    analisis = 83
                    precio1 = precioct
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ECOLI = 1 Then
                    analisis = 23
                    precio1 = precioecoli
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ECOLI157 = 1 Then
                    analisis = 185
                    precio1 = precioecoli157
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.SALMONELLA = 1 Then
                    analisis = 27
                    precio1 = preciosalmonella
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.LISTERIASPP = 1 Then
                    analisis = 25
                    precio1 = preciolistspp
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.LISTERIAMONOCITOGENES = 1 Then
                    analisis = 141
                    precio1 = preciolistmono
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.RB = 1 Then
                    analisis = 1
                    precio1 = preciorb
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.MOHOSYLEVADURAS = 1 Then
                    analisis = 28
                    precio1 = preciomohos
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
            End If
            If subtipo = 43 Then
                If subp.HUMEDAD = 1 Then
                    analisis = 29
                    precio1 = preciohumedad
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.MGRASA = 1 Then
                    analisis = 30
                    precio1 = preciograsa
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.PH = 1 Then
                    analisis = 31
                    precio1 = precioph
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.CLORUROS = 1 Then
                    analisis = 10
                    precio1 = preciocloruros
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.PROTEINAS = 1 Then
                    analisis = 32
                    precio1 = precioproteinas
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.CENIZAS = 1 Then
                    analisis = 64
                    precio1 = preciocenizas
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ESPORANAERMESOFILO = 1 Then
                    analisis = 8
                    precio1 = precioesporulados
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.TERMOFILOS = 1 Then
                    analisis = 62
                    precio1 = preciotermoduricos
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.PSICROTROFOS = 1 Then
                    analisis = 61
                    precio1 = preciopsicrotrofos
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ENTEROBACTERIAS = 1 Then
                    analisis = 9
                    precio1 = precioenterobacterias
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ESTAFCOAGPOSITIVO = 1 Then
                    analisis = 24
                    precio1 = precioestaf
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.CF = 1 Then
                    analisis = 84
                    precio1 = preciocf
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.CT = 1 Then
                    analisis = 83
                    precio1 = precioct
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ECOLI = 1 Then
                    analisis = 23
                    precio1 = precioecoli
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ECOLI157 = 1 Then
                    analisis = 185
                    precio1 = precioecoli157
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.SALMONELLA = 1 Then
                    analisis = 27
                    precio1 = preciosalmonella
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.LISTERIASPP = 1 Then
                    analisis = 25
                    precio1 = preciolistspp
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.LISTERIAMONOCITOGENES = 1 Then
                    analisis = 141
                    precio1 = preciolistmono
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.RB = 1 Then
                    analisis = 1
                    precio1 = preciorb
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.MOHOSYLEVADURAS = 1 Then
                    analisis = 28
                    precio1 = preciomohos
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
            End If

            If subtipo = 60 Then
                analisis = 230
                precio1 = preciopaquete4
                Dim f1 As New dFacturacion
                f1.FICHA = ficha
                f1.CANTIDAD = muestras
                f1.ANALISIS = analisis
                f1.PRECIO = precio1
                f1.SUBTOTAL = muestras * precio1
                f1.FACTURA = 0
                f1.guardar(Usuario)
                f1 = Nothing
                If subp.HUMEDAD = 1 Then
                    analisis = 29
                    precio1 = preciohumedad
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.MGRASA = 1 Then
                    analisis = 30
                    precio1 = preciograsa
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.PH = 1 Then
                    analisis = 31
                    precio1 = precioph
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.CLORUROS = 1 Then
                    analisis = 10
                    precio1 = preciocloruros
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.PROTEINAS = 1 Then
                    analisis = 32
                    precio1 = precioproteinas
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.CENIZAS = 1 Then
                    analisis = 64
                    precio1 = preciocenizas
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ESPORANAERMESOFILO = 1 Then
                    analisis = 8
                    precio1 = precioesporulados
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.TERMOFILOS = 1 Then
                    analisis = 62
                    precio1 = preciotermoduricos
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.PSICROTROFOS = 1 Then
                    analisis = 61
                    precio1 = preciopsicrotrofos
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
                If subp.ENTEROBACTERIAS = 1 Then
                    analisis = 9
                    precio1 = precioenterobacterias
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestras
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio1
                    f2.SUBTOTAL = muestras * precio1
                    f2.FACTURA = 0
                    f2.guardar(Usuario)
                    f2 = Nothing
                End If
            End If
            If subp.SALMONELLAPOOL = 1 Then
                analisis = 232
                precio1 = preciosalmonellapool
                Dim f2 As New dFacturacion
                f2.FICHA = ficha
                f2.CANTIDAD = 1
                f2.ANALISIS = analisis
                f2.PRECIO = precio1
                f2.SUBTOTAL = precio1
                f2.FACTURA = 0
                f2.guardar(Usuario)
                f2 = Nothing
            End If
            If subp.LISTERIAPOOL = 1 Then
                analisis = 231
                precio1 = preciolisteriapool
                Dim f2 As New dFacturacion
                f2.FICHA = ficha
                f2.CANTIDAD = 1
                f2.ANALISIS = analisis
                f2.PRECIO = precio1
                f2.SUBTOTAL = precio1
                f2.FACTURA = 0
                f2.guardar(Usuario)
                f2 = Nothing
            End If
            'Next
        End If
    End Sub

    Private Sub factura_serologia()
        Dim lp As New dListaPrecios
        Dim idrosa As Integer = 235
        Dim preciorosa As Double = 0
        
        Dim c As New dCliente
        Dim precio As Integer = 0
        c.ID = TextIdProductor.Text.Trim
        c = c.buscar
        If Not c Is Nothing Then
            precio = c.FAC_LISTA
        End If

        If precio = 1 Then
            lp.ID = idrosa
            lp = lp.buscar
            preciorosa = lp.PRECIO1
        ElseIf precio = 2 Then
            lp.ID = idrosa
            lp = lp.buscar
            preciorosa = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciorosa = lp.PRECIO1
            End If
        ElseIf precio = 3 Then
            lp.ID = idrosa
            lp = lp.buscar
            preciorosa = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciorosa = lp.PRECIO1
            End If
        End If

        Dim ficha As Long = 0
        Dim sa As New dSolicitudAnalisis
        Dim muestras As Integer = 0
        ficha = TextId.Text.Trim
        sa.ID = ficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            muestras = sa.NMUESTRAS
        End If

        Dim analisis As Integer = 0
        Dim precio1 As Double = 0

        analisis = 235
        precio1 = preciorosa
        Dim f1 As New dFacturacion
        f1.FICHA = ficha
        f1.CANTIDAD = muestras
        f1.ANALISIS = analisis
        f1.PRECIO = precio1
        f1.SUBTOTAL = muestras * precio1
        f1.FACTURA = 0
        f1.guardar(Usuario)
        f1 = Nothing
    End Sub

    Private Sub factura_calidad()
        Dim ficha As Long = 0
        Dim muestras As Integer = 0
        ficha = TextId.Text.Trim
        Dim csm As New dCalidadSolicitudMuestra
        Dim listamuestras As New ArrayList
        listamuestras = csm.listarporsolicitud(ficha)
        muestras = listamuestras.Count
        Dim lp As New dListaPrecios
        Dim idrb As Integer = 1
        Dim idrc As Integer = 2
        Dim idcomposicion As Integer = 3
        Dim idinhibidores As Integer = 5
        Dim idcharm As Integer = 196
        Dim idurea As Integer = 60
        Dim idcrioscopia As Integer = 4
        Dim idesporulados As Integer = 8
        Dim idpsicrotrofos As Integer = 61
        Dim idtermoduricos As Integer = 237
        Dim idbact_cel_comp As Integer = 100
        Dim idbact_cel As Integer = 101
        Dim idcrioscopia_crioscopo As Integer = 102
        Dim idcaseina As Integer = 118
        Dim idaflatoxina As Integer = 162
        Dim idcomposicionsuero As Integer = 154
        Dim preciorb As Double
        Dim preciorc As Double
        Dim preciocomposicion As Double
        Dim precioinhibidores As Double
        Dim preciocharm As Double
        Dim preciourea As Double
        Dim preciocrioscopia As Double
        Dim precioesporulados As Double
        Dim preciopsicrotrofos As Double
        Dim preciotermoduricos As Double
        Dim preciobact_cel_comp As Double
        Dim preciobact_cel As Double
        Dim preciocrioscopia_crioscopo As Double
        Dim preciocaseina As Double
        Dim precioaflatoxina As Double
        Dim preciocomposicionsuero As Double
        Dim c As New dCliente
        Dim precio As Integer = 0
        c.ID = TextIdProductor.Text.Trim
        c = c.buscar
        If Not c Is Nothing Then
            precio = c.FAC_LISTA
        End If
        If precio = 1 Then
            lp.ID = idrb
            lp = lp.buscar
            preciorb = lp.PRECIO1
            lp.ID = idrc
            lp = lp.buscar
            preciorc = lp.PRECIO1
            lp.ID = idcomposicion
            lp = lp.buscar
            preciocomposicion = lp.PRECIO1
            lp.ID = idinhibidores
            lp = lp.buscar
            precioinhibidores = lp.PRECIO1
            lp.ID = idcharm
            lp = lp.buscar
            preciocharm = lp.PRECIO1
            lp.ID = idurea
            lp = lp.buscar
            preciourea = lp.PRECIO1
            lp.ID = idcrioscopia
            lp = lp.buscar
            preciocrioscopia = lp.PRECIO1
            lp.ID = idesporulados
            lp = lp.buscar
            precioesporulados = lp.PRECIO1
            lp.ID = idpsicrotrofos
            lp = lp.buscar
            preciopsicrotrofos = lp.PRECIO1
            lp.ID = idtermoduricos
            lp = lp.buscar
            preciotermoduricos = lp.PRECIO1
            lp.ID = idbact_cel_comp
            lp = lp.buscar
            preciobact_cel_comp = lp.PRECIO1
            lp.ID = idbact_cel
            lp = lp.buscar
            preciobact_cel = lp.PRECIO1
            lp.ID = idcrioscopia_crioscopo
            lp = lp.buscar
            preciocrioscopia_crioscopo = lp.PRECIO1
            lp.ID = idcaseina
            lp = lp.buscar
            preciocaseina = lp.PRECIO1
            lp.ID = idaflatoxina
            lp = lp.buscar
            precioaflatoxina = lp.PRECIO1
            lp.ID = idcomposicionsuero
            lp = lp.buscar
            preciocomposicionsuero = lp.PRECIO1
        ElseIf precio = 2 Then
            lp.ID = idrb
            lp = lp.buscar
            preciorb = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciorb = lp.PRECIO1
            End If
            lp.ID = idrc
            lp = lp.buscar
            preciorc = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciorc = lp.PRECIO1
            End If
            lp.ID = idcomposicion
            lp = lp.buscar
            preciocomposicion = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocomposicion = lp.PRECIO1
            End If
            lp.ID = idinhibidores
            lp = lp.buscar
            precioinhibidores = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioinhibidores = lp.PRECIO1
            End If
            lp.ID = idcharm
            lp = lp.buscar
            preciocharm = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocharm = lp.PRECIO1
            End If
            lp.ID = idurea
            lp = lp.buscar
            preciourea = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciourea = lp.PRECIO1
            End If
            lp.ID = idcrioscopia
            lp = lp.buscar
            preciocrioscopia = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocrioscopia = lp.PRECIO1
            End If
            lp.ID = idesporulados
            lp = lp.buscar
            precioesporulados = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioesporulados = lp.PRECIO1
            End If
            lp.ID = idpsicrotrofos
            lp = lp.buscar
            preciopsicrotrofos = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopsicrotrofos = lp.PRECIO1
            End If
            lp.ID = idtermoduricos
            lp = lp.buscar
            preciotermoduricos = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciotermoduricos = lp.PRECIO1
            End If
            lp.ID = idbact_cel_comp
            lp = lp.buscar
            preciobact_cel_comp = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciobact_cel_comp = lp.PRECIO1
            End If
            lp.ID = idbact_cel
            lp = lp.buscar
            preciobact_cel = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciobact_cel = lp.PRECIO1
            End If
            lp.ID = idcrioscopia_crioscopo
            lp = lp.buscar
            preciocrioscopia_crioscopo = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocrioscopia_crioscopo = lp.PRECIO1
            End If
            lp.ID = idcaseina
            lp = lp.buscar
            preciocaseina = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocaseina = lp.PRECIO1
            End If
            lp.ID = idaflatoxina
            lp = lp.buscar
            precioaflatoxina = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioaflatoxina = lp.PRECIO1
            End If
            lp.ID = idcomposicionsuero
            lp = lp.buscar
            preciocomposicionsuero = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocomposicionsuero = lp.PRECIO1
            End If
        ElseIf precio = 3 Then
            lp.ID = idrb
            lp = lp.buscar
            preciorb = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciorb = lp.PRECIO1
            End If
            lp.ID = idrc
            lp = lp.buscar
            preciorc = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciorc = lp.PRECIO1
            End If
            lp.ID = idcomposicion
            lp = lp.buscar
            preciocomposicion = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocomposicion = lp.PRECIO1
            End If
            lp.ID = idinhibidores
            lp = lp.buscar
            precioinhibidores = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioinhibidores = lp.PRECIO1
            End If
            lp.ID = idcharm
            lp = lp.buscar
            preciocharm = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocharm = lp.PRECIO1
            End If
            lp.ID = idurea
            lp = lp.buscar
            preciourea = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciourea = lp.PRECIO1
            End If
            lp.ID = idcrioscopia
            lp = lp.buscar
            preciocrioscopia = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocrioscopia = lp.PRECIO1
            End If
            lp.ID = idesporulados
            lp = lp.buscar
            precioesporulados = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioesporulados = lp.PRECIO1
            End If
            lp.ID = idpsicrotrofos
            lp = lp.buscar
            preciopsicrotrofos = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopsicrotrofos = lp.PRECIO1
            End If
            lp.ID = idtermoduricos
            lp = lp.buscar
            preciotermoduricos = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciotermoduricos = lp.PRECIO1
            End If
            lp.ID = idbact_cel_comp
            lp = lp.buscar
            preciobact_cel_comp = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciobact_cel_comp = lp.PRECIO1
            End If
            lp.ID = idbact_cel
            lp = lp.buscar
            preciobact_cel = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciobact_cel = lp.PRECIO1
            End If
            lp.ID = idcrioscopia_crioscopo
            lp = lp.buscar
            preciocrioscopia_crioscopo = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocrioscopia_crioscopo = lp.PRECIO1
            End If
            lp.ID = idcaseina
            lp = lp.buscar
            preciocaseina = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocaseina = lp.PRECIO1
            End If
            lp.ID = idaflatoxina
            lp = lp.buscar
            precioaflatoxina = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioaflatoxina = lp.PRECIO1
            End If
            lp.ID = idcomposicionsuero
            lp = lp.buscar
            preciocomposicionsuero = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocomposicionsuero = lp.PRECIO1
            End If
        End If

        Dim cuentarb As Integer = 0
        Dim cuentarc As Integer = 0
        Dim cuentacomposicion As Integer = 0
        Dim cuentainhibidores As Integer = 0
        Dim cuentacharm As Integer = 0
        Dim cuentaurea As Integer = 0
        Dim cuentacrioscopia As Integer = 0
        Dim cuentaesporulados As Integer = 0
        Dim cuentapsicrotrofos As Integer = 0
        Dim cuentatermoduricos As Integer = 0
        Dim cuentabact_cel_comp = 0
        Dim cuentabact_cel As Integer = 0
        Dim cuentacrioscopia_crioscopo As Integer = 0
        Dim cuentacaseina As Integer = 0
        Dim cuentaaflatoxina As Integer = 0
        Dim cuentacomposicionsuero As Integer = 0

        Dim listam As New ArrayList
        listam = csm.listarrb(ficha)
        If Not listam Is Nothing Then
            cuentarb = listam.Count
        End If
        listam = Nothing
        listam = csm.listarrc(ficha)
        If Not listam Is Nothing Then
            cuentarc = listam.Count
        End If
        listam = Nothing
        listam = csm.listarcomposicion(ficha)
        If Not listam Is Nothing Then
            cuentacomposicion = listam.Count
        End If
        listam = Nothing
        listam = csm.listarcrioscopia(ficha)
        If Not listam Is Nothing Then
            cuentacrioscopia = listam.Count
        End If
        listam = Nothing
        listam = csm.listarinhibidores(ficha)
        If Not listam Is Nothing Then
            cuentainhibidores = listam.Count
        End If
        listam = Nothing
        listam = csm.listarcharm(ficha)
        If Not listam Is Nothing Then
            cuentacharm = listam.Count
        End If
        listam = Nothing
        listam = csm.listaresporulados(ficha)
        If Not listam Is Nothing Then
            cuentaesporulados = listam.Count
        End If
        listam = Nothing
        listam = csm.listarurea(ficha)
        If Not listam Is Nothing Then
            cuentaurea = listam.Count
        End If
        listam = Nothing
        listam = csm.listartermofilos(ficha)
        If Not listam Is Nothing Then
            cuentatermoduricos = listam.Count
        End If
        listam = Nothing
        listam = csm.listarpsicrotrofos(ficha)
        If Not listam Is Nothing Then
            cuentapsicrotrofos = listam.Count
        End If
        listam = Nothing
        listam = csm.listarcrioscopia_crioscopo(ficha)
        If Not listam Is Nothing Then
            cuentacrioscopia_crioscopo = listam.Count
        End If
        listam = Nothing
        listam = csm.listar_caseina(ficha)
        If Not listam Is Nothing Then
            cuentacaseina = listam.Count
        End If
        listam = Nothing
        listam = csm.listar_aflatoxina(ficha)
        If Not listam Is Nothing Then
            cuentaaflatoxina = listam.Count
        End If
        listam = Nothing
        listam = csm.listarrb_rc(ficha)
        If Not listam Is Nothing Then
            cuentabact_cel = listam.Count
        End If
        listam = Nothing
        listam = csm.listarrb_rc_composicion(ficha)
        If Not listam Is Nothing Then
            cuentabact_cel_comp = listam.Count
        End If
        listam = Nothing
        listam = csm.listar_composicionsuero(ficha)
        If Not listam Is Nothing Then
            cuentacomposicionsuero = listam.Count
        End If
        listam = Nothing
        Dim analisis As Integer = 0
        Dim precio1 As Double = 0
        If cuentabact_cel_comp > 0 Then
            analisis = 100
            precio1 = preciobact_cel_comp
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentabact_cel_comp
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = muestras * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentabact_cel > cuentabact_cel_comp Then
            cuentabact_cel = cuentabact_cel - cuentabact_cel_comp
            analisis = 101
            precio1 = preciobact_cel
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentabact_cel
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = muestras * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentarb > (cuentabact_cel_comp + cuentabact_cel) Then
            cuentarb = cuentarb - cuentabact_cel_comp - cuentabact_cel
            analisis = 1
            precio1 = preciorb
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentarb
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = muestras * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentarc > (cuentabact_cel_comp + cuentabact_cel) Then
            cuentarc = cuentarc - cuentabact_cel_comp - cuentabact_cel
            analisis = 2
            precio1 = preciorc
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentarc
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = muestras * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentacomposicion > cuentabact_cel_comp Then
            cuentacomposicion = cuentacomposicion - cuentabact_cel_comp
            analisis = 3
            precio1 = preciocomposicion
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentacomposicion
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = muestras * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentacrioscopia > 0 Then
            analisis = 4
            precio1 = preciocrioscopia
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentacrioscopia
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = muestras * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentainhibidores > 0 Then
            analisis = 5
            precio1 = precioinhibidores
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentainhibidores
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = muestras * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentacharm > 0 Then
            analisis = 196
            precio1 = preciocharm
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentacharm
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = muestras * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentaesporulados > 0 Then
            analisis = 8
            precio1 = precioesporulados
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentaesporulados
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = muestras * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentaurea > 0 Then
            analisis = 60
            precio1 = preciourea
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentaurea
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = muestras * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentatermoduricos > 0 Then
            analisis = 237
            precio1 = preciotermoduricos
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentatermoduricos
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = muestras * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentapsicrotrofos > 0 Then
            analisis = 61
            precio1 = preciopsicrotrofos
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentapsicrotrofos
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = muestras * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentacrioscopia_crioscopo > 0 Then
            analisis = 102
            precio1 = preciocrioscopia_crioscopo
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentacrioscopia_crioscopo
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = muestras * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentacaseina > 0 Then
            analisis = 118
            precio1 = preciocaseina
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentacaseina
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = muestras * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentaaflatoxina > 0 Then
            analisis = 162
            precio1 = precioaflatoxina
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentaaflatoxina
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = muestras * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentacomposicionsuero > 0 Then
            analisis = 154
            precio1 = preciocomposicionsuero
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentacomposicionsuero
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = muestras * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
    End Sub
    Private Sub factura_ambiental()
        Dim ficha As Long = 0
        ficha = TextId.Text.Trim
        Dim amb As New dAmbiental
        Dim amb2 As New dAmbientalSolicitud
        Dim listamuestras As New ArrayList
        Dim listaanalisis As New ArrayList
        listamuestras = amb.listarporid(ficha)
        Dim muestras As Integer = listamuestras.Count
        Dim lp As New dListaPrecios
        Dim idlistambiental As Integer = 26
        Dim idct As Integer = 151
        Dim idcf As Integer = 152
        Dim idpseudomonaspp As Integer = 153
        Dim idmesofilos As Integer = 228
        Dim identerobacterias As Integer = 122
        Dim idmohosylevaduras As Integer = 28
        Dim idsalmonella As Integer = 27
        Dim idecoli As Integer = 251
        Dim preciolistambiental As Double = 0
        Dim precioct As Double = 0
        Dim preciocf As Double = 0
        Dim preciopseudomonaspp As Double = 0
        Dim preciomesofilos As Double = 0
        Dim precioenterobacterias As Double = 0
        Dim preciomohosylevaduras As Double = 0
        Dim preciosalmonella As Double = 0
        Dim precioecoli As Double = 0
        Dim c As New dCliente
        Dim precio As Integer = 0
        c.ID = TextIdProductor.Text.Trim
        c = c.buscar
        If Not c Is Nothing Then
            precio = c.FAC_LISTA
        End If
        If precio = 1 Then
            lp.ID = idlistambiental
            lp = lp.buscar
            preciolistambiental = lp.PRECIO1
            lp.ID = idct
            lp = lp.buscar
            precioct = lp.PRECIO1
            lp.ID = idcf
            lp = lp.buscar
            preciocf = lp.PRECIO1
            lp.ID = idpseudomonaspp
            lp = lp.buscar
            preciopseudomonaspp = lp.PRECIO1
            lp.ID = idmesofilos
            lp = lp.buscar
            preciomesofilos = lp.PRECIO1
            lp.ID = identerobacterias
            lp = lp.buscar
            precioenterobacterias = lp.PRECIO1
            lp.ID = idmohosylevaduras
            lp = lp.buscar
            preciomohosylevaduras = lp.PRECIO1
            lp.ID = idsalmonella
            lp = lp.buscar
            preciosalmonella = lp.PRECIO1
            lp.ID = idecoli
            lp = lp.buscar
            precioecoli = lp.PRECIO1
        ElseIf precio = 2 Then
            lp.ID = idlistambiental
            lp = lp.buscar
            preciolistambiental = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciolistambiental = lp.PRECIO1
            End If
            lp.ID = idct
            lp = lp.buscar
            precioct = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioct = lp.PRECIO1
            End If
            lp.ID = idcf
            lp = lp.buscar
            preciocf = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocf = lp.PRECIO1
            End If
            lp.ID = idpseudomonaspp
            lp = lp.buscar
            preciopseudomonaspp = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopseudomonaspp = lp.PRECIO1
            End If
            lp.ID = idmesofilos
            lp = lp.buscar
            preciomesofilos = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciomesofilos = lp.PRECIO1
            End If
            lp.ID = identerobacterias
            lp = lp.buscar
            precioenterobacterias = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioenterobacterias = lp.PRECIO1
            End If
            lp.ID = idmohosylevaduras
            lp = lp.buscar
            preciomohosylevaduras = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciomohosylevaduras = lp.PRECIO1
            End If
            lp.ID = idsalmonella
            lp = lp.buscar
            preciosalmonella = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciosalmonella = lp.PRECIO1
            End If
            lp.ID = idecoli
            lp = lp.buscar
            precioecoli = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioecoli = lp.PRECIO1
            End If
        ElseIf precio = 3 Then
            lp.ID = idlistambiental
            lp = lp.buscar
            preciolistambiental = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciolistambiental = lp.PRECIO1
            End If
            lp.ID = idct
            lp = lp.buscar
            precioct = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioct = lp.PRECIO1
            End If
            lp.ID = idcf
            lp = lp.buscar
            preciocf = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocf = lp.PRECIO1
            End If
            lp.ID = idpseudomonaspp
            lp = lp.buscar
            preciopseudomonaspp = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopseudomonaspp = lp.PRECIO1
            End If
            lp.ID = idmesofilos
            lp = lp.buscar
            preciomesofilos = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciomesofilos = lp.PRECIO1
            End If
            lp.ID = identerobacterias
            lp = lp.buscar
            precioenterobacterias = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioenterobacterias = lp.PRECIO1
            End If
            lp.ID = idmohosylevaduras
            lp = lp.buscar
            preciomohosylevaduras = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciomohosylevaduras = lp.PRECIO1
            End If
            lp.ID = idsalmonella
            lp = lp.buscar
            preciosalmonella = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciosalmonella = lp.PRECIO1
            End If
            lp.ID = idecoli
            lp = lp.buscar
            precioecoli = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioecoli = lp.PRECIO1
            End If
        End If
        listaanalisis = amb2.listarporsolicitud(ficha)
        Dim analisis As Integer = 0
        Dim precio1 As Double = 0
        If Not listaanalisis Is Nothing Then
            For Each amb2 In listaanalisis
                If amb2.LISTAMBIENTAL = 1 Then
                    analisis = 26
                    precio1 = preciolistambiental
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If amb2.CT = 1 Then
                    analisis = 151
                    precio1 = precioct
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If amb2.CF = 1 Then
                    analisis = 152
                    precio1 = preciocf
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If amb2.PSEUDOMONASPP = 1 Then
                    analisis = 153
                    precio1 = preciopseudomonaspp
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If amb2.ENTEROBACTERIAS = 1 Then
                    analisis = 122
                    precio1 = precioenterobacterias
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If amb2.MOHOSYLEVADURAS = 1 Then
                    analisis = 28
                    precio1 = preciomohosylevaduras
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If amb2.SALMONELLA = 1 Then
                    analisis = 27
                    precio1 = preciosalmonella
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If amb2.RB = 1 Then
                    analisis = 228
                    precio1 = preciomesofilos
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
                If amb2.ECOLI = 1 Then
                    analisis = 251
                    precio1 = precioecoli
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestras
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = muestras * precio1
                    f1.FACTURA = 0
                    f1.guardar(Usuario)
                    f1 = Nothing
                End If
            Next
        End If
    End Sub

    Private Sub factura_nutricion()
        Dim ficha As Long = 0
        ficha = TextId.Text.Trim
        Dim n As New dNutricion
        Dim listamuestras As New ArrayList
        listamuestras = n.listarporid(ficha)
        Dim muestras As Integer = listamuestras.Count
        Dim lp As New dListaPrecios
        Dim paquete1a As Integer = 125
        Dim paquete1b As Integer = 126
        Dim paquete2 As Integer = 127
        Dim paquete3 As Integer = 128
        Dim paquete4 As Integer = 129
        Dim paquete5 As Integer = 130
        Dim paquetemicotoxinas As Integer = 160
        Dim idmicotoxinas As Integer = 161
        Dim idproteinas As Integer = 159
        Dim idmateriaseca As Integer = 164
        Dim idph As Integer = 165
        Dim idfibraefectiva As Integer = 191
        Dim idfibras As Integer = 259
        Dim preciopaquete1a As Double = 0
        Dim preciopaquete1b As Double = 0
        Dim preciopaquete2 As Double = 0
        Dim preciopaquete3 As Double = 0
        Dim preciopaquete4 As Double = 0
        Dim preciopaquete5 As Double = 0
        Dim preciopaquetemicotoxinas As Double = 0
        Dim preciomicotoxinas As Double = 0
        Dim precioproteinas As Double = 0
        Dim preciomateriaseca As Double = 0
        Dim precioph As Double = 0
        Dim preciofibraefectiva As Double = 0
        Dim preciofibras As Double = 0
        Dim c As New dCliente
        Dim precio As Integer = 0
        c.ID = TextIdProductor.Text.Trim
        c = c.buscar
        If Not c Is Nothing Then
            precio = c.FAC_LISTA
        End If
        If precio = 1 Then
            lp.ID = paquete1a
            lp = lp.buscar
            preciopaquete1a = lp.PRECIO1
            lp.ID = paquete1b
            lp = lp.buscar
            preciopaquete1b = lp.PRECIO1
            lp.ID = paquete2
            lp = lp.buscar
            preciopaquete2 = lp.PRECIO1
            lp.ID = paquete3
            lp = lp.buscar
            preciopaquete3 = lp.PRECIO1
            lp.ID = paquete4
            lp = lp.buscar
            preciopaquete4 = lp.PRECIO1
            lp.ID = paquete5
            lp = lp.buscar
            preciopaquete5 = lp.PRECIO1
            lp.ID = paquetemicotoxinas
            lp = lp.buscar
            preciopaquetemicotoxinas = lp.PRECIO1
            lp.ID = idmicotoxinas
            lp = lp.buscar
            preciomicotoxinas = lp.PRECIO1
            lp.ID = idproteinas
            lp = lp.buscar
            precioproteinas = lp.PRECIO1
            lp.ID = idmateriaseca
            lp = lp.buscar
            preciomateriaseca = lp.PRECIO1
            lp.ID = idph
            lp = lp.buscar
            precioph = lp.PRECIO1
            lp.ID = idfibraefectiva
            lp = lp.buscar
            preciofibraefectiva = lp.PRECIO1
            lp.ID = idfibras
            lp = lp.buscar
            preciofibras = lp.PRECIO1
        ElseIf precio = 2 Then
            lp.ID = paquete1a
            lp = lp.buscar
            preciopaquete1a = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaquete1a = lp.PRECIO1
            End If
            lp.ID = paquete1b
            lp = lp.buscar
            preciopaquete1b = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaquete1b = lp.PRECIO1
            End If
            lp.ID = paquete2
            lp = lp.buscar
            preciopaquete2 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaquete2 = lp.PRECIO1
            End If
            lp.ID = paquete3
            lp = lp.buscar
            preciopaquete3 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaquete3 = lp.PRECIO1
            End If
            lp.ID = paquete4
            lp = lp.buscar
            preciopaquete4 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaquete4 = lp.PRECIO1
            End If
            lp.ID = paquete5
            lp = lp.buscar
            preciopaquete5 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaquete5 = lp.PRECIO1
            End If
            lp.ID = paquetemicotoxinas
            lp = lp.buscar
            preciopaquetemicotoxinas = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaquetemicotoxinas = lp.PRECIO1
            End If
            lp.ID = idmicotoxinas
            lp = lp.buscar
            preciomicotoxinas = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciomicotoxinas = lp.PRECIO1
            End If
            lp.ID = idproteinas
            lp = lp.buscar
            precioproteinas = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioproteinas = lp.PRECIO1
            End If
            lp.ID = idmateriaseca
            lp = lp.buscar
            preciomateriaseca = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciomateriaseca = lp.PRECIO1
            End If
            lp.ID = idph
            lp = lp.buscar
            precioph = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioph = lp.PRECIO1
            End If
            lp.ID = idfibraefectiva
            lp = lp.buscar
            preciofibraefectiva = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciofibraefectiva = lp.PRECIO1
            End If
            lp.ID = idfibras
            lp = lp.buscar
            preciofibras = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciofibras = lp.PRECIO1
            End If
        ElseIf precio = 3 Then
            lp.ID = paquete1a
            lp = lp.buscar
            preciopaquete1a = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaquete1a = lp.PRECIO1
            End If
            lp.ID = paquete1b
            lp = lp.buscar
            preciopaquete1b = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaquete1b = lp.PRECIO1
            End If
            lp.ID = paquete2
            lp = lp.buscar
            preciopaquete2 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaquete2 = lp.PRECIO1
            End If
            lp.ID = paquete3
            lp = lp.buscar
            preciopaquete3 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaquete3 = lp.PRECIO1
            End If
            lp.ID = paquete4
            lp = lp.buscar
            preciopaquete4 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaquete4 = lp.PRECIO1
            End If
            lp.ID = paquete5
            lp = lp.buscar
            preciopaquete5 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaquete5 = lp.PRECIO1
            End If
            lp.ID = paquetemicotoxinas
            lp = lp.buscar
            preciopaquetemicotoxinas = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaquetemicotoxinas = lp.PRECIO1
            End If
            lp.ID = idmicotoxinas
            lp = lp.buscar
            preciomicotoxinas = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciomicotoxinas = lp.PRECIO1
            End If
            lp.ID = idproteinas
            lp = lp.buscar
            precioproteinas = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioproteinas = lp.PRECIO1
            End If
            lp.ID = idmateriaseca
            lp = lp.buscar
            preciomateriaseca = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciomateriaseca = lp.PRECIO1
            End If
            lp.ID = idph
            lp = lp.buscar
            precioph = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioph = lp.PRECIO1
            End If
            lp.ID = idfibraefectiva
            lp = lp.buscar
            preciofibraefectiva = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciofibraefectiva = lp.PRECIO1
            End If
            lp.ID = idfibras
            lp = lp.buscar
            preciofibras = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciofibras = lp.PRECIO1
            End If
        End If
        Dim cuentapaquete1a As Integer = 0
        Dim cuentapaquete1b As Integer = 0
        Dim cuentapaquete2 As Integer = 0
        Dim cuentapaquete3 As Integer = 0
        Dim cuentapaquete4 As Integer = 0
        Dim cuentapaquete5 As Integer = 0
        Dim cuentapaquetemicotoxinas As Integer = 0
        Dim cuentamicotoxinas As Integer = 0
        Dim cuentaproteinas As Integer = 0
        Dim cuentamateriaseca As Integer = 0
        Dim cuentaph As Integer = 0
        Dim cuentafibraefectiva As Integer = 0
        Dim cuentafibras As Integer = 0
        Dim sn2 As New dSolicitudNutricion
        Dim listaanalisis As New ArrayList
        listaanalisis = sn2.listarporsolicitud(ficha)
        If Not listaanalisis Is Nothing Then
            For Each sn2 In listaanalisis
                If sn2.MGA = 1 Then
                    cuentapaquete1a = cuentapaquete1a + 1
                End If
                If sn2.MGB = 1 Then
                    cuentapaquete1b = cuentapaquete1b + 1
                End If
                If sn2.ENSILADOS = 1 Then
                    cuentapaquete2 = cuentapaquete2 + 1
                End If
                If sn2.PASTURAS = 1 Then
                    cuentapaquete3 = cuentapaquete3 + 1
                End If
                If sn2.EXTETEREO = 1 Then
                    cuentapaquete4 = cuentapaquete4 + 1
                End If
                If sn2.NIDA = 1 Then
                    cuentapaquete5 = cuentapaquete5 + 1
                End If
                If sn2.FIBRAACIDA = 1 And sn2.FIBRANEUTRA = 1 Then
                    cuentafibras = cuentafibras + 1
                End If
                If sn2.DON = 1 And sn2.AFLA = 1 And sn2.ZEARA = 1 Then
                    cuentapaquetemicotoxinas = cuentapaquetemicotoxinas + 1
                Else
                    If sn2.DON = 1 Then
                        cuentamicotoxinas = cuentamicotoxinas + 1
                    End If
                    If sn2.AFLA = 1 Then
                        cuentamicotoxinas = cuentamicotoxinas + 1
                    End If
                    If sn2.ZEARA = 1 Then
                        cuentamicotoxinas = cuentamicotoxinas + 1
                    End If
                End If
                If sn2.PROTEINAS = 1 Then
                    cuentaproteinas = cuentaproteinas + 1
                End If
                If sn2.MATERIASECA = 1 Then
                    cuentamateriaseca = cuentamateriaseca + 1
                End If
                If sn2.PH = 1 Then
                    cuentaph = cuentaph + 1
                End If
                If sn2.FIBRAEFECTIVA = 1 Then
                    cuentafibraefectiva = cuentafibraefectiva + 1
                End If
            Next
        End If
        Dim analisis As Integer = 0
        Dim precio1 As Double = 0
        If cuentapaquete1a > 0 Then
            analisis = 125
            precio1 = preciopaquete1a
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentapaquete1a
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentapaquete1a * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentapaquete1b > 0 Then
            analisis = 126
            precio1 = preciopaquete1b
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentapaquete1b
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentapaquete1b * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentapaquete2 > 0 Then
            analisis = 127
            precio1 = preciopaquete2
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentapaquete2
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentapaquete2 * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentapaquete3 > 0 Then
            analisis = 128
            precio1 = preciopaquete3
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentapaquete3
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentapaquete3 * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentapaquete4 > 0 Then
            analisis = 129
            precio1 = preciopaquete4
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentapaquete4
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentapaquete4 * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentapaquete5 > 0 Then
            analisis = 130
            precio1 = preciopaquete5
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentapaquete5
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentapaquete5 * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentafibras > 0 Then
            analisis = 259
            precio1 = preciofibras
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentafibras
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentafibras * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentapaquetemicotoxinas > 0 Then
            analisis = 160
            precio1 = preciopaquetemicotoxinas
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentapaquetemicotoxinas
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentapaquetemicotoxinas * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentamicotoxinas > 0 Then
            analisis = 161
            precio1 = preciomicotoxinas
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentamicotoxinas
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentamicotoxinas * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentaproteinas > 0 Then
            analisis = 159
            precio1 = precioproteinas
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentaproteinas
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentaproteinas * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentamateriaseca > 0 Then
            analisis = 164
            precio1 = preciomateriaseca
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentamateriaseca
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentamateriaseca * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentaph > 0 Then
            analisis = 165
            precio1 = precioph
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentaph
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentaph * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentafibraefectiva > 0 Then
            analisis = 191
            precio1 = preciofibraefectiva
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentafibraefectiva
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentafibraefectiva * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
    End Sub
    Private Sub factura_suelos()
        Dim ficha As Long = 0
        ficha = TextId.Text.Trim
        Dim lp As New dListaPrecios
        Dim idfosforobray As Integer = 131
        Dim idfosforocitrico As Integer = 132
        Dim idnitratos As Integer = 133
        Dim idphagua As Integer = 134
        Dim idphkci As Integer = 135
        Dim idpotasio As Integer = 136
        Dim idsulfatos As Integer = 137
        Dim idnitrogenovegetal As Integer = 138
        Dim idmateriaorganica As Integer = 139
        Dim idpmn As Integer = 140
        Dim idpaq1 As Integer = 142
        Dim idpaq2 As Integer = 143
        Dim idpaq3 As Integer = 144
        Dim idpaq4 As Integer = 145
        Dim idpaq5 As Integer = 189
        Dim idmuestreo As Integer = 241
        Dim idzinc As Integer = 192
        Dim idcalcioymagnesio As Integer = 219
        Dim preciofosforobray As Double = 0
        Dim preciofosforcitrico As Double = 0
        Dim precionitratos As Double = 0
        Dim preciophagua As Double = 0
        Dim preciophkci As Double = 0
        Dim preciopotasio As Double = 0
        Dim preciosulfatos As Double = 0
        Dim precionitrogenovegetal As Double = 0
        Dim preciomateriaorganica As Double = 0
        Dim preciopmn As Double = 0
        Dim preciopaq1 As Double = 0
        Dim preciopaq2 As Double = 0
        Dim preciopaq3 As Double = 0
        Dim preciopaq4 As Double = 0
        Dim preciopaq5 As Double = 0
        Dim preciomuestreo As Double = 0
        Dim preciozinc As Double = 0
        Dim preciocalcioymagnesio As Double = 0
        Dim c As New dCliente
        Dim precio As Integer = 0
        c.ID = TextIdProductor.Text.Trim
        c = c.buscar
        If Not c Is Nothing Then
            precio = c.FAC_LISTA
        End If
        If precio = 1 Then
            lp.ID = idfosforobray
            lp = lp.buscar
            preciofosforobray = lp.PRECIO1
            lp.ID = idfosforocitrico
            lp = lp.buscar
            preciofosforcitrico = lp.PRECIO1
            lp.ID = idnitratos
            lp = lp.buscar
            precionitratos = lp.PRECIO1
            lp.ID = idphagua
            lp = lp.buscar
            preciophagua = lp.PRECIO1
            lp.ID = idphkci
            lp = lp.buscar
            preciophkci = lp.PRECIO1
            lp.ID = idpotasio
            lp = lp.buscar
            preciopotasio = lp.PRECIO1
            lp.ID = idsulfatos
            lp = lp.buscar
            preciosulfatos = lp.PRECIO1
            lp.ID = idnitrogenovegetal
            lp = lp.buscar
            precionitrogenovegetal = lp.PRECIO1
            lp.ID = idmateriaorganica
            lp = lp.buscar
            preciomateriaorganica = lp.PRECIO1
            lp.ID = idpmn
            lp = lp.buscar
            preciopmn = lp.PRECIO1
            lp.ID = idpaq1
            lp = lp.buscar
            preciopaq1 = lp.PRECIO1
            lp.ID = idpaq2
            lp = lp.buscar
            preciopaq2 = lp.PRECIO1
            lp.ID = idpaq3
            lp = lp.buscar
            preciopaq3 = lp.PRECIO1
            lp.ID = idpaq4
            lp = lp.buscar
            preciopaq4 = lp.PRECIO1
            lp.ID = idpaq5
            lp = lp.buscar
            preciopaq5 = lp.PRECIO1
            lp.ID = idmuestreo
            lp = lp.buscar
            preciomuestreo = lp.PRECIO1
            lp.ID = idzinc
            lp = lp.buscar
            preciozinc = lp.PRECIO1
            lp.ID = idcalcioymagnesio
            lp = lp.buscar
            preciocalcioymagnesio = lp.PRECIO1
        ElseIf precio = 2 Then
            lp.ID = idfosforobray
            lp = lp.buscar
            preciofosforobray = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciofosforobray = lp.PRECIO1
            End If
            lp.ID = idfosforocitrico
            lp = lp.buscar
            preciofosforcitrico = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciofosforcitrico = lp.PRECIO1
            End If
            lp.ID = idnitratos
            lp = lp.buscar
            precionitratos = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precionitratos = lp.PRECIO1
            End If
            lp.ID = idphagua
            lp = lp.buscar
            preciophagua = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciophagua = lp.PRECIO1
            End If
            lp.ID = idphkci
            lp = lp.buscar
            preciophkci = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciophkci = lp.PRECIO1
            End If
            lp.ID = idpotasio
            lp = lp.buscar
            preciopotasio = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopotasio = lp.PRECIO1
            End If
            lp.ID = idsulfatos
            lp = lp.buscar
            preciosulfatos = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciosulfatos = lp.PRECIO1
            End If
            lp.ID = idnitrogenovegetal
            lp = lp.buscar
            precionitrogenovegetal = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precionitrogenovegetal = lp.PRECIO1
            End If
            lp.ID = idmateriaorganica
            lp = lp.buscar
            preciomateriaorganica = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciomateriaorganica = lp.PRECIO1
            End If
            lp.ID = idpmn
            lp = lp.buscar
            preciopmn = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopmn = lp.PRECIO1
            End If
            lp.ID = idpaq1
            lp = lp.buscar
            preciopaq1 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaq1 = lp.PRECIO1
            End If
            lp.ID = idpaq2
            lp = lp.buscar
            preciopaq2 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaq2 = lp.PRECIO1
            End If
            lp.ID = idpaq3
            lp = lp.buscar
            preciopaq3 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaq3 = lp.PRECIO1
            End If
            lp.ID = idpaq4
            lp = lp.buscar
            preciopaq4 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaq4 = lp.PRECIO1
            End If
            lp.ID = idpaq5
            lp = lp.buscar
            preciopaq5 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaq5 = lp.PRECIO1
            End If
            lp.ID = idmuestreo
            lp = lp.buscar
            preciomuestreo = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciomuestreo = lp.PRECIO1
            End If
            lp.ID = idzinc
            lp = lp.buscar
            preciozinc = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciozinc = lp.PRECIO1
            End If
            lp.ID = idcalcioymagnesio
            lp = lp.buscar
            preciocalcioymagnesio = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocalcioymagnesio = lp.PRECIO1
            End If
        ElseIf precio = 3 Then
            lp.ID = idfosforobray
            lp = lp.buscar
            preciofosforobray = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciofosforobray = lp.PRECIO1
            End If
            lp.ID = idfosforocitrico
            lp = lp.buscar
            preciofosforcitrico = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciofosforcitrico = lp.PRECIO1
            End If
            lp.ID = idnitratos
            lp = lp.buscar
            precionitratos = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precionitratos = lp.PRECIO1
            End If
            lp.ID = idphagua
            lp = lp.buscar
            preciophagua = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciophagua = lp.PRECIO1
            End If
            lp.ID = idphkci
            lp = lp.buscar
            preciophkci = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciophkci = lp.PRECIO1
            End If
            lp.ID = idpotasio
            lp = lp.buscar
            preciopotasio = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopotasio = lp.PRECIO1
            End If
            lp.ID = idsulfatos
            lp = lp.buscar
            preciosulfatos = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciosulfatos = lp.PRECIO1
            End If
            lp.ID = idnitrogenovegetal
            lp = lp.buscar
            precionitrogenovegetal = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precionitrogenovegetal = lp.PRECIO1
            End If
            lp.ID = idmateriaorganica
            lp = lp.buscar
            preciomateriaorganica = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciomateriaorganica = lp.PRECIO1
            End If
            lp.ID = idpmn
            lp = lp.buscar
            preciopmn = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopmn = lp.PRECIO1
            End If
            lp.ID = idpaq1
            lp = lp.buscar
            preciopaq1 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaq1 = lp.PRECIO1
            End If
            lp.ID = idpaq2
            lp = lp.buscar
            preciopaq2 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaq2 = lp.PRECIO1
            End If
            lp.ID = idpaq3
            lp = lp.buscar
            preciopaq3 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaq3 = lp.PRECIO1
            End If
            lp.ID = idpaq4
            lp = lp.buscar
            preciopaq4 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaq4 = lp.PRECIO1
            End If
            lp.ID = idpaq5
            lp = lp.buscar
            preciopaq5 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaq5 = lp.PRECIO1
            End If
            lp.ID = idmuestreo
            lp = lp.buscar
            preciomuestreo = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciomuestreo = lp.PRECIO1
            End If
            lp.ID = idzinc
            lp = lp.buscar
            preciozinc = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciozinc = lp.PRECIO1
            End If
            lp.ID = idcalcioymagnesio
            lp = lp.buscar
            preciocalcioymagnesio = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocalcioymagnesio = lp.PRECIO1
            End If
        End If
        Dim listamuestras As New ArrayList
        Dim ss As New dSolicitudSuelos
        listamuestras = ss.listarporsolicitud(ficha)
        Dim cuentafosforobray As Double = 0
        Dim cuentafosforcitrico As Double = 0
        Dim cuentanitratos As Double = 0
        Dim cuentaphagua As Double = 0
        Dim cuentaphkci As Double = 0
        Dim cuentapotasio As Double = 0
        Dim cuentasulfatos As Double = 0
        Dim cuentanitrogenovegetal As Double = 0
        Dim cuentamateriaorganica As Double = 0
        Dim cuentapmn As Double = 0
        Dim cuentapaq1 As Double = 0
        Dim cuentapaq2 As Double = 0
        Dim cuentapaq3 As Double = 0
        Dim cuentapaq4 As Double = 0
        Dim cuentapaq5 As Double = 0
        Dim cuentamuestreo As Double = 0
        Dim cuentazinc As Double = 0
        Dim cuentacalcioymagnesio As Double = 0
        If Not listamuestras Is Nothing Then
            For Each ss In listamuestras
                If ss.FOSFOROBRAY = 1 Then
                    cuentafosforobray = cuentafosforobray + 1
                End If
                If ss.FOSFOROCITRICO = 1 Then
                    cuentafosforcitrico = cuentafosforcitrico + 1
                End If
                If ss.NITRATOS = 1 Then
                    cuentanitratos = cuentanitratos + 1
                End If
                If ss.PHAGUA = 1 Then
                    cuentaphagua = cuentaphagua + 1
                End If
                If ss.PHKCI = 1 Then
                    cuentaphkci = cuentaphkci + 1
                End If
                If ss.POTASIOINT = 1 Then
                    cuentapotasio = cuentapotasio + 1
                End If
                If ss.SULFATOS = 1 Then
                    cuentasulfatos = cuentasulfatos + 1
                End If
                If ss.NITROGENOVEGETAL = 1 Then
                    cuentanitrogenovegetal = cuentanitrogenovegetal + 1
                End If
                If ss.MATERIAORG = 1 Then
                    cuentamateriaorganica = cuentamateriaorganica + 1
                End If
                If ss.MINERALIZACION = 1 Then
                    cuentapmn = cuentapmn + 1
                End If
                If ss.ZINC = 1 Then
                    cuentazinc = cuentazinc + 1
                End If
                If ss.PAQUETE = 1 Then
                    cuentapaq1 = cuentapaq1 + 1
                End If
                If ss.PAQUETE = 2 Then
                    cuentapaq2 = cuentapaq2 + 1
                End If
                If ss.PAQUETE = 3 Then
                    cuentapaq3 = cuentapaq3 + 1
                End If
                If ss.PAQUETE = 4 Then
                    cuentapaq4 = cuentapaq4 + 1
                End If
                If ss.PAQUETE = 5 Then
                    cuentapaq5 = cuentapaq5 + 1
                End If
                If ss.CALCIO = 1 And ss.MAGNESIO = 1 Then
                    cuentacalcioymagnesio = cuentacalcioymagnesio + 1
                End If
            Next
        End If
        Dim analisis As Integer = 0
        Dim precio1 As Double = 0
        If cuentapaq1 > 0 Then
            analisis = 142
            precio1 = preciopaq1
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentapaq1
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentapaq1 * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentapaq2 > 0 Then
            analisis = 143
            precio1 = preciopaq2
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentapaq2
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentapaq2 * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentapaq3 > 0 Then
            analisis = 144
            precio1 = preciopaq3
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentapaq3
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentapaq3 * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentapaq4 > 0 Then
            analisis = 145
            precio1 = preciopaq4
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentapaq4
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentapaq4 * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentapaq5 > 0 Then
            analisis = 189
            precio1 = preciopaq5
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentapaq5
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentapaq5 * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentacalcioymagnesio > 0 Then
            analisis = 219
            precio1 = preciocalcioymagnesio
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentacalcioymagnesio
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentacalcioymagnesio * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentafosforobray > 0 Then
            analisis = 131
            precio1 = preciofosforobray
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentafosforobray
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentafosforobray * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentafosforcitrico > 0 Then
            analisis = 132
            precio1 = preciofosforcitrico
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentafosforcitrico
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentafosforcitrico * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentanitratos > 0 Then
            analisis = 133
            precio1 = precionitratos
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentanitratos
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentanitratos * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentaphagua > 0 Then
            analisis = 134
            precio1 = preciophagua
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentaphagua
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentaphagua * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentaphkci > 0 Then
            analisis = 135
            precio1 = preciophkci
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentaphkci
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentaphkci * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentapotasio > 0 Then
            analisis = 136
            precio1 = preciopotasio
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentapotasio
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentapotasio * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentasulfatos > 0 Then
            analisis = 137
            precio1 = preciosulfatos
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentasulfatos
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentasulfatos * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentanitrogenovegetal > 0 Then
            analisis = 138
            precio1 = precionitrogenovegetal
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentanitrogenovegetal
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentanitrogenovegetal * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentamateriaorganica > 0 Then
            analisis = 139
            precio1 = preciomateriaorganica
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentamateriaorganica
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentamateriaorganica * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentapmn > 0 Then
            analisis = 140
            precio1 = preciopmn
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentapmn
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentapmn * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If
        If cuentazinc > 0 Then
            analisis = 192
            precio1 = preciozinc
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = cuentazinc
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = cuentazinc * precio1
            f1.FACTURA = 0
            f1.guardar(Usuario)
            f1 = Nothing
        End If

        If cuentamuestreo > 0 Then

        End If
        'If ss2.MUESTREO = 1 Then
        '    Dim sakm As New dSolicitudAnalisis
        '    sakm.ID = ficha
        '    sakm = sakm.buscar
        '    If Not sakm Is Nothing Then
        '        If sakm.KMTS > 0 Then
        '            Dim viatico As Double = 0
        '            viatico = preciomuestreo * sakm.KMTS
        '            total = total + viatico
        '        End If
        '    End If
        'End If
    End Sub
    Private Sub factura_brucelosisleche()
        Dim lp As New dListaPrecios
        Dim idbrucelosis As Integer = 124
        Dim preciobrucelosis As Double = 0
        lp.ID = idbrucelosis
        lp = lp.buscar
        preciobrucelosis = lp.PRECIO1
        Dim c As New dCliente
        Dim precio As Integer = 0
        c.ID = TextIdProductor.Text.Trim
        c = c.buscar
        If Not c Is Nothing Then
            precio = c.FAC_LISTA
        End If
        If precio = 1 Then
            lp.ID = idbrucelosis
            lp = lp.buscar
            preciobrucelosis = lp.PRECIO1
        ElseIf precio = 2 Then
            lp.ID = idbrucelosis
            lp = lp.buscar
            preciobrucelosis = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciobrucelosis = lp.PRECIO1
            End If
        ElseIf precio = 3 Then
            lp.ID = idbrucelosis
            lp = lp.buscar
            preciobrucelosis = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciobrucelosis = lp.PRECIO1
            End If
        End If
        Dim ficha As Long = 0
        Dim sa As New dSolicitudAnalisis
        Dim muestras As Integer = 0
        ficha = TextId.Text.Trim
        sa.ID = ficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            muestras = sa.NMUESTRAS
        End If
        Dim analisis As Integer = 0
        Dim precio1 As Double = 0
        analisis = 124
        precio1 = preciobrucelosis
        Dim f1 As New dFacturacion
        f1.FICHA = ficha
        f1.CANTIDAD = muestras
        f1.ANALISIS = analisis
        f1.PRECIO = precio1
        f1.SUBTOTAL = muestras * precio1
        f1.FACTURA = 0
        f1.guardar(Usuario)
        f1 = Nothing
    End Sub
    Private Sub factura_parasitologia()
        Dim lp As New dListaPrecios
        Dim idcoccidias As Integer = 35
        Dim idcopro_bov As Integer = 33
        Dim idcopro_can As Integer = 247
        Dim idfasciolasis As Integer = 34
        Dim preciococcidias As Double = 0
        Dim preciocopro_bov As Double = 0
        Dim preciocopro_can As Double = 0
        Dim preciofasciolasis As Double = 0

        Dim c As New dCliente
        Dim precio As Integer = 0
        c.ID = TextIdProductor.Text.Trim
        c = c.buscar
        If Not c Is Nothing Then
            precio = c.FAC_LISTA
        End If

        If precio = 1 Then
            lp.ID = idcoccidias
            lp = lp.buscar
            preciococcidias = lp.PRECIO1
            lp.ID = idcopro_bov
            lp = lp.buscar
            preciocopro_bov = lp.PRECIO1
            lp.ID = idcopro_can
            lp = lp.buscar
            preciocopro_can = lp.PRECIO1
            lp.ID = idfasciolasis
            lp = lp.buscar
            preciofasciolasis = lp.PRECIO1
        ElseIf precio = 2 Then
            lp.ID = idcoccidias
            lp = lp.buscar
            preciococcidias = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciococcidias = lp.PRECIO1
            End If
            lp.ID = idcopro_bov
            lp = lp.buscar
            preciocopro_bov = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocopro_bov = lp.PRECIO1
            End If
            lp.ID = idcopro_can
            lp = lp.buscar
            preciocopro_can = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocopro_can = lp.PRECIO1
            End If
            lp.ID = idfasciolasis
            lp = lp.buscar
            preciofasciolasis = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciofasciolasis = lp.PRECIO1
            End If
        ElseIf precio = 3 Then
            lp.ID = idcoccidias
            lp = lp.buscar
            preciococcidias = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciococcidias = lp.PRECIO1
            End If
            lp.ID = idcopro_bov
            lp = lp.buscar
            preciocopro_bov = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocopro_bov = lp.PRECIO1
            End If
            lp.ID = idcopro_can
            lp = lp.buscar
            preciocopro_can = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocopro_can = lp.PRECIO1
            End If
            lp.ID = idfasciolasis
            lp = lp.buscar
            preciofasciolasis = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciofasciolasis = lp.PRECIO1
            End If
        End If

        Dim ficha As Long = 0
        Dim sa As New dSolicitudAnalisis
        Dim muestras As Integer = 0
        ficha = TextId.Text.Trim
        sa.ID = ficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            muestras = sa.NMUESTRAS
        End If

        Dim analisis As Integer = 0
        Dim precio1 As Double = 0

        Dim sp As New dParasitologiaSolicitud
        Dim lista As New ArrayList
        Dim coccidias As Integer = 0
        Dim copro_bov As Integer = 0
        Dim copro_can As Integer = 0
        Dim fasciolasis As Integer = 0
        lista = sp.listarporsolicitud(ficha)
        If Not lista Is Nothing Then
            For Each sp In lista
                If sp.COCCIDIAS = 1 Then
                    coccidias = 1
                End If
                If sp.GASTROINTESTINALES = 1 Then
                    copro_bov = 1
                End If
                If sp.COPROPARASITARIO_CAN = 1 Then
                    copro_can = 1
                End If
                If sp.FASCIOLA = 1 Then
                    fasciolasis = 1
                End If
            Next
        End If
        If muestras < 4 Then
            If coccidias = 1 Then
                analisis = 35
                precio1 = preciococcidias
                Dim f1 As New dFacturacion
                f1.FICHA = ficha
                f1.CANTIDAD = 4
                f1.ANALISIS = analisis
                f1.PRECIO = precio1
                f1.SUBTOTAL = 4 * precio1
                f1.FACTURA = 0
                f1.guardar(Usuario)
                f1 = Nothing
            End If
            If copro_bov = 1 Then
                analisis = 33
                precio1 = preciocopro_bov
                Dim f1 As New dFacturacion
                f1.FICHA = ficha
                f1.CANTIDAD = 4
                f1.ANALISIS = analisis
                f1.PRECIO = precio1
                f1.SUBTOTAL = 4 * precio1
                f1.FACTURA = 0
                f1.guardar(Usuario)
                f1 = Nothing
            End If
            If copro_can = 1 Then
                analisis = 247
                precio1 = preciocopro_can
                Dim f1 As New dFacturacion
                f1.FICHA = ficha
                f1.CANTIDAD = 4
                f1.ANALISIS = analisis
                f1.PRECIO = precio1
                f1.SUBTOTAL = 4 * precio1
                f1.FACTURA = 0
                f1.guardar(Usuario)
                f1 = Nothing
            End If
            If fasciolasis = 1 Then
                analisis = 34
                precio1 = preciofasciolasis
                Dim f1 As New dFacturacion
                f1.FICHA = ficha
                f1.CANTIDAD = 4
                f1.ANALISIS = analisis
                f1.PRECIO = precio1
                f1.SUBTOTAL = 4 * precio1
                f1.FACTURA = 0
                f1.guardar(Usuario)
                f1 = Nothing
            End If
        Else
            If coccidias = 1 Then
                analisis = 35
                precio1 = preciococcidias
                Dim f1 As New dFacturacion
                f1.FICHA = ficha
                f1.CANTIDAD = muestras
                f1.ANALISIS = analisis
                f1.PRECIO = precio1
                f1.SUBTOTAL = muestras * precio1
                f1.FACTURA = 0
                f1.guardar(Usuario)
                f1 = Nothing
            End If
            If copro_bov = 1 Then
                analisis = 33
                precio1 = preciocopro_bov
                Dim f1 As New dFacturacion
                f1.FICHA = ficha
                f1.CANTIDAD = muestras
                f1.ANALISIS = analisis
                f1.PRECIO = precio1
                f1.SUBTOTAL = muestras * precio1
                f1.FACTURA = 0
                f1.guardar(Usuario)
                f1 = Nothing
            End If
            If copro_can = 1 Then
                analisis = 247
                precio1 = preciocopro_can
                Dim f1 As New dFacturacion
                f1.FICHA = ficha
                f1.CANTIDAD = muestras
                f1.ANALISIS = analisis
                f1.PRECIO = precio1
                f1.SUBTOTAL = muestras * precio1
                f1.FACTURA = 0
                f1.guardar(Usuario)
                f1 = Nothing
            End If
            If fasciolasis = 1 Then
                analisis = 34
                precio1 = preciofasciolasis
                Dim f1 As New dFacturacion
                f1.FICHA = ficha
                f1.CANTIDAD = muestras
                f1.ANALISIS = analisis
                f1.PRECIO = precio1
                f1.SUBTOTAL = muestras * precio1
                f1.FACTURA = 0
                f1.guardar(Usuario)
                f1 = Nothing
            End If
        End If

    End Sub
    Private Sub factura_efluentes()
        Dim lp As New dListaPrecios

        Dim c As New dCliente
        Dim precio As Integer = 0
        c.ID = TextIdProductor.Text.Trim
        c = c.buscar
        If Not c Is Nothing Then
            precio = c.FAC_LISTA
        End If

        Dim ficha As Long = 0
        Dim sa As New dSolicitudAnalisis
        Dim muestras As Integer = 0
        ficha = TextId.Text.Trim
        sa.ID = ficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            muestras = sa.NMUESTRAS
        End If

        Dim analisis As Integer = 0
        Dim precio1 As Double = 0

       
      
       
       
            

    End Sub
    Private Sub imprimir_ticket2()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)
        Dim ficha As String = TextId.Text.Trim
        Dim fecha As Date = DateFechaIngreso.Value
        Dim nmuestras As String
        If TextNMuestras.Text <> "" Then
            nmuestras = TextNMuestras.Text.Trim
        Else
            nmuestras = ""
        End If
        Dim muestra As String = ComboMuestra.Text
        Dim solicitud As String = ""
        Dim texto As String = ""
        Dim texto2 As String = ""
        Dim texto3 As String = ""
        Dim usucontra As String = ""
        Dim tipoinforme As String = ComboTipoInforme.Text
        Dim subtipoinforme As String = ComboSubInforme.Text
        Dim observaciones As String = TextObservaciones.Text.Trim
        Dim fila = 1
        Dim columna = 5
        x1hoja.Cells(fila, columna).formula = "RG.ADM.54 v02 06/06/18"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = 1
        columna = 1
        columna = columna + 2
        x1hoja.Cells(fila, columna).formula = "Solicitud de análisis"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Ficha:" & " " & TextId.Text
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Realizada por:" & " " & Usuario.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Fecha/Hora de recepción:" & " " & fecha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        'fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Muestras:" & " " & nmuestras
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        Dim pro As New dCliente
        Dim nombre_productor As String = ""
        Dim idproductor As Long = 0
        pro.ID = TextIdProductor.Text.Trim
        pro = pro.buscar
        If Not pro Is Nothing Then
            nombre_productor = pro.NOMBRE
            usucontra = pro.USUARIO_WEB
            idproductor = pro.ID
        Else
            nombre_productor = ""
        End If
        x1hoja.Cells(fila, columna).formula = "Cliente:" & " " & nombre_productor & " " & "(" & idproductor & ")"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Muestra de:" & " " & muestra
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "-----------------------------------------------------------------------------"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        Dim sm As New dRelSolicitudMuestras
        Dim spal As New dSolicitudPAL
        Dim csm As New dCalidadSolicitudMuestra
        Dim cs As New dControlSolicitud
        Dim a2 As New dAntibiograma2
        Dim sn As New dSolicitudNutricion
        Dim ss As New dSolicitudSuelos
        Dim bl As New dBrucelosis
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim lista4 As New ArrayList
        Dim lista5 As New ArrayList
        Dim lista6 As New ArrayList
        Dim lista7 As New ArrayList
        Dim lista10 As New ArrayList
        Dim listabl As New ArrayList
        Dim listanutricion As New ArrayList
        Dim listasuelos As New ArrayList
        Dim cajas As String = ""
        Dim gradillas As String = ""
        Dim otros As String = ""
        lista4 = sm.listarporficha(ficha)
        lista5 = csm.listarporsolicitud3(ficha)
        lista6 = cs.listarporsolicitud(ficha)
        lista7 = a2.listarporsolicitud(ficha)
        lista10 = spal.listarporsolicitud(ficha)
        listanutricion = sn.listarporsolicitud(ficha)
        listasuelos = ss.listarporsolicitud(ficha)
        listabl = sm.listarporficha(ficha)
        x1hoja.Cells(fila, columna).formula = "Análisis requerido: " & tipoinforme & " // " & "Subinforme:" & " " & subtipoinforme
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '***  LISTADO DE ANALISIS REQUERIDOS *********************************************************************
        ' SI ES PRODUCTOS LÁCTEOS ********************************************************************************
        If tipoinforme = "Alimentos" Then
            Dim sp As New dSubproducto
            Dim lista As New ArrayList
            texto = ""
            lista = sp.listarporsolicitud(ficha)
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each sp In lista
                        texto = ""
                        If sp.ESTAFCOAGPOSITIVO = 1 Then
                            texto = texto + " - Estaf. Coag. Positivo"
                        End If
                        If sp.CF = 1 Then
                            texto = texto + " - CF"
                        End If
                        If sp.MOHOSYLEVADURAS = 1 Then
                            texto = texto + " - Mohos y levaduras"
                        End If
                        If sp.CT = 1 Then
                            texto = texto + " - Coliformes Totales"
                        End If
                        If sp.ECOLI = 1 Then
                            texto = texto + " - E. Coli"
                        End If
                        If sp.SALMONELLA = 1 Then
                            texto = texto + " - Salmonella"
                        End If
                        If sp.LISTERIASPP = 1 Then
                            texto = texto + " - Listeria spp"
                        End If
                        If sp.HUMEDAD = 1 Then
                            texto = texto + " - Humedad"
                        End If
                        If sp.MGRASA = 1 Then
                            texto = texto + " - M. Grasa"
                        End If
                        If sp.PH = 1 Then
                            texto = texto + " - pH"
                        End If
                        If sp.CLORUROS = 1 Then
                            texto = texto + " - Cloruros"
                        End If
                        If sp.PROTEINAS = 1 Then
                            texto = texto + " - Proteínas"
                        End If
                        If sp.ENTEROBACTERIAS = 1 Then
                            texto = texto + " - Enterobacterias"
                        End If
                        If sp.LISTERIAAMBIENTAL = 1 Then
                            texto = texto + " - Listeria Ambiental"
                        End If
                        If sp.ESPORANAERMESOFILO = 1 Then
                            texto = texto + " - Espor. Anaer. Mesófilos"
                        End If
                        If sp.TERMOFILOS = 1 Then
                            texto = texto + " - Termodúricos"
                        End If
                        If sp.PSICROTROFOS = 1 Then
                            texto = texto + " - Psicrótrofos"
                        End If
                        If sp.RB = 1 Then
                            texto = texto + " - RB"
                        End If
                        If sp.TABLANUTRICIONAL = 1 Then
                            texto = texto + " - Tabla nutricional"
                        End If
                        If sp.LISTERIAMONOCITOGENES = 1 Then
                            texto = texto + " - Listeria monocitógenes"
                        End If
                        If sp.CENIZAS = 1 Then
                            texto = texto + " - Cenizas"
                        End If
                        If sp.LISTERIAPOOL = 1 Then
                            texto = texto + " - Pool de Listeria"
                        End If
                        If sp.SALMONELLAPOOL = 1 Then
                            texto = texto + " - Pool de Salmonella"
                        End If
                    Next
                End If
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES AGUA ********************************************************************************
        ElseIf tipoinforme = "Agua" Then
            Dim a1 As New dAgua
            texto = ""
            a1.ID = ficha
            a1 = a1.buscar()
            texto = ComboSubInforme.Text
            If a1.HET22 = 1 Then
                texto = texto & " " & " - Heterotróficos 22"
            End If
            If a1.HET35 = 1 Then
                texto = texto & " " & " - Heterotróficos 35"
            End If
            If a1.HET37 = 1 Then
                texto = texto & " " & " - Heterotróficos 37"
            End If
            If a1.CLORO = 1 Then
                texto = texto & " " & " - Cloro"
            End If
            If a1.CONDUCTIVIDAD = 1 Then
                texto = texto & " " & " - Conductividad"
            End If
            If a1.PH = 1 Then
                texto = texto & " " & " - pH"
            End If
            If a1.ECOLI = 1 Then
                texto = texto & " " & " - Ecoli"
            End If
            If a1.SULFITOREDUCTORES = 1 Then
                texto = texto & " " & " - Sulfito reductores"
            End If
            If a1.ENTEROCOCOS = 1 Then
                texto = texto & " " & " - Enterococos"
            End If
            If a1.ESTREPTOCOCOS = 1 Then
                texto = texto & " " & " - Estreptococos"
            End If
            If a1.PAQMACRO = 1 Then
                texto = texto & " " & "+ Paq. Macroelementos "
            End If
            If a1.ALCALINIDAD = 1 Then
                texto = texto & " " & "+ Alcalinidad "
            End If
            If a1.CA = 1 Then
                texto = texto & " " & "+ Ca "
            End If
            If a1.MG = 1 Then
                texto = texto & " " & "+ Mg "
            End If
            If a1.NA = 1 Then
                texto = texto & " " & "+ Na "
            End If
            If a1.FE = 1 Then
                texto = texto & " " & "+ Fe "
            End If
            If a1.K = 1 Then
                texto = texto & " " & "+ K "
            End If
            If a1.AL = 1 Then
                texto = texto & " " & "+ Al "
            End If
            If a1.CD = 1 Then
                texto = texto & " " & "+ Cd "
            End If
            If a1.CR = 1 Then
                texto = texto & " " & "+ Cr "
            End If
            If a1.CU = 1 Then
                texto = texto & " " & "+ Cu "
            End If
            If a1.PB = 1 Then
                texto = texto & " " & "+ Pb "
            End If
            If a1.MN = 1 Then
                texto = texto & " " & "+ Mn "
            End If
            If a1.FE = 1 Then
                texto = texto & " " & "+ fe "
            End If
            If a1.ZN = 1 Then
                texto = texto & " " & "+ Zn "
            End If
            If a1.SE = 1 Then
                texto = texto & " " & "+ Se "
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES CALIDAD DE LECHE ********************************************************************************
        ElseIf tipoinforme = "Calidad de leche" Then
            Dim rb As Integer = 0
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim compsuero As Integer = 0
            Dim criosc As Integer = 0
            Dim inh As Integer = 0
            Dim charm As Integer = 0
            Dim espor As Integer = 0
            Dim urea As Integer = 0
            Dim term As Integer = 0
            Dim psicr As Integer = 0
            Dim crioscopo As Integer = 0
            Dim aflatoxinam1 As Integer = 0
            Dim caseina As Integer = 0
            texto = ""
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        If csm.RB = 1 Then
                            rb = 1
                        End If
                        If csm.RC = 1 Then
                            rc = 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If csm.COMPOSICIONSUERO = 1 Then
                            compsuero = 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            criosc = 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            inh = 1
                        End If
                        If csm.CHARM = 1 Then
                            charm = 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            espor = 1
                        End If
                        If csm.UREA = 1 Then
                            urea = 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            term = 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            psicr = 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            crioscopo = 1
                        End If
                        If csm.AFLATOXINA = 1 Then
                            aflatoxinam1 = 1
                        End If
                        If csm.CASEINA = 1 Then
                            caseina = 1
                        End If
                    Next
                End If
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If compsuero = 1 Then
                texto = texto + " - Composición suero"
            End If
            If criosc = 1 Then
                texto = texto + " - Crioscopía"
            End If
            If inh = 1 Then
                texto = texto + " - Inhibidores"
            End If
            If charm = 1 Then
                texto = texto + " - Charm"
            End If
            If espor = 1 Then
                texto = texto + " - Esporulados"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If term = 1 Then
                texto = texto + " - Termófilos"
            End If
            If psicr = 1 Then
                texto = texto + " - Psicrótrofos"
            End If
            If crioscopo = 1 Then
                texto = texto + " - Crioscopía (crióscopo)"
            End If
            If crioscopo = 1 Then
                texto = texto + " - Aflatoxina M1"
            End If
            If caseina = 1 Then
                texto = texto + " - Caseína"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES CONTROL LECHERO ********************************************************************************
        ElseIf tipoinforme = "Control Lechero" Then
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim urea As Integer = 0
            Dim caseina As Integer = 0
            texto = ""
            If Not lista6 Is Nothing Then
                If lista6.Count > 0 Then
                    For Each cs In lista6
                        If cs.RC = 1 Then
                            rc = 1
                        End If
                        If cs.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If cs.UREA = 1 Then
                            urea = 1
                        End If
                        If cs.CASEINA = 1 Then
                            caseina = 1
                        End If
                    Next
                End If
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If caseina = 1 Then
                texto = texto + " - Caseina"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ANTIBIOGRAMA ********************************************************************************
        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            Dim aislamiento As Integer = 0
            Dim antibiograma As Integer = 0
            texto = ""
            If Not lista7 Is Nothing Then
                If lista7.Count > 0 Then
                    For Each a2 In lista7
                        If a2.AISLAMIENTO = 1 Then
                            aislamiento = 1
                        End If
                        If a2.ANTIBIOGRAMA = 1 Then
                            antibiograma = 1
                        End If
                    Next
                End If
            End If
            If aislamiento = 1 Then
                texto = texto + " - Aislamiento"
            End If
            If antibiograma = 1 Then
                texto = texto + " - Antibiograma"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES AMBIENTAL ********************************************************************************
        ElseIf tipoinforme = "Ambiental" Then
            Dim ambs As New dAmbientalSolicitud
            Dim lista8 As ArrayList
            lista8 = ambs.listarporsolicitud(ficha)
            Dim enterobacterias As Integer = 0
            Dim listambiental As Integer = 0
            Dim listmono As Integer = 0
            Dim salmonella As Integer = 0
            Dim ecoli As Integer = 0
            Dim mohosylevaduras As Integer = 0
            Dim rb As Integer = 0
            Dim ct As Integer = 0
            Dim cf As Integer = 0
            Dim pseudomonaspp As Integer = 0
            Dim listeriaspp As Integer = 0
            texto = ""
            If Not lista8 Is Nothing Then
                If lista8.Count > 0 Then
                    For Each ambs In lista8
                        If ambs.ENTEROBACTERIAS = 1 Then
                            enterobacterias = 1
                        End If
                        If ambs.LISTAMBIENTAL = 1 Then
                            listambiental = 1
                        End If
                        If ambs.LISTMONO = 1 Then
                            listmono = 1
                        End If
                        If ambs.SALMONELLA = 1 Then
                            salmonella = 1
                        End If
                        If ambs.ECOLI = 1 Then
                            ecoli = 1
                        End If
                        If ambs.MOHOSYLEVADURAS = 1 Then
                            mohosylevaduras = 1
                        End If
                        If ambs.RB = 1 Then
                            rb = 1
                        End If
                        If ambs.CT = 1 Then
                            ct = 1
                        End If
                        If ambs.CF = 1 Then
                            cf = 1
                        End If
                        If ambs.PSEUDOMONASPP = 1 Then
                            pseudomonaspp = 1
                        End If
                        If ambs.LISTSPP = 1 Then
                            listeriaspp = 1
                        End If
                    Next
                End If
            End If
            If enterobacterias = 1 Then
                texto = texto + " - Enterobacterias"
            End If
            If listambiental = 1 Then
                texto = texto + " - Listeria ambiental"
            End If
            If listmono = 1 Then
                texto = texto + " - Listeria monocitógenes"
            End If
            If salmonella = 1 Then
                texto = texto + " - Salmonella"
            End If
            If ecoli = 1 Then
                texto = texto + " - E. Coli"
            End If
            If mohosylevaduras = 1 Then
                texto = texto + " - Mohos y levaduras"
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If ct = 1 Then
                texto = texto + " - Coliformes totales"
            End If
            If cf = 1 Then
                texto = texto + " - CF"
            End If
            If pseudomonaspp = 1 Then
                texto = texto + " - Pseudomona spp"
            End If
            If listeriaspp = 1 Then
                texto = texto + " - Listeriaa spp"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES PARASITOLOGÍA ********************************************************************************
        ElseIf tipoinforme = "Parasitología" Then
            Dim p As New dParasitologiaSolicitud
            Dim lista9 As ArrayList
            lista9 = p.listarporsolicitud(ficha)
            Dim gastrointestinales As Integer = 0
            Dim fasciola As Integer = 0
            Dim coccidias As Integer = 0
            texto = ""
            If Not lista9 Is Nothing Then
                If lista9.Count > 0 Then
                    For Each p In lista9
                        If p.GASTROINTESTINALES = 1 Then
                            gastrointestinales = 1
                        End If
                        If p.FASCIOLA = 1 Then
                            fasciola = 1
                        End If
                        If p.COCCIDIAS = 1 Then
                            coccidias = 1
                        End If
                    Next
                End If
            End If
            If gastrointestinales = 1 Then
                texto = texto + " - Gastrointestinales"
            End If
            If fasciola = 1 Then
                texto = texto + " - Fasciola"
            End If
            If coccidias = 1 Then
                texto = texto + " - Coccidias"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES NUTRICIÓN ********************************************************************************
        ElseIf tipoinforme = "Nutrición" Then
            Dim mga As Integer = 0
            Dim mgb As Integer = 0
            Dim ensilados As Integer = 0
            Dim pasturas As Integer = 0
            Dim extetereo As Integer = 0
            Dim nida As Integer = 0
            Dim micotoxinas As Integer = 0
            texto = ""
            If Not listanutricion Is Nothing Then
                If listanutricion.Count > 0 Then
                    For Each sn In listanutricion
                        texto = texto & " // " & sn.MUESTRA & " - "
                        If sn.MGA = 1 Then
                            texto = texto & "MGA - "
                        End If
                        If sn.MGB = 1 Then
                            texto = texto & "MGB - "
                        End If
                        If sn.ENSILADOS = 1 Then
                            texto = texto & "Ensilados - "
                        End If
                        If sn.PASTURAS = 1 Then
                            texto = texto & "Pasturas - "
                        End If
                        If sn.EXTETEREO = 1 Then
                            texto = texto & "Extracto etéreo - "
                        End If
                        If sn.NIDA = 1 Then
                            texto = texto & "NIDA - "
                        End If
                        If sn.MICOTOXINAS = 1 Then
                            texto = texto & "MICOTOXINAS - "
                        End If
                        If sn.AFLA = 1 Then
                            texto = texto & "AFLA - "
                        End If
                        If sn.DON = 1 Then
                            texto = texto & "DON - "
                        End If
                        If sn.ZEARA = 1 Then
                            texto = texto & "ZEARA - "
                        End If
                        If sn.PROTEINAS = 1 Then
                            texto = texto & "PROTEINAS - "
                        End If
                        If sn.MATERIASECA = 1 Then
                            texto = texto & "MATERIA SECA - "
                        End If
                        If sn.FIBRANEUTRA = 1 Then
                            texto = texto & "FIBRA NEUTRA - "
                        End If
                        If sn.FIBRAACIDA = 1 Then
                            texto = texto & "FIBRA ÁCIDA - "
                        End If
                        If sn.PH = 1 Then
                            texto = texto & "pH - "
                        End If
                    Next
                End If
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES SUELOS ********************************************************************************
        ElseIf tipoinforme = "Suelos" Then
            Dim nitratos As Integer = 0
            Dim mineralizacion As Integer = 0
            Dim fosforobray As Integer = 0
            Dim fosforocitrico As Integer = 0
            Dim phagua As Integer = 0
            Dim phkci As Integer = 0
            Dim materiaorg As Integer = 0
            Dim potasioint As Integer = 0
            Dim sulfatos As Integer = 0
            Dim nitrogenovegetal As Integer = 0
            texto = ""
            If Not listasuelos Is Nothing Then
                If listasuelos.Count > 0 Then
                    For Each ss In listasuelos
                        texto = texto & " // " & ss.MUESTRA & " - "
                        If ss.PAQUETE = 1 Then
                            texto = texto & "Paquete 1 (Completo) - "
                        End If
                        If ss.PAQUETE = 2 Then
                            texto = texto & "Paquete 2 (Cultivos de verano) - "
                        End If
                        If ss.PAQUETE = 3 Then
                            texto = texto & "Paquete 3 (Cultivos de invierno) - "
                        End If
                        If ss.PAQUETE = 4 Then
                            texto = texto & "Paquete 4 (Cationes) - "
                        End If
                        If ss.PAQUETE = 5 Then
                            texto = texto & "Paquete 5 (Pastura) - "
                        End If
                        If ss.PAQUETE = 7 Then
                            texto = texto & "Paquete foliares (Fósforo y Potasio Total) "
                        End If
                        If ss.NITRATOS = 1 Then
                            texto = texto & "Nitratos - "
                        End If
                        If ss.MINERALIZACION = 1 Then
                            texto = texto & "Mineralización - "
                        End If
                        If ss.FOSFOROBRAY = 1 Then
                            texto = texto & "Fósforo Bray I - "
                        End If
                        If ss.FOSFOROCITRICO = 1 Then
                            texto = texto & "Fósforo Ac.Cítrico - "
                        End If
                        If ss.PHAGUA = 1 Then
                            texto = texto & "pH Agua - "
                        End If
                        If ss.PHKCI = 1 Then
                            texto = texto & "pH KCI - "
                        End If
                        If ss.MATERIAORG = 1 Then
                            texto = texto & "Materia orgánica - "
                        End If
                        If ss.POTASIOINT = 1 Then
                            texto = texto & "Potasio intercambiable - "
                        End If
                        If ss.SULFATOS = 1 Then
                            texto = texto & "Sulfatos - "
                        End If
                        If ss.NITROGENOVEGETAL = 1 Then
                            texto = texto & "Nitrógeno vegetal - "
                        End If
                        If ss.MAGNESIO = 1 Then
                            texto = texto & "Magnesio - "
                        End If
                        If ss.SODIO = 1 Then
                            texto = texto & "Sodio - "
                        End If
                        If ss.ACIDEZTITULABLE = 1 Then
                            texto = texto & "Acidez titulable - "
                        End If
                        If ss.CIC = 1 Then
                            texto = texto & "CIC - "
                        End If
                        If ss.SB = 1 Then
                            texto = texto & "% SB - "
                        End If
                        If ss.ZINC = 1 Then
                            texto = texto & "ZINC - "
                        End If
                    Next
                End If
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
        Else
            x1hoja.Range("A9", "G10").Merge()
            x1hoja.Range("A9", "G10").WrapText = True
            'x1hoja.Cells(fila, columna).Formula = texto
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 2
        End If
        '***********************************************************************************************
        'x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).formula = "-----------------------------------------------------------------------------"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Identificación de las muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '*** LISTADO DE MUESTRAS *********************************************************************************
        ' SI ES PRODUCTOS LÁCTEOS ********************************************************************************
        If tipoinforme = "Alimentos" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4

                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES AGUA ********************************************************************************
        ElseIf tipoinforme = "Agua" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES CALIDAD ********************************************************************************
        ElseIf tipoinforme = "Calidad de leche" Then
            texto2 = ""
            Dim cuenta_rb As Integer = 0
            Dim cuenta_rc As Integer = 0
            Dim cuenta_comp As Integer = 0
            Dim cuenta_compsuero As Integer = 0
            Dim cuenta_criosc As Integer = 0
            Dim cuenta_inhib As Integer = 0
            Dim cuenta_charm As Integer = 0
            Dim cuenta_espor As Integer = 0
            Dim cuenta_urea As Integer = 0
            Dim cuenta_termo As Integer = 0
            Dim cuenta_psicro As Integer = 0
            Dim cuenta_criosc_criosc As Integer = 0
            Dim cuenta_caseina As Integer = 0
            Dim cuenta_aflatoxinam1 As Integer = 0
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        texto2 = texto2 + csm.MUESTRA
                        If csm.RB = 1 Then
                            cuenta_rb = cuenta_rb + 1
                        End If
                        If csm.RC = 1 Then
                            cuenta_rc = cuenta_rc + 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            cuenta_comp = cuenta_comp + 1
                        End If
                        If csm.COMPOSICIONSUERO = 1 Then
                            cuenta_compsuero = cuenta_compsuero + 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            cuenta_criosc = cuenta_criosc + 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            cuenta_inhib = cuenta_inhib + 1
                        End If
                        If csm.CHARM = 1 Then
                            cuenta_charm = cuenta_charm + 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            cuenta_espor = cuenta_espor + 1
                        End If
                        If csm.UREA = 1 Then
                            cuenta_urea = cuenta_urea + 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            cuenta_termo = cuenta_termo + 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            cuenta_psicro = cuenta_psicro + 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            cuenta_criosc_criosc = cuenta_criosc_criosc + 1
                        End If
                        If csm.CASEINA = 1 Then
                            cuenta_caseina = cuenta_caseina + 1
                        End If
                        If csm.AFLATOXINA = 1 Then
                            cuenta_aflatoxinam1 = cuenta_aflatoxinam1 + 1
                        End If
                        texto2 = texto2 + " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G16").Merge()
            x1hoja.Range("A13", "G16").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            If cuenta_rb > 0 Then
                texto3 = texto3 & cuenta_rb & " RB - "
            End If
            If cuenta_rc > 0 Then
                texto3 = texto3 & cuenta_rc & " RC - "
            End If
            If cuenta_comp > 0 Then
                texto3 = texto3 & cuenta_comp & " Comp. - "
            End If
            If cuenta_compsuero > 0 Then
                texto3 = texto3 & cuenta_compsuero & " Comp. suero - "
            End If
            If cuenta_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc & " Criosc. - "
            End If
            If cuenta_inhib > 0 Then
                texto3 = texto3 & cuenta_inhib & " Inhib. - "
            End If
            If cuenta_charm > 0 Then
                texto3 = texto3 & cuenta_charm & " Charm - "
            End If
            If cuenta_espor > 0 Then
                texto3 = texto3 & cuenta_espor & " Espor. - "
            End If
            If cuenta_urea > 0 Then
                texto3 = texto3 & cuenta_urea & " Urea - "
            End If
            If cuenta_termo > 0 Then
                texto3 = texto3 & cuenta_termo & " Termof. - "
            End If
            If cuenta_psicro > 0 Then
                texto3 = texto3 & cuenta_psicro & " Psicro. - "
            End If
            If cuenta_criosc_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc_criosc & " Criosc.(Crióscopo) - "
            End If
            If cuenta_caseina > 0 Then
                texto3 = texto3 & cuenta_caseina & " Caseina - "
            End If
            If cuenta_aflatoxinam1 > 0 Then
                texto3 = texto3 & cuenta_aflatoxinam1 & " Aflatoxina M1 - "
            End If
            fila = fila + 4
            'x1hoja.Range("A27", "G28").Merge()
            'x1hoja.Range("A27", "G28").WrapText = True
            x1hoja.Cells(fila, columna).Formula = "Total: " + texto3
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 1
            ' SI ES CONTROL LECHERO ********************************************************************************
        ElseIf tipoinforme = "Control Lechero" Then
            texto2 = ""
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES ANTIBIOGRAMA ********************************************************************************
        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES AMBIENTAL ********************************************************************************
        ElseIf tipoinforme = "Ambiental" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES PARASITOLOGÍA ********************************************************************************
        ElseIf tipoinforme = "Parasitología" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES PAL ********************************************************************************
        ElseIf tipoinforme = "PAL" Then
            texto2 = ""
            If Not lista10 Is Nothing Then
                If lista10.Count > 0 Then
                    For Each spal In lista10
                        texto2 = texto2 + spal.MATRICULA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            Dim solpal As New dSolicitudPAL
            solpal.FICHA = ficha
            solpal = solpal.buscar
            If Not solpal Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = "Vacas: " & solpal.VACAS & " - " & "Fecha extracción: " & solpal.FECHAEXT
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
            End If
            '********************************************************************************************************************
            ' SI ES BRUCELOSIS LECHE ********************************************************************************
        ElseIf tipoinforme = "Brucelosis en leche" Then
            texto2 = ""
            If Not listabl Is Nothing Then
                If listabl.Count > 0 Then
                    For Each sm In listabl
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
        ElseIf tipoinforme = "Nutrición" Then
            fila = fila + 5
        ElseIf tipoinforme = "Suelos" Then
            fila = fila + 5
        Else
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
        End If
        '********************************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Observaciones:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        Dim dm As New dDescarteMuestras
        dm.FICHA = ficha
        dm = dm.buscarxficha
        If Not dm Is Nothing Then
            If dm.IDINFORETORNO = 1 Then
                observaciones = observaciones & " * Muestras fuera de condición."
            End If
        End If

        x1hoja.Cells(fila, columna).formula = observaciones
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "IMPORTANTE"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Ud. puede descargar los resultados desde nuestra web, solicite usuario y contraseña"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        'fila = fila + 1
        'x1hoja.Cells(fila, columna).formula = "Para poder acceder a sus resultados debe ingresar a http://www.colaveco.com.uy/gestor"
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 10
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'fila = fila + 1
        'x1hoja.Cells(fila, columna).formula = "Usuario y contraseña: " & usucontra
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 10
        'x1hoja.Cells(fila, columna).Font.Bold = True

        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Recuerde que los resultados quedan habilitados si el cliente no tiene facturas vencidas."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Si tiene dificultades para obtener los resultados, comunicarse al 4554 5311 /5975/6838"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "o vía mail a colaveco@gmail.com (Horario de atención al público L a V de 8 a 17 Hs."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        ' SEGUNDA COPIA *************************************************************************************************************************************
        fila = fila + 2
        columna = 5
        x1hoja.Cells(fila, columna).formula = "RG.ADM.54 v02 06/06/18"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1
        columna = columna + 2
        x1hoja.Cells(fila, columna).formula = "Solicitud de análisis"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Ficha:" & " " & TextId.Text
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Realizada por:" & " " & Usuario.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Fecha/Hora de recepción:" & " " & fecha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        'fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Muestras:" & " " & nmuestras
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        If Not pro Is Nothing Then
            nombre_productor = pro.NOMBRE
        Else
            nombre_productor = ""
        End If
        x1hoja.Cells(fila, columna).formula = "Cliente:" & " " & nombre_productor
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Muestra de:" & " " & muestra
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        'x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).formula = "-----------------------------------------------------------------------------"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Análisis requerido: " & tipoinforme & " // " & "Subinforme:" & " " & subtipoinforme
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '***  LISTADO DE ANALISIS REQUERIDOS *********************************************************************
        ' SI ES ALIMENTOS ********************************************************************************
        If tipoinforme = "Alimentos" Then
            Dim sp As New dSubproducto
            Dim lista As New ArrayList
            texto = ""
            lista = sp.listarporsolicitud(ficha)
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each sp In lista
                        texto = ""
                        If sp.ESTAFCOAGPOSITIVO = 1 Then
                            texto = texto + " - Estaf. Coag. Positivo"
                        End If
                        If sp.CF = 1 Then
                            texto = texto + " - CF"
                        End If
                        If sp.MOHOSYLEVADURAS = 1 Then
                            texto = texto + " - Mohos y levaduras"
                        End If
                        If sp.CT = 1 Then
                            texto = texto + " - Coliformes Totales"
                        End If
                        If sp.ECOLI = 1 Then
                            texto = texto + " - E. Coli"
                        End If
                        If sp.SALMONELLA = 1 Then
                            texto = texto + " - Salmonella"
                        End If
                        If sp.LISTERIASPP = 1 Then
                            texto = texto + " - Listeria spp"
                        End If
                        If sp.HUMEDAD = 1 Then
                            texto = texto + " - Humedad"
                        End If
                        If sp.MGRASA = 1 Then
                            texto = texto + " - M. Grasa"
                        End If
                        If sp.PH = 1 Then
                            texto = texto + " - pH"
                        End If
                        If sp.CLORUROS = 1 Then
                            texto = texto + " - Cloruros"
                        End If
                        If sp.PROTEINAS = 1 Then
                            texto = texto + " - Proteínas"
                        End If
                        If sp.ENTEROBACTERIAS = 1 Then
                            texto = texto + " - Enterobacterias"
                        End If
                        If sp.LISTERIAAMBIENTAL = 1 Then
                            texto = texto + " - Listeria Ambiental"
                        End If
                        If sp.ESPORANAERMESOFILO = 1 Then
                            texto = texto + " - Espor. Anaer. Mesófilos"
                        End If
                        If sp.TERMOFILOS = 1 Then
                            texto = texto + " - Termodúricos"
                        End If
                        If sp.PSICROTROFOS = 1 Then
                            texto = texto + " - Psicrótrofos"
                        End If
                        If sp.RB = 1 Then
                            texto = texto + " - RB"
                        End If
                        If sp.TABLANUTRICIONAL = 1 Then
                            texto = texto + " - Tabla nutricional"
                        End If
                        If sp.LISTERIAMONOCITOGENES = 1 Then
                            texto = texto + " - Listeria monocitógenes"
                        End If
                        If sp.CENIZAS = 1 Then
                            texto = texto + " - Cenizas"
                        End If
                    Next
                End If
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES AGUA ********************************************************************************
        ElseIf tipoinforme = "Agua" Then
            Dim a1 As New dAgua
            texto = ""
            a1.ID = ficha
            a1 = a1.buscar()
            texto = ComboSubInforme.Text
            If a1.HET22 = 1 Then
                texto = texto & " " & " - Heterotróficos 22"
            End If
            If a1.HET35 = 1 Then
                texto = texto & " " & " - Heterotróficos 35"
            End If
            If a1.HET37 = 1 Then
                texto = texto & " " & " - Heterotróficos 37"
            End If
            If a1.CLORO = 1 Then
                texto = texto & " " & " - Cloro"
            End If
            If a1.CONDUCTIVIDAD = 1 Then
                texto = texto & " " & " - Conductividad"
            End If
            If a1.PH = 1 Then
                texto = texto & " " & " - pH"
            End If
            If a1.ECOLI = 1 Then
                texto = texto & " " & " - Ecoli"
            End If
            If a1.SULFITOREDUCTORES = 1 Then
                texto = texto & " " & " - Sulfito reductores"
            End If
            If a1.ENTEROCOCOS = 1 Then
                texto = texto & " " & " - Enterococos"
            End If
            If a1.ESTREPTOCOCOS = 1 Then
                texto = texto & " " & " - Estreptococos"
            End If
            If texto.Length > 0 Then

                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES CALIDAD DE LECHE ********************************************************************************
        ElseIf tipoinforme = "Calidad de leche" Then
            Dim rb As Integer = 0
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim compsuero As Integer = 0
            Dim criosc As Integer = 0
            Dim inh As Integer = 0
            Dim charm As Integer = 0
            Dim espor As Integer = 0
            Dim urea As Integer = 0
            Dim term As Integer = 0
            Dim psicr As Integer = 0
            Dim crioscopo As Integer = 0
            Dim aflatoxinam1 As Integer = 0
            texto = ""
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        If csm.RB = 1 Then
                            rb = 1
                        End If
                        If csm.RC = 1 Then
                            rc = 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If csm.COMPOSICIONSUERO = 1 Then
                            compsuero = 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            criosc = 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            inh = 1
                        End If
                        If csm.CHARM = 1 Then
                            charm = 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            espor = 1
                        End If
                        If csm.UREA = 1 Then
                            urea = 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            term = 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            psicr = 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            crioscopo = 1
                        End If
                        If csm.AFLATOXINA = 1 Then
                            aflatoxinam1 = 1
                        End If
                    Next
                End If
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If compsuero = 1 Then
                texto = texto + " - Composición suero"
            End If
            If criosc = 1 Then
                texto = texto + " - Crioscopía"
            End If
            If inh = 1 Then
                texto = texto + " - Inhibidores"
            End If
            If charm = 1 Then
                texto = texto + " - Charm"
            End If
            If espor = 1 Then
                texto = texto + " - Esporulados"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If term = 1 Then
                texto = texto + " - Termófilos"
            End If
            If psicr = 1 Then
                texto = texto + " - Psicrótrofos"
            End If
            If crioscopo = 1 Then
                texto = texto + " - Crioscopía (crióscopo)"
            End If
            If aflatoxinam1 = 1 Then
                texto = texto + " - Aflatoxina M1"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES CONTROL LECHERO ********************************************************************************
        ElseIf tipoinforme = "Control Lechero" Then
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim urea As Integer = 0
            texto = ""
            If Not lista6 Is Nothing Then
                If lista6.Count > 0 Then
                    For Each cs In lista6
                        If cs.RC = 1 Then
                            rc = 1
                        End If
                        If cs.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If cs.UREA = 1 Then
                            urea = 1
                        End If
                    Next
                End If
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ANTIBIOGRAMA ********************************************************************************
        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            Dim aislamiento As Integer = 0
            Dim antibiograma As Integer = 0
            texto = ""
            If Not lista7 Is Nothing Then
                If lista7.Count > 0 Then
                    For Each a2 In lista7
                        If a2.AISLAMIENTO = 1 Then
                            aislamiento = 1
                        End If
                        If a2.ANTIBIOGRAMA = 1 Then
                            antibiograma = 1
                        End If
                    Next
                End If
            End If
            If aislamiento = 1 Then
                texto = texto + " - Aislamiento"
            End If
            If antibiograma = 1 Then
                texto = texto + " - Antibiograma"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES AMBIENTAL ********************************************************************************
        ElseIf tipoinforme = "Ambiental" Then
            Dim ambs As New dAmbientalSolicitud
            Dim lista8 As ArrayList
            lista8 = ambs.listarporsolicitud(ficha)
            Dim enterobacterias As Integer = 0
            Dim listambiental As Integer = 0
            Dim listmono As Integer = 0
            Dim salmonella As Integer = 0
            Dim ecoli As Integer = 0
            Dim mohosylevaduras As Integer = 0
            Dim rb As Integer = 0
            Dim ct As Integer = 0
            Dim cf As Integer = 0
            Dim pseudomonaspp As Integer = 0
            Dim listeriaspp As Integer = 0
            texto = ""
            If Not lista8 Is Nothing Then
                If lista8.Count > 0 Then
                    For Each ambs In lista8
                        If ambs.ENTEROBACTERIAS = 1 Then
                            enterobacterias = 1
                        End If
                        If ambs.LISTAMBIENTAL = 1 Then
                            listambiental = 1
                        End If
                        If ambs.LISTMONO = 1 Then
                            listmono = 1
                        End If
                        If ambs.SALMONELLA = 1 Then
                            salmonella = 1
                        End If
                        If ambs.ECOLI = 1 Then
                            ecoli = 1
                        End If
                        If ambs.MOHOSYLEVADURAS = 1 Then
                            mohosylevaduras = 1
                        End If
                        If ambs.RB = 1 Then
                            rb = 1
                        End If
                        If ambs.CT = 1 Then
                            ct = 1
                        End If
                        If ambs.CF = 1 Then
                            cf = 1
                        End If
                        If ambs.PSEUDOMONASPP = 1 Then
                            pseudomonaspp = 1
                        End If
                        If ambs.LISTSPP = 1 Then
                            listeriaspp = 1
                        End If
                    Next
                End If
            End If
            If enterobacterias = 1 Then
                texto = texto + " - Enterobacterias"
            End If
            If listambiental = 1 Then
                texto = texto + " - Listeria ambiental"
            End If
            If listmono = 1 Then
                texto = texto + " - Listeria monocitógenes"
            End If
            If salmonella = 1 Then
                texto = texto + " - Salmonella"
            End If
            If ecoli = 1 Then
                texto = texto + " - E. Coli"
            End If
            If mohosylevaduras = 1 Then
                texto = texto + " - Mohos y levaduras"
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If ct = 1 Then
                texto = texto + " - Coliformes totales"
            End If
            If cf = 1 Then
                texto = texto + " - CF"
            End If
            If pseudomonaspp = 1 Then
                texto = texto + " - Pseudomona spp"
            End If
            If listeriaspp = 1 Then
                texto = texto + " - Listeria spp"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES PARASITOLOGÍA ********************************************************************************
        ElseIf tipoinforme = "Parasitología" Then
            Dim p As New dParasitologiaSolicitud
            Dim lista9 As ArrayList
            lista9 = p.listarporsolicitud(ficha)
            Dim gastrointestinales As Integer = 0
            Dim fasciola As Integer = 0
            Dim coccidias As Integer = 0
            texto = ""
            If Not lista9 Is Nothing Then
                If lista9.Count > 0 Then
                    For Each p In lista9
                        If p.GASTROINTESTINALES = 1 Then
                            gastrointestinales = 1
                        End If
                        If p.FASCIOLA = 1 Then
                            fasciola = 1
                        End If
                        If p.COCCIDIAS = 1 Then
                            coccidias = 1
                        End If
                    Next
                End If
            End If
            If gastrointestinales = 1 Then
                texto = texto + " - Gastrointestinales"
            End If
            If fasciola = 1 Then
                texto = texto + " - Fasciola"
            End If
            If coccidias = 1 Then
                texto = texto + " - Coccidias"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES NUTRICIÓN ********************************************************************************
        ElseIf tipoinforme = "Nutrición" Then
            Dim mga As Integer = 0
            Dim mgb As Integer = 0
            Dim ensilados As Integer = 0
            Dim pasturas As Integer = 0
            Dim extetereo As Integer = 0
            Dim nida As Integer = 0
            Dim micotoxinas As Integer = 0
            texto = ""
            If Not listanutricion Is Nothing Then
                If listanutricion.Count > 0 Then
                    For Each sn In listanutricion
                        texto = texto & " // " & sn.MUESTRA & " - "
                        If sn.MGA = 1 Then
                            texto = texto & "MGA - "
                        End If
                        If sn.MGB = 1 Then
                            texto = texto & "MGB - "
                        End If
                        If sn.ENSILADOS = 1 Then
                            texto = texto & "Ensilados - "
                        End If
                        If sn.PASTURAS = 1 Then
                            texto = texto & "Pasturas - "
                        End If
                        If sn.EXTETEREO = 1 Then
                            texto = texto & "Extracto etéreo - "
                        End If
                        If sn.NIDA = 1 Then
                            texto = texto & "NIDA - "
                        End If
                        If sn.MICOTOXINAS = 1 Then
                            texto = texto & "MICOTOXINAS - "
                        End If
                        If sn.AFLA = 1 Then
                            texto = texto & "AFLA - "
                        End If
                        If sn.DON = 1 Then
                            texto = texto & "DON - "
                        End If
                        If sn.ZEARA = 1 Then
                            texto = texto & "ZEARA - "
                        End If
                        If sn.PROTEINAS = 1 Then
                            texto = texto & "PROTEINAS - "
                        End If
                        If sn.FIBRANEUTRA = 1 Then
                            texto = texto & "FIBRA NEUTRA - "
                        End If
                        If sn.FIBRAACIDA = 1 Then
                            texto = texto & "FIBRA ÁCIDA - "
                        End If
                    Next
                End If
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES SUELOS ********************************************************************************
        ElseIf tipoinforme = "Suelos" Then
            Dim nitratos As Integer = 0
            Dim mineralizacion As Integer = 0
            Dim fosforobray As Integer = 0
            Dim fosforocitrico As Integer = 0
            Dim phagua As Integer = 0
            Dim phkci As Integer = 0
            Dim materiaorg As Integer = 0
            Dim potasioint As Integer = 0
            Dim sulfatos As Integer = 0
            Dim nitrogenovegetal As Integer = 0
            texto = ""
            If Not listasuelos Is Nothing Then
                If listasuelos.Count > 0 Then
                    For Each ss In listasuelos
                        texto = texto & " // " & ss.MUESTRA & " - "
                        If ss.PAQUETE = 1 Then
                            texto = texto & "Paquete 1 (Completo) - "
                        End If
                        If ss.PAQUETE = 2 Then
                            texto = texto & "Paquete 2 (Cultivos de verano) - "
                        End If
                        If ss.PAQUETE = 3 Then
                            texto = texto & "Paquete 3 (Cultivos de invierno) - "
                        End If
                        If ss.PAQUETE = 4 Then
                            texto = texto & "Paquete 4 (Cationes) - "
                        End If
                        If ss.PAQUETE = 5 Then
                            texto = texto & "Paquete 5 (Pastura) - "
                        End If
                        If ss.PAQUETE = 7 Then
                            texto = texto & "Paquete foliares (Fósforo y Potasio Total) "
                        End If
                        If ss.NITRATOS = 1 Then
                            texto = texto & "Nitratos - "
                        End If
                        If ss.MINERALIZACION = 1 Then
                            texto = texto & "Mineralización - "
                        End If
                        If ss.FOSFOROBRAY = 1 Then
                            texto = texto & "Fósforo Bray I - "
                        End If
                        If ss.FOSFOROCITRICO = 1 Then
                            texto = texto & "Fósforo Ac.Cítrico - "
                        End If
                        If ss.PHAGUA = 1 Then
                            texto = texto & "pH Agua - "
                        End If
                        If ss.PHKCI = 1 Then
                            texto = texto & "pH KCI - "
                        End If
                        If ss.MATERIAORG = 1 Then
                            texto = texto & "Materia orgánica - "
                        End If
                        If ss.POTASIOINT = 1 Then
                            texto = texto & "Potasio intercambiable - "
                        End If
                        If ss.SULFATOS = 1 Then
                            texto = texto & "Sulfatos - "
                        End If
                        If ss.NITROGENOVEGETAL = 1 Then
                            texto = texto & "Nitrógeno vegetal - "
                        End If
                        If ss.MAGNESIO = 1 Then
                            texto = texto & "Magnesio - "
                        End If
                        If ss.SODIO = 1 Then
                            texto = texto & "Sodio - "
                        End If
                        If ss.ACIDEZTITULABLE = 1 Then
                            texto = texto & "Acidez titulable - "
                        End If
                        If ss.CIC = 1 Then
                            texto = texto & "CIC - "
                        End If
                        If ss.SB = 1 Then
                            texto = texto & "% SB - "
                        End If
                        If ss.ZINC = 1 Then
                            texto = texto & "ZINC - "
                        End If
                    Next
                End If
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
        Else
            x1hoja.Range("A36", "G37").Merge()
            x1hoja.Range("A36", "G37").WrapText = True
            'x1hoja.Cells(fila, columna).Formula = texto
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 2
        End If
        '***********************************************************************************************
        'x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).formula = "-----------------------------------------------------------------------------"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Identificación de las muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '*** LISTADO DE MUESTRAS *********************************************************************************
        ' SI ES ALIMENTOS ********************************************************************************
        If tipoinforme = "Alimentos" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4

                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES AGUA ********************************************************************************
        ElseIf tipoinforme = "Agua" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES CALIDAD ********************************************************************************
        ElseIf tipoinforme = "Calidad de leche" Then
            texto2 = ""
            Dim cuenta_rb As Integer = 0
            Dim cuenta_rc As Integer = 0
            Dim cuenta_comp As Integer = 0
            Dim cuenta_compsuero As Integer = 0
            Dim cuenta_criosc As Integer = 0
            Dim cuenta_inhib As Integer = 0
            Dim cuenta_charm As Integer = 0
            Dim cuenta_espor As Integer = 0
            Dim cuenta_urea As Integer = 0
            Dim cuenta_termo As Integer = 0
            Dim cuenta_psicro As Integer = 0
            Dim cuenta_criosc_criosc As Integer = 0
            Dim cuenta_caseina As Integer = 0
            Dim cuenta_aflatoxinam1 As Integer = 0
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        texto2 = texto2 + csm.MUESTRA
                        If csm.RB = 1 Then
                            cuenta_rb = cuenta_rb + 1
                        End If
                        If csm.RC = 1 Then
                            cuenta_rc = cuenta_rc + 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            cuenta_comp = cuenta_comp + 1
                        End If
                        If csm.COMPOSICIONSUERO = 1 Then
                            cuenta_compsuero = cuenta_compsuero + 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            cuenta_criosc = cuenta_criosc + 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            cuenta_inhib = cuenta_inhib + 1
                        End If
                        If csm.CHARM = 1 Then
                            cuenta_charm = cuenta_charm + 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            cuenta_espor = cuenta_espor + 1
                        End If
                        If csm.UREA = 1 Then
                            cuenta_urea = cuenta_urea + 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            cuenta_termo = cuenta_termo + 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            cuenta_psicro = cuenta_psicro + 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            cuenta_criosc_criosc = cuenta_criosc_criosc + 1
                        End If
                        If csm.CASEINA = 1 Then
                            cuenta_caseina = cuenta_caseina + 1
                        End If
                        If csm.AFLATOXINA = 1 Then
                            cuenta_aflatoxinam1 = cuenta_aflatoxinam1 + 1
                        End If
                        texto2 = texto2 + " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G43").Merge()
            x1hoja.Range("A40", "G43").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            If cuenta_rb > 0 Then
                texto3 = texto3 & cuenta_rb & " RB - "
            End If
            If cuenta_rc > 0 Then
                texto3 = texto3 & cuenta_rc & " RC - "
            End If
            If cuenta_comp > 0 Then
                texto3 = texto3 & cuenta_comp & " Comp. - "
            End If
            If cuenta_compsuero > 0 Then
                texto3 = texto3 & cuenta_compsuero & " Comp. suero - "
            End If
            If cuenta_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc & " Criosc. - "
            End If
            If cuenta_inhib > 0 Then
                texto3 = texto3 & cuenta_inhib & " Inhib. - "
            End If
            If cuenta_charm > 0 Then
                texto3 = texto3 & cuenta_charm & " Charm - "
            End If
            If cuenta_espor > 0 Then
                texto3 = texto3 & cuenta_espor & " Espor. - "
            End If
            If cuenta_urea > 0 Then
                texto3 = texto3 & cuenta_urea & " Urea - "
            End If
            If cuenta_termo > 0 Then
                texto3 = texto3 & cuenta_termo & " Termof. - "
            End If
            If cuenta_psicro > 0 Then
                texto3 = texto3 & cuenta_psicro & " Psicro. - "
            End If
            If cuenta_criosc_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc_criosc & " Criosc.(Crióscopo) - "
            End If
            If cuenta_caseina > 0 Then
                texto3 = texto3 & cuenta_caseina & " Caseina - "
            End If
            If cuenta_aflatoxinam1 > 0 Then
                texto3 = texto3 & cuenta_aflatoxinam1 & " Aflatoxina M1 - "
            End If
            fila = fila + 4
            'x1hoja.Range("A45", "G46").Merge()
            'x1hoja.Range("A45", "G46").WrapText = True
            x1hoja.Cells(fila, columna).Formula = "Total: " + texto3
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 1
            ' SI ES CONTROL LECHERO ********************************************************************************
        ElseIf tipoinforme = "Control Lechero" Then
            texto2 = ""
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES ANTIBIOGRAMA ********************************************************************************
        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES AMBIENTAL ********************************************************************************
        ElseIf tipoinforme = "Ambiental" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES PARASITOLOGÍA ********************************************************************************
        ElseIf tipoinforme = "Parasitología" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES PAL ********************************************************************************
        ElseIf tipoinforme = "PAL" Then
            texto2 = ""
            If Not lista10 Is Nothing Then
                If lista10.Count > 0 Then
                    For Each spal In lista10
                        texto2 = texto2 + spal.MATRICULA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            Dim solpal As New dSolicitudPAL
            solpal.FICHA = ficha
            solpal = solpal.buscar
            If Not solpal Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = "Vacas: " & solpal.VACAS & " - " & "Fecha extracción: " & solpal.FECHAEXT
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
            End If
            '********************************************************************************************************************
            ' SI ES BRUCELOSIS LECHE ********************************************************************************
        ElseIf tipoinforme = "Brucelosis en leche" Then
            texto2 = ""
            If Not listabl Is Nothing Then
                If listabl.Count > 0 Then
                    For Each sm In listabl
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
        ElseIf tipoinforme = "Nutrición" Then
            fila = fila + 5
        ElseIf tipoinforme = "Suelos" Then
            fila = fila + 5
        Else
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
        End If
        '********************************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Observaciones:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = observaciones
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2
        'x1hoja.Cells(fila, columna).formula = "En nuestro sitio web http://www.colaveco.com.uy/gestor, puede descargar los resultados, solicite usuario y contraseña."
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 10
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "COLAVECO - Parque El Retiro - Nueva Helvecia - Tel/Fax: 45545311/45545975/45546838"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Email: colaveco@gmail.com - web: http://www.colaveco.com.uy"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Cuando el cliente solicite suspender el servicio ya presupuestado y en ejecución, o una parte del mismo,"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "los costos de las actividades ya realizadas en el momento de la suspensión deberán pagarse."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Los resultados de este análisis pueden ser utilizados y/o publicados por COLAVECO, con fines"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "científicos, protegiendo la confidencialidad del cliente."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        If Not dm Is Nothing Then
            If dm.IDINFORETORNO = 1 Then
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Autorizo a procesar las muestras a pesar de no cumplir con las condiciones establecidas en el PG.LAB.01"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
            End If
        End If
        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "FIRMA DEL CLIENTE / ACLARACIÓN: _____________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        'x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        x1hoja.SaveAs("\\192.168.1.10\E\NET\TICKET_CLIENTES\TC" & ficha & ".xls")
        x1app.Visible = True
        x1libro.PrintPreview()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub imprimir_ticket3()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)
        Dim ficha As String = TextId.Text.Trim
        Dim fecha As Date = DateFechaIngreso.Value
        Dim nmuestras As String
        If TextNMuestras.Text <> "" Then
            nmuestras = TextNMuestras.Text.Trim
        Else
            nmuestras = ""
        End If
        Dim muestra As String = ComboMuestra.Text
        Dim solicitud As String = ""
        Dim texto As String = ""
        Dim texto2 As String = ""
        Dim texto3 As String = ""
        Dim usucontra As String = ""
        Dim tipoinforme As String = ComboTipoInforme.Text
        Dim subtipoinforme As String = ComboSubInforme.Text
        Dim observaciones As String = TextObservaciones.Text.Trim
        Dim fila = 1
        Dim columna = 5
        x1hoja.Cells(fila, columna).formula = "RG.ADM.54 v02 06/06/18"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = 2
        columna = 1
        columna = columna + 2
        x1hoja.Cells(fila, columna).formula = "Solicitud de análisis"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Ficha:" & " " & TextId.Text
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Realizada por:" & " " & Usuario.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Fecha/Hora de recepción:" & " " & fecha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        'fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Muestras:" & " " & nmuestras
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        Dim pro As New dCliente
        Dim nombre_productor As String = ""
        Dim idproductor As Long = 0
        pro.ID = TextIdProductor.Text.Trim
        pro = pro.buscar
        If Not pro Is Nothing Then
            nombre_productor = pro.NOMBRE
            usucontra = pro.USUARIO_WEB
            idproductor = pro.ID
        Else
            nombre_productor = ""
        End If
        x1hoja.Cells(fila, columna).formula = "Cliente:" & " " & nombre_productor & " " & "(" & idproductor & ")"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Muestra de:" & " " & muestra
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        'x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).formula = "-----------------------------------------------------------------------------"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        Dim sm As New dRelSolicitudMuestras
        Dim spal As New dSolicitudPAL
        Dim csm As New dCalidadSolicitudMuestra
        Dim cs As New dControlSolicitud
        Dim a2 As New dAntibiograma2
        Dim sn As New dSolicitudNutricion
        Dim ss As New dSolicitudSuelos
        Dim bl As New dBrucelosis
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim lista4 As New ArrayList
        Dim lista5 As New ArrayList
        Dim lista6 As New ArrayList
        Dim lista7 As New ArrayList
        Dim lista10 As New ArrayList
        Dim listabl As New ArrayList
        Dim listanutricion As New ArrayList
        Dim listasuelos As New ArrayList
        Dim cajas As String = ""
        Dim gradillas As String = ""
        Dim otros As String = ""
        lista4 = sm.listarporficha(ficha)
        lista5 = csm.listarporsolicitud3(ficha)
        lista6 = cs.listarporsolicitud(ficha)
        lista7 = a2.listarporsolicitud(ficha)
        lista10 = spal.listarporsolicitud(ficha)
        listanutricion = sn.listarporsolicitud(ficha)
        listasuelos = ss.listarporsolicitud(ficha)
        listabl = sm.listarporficha(ficha)
        x1hoja.Cells(fila, columna).formula = "Análisis requerido: " & tipoinforme & " // " & "Subinforme:" & " " & subtipoinforme
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '***  LISTADO DE ANALISIS REQUERIDOS *********************************************************************
        ' SI ES ALIMENTOS ********************************************************************************
        If tipoinforme = "Alimentos" Then
            Dim sp As New dSubproducto
            Dim lista As New ArrayList
            texto = ""
            lista = sp.listarporsolicitud(ficha)
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each sp In lista
                        texto = ""
                        If sp.ESTAFCOAGPOSITIVO = 1 Then
                            texto = texto + " - Estaf. Coag. Positivo"
                        End If
                        If sp.CF = 1 Then
                            texto = texto + " - CF"
                        End If
                        If sp.MOHOSYLEVADURAS = 1 Then
                            texto = texto + " - Mohos y levaduras"
                        End If
                        If sp.CT = 1 Then
                            texto = texto + " - Coliformes Totales"
                        End If
                        If sp.ECOLI = 1 Then
                            texto = texto + " - E. Coli"
                        End If
                        If sp.SALMONELLA = 1 Then
                            texto = texto + " - Salmonella"
                        End If
                        If sp.LISTERIASPP = 1 Then
                            texto = texto + " - Listeria spp"
                        End If
                        If sp.HUMEDAD = 1 Then
                            texto = texto + " - Humedad"
                        End If
                        If sp.MGRASA = 1 Then
                            texto = texto + " - M. Grasa"
                        End If
                        If sp.PH = 1 Then
                            texto = texto + " - pH"
                        End If
                        If sp.CLORUROS = 1 Then
                            texto = texto + " - Cloruros"
                        End If
                        If sp.PROTEINAS = 1 Then
                            texto = texto + " - Proteínas"
                        End If
                        If sp.ENTEROBACTERIAS = 1 Then
                            texto = texto + " - Enterobacterias"
                        End If
                        If sp.LISTERIAAMBIENTAL = 1 Then
                            texto = texto + " - Listeria Ambiental"
                        End If
                        If sp.ESPORANAERMESOFILO = 1 Then
                            texto = texto + " - Espor. Anaer. Mesófilos"
                        End If
                        If sp.TERMOFILOS = 1 Then
                            texto = texto + " - Termodúricos"
                        End If
                        If sp.PSICROTROFOS = 1 Then
                            texto = texto + " - Psicrótrofos"
                        End If
                        If sp.RB = 1 Then
                            texto = texto + " - RB"
                        End If
                        If sp.TABLANUTRICIONAL = 1 Then
                            texto = texto + " - Tabla nutricional"
                        End If
                        If sp.LISTERIAMONOCITOGENES = 1 Then
                            texto = texto + " - Listeria monocitógenes"
                        End If
                        If sp.CENIZAS = 1 Then
                            texto = texto + " - Cenizas"
                        End If
                        If sp.LISTERIAPOOL = 1 Then
                            texto = texto + " - Pool de Listeria"
                        End If
                        If sp.SALMONELLAPOOL = 1 Then
                            texto = texto + " - Pool de Salmonella"
                        End If
                    Next
                End If
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES AGUA ********************************************************************************
        ElseIf tipoinforme = "Agua" Then
            Dim a1 As New dAgua
            texto = ""
            a1.ID = ficha
            a1 = a1.buscar()
            texto = ComboSubInforme.Text
            If a1.HET22 = 1 Then
                texto = texto & " " & " - Heterotróficos 22"
            End If
            If a1.HET35 = 1 Then
                texto = texto & " " & " - Heterotróficos 35"
            End If
            If a1.HET37 = 1 Then
                texto = texto & " " & " - Heterotróficos 37"
            End If
            If a1.CLORO = 1 Then
                texto = texto & " " & " - Cloro"
            End If
            If a1.CONDUCTIVIDAD = 1 Then
                texto = texto & " " & " - Conductividad"
            End If
            If a1.PH = 1 Then
                texto = texto & " " & " - pH"
            End If
            If a1.ECOLI = 1 Then
                texto = texto & " " & " - Ecoli"
            End If
            If a1.SULFITOREDUCTORES = 1 Then
                texto = texto & " " & " - Sulfito reductores"
            End If
            If a1.ENTEROCOCOS = 1 Then
                texto = texto & " " & " - Enterococos"
            End If
            If a1.ESTREPTOCOCOS = 1 Then
                texto = texto & " " & " - Estreptococos"
            End If
            If a1.PAQMACRO = 1 Then
                texto = texto & " " & " - Paq. Macroelementos "
            End If
            If a1.ALCALINIDAD = 1 Then
                texto = texto & " " & " - Alcalinidad "
            End If
            If a1.CA = 1 Then
                texto = texto & " " & "+ Ca "
            End If
            If a1.MG = 1 Then
                texto = texto & " " & "+ Mg "
            End If
            If a1.NA = 1 Then
                texto = texto & " " & "+ Na "
            End If
            If a1.FE = 1 Then
                texto = texto & " " & "+ Fe "
            End If
            If a1.K = 1 Then
                texto = texto & " " & "+ K "
            End If
            If a1.AL = 1 Then
                texto = texto & " " & "+ Al "
            End If
            If a1.CD = 1 Then
                texto = texto & " " & "+ Cd "
            End If
            If a1.CR = 1 Then
                texto = texto & " " & "+ Cr "
            End If
            If a1.CU = 1 Then
                texto = texto & " " & "+ Cu "
            End If
            If a1.PB = 1 Then
                texto = texto & " " & "+ Pb "
            End If
            If a1.MN = 1 Then
                texto = texto & " " & "+ Mn "
            End If
            If a1.FE = 1 Then
                texto = texto & " " & "+ fe "
            End If
            If a1.ZN = 1 Then
                texto = texto & " " & "+ Zn "
            End If
            If a1.SE = 1 Then
                texto = texto & " " & "+ Se "
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES CALIDAD DE LECHE ********************************************************************************
        ElseIf tipoinforme = "Calidad de leche" Then
            Dim rb As Integer = 0
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim compsuero As Integer = 0
            Dim criosc As Integer = 0
            Dim inh As Integer = 0
            Dim charm As Integer = 0
            Dim espor As Integer = 0
            Dim urea As Integer = 0
            Dim term As Integer = 0
            Dim psicr As Integer = 0
            Dim crioscopo As Integer = 0
            Dim aflatoxinam1 As Integer = 0
            Dim caseina As Integer = 0
            texto = ""
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        If csm.RB = 1 Then
                            rb = 1
                        End If
                        If csm.RC = 1 Then
                            rc = 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If csm.COMPOSICIONSUERO = 1 Then
                            compsuero = 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            criosc = 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            inh = 1
                        End If
                        If csm.CHARM = 1 Then
                            charm = 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            espor = 1
                        End If
                        If csm.UREA = 1 Then
                            urea = 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            term = 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            psicr = 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            crioscopo = 1
                        End If
                        If csm.AFLATOXINA = 1 Then
                            aflatoxinam1 = 1
                        End If
                        If csm.CASEINA = 1 Then
                            caseina = 1
                        End If
                    Next
                End If
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If compsuero = 1 Then
                texto = texto + " - Composición suero"
            End If
            If criosc = 1 Then
                texto = texto + " - Crioscopía"
            End If
            If inh = 1 Then
                texto = texto + " - Inhibidores"
            End If
            If charm = 1 Then
                texto = texto + " - Charm"
            End If
            If espor = 1 Then
                texto = texto + " - Esporulados"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If term = 1 Then
                texto = texto + " - Termófilos"
            End If
            If psicr = 1 Then
                texto = texto + " - Psicrótrofos"
            End If
            If crioscopo = 1 Then
                texto = texto + " - Crioscopía (crióscopo)"
            End If
            If aflatoxinam1 = 1 Then
                texto = texto + " - Aflatoxina M1"
            End If
            If caseina = 1 Then
                texto = texto + " - Caseína"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES CONTROL LECHERO ********************************************************************************
        ElseIf tipoinforme = "Control Lechero" Then
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim urea As Integer = 0
            Dim caseina As Integer = 0
            texto = ""
            If Not lista6 Is Nothing Then
                If lista6.Count > 0 Then
                    For Each cs In lista6
                        If cs.RC = 1 Then
                            rc = 1
                        End If
                        If cs.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If cs.UREA = 1 Then
                            urea = 1
                        End If
                        If cs.CASEINA = 1 Then
                            caseina = 1
                        End If
                    Next
                End If
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If caseina = 1 Then
                texto = texto + " - Caseina"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ANTIBIOGRAMA ********************************************************************************
        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            Dim aislamiento As Integer = 0
            Dim antibiograma As Integer = 0
            texto = ""
            If Not lista7 Is Nothing Then
                If lista7.Count > 0 Then
                    For Each a2 In lista7
                        If a2.AISLAMIENTO = 1 Then
                            aislamiento = 1
                        End If
                        If a2.ANTIBIOGRAMA = 1 Then
                            antibiograma = 1
                        End If
                    Next
                End If
            End If
            If aislamiento = 1 Then
                texto = texto + " - Aislamiento"
            End If
            If antibiograma = 1 Then
                texto = texto + " - Antibiograma"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES AMBIENTAL ********************************************************************************
        ElseIf tipoinforme = "Ambiental" Then
            Dim ambs As New dAmbientalSolicitud
            Dim lista8 As ArrayList
            lista8 = ambs.listarporsolicitud(ficha)
            Dim enterobacterias As Integer = 0
            Dim listambiental As Integer = 0
            Dim listmono As Integer = 0
            Dim salmonella As Integer = 0
            Dim ecoli As Integer = 0
            Dim mohosylevaduras As Integer = 0
            Dim rb As Integer = 0
            Dim ct As Integer = 0
            Dim cf As Integer = 0
            Dim pseudomonaspp As Integer = 0
            Dim listeriaspp As Integer = 0
            texto = ""
            If Not lista8 Is Nothing Then
                If lista8.Count > 0 Then
                    For Each ambs In lista8
                        If ambs.ENTEROBACTERIAS = 1 Then
                            enterobacterias = 1
                        End If
                        If ambs.LISTAMBIENTAL = 1 Then
                            listambiental = 1
                        End If
                        If ambs.LISTMONO = 1 Then
                            listmono = 1
                        End If
                        If ambs.SALMONELLA = 1 Then
                            salmonella = 1
                        End If
                        If ambs.ECOLI = 1 Then
                            ecoli = 1
                        End If
                        If ambs.MOHOSYLEVADURAS = 1 Then
                            mohosylevaduras = 1
                        End If
                        If ambs.RB = 1 Then
                            rb = 1
                        End If
                        If ambs.CT = 1 Then
                            ct = 1
                        End If
                        If ambs.CF = 1 Then
                            cf = 1
                        End If
                        If ambs.PSEUDOMONASPP = 1 Then
                            pseudomonaspp = 1
                        End If
                        If ambs.LISTSPP = 1 Then
                            listeriaspp = 1
                        End If
                    Next
                End If
            End If
            If enterobacterias = 1 Then
                texto = texto + " - Enterobacterias"
            End If
            If listambiental = 1 Then
                texto = texto + " - Listeria ambiental"
            End If
            If listmono = 1 Then
                texto = texto + " - Listeria monocitógenes"
            End If
            If salmonella = 1 Then
                texto = texto + " - Salmonella"
            End If
            If ecoli = 1 Then
                texto = texto + " - E. Coli"
            End If
            If mohosylevaduras = 1 Then
                texto = texto + " - Mohos y levaduras"
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If ct = 1 Then
                texto = texto + " - Coliformes totales"
            End If
            If cf = 1 Then
                texto = texto + " - CF"
            End If
            If pseudomonaspp = 1 Then
                texto = texto + " - Pseudomona spp"
            End If
            If listeriaspp = 1 Then
                texto = texto + " - Listeria spp"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES PARASITOLOGÍA ********************************************************************************
        ElseIf tipoinforme = "Parasitología" Then
            Dim p As New dParasitologiaSolicitud
            Dim lista9 As ArrayList
            lista9 = p.listarporsolicitud(ficha)
            Dim gastrointestinales As Integer = 0
            Dim fasciola As Integer = 0
            Dim coccidias As Integer = 0
            texto = ""
            If Not lista9 Is Nothing Then
                If lista9.Count > 0 Then
                    For Each p In lista9
                        If p.GASTROINTESTINALES = 1 Then
                            gastrointestinales = 1
                        End If
                        If p.FASCIOLA = 1 Then
                            fasciola = 1
                        End If
                        If p.COCCIDIAS = 1 Then
                            coccidias = 1
                        End If
                    Next
                End If
            End If
            If gastrointestinales = 1 Then
                texto = texto + " - Gastrointestinales"
            End If
            If fasciola = 1 Then
                texto = texto + " - Fasciola"
            End If
            If coccidias = 1 Then
                texto = texto + " - Coccidias"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES NUTRICIÓN ********************************************************************************
        ElseIf tipoinforme = "Nutrición" Then
            Dim mga As Integer = 0
            Dim mgb As Integer = 0
            Dim ensilados As Integer = 0
            Dim pasturas As Integer = 0
            Dim extetereo As Integer = 0
            Dim nida As Integer = 0
            Dim micotoxinas As Integer = 0
            texto = ""
            If Not listanutricion Is Nothing Then
                If listanutricion.Count > 0 Then
                    For Each sn In listanutricion
                        texto = texto & " // " & sn.MUESTRA & " - "
                        If sn.MGA = 1 Then
                            texto = texto & "MGA - "
                        End If
                        If sn.MGB = 1 Then
                            texto = texto & "MGB - "
                        End If
                        If sn.ENSILADOS = 1 Then
                            texto = texto & "Ensilados - "
                        End If
                        If sn.PASTURAS = 1 Then
                            texto = texto & "Pasturas - "
                        End If
                        If sn.EXTETEREO = 1 Then
                            texto = texto & "Extracto etéreo - "
                        End If
                        If sn.NIDA = 1 Then
                            texto = texto & "NIDA - "
                        End If
                        If sn.MICOTOXINAS = 1 Then
                            texto = texto & "MICOTOXINAS - "
                        End If
                        If sn.AFLA = 1 Then
                            texto = texto & "AFLA - "
                        End If
                        If sn.DON = 1 Then
                            texto = texto & "DON - "
                        End If
                        If sn.ZEARA = 1 Then
                            texto = texto & "ZEARA - "
                        End If
                        If sn.PROTEINAS = 1 Then
                            texto = texto & "PROTEINAS - "
                        End If
                        If sn.MATERIASECA = 1 Then
                            texto = texto & "MATERIA SECA - "
                        End If
                        If sn.FIBRANEUTRA = 1 Then
                            texto = texto & "FIBRA NEUTRA - "
                        End If
                        If sn.FIBRAACIDA = 1 Then
                            texto = texto & "FIBRA ÁCIDA - "
                        End If
                        If sn.PH = 1 Then
                            texto = texto & "pH - "
                        End If
                    Next
                End If
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES SUELOS ********************************************************************************
        ElseIf tipoinforme = "Suelos" Then
            Dim nitratos As Integer = 0
            Dim mineralizacion As Integer = 0
            Dim fosforobray As Integer = 0
            Dim fosforocitrico As Integer = 0
            Dim phagua As Integer = 0
            Dim phkci As Integer = 0
            Dim materiaorg As Integer = 0
            Dim potasioint As Integer = 0
            Dim sulfatos As Integer = 0
            Dim nitrogenovegetal As Integer = 0
            texto = ""
            If Not listasuelos Is Nothing Then
                If listasuelos.Count > 0 Then
                    For Each ss In listasuelos
                        texto = texto & " // " & ss.MUESTRA & " - "
                        If ss.PAQUETE = 1 Then
                            texto = texto & "Paquete 1 (Completo) - "
                        End If
                        If ss.PAQUETE = 2 Then
                            texto = texto & "Paquete 2 (Cultivos de verano) - "
                        End If
                        If ss.PAQUETE = 3 Then
                            texto = texto & "Paquete 3 (Cultivos de invierno) - "
                        End If
                        If ss.PAQUETE = 4 Then
                            texto = texto & "Paquete 4 (Cationes) - "
                        End If
                        If ss.PAQUETE = 5 Then
                            texto = texto & "Paquete 5 (Pastura) - "
                        End If
                        If ss.PAQUETE = 7 Then
                            texto = texto & "Paquete foliares (Fósforo y Potasio Total) "
                        End If
                        If ss.NITRATOS = 1 Then
                            texto = texto & "Nitratos - "
                        End If
                        If ss.MINERALIZACION = 1 Then
                            texto = texto & "Mineralización - "
                        End If
                        If ss.FOSFOROBRAY = 1 Then
                            texto = texto & "Fósforo Bray I - "
                        End If
                        If ss.FOSFOROCITRICO = 1 Then
                            texto = texto & "Fósforo Ac.Cítrico - "
                        End If
                        If ss.PHAGUA = 1 Then
                            texto = texto & "pH Agua - "
                        End If
                        If ss.PHKCI = 1 Then
                            texto = texto & "pH KCI - "
                        End If
                        If ss.MATERIAORG = 1 Then
                            texto = texto & "Materia orgánica - "
                        End If
                        If ss.POTASIOINT = 1 Then
                            texto = texto & "Potasio intercambiable - "
                        End If
                        If ss.SULFATOS = 1 Then
                            texto = texto & "Sulfatos - "
                        End If
                        If ss.NITROGENOVEGETAL = 1 Then
                            texto = texto & "Nitrógeno vegetal - "
                        End If
                        If ss.MAGNESIO = 1 Then
                            texto = texto & "Magnesio - "
                        End If
                        If ss.SODIO = 1 Then
                            texto = texto & "Sodio - "
                        End If
                        If ss.ACIDEZTITULABLE = 1 Then
                            texto = texto & "Acidez titulable - "
                        End If
                        If ss.CIC = 1 Then
                            texto = texto & "CIC - "
                        End If
                        If ss.SB = 1 Then
                            texto = texto & "% SB - "
                        End If
                        If ss.ZINC = 1 Then
                            texto = texto & "ZINC - "
                        End If
                    Next
                End If
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
        Else
            x1hoja.Range("A9", "G10").Merge()
            x1hoja.Range("A9", "G10").WrapText = True
            'x1hoja.Cells(fila, columna).Formula = texto
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 2
        End If
        '**********************************************************************************************
        'x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).formula = "-----------------------------------------------------------------------------"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Identificación de las muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '*** LISTADO DE MUESTRAS *********************************************************************************
        ' SI ES ALIMENTOS ********************************************************************************
        If tipoinforme = "Alimentos" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4

                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES AGUA ********************************************************************************
        ElseIf tipoinforme = "Agua" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES CALIDAD ********************************************************************************
        ElseIf tipoinforme = "Calidad de leche" Then
            texto2 = ""
            Dim cuenta_rb As Integer = 0
            Dim cuenta_rc As Integer = 0
            Dim cuenta_comp As Integer = 0
            Dim cuenta_compsuero As Integer = 0
            Dim cuenta_criosc As Integer = 0
            Dim cuenta_inhib As Integer = 0
            Dim cuenta_charm As Integer = 0
            Dim cuenta_espor As Integer = 0
            Dim cuenta_urea As Integer = 0
            Dim cuenta_termo As Integer = 0
            Dim cuenta_psicro As Integer = 0
            Dim cuenta_criosc_criosc As Integer = 0
            Dim cuenta_caseina As Integer = 0
            Dim cuenta_aflatoxina As Integer = 0
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        texto2 = texto2 + csm.MUESTRA
                        If csm.RB = 1 Then
                            cuenta_rb = cuenta_rb + 1
                        End If
                        If csm.RC = 1 Then
                            cuenta_rc = cuenta_rc + 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            cuenta_comp = cuenta_comp + 1
                        End If
                        If csm.COMPOSICIONSUERO = 1 Then
                            cuenta_compsuero = cuenta_compsuero + 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            cuenta_criosc = cuenta_criosc + 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            cuenta_inhib = cuenta_inhib + 1
                        End If
                        If csm.CHARM = 1 Then
                            cuenta_charm = cuenta_charm + 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            cuenta_espor = cuenta_espor + 1
                        End If
                        If csm.UREA = 1 Then
                            cuenta_urea = cuenta_urea + 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            cuenta_termo = cuenta_termo + 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            cuenta_psicro = cuenta_psicro + 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            cuenta_criosc_criosc = cuenta_criosc_criosc + 1
                        End If
                        If csm.CASEINA = 1 Then
                            cuenta_caseina = cuenta_caseina + 1
                        End If
                        If csm.AFLATOXINA = 1 Then
                            cuenta_aflatoxina = cuenta_aflatoxina + 1
                        End If
                        texto2 = texto2 + " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G16").Merge()
            x1hoja.Range("A13", "G16").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            If cuenta_rb > 0 Then
                texto3 = texto3 & cuenta_rb & " RB - "
            End If
            If cuenta_rc > 0 Then
                texto3 = texto3 & cuenta_rc & " RC - "
            End If
            If cuenta_comp > 0 Then
                texto3 = texto3 & cuenta_comp & " Comp. - "
            End If
            If cuenta_compsuero > 0 Then
                texto3 = texto3 & cuenta_compsuero & " Comp. suero - "
            End If
            If cuenta_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc & " Criosc. - "
            End If
            If cuenta_inhib > 0 Then
                texto3 = texto3 & cuenta_inhib & " Inhib. - "
            End If
            If cuenta_charm > 0 Then
                texto3 = texto3 & cuenta_charm & " Charm - "
            End If
            If cuenta_espor > 0 Then
                texto3 = texto3 & cuenta_espor & " Espor. - "
            End If
            If cuenta_urea > 0 Then
                texto3 = texto3 & cuenta_urea & " Urea - "
            End If
            If cuenta_termo > 0 Then
                texto3 = texto3 & cuenta_termo & " Termof. - "
            End If
            If cuenta_psicro > 0 Then
                texto3 = texto3 & cuenta_psicro & " Psicro. - "
            End If
            If cuenta_criosc_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc_criosc & " Criosc.(Crióscopo) - "
            End If
            If cuenta_caseina > 0 Then
                texto3 = texto3 & cuenta_caseina & " Caseina - "
            End If
            If cuenta_aflatoxina > 0 Then
                texto3 = texto3 & cuenta_aflatoxina & " Aflatoxina M1 - "
            End If
            fila = fila + 4
            'x1hoja.Range("A27", "G28").Merge()
            'x1hoja.Range("A27", "G28").WrapText = True
            x1hoja.Cells(fila, columna).Formula = "Total: " + texto3
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 1
            ' SI ES CONTROL LECHERO ********************************************************************************
        ElseIf tipoinforme = "Control Lechero" Then
            texto2 = ""
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES ANTIBIOGRAMA ********************************************************************************
        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES AMBIENTAL ********************************************************************************
        ElseIf tipoinforme = "Ambiental" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES PARASITOLOGÍA ********************************************************************************
        ElseIf tipoinforme = "Parasitología" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES PAL ********************************************************************************
        ElseIf tipoinforme = "PAL" Then
            texto2 = ""
            If Not lista10 Is Nothing Then
                If lista10.Count > 0 Then
                    For Each spal In lista10
                        texto2 = texto2 + spal.MATRICULA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            Dim solpal As New dSolicitudPAL
            solpal.FICHA = ficha
            solpal = solpal.buscar
            If Not solpal Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = "Vacas: " & solpal.VACAS & " - " & "Fecha extracción: " & solpal.FECHAEXT
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
            End If
            '********************************************************************************************************************
            ' SI ES BRUCELOSIS LECHE ********************************************************************************
        ElseIf tipoinforme = "Brucelosis en leche" Then
            texto2 = ""
            If Not listabl Is Nothing Then
                If listabl.Count > 0 Then
                    For Each sm In listabl
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
        ElseIf tipoinforme = "Nutrición" Then
            fila = fila + 5
        ElseIf tipoinforme = "Suelos" Then
            fila = fila + 5
        Else
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
        End If
        '********************************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Observaciones:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1

        Dim dm As New dDescarteMuestras
        dm.FICHA = ficha
        dm = dm.buscarxficha
        If Not dm Is Nothing Then
            If dm.IDINFORETORNO = 1 Then
                observaciones = observaciones & " * Muestras fuera de condición."
            End If
        End If

        x1hoja.Cells(fila, columna).formula = observaciones
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "IMPORTANTE"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Ud. puede descargar los resultados desde nuestra web, solicite usuario y contraseña"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        'fila = fila + 1
        'x1hoja.Cells(fila, columna).formula = "Usuario y contraseña: " & usucontra
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 10
        'x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Recuerde que los resultados quedan habilitados si el cliente no tiene facturas vencidas."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Si tiene dificultades para obtener los resultados, comunicarse al 4554 5311 /5975/6838"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "o vía mail a colaveco@gmail.com (Horario de atención al público L a V de 8 a 17 Hs."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        ' SEGUNDA COPIA *************************************************************************************************************************************
        fila = fila + 2
        columna = 5
        x1hoja.Cells(fila, columna).formula = "RG.ADM.54 v02 06/06/18"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1
        columna = columna + 2
        x1hoja.Cells(fila, columna).formula = "Solicitud de análisis"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Ficha:" & " " & TextId.Text
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Realizada por:" & " " & Usuario.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Fecha/Hora de recepción:" & " " & fecha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        'fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Muestras:" & " " & nmuestras
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        If Not pro Is Nothing Then
            nombre_productor = pro.NOMBRE
        Else
            nombre_productor = ""
        End If
        x1hoja.Cells(fila, columna).formula = "Cliente:" & " " & nombre_productor
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Muestra de:" & " " & muestra
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        'x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).formula = "-----------------------------------------------------------------------------"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Análisis requerido: " & tipoinforme & " // " & "Subinforme:" & " " & subtipoinforme
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '***  LISTADO DE ANALISIS REQUERIDOS *********************************************************************
        ' SI ES ALIMENTOS ********************************************************************************
        If tipoinforme = "Alimentos" Then
            Dim sp As New dSubproducto
            Dim lista As New ArrayList
            texto = ""
            lista = sp.listarporsolicitud(ficha)
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each sp In lista
                        texto = ""
                        If sp.ESTAFCOAGPOSITIVO = 1 Then
                            texto = texto + " - Estaf. Coag. Positivo"
                        End If
                        If sp.CF = 1 Then
                            texto = texto + " - CF"
                        End If
                        If sp.MOHOSYLEVADURAS = 1 Then
                            texto = texto + " - Mohos y levaduras"
                        End If
                        If sp.CT = 1 Then
                            texto = texto + " - Coliformes Totales"
                        End If
                        If sp.ECOLI = 1 Then
                            texto = texto + " - E. Coli"
                        End If
                        If sp.SALMONELLA = 1 Then
                            texto = texto + " - Salmonella"
                        End If
                        If sp.LISTERIASPP = 1 Then
                            texto = texto + " - Listeria spp"
                        End If
                        If sp.HUMEDAD = 1 Then
                            texto = texto + " - Humedad"
                        End If
                        If sp.MGRASA = 1 Then
                            texto = texto + " - M. Grasa"
                        End If
                        If sp.PH = 1 Then
                            texto = texto + " - pH"
                        End If
                        If sp.CLORUROS = 1 Then
                            texto = texto + " - Cloruros"
                        End If
                        If sp.PROTEINAS = 1 Then
                            texto = texto + " - Proteínas"
                        End If
                        If sp.ENTEROBACTERIAS = 1 Then
                            texto = texto + " - Enterobacterias"
                        End If
                        If sp.LISTERIAAMBIENTAL = 1 Then
                            texto = texto + " - Listeria Ambiental"
                        End If
                        If sp.ESPORANAERMESOFILO = 1 Then
                            texto = texto + " - Espor. Anaer. Mesófilos"
                        End If
                        If sp.TERMOFILOS = 1 Then
                            texto = texto + " - Termodúricos"
                        End If
                        If sp.PSICROTROFOS = 1 Then
                            texto = texto + " - Psicrótrofos"
                        End If
                        If sp.RB = 1 Then
                            texto = texto + " - RB"
                        End If
                        If sp.TABLANUTRICIONAL = 1 Then
                            texto = texto + " - Tabla nutricional"
                        End If
                        If sp.LISTERIAMONOCITOGENES = 1 Then
                            texto = texto + " - Listeria monocitógenes"
                        End If
                        If sp.CENIZAS = 1 Then
                            texto = texto + " - Cenizas"
                        End If
                    Next
                End If
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES AGUA ********************************************************************************
        ElseIf tipoinforme = "Agua" Then
            Dim a1 As New dAgua
            texto = ""
            a1.ID = ficha
            a1 = a1.buscar()
            texto = ComboSubInforme.Text
            If a1.HET22 = 1 Then
                texto = texto & " " & " - Heterotróficos 22"
            End If
            If a1.HET35 = 1 Then
                texto = texto & " " & " - Heterotróficos 35"
            End If
            If a1.HET37 = 1 Then
                texto = texto & " " & " - Heterotróficos 37"
            End If
            If a1.CLORO = 1 Then
                texto = texto & " " & " - Cloro"
            End If
            If a1.CONDUCTIVIDAD = 1 Then
                texto = texto & " " & " - Conductividad"
            End If
            If a1.PH = 1 Then
                texto = texto & " " & " - pH"
            End If
            If a1.ECOLI = 1 Then
                texto = texto & " " & " - Ecoli"
            End If
            If a1.SULFITOREDUCTORES = 1 Then
                texto = texto & " " & " - Sulfito reductores"
            End If
            If a1.ENTEROCOCOS = 1 Then
                texto = texto & " " & " - Enterococos"
            End If
            If a1.ESTREPTOCOCOS = 1 Then
                texto = texto & " " & " - Estreptococos"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES CALIDAD DE LECHE ********************************************************************************
        ElseIf tipoinforme = "Calidad de leche" Then
            Dim rb As Integer = 0
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim compsuero As Integer = 0
            Dim criosc As Integer = 0
            Dim inh As Integer = 0
            Dim charm As Integer = 0
            Dim espor As Integer = 0
            Dim urea As Integer = 0
            Dim term As Integer = 0
            Dim psicr As Integer = 0
            Dim crioscopo As Integer = 0
            Dim aflatoxinam1 As Integer = 0
            texto = ""
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        If csm.RB = 1 Then
                            rb = 1
                        End If
                        If csm.RC = 1 Then
                            rc = 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If csm.COMPOSICIONSUERO = 1 Then
                            compsuero = 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            criosc = 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            inh = 1
                        End If
                        If csm.CHARM = 1 Then
                            charm = 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            espor = 1
                        End If
                        If csm.UREA = 1 Then
                            urea = 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            term = 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            psicr = 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            crioscopo = 1
                        End If
                        If csm.AFLATOXINA = 1 Then
                            aflatoxinam1 = 1
                        End If
                    Next
                End If
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If compsuero = 1 Then
                texto = texto + " - Composición suero"
            End If
            If criosc = 1 Then
                texto = texto + " - Crioscopía"
            End If
            If inh = 1 Then
                texto = texto + " - Inhibidores"
            End If
            If charm = 1 Then
                texto = texto + " - Charm"
            End If
            If espor = 1 Then
                texto = texto + " - Esporulados"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If term = 1 Then
                texto = texto + " - Termófilos"
            End If
            If psicr = 1 Then
                texto = texto + " - Psicrótrofos"
            End If
            If crioscopo = 1 Then
                texto = texto + " - Crioscopía (crióscopo)"
            End If
            If aflatoxinam1 = 1 Then
                texto = texto + " - Aflatoxina M1"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES CONTROL LECHERO ********************************************************************************
        ElseIf tipoinforme = "Control Lechero" Then
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim urea As Integer = 0
            texto = ""
            If Not lista6 Is Nothing Then
                If lista6.Count > 0 Then
                    For Each cs In lista6
                        If cs.RC = 1 Then
                            rc = 1
                        End If
                        If cs.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If cs.UREA = 1 Then
                            urea = 1
                        End If
                    Next
                End If
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ANTIBIOGRAMA ********************************************************************************
        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            Dim aislamiento As Integer = 0
            Dim antibiograma As Integer = 0
            texto = ""
            If Not lista7 Is Nothing Then
                If lista7.Count > 0 Then
                    For Each a2 In lista7
                        If a2.AISLAMIENTO = 1 Then
                            aislamiento = 1
                        End If
                        If a2.ANTIBIOGRAMA = 1 Then
                            antibiograma = 1
                        End If
                    Next
                End If
            End If
            If aislamiento = 1 Then
                texto = texto + " - Aislamiento"
            End If
            If antibiograma = 1 Then
                texto = texto + " - Antibiograma"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES AMBIENTAL ********************************************************************************
        ElseIf tipoinforme = "Ambiental" Then
            Dim ambs As New dAmbientalSolicitud
            Dim lista8 As ArrayList
            lista8 = ambs.listarporsolicitud(ficha)
            Dim enterobacterias As Integer = 0
            Dim listambiental As Integer = 0
            Dim listmono As Integer = 0
            Dim salmonella As Integer = 0
            Dim ecoli As Integer = 0
            Dim mohosylevaduras As Integer = 0
            Dim rb As Integer = 0
            Dim ct As Integer = 0
            Dim cf As Integer = 0
            Dim pseudomonaspp As Integer = 0
            Dim listeriaspp As Integer = 0
            texto = ""
            If Not lista8 Is Nothing Then
                If lista8.Count > 0 Then
                    For Each ambs In lista8
                        If ambs.ENTEROBACTERIAS = 1 Then
                            enterobacterias = 1
                        End If
                        If ambs.LISTAMBIENTAL = 1 Then
                            listambiental = 1
                        End If
                        If ambs.LISTMONO = 1 Then
                            listmono = 1
                        End If
                        If ambs.SALMONELLA = 1 Then
                            salmonella = 1
                        End If
                        If ambs.ECOLI = 1 Then
                            ecoli = 1
                        End If
                        If ambs.MOHOSYLEVADURAS = 1 Then
                            mohosylevaduras = 1
                        End If
                        If ambs.RB = 1 Then
                            rb = 1
                        End If
                        If ambs.CT = 1 Then
                            ct = 1
                        End If
                        If ambs.CF = 1 Then
                            cf = 1
                        End If
                        If ambs.PSEUDOMONASPP = 1 Then
                            pseudomonaspp = 1
                        End If
                        If ambs.LISTSPP = 1 Then
                            listeriaspp = 1
                        End If
                    Next
                End If
            End If
            If enterobacterias = 1 Then
                texto = texto + " - Enterobacterias"
            End If
            If listambiental = 1 Then
                texto = texto + " - Listeria ambiental"
            End If
            If listmono = 1 Then
                texto = texto + " - Listeria monocitógenes"
            End If
            If salmonella = 1 Then
                texto = texto + " - Salmonella"
            End If
            If ecoli = 1 Then
                texto = texto + " - E. Coli"
            End If
            If mohosylevaduras = 1 Then
                texto = texto + " - Mohos y levaduras"
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If ct = 1 Then
                texto = texto + " - Coliformes totales"
            End If
            If cf = 1 Then
                texto = texto + " - CF"
            End If
            If pseudomonaspp = 1 Then
                texto = texto + " - Pseudomona spp"
            End If
            If listeriaspp = 1 Then
                texto = texto + " - Listeria spp"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES PARASITOLOGÍA ********************************************************************************
        ElseIf tipoinforme = "Parasitología" Then
            Dim p As New dParasitologiaSolicitud
            Dim lista9 As ArrayList
            lista9 = p.listarporsolicitud(ficha)
            Dim gastrointestinales As Integer = 0
            Dim fasciola As Integer = 0
            Dim coccidias As Integer = 0
            texto = ""
            If Not lista9 Is Nothing Then
                If lista9.Count > 0 Then
                    For Each p In lista9
                        If p.GASTROINTESTINALES = 1 Then
                            gastrointestinales = 1
                        End If
                        If p.FASCIOLA = 1 Then
                            fasciola = 1
                        End If
                        If p.COCCIDIAS = 1 Then
                            coccidias = 1
                        End If
                    Next
                End If
            End If
            If gastrointestinales = 1 Then
                texto = texto + " - Gastrointestinales"
            End If
            If fasciola = 1 Then
                texto = texto + " - Fasciola"
            End If
            If coccidias = 1 Then
                texto = texto + " - Coccidias"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES NUTRICIÓN ********************************************************************************
        ElseIf tipoinforme = "Nutrición" Then
            Dim mga As Integer = 0
            Dim mgb As Integer = 0
            Dim ensilados As Integer = 0
            Dim pasturas As Integer = 0
            Dim extetereo As Integer = 0
            Dim nida As Integer = 0
            Dim micotoxinas As Integer = 0
            texto = ""
            If Not listanutricion Is Nothing Then
                If listanutricion.Count > 0 Then
                    For Each sn In listanutricion
                        texto = texto & " // " & sn.MUESTRA & " - "
                        If sn.MGA = 1 Then
                            texto = texto & "MGA - "
                        End If
                        If sn.MGB = 1 Then
                            texto = texto & "MGB - "
                        End If
                        If sn.ENSILADOS = 1 Then
                            texto = texto & "Ensilados - "
                        End If
                        If sn.PASTURAS = 1 Then
                            texto = texto & "Pasturas - "
                        End If
                        If sn.EXTETEREO = 1 Then
                            texto = texto & "Extracto etéreo - "
                        End If
                        If sn.NIDA = 1 Then
                            texto = texto & "NIDA - "
                        End If
                        If sn.MICOTOXINAS = 1 Then
                            texto = texto & "MICOTOXINAS - "
                        End If
                        If sn.AFLA = 1 Then
                            texto = texto & "AFLA - "
                        End If
                        If sn.DON = 1 Then
                            texto = texto & "DON - "
                        End If
                        If sn.ZEARA = 1 Then
                            texto = texto & "ZEARA - "
                        End If
                        If sn.PROTEINAS = 1 Then
                            texto = texto & "PROTEINAS - "
                        End If
                        If sn.FIBRANEUTRA = 1 Then
                            texto = texto & "FIBRA NEUTRA - "
                        End If
                        If sn.FIBRAACIDA = 1 Then
                            texto = texto & "FIBRA ÁCIDA - "
                        End If
                    Next

                End If
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES SUELOS ********************************************************************************
        ElseIf tipoinforme = "Suelos" Then
            Dim nitratos As Integer = 0
            Dim mineralizacion As Integer = 0
            Dim fosforobray As Integer = 0
            Dim fosforocitrico As Integer = 0
            Dim phagua As Integer = 0
            Dim phkci As Integer = 0
            Dim materiaorg As Integer = 0
            Dim potasioint As Integer = 0
            Dim sulfatos As Integer = 0
            Dim nitrogenovegetal As Integer = 0
            texto = ""
            If Not listasuelos Is Nothing Then
                If listasuelos.Count > 0 Then
                    For Each ss In listasuelos
                        texto = texto & " // " & ss.MUESTRA & " - "
                        If ss.PAQUETE = 1 Then
                            texto = texto & "Paquete 1 (Completo) - "
                        End If
                        If ss.PAQUETE = 2 Then
                            texto = texto & "Paquete 2 (Cultivos de verano) - "
                        End If
                        If ss.PAQUETE = 3 Then
                            texto = texto & "Paquete 3 (Cultivos de invierno) - "
                        End If
                        If ss.PAQUETE = 4 Then
                            texto = texto & "Paquete 4 (Cationes) - "
                        End If
                        If ss.PAQUETE = 5 Then
                            texto = texto & "Paquete 5 (Pastura) - "
                        End If
                        If ss.PAQUETE = 7 Then
                            texto = texto & "Paquete foliares (Fósforo y Potasio Total) "
                        End If
                        If ss.NITRATOS = 1 Then
                            texto = texto & "Nitratos - "
                        End If
                        If ss.MINERALIZACION = 1 Then
                            texto = texto & "Mineralización - "
                        End If
                        If ss.FOSFOROBRAY = 1 Then
                            texto = texto & "Fósforo Bray I - "
                        End If
                        If ss.FOSFOROCITRICO = 1 Then
                            texto = texto & "Fósforo Ac.Cítrico - "
                        End If
                        If ss.PHAGUA = 1 Then
                            texto = texto & "pH Agua - "
                        End If
                        If ss.PHKCI = 1 Then
                            texto = texto & "pH KCI - "
                        End If
                        If ss.MATERIAORG = 1 Then
                            texto = texto & "Materia orgánica - "
                        End If
                        If ss.POTASIOINT = 1 Then
                            texto = texto & "Potasio intercambiable - "
                        End If
                        If ss.SULFATOS = 1 Then
                            texto = texto & "Sulfatos - "
                        End If
                        If ss.NITROGENOVEGETAL = 1 Then
                            texto = texto & "Nitrógeno vegetal - "
                        End If
                        If ss.MAGNESIO = 1 Then
                            texto = texto & "Magnesio - "
                        End If
                        If ss.SODIO = 1 Then
                            texto = texto & "Sodio - "
                        End If
                        If ss.ACIDEZTITULABLE = 1 Then
                            texto = texto & "Acidez titulable - "
                        End If
                        If ss.CIC = 1 Then
                            texto = texto & "CIC - "
                        End If
                        If ss.SB = 1 Then
                            texto = texto & "% SB - "
                        End If
                        If ss.ZINC = 1 Then
                            texto = texto & "ZINC - "
                        End If
                    Next
                End If
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
        Else
            x1hoja.Range("A36", "G37").Merge()
            x1hoja.Range("A36", "G37").WrapText = True
            'x1hoja.Cells(fila, columna).Formula = texto
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 2
        End If
        '***********************************************************************************************
        'x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).formula = "-----------------------------------------------------------------------------"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Identificación de las muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '*** LISTADO DE MUESTRAS *********************************************************************************
        ' SI ES ALIMENTOS ********************************************************************************
        If tipoinforme = "Alimentos" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES AGUA ********************************************************************************
        ElseIf tipoinforme = "Agua" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES CALIDAD ********************************************************************************
        ElseIf tipoinforme = "Calidad de leche" Then
            texto2 = ""
            Dim cuenta_rb As Integer = 0
            Dim cuenta_rc As Integer = 0
            Dim cuenta_comp As Integer = 0
            Dim cuenta_compsuero As Integer = 0
            Dim cuenta_criosc As Integer = 0
            Dim cuenta_inhib As Integer = 0
            Dim cuenta_charm As Integer = 0
            Dim cuenta_espor As Integer = 0
            Dim cuenta_urea As Integer = 0
            Dim cuenta_termo As Integer = 0
            Dim cuenta_psicro As Integer = 0
            Dim cuenta_criosc_criosc As Integer = 0
            Dim cuenta_caseina As Integer = 0
            Dim cuenta_aflatoxinam1 As Integer = 0
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        texto2 = texto2 + csm.MUESTRA
                        If csm.RB = 1 Then
                            cuenta_rb = cuenta_rb + 1
                        End If
                        If csm.RC = 1 Then
                            cuenta_rc = cuenta_rc + 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            cuenta_comp = cuenta_comp + 1
                        End If
                        If csm.COMPOSICIONSUERO = 1 Then
                            cuenta_compsuero = cuenta_compsuero + 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            cuenta_criosc = cuenta_criosc + 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            cuenta_inhib = cuenta_inhib + 1
                        End If
                        If csm.CHARM = 1 Then
                            cuenta_charm = cuenta_charm + 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            cuenta_espor = cuenta_espor + 1
                        End If
                        If csm.UREA = 1 Then
                            cuenta_urea = cuenta_urea + 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            cuenta_termo = cuenta_termo + 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            cuenta_psicro = cuenta_psicro + 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            cuenta_criosc_criosc = cuenta_criosc_criosc + 1
                        End If
                        If csm.CASEINA = 1 Then
                            cuenta_caseina = cuenta_caseina + 1
                        End If
                        If csm.AFLATOXINA = 1 Then
                            cuenta_aflatoxinam1 = cuenta_aflatoxinam1 + 1
                        End If
                        texto2 = texto2 + " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G43").Merge()
            x1hoja.Range("A40", "G43").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            If cuenta_rb > 0 Then
                texto3 = texto3 & cuenta_rb & " RB - "
            End If
            If cuenta_rc > 0 Then
                texto3 = texto3 & cuenta_rc & " RC - "
            End If
            If cuenta_comp > 0 Then
                texto3 = texto3 & cuenta_comp & " Comp. - "
            End If
            If cuenta_compsuero > 0 Then
                texto3 = texto3 & cuenta_compsuero & " Comp. suero - "
            End If
            If cuenta_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc & " Criosc. - "
            End If
            If cuenta_inhib > 0 Then
                texto3 = texto3 & cuenta_inhib & " Inhib. - "
            End If
            If cuenta_charm > 0 Then
                texto3 = texto3 & cuenta_charm & " Charm - "
            End If
            If cuenta_espor > 0 Then
                texto3 = texto3 & cuenta_espor & " Espor. - "
            End If
            If cuenta_urea > 0 Then
                texto3 = texto3 & cuenta_urea & " Urea - "
            End If
            If cuenta_termo > 0 Then
                texto3 = texto3 & cuenta_termo & " Termof. - "
            End If
            If cuenta_psicro > 0 Then
                texto3 = texto3 & cuenta_psicro & " Psicro. - "
            End If
            If cuenta_criosc_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc_criosc & " Criosc.(Crióscopo) - "
            End If
            If cuenta_caseina > 0 Then
                texto3 = texto3 & cuenta_caseina & " Caseina - "
            End If
            If cuenta_aflatoxinam1 > 0 Then
                texto3 = texto3 & cuenta_aflatoxinam1 & " Aflatoxina M1 - "
            End If
            fila = fila + 4
            'x1hoja.Range("A45", "G46").Merge()
            'x1hoja.Range("A45", "G46").WrapText = True
            x1hoja.Cells(fila, columna).Formula = "Total: " + texto3
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 1
            ' SI ES CONTROL LECHERO ********************************************************************************
        ElseIf tipoinforme = "Control Lechero" Then
            texto2 = ""
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES ANTIBIOGRAMA ********************************************************************************
        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES AMBIENTAL ********************************************************************************
        ElseIf tipoinforme = "Ambiental" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES PARASITOLOGÍA ********************************************************************************
        ElseIf tipoinforme = "Parasitología" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES PAL ********************************************************************************
        ElseIf tipoinforme = "PAL" Then
            texto2 = ""
            If Not lista10 Is Nothing Then
                If lista10.Count > 0 Then
                    For Each spal In lista10
                        texto2 = texto2 + spal.MATRICULA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            Dim solpal As New dSolicitudPAL
            solpal.FICHA = ficha
            solpal = solpal.buscar
            If Not solpal Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = "Vacas: " & solpal.VACAS & " - " & "Fecha extracción: " & solpal.FECHAEXT
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
            End If
            '********************************************************************************************************************
            ' SI ES BRUCELOSIS LECHE ********************************************************************************
        ElseIf tipoinforme = "Brucelosis en leche" Then
            texto2 = ""
            If Not listabl Is Nothing Then
                If listabl.Count > 0 Then
                    For Each sm In listabl
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
        ElseIf tipoinforme = "Nutrición" Then
            fila = fila + 5
        ElseIf tipoinforme = "Suelos" Then
            fila = fila + 5
        Else
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
        End If
        '********************************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Observaciones:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = observaciones
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2
        'x1hoja.Cells(fila, columna).formula = "En nuestro sitio web http://www.colaveco.com.uy/gestor, puede descargar los resultados, solicite usuario y contraseña."
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 10
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "COLAVECO - Parque El Retiro - Nueva Helvecia - Tel/Fax: 45545311/45545975/45546838"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Email: colaveco@gmail.com - web: http://www.colaveco.com.uy"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Cuando el cliente solicite suspender el servicio ya presupuestado y en ejecución, o una parte del mismo,"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "los costos de las actividades ya realizadas en el momento de la suspensión deberán pagarse."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Los resultados de este análisis pueden ser utilizados y/o publicados por COLAVECO, con fines"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "científicos, protegiendo la confidencialidad del cliente."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True

        If Not dm Is Nothing Then
            If dm.IDINFORETORNO = 1 Then
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Autorizo a procesar las muestras a pesar de no cumplir con las condiciones establecidas en el PG.LAB.01"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
            End If
        End If

        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "FIRMA DEL CLIENTE / ACLARACIÓN: _____________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        'x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        x1hoja.SaveAs("\\192.168.1.10\E\NET\TICKET_CLIENTES\TC" & ficha & ".xls")
        x1app.Visible = False
        x1libro.Close()
        'x1libro.PrintPreview()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub imprimir_ticket2_cliente()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)
        Dim ficha As String = TextId.Text.Trim
        Dim fecha As Date = DateFechaIngreso.Value
        Dim nmuestras As String
        If TextNMuestras.Text <> "" Then
            nmuestras = TextNMuestras.Text.Trim
        Else
            nmuestras = ""
        End If
        Dim muestra As String = ComboMuestra.Text
        Dim solicitud As String = ""
        Dim texto As String = ""
        Dim texto2 As String = ""
        Dim texto3 As String = ""
        Dim usucontra As String = ""
        'Poner Titulos
        'x1hoja.Shapes.AddPicture("c:\Debug\encabezado_ticket.jpg", _
        ' Microsoft.Office.Core.MsoTriState.msoFalse, _
        ' Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 418, 55)
        ''x1hoja.Shapes.AddPicture("c:\Debug\logo.jpg", _
        '' Microsoft.Office.Core.MsoTriState.msoFalse, _
        '' Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 80, 35)
        Dim tipoinforme As String = ComboTipoInforme.Text
        Dim subtipoinforme As String = ComboSubInforme.Text
        Dim observaciones As String = TextObservaciones.Text.Trim
        Dim fila = 1
        Dim columna = 5
        x1hoja.Cells(fila, columna).formula = "RG.ADM.54 v02 06/06/18"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = 2
        columna = 1
        columna = columna + 2
        x1hoja.Cells(fila, columna).formula = "Solicitud de análisis"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Ficha:" & " " & TextId.Text
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Realizada por:" & " " & Usuario.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Fecha/Hora de recepción:" & " " & fecha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        'fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Muestras:" & " " & nmuestras
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        Dim pro As New dCliente
        Dim nombre_productor As String = ""
        Dim idproductor As Long = 0
        pro.ID = TextIdProductor.Text.Trim
        pro = pro.buscar
        If Not pro Is Nothing Then
            nombre_productor = pro.NOMBRE
            usucontra = pro.USUARIO_WEB
            idproductor = pro.ID
        Else
            nombre_productor = ""
        End If
        x1hoja.Cells(fila, columna).formula = "Cliente:" & " " & nombre_productor & " " & "(" & idproductor & ")"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Muestra de:" & " " & muestra
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        'x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).formula = "-----------------------------------------------------------------------------"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        Dim sm As New dRelSolicitudMuestras
        Dim spal As New dSolicitudPAL
        Dim csm As New dCalidadSolicitudMuestra
        Dim cs As New dControlSolicitud
        Dim a2 As New dAntibiograma2
        Dim sn As New dSolicitudNutricion
        Dim ss As New dSolicitudSuelos
        Dim bl As New dBrucelosis
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim lista4 As New ArrayList
        Dim lista5 As New ArrayList
        Dim lista6 As New ArrayList
        Dim lista7 As New ArrayList
        Dim lista10 As New ArrayList
        Dim listabl As New ArrayList
        Dim listanutricion As New ArrayList
        Dim listasuelos As New ArrayList
        Dim cajas As String = ""
        Dim gradillas As String = ""
        Dim otros As String = ""
        lista4 = sm.listarporficha(ficha)
        lista5 = csm.listarporsolicitud3(ficha)
        lista6 = cs.listarporsolicitud(ficha)
        lista7 = a2.listarporsolicitud(ficha)
        lista10 = spal.listarporsolicitud(ficha)
        listanutricion = sn.listarporsolicitud(ficha)
        listasuelos = ss.listarporsolicitud(ficha)
        listabl = sm.listarporficha(ficha)
        x1hoja.Cells(fila, columna).formula = "Análisis requerido: " & tipoinforme & " // " & "Subinforme:" & " " & subtipoinforme
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '***  LISTADO DE ANALISIS REQUERIDOS *********************************************************************
        ' SI ES ALIMENTOS ********************************************************************************
        If tipoinforme = "Alimentos" Then
            Dim sp As New dSubproducto
            Dim lista As New ArrayList
            texto = ""
            lista = sp.listarporsolicitud(ficha)
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each sp In lista
                        texto = ""
                        If sp.ESTAFCOAGPOSITIVO = 1 Then
                            texto = texto + " - Estaf. Coag. Positivo"
                        End If
                        If sp.CF = 1 Then
                            texto = texto + " - CF"
                        End If
                        If sp.MOHOSYLEVADURAS = 1 Then
                            texto = texto + " - Mohos y levaduras"
                        End If
                        If sp.CT = 1 Then
                            texto = texto + " - Coliformes Totales"
                        End If
                        If sp.ECOLI = 1 Then
                            texto = texto + " - E. Coli"
                        End If
                        If sp.SALMONELLA = 1 Then
                            texto = texto + " - Salmonella"
                        End If
                        If sp.LISTERIASPP = 1 Then
                            texto = texto + " - Listeria spp"
                        End If
                        If sp.HUMEDAD = 1 Then
                            texto = texto + " - Humedad"
                        End If
                        If sp.MGRASA = 1 Then
                            texto = texto + " - M. Grasa"
                        End If
                        If sp.PH = 1 Then
                            texto = texto + " - pH"
                        End If
                        If sp.CLORUROS = 1 Then
                            texto = texto + " - Cloruros"
                        End If
                        If sp.PROTEINAS = 1 Then
                            texto = texto + " - Proteínas"
                        End If
                        If sp.ENTEROBACTERIAS = 1 Then
                            texto = texto + " - Enterobacterias"
                        End If
                        If sp.LISTERIAAMBIENTAL = 1 Then
                            texto = texto + " - Listeria Ambiental"
                        End If
                        If sp.ESPORANAERMESOFILO = 1 Then
                            texto = texto + " - Espor. Anaer. Mesófilos"
                        End If
                        If sp.TERMOFILOS = 1 Then
                            texto = texto + " - Termodúricos"
                        End If
                        If sp.PSICROTROFOS = 1 Then
                            texto = texto + " - Psicrótrofos"
                        End If
                        If sp.RB = 1 Then
                            texto = texto + " - RB"
                        End If
                        If sp.TABLANUTRICIONAL = 1 Then
                            texto = texto + " - Tabla nutricional"
                        End If
                        If sp.LISTERIAMONOCITOGENES = 1 Then
                            texto = texto + " - Listeria monocitógenes"
                        End If
                        If sp.CENIZAS = 1 Then
                            texto = texto + " - Cenizas"
                        End If
                        If sp.LISTERIAPOOL = 1 Then
                            texto = texto + " - Pool de Listeria"
                        End If
                        If sp.SALMONELLAPOOL = 1 Then
                            texto = texto + " - Pool de Salmonella"
                        End If
                    Next
                End If
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES AGUA ********************************************************************************
        ElseIf tipoinforme = "Agua" Then
            Dim a1 As New dAgua
            texto = ""
            a1.ID = ficha
            a1 = a1.buscar()
            texto = ComboSubInforme.Text
            If a1.HET22 = 1 Then
                texto = texto & " " & " - Heterotróficos 22"
            End If
            If a1.HET35 = 1 Then
                texto = texto & " " & " - Heterotróficos 35"
            End If
            If a1.HET37 = 1 Then
                texto = texto & " " & " - Heterotróficos 37"
            End If
            If a1.CLORO = 1 Then
                texto = texto & " " & " - Cloro"
            End If
            If a1.CONDUCTIVIDAD = 1 Then
                texto = texto & " " & " - Conductividad"
            End If
            If a1.PH = 1 Then
                texto = texto & " " & " - pH"
            End If
            If a1.ECOLI = 1 Then
                texto = texto & " " & " - Ecoli"
            End If
            If a1.SULFITOREDUCTORES = 1 Then
                texto = texto & " " & " - Sulfito reductores"
            End If
            If a1.ENTEROCOCOS = 1 Then
                texto = texto & " " & " - Enterococos"
            End If
            If a1.ESTREPTOCOCOS = 1 Then
                texto = texto & " " & " - Estreptococos"
            End If
            If a1.PAQMACRO = 1 Then
                texto = texto & " " & " - Paq. Macroelementos "
            End If
            If a1.ALCALINIDAD = 1 Then
                texto = texto & " " & " - Alcalinidad "
            End If
            If a1.CA = 1 Then
                texto = texto & " " & "+ Ca "
            End If
            If a1.MG = 1 Then
                texto = texto & " " & "+ Mg "
            End If
            If a1.NA = 1 Then
                texto = texto & " " & "+ Na "
            End If
            If a1.FE = 1 Then
                texto = texto & " " & "+ Fe "
            End If
            If a1.K = 1 Then
                texto = texto & " " & "+ K "
            End If
            If a1.AL = 1 Then
                texto = texto & " " & "+ Al "
            End If
            If a1.CD = 1 Then
                texto = texto & " " & "+ Cd "
            End If
            If a1.CR = 1 Then
                texto = texto & " " & "+ Cr "
            End If
            If a1.CU = 1 Then
                texto = texto & " " & "+ Cu "
            End If
            If a1.PB = 1 Then
                texto = texto & " " & "+ Pb "
            End If
            If a1.MN = 1 Then
                texto = texto & " " & "+ Mn "
            End If
            If a1.FE = 1 Then
                texto = texto & " " & "+ fe "
            End If
            If a1.ZN = 1 Then
                texto = texto & " " & "+ Zn "
            End If
            If a1.SE = 1 Then
                texto = texto & " " & "+ Se "
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES CALIDAD DE LECHE ********************************************************************************
        ElseIf tipoinforme = "Calidad de leche" Then
            Dim rb As Integer = 0
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim compsuero As Integer = 0
            Dim criosc As Integer = 0
            Dim inh As Integer = 0
            Dim charm As Integer = 0
            Dim espor As Integer = 0
            Dim urea As Integer = 0
            Dim term As Integer = 0
            Dim psicr As Integer = 0
            Dim crioscopo As Integer = 0
            Dim aflatoxinam1 As Integer = 0
            Dim caseina As Integer = 0
            texto = ""
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        If csm.RB = 1 Then
                            rb = 1
                        End If
                        If csm.RC = 1 Then
                            rc = 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If csm.COMPOSICIONSUERO = 1 Then
                            compsuero = 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            criosc = 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            inh = 1
                        End If
                        If csm.CHARM = 1 Then
                            charm = 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            espor = 1
                        End If
                        If csm.UREA = 1 Then
                            urea = 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            term = 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            psicr = 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            crioscopo = 1
                        End If
                        If csm.AFLATOXINA = 1 Then
                            aflatoxinam1 = 1
                        End If
                        If csm.CASEINA = 1 Then
                            caseina = 1
                        End If
                    Next
                End If
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If compsuero = 1 Then
                texto = texto + " - Composición suero"
            End If
            If criosc = 1 Then
                texto = texto + " - Crioscopía"
            End If
            If inh = 1 Then
                texto = texto + " - Inhibidores"
            End If
            If charm = 1 Then
                texto = texto + " - Charm"
            End If
            If espor = 1 Then
                texto = texto + " - Esporulados"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If term = 1 Then
                texto = texto + " - Termófilos"
            End If
            If psicr = 1 Then
                texto = texto + " - Psicrótrofos"
            End If
            If crioscopo = 1 Then
                texto = texto + " - Crioscopía (crióscopo)"
            End If
            If aflatoxinam1 = 1 Then
                texto = texto + " - Aflatoxina M1"
            End If
            If caseina = 1 Then
                texto = texto + " - Caseína"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES CONTROL LECHERO ********************************************************************************
        ElseIf tipoinforme = "Control Lechero" Then
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim urea As Integer = 0
            Dim caseina As Integer = 0
            texto = ""
            If Not lista6 Is Nothing Then
                If lista6.Count > 0 Then
                    For Each cs In lista6
                        If cs.RC = 1 Then
                            rc = 1
                        End If
                        If cs.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If cs.UREA = 1 Then
                            urea = 1
                        End If
                        If cs.CASEINA = 1 Then
                            caseina = 1
                        End If
                    Next
                End If
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If caseina = 1 Then
                texto = texto + " - Caseina"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ANTIBIOGRAMA ********************************************************************************
        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            Dim aislamiento As Integer = 0
            Dim antibiograma As Integer = 0
            texto = ""
            If Not lista7 Is Nothing Then
                If lista7.Count > 0 Then
                    For Each a2 In lista7
                        If a2.AISLAMIENTO = 1 Then
                            aislamiento = 1
                        End If
                        If a2.ANTIBIOGRAMA = 1 Then
                            antibiograma = 1
                        End If
                    Next
                End If
            End If
            If aislamiento = 1 Then
                texto = texto + " - Aislamiento"
            End If
            If antibiograma = 1 Then
                texto = texto + " - Antibiograma"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES AMBIENTAL ********************************************************************************
        ElseIf tipoinforme = "Ambiental" Then
            Dim ambs As New dAmbientalSolicitud
            Dim lista8 As ArrayList
            lista8 = ambs.listarporsolicitud(ficha)
            Dim enterobacterias As Integer = 0
            Dim listambiental As Integer = 0
            Dim listmono As Integer = 0
            Dim salmonella As Integer = 0
            Dim ecoli As Integer = 0
            Dim mohosylevaduras As Integer = 0
            Dim rb As Integer = 0
            Dim ct As Integer = 0
            Dim cf As Integer = 0
            Dim pseudomonaspp As Integer = 0
            Dim listeriaspp As Integer = 0
            texto = ""
            If Not lista8 Is Nothing Then
                If lista8.Count > 0 Then
                    For Each ambs In lista8
                        If ambs.ENTEROBACTERIAS = 1 Then
                            enterobacterias = 1
                        End If
                        If ambs.LISTAMBIENTAL = 1 Then
                            listambiental = 1
                        End If
                        If ambs.LISTMONO = 1 Then
                            listmono = 1
                        End If
                        If ambs.SALMONELLA = 1 Then
                            salmonella = 1
                        End If
                        If ambs.ECOLI = 1 Then
                            ecoli = 1
                        End If
                        If ambs.MOHOSYLEVADURAS = 1 Then
                            mohosylevaduras = 1
                        End If
                        If ambs.RB = 1 Then
                            rb = 1
                        End If
                        If ambs.CT = 1 Then
                            ct = 1
                        End If
                        If ambs.CF = 1 Then
                            cf = 1
                        End If
                        If ambs.PSEUDOMONASPP = 1 Then
                            pseudomonaspp = 1
                        End If
                        If ambs.LISTSPP = 1 Then
                            listeriaspp = 1
                        End If
                    Next
                End If
            End If
            If enterobacterias = 1 Then
                texto = texto + " - Enterobacterias"
            End If
            If listambiental = 1 Then
                texto = texto + " - Listeria ambiental"
            End If
            If listmono = 1 Then
                texto = texto + " - Listeria monocitógenes"
            End If
            If salmonella = 1 Then
                texto = texto + " - Salmonella"
            End If
            If ecoli = 1 Then
                texto = texto + " - E. Coli"
            End If
            If mohosylevaduras = 1 Then
                texto = texto + " - Mohos y levaduras"
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If ct = 1 Then
                texto = texto + " - Coliformes totales"
            End If
            If cf = 1 Then
                texto = texto + " - CF"
            End If
            If pseudomonaspp = 1 Then
                texto = texto + " - Pseudomona spp"
            End If
            If listeriaspp = 1 Then
                texto = texto + " - Listeria spp"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES PARASITOLOGÍA ********************************************************************************
        ElseIf tipoinforme = "Parasitología" Then
            Dim p As New dParasitologiaSolicitud
            Dim lista9 As ArrayList
            lista9 = p.listarporsolicitud(ficha)
            Dim gastrointestinales As Integer = 0
            Dim fasciola As Integer = 0
            Dim coccidias As Integer = 0
            texto = ""
            If Not lista9 Is Nothing Then
                If lista9.Count > 0 Then
                    For Each p In lista9
                        If p.GASTROINTESTINALES = 1 Then
                            gastrointestinales = 1
                        End If
                        If p.FASCIOLA = 1 Then
                            fasciola = 1
                        End If
                        If p.COCCIDIAS = 1 Then
                            coccidias = 1
                        End If
                    Next
                End If
            End If
            If gastrointestinales = 1 Then
                texto = texto + " - Gastrointestinales"
            End If
            If fasciola = 1 Then
                texto = texto + " - Fasciola"
            End If
            If coccidias = 1 Then
                texto = texto + " - Coccidias"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES NUTRICIÓN ********************************************************************************
        ElseIf tipoinforme = "Nutrición" Then
            Dim mga As Integer = 0
            Dim mgb As Integer = 0
            Dim ensilados As Integer = 0
            Dim pasturas As Integer = 0
            Dim extetereo As Integer = 0
            Dim nida As Integer = 0
            Dim micotoxinas As Integer = 0
            texto = ""
            If Not listanutricion Is Nothing Then
                If listanutricion.Count > 0 Then
                    For Each sn In listanutricion
                        texto = texto & " // " & sn.MUESTRA & " - "
                        If sn.MGA = 1 Then
                            texto = texto & "MGA - "
                        End If
                        If sn.MGB = 1 Then
                            texto = texto & "MGB - "
                        End If
                        If sn.ENSILADOS = 1 Then
                            texto = texto & "Ensilados - "
                        End If
                        If sn.PASTURAS = 1 Then
                            texto = texto & "Pasturas - "
                        End If
                        If sn.EXTETEREO = 1 Then
                            texto = texto & "Extracto etéreo - "
                        End If
                        If sn.NIDA = 1 Then
                            texto = texto & "NIDA - "
                        End If
                        If sn.MICOTOXINAS = 1 Then
                            texto = texto & "MICOTOXINAS - "
                        End If
                        If sn.AFLA = 1 Then
                            texto = texto & "AFLA - "
                        End If
                        If sn.DON = 1 Then
                            texto = texto & "DON - "
                        End If
                        If sn.ZEARA = 1 Then
                            texto = texto & "ZEARA - "
                        End If
                        If sn.PROTEINAS = 1 Then
                            texto = texto & "PROTEINAS - "
                        End If
                        If sn.MATERIASECA = 1 Then
                            texto = texto & "MATERIA SECA - "
                        End If
                        If sn.FIBRANEUTRA = 1 Then
                            texto = texto & "FIBRA NEUTRA - "
                        End If
                        If sn.FIBRAACIDA = 1 Then
                            texto = texto & "FIBRA ÁCIDA - "
                        End If
                        If sn.PH = 1 Then
                            texto = texto & "pH - "
                        End If
                    Next
                End If
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES SUELOS ********************************************************************************
        ElseIf tipoinforme = "Suelos" Then
            Dim nitratos As Integer = 0
            Dim mineralizacion As Integer = 0
            Dim fosforobray As Integer = 0
            Dim fosforocitrico As Integer = 0
            Dim phagua As Integer = 0
            Dim phkci As Integer = 0
            Dim materiaorg As Integer = 0
            Dim potasioint As Integer = 0
            Dim sulfatos As Integer = 0
            Dim nitrogenovegetal As Integer = 0
            texto = ""
            If Not listasuelos Is Nothing Then
                If listasuelos.Count > 0 Then
                    For Each ss In listasuelos
                        texto = texto & " // " & ss.MUESTRA & " - "
                        If ss.PAQUETE = 1 Then
                            texto = texto & "Paquete 1 (Completo) - "
                        End If
                        If ss.PAQUETE = 2 Then
                            texto = texto & "Paquete 2 (Cultivos de verano) - "
                        End If
                        If ss.PAQUETE = 3 Then
                            texto = texto & "Paquete 3 (Cultivos de invierno) - "
                        End If
                        If ss.PAQUETE = 4 Then
                            texto = texto & "Paquete 4 (Cationes) - "
                        End If
                        If ss.PAQUETE = 5 Then
                            texto = texto & "Paquete 5 (Pastura) - "
                        End If
                        If ss.PAQUETE = 7 Then
                            texto = texto & "Paquete foliares (Fósforo y Potasio Total) "
                        End If
                        If ss.NITRATOS = 1 Then
                            texto = texto & "Nitratos - "
                        End If
                        If ss.MINERALIZACION = 1 Then
                            texto = texto & "Mineralización - "
                        End If
                        If ss.FOSFOROBRAY = 1 Then
                            texto = texto & "Fósforo Bray I - "
                        End If
                        If ss.FOSFOROCITRICO = 1 Then
                            texto = texto & "Fósforo Ac.Cítrico - "
                        End If
                        If ss.PHAGUA = 1 Then
                            texto = texto & "pH Agua - "
                        End If
                        If ss.PHKCI = 1 Then
                            texto = texto & "pH KCI - "
                        End If
                        If ss.MATERIAORG = 1 Then
                            texto = texto & "Materia orgánica - "
                        End If
                        If ss.POTASIOINT = 1 Then
                            texto = texto & "Potasio intercambiable - "
                        End If
                        If ss.SULFATOS = 1 Then
                            texto = texto & "Sulfatos - "
                        End If
                        If ss.NITROGENOVEGETAL = 1 Then
                            texto = texto & "Nitrógeno vegetal - "
                        End If
                        If ss.MAGNESIO = 1 Then
                            texto = texto & "Magnesio - "
                        End If
                        If ss.SODIO = 1 Then
                            texto = texto & "Sodio - "
                        End If
                        If ss.ACIDEZTITULABLE = 1 Then
                            texto = texto & "Acidez titulable - "
                        End If
                        If ss.CIC = 1 Then
                            texto = texto & "CIC - "
                        End If
                        If ss.SB = 1 Then
                            texto = texto & "% SB - "
                        End If
                        If ss.ZINC = 1 Then
                            texto = texto & "ZINC - "
                        End If
                    Next
                End If
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A9", "G10").Merge()
                x1hoja.Range("A9", "G10").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
        Else
            x1hoja.Range("A9", "G10").Merge()
            x1hoja.Range("A9", "G10").WrapText = True
            'x1hoja.Cells(fila, columna).Formula = texto
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 2
        End If
        '***********************************************************************************************
        'x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).formula = "-----------------------------------------------------------------------------"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Identificación de las muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '*** LISTADO DE MUESTRAS *********************************************************************************
        ' SI ES ALIMENTOS ********************************************************************************
        If tipoinforme = "Alimentos" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES AGUA ********************************************************************************
        ElseIf tipoinforme = "Agua" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES CALIDAD ********************************************************************************
        ElseIf tipoinforme = "Calidad de leche" Then
            texto2 = ""
            Dim cuenta_rb As Integer = 0
            Dim cuenta_rc As Integer = 0
            Dim cuenta_comp As Integer = 0
            Dim cuenta_compsuero As Integer = 0
            Dim cuenta_criosc As Integer = 0
            Dim cuenta_inhib As Integer = 0
            Dim cuenta_charm As Integer = 0
            Dim cuenta_espor As Integer = 0
            Dim cuenta_urea As Integer = 0
            Dim cuenta_termo As Integer = 0
            Dim cuenta_psicro As Integer = 0
            Dim cuenta_criosc_criosc As Integer = 0
            Dim cuenta_caseina As Integer = 0
            Dim cuenta_aflatoxinam1 As Integer = 0
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        texto2 = texto2 + csm.MUESTRA
                        If csm.RB = 1 Then
                            cuenta_rb = cuenta_rb + 1
                        End If
                        If csm.RC = 1 Then
                            cuenta_rc = cuenta_rc + 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            cuenta_comp = cuenta_comp + 1
                        End If
                        If csm.COMPOSICIONSUERO = 1 Then
                            cuenta_compsuero = cuenta_compsuero + 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            cuenta_criosc = cuenta_criosc + 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            cuenta_inhib = cuenta_inhib + 1
                        End If
                        If csm.CHARM = 1 Then
                            cuenta_charm = cuenta_charm + 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            cuenta_espor = cuenta_espor + 1
                        End If
                        If csm.UREA = 1 Then
                            cuenta_urea = cuenta_urea + 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            cuenta_termo = cuenta_termo + 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            cuenta_psicro = cuenta_psicro + 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            cuenta_criosc_criosc = cuenta_criosc_criosc + 1
                        End If
                        If csm.CASEINA = 1 Then
                            cuenta_caseina = cuenta_caseina + 1
                        End If
                        If csm.AFLATOXINA = 1 Then
                            cuenta_aflatoxinam1 = cuenta_aflatoxinam1 + 1
                        End If
                        texto2 = texto2 + " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G16").Merge()
            x1hoja.Range("A13", "G16").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            If cuenta_rb > 0 Then
                texto3 = texto3 & cuenta_rb & " RB - "
            End If
            If cuenta_rc > 0 Then
                texto3 = texto3 & cuenta_rc & " RC - "
            End If
            If cuenta_comp > 0 Then
                texto3 = texto3 & cuenta_comp & " Comp. - "
            End If
            If cuenta_compsuero > 0 Then
                texto3 = texto3 & cuenta_compsuero & " Comp. suero - "
            End If
            If cuenta_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc & " Criosc. - "
            End If
            If cuenta_inhib > 0 Then
                texto3 = texto3 & cuenta_inhib & " Inhib. - "
            End If
            If cuenta_charm > 0 Then
                texto3 = texto3 & cuenta_charm & " Charm - "
            End If
            If cuenta_espor > 0 Then
                texto3 = texto3 & cuenta_espor & " Espor. - "
            End If
            If cuenta_urea > 0 Then
                texto3 = texto3 & cuenta_urea & " Urea - "
            End If
            If cuenta_termo > 0 Then
                texto3 = texto3 & cuenta_termo & " Termof. - "
            End If
            If cuenta_psicro > 0 Then
                texto3 = texto3 & cuenta_psicro & " Psicro. - "
            End If
            If cuenta_criosc_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc_criosc & " Criosc.(Crióscopo) - "
            End If
            If cuenta_caseina > 0 Then
                texto3 = texto3 & cuenta_caseina & " Caseina - "
            End If
            If cuenta_aflatoxinam1 > 0 Then
                texto3 = texto3 & cuenta_aflatoxinam1 & " Aflatoxina M1 - "
            End If
            fila = fila + 4
            'x1hoja.Range("A27", "G28").Merge()
            'x1hoja.Range("A27", "G28").WrapText = True
            x1hoja.Cells(fila, columna).Formula = "Total: " + texto3
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 1
            ' SI ES CONTROL LECHERO ********************************************************************************
        ElseIf tipoinforme = "Control Lechero" Then
            texto2 = ""
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES ANTIBIOGRAMA ********************************************************************************
        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES AMBIENTAL ********************************************************************************
        ElseIf tipoinforme = "Ambiental" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES PARASITOLOGÍA ********************************************************************************
        ElseIf tipoinforme = "Parasitología" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            ' SI ES PAL ********************************************************************************
        ElseIf tipoinforme = "PAL" Then
            texto2 = ""
            If Not lista10 Is Nothing Then
                If lista10.Count > 0 Then
                    For Each spal In lista10
                        texto2 = texto2 + spal.MATRICULA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
            Dim solpal As New dSolicitudPAL
            solpal.FICHA = ficha
            solpal = solpal.buscar
            If Not solpal Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = "Vacas: " & solpal.VACAS & " - " & "Fecha extracción: " & solpal.FECHAEXT
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
            End If
            '********************************************************************************************************************
            ' SI ES BRUCELOSIS LECHE ********************************************************************************
        ElseIf tipoinforme = "Brucelosis en leche" Then
            texto2 = ""
            If Not listabl Is Nothing Then
                If listabl.Count > 0 Then
                    For Each sm In listabl
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
        ElseIf tipoinforme = "Nutrición" Then
            fila = fila + 5
        ElseIf tipoinforme = "Suelos" Then
            fila = fila + 5
        Else
            x1hoja.Range("A13", "G17").Merge()
            x1hoja.Range("A13", "G17").WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
        End If
        '********************************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Observaciones:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1

        Dim dm As New dDescarteMuestras
        dm.FICHA = ficha
        dm = dm.buscarxficha
        If Not dm Is Nothing Then
            If dm.IDINFORETORNO = 1 Then
                observaciones = observaciones & " * Muestras fuera de condición."
            End If
        End If


        x1hoja.Cells(fila, columna).formula = observaciones
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "IMPORTANTE"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Ud. puede descargar los resultados desde nuestra web, solicite usuario y contraseña"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Usuario y contraseña: " & usucontra
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Recuerde que los resultados quedan habilitados si el cliente no tiene facturas vencidas."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Si tiene dificultades para obtener los resultados, comunicarse al 4554 5311 /5975/6838"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "o vía mail a colaveco@gmail.com (Horario de atención al público L a V de 8 a 17 Hs."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        ' SEGUNDA COPIA *************************************************************************************************************************************
        fila = fila + 2
        columna = 5
        x1hoja.Cells(fila, columna).formula = "RG.ADM.54 v02 06/06/18"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1
        columna = columna + 2
        x1hoja.Cells(fila, columna).formula = "Solicitud de análisis"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Ficha:" & " " & TextId.Text
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Realizada por:" & " " & Usuario.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Fecha/Hora de recepción:" & " " & fecha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        'fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Muestras:" & " " & nmuestras
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        If Not pro Is Nothing Then
            nombre_productor = pro.NOMBRE
        Else
            nombre_productor = ""
        End If
        x1hoja.Cells(fila, columna).formula = "Cliente:" & " " & nombre_productor
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Muestra de:" & " " & muestra
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        'x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).formula = "-----------------------------------------------------------------------------"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Análisis requerido: " & tipoinforme & " // " & "Subinforme:" & " " & subtipoinforme
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '***  LISTADO DE ANALISIS REQUERIDOS *********************************************************************
        ' SI ES ALIMENTOS ********************************************************************************
        If tipoinforme = "Alimentos" Then
            Dim sp As New dSubproducto
            Dim lista As New ArrayList
            texto = ""
            lista = sp.listarporsolicitud(ficha)
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each sp In lista
                        texto = ""
                        If sp.ESTAFCOAGPOSITIVO = 1 Then
                            texto = texto + " - Estaf. Coag. Positivo"
                        End If
                        If sp.CF = 1 Then
                            texto = texto + " - CF"
                        End If
                        If sp.MOHOSYLEVADURAS = 1 Then
                            texto = texto + " - Mohos y levaduras"
                        End If
                        If sp.CT = 1 Then
                            texto = texto + " - Coliformes Totales"
                        End If
                        If sp.ECOLI = 1 Then
                            texto = texto + " - E. Coli"
                        End If
                        If sp.SALMONELLA = 1 Then
                            texto = texto + " - Salmonella"
                        End If
                        If sp.LISTERIASPP = 1 Then
                            texto = texto + " - Listeria spp"
                        End If
                        If sp.HUMEDAD = 1 Then
                            texto = texto + " - Humedad"
                        End If
                        If sp.MGRASA = 1 Then
                            texto = texto + " - M. Grasa"
                        End If
                        If sp.PH = 1 Then
                            texto = texto + " - pH"
                        End If
                        If sp.CLORUROS = 1 Then
                            texto = texto + " - Cloruros"
                        End If
                        If sp.PROTEINAS = 1 Then
                            texto = texto + " - Proteínas"
                        End If
                        If sp.ENTEROBACTERIAS = 1 Then
                            texto = texto + " - Enterobacterias"
                        End If
                        If sp.LISTERIAAMBIENTAL = 1 Then
                            texto = texto + " - Listeria Ambiental"
                        End If
                        If sp.ESPORANAERMESOFILO = 1 Then
                            texto = texto + " - Espor. Anaer. Mesófilos"
                        End If
                        If sp.TERMOFILOS = 1 Then
                            texto = texto + " - Termodúricos"
                        End If
                        If sp.PSICROTROFOS = 1 Then
                            texto = texto + " - Psicrótrofos"
                        End If
                        If sp.RB = 1 Then
                            texto = texto + " - RB"
                        End If
                        If sp.TABLANUTRICIONAL = 1 Then
                            texto = texto + " - Tabla nutricional"
                        End If
                        If sp.LISTERIAMONOCITOGENES = 1 Then
                            texto = texto + " - Listeria monocitógenes"
                        End If
                        If sp.CENIZAS = 1 Then
                            texto = texto + " - Cenizas"
                        End If
                    Next
                End If
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES AGUA ********************************************************************************
        ElseIf tipoinforme = "Agua" Then
            Dim a1 As New dAgua
            texto = ""
            a1.ID = ficha
            a1 = a1.buscar()
            texto = ComboSubInforme.Text
            If a1.HET22 = 1 Then
                texto = texto & " " & " - Heterotróficos 22"
            End If
            If a1.HET35 = 1 Then
                texto = texto & " " & " - Heterotróficos 35"
            End If
            If a1.HET37 = 1 Then
                texto = texto & " " & " - Heterotróficos 37"
            End If
            If a1.CLORO = 1 Then
                texto = texto & " " & " - Cloro"
            End If
            If a1.CONDUCTIVIDAD = 1 Then
                texto = texto & " " & " - Conductividad"
            End If
            If a1.PH = 1 Then
                texto = texto & " " & " - pH"
            End If
            If a1.ECOLI = 1 Then
                texto = texto & " " & " - Ecoli"
            End If
            If a1.SULFITOREDUCTORES = 1 Then
                texto = texto & " " & " - Sulfito reductores"
            End If
            If a1.ENTEROCOCOS = 1 Then
                texto = texto & " " & " - Enterococos"
            End If
            If a1.ESTREPTOCOCOS = 1 Then
                texto = texto & " " & " - Estreptococos"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
            ' SI ES CALIDAD DE LECHE ********************************************************************************
        ElseIf tipoinforme = "Calidad de leche" Then
            Dim rb As Integer = 0
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim compsuero As Integer = 0
            Dim criosc As Integer = 0
            Dim inh As Integer = 0
            Dim charm As Integer = 0
            Dim espor As Integer = 0
            Dim urea As Integer = 0
            Dim term As Integer = 0
            Dim psicr As Integer = 0
            Dim crioscopo As Integer = 0
            Dim aflatoxinam1 As Integer = 0
            texto = ""
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        If csm.RB = 1 Then
                            rb = 1
                        End If
                        If csm.RC = 1 Then
                            rc = 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If csm.COMPOSICIONSUERO = 1 Then
                            compsuero = 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            criosc = 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            inh = 1
                        End If
                        If csm.CHARM = 1 Then
                            charm = 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            espor = 1
                        End If
                        If csm.UREA = 1 Then
                            urea = 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            term = 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            psicr = 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            crioscopo = 1
                        End If
                        If csm.AFLATOXINA = 1 Then
                            aflatoxinam1 = 1
                        End If
                    Next

                End If
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If compsuero = 1 Then
                texto = texto + " - Composición suero"
            End If
            If criosc = 1 Then
                texto = texto + " - Crioscopía"
            End If
            If inh = 1 Then
                texto = texto + " - Inhibidores"
            End If
            If charm = 1 Then
                texto = texto + " - Charm"
            End If
            If espor = 1 Then
                texto = texto + " - Esporulados"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If term = 1 Then
                texto = texto + " - Termófilos"
            End If
            If psicr = 1 Then
                texto = texto + " - Psicrótrofos"
            End If
            If crioscopo = 1 Then
                texto = texto + " - Crioscopía (crióscopo)"
            End If
            If aflatoxinam1 = 1 Then
                texto = texto + " - Aflatoxina M1"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If


            ' SI ES CONTROL LECHERO ********************************************************************************
        ElseIf tipoinforme = "Control Lechero" Then
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim urea As Integer = 0
            texto = ""
            If Not lista6 Is Nothing Then
                If lista6.Count > 0 Then
                    For Each cs In lista6
                        If cs.RC = 1 Then
                            rc = 1
                        End If
                        If cs.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If cs.UREA = 1 Then
                            urea = 1
                        End If
                    Next

                End If
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ANTIBIOGRAMA ********************************************************************************
        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            Dim aislamiento As Integer = 0
            Dim antibiograma As Integer = 0
            texto = ""
            If Not lista7 Is Nothing Then
                If lista7.Count > 0 Then
                    For Each a2 In lista7
                        If a2.AISLAMIENTO = 1 Then
                            aislamiento = 1
                        End If
                        If a2.ANTIBIOGRAMA = 1 Then
                            antibiograma = 1
                        End If
                    Next

                End If
            End If
            If aislamiento = 1 Then
                texto = texto + " - Aislamiento"
            End If
            If antibiograma = 1 Then
                texto = texto + " - Antibiograma"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ES AMBIENTAL ********************************************************************************
        ElseIf tipoinforme = "Ambiental" Then
            Dim ambs As New dAmbientalSolicitud
            Dim lista8 As ArrayList
            lista8 = ambs.listarporsolicitud(ficha)

            Dim enterobacterias As Integer = 0
            Dim listambiental As Integer = 0
            Dim listmono As Integer = 0
            Dim salmonella As Integer = 0
            Dim ecoli As Integer = 0
            Dim mohosylevaduras As Integer = 0
            Dim rb As Integer = 0
            Dim ct As Integer = 0
            Dim cf As Integer = 0
            Dim pseudomonaspp As Integer = 0
            Dim listeriaspp As Integer = 0
            texto = ""
            If Not lista8 Is Nothing Then
                If lista8.Count > 0 Then
                    For Each ambs In lista8
                        If ambs.ENTEROBACTERIAS = 1 Then
                            enterobacterias = 1
                        End If
                        If ambs.LISTAMBIENTAL = 1 Then
                            listambiental = 1
                        End If
                        If ambs.LISTMONO = 1 Then
                            listmono = 1
                        End If
                        If ambs.SALMONELLA = 1 Then
                            salmonella = 1
                        End If
                        If ambs.ECOLI = 1 Then
                            ecoli = 1
                        End If
                        If ambs.MOHOSYLEVADURAS = 1 Then
                            mohosylevaduras = 1
                        End If
                        If ambs.RB = 1 Then
                            rb = 1
                        End If
                        If ambs.CT = 1 Then
                            ct = 1
                        End If
                        If ambs.CF = 1 Then
                            cf = 1
                        End If
                        If ambs.PSEUDOMONASPP = 1 Then
                            pseudomonaspp = 1
                        End If
                        If ambs.LISTSPP = 1 Then
                            listeriaspp = 1
                        End If
                    Next

                End If
            End If
            If enterobacterias = 1 Then
                texto = texto + " - Enterobacterias"
            End If
            If listambiental = 1 Then
                texto = texto + " - Listeria ambiental"
            End If
            If listmono = 1 Then
                texto = texto + " - Listeria monocitógenes"
            End If
            If salmonella = 1 Then
                texto = texto + " - Salmonella"
            End If
            If ecoli = 1 Then
                texto = texto + " - E. Coli"
            End If
            If mohosylevaduras = 1 Then
                texto = texto + " - Mohos y levaduras"
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If ct = 1 Then
                texto = texto + " - Coliformes totales"
            End If
            If cf = 1 Then
                texto = texto + " - CF"
            End If
            If pseudomonaspp = 1 Then
                texto = texto + " - Pseudomona spp"
            End If
            If listeriaspp = 1 Then
                texto = texto + " - Listeria spp"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ES PARASITOLOGÍA ********************************************************************************
        ElseIf tipoinforme = "Parasitología" Then
            Dim p As New dParasitologiaSolicitud
            Dim lista9 As ArrayList
            lista9 = p.listarporsolicitud(ficha)

            Dim gastrointestinales As Integer = 0
            Dim fasciola As Integer = 0
            Dim coccidias As Integer = 0
            texto = ""
            If Not lista9 Is Nothing Then
                If lista9.Count > 0 Then
                    For Each p In lista9
                        If p.GASTROINTESTINALES = 1 Then
                            gastrointestinales = 1
                        End If
                        If p.FASCIOLA = 1 Then
                            fasciola = 1
                        End If
                        If p.COCCIDIAS = 1 Then
                            coccidias = 1
                        End If
                    Next
                End If
            End If
            If gastrointestinales = 1 Then
                texto = texto + " - Gastrointestinales"
            End If
            If fasciola = 1 Then
                texto = texto + " - Fasciola"
            End If
            If coccidias = 1 Then
                texto = texto + " - Coccidias"
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If

            ' SI ES NUTRICIÓN ********************************************************************************
        ElseIf tipoinforme = "Nutrición" Then
            Dim mga As Integer = 0
            Dim mgb As Integer = 0
            Dim ensilados As Integer = 0
            Dim pasturas As Integer = 0
            Dim extetereo As Integer = 0
            Dim nida As Integer = 0
            Dim micotoxinas As Integer = 0
            texto = ""
            If Not listanutricion Is Nothing Then
                If listanutricion.Count > 0 Then
                    For Each sn In listanutricion
                        texto = texto & " // " & sn.MUESTRA & " - "
                        If sn.MGA = 1 Then
                            texto = texto & "MGA - "
                        End If
                        If sn.MGB = 1 Then
                            texto = texto & "MGB - "
                        End If
                        If sn.ENSILADOS = 1 Then
                            texto = texto & "Ensilados - "
                        End If
                        If sn.PASTURAS = 1 Then
                            texto = texto & "Pasturas - "
                        End If
                        If sn.EXTETEREO = 1 Then
                            texto = texto & "Extracto etéreo - "
                        End If
                        If sn.NIDA = 1 Then
                            texto = texto & "NIDA - "
                        End If
                        If sn.MICOTOXINAS = 1 Then
                            texto = texto & "MICOTOXINAS - "
                        End If
                        If sn.AFLA = 1 Then
                            texto = texto & "AFLA - "
                        End If
                        If sn.DON = 1 Then
                            texto = texto & "DON - "
                        End If
                        If sn.ZEARA = 1 Then
                            texto = texto & "ZEARA - "
                        End If
                        If sn.PROTEINAS = 1 Then
                            texto = texto & "PROTEINAS - "
                        End If
                        If sn.FIBRANEUTRA = 1 Then
                            texto = texto & "FIBRA NEUTRA - "
                        End If
                        If sn.FIBRAACIDA = 1 Then
                            texto = texto & "FIBRA ÁCIDA - "
                        End If
                    Next

                End If
            End If

            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If


            ' SI ES SUELOS ********************************************************************************
        ElseIf tipoinforme = "Suelos" Then
            Dim nitratos As Integer = 0
            Dim mineralizacion As Integer = 0
            Dim fosforobray As Integer = 0
            Dim fosforocitrico As Integer = 0
            Dim phagua As Integer = 0
            Dim phkci As Integer = 0
            Dim materiaorg As Integer = 0
            Dim potasioint As Integer = 0
            Dim sulfatos As Integer = 0
            Dim nitrogenovegetal As Integer = 0
            texto = ""
            If Not listasuelos Is Nothing Then
                If listasuelos.Count > 0 Then
                    For Each ss In listasuelos
                        texto = texto & " // " & ss.MUESTRA & " - "
                        If ss.PAQUETE = 1 Then
                            texto = texto & "Paquete 1 (Completo) - "
                        End If
                        If ss.PAQUETE = 2 Then
                            texto = texto & "Paquete 2 (Cultivos de verano) - "
                        End If
                        If ss.PAQUETE = 3 Then
                            texto = texto & "Paquete 3 (Cultivos de invierno) - "
                        End If
                        If ss.PAQUETE = 4 Then
                            texto = texto & "Paquete 4 (Cationes) - "
                        End If
                        If ss.PAQUETE = 5 Then
                            texto = texto & "Paquete 5 (Pastura) - "
                        End If
                        If ss.PAQUETE = 7 Then
                            texto = texto & "Paquete foliares (Fósforo y Potasio Total) "
                        End If
                        If ss.NITRATOS = 1 Then
                            texto = texto & "Nitratos - "
                        End If
                        If ss.MINERALIZACION = 1 Then
                            texto = texto & "Mineralización - "
                        End If
                        If ss.FOSFOROBRAY = 1 Then
                            texto = texto & "Fósforo Bray I - "
                        End If
                        If ss.FOSFOROCITRICO = 1 Then
                            texto = texto & "Fósforo Ac.Cítrico - "
                        End If
                        If ss.PHAGUA = 1 Then
                            texto = texto & "pH Agua - "
                        End If
                        If ss.PHKCI = 1 Then
                            texto = texto & "pH KCI - "
                        End If
                        If ss.MATERIAORG = 1 Then
                            texto = texto & "Materia orgánica - "
                        End If
                        If ss.POTASIOINT = 1 Then
                            texto = texto & "Potasio intercambiable - "
                        End If
                        If ss.SULFATOS = 1 Then
                            texto = texto & "Sulfatos - "
                        End If
                        If ss.NITROGENOVEGETAL = 1 Then
                            texto = texto & "Nitrógeno vegetal - "
                        End If
                        If ss.MAGNESIO = 1 Then
                            texto = texto & "Magnesio - "
                        End If
                        If ss.SODIO = 1 Then
                            texto = texto & "Sodio - "
                        End If
                        If ss.ACIDEZTITULABLE = 1 Then
                            texto = texto & "Acidez titulable - "
                        End If
                        If ss.CIC = 1 Then
                            texto = texto & "CIC - "
                        End If
                        If ss.SB = 1 Then
                            texto = texto & "% SB - "
                        End If
                        If ss.ZINC = 1 Then
                            texto = texto & "ZINC - "
                        End If
                    Next

                End If
            End If

            If texto.Length > 0 Then
                x1hoja.Range("A36", "G37").Merge()
                x1hoja.Range("A36", "G37").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
            End If
        Else
            x1hoja.Range("A36", "G37").Merge()
            x1hoja.Range("A36", "G37").WrapText = True
            'x1hoja.Cells(fila, columna).Formula = texto
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 2
        End If
        '***********************************************************************************************



        'x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).formula = "-----------------------------------------------------------------------------"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Identificación de las muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1

        '*** LISTADO DE MUESTRAS *********************************************************************************

        ' SI ES PRODUCTOS LÁCTEOS ********************************************************************************

        If tipoinforme = "Alimentos" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4

                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5


            ' SI ES AGUA ********************************************************************************

        ElseIf tipoinforme = "Agua" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES CALIDAD ********************************************************************************

        ElseIf tipoinforme = "Calidad de leche" Then
            texto2 = ""
            Dim cuenta_rb As Integer = 0
            Dim cuenta_rc As Integer = 0
            Dim cuenta_comp As Integer = 0
            Dim cuenta_compsuero As Integer = 0
            Dim cuenta_criosc As Integer = 0
            Dim cuenta_inhib As Integer = 0
            Dim cuenta_charm As Integer = 0
            Dim cuenta_espor As Integer = 0
            Dim cuenta_urea As Integer = 0
            Dim cuenta_termo As Integer = 0
            Dim cuenta_psicro As Integer = 0
            Dim cuenta_criosc_criosc As Integer = 0
            Dim cuenta_caseina As Integer = 0
            Dim cuenta_aflatoxina As Integer = 0
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        texto2 = texto2 + csm.MUESTRA

                        If csm.RB = 1 Then

                            cuenta_rb = cuenta_rb + 1
                        End If
                        If csm.RC = 1 Then

                            cuenta_rc = cuenta_rc + 1
                        End If
                        If csm.COMPOSICION = 1 Then

                            cuenta_comp = cuenta_comp + 1
                        End If
                        If csm.COMPOSICIONSUERO = 1 Then

                            cuenta_compsuero = cuenta_compsuero + 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then

                            cuenta_criosc = cuenta_criosc + 1
                        End If
                        If csm.INHIBIDORES = 1 Then

                            cuenta_inhib = cuenta_inhib + 1
                        End If
                        If csm.CHARM = 1 Then
                            cuenta_charm = cuenta_charm + 1
                        End If
                        If csm.ESPORULADOS = 1 Then

                            cuenta_espor = cuenta_espor + 1
                        End If
                        If csm.UREA = 1 Then

                            cuenta_urea = cuenta_urea + 1
                        End If
                        If csm.TERMOFILOS = 1 Then

                            cuenta_termo = cuenta_termo + 1
                        End If
                        If csm.PSICROTROFOS = 1 Then

                            cuenta_psicro = cuenta_psicro + 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then

                            cuenta_criosc_criosc = cuenta_criosc_criosc + 1
                        End If
                        If csm.CASEINA = 1 Then

                            cuenta_caseina = cuenta_caseina + 1
                        End If
                        If csm.AFLATOXINA = 1 Then

                            cuenta_aflatoxina = cuenta_aflatoxina + 1
                        End If
                        texto2 = texto2 + " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G43").Merge()
            x1hoja.Range("A40", "G43").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9

            If cuenta_rb > 0 Then
                texto3 = texto3 & cuenta_rb & " RB - "
            End If
            If cuenta_rc > 0 Then
                texto3 = texto3 & cuenta_rc & " RC - "
            End If
            If cuenta_comp > 0 Then
                texto3 = texto3 & cuenta_comp & " Comp. - "
            End If
            If cuenta_compsuero > 0 Then
                texto3 = texto3 & cuenta_compsuero & " Comp. suero - "
            End If
            If cuenta_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc & " Criosc. - "
            End If
            If cuenta_inhib > 0 Then
                texto3 = texto3 & cuenta_inhib & " Inhib. - "
            End If
            If cuenta_charm > 0 Then
                texto3 = texto3 & cuenta_charm & " Charm - "
            End If
            If cuenta_espor > 0 Then
                texto3 = texto3 & cuenta_espor & " Espor. - "
            End If
            If cuenta_urea > 0 Then
                texto3 = texto3 & cuenta_urea & " Urea - "
            End If
            If cuenta_termo > 0 Then
                texto3 = texto3 & cuenta_termo & " Termof. - "
            End If
            If cuenta_psicro > 0 Then
                texto3 = texto3 & cuenta_psicro & " Psicro. - "
            End If
            If cuenta_criosc_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc_criosc & " Criosc.(Crióscopo) - "
            End If
            If cuenta_caseina > 0 Then
                texto3 = texto3 & cuenta_caseina & " Caseina - "
            End If
            If cuenta_aflatoxina > 0 Then
                texto3 = texto3 & cuenta_aflatoxina & " Aflatoxina M1 - "
            End If
            fila = fila + 4

            'x1hoja.Range("A45", "G46").Merge()
            'x1hoja.Range("A45", "G46").WrapText = True
            x1hoja.Cells(fila, columna).Formula = "Total: " + texto3
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9

            fila = fila + 1



            ' SI ES CONTROL LECHERO ********************************************************************************

        ElseIf tipoinforme = "Control Lechero" Then
            texto2 = ""
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES ANTIBIOGRAMA ********************************************************************************

        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES AMBIENTAL ********************************************************************************

        ElseIf tipoinforme = "Ambiental" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES PARASITOLOGÍA ********************************************************************************

        ElseIf tipoinforme = "Parasitología" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            ' SI ES PAL ********************************************************************************

        ElseIf tipoinforme = "PAL" Then
            texto2 = ""
            If Not lista10 Is Nothing Then
                If lista10.Count > 0 Then
                    For Each spal In lista10
                        texto2 = texto2 + spal.MATRICULA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5

            Dim solpal As New dSolicitudPAL
            solpal.FICHA = ficha
            solpal = solpal.buscar
            If Not solpal Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = "Vacas: " & solpal.VACAS & " - " & "Fecha extracción: " & solpal.FECHAEXT
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
            End If

            '********************************************************************************************************************
            ' SI ES BRUCELOSIS LECHE ********************************************************************************

        ElseIf tipoinforme = "Brucelosis en leche" Then
            texto2 = ""
            If Not listabl Is Nothing Then
                If listabl.Count > 0 Then
                    For Each sm In listabl
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
        ElseIf tipoinforme = "Nutrición" Then
            fila = fila + 5
        ElseIf tipoinforme = "Suelos" Then
            fila = fila + 5
        Else
            x1hoja.Range("A40", "G44").Merge()
            x1hoja.Range("A40", "G44").WrapText = True
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 5
        End If
        '********************************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Observaciones:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = observaciones
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2

        'x1hoja.Cells(fila, columna).formula = "En nuestro sitio web http://www.colaveco.com.uy, puede descargar los resultados, solicite usuario y contraseña."
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 10
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "COLAVECO - Parque El Retiro - Nueva Helvecia - Tel/Fax: 45545311/45545975/45546838"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Email: colaveco@gmail.com - web: http://www.colaveco.com.uy"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Cuando el cliente solicite suspender el servicio ya presupuestado y en ejecución, o una parte del mismo,"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "los costos de las actividades ya realizadas en el momento de la suspensión deberán pagarse."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Los resultados de este análisis pueden ser utilizados y/o publicados por COLAVECO, con fines"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "científicos, protegiendo la confidencialidad del cliente."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True

        If Not dm Is Nothing Then
            If dm.IDINFORETORNO = 1 Then
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Autorizo a procesar las muestras a pesar de no cumplir con las condiciones establecidas en el PG.LAB.01"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
            End If
        End If

        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "FIRMA DEL CLIENTE / ACLARACIÓN: _____________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10

        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        'x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        x1hoja.SaveAs("\\192.168.1.10\E\NET\TICKET_CLIENTES\TC" & ficha & ".xls")




        x1app.Visible = True

        x1libro.PrintPreview()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub imprimir_solicitud()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        Dim ficha As String = TextId.Text.Trim
        Dim fecha As Date = DateFechaIngreso.Value
        Dim nmuestras As Integer
        If TextNMuestras.Text <> "" Then
            nmuestras = TextNMuestras.Text.Trim
        Else
            nmuestras = 0
        End If
        Dim muestra As String = ComboMuestra.Text
        Dim solicitud As String = ""
        Dim texto As String = ""
        Dim texto2 As String = ""
        Dim texto3 As String = ""
        If CheckSinSolicitud.Checked = True Then
            solicitud = "No"
        Else
            solicitud = "Si"
        End If
        Dim conservante As String = ""
        If CheckSinConservante.Checked = True Then
            conservante = "No"
        Else
            conservante = "Si"
        End If
        Dim temperatura As String = TextTemperatura.Text
        Dim derramadas As String = ""
        If CheckDerramadas.Checked = True Then
            derramadas = "Si"
        Else
            derramadas = "No"
        End If
        Dim desvio As String = ""
        If CheckDesvio.Checked = True Then
            desvio = "Si"
        Else
            desvio = "No"
        End If
        Dim tipoinforme As String = ComboTipoInforme.Text
        Dim subtipoinforme As String = ComboSubInforme.Text
        Dim observaciones As String = TextObservaciones.Text.Trim
        Dim pago As Integer
        If CheckPago.Checked = True Then
            pago = 1
        Else
            pago = 0
        End If

        Dim fila = 1
        Dim columna = 1
        x1hoja.Cells(fila, columna).formula = Now
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 2
        x1hoja.Cells(fila, columna).formula = "Solicitud de análisis"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        columna = columna + 3
        x1hoja.Cells(fila, columna).formula = "RG.ADM.36"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Versión 03 del 01/07/16"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Ficha:" & " " & TextId.Text
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 2

        '************************************************************************
        x1hoja.Cells(fila, columna).formula = "*" & TextId.Text & "*"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Name = "Bar-Code 39"
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 20
        columna = 1
        '************************************************************************

        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Fecha de ingreso:" & " " & fecha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Realizada por:" & " " & Usuario.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Muestras:" & " " & nmuestras
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Muestra de:" & " " & muestra
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Control de Recepción de Muestras:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Solicitud:" & " " & solicitud
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 3
        Dim sc As New dRelSolicitudCajas
        Dim so As New dRelSolicitudOtros
        Dim sm As New dRelSolicitudMuestras
        Dim spal As New dSolicitudPAL
        Dim csm As New dCalidadSolicitudMuestra
        Dim cs As New dControlSolicitud
        Dim a2 As New dAntibiograma2
        Dim sn As New dSolicitudNutricion
        Dim ss As New dSolicitudSuelos
        Dim bl As New dBrucelosis
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim lista4 As New ArrayList
        Dim lista5 As New ArrayList
        Dim lista6 As New ArrayList
        Dim lista7 As New ArrayList
        Dim lista10 As New ArrayList
        Dim listabl As New ArrayList
        Dim listanutricion As New ArrayList
        Dim listasuelos As New ArrayList
        Dim cajas As String = ""
        Dim gradillas As String = ""
        Dim otros As String = ""
        lista2 = sc.listarporficha(ficha)
        lista3 = so.listarporficha(ficha)
        lista4 = sm.listarporficha(ficha)
        lista5 = csm.listarporsolicitud3(ficha)
        lista6 = cs.listarporsolicitud(ficha)
        lista7 = a2.listarporsolicitud(ficha)
        lista10 = spal.listarporsolicitud(ficha)
        listanutricion = sn.listarporsolicitud(ficha)
        listasuelos = ss.listarporsolicitud(ficha)
        listabl = sm.listarporficha(ficha)
        If Not lista2 Is Nothing Then
            For Each sc In lista2
                cajas = cajas + Format$(sc.IDCAJA) & " - "
                If sc.GRADILLA1 <> 0 Then
                    gradillas = gradillas + Format$(sc.GRADILLA1) & " - "
                End If
                If sc.GRADILLA2 <> 0 Then
                    gradillas = gradillas + Format$(sc.GRADILLA2) & " - "
                End If
                If sc.GRADILLA3 <> 0 Then
                    gradillas = gradillas + Format$(sc.GRADILLA3) & " - "
                End If
            Next
        End If
        If Not lista3 Is Nothing Then
            For Each so In lista3
                otros = otros + so.DESCRIPCION & " "
            Next
        End If
        x1hoja.Range("D9", "G10").Merge()
        x1hoja.Range("D9", "G10").WrapText = True
        x1hoja.Cells(fila, columna).formula = "Caja/s nº:" & " " & cajas
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Conservante:" & " " & conservante
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 3
        fila = fila + 1
        x1hoja.Range("D11", "G14").Merge()
        x1hoja.Range("D11", "G14").WrapText = True
        x1hoja.Cells(fila, columna).formula = "Gradillas nº:" & " " & gradillas
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        'fila = fila + 3
        x1hoja.Cells(fila, columna).formula = "Temperatura:" & " " & temperatura
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 3
        fila = fila + 4
        x1hoja.Cells(fila, columna).formula = "Otros:" & " " & otros
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1

        fila = fila - 3
        x1hoja.Cells(fila, columna).formula = "Derramadas en el envío:" & " " & derramadas
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Desvío autorizado por el cliente:" & " " & desvio
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 3
        x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Solicitud: Tipo de informe:" & " " & tipoinforme & " - " & "Subinforme:" & " " & subtipoinforme
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1

        '***  LISTADO DE ANALISIS REQUERIDOS *********************************************************************

        ' SI ES PRODUCTOS LÁCTEOS ********************************************************************************
        If tipoinforme = "Alimentos" Then
            Dim sp As New dSubproducto
            Dim lista As New ArrayList
            texto = ""
            lista = sp.listarporsolicitud(ficha)
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each sp In lista
                        texto = ""
                        If sp.ESTAFCOAGPOSITIVO = 1 Then
                            texto = texto + "Estaf. Coag. Positivo ____/____/____ "
                        End If
                        If sp.CF = 1 Then
                            texto = texto + "CF ____/____/____ "
                        End If
                        If sp.MOHOSYLEVADURAS = 1 Then
                            texto = texto + "Mohos y levaduras ____/____/____ "
                        End If
                        If sp.CT = 1 Then
                            texto = texto + "CT ____/____/____ "
                        End If
                        If sp.ECOLI = 1 Then
                            texto = texto + "E. Coli ____/____/____ "
                        End If
                        If sp.SALMONELLA = 1 Then
                            texto = texto + "Salmonella ____/____/____ "
                        End If
                        If sp.LISTERIASPP = 1 Then
                            texto = texto + "Listeria spp ____/____/____ "
                        End If
                        If sp.HUMEDAD = 1 Then
                            texto = texto + "Humedad ____/____/____ "
                        End If
                        If sp.MGRASA = 1 Then
                            texto = texto + "M. Grasa ____/____/____ "
                        End If
                        If sp.PH = 1 Then
                            texto = texto + "pH ____/____/____ "
                        End If
                        If sp.CLORUROS = 1 Then
                            texto = texto + "Cloruros ____/____/____ "
                        End If
                        If sp.PROTEINAS = 1 Then
                            texto = texto + "Proteínas ____/____/____ "
                        End If
                        If sp.ENTEROBACTERIAS = 1 Then
                            texto = texto + "Enterobacterias ____/____/____ "
                        End If
                        If sp.LISTERIAAMBIENTAL = 1 Then
                            texto = texto + "Listeria Ambiental ____/____/____ "
                        End If
                        If sp.ESPORANAERMESOFILO = 1 Then
                            texto = texto + "Espor. Anaer. Mesófilos ____/____/____ "
                        End If
                        If sp.TERMOFILOS = 1 Then
                            texto = texto + "Termodúricos ____/____/____ "
                        End If
                        If sp.PSICROTROFOS = 1 Then
                            texto = texto + "Psicrótrofos ____/____/____ "
                        End If
                        If sp.RB = 1 Then
                            texto = texto + "RB ____/____/____ "
                        End If
                        If sp.TABLANUTRICIONAL = 1 Then
                            texto = texto + "Tabla nutricional ____/____/____ "
                        End If
                        If sp.LISTERIAMONOCITOGENES = 1 Then
                            texto = texto + "Listeria monocitógenes ____/____/____ "
                        End If
                        If sp.CENIZAS = 1 Then
                            texto = texto + "Cenizas ____/____/____ "
                        End If
                        If sp.LISTERIAPOOL = 1 Then
                            texto = texto + "Pool de Listeria ____/____/____ "
                        End If
                        If sp.SALMONELLAPOOL = 1 Then
                            texto = texto + "Pool de Salmonella ____/____/____ "
                        End If
                    Next
                End If
                x1hoja.Range("A18", "G20").Merge()
                x1hoja.Range("A18", "G20").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 3
            End If
        End If

        ' SI ES AGUA ********************************************************************************
        If tipoinforme = "Agua" Then
            Dim a1 As New dAgua
            texto = ""
            a1.ID = ficha
            a1 = a1.buscar()

            texto = ComboSubInforme.Text & " "
            If a1.HET22 = 1 Then
                texto = texto & " " & "+ Heterotróficos 22 ____/____/____ "
            End If
            If a1.HET35 = 1 Then
                texto = texto & " " & "+ Heterotróficos 35 ____/____/____ "
            End If
            If a1.HET37 = 1 Then
                texto = texto & " " & "+ Heterotróficos 37 ____/____/____ "
            End If
            If a1.CLORO = 1 Then
                texto = texto & " " & "+ Cloro ____/____/____ "
            End If
            If a1.CONDUCTIVIDAD = 1 Then
                texto = texto & " " & "+ Conductividad ____/____/____ "
            End If
            If a1.PH = 1 Then
                texto = texto & " " & "+ pH ____/____/____ "
            End If
            If a1.ECOLI = 1 Then
                texto = texto & " " & "+ Ecoli ____/____/____ "
            End If
            If a1.SULFITOREDUCTORES = 1 Then
                texto = texto & " " & "+ Sulfito reductores ____/____/____ "
            End If
            If a1.ENTEROCOCOS = 1 Then
                texto = texto & " " & "+ Enterococos ____/____/____ "
            End If
            If a1.ESTREPTOCOCOS = 1 Then
                texto = texto & " " & "+ Estreptococos ____/____/____ "
            End If
            If a1.PAQMACRO = 1 Then
                texto = texto & " " & "+ Paq. Macroelementos "
            End If
            If a1.ALCALINIDAD = 1 Then
                texto = texto & " " & "+ Alcalinidad "
            End If
            If a1.CA = 1 Then
                texto = texto & " " & "+ Ca "
            End If
            If a1.MG = 1 Then
                texto = texto & " " & "+ Mg "
            End If
            If a1.NA = 1 Then
                texto = texto & " " & "+ Na "
            End If
            If a1.FE = 1 Then
                texto = texto & " " & "+ Fe "
            End If
            If a1.K = 1 Then
                texto = texto & " " & "+ K "
            End If
            If a1.AL = 1 Then
                texto = texto & " " & "+ Al "
            End If
            If a1.CD = 1 Then
                texto = texto & " " & "+ Cd "
            End If
            If a1.CR = 1 Then
                texto = texto & " " & "+ Cr "
            End If
            If a1.CU = 1 Then
                texto = texto & " " & "+ Cu "
            End If
            If a1.PB = 1 Then
                texto = texto & " " & "+ Pb "
            End If
            If a1.MN = 1 Then
                texto = texto & " " & "+ Mn "
            End If
            If a1.FE = 1 Then
                texto = texto & " " & "+ fe "
            End If
            If a1.ZN = 1 Then
                texto = texto & " " & "+ Zn "
            End If
            If a1.SE = 1 Then
                texto = texto & " " & "+ Se "
            End If

            If texto.Length > 0 Then

                x1hoja.Range("A18", "G20").Merge()
                x1hoja.Range("A18", "G20").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 3
            End If
        End If
        ' SI ES CALIDAD DE LECHE ********************************************************************************
        If tipoinforme = "Calidad de leche" Then
            Dim rb As Integer = 0
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim compsuero As Integer = 0
            Dim criosc As Integer = 0
            Dim inh As Integer = 0
            Dim charm As Integer = 0
            Dim espor As Integer = 0
            Dim urea As Integer = 0
            Dim term As Integer = 0
            Dim psicr As Integer = 0
            Dim crioscopo As Integer = 0
            Dim caseina As Integer = 0
            Dim aflatoxinam1 As Integer = 0
            texto = ""
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        If csm.RB = 1 Then
                            rb = 1
                        End If
                        If csm.RC = 1 Then
                            rc = 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If csm.COMPOSICIONSUERO = 1 Then
                            compsuero = 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            criosc = 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            inh = 1
                        End If
                        If csm.CHARM = 1 Then
                            charm = 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            espor = 1
                        End If
                        If csm.UREA = 1 Then
                            urea = 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            term = 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            psicr = 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            crioscopo = 1
                        End If
                        If csm.CASEINA = 1 Then
                            caseina = 1
                        End If
                        If csm.AFLATOXINA = 1 Then
                            aflatoxinam1 = 1
                        End If
                    Next

                End If
            End If
            If rb = 1 Then
                texto = texto + "RB ____/____/____ "
            End If
            If rc = 1 Then
                texto = texto + "RC ____/____/____ "
            End If
            If comp = 1 Then
                texto = texto + "Composición ____/____/____ "
            End If
            If compsuero = 1 Then
                texto = texto + "Composición Suero ____/____/____ "
            End If
            If criosc = 1 Then
                texto = texto + "Crioscopía ____/____/____ "
            End If
            If inh = 1 Then
                texto = texto + "Inhibidores ____/____/____ "
            End If
            If charm = 1 Then
                texto = texto + "ROSA Charm ____/____/____ "
            End If
            If espor = 1 Then
                texto = texto + "Esporulados ____/____/____ "
            End If
            If urea = 1 Then
                texto = texto + "Urea ____/____/____ "
            End If
            If term = 1 Then
                texto = texto + "Termófilos ____/____/____ "
            End If
            If psicr = 1 Then
                texto = texto + "Psicrótrofos ____/____/____ "
            End If
            If crioscopo = 1 Then
                texto = texto + "Crioscopía (crióscopo) ____/____/____ "
            End If
            If caseina = 1 Then
                texto = texto + "Caseína ____/____/____ "
            End If
            If aflatoxinam1 = 1 Then
                texto = texto + "Aflatoxina M1 ____/____/____ "
            End If

            If texto.Length > 0 Then
                x1hoja.Range("A18", "G20").Merge()
                x1hoja.Range("A18", "G20").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 3
            End If

        End If
        ' SI ES CONTROL LECHERO ********************************************************************************
        If tipoinforme = "Control Lechero" Then
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim urea As Integer = 0
            Dim caseina As Integer = 0
            texto = ""
            If Not lista6 Is Nothing Then
                If lista6.Count > 0 Then
                    For Each cs In lista6
                        If cs.RC = 1 Then
                            rc = 1
                        End If
                        If cs.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If cs.UREA = 1 Then
                            urea = 1
                        End If
                        If cs.CASEINA = 1 Then
                            caseina = 1
                        End If
                    Next

                End If
            End If
            If rc = 1 Then
                texto = texto + "RC ____/____/____ "
            End If
            If comp = 1 Then
                texto = texto + "Composición ____/____/____ "
            End If
            If urea = 1 Then
                texto = texto + "Urea ____/____/____ "
            End If
            If caseina = 1 Then
                texto = texto + "Caseina ____/____/____ "
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A18", "G20").Merge()
                x1hoja.Range("A18", "G20").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 3
            End If
        End If
        ' SI ANTIBIOGRAMA ********************************************************************************
        If tipoinforme = "Bacteriología y Antibiograma" Then
            Dim aislamiento As Integer = 0
            Dim antibiograma As Integer = 0
            texto = ""
            If Not lista7 Is Nothing Then
                If lista7.Count > 0 Then
                    For Each a2 In lista7
                        If a2.AISLAMIENTO = 1 Then
                            aislamiento = 1
                        End If
                        If a2.ANTIBIOGRAMA = 1 Then
                            antibiograma = 1
                        End If
                    Next

                End If
            End If
            If aislamiento = 1 Then
                texto = texto + "Aislamiento ____/____/____ "
            End If
            If antibiograma = 1 Then
                texto = texto + "Antibiograma ____/____/____ "
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A18", "G20").Merge()
                x1hoja.Range("A18", "G20").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 3
            End If
        End If
        ' SI ES AMBIENTAL ********************************************************************************
        If tipoinforme = "Ambiental" Then
            Dim ambs As New dAmbientalSolicitud
            Dim lista8 As ArrayList
            lista8 = ambs.listarporsolicitud(ficha)

            Dim enterobacterias As Integer = 0
            Dim listambiental As Integer = 0
            Dim listmono As Integer = 0
            Dim salmonella As Integer = 0
            Dim ecoli As Integer = 0
            Dim mohosylevaduras As Integer = 0
            Dim rb As Integer = 0
            Dim ct As Integer = 0
            Dim cf As Integer = 0
            Dim pseudomonaspp As Integer = 0
            Dim listeriaspp As Integer = 0
            texto = ""
            If Not lista8 Is Nothing Then
                If lista8.Count > 0 Then
                    For Each ambs In lista8
                        If ambs.ENTEROBACTERIAS = 1 Then
                            enterobacterias = 1
                        End If
                        If ambs.LISTAMBIENTAL = 1 Then
                            listambiental = 1
                        End If
                        If ambs.LISTMONO = 1 Then
                            listmono = 1
                        End If
                        If ambs.SALMONELLA = 1 Then
                            salmonella = 1
                        End If
                        If ambs.ECOLI = 1 Then
                            ecoli = 1
                        End If
                        If ambs.MOHOSYLEVADURAS = 1 Then
                            mohosylevaduras = 1
                        End If
                        If ambs.RB = 1 Then
                            rb = 1
                        End If
                        If ambs.CT = 1 Then
                            ct = 1
                        End If
                        If ambs.CF = 1 Then
                            cf = 1
                        End If
                        If ambs.PSEUDOMONASPP = 1 Then
                            pseudomonaspp = 1
                        End If
                        If ambs.LISTSPP = 1 Then
                            listeriaspp = 1
                        End If
                    Next

                End If
            End If
            If enterobacterias = 1 Then
                texto = texto + "Enterobacterias ____/____/____ "
            End If
            If listambiental = 1 Then
                texto = texto + "Listeria ambiental ____/____/____ "
            End If
            If listmono = 1 Then
                texto = texto + "Listeria monocitógenes ____/____/____ "
            End If
            If salmonella = 1 Then
                texto = texto + "Salmonella ____/____/____ "
            End If
            If ecoli = 1 Then
                texto = texto + "E. Coli ____/____/____ "
            End If
            If mohosylevaduras = 1 Then
                texto = texto + "Mohos y levaduras ____/____/____ "
            End If
            If rb = 1 Then
                texto = texto + "RB ____/____/____ "
            End If
            If ct = 1 Then
                texto = texto + "CT ____/____/____ "
            End If
            If cf = 1 Then
                texto = texto + "CF ____/____/____ "
            End If
            If pseudomonaspp = 1 Then
                texto = texto + "Pseudomona spp ____/____/____ "
            End If
            If listeriaspp = 1 Then
                texto = texto + "Listeriaa spp ____/____/____ "
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A18", "G20").Merge()
                x1hoja.Range("A18", "G20").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 3
            End If
        End If
        ' SI ES PARASITOLOGÍA ********************************************************************************
        If tipoinforme = "Parasitología" Then
            Dim p As New dParasitologiaSolicitud
            Dim lista9 As ArrayList
            lista9 = p.listarporsolicitud(ficha)

            Dim gastrointestinales As Integer = 0
            Dim fasciola As Integer = 0
            Dim coccidias As Integer = 0
            texto = ""
            If Not lista9 Is Nothing Then
                If lista9.Count > 0 Then
                    For Each p In lista9
                        If p.GASTROINTESTINALES = 1 Then
                            gastrointestinales = 1
                        End If
                        If p.FASCIOLA = 1 Then
                            fasciola = 1
                        End If
                        If p.COCCIDIAS = 1 Then
                            coccidias = 1
                        End If
                    Next
                End If
            End If
            If gastrointestinales = 1 Then
                texto = texto + "Gastrointestinales ____/____/____ "
            End If
            If fasciola = 1 Then
                texto = texto + "Fasciola ____/____/____ "
            End If
            If coccidias = 1 Then
                texto = texto + "Coccidias ____/____/____ "
            End If
            If texto.Length > 0 Then
                x1hoja.Range("A18", "G20").Merge()
                x1hoja.Range("A18", "G20").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 3
            End If
        End If
        ' SI ES NUTRICIÓN ********************************************************************************
        If tipoinforme = "Nutrición" Then
            Dim mga As Integer = 0
            Dim mgb As Integer = 0
            Dim ensilados As Integer = 0
            Dim pasturas As Integer = 0
            Dim extetereo As Integer = 0
            Dim nida As Integer = 0
            Dim micotoxinas As Integer = 0
            texto = ""
            If Not listanutricion Is Nothing Then
                If listanutricion.Count > 0 Then
                    For Each sn In listanutricion
                        texto = texto & " // " & sn.MUESTRA & " - "
                        If sn.MGA = 1 Then
                            texto = texto & "MGA - "
                        End If
                        If sn.MGB = 1 Then
                            texto = texto & "MGB - "
                        End If
                        If sn.ENSILADOS = 1 Then
                            texto = texto & "Ensilados - "
                        End If
                        If sn.PASTURAS = 1 Then
                            texto = texto & "Pasturas - "
                        End If
                        If sn.EXTETEREO = 1 Then
                            texto = texto & "Extracto etéreo - "
                        End If
                        If sn.NIDA = 1 Then
                            texto = texto & "NIDA - "
                        End If
                        If sn.MICOTOXINAS = 1 Then
                            texto = texto & "MICOTOXINAS - "
                        End If
                        If sn.AFLA = 1 Then
                            texto = texto & "AFLA - "
                        End If
                        If sn.DON = 1 Then
                            texto = texto & "DON - "
                        End If
                        If sn.ZEARA = 1 Then
                            texto = texto & "ZEARA - "
                        End If
                        If sn.PROTEINAS = 1 Then
                            texto = texto & "PROTEINAS - "
                        End If
                        If sn.MATERIASECA = 1 Then
                            texto = texto & "MATERIA SECA - "
                        End If
                        If sn.FIBRANEUTRA = 1 Then
                            texto = texto & "FIBRA NEUTRA - "
                        End If
                        If sn.FIBRAACIDA = 1 Then
                            texto = texto & "FIBRA ÁCIDA - "
                        End If
                        If sn.PH = 1 Then
                            texto = texto & "pH - "
                        End If
                    Next

                End If
            End If

            If texto.Length > 0 Then
                x1hoja.Range("A18", "G20").Merge()
                x1hoja.Range("A18", "G20").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 3
            End If

        End If
        ' SI ES SUELOS ********************************************************************************
        If tipoinforme = "Suelos" Then
            Dim nitratos As Integer = 0
            Dim mineralizacion As Integer = 0
            Dim fosforobray As Integer = 0
            Dim fosforocitrico As Integer = 0
            Dim phagua As Integer = 0
            Dim phkci As Integer = 0
            Dim materiaorg As Integer = 0
            Dim potasioint As Integer = 0
            Dim sulfatos As Integer = 0
            Dim nitrogenovegetal As Integer = 0
            texto = ""
            If Not listasuelos Is Nothing Then
                If listasuelos.Count > 0 Then
                    For Each ss In listasuelos
                        texto = texto & " // " & ss.MUESTRA & " - "
                        If ss.PAQUETE = 1 Then
                            texto = texto & "Análisis completo - "
                        End If
                        If ss.PAQUETE = 2 Then
                            texto = texto & "Cultivos de verano - "
                        End If
                        If ss.PAQUETE = 3 Then
                            texto = texto & "Cultivos de invierno - "
                        End If
                        If ss.PAQUETE = 4 Then
                            texto = texto & "Cationes - "
                        End If
                        If ss.PAQUETE = 5 Then
                            texto = texto & "Pasturas - "
                        End If
                        If ss.PAQUETE = 7 Then
                            texto = texto & "Fósforo Total - Potasio Total (foliares) "
                        End If
                        If ss.NITRATOS = 1 Then
                            texto = texto & "Nitratos - "
                        End If
                        If ss.MINERALIZACION = 1 Then
                            texto = texto & "Mineralización - "
                        End If
                        If ss.FOSFOROBRAY = 1 Then
                            texto = texto & "Fósforo Bray I - "
                        End If
                        If ss.FOSFOROCITRICO = 1 Then
                            texto = texto & "Fósforo Ac.Cítrico - "
                        End If
                        If ss.PHAGUA = 1 Then
                            texto = texto & "pH Agua - "
                        End If
                        If ss.PHKCI = 1 Then
                            texto = texto & "pH KCI - "
                        End If
                        If ss.MATERIAORG = 1 Then
                            texto = texto & "Materia orgánica - "
                        End If
                        If ss.POTASIOINT = 1 Then
                            texto = texto & "Potasio intercambiable - "
                        End If
                        If ss.SULFATOS = 1 Then
                            texto = texto & "Sulfatos - "
                        End If
                        If ss.NITROGENOVEGETAL = 1 Then
                            texto = texto & "Nitrógeno vegetal - "
                        End If
                        If ss.CALCIO = 1 Then
                            texto = texto & "Calcio - "
                        End If
                        If ss.MAGNESIO = 1 Then
                            texto = texto & "Magnesio - "
                        End If
                        If ss.SODIO = 1 Then
                            texto = texto & "Sodio - "
                        End If
                        If ss.ACIDEZTITULABLE = 1 Then
                            texto = texto & "Acidez titulable - "
                        End If
                        If ss.CIC = 1 Then
                            texto = texto & "CIC - "
                        End If
                        If ss.SB = 1 Then
                            texto = texto & "% SB - "
                        End If
                        If ss.ZINC = 1 Then
                            texto = texto & "ZINC - "
                        End If

                    Next

                End If
            End If

            If texto.Length > 0 Then
                x1hoja.Range("A18", "G21").Merge()
                x1hoja.Range("A18", "G21").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 12
                fila = fila + 4
            End If

        End If
        '***********************************************************************************************
        x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Enviado:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Web: ░░ - Personal: ░░ - Email: ░░ - Fecha de envío: "
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Otro: "
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1

        x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Identificación de las muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '*** LISTADO DE MUESTRAS *********************************************************************************

        ' SI ES PRODUCTOS LÁCTEOS ********************************************************************************
        texto2 = ""
        If tipoinforme = "Alimentos" Then
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4

                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A27", "G30").Merge()
            x1hoja.Range("A27", "G30").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 4
        End If

        ' SI ES AGUA ********************************************************************************
        texto2 = ""
        If tipoinforme = "Agua" Then
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A27", "G30").Merge()
            x1hoja.Range("A27", "G30").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 4
        End If
        ' SI ES CALIDAD ********************************************************************************
        texto2 = ""
        Dim cuenta_rb As Integer = 0
        Dim cuenta_rc As Integer = 0
        Dim cuenta_comp As Integer = 0
        Dim cuenta_criosc As Integer = 0
        Dim cuenta_inhib As Integer = 0
        Dim cuenta_charm As Integer = 0
        Dim cuenta_espor As Integer = 0
        Dim cuenta_urea As Integer = 0
        Dim cuenta_termo As Integer = 0
        Dim cuenta_psicro As Integer = 0
        Dim cuenta_criosc_criosc As Integer = 0
        Dim cuenta_caseina As Integer = 0
        Dim cuenta_aflatoxinam1 As Integer = 0
        If tipoinforme = "Calidad de leche" Then
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        texto2 = texto2 + csm.MUESTRA
                        'texto2 = texto2 + " ("
                        If csm.RB = 1 Then
                            'texto2 = texto2 + "RB "
                            cuenta_rb = cuenta_rb + 1
                        End If
                        If csm.RC = 1 Then
                            'texto2 = texto2 + "RC "
                            cuenta_rc = cuenta_rc + 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            'texto2 = texto2 + "Comp. "
                            cuenta_comp = cuenta_comp + 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            'texto2 = texto2 + "Criosc. "
                            cuenta_criosc = cuenta_criosc + 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            'texto2 = texto2 + "Inhib. "
                            cuenta_inhib = cuenta_inhib + 1
                        End If
                        If csm.CHARM = 1 Then
                            'texto2 = texto2 + "Inhib. "
                            cuenta_charm = cuenta_charm + 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            'texto2 = texto2 + "Espor. "
                            cuenta_espor = cuenta_espor + 1
                        End If
                        If csm.UREA = 1 Then
                            'texto2 = texto2 + "Urea "
                            cuenta_urea = cuenta_urea + 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            'texto2 = texto2 + "Termof. "
                            cuenta_termo = cuenta_termo + 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            'texto2 = texto2 + "Psicrot. "
                            cuenta_psicro = cuenta_psicro + 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            'texto2 = texto2 + "Criosc.(Crioscopo) "
                            cuenta_criosc_criosc = cuenta_criosc_criosc + 1
                        End If
                        If csm.CASEINA = 1 Then
                            'texto2 = texto2 + "Caseina."
                            cuenta_caseina = cuenta_caseina + 1
                        End If
                        If csm.AFLATOXINA = 1 Then
                            'texto2 = texto2 + "Caseina."
                            cuenta_aflatoxinam1 = cuenta_aflatoxinam1 + 1
                        End If
                        'texto2 = texto2 + ")- "
                        texto2 = texto2 + " - "
                    Next
                End If
            End If
            x1hoja.Range("A27", "G37").Merge()
            x1hoja.Range("A27", "G37").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9

            If cuenta_rb > 0 Then
                texto3 = texto3 & cuenta_rb & " RB - "
            End If
            If cuenta_rc > 0 Then
                texto3 = texto3 & cuenta_rc & " RC - "
            End If
            If cuenta_comp > 0 Then
                texto3 = texto3 & cuenta_comp & " Comp. - "
            End If
            If cuenta_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc & " Criosc. - "
            End If
            If cuenta_inhib > 0 Then
                texto3 = texto3 & cuenta_inhib & " Inhib. - "
            End If
            If cuenta_charm > 0 Then
                texto3 = texto3 & cuenta_charm & " Charm. - "
            End If
            If cuenta_espor > 0 Then
                texto3 = texto3 & cuenta_espor & " Espor. - "
            End If
            If cuenta_urea > 0 Then
                texto3 = texto3 & cuenta_urea & " Urea - "
            End If
            If cuenta_termo > 0 Then
                texto3 = texto3 & cuenta_termo & " Termof. - "
            End If
            If cuenta_psicro > 0 Then
                texto3 = texto3 & cuenta_psicro & " Psicro. - "
            End If
            If cuenta_criosc_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc_criosc & " Criosc.(Crióscopo) - "
            End If
            If cuenta_caseina > 0 Then
                texto3 = texto3 & cuenta_caseina & " Caseina - "
            End If
            If cuenta_aflatoxinam1 > 0 Then
                texto3 = texto3 & cuenta_aflatoxinam1 & " Aflatoxina M1 - "
            End If

            fila = fila + 11

            x1hoja.Range("A38", "G39").Merge()
            x1hoja.Range("A38", "G39").WrapText = True
            x1hoja.Cells(fila, columna).Formula = "Total: " + texto3
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 9

            fila = fila + 2

            ' Agrega en la planilla excel las muestras con Rc alto
            'If rc_alto <> "" Then
            '    x1hoja.Range("A41", "G43").Merge()
            '    x1hoja.Range("A41", "G43").WrapText = True
            '    x1hoja.Cells(fila, columna).Formula = "Muestras con RC > 500.000 --> " & rc_alto
            '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            '    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            '    x1hoja.Cells(fila, columna).Font.Bold = True
            '    x1hoja.Cells(fila, columna).Font.Size = 9
            '    fila = fila + 3
            '    rc_alto = ""
            'End If
        End If


        ' SI ES CONTROL LECHERO ********************************************************************************
        texto2 = ""
        If tipoinforme = "Control Lechero" Then

            x1hoja.Range("A27", "G30").Merge()
            x1hoja.Range("A27", "G30").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 4
        End If
        ' SI ES ANTIBIOGRAMA ********************************************************************************
        texto2 = ""
        If tipoinforme = "Bacteriología y Antibiograma" Then
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A27", "G30").Merge()
            x1hoja.Range("A27", "G30").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 4
        End If
        ' SI ES AMBIENTAL ********************************************************************************
        texto2 = ""
        If tipoinforme = "Ambiental" Then
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A27", "G30").Merge()
            x1hoja.Range("A27", "G30").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 4
        End If

        ' SI ES PARASITOLOGÍA ********************************************************************************
        texto2 = ""
        If tipoinforme = "Parasitología" Then
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A27", "G30").Merge()
            x1hoja.Range("A27", "G30").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 6
        End If
        ' SI ES PAL ********************************************************************************
        texto2 = ""
        If tipoinforme = "PAL" Then
            If Not lista10 Is Nothing Then
                If lista10.Count > 0 Then
                    For Each spal In lista10
                        texto2 = texto2 + spal.MATRICULA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A27", "G30").Merge()
            x1hoja.Range("A27", "G30").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 7

            Dim solpal As New dSolicitudPAL
            solpal.FICHA = ficha
            solpal = solpal.buscar
            If Not solpal Is Nothing Then
                x1hoja.Cells(fila, columna).Formula = "Vacas: " & solpal.VACAS & " - " & "Fecha extracción: " & solpal.FECHAEXT
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
            End If
        End If
        '********************************************************************************************************************
        ' SI ES BRUCELOSIS LECHE ********************************************************************************
        texto2 = ""
        If tipoinforme = "Brucelosis en leche" Then
            If Not listabl Is Nothing Then
                If listabl.Count > 0 Then
                    For Each sm In listabl
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            x1hoja.Range("A24", "G27").Merge()
            x1hoja.Range("A24", "G27").WrapText = True
            x1hoja.Cells(fila, columna).Formula = texto2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 9
            fila = fila + 4
        End If


        ' SI ES AGUA ********************************************************************************
        If tipoinforme = "Agua" Then
            Dim a1 As New dAgua
            texto = ""
            a1.ID = ficha
            a1 = a1.buscar()
            If a1.MUESTRAOFICIAL = 1 Then
                texto = a1.PRECINTO
            End If
            If texto.Length > 0 Then
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Precinto: " & texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10

            End If
        End If

        '*** Controla que el productor realiza cambio de caravanas **********************
        If tipoinforme = "Control Lechero" Then
            Dim sa As New dSolicitudAnalisis
            Dim caravanas As Integer = 0
            sa.ID = ficha
            sa = sa.buscar
            If Not sa Is Nothing Then
                Dim p As New dCliente
                p.ID = sa.IDPRODUCTOR
                p = p.buscar
                If Not p Is Nothing Then
                    If p.CARAVANAS = 1 Then
                        caravanas = 1
                    End If
                End If
            End If
            If caravanas = 1 Then
                fila = fila + 4
                x1hoja.Cells(fila, columna).formula = "CAMBIAR CARAVANAS"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 18
            End If
        End If
        '*********************************************************************************************
        '********************************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "_____________________________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "Observaciones:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = observaciones
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        If pago = 1 Then
            x1hoja.Cells(fila, columna).formula = "PAGO OK"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 14
        End If



        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        'x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        x1hoja.SaveAs("\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls")
        'x1hoja.SaveAs("c:\NET\SOLICITUDES\" & ficha & ".xls")

        x1app.Visible = True

        x1libro.PrintPreview()

        'x1hoja.PrintOut()
        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing

    End Sub
    Public Sub guardar()
        If TextId.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de ficha", MsgBoxStyle.Exclamation, "Atención") : TextId.Focus() : Exit Sub
        Dim id As Long = TextId.Text.Trim
        Dim fechaingreso As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
        If TextIdProductor.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de productor", MsgBoxStyle.Exclamation, "Atención") : TextIdProductor.Focus() : Exit Sub
        Dim idproductor As Long = TextIdProductor.Text.Trim
        Dim idtipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        Dim idsubinforme As dSubInforme = CType(ComboSubInforme.SelectedItem, dSubInforme)
        Dim idtipoficha As dTipoFicha = CType(ComboTipoFicha.SelectedItem, dTipoFicha)
        Dim observaciones As String = TextObservaciones.Text.Trim
        Dim nmuestras As Integer
        If TextNMuestras.Text <> "" Then
            nmuestras = TextNMuestras.Text.Trim
        End If
        Dim idmuestra As dMuestras = CType(ComboMuestra.SelectedItem, dMuestras)
        Dim idtecnico As dCliente = CType(ComboTecnico.SelectedItem, dCliente)
        Dim sinsolicitud As Integer
        If CheckSinSolicitud.Checked = True Then
            sinsolicitud = 1
        Else
            sinsolicitud = 0
        End If
        Dim sinconservante As Integer
        If CheckSinConservante.Checked = True Then
            sinconservante = 1
        Else
            sinconservante = 0
        End If
        Dim temperatura As Double
        If TextTemperatura.Text <> "" Then
            temperatura = TextTemperatura.Text.Trim
        End If
        Dim derramadas As Integer
        If CheckDerramadas.Checked = True Then
            derramadas = 1
        Else
            derramadas = 0
        End If
        Dim desvioautorizado As Integer
        If CheckDesvio.Checked = True Then
            desvioautorizado = 1
        Else
            desvioautorizado = 0
        End If
        Dim idfactura As Long
        If TextIdFactura.Text <> "" Then
            idfactura = TextIdFactura.Text.Trim
        End If
        Dim web As Integer
        If CheckWeb.Checked = True Then
            web = 1
        Else
            web = 0
        End If
        Dim personal As Integer
        If CheckPersonal.Checked = True Then
            personal = 1
        Else
            personal = 0
        End If
        Dim mail As Integer
        If CheckEmail.Checked = True Then
            mail = 1
        Else
            mail = 0
        End If
        Dim fechaenvio As Date = DateFechaEnvio.Value.ToString("yyyy-MM-dd")
        'If TextId.Text.Trim.Length > 0 Then
        'Dim sol As New dSolicitudAnalisis()
        'Dim id As Long = CType(TextId.Text.Trim, Long)
        'Dim fecing As String
        'Dim fecenv As String
        'fecing = Format(fechaingreso, "yyyy-MM-dd")
        'fecenv = Format(fechaenvio, "yyyy-MM-dd")
        'sol.ID = id
        'sol.FECHAINGRESO = fecing
        'sol.IDPRODUCTOR = idproductor
        'If Not idtipoinforme Is Nothing Then
        ' sol.IDTIPOINFORME = idtipoinforme.ID
        'End If
        'If Not idsubinforme Is Nothing Then
        'sol.IDSUBINFORME = idsubinforme.ID
        'End If
        'If Not idtipoficha Is Nothing Then
        'sol.IDTIPOFICHA = idtipoficha.ID
        'End If
        'sol.OBSERVACIONES = observaciones
        'sol.NMUESTRAS = nmuestras
        'If Not idtecnico Is Nothing Then
        'sol.IDTECNICO = idtecnico.ID
        'End If
        'sol.SINCOLICITUD = sinsolicitud
        'sol.SINCONSERVANTE = sinconservante
        'sol.TEMPERATURA = temperatura
        'sol.DERRAMADAS = derramadas
        'sol.DESVIOAUTORIZADO = desvioautorizado
        'sol.IDFACTURA = idfactura
        'sol.WEB = web
        'sol.PERSONAL = personal
        'sol.EMAIL = email
        'sol.FECHAENVIO = fecenv
        'If (sol.modificar(Usuario)) Then
        'MsgBox("Solicitud modificada", MsgBoxStyle.Information, "Atención")
        'Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        'End If
        'Else
        'If TextIdProductor.Text.Trim.Length > 0 Then
        Dim sol As New dSolicitudAnalisis()
        Dim fecing As String
        Dim fecenv As String
        fecing = Format(fechaingreso, "yyyy-MM-dd")
        fecenv = Format(fechaenvio, "yyyy-MM-dd")
        sol.ID = id
        sol.FECHAINGRESO = fecing
        sol.IDPRODUCTOR = idproductor
        If Not idtipoinforme Is Nothing Then
            sol.IDTIPOINFORME = idtipoinforme.ID
        End If
        If Not idsubinforme Is Nothing Then
            sol.IDSUBINFORME = idsubinforme.ID
        End If
        If Not idtipoficha Is Nothing Then
            sol.IDTIPOFICHA = idtipoficha.ID
        End If
        sol.OBSERVACIONES = observaciones
        sol.NMUESTRAS = nmuestras
        If Not idtecnico Is Nothing Then
            sol.IDTECNICO = idtecnico.ID
        End If
        sol.SINCOLICITUD = sinsolicitud
        sol.SINCONSERVANTE = sinconservante
        sol.TEMPERATURA = temperatura
        sol.DERRAMADAS = derramadas
        sol.DESVIOAUTORIZADO = desvioautorizado
        sol.IDFACTURA = idfactura
        sol.WEB = web
        sol.PERSONAL = personal
        sol.EMAIL = mail
        sol.FECHAENVIO = fecenv
        sol.FECHAPROCESO = fecenv
        If (sol.guardar(Usuario)) Then
            'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
        'End If
        'End If

    End Sub
    Public Sub cargarComboSubInformes2()
        Dim si As New dSubInforme
        Dim lista As New ArrayList
        Dim idtipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        Dim texto As Long = idtipoinforme.ID
        lista = si.listarportipoinforme(texto)
        ComboSubInforme.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each si In lista
                    ComboSubInforme.Items.Add(si)
                Next
            End If
        End If
    End Sub

    Public Sub listarultimoid()
        Dim s As New dSolicitudAnalisis
        Dim lista As New ArrayList
        lista = s.listarultimoid
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    TextId.Text = s.ID
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboAgencia()
        Dim et As New dEmpresaT
        Dim lista As New ArrayList
        lista = et.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each et In lista
                    ComboAgencia.Items.Add(et)
                Next
            End If
        End If
    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        DateFechaIngreso.Value = Now()
        TextIdProductor.Text = ""
        TextProductor.Text = ""
        ComboTipoInforme.Text = ""
        ComboSubInforme.Text = ""
        ComboTipoFicha.Text = ""
        TextObservaciones.Text = ""
        TextNMuestras.Text = ""
        TextKmts.Text = ""
        ComboMuestra.Text = ""
        ComboTecnico.Text = ""
        CheckSinSolicitud.Checked = False
        CheckSinConservante.Checked = False
        TextTemperatura.Text = ""
        CheckDerramadas.Checked = False
        CheckDesvio.Checked = False
        TextIdFactura.Text = ""
        TextFactura.Text = ""
        CheckWeb.Checked = False
        CheckPersonal.Checked = False
        CheckEmail.Checked = False
        DateFechaEnvio.Value = Now()
        TextId.Focus()
        'cargarComboInformes()
        'cargarComboSubInformes()
        'cargarComboTecnicos()
        'cargarComboTipoFicha()
        'cargarComboMuestras()

    End Sub
    Private Sub actualizarTecnico1()
        Dim p As New dCliente
        Dim id As Integer = TextIdProductor.Text.Trim
        Dim tecnico As dCliente = CType(ComboTecnico.SelectedItem, dCliente)
        Dim tec As Integer = tecnico.ID
        p.ID = id
        p.actualizartecnico1(p.ID, tec, Usuario)
    End Sub
    Private Sub ComboTecnico_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboTecnico.SelectedIndexChanged
        actualizarTecnico1()
    End Sub

    Private Sub TextCaja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextCaja.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            buscarultimoenvio()
        End If

    End Sub
    Private Sub buscarultimoenvio()
        Dim e As New dEnvioCajas
        e.IDCAJA = ComboCajas.Text.Trim
        e = e.buscarultimoenvio()
        If Not e Is Nothing Then
            TextIdEnvio.Text = e.ID
            TextFrascos.Text = e.FRASCOS
            Dim c As New dCliente
            c.ID = e.IDPRODUCTOR
            c = c.buscar
            If Not c Is Nothing Then
                MsgBox("Fué enviada al cliente " & c.NOMBRE)
            End If
            TextRemito.Focus()
        Else
            'TextGradilla1.Focus()
            TextRemito.Focus()
        End If
    End Sub
    Private Sub marcarrecibido()
        Dim id As Long = 0
        If TextIdEnvio.Text <> "" Then
            id = TextIdEnvio.Text.Trim
        Else
            Dim e As New dEnvioCajas
            e.IDCAJA = ComboCajas.Text.Trim
            e = e.buscarultimoenvio()
            If Not e Is Nothing Then
                id = e.ID
            End If
        End If
        Dim agencia As dEmpresaT = CType(ComboAgencia.SelectedItem, dEmpresaT)
        Dim recibo As String = TextRemito.Text.Trim
        Dim fecharecibo As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
        Dim cliente As Long = TextIdProductor.Text
        Dim observaciones As String = TextObservaciones.Text.Trim
        'If Not ListCajas.SelectedItem Is Nothing Then
        Dim env As New dEnvioCajas()
        If ComboCajas.Text.Trim.Length > 0 Then
            Dim fec As String
            fec = Format(fecharecibo, "yyyy-MM-dd")
            env.ID = id
            If Not agencia Is Nothing Then
                env.IDAGENCIA = agencia.ID
            Else
                env.IDAGENCIA = 8
            End If
            env.RECIBO = recibo
            env.FECHARECIBO = fec
            env.CLIENTE = cliente
            env.OBSRECIBO = observaciones
            env.RECIBIDO = 1
        End If
        If (env.marcarrecibido(Usuario)) Then
            MsgBox("Caja recibida", MsgBoxStyle.Information, "Atención")
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
    End Sub
    Private Sub desmarcarrecibido()
        Dim id As Long = TextIdEnvio.Text.Trim
        'Dim agencia As dEmpresaT = CType(ComboAgencia.SelectedItem, dEmpresaT)
        'Dim recibo As String = TextRemito.Text.Trim
        'Dim fecharecibo As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
        'Dim observaciones As String = TextObservaciones.Text.Trim
        'If Not ListCajas.SelectedItem Is Nothing Then
        Dim env As New dEnvioCajas()
        If TextCaja.Text.Trim.Length > 0 Then
            'Dim fec As String
            'fec = Format(fecharecibo, "yyyy-MM-dd")
            env.ID = id
            env.IDAGENCIA = 0
            env.RECIBO = ""
            env.FECHARECIBO = "0000-00-00"
            env.OBSRECIBO = ""
            env.RECIBIDO = 0
        End If
        If (env.marcarrecibido(Usuario)) Then
            MsgBox("Registro actualizado", MsgBoxStyle.Information, "Atención")
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
    End Sub
    Private Sub solicitud_caja()
        Dim ficha As Long = TextId.Text.Trim
        Dim idenvio As Long
        If TextIdEnvio.Text <> "" Then
            idenvio = TextIdEnvio.Text.Trim
        End If
        Dim idcaja As String = ComboCajas.Text.Trim
        Dim gradilla1, gradilla2, gradilla3 As String
        If TextGradilla1.Text <> "" Then
            gradilla1 = TextGradilla1.Text.Trim
        Else
            gradilla1 = 0
        End If
        If TextGradilla2.Text <> "" Then
            gradilla2 = TextGradilla2.Text.Trim
        Else
            gradilla2 = 0
        End If
        If TextGradilla3.Text <> "" Then
            gradilla3 = TextGradilla3.Text.Trim
        Else
            gradilla3 = 0
        End If
        Dim frascos As Integer = 0
        If TextFrascos.Text.Trim <> "" Then
            frascos = TextFrascos.Text.Trim
        End If
        Dim nocolaveco As Integer
        If CheckCajas.Checked = True Then
            nocolaveco = 1
        Else
            nocolaveco = 0
        End If
        Dim sc As New dRelSolicitudCajas()
        If ComboCajas.Text.Trim.Length > 0 Then
            sc.FICHA = ficha
            sc.IDENVIO = idenvio
            sc.IDCAJA = idcaja
            sc.GRADILLA1 = gradilla1
            sc.GRADILLA2 = gradilla2
            sc.GRADILLA3 = gradilla3
            sc.FRASCOS = frascos
            sc.NOCOLAVECO = nocolaveco

        End If
        If (sc.guardar(Usuario)) Then
            Dim c As New dCajas
            Dim fechaingreso As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
            Dim fecing As String
            fecing = Format(fechaingreso, "yyyy-MM-dd")
            c.CODIGO = idcaja
            c.FECHA = fecing
            c.marcarLaboratorio(Usuario)
            c = Nothing
            'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
    End Sub

    Private Sub TextRemito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextRemito.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            'Dim c As New dCajas
            'Dim codcaja As String = ""
            'codcaja = ComboCajas.Text.Trim
            'c.CODIGO = codcaja
            'c.marcarLaboratorio(Usuario)
            'c = Nothing
            marcarrecibido()
            solicitud_caja()
            listar_solicitud_cajas()
            TextCaja.Text = ""
            TextFrascos.Text = ""
            TextRemito.Text = ""
            ComboCajas.Focus()
        End If
    End Sub
    Public Sub listar_solicitud_cajas()
        Dim sc As New dRelSolicitudCajas
        Dim lista As New ArrayList
        Dim texto As Long = TextId.Text.Trim
        lista = sc.listarporid(texto)
        ListCajas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sc In lista
                    ListCajas().Items.Add(sc)
                Next
            End If
        End If
    End Sub
    Private Sub limpiar2()
        TextCaja.Text = ""
        TextGradilla1.Text = ""
        TextGradilla2.Text = ""
        TextFrascos.Text = ""
        TextRemito.Text = ""
        ComboAgencia.Text = ""
        CheckCajas.Checked = False
        CheckFrascos.Checked = False
        ListCajas.Items.Clear()
        ListMuestras.Items.Clear()
    End Sub
    Private Sub ButtonEliminarCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminarCaja.Click
        If Not ListCajas.SelectedItem Is Nothing Then
            Dim sc As New dRelSolicitudCajas
            Dim id As Long = CType(TextIdSC.Text, Long)
            sc.ID = id
            If (sc.eliminar(Usuario)) Then
                desmarcarrecibido()
                MsgBox("Caja eliminada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        limpiar2()
        listar_solicitud_cajas()
    End Sub
    Private Sub ButtonEliminarMuestra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminarMuestra.Click
        If Not ListMuestras.SelectedItem Is Nothing Then
            Dim sm As New dRelSolicitudMuestras
            Dim id As Long = CType(TextIdSM.Text, Long)
            sm.ID = id
            If (sm.eliminar(Usuario)) Then
                MsgBox("Muestra eliminada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        TextMuestras.Text = ""
        listar_solicitud_muestras()
    End Sub
    Private Sub ListCajas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListCajas.SelectedIndexChanged
        limpiar2()
        If ListCajas.SelectedItems.Count = 1 Then
            Dim sc As dRelSolicitudCajas = CType(ListCajas.SelectedItem, dRelSolicitudCajas)
            TextIdSC.Text = sc.ID
            TextIdEnvio.Text = sc.IDENVIO
            TextCaja.Text = sc.IDCAJA
            TextGradilla1.Text = sc.GRADILLA1
            TextGradilla2.Text = sc.GRADILLA2
            TextGradilla3.Text = sc.GRADILLA3
            TextFrascos.Text = sc.FRASCOS
            TextCaja.Focus()
        End If
    End Sub
    Private Sub solicitud_muestras()
        Dim ficha As Long = TextId.Text.Trim
        Dim idtipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        Dim idmuestra As String = TextMuestras.Text.Trim
        Dim idsubinforme As dSubInforme = CType(ComboSubInforme.SelectedItem, dSubInforme)
        Dim nocolaveco As Integer
        If CheckFrascos.Checked = True Then
            nocolaveco = 1
        Else
            nocolaveco = 0
        End If
        Dim fechaingreso As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
        Dim fecing As String
        fecing = Format(fechaingreso, "yyyy-MM-dd")
        Dim fechaingreso2 As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd hh:mm:ss")
        Dim fecing2 As String
        fecing2 = Format(fechaingreso2, "yyyy-MM-dd hh:mm:ss")
        Dim sm As New dRelSolicitudMuestras()
        Dim a As New dAntibiograma
        Dim ag As New dAgua2
        Dim ag3 As New dAgua3
        Dim sp As New dSubproducto2
        Dim am As New dAmbiental
        Dim b As New dBacteriologia
        If TextMuestras.Text.Trim.Length > 0 Then
            sm.FICHA = ficha
            sm.FECHA = fecing2
            sm.IDTIPOINFORME = idtipoinforme.ID
            sm.IDMUESTRA = idmuestra
            sm.NOCOLAVECO = nocolaveco
            a.FICHA = ficha
            a.FECHASOLICITUD = fecing
            a.IDANIMAL = idmuestra
            a.MARCA = 0
            ag.FICHA = ficha
            ag.FECHAENTRADA = fecing
            ag.IDMUESTRA = idmuestra
            ag.COLIFORMESTOTALES = -1
            ag.COLIFORMESFECALES = -1
            ag.IDASPECTO = -1
            ag.IDOLOR = -1
            ag.IDCOLOR = -1
            ag.PH = -1
            ag.IDMATERIAORGANICA = -1
            ag.CONDUCTIVIDAD = -1
            ag.IDDUREZA = -1
            ag.NITRATO = -1
            ag.NITRITO = -1
            ag.HETEROTROFICOS = -1
            ag.TURBIEDAD = -1
            ag.NITRATOTIRAS = -1
            ag.NITRITOTIRAS = -1
            ag.DUREZA = -1
            ag.VOLUMENDESIEMBRA = -1
            ag.VOLUMENDESIEMBRA2 = -1
            ag.HETEROTROFICOS37 = -1
            ag.HETEROTROFICOS35 = -1
            ag.CLOROLIBRE = -1
            ag.CLORORESIDUAL = -1
            ag.PSEUDOMONASAERUGINOSA = -1
            ag.PSEUDOMONASPP = -1
            ag.ECOLI = -1
            ag.SULFITOREDUCTORES = -1
            ag.ENTEROCOCOS = -1
            ag.ESTREPTOCOCOS = -1
            ag.LOTENITRATO = -1
            ag.LOTENITRITO = -1
            ag.LOTEDUREZA = -1
            ag.MEDIOS = 0
            ag.MARCA = 0

            sp.FICHA = ficha
            sp.FECHASOLICITUD = fecing
            sp.IDMUESTRA = idmuestra
            sp.ESTAFCOAGPOSITIVO = -1
            sp.ESTAFCOAGPOSITIVO_MET = -1
            sp.CF = -1
            sp.CF_MET = -1
            sp.MOHOS = -1
            sp.MOHOS_MET = -1
            sp.LEVADURAS = -1
            sp.LEVADURAS_MET = -1
            sp.CT = -1
            sp.CT_MET = -1
            sp.ECOLI = -1
            sp.ECOLI_MET = -1
            sp.ECOLI157 = -1
            sp.ECOLI157_MET = -1
            sp.SALMONELLA = -1
            sp.SALMONELLA_MET = -1
            sp.LISTERIASPP = -1
            sp.LISTERIASPP_MET = -1
            sp.HUMEDAD = -1
            sp.HUMEDAD_MET = -1
            sp.MGRASA = -1
            sp.MGRASA_MET = -1
            sp.PH = -1
            sp.PH_MET = -1
            sp.CLORUROS = -1
            sp.CLORUROS_MET = -1
            sp.PROTEINAS = -1
            sp.PROTEINAS_MET = -1
            sp.ENTEROBACTERIAS = -1
            sp.ENTEROBACTERIAS_MET = -1
            sp.LISTERIAAMBIENTAL = -1
            sp.LISTERIAAMBIENTAL2 = -1
            sp.LISTERIAAMBIENTAL_MET = -1
            sp.ESPORANAERMESOFILO = -1
            sp.ESPORANAERMESOFILO_MET = -1
            sp.TERMOFILOS = -1
            sp.TERMOFILOS_MET = -1
            sp.PSICROTROFOS = -1
            sp.PSICROTROFOS_MET = -1
            sp.RB = -1
            sp.RB_MET = -1
            sp.TABLANUTRICIONAL = -1
            sp.TNPROTEINA = -1
            sp.TNCARBOHIDRATOS = -1
            sp.TNGRASASTOTALES = -1
            sp.TNGRASASSATURADAS = -1
            sp.TNGRASASTRANS = -1
            sp.LISTERIAMONOCITOGENES = -1
            sp.LISTERIAMONOCITOGENES_MET = -1
            sp.CENIZAS = -1
            sp.CENIZAS_MET = -1
            sp.TNSODIO = -1
            sp.TNFIBRAALIMENTICIA = -1
            sp.MARCA = 0
            am.FICHA = ficha
            am.FECHASOLICITUD = fecing
            am.FECHAPROCESO = fecing
            am.IDMUESTRA = idmuestra
            am.DETALLEMUESTRA = ""
            am.OBSERVACIONES = ""
            am.ESTADOMUESTRA = -1
            am.LISTERIAAMBIENTAL = -1
            am.LISTERIAAMBIENTAL2 = -1
            am.LISTERIAMONOCITOGENES = -1
            am.LISTERIASPP = -1
            am.LISTERIASPP2 = -1
            am.ESTAFCOAGPOSITIVO = -1
            am.ESTAFCOAGPOSITIVO2 = -1
            am.SALMONELLA = -1
            am.ENTEROBACTERIAS = -1
            am.ENTEROBACTERIAS2 = -1
            am.ECOLI = -1
            am.ECOLI2 = -1
            am.RB = -1
            am.MOHOS = -1
            am.MOHOS2 = -1
            am.LEVADURAS = -1
            am.LEVADURAS2 = -1
            am.CT = -1
            am.CT2 = -1
            am.CF = -1
            am.CF2 = -1
            am.PSEUDOMONASPP = -1
            am.PSEUDOMONASPP2 = -1
            am.MARCA = 0
            b.FICHA = ficha
            b.FECHASOLICITUD = fecing
            b.FECHAPROCESO = fecing
            b.IDMUESTRA = idmuestra
            b.RC = -1
            b.RB = -1
            b.COLIFORMES = -1
            b.TERMODURICOS = -1
            b.ESTREPTOCOCOAG = -1
            b.ESTREPTOCOCODYS = -1
            b.ESTREPTOCOCOUB = -1
            b.ESTREPTOCOCOSPP = -1
            b.ESTAFILOCOCOAU = -1
            b.ESTAPYLOCOCOCOAGNEG = -1
            b.PSICROTROFOS = -1
            b.CORYNEBACTERIUM = -1
            b.OTROS = -1
            b.OBSERVACIONES = -1
            b.MARCA = 0
        End If
        If (sm.guardar(Usuario)) Then
            'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            If idtipoinforme.ID = 4 Then
                If idsubinforme.ID <> 10 Then
                    a.guardar(Usuario)
                End If
                If idsubinforme.ID = 10 Then
                    b.guardar(Usuario)
                End If
            End If
            If idtipoinforme.ID = 3 Then
                ag.guardar(Usuario)
            End If
            If idtipoinforme.ID = 7 Then
                sp.guardar(Usuario)
            End If
            If idtipoinforme.ID = 11 Then
                am.guardar(Usuario)
            End If
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
    End Sub
    Public Sub listar_solicitud_muestras()
        Dim sm As New dRelSolicitudMuestras
        Dim lista As New ArrayList
        Dim texto As Long = TextId.Text.Trim
        Dim cuenta_muestras As Integer = 0
        lista = sm.listarporid(texto)
        ListMuestras.Items.Clear()
        If Not lista Is Nothing Then
            cuenta_muestras = lista.Count
            If lista.Count > 0 Then
                For Each sm In lista
                    ListMuestras().Items.Add(sm)
                Next
            End If
        End If
        TextNMuestras.Text = ""
        TextNMuestras.Text = cuenta_muestras
    End Sub
    Private Sub TextMuestras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextMuestras.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Dim sm As New dRelSolicitudMuestras
            Dim ficha As Long = TextId.Text
            Dim muestra As String = TextMuestras.Text.Trim
            sm.FICHA = ficha
            sm.IDMUESTRA = muestra
            sm = sm.buscarrepetidas
            If Not sm Is Nothing Then
                My.Computer.Audio.Play("c:\debug\aviso.wav")
                Dim result = MessageBox.Show("La muestra ya existe, desea agregarla?", "Atención", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    Exit Sub
                ElseIf result = DialogResult.Yes Then
                    solicitud_muestras()
                    listar_solicitud_muestras()
                    TextMuestras.Text = ""
                    TextMuestras.Focus()
                End If
            Else
                solicitud_muestras()
                listar_solicitud_muestras()
                TextMuestras.Text = ""
                TextMuestras.Focus()
            End If
        End If
    End Sub
    Private Sub ListMuestras_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListMuestras.SelectedIndexChanged
        TextMuestras.Text = ""
        If ListMuestras.SelectedItems.Count = 1 Then
            Dim sm As dRelSolicitudMuestras = CType(ListMuestras.SelectedItem, dRelSolicitudMuestras)
            TextIdSM.Text = sm.ID
            TextMuestras.Text = sm.IDMUESTRA
            TextMuestras.Focus()
        End If
    End Sub
    Private Sub ButtonBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click
        limpiar()
        Dim v As New FormBuscarSolicitud(Usuario)
        v.ShowDialog()
        If Not v.SolicitudAnalisis Is Nothing Then
            Dim sol As dSolicitudAnalisis = v.SolicitudAnalisis
            ComboTipoFicha.SelectedItem = Nothing
            Dim tf As dTipoFicha
            For Each tf In ComboTipoFicha.Items
                If tf.ID = sol.IDTIPOFICHA Then
                    ComboTipoFicha.SelectedItem = tf
                    Exit For
                End If
            Next
            TextId.Text = sol.ID
            DateFechaIngreso.Value = sol.FECHAINGRESO
            Dim p As New dCliente
            TextIdProductor.Text = sol.IDPRODUCTOR
            'Dim id As Long = CType(TextIdProductor.Text, Long)
            p.ID = Val(TextIdProductor.Text)
            p = p.buscar
            If Not p Is Nothing Then
                TextProductor.Text = p.NOMBRE
            End If
            ComboTipoInforme.SelectedItem = Nothing
            Dim ti As dTipoInforme
            For Each ti In ComboTipoInforme.Items
                If ti.ID = sol.IDTIPOINFORME Then
                    ComboTipoInforme.SelectedItem = ti
                    Exit For
                End If
            Next
            ComboSubInforme.SelectedItem = Nothing
            Dim si As dSubInforme
            For Each si In ComboSubInforme.Items
                If si.ID = sol.IDSUBINFORME Then
                    ComboSubInforme.SelectedItem = si
                    Exit For
                End If
            Next
            TextObservaciones.Text = sol.OBSERVACIONES
            TextNMuestras.Text = sol.NMUESTRAS
            TextKmts.Text = sol.KMTS
            ComboMuestra.SelectedItem = Nothing
            Dim m As dMuestras
            For Each m In ComboMuestra.Items
                If m.ID = sol.IDMUESTRA Then
                    ComboMuestra.SelectedItem = m
                    Exit For
                End If
            Next
            ComboTecnico.SelectedItem = Nothing
            Dim t As dCliente
            For Each t In ComboTecnico.Items
                If t.ID = sol.IDTECNICO Then
                    ComboTecnico.SelectedItem = t
                    Exit For
                End If
            Next
            If sol.SINCOLICITUD = 1 Then
                CheckSinSolicitud.Checked = True
            Else
                CheckSinSolicitud.Checked = False
            End If
            If sol.SINCONSERVANTE = 1 Then
                CheckSinConservante.Checked = True
            Else
                CheckSinConservante.Checked = False
            End If
            TextTemperatura.Text = sol.TEMPERATURA
            If sol.DERRAMADAS = 1 Then
                CheckDerramadas.Checked = True
            Else
                CheckDerramadas.Checked = False
            End If
            If sol.DESVIOAUTORIZADO = 1 Then
                CheckDesvio.Checked = True
            Else
                CheckDesvio.Checked = False
            End If
            Dim pr As New dCliente
            TextIdFactura.Text = sol.IDFACTURA
            'Dim idf As Long = CType(TextIdFactura.Text, Long)
            pr.ID = Val(TextIdFactura.Text)
            pr = p.buscar
            If Not p Is Nothing Then
                TextFactura.Text = pr.NOMBRE
            End If
            If sol.WEB = 1 Then
                CheckWeb.Checked = True
            Else
                CheckWeb.Checked = False
            End If
            If sol.PERSONAL = 1 Then
                CheckPersonal.Checked = True
            Else
                CheckPersonal.Checked = False
            End If
            If sol.EMAIL = 1 Then
                CheckEmail.Checked = True
            Else
                CheckEmail.Checked = False
            End If
            DateFechaEnvio.Value = sol.FECHAENVIO
        End If
        If TextId.Text <> "" Then
            If TextId.Text > 0 Then
                listar_solicitud_cajas()
                listar_solicitud_muestras()
            End If
        End If
    End Sub
    Private Sub ComboTipoInforme_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboTipoInforme.SelectedIndexChanged
        cargarComboSubInformes2()
        cargarComboMuestras()
        GroupBox4.Enabled = True
    End Sub
    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
        limpiar2()
    End Sub
    Private Sub ComboSubInforme_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboSubInforme.SelectedIndexChanged
        Dim si As New dSubInforme
        Dim idtipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        Dim idsubinforme As dSubInforme = CType(ComboSubInforme.SelectedItem, dSubInforme)
        Dim solicitud As Long = TextId.Text.Trim
        Dim idproductor As Long = TextIdProductor.Text.Trim
        Dim fecha As Date = DateFechaIngreso.Value
        Dim idsubinf As Integer = idsubinforme.ID
        If idtipoinforme.ID = 1 Then
            Dim v As New FormSolicitudControlLechero(Usuario, solicitud, idsubinf)
            v.ShowDialog()
            Dim c As New dCaravanasRfid
            Dim listacaravanas As New ArrayList
            listacaravanas = c.listarxproductor(idproductor)
            If Not listacaravanas Is Nothing Then
                If listacaravanas.Count > 0 Then
                    Dim vv As New FormCaravanasFicha(Usuario, idproductor, solicitud)
                    vv.ShowDialog()
                End If
            End If
        End If
        If idtipoinforme.ID = 3 Then
            Dim v As New FormSolicitudAgua(Usuario, solicitud, fecha)
            v.ShowDialog()
        End If
        If idtipoinforme.ID = 4 Then
            If idsubinforme.ID = 3 Then
                Dim v As New FormAntibiograma2(Usuario, solicitud)
                v.ShowDialog()
            ElseIf idsubinforme.ID = 34 Then
                Dim v As New FormAntibiograma2(Usuario, solicitud)
                v.ShowDialog()
            End If
        End If
        If idtipoinforme.ID = 5 Then
            GroupBox4.Enabled = False
            Dim v As New FormSolicitudPAL(Usuario, solicitud, idproductor)
            v.ShowDialog()
        End If
        If idtipoinforme.ID = 6 Then
            Dim v As New FormSolicitudParasitologia(Usuario, solicitud, idsubinf)
            v.ShowDialog()
        End If
        If idtipoinforme.ID = 7 Then
            Dim v As New FormSolicitudSubproductos(Usuario, solicitud, fecha, idsubinf)
            v.ShowDialog()
        End If
        If idtipoinforme.ID = 8 Then
            GroupBox4.Enabled = False
            Dim v As New FormSinaveleFicha(Usuario, solicitud)
            v.ShowDialog()
        End If
        If idtipoinforme.ID = 10 Then
            GroupBox4.Enabled = False
            idprod = TextIdProductor.Text.Trim
            Dim v As New FormSolicitudCalidadMuestras(Usuario, solicitud, idsubinf)
            v.ShowDialog()
            TextNMuestras.Text = cant_muestras
        End If
        If idtipoinforme.ID = 11 Then
            Dim v As New FormSolicitudAmbiental(Usuario, solicitud, idsubinf)
            v.ShowDialog()
        End If
        If idtipoinforme.ID = 13 Then
            GroupBox4.Enabled = False
            Dim v As New FormSolicitudNutricion(Usuario, solicitud)
            v.ShowDialog()
            TextNMuestras.Text = cant_muestras
        End If
        If idtipoinforme.ID = 14 Then
            GroupBox4.Enabled = False
            Dim v As New FormSolicitudSuelos(Usuario, solicitud)
            v.ShowDialog()
            TextNMuestras.Text = cant_muestras
        End If
    End Sub
    Private Sub ButtonGuardar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TextId.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de ficha", MsgBoxStyle.Exclamation, "Atención") : TextId.Focus() : Exit Sub
        Dim id As Long = TextId.Text.Trim
        Dim fechaingreso As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
        If TextIdProductor.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de productor", MsgBoxStyle.Exclamation, "Atención") : TextIdProductor.Focus() : Exit Sub
        Dim idproductor As Long = TextIdProductor.Text.Trim
        Dim idtipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        Dim idsubinforme As dSubInforme = CType(ComboSubInforme.SelectedItem, dSubInforme)
        Dim idtipoficha As dTipoFicha = CType(ComboTipoFicha.SelectedItem, dTipoFicha)
        Dim observaciones As String = TextObservaciones.Text.Trim
        Dim nmuestras As Integer
        If TextNMuestras.Text <> "" Then
            nmuestras = TextNMuestras.Text.Trim
        End If
        Dim kmts As Integer = 0
        If TextKmts.Text <> "" Then
            kmts = TextKmts.Text.Trim
        End If
        Dim idmuestra As dMuestras = CType(ComboMuestra.SelectedItem, dMuestras)
        Dim idtecnico As dCliente = CType(ComboTecnico.SelectedItem, dCliente)
        Dim sinsolicitud As Integer
        If CheckSinSolicitud.Checked = True Then
            sinsolicitud = 1
        Else
            sinsolicitud = 0
        End If
        Dim sinconservante As Integer
        If CheckSinConservante.Checked = True Then
            sinconservante = 1
        Else
            sinconservante = 0
        End If
        Dim temperatura As Double
        If TextTemperatura.Text <> "" Then
            temperatura = TextTemperatura.Text.Trim
        End If
        Dim derramadas As Integer
        If CheckDerramadas.Checked = True Then
            derramadas = 1
        Else
            derramadas = 0
        End If
        Dim desvioautorizado As Integer
        If CheckDesvio.Checked = True Then
            desvioautorizado = 1
        Else
            desvioautorizado = 0
        End If
        Dim idfactura As Long
        If TextIdFactura.Text <> "" Then
            idfactura = TextIdFactura.Text.Trim
        End If
        Dim web As Integer
        If CheckWeb.Checked = True Then
            web = 1
        Else
            web = 0
        End If
        Dim personal As Integer
        If CheckPersonal.Checked = True Then
            personal = 1
        Else
            personal = 0
        End If
        Dim mail As Integer
        If CheckEmail.Checked = True Then
            mail = 1
        Else
            mail = 0
        End If
        Dim fechaenvio As Date = DateFechaEnvio.Value.ToString("yyyy-MM-dd")
        If TextId.Text.Trim.Length > 0 Then
            Dim sol As New dSolicitudAnalisis()
            'Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fecing As String
            Dim fecenv As String
            fecing = Format(fechaingreso, "yyyy-MM-dd")
            fecenv = Format(fechaenvio, "yyyy-MM-dd")
            sol.ID = id
            sol.FECHAINGRESO = fecing
            sol.IDPRODUCTOR = idproductor
            If Not idtipoinforme Is Nothing Then
                sol.IDTIPOINFORME = idtipoinforme.ID
            End If
            If Not idsubinforme Is Nothing Then
                sol.IDSUBINFORME = idsubinforme.ID
            End If
            If Not idtipoficha Is Nothing Then
                sol.IDTIPOFICHA = idtipoficha.ID
            End If
            sol.OBSERVACIONES = observaciones
            sol.NMUESTRAS = nmuestras
            sol.KMTS = kmts
            If Not idmuestra Is Nothing Then
                sol.IDMUESTRA = idmuestra.ID
            End If
            If Not idtecnico Is Nothing Then
                sol.IDTECNICO = idtecnico.ID
            End If
            sol.SINCOLICITUD = sinsolicitud
            sol.SINCONSERVANTE = sinconservante
            sol.TEMPERATURA = temperatura
            sol.DERRAMADAS = derramadas
            sol.DESVIOAUTORIZADO = desvioautorizado
            sol.IDFACTURA = idfactura
            sol.WEB = web
            sol.PERSONAL = personal
            sol.EMAIL = mail
            sol.FECHAENVIO = fecenv
            If (sol.modificar(Usuario)) Then
                MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                limpiar()
                limpiar2()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            If TextIdProductor.Text.Trim.Length > 0 Then
                Dim sol As New dSolicitudAnalisis()
                Dim fecing As String
                Dim fecenv As String
                fecing = Format(fechaingreso, "yyyy-MM-dd")
                fecenv = Format(fechaenvio, "yyyy-MM-dd")
                sol.ID = id
                sol.FECHAINGRESO = fecing
                sol.IDPRODUCTOR = idproductor
                If Not idtipoinforme Is Nothing Then
                    sol.IDTIPOINFORME = idtipoinforme.ID
                End If
                If Not idsubinforme Is Nothing Then
                    sol.IDSUBINFORME = idsubinforme.ID
                End If
                If Not idtipoficha Is Nothing Then
                    sol.IDTIPOFICHA = idtipoficha.ID
                End If
                sol.OBSERVACIONES = observaciones
                sol.NMUESTRAS = nmuestras
                sol.KMTS = kmts
                If Not idtecnico Is Nothing Then
                    sol.IDTECNICO = idtecnico.ID
                End If
                sol.SINCOLICITUD = sinsolicitud
                sol.SINCONSERVANTE = sinconservante
                sol.TEMPERATURA = temperatura
                sol.DERRAMADAS = derramadas
                sol.DESVIOAUTORIZADO = desvioautorizado
                sol.IDFACTURA = idfactura
                sol.WEB = web
                sol.PERSONAL = personal
                sol.EMAIL = mail
                sol.FECHAENVIO = fecenv
                If (sol.guardar(Usuario)) Then
                    MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    limpiar()
                    limpiar2()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        'cargarLista()
        Me.Close()
    End Sub
    Private Sub FormSolicitudAnalisis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextId.Select()
    End Sub
    Private Sub TextTemperatura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextTemperatura.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(46) Or e.KeyChar = Microsoft.VisualBasic.ChrW(44) Then
            MsgBox("Ingresar solo números enteros", MsgBoxStyle.Information, "Atención")
            TextTemperatura.Text = ""
        End If
    End Sub
    Private Sub actualizardicose()
        Dim p As New dCliente
        Dim id As Integer = TextIdProductor.Text.Trim
        Dim dicose As String = TextDicose.Text.Trim
        p.ID = id
        p.actualizardicose(p.ID, dicose, Usuario)
    End Sub
    Private Sub TextDicose_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextDicose.TextChanged
        actualizardicose()
    End Sub
    Private Sub TextId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextId.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TextOtros_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextOtros.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextMuestras.Focus()
        End If
    End Sub
    Private Sub TextOtros_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextOtros.LostFocus
        If TextOtros.Text <> "" Then
            Dim ficha As String = TextId.Text.Trim
            Dim descripcion As String = TextOtros.Text.Trim

            Dim so As New dRelSolicitudOtros()
            so.FICHA = ficha
            so.DESCRIPCION = descripcion
            If (so.guardar(Usuario)) Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Private Sub TextGradilla1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextGradilla1.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextGradilla2.Focus()
        End If
    End Sub
    Private Sub TextGradilla2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextGradilla2.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextGradilla3.Focus()
        End If
    End Sub
    Private Sub TextGradilla3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextGradilla3.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextFrascos.Focus()
        End If
    End Sub
    Private Sub TextFrascos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextFrascos.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextRemito.Focus()
        End If
    End Sub
    Private Sub InsertarRegistro_com()
        Dim idnet As Long = 0
        Dim sa_ As New dSolicitudAnalisis
        sa_.ID = idficha
        sa_ = sa_.buscar
        If Not sa_ Is Nothing Then
            idnet = sa_.IDPRODUCTOR
        End If
        tipoinforme = ComboTipoInforme.Text
        idficha = TextId.Text.Trim
        If tipoinforme = "Control Lechero" Then 'SI EL TIPO DE INFORME ES DE CONTROL LECHERO
            Dim cw_com As New dControlLecheroWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            cw_com.ID_USUARIO = idproductorweb_com
            cw_com.ABONADO = 0
            cw_com.FECHA_CREADO = fechaemi
            cw_com.FECHA_EMISION = fechaemi
            cw_com.FICHA = idficha
            cw_com.ID_ESTADO = 1
            cw_com.ID_LIBRO = idficha
            If (cw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Calidad de leche" Then 'SI EL TIPO DE INFORME ES DE CALIDAD DE LECHE
            Dim cw_com As New dCalidadWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            cw_com.ID_USUARIO = idproductorweb_com
            cw_com.ABONADO = 0
            cw_com.FECHA_CREADO = fechaemi
            cw_com.FECHA_EMISION = fechaemi
            cw_com.FICHA = idficha
            cw_com.ID_ESTADO = 1
            cw_com.ID_LIBRO = idficha
            If (cw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Agua" Then 'SI EL TIPO DE INFORME ES DE AGUA
            Dim aw_com As New dAguaWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            aw_com.ID_USUARIO = idproductorweb_com
            aw_com.ABONADO = 0
            aw_com.FECHA_CREADO = fechaemi
            aw_com.FECHA_EMISION = fechaemi
            aw_com.FICHA = idficha
            aw_com.ID_ESTADO = 1
            aw_com.ID_LIBRO = idficha
            If (aw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Parasitología" Then 'SI EL TIPO DE INFORME ES DE PARASITOLOGÍA
            Dim parw_com As New dParasitologiaWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            parw_com.ID_USUARIO = idproductorweb_com
            parw_com.ABONADO = 0
            parw_com.FECHA_CREADO = fechaemi
            parw_com.FECHA_EMISION = fechaemi
            parw_com.FICHA = idficha
            parw_com.ID_ESTADO = 1
            parw_com.ID_LIBRO = idficha
            If (parw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Alimentos" Then 'SI EL TIPO DE INFORME ES DE ALIMENTOS E INDICADORES
            Dim spw_com As New dSubproductosWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            spw_com.ID_USUARIO = idproductorweb_com
            spw_com.ABONADO = 0
            spw_com.FECHA_CREADO = fechaemi
            spw_com.FECHA_EMISION = fechaemi
            spw_com.FICHA = idficha
            spw_com.ID_ESTADO = 1
            spw_com.ID_LIBRO = idficha
            If (spw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Serología" Then 'SI EL TIPO DE INFORME ES DE SEROLOGÍA
            Dim sw_com As New dSerologiaWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            sw_com.ID_USUARIO = idproductorweb_com
            sw_com.ABONADO = 0
            sw_com.FECHA_CREADO = fechaemi
            sw_com.FECHA_EMISION = fechaemi
            sw_com.FICHA = idficha
            sw_com.ID_ESTADO = 1
            sw_com.ID_LIBRO = idficha
            If (sw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Patología - Toxicología" Then 'SI EL TIPO DE INFORME ES DE PATOLOGÍA - TOXICOLOGÍA
            Dim paw_com As New dPatologiaWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            paw_com.ID_USUARIO = idproductorweb_com
            paw_com.ABONADO = 0
            paw_com.FECHA_CREADO = fechaemi
            paw_com.FECHA_EMISION = fechaemi
            paw_com.FICHA = idficha
            paw_com.ID_ESTADO = 1
            paw_com.ID_LIBRO = idficha
            If (paw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Ambiental" Then 'SI EL TIPO DE INFORME ES AMBIENTAL
            Dim aw_com As New dAmbientalWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            aw_com.ID_USUARIO = idproductorweb_com
            aw_com.ABONADO = 0
            aw_com.FECHA_CREADO = fechaemi
            aw_com.FECHA_EMISION = fechaemi
            aw_com.FICHA = idficha
            aw_com.ID_ESTADO = 1
            aw_com.ID_LIBRO = idficha
            If (aw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Lactómetros - Chequeos" Then 'SI EL TIPO DE INFORME ES DE LACTÓMETROS
            Dim lw_com As New dLactometrosWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            lw_com.ID_USUARIO = idproductorweb_com
            lw_com.ABONADO = 0
            lw_com.FECHA_CREADO = fechaemi
            lw_com.FECHA_EMISION = fechaemi
            lw_com.FICHA = idficha
            lw_com.ID_ESTADO = 1
            lw_com.ID_LIBRO = idficha
            If (lw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Nutrición" Then 'SI EL TIPO DE INFORME ES DE NUTRICIÓN
            Dim aw_com As New dAgroNutricionWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            aw_com.ID_USUARIO = idproductorweb_com
            aw_com.ABONADO = 0
            aw_com.FECHA_CREADO = fechaemi
            aw_com.FECHA_EMISION = fechaemi
            aw_com.FICHA = idficha
            aw_com.ID_ESTADO = 1
            aw_com.ID_LIBRO = idficha
            If (aw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Otros Servicios" Then 'SI EL TIPO DE INFORME ES DE OTROS SERVICIOS
            Dim osw_com As New dOtrosServiciosWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            osw_com.ID_USUARIO = idproductorweb_com
            osw_com.ABONADO = 0
            osw_com.FECHA_CREADO = fechaemi
            osw_com.FECHA_EMISION = fechaemi
            osw_com.FICHA = idficha
            osw_com.ID_ESTADO = 1
            osw_com.ID_LIBRO = idficha
            If (osw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Suelos" Then 'SI EL TIPO DE INFORME ES DE SUELOS
            Dim aw_com As New dAgroSuelosWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            aw_com.ID_USUARIO = idproductorweb_com
            aw_com.ABONADO = 0
            aw_com.FECHA_CREADO = fechaemi
            aw_com.FECHA_EMISION = fechaemi
            aw_com.FICHA = idficha
            aw_com.ID_ESTADO = 1
            aw_com.ID_LIBRO = idficha
            If (aw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Brucelosis en leche" Then 'SI EL TIPO DE INFORME ES DE BRUCELOSIS EN LECHE
            Dim bw_com As New dBrucelosisLecheWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            bw_com.ID_USUARIO = idproductorweb_com
            bw_com.ABONADO = 0
            bw_com.FECHA_CREADO = fechaemi
            bw_com.FECHA_EMISION = fechaemi
            bw_com.FICHA = idficha
            bw_com.ID_ESTADO = 1
            bw_com.ID_LIBRO = idficha
            If (bw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then 'SI EL TIPO DE INFORME ES DE BACTERIOLOGIA Y ANTIBIOGRAMA
            Dim aw_com As New dAntibiogramaWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim fecha_emision As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
            Dim fechaemi As String
            fechaemi = Format(fecha_emision, "yyyy-MM-dd")
            aw_com.ID_USUARIO = idproductorweb_com
            aw_com.ABONADO = 0
            aw_com.FECHA_CREADO = fechaemi
            aw_com.FECHA_EMISION = fechaemi
            aw_com.FICHA = idficha
            aw_com.ID_ESTADO = 1
            aw_com.ID_LIBRO = idficha
            If (aw_com.guardar()) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        '*** CREA RESULTADO EN GESTOR NUEVO *******************************************************************************************
        Dim resultado As New Dictionary(Of String, dResultado)
        Dim carpeta As String = ""
        If tipoinforme = 1 Then
            carpeta = "control_lechero"
        ElseIf tipoinforme = 3 Then
            carpeta = "agua"
        ElseIf tipoinforme = 4 Then
            carpeta = "antibiograma"
        ElseIf tipoinforme = 6 Then
            carpeta = "parasitologia"
        ElseIf tipoinforme = 7 Then
            carpeta = "productos_subproductos"
        ElseIf tipoinforme = 8 Then
            carpeta = "serologia"
        ElseIf tipoinforme = 9 Then
            carpeta = "patologia"
        ElseIf tipoinforme = 10 Then
            carpeta = "calidad_de_leche"
        ElseIf tipoinforme = 11 Then
            carpeta = "ambiental"
        ElseIf tipoinforme = 13 Then
            carpeta = "agro_nutricion"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            carpeta = "agro_suelos"
        ElseIf tipoinforme = 15 Then
            carpeta = "brucelosis_leche"
        End If
        Dim rg As New dResultado
        Dim fechaemi2 As String
        Dim fecha_emision2 As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
        fechaemi2 = Format(fecha_emision2, "yyyy-MM-dd")

        rg.ficha = idficha
        rg.comentarios = ""
        rg.idnet_usuario = idnet
        rg.abonado = True
        rg.fecha_creado = fechaemi2
        rg.fecha_emision = fechaemi2
        rg.path_excel = ""
        rg.path_pdf = ""
        rg.path_csv = ""
        rg.id_estado = 1
        rg.id_libro = idficha
        rg.idnet_tipo_informe = tipoinforme
        resultado.Add("resultado", rg)

        Dim parameters As String = JsonConvert.SerializeObject(resultado, Formatting.None)

        Dim status As HttpStatusCode = HttpStatusCode.ExpectationFailed
        Dim response As Byte() = PostResponse("http://colaveco-gestor.herokuapp.com/resultados", "POST", parameters, status)
        'Dim responseString As String
        'If response IsNot Nothing Then
        '    responseString = System.Text.Encoding.UTF8.GetString(response)
        'Else
        '    responseString = "NULL"
        'End If
        'Console.WriteLine("Response Code: " & status)
        'Console.WriteLine("Response String: " & responseString)
        ''resultado.Add("resultado", rg)
        '****************************************************************************************************************************

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
    Private Sub enviomail()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        '******************************************************************************************************************************************
        Dim ficha As String = TextId.Text.Trim
        Dim fecha As Date = DateFechaIngreso.Value
        Dim nmuestras As String
        If TextNMuestras.Text <> "" Then
            nmuestras = TextNMuestras.Text.Trim
        Else
            nmuestras = ""
        End If
        Dim muestra As String = ComboMuestra.Text
        Dim solicitud As String = ""
        Dim texto As String = ""
        Dim texto2 As String = ""
        Dim texto3 As String = ""
        Dim tipoinforme As String = ComboTipoInforme.Text
        Dim subtipoinforme As String = ComboSubInforme.Text
        Dim observaciones As String = TextObservaciones.Text.Trim
        Dim titulo As String = ""
        Dim enc_ficha As String = ""
        Dim enc_fecha As String = ""
        Dim enc_cliente As String = ""
        Dim enc_muestras As String = ""
        Dim enc_muestrade As String = ""
        Dim cuerpo_analisis As String = ""
        Dim cuerpo_muestras As String = ""
        Dim pie_observaciones As String = ""
        Dim pie_estadosolicitud As String = "En nuestro sitio web http://www.colaveco.com.uy/gestor, puede ver el estado de su solicitud."
        Dim pro As New dCliente
        Dim nombre_productor As String = ""
        pro.ID = TextIdProductor.Text.Trim
        pro = pro.buscar
        If Not pro Is Nothing Then
            nombre_productor = pro.NOMBRE
        Else
            nombre_productor = ""
        End If
        Dim sm As New dRelSolicitudMuestras
        Dim spal As New dSolicitudPAL
        Dim csm As New dCalidadSolicitudMuestra
        Dim cs As New dControlSolicitud
        Dim a2 As New dAntibiograma2
        Dim sn As New dSolicitudNutricion
        Dim ss As New dSolicitudSuelos
        Dim bl As New dBrucelosis
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim lista4 As New ArrayList
        Dim lista5 As New ArrayList
        Dim lista6 As New ArrayList
        Dim lista7 As New ArrayList
        Dim lista10 As New ArrayList
        Dim listabl As New ArrayList
        Dim listanutricion As New ArrayList
        Dim listasuelos As New ArrayList
        lista4 = sm.listarporficha(ficha)
        lista5 = csm.listarporsolicitud3(ficha)
        lista6 = cs.listarporsolicitud(ficha)
        lista7 = a2.listarporsolicitud(ficha)
        lista10 = spal.listarporsolicitud(ficha)
        listanutricion = sn.listarporsolicitud(ficha)
        listasuelos = ss.listarporsolicitud(ficha)
        listabl = sm.listarporficha(ficha)
        ' SI ES PRODUCTOS LÁCTEOS ********************************************************************************
        If tipoinforme = "Alimentos" Then
            Dim sp As New dSubproducto
            Dim lista As New ArrayList
            texto = ""
            lista = sp.listarporsolicitud(ficha)
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each sp In lista
                        If sp.ESTAFCOAGPOSITIVO = 1 Then
                            texto = texto + " - Estaf. Coag. Positivo"
                        End If
                        If sp.CF = 1 Then
                            texto = texto + " - CF"
                        End If
                        If sp.MOHOSYLEVADURAS = 1 Then
                            texto = texto + " - Mohos y levaduras"
                        End If
                        If sp.CT = 1 Then
                            texto = texto + " - Coliformes Totales"
                        End If
                        If sp.ECOLI = 1 Then
                            texto = texto + " - E. Coli"
                        End If
                        If sp.SALMONELLA = 1 Then
                            texto = texto + " - Salmonella"
                        End If
                        If sp.LISTERIASPP = 1 Then
                            texto = texto + " - Listeria spp"
                        End If
                        If sp.HUMEDAD = 1 Then
                            texto = texto + " - Humedad"
                        End If
                        If sp.MGRASA = 1 Then
                            texto = texto + " - M. Grasa"
                        End If
                        If sp.PH = 1 Then
                            texto = texto + " - pH"
                        End If
                        If sp.CLORUROS = 1 Then
                            texto = texto + " - Cloruros"
                        End If
                        If sp.PROTEINAS = 1 Then
                            texto = texto + " - Proteínas"
                        End If
                        If sp.ENTEROBACTERIAS = 1 Then
                            texto = texto + " - Enterobacterias"
                        End If
                        If sp.LISTERIAAMBIENTAL = 1 Then
                            texto = texto + " - Listeria Ambiental"
                        End If
                        If sp.ESPORANAERMESOFILO = 1 Then
                            texto = texto + " - Espor. Anaer. Mesófilos"
                        End If
                        If sp.TERMOFILOS = 1 Then
                            texto = texto + " - Termodúricos"
                        End If
                        If sp.PSICROTROFOS = 1 Then
                            texto = texto + " - Psicrótrofos"
                        End If
                        If sp.RB = 1 Then
                            texto = texto + " - RB"
                        End If
                        If sp.TABLANUTRICIONAL = 1 Then
                            texto = texto + " - Tabla nutricional"
                        End If
                        If sp.LISTERIAMONOCITOGENES = 1 Then
                            texto = texto + " - Listeria monocitógenes"
                        End If
                        If sp.CENIZAS = 1 Then
                            texto = texto + " - Cenizas"
                        End If
                    Next
                End If
            End If
            ' SI ES AGUA ********************************************************************************
        ElseIf tipoinforme = "Agua" Then
            Dim a1 As New dAgua
            texto = ""
            a1.ID = ficha
            a1 = a1.buscar()
            texto = ComboSubInforme.Text
            If a1.HET22 = 1 Then
                texto = texto & " " & " - Heterotróficos 22"
            End If
            If a1.HET35 = 1 Then
                texto = texto & " " & " - Heterotróficos 35"
            End If
            If a1.HET37 = 1 Then
                texto = texto & " " & " - Heterotróficos 37"
            End If
            If a1.CLORO = 1 Then
                texto = texto & " " & " - Cloro"
            End If
            If a1.CONDUCTIVIDAD = 1 Then
                texto = texto & " " & " - Conductividad"
            End If
            If a1.PH = 1 Then
                texto = texto & " " & " - pH"
            End If
            If a1.ECOLI = 1 Then
                texto = texto & " " & " - Ecoli"
            End If
            ' SI ES CALIDAD DE LECHE ********************************************************************************
        ElseIf tipoinforme = "Calidad de leche" Then
            Dim rb As Integer = 0
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim criosc As Integer = 0
            Dim inh As Integer = 0
            Dim espor As Integer = 0
            Dim urea As Integer = 0
            Dim term As Integer = 0
            Dim psicr As Integer = 0
            Dim crioscopo As Integer = 0
            texto = ""
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        If csm.RB = 1 Then
                            rb = 1
                        End If
                        If csm.RC = 1 Then
                            rc = 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            criosc = 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            inh = 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            espor = 1
                        End If
                        If csm.UREA = 1 Then
                            urea = 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            term = 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            psicr = 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            crioscopo = 1
                        End If
                    Next
                End If
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If criosc = 1 Then
                texto = texto + " - Crioscopía"
            End If
            If inh = 1 Then
                texto = texto + " - Inhibidores"
            End If
            If espor = 1 Then
                texto = texto + " - Esporulados"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            If term = 1 Then
                texto = texto + " - Termófilos"
            End If
            If psicr = 1 Then
                texto = texto + " - Psicrótrofos"
            End If
            If crioscopo = 1 Then
                texto = texto + " - Crioscopía (crióscopo)"
            End If
            ' SI ES CONTROL LECHERO ********************************************************************************
        ElseIf tipoinforme = "Control Lechero" Then
            Dim rc As Integer = 0
            Dim comp As Integer = 0
            Dim urea As Integer = 0
            texto = ""
            If Not lista6 Is Nothing Then
                If lista6.Count > 0 Then
                    For Each cs In lista6
                        If cs.RC = 1 Then
                            rc = 1
                        End If
                        If cs.COMPOSICION = 1 Then
                            comp = 1
                        End If
                        If cs.UREA = 1 Then
                            urea = 1
                        End If
                    Next
                End If
            End If
            If rc = 1 Then
                texto = texto + " - RC"
            End If
            If comp = 1 Then
                texto = texto + " - Composición"
            End If
            If urea = 1 Then
                texto = texto + " - Urea"
            End If
            ' SI ANTIBIOGRAMA ********************************************************************************
        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            Dim aislamiento As Integer = 0
            Dim antibiograma As Integer = 0
            texto = ""
            If Not lista7 Is Nothing Then
                If lista7.Count > 0 Then
                    For Each a2 In lista7
                        If a2.AISLAMIENTO = 1 Then
                            aislamiento = 1
                        End If
                        If a2.ANTIBIOGRAMA = 1 Then
                            antibiograma = 1
                        End If
                    Next
                End If
            End If
            If aislamiento = 1 Then
                texto = texto + " - Aislamiento"
            End If
            If antibiograma = 1 Then
                texto = texto + " - Antibiograma"
            End If
            ' SI ES AMBIENTAL ********************************************************************************
        ElseIf tipoinforme = "Ambiental" Then
            Dim ambs As New dAmbientalSolicitud
            Dim lista8 As ArrayList
            lista8 = ambs.listarporsolicitud(ficha)
            Dim enterobacterias As Integer = 0
            Dim listambiental As Integer = 0
            Dim listmono As Integer = 0
            Dim salmonella As Integer = 0
            Dim ecoli As Integer = 0
            Dim mohosylevaduras As Integer = 0
            Dim rb As Integer = 0
            Dim ct As Integer = 0
            Dim cf As Integer = 0
            Dim pseudomonaspp As Integer = 0
            texto = ""
            If Not lista8 Is Nothing Then
                If lista8.Count > 0 Then
                    For Each ambs In lista8
                        If ambs.ENTEROBACTERIAS = 1 Then
                            enterobacterias = 1
                        End If
                        If ambs.LISTAMBIENTAL = 1 Then
                            listambiental = 1
                        End If
                        If ambs.LISTMONO = 1 Then
                            listmono = 1
                        End If
                        If ambs.SALMONELLA = 1 Then
                            salmonella = 1
                        End If
                        If ambs.ECOLI = 1 Then
                            ecoli = 1
                        End If
                        If ambs.MOHOSYLEVADURAS = 1 Then
                            mohosylevaduras = 1
                        End If
                        If ambs.RB = 1 Then
                            rb = 1
                        End If
                        If ambs.CT = 1 Then
                            ct = 1
                        End If
                        If ambs.CF = 1 Then
                            cf = 1
                        End If
                        If ambs.PSEUDOMONASPP = 1 Then
                            pseudomonaspp = 1
                        End If
                    Next
                End If
            End If
            If enterobacterias = 1 Then
                texto = texto + " - Enterobacterias"
            End If
            If listambiental = 1 Then
                texto = texto + " - Listeria ambiental"
            End If
            If listmono = 1 Then
                texto = texto + " - Listeria monocitógenes"
            End If
            If salmonella = 1 Then
                texto = texto + " - Salmonella"
            End If
            If ecoli = 1 Then
                texto = texto + " - E. Coli"
            End If
            If mohosylevaduras = 1 Then
                texto = texto + " - Mohos y levaduras"
            End If
            If rb = 1 Then
                texto = texto + " - RB"
            End If
            If ct = 1 Then
                texto = texto + " - Coliformes totales"
            End If
            If cf = 1 Then
                texto = texto + " - CF"
            End If
            If pseudomonaspp = 1 Then
                texto = texto + " - Pseudomona spp"
            End If
            ' SI ES PARASITOLOGÍA ********************************************************************************
        ElseIf tipoinforme = "Parasitología" Then
            Dim p As New dParasitologiaSolicitud
            Dim lista9 As ArrayList
            lista9 = p.listarporsolicitud(ficha)
            Dim gastrointestinales As Integer = 0
            Dim fasciola As Integer = 0
            Dim coccidias As Integer = 0
            texto = ""
            If Not lista9 Is Nothing Then
                If lista9.Count > 0 Then
                    For Each p In lista9
                        If p.GASTROINTESTINALES = 1 Then
                            gastrointestinales = 1
                        End If
                        If p.FASCIOLA = 1 Then
                            fasciola = 1
                        End If
                        If p.COCCIDIAS = 1 Then
                            coccidias = 1
                        End If
                    Next
                End If
            End If
            If gastrointestinales = 1 Then
                texto = texto + " - Gastrointestinales"
            End If
            If fasciola = 1 Then
                texto = texto + " - Fasciola"
            End If
            If coccidias = 1 Then
                texto = texto + " - Coccidias"
            End If
            ' SI ES NUTRICIÓN ********************************************************************************
        ElseIf tipoinforme = "Nutrición" Then
            Dim mga As Integer = 0
            Dim mgb As Integer = 0
            Dim ensilados As Integer = 0
            Dim pasturas As Integer = 0
            Dim extetereo As Integer = 0
            Dim nida As Integer = 0
            texto = ""
            If Not listanutricion Is Nothing Then
                If listanutricion.Count > 0 Then
                    For Each sn In listanutricion
                        texto = texto & " // " & sn.MUESTRA & " - "
                        If sn.MGA = 1 Then
                            texto = texto & "MGA - "
                        End If
                        If sn.MGB = 1 Then
                            texto = texto & "MGB - "
                        End If
                        If sn.ENSILADOS = 1 Then
                            texto = texto & "Ensilados - "
                        End If
                        If sn.PASTURAS = 1 Then
                            texto = texto & "Pasturas - "
                        End If
                        If sn.EXTETEREO = 1 Then
                            texto = texto & "Extracto etéreo - "
                        End If
                        If sn.NIDA = 1 Then
                            texto = texto & "NIDA - "
                        End If
                    Next
                End If
            End If
            ' SI ES SUELOS ********************************************************************************
        ElseIf tipoinforme = "Suelos" Then
            Dim nitratos As Integer = 0
            Dim mineralizacion As Integer = 0
            Dim fosforobray As Integer = 0
            Dim fosforocitrico As Integer = 0
            Dim phagua As Integer = 0
            Dim phkci As Integer = 0
            Dim materiaorg As Integer = 0
            Dim potasioint As Integer = 0
            Dim sulfatos As Integer = 0
            Dim nitrogenovegetal As Integer = 0
            texto = ""
            If Not listasuelos Is Nothing Then
                If listasuelos.Count > 0 Then
                    For Each ss In listasuelos
                        texto = texto & " // " & ss.MUESTRA & " - "
                        If ss.NITRATOS = 1 Then
                            texto = texto & "Nitratos - "
                        End If
                        If ss.MINERALIZACION = 1 Then
                            texto = texto & "Mineralización - "
                        End If
                        If ss.FOSFOROBRAY = 1 Then
                            texto = texto & "Fósforo Bray I - "
                        End If
                        If ss.FOSFOROCITRICO = 1 Then
                            texto = texto & "Fósforo Ac.Cítrico - "
                        End If
                        If ss.PHAGUA = 1 Then
                            texto = texto & "pH Agua - "
                        End If
                        If ss.PHKCI = 1 Then
                            texto = texto & "pH KCI - "
                        End If
                        If ss.MATERIAORG = 1 Then
                            texto = texto & "Materia orgánica - "
                        End If
                        If ss.POTASIOINT = 1 Then
                            texto = texto & "Potasio intercambiable - "
                        End If
                        If ss.SULFATOS = 1 Then
                            texto = texto & "Sulfatos - "
                        End If
                        If ss.NITROGENOVEGETAL = 1 Then
                            texto = texto & "Nitrógeno vegetal - "
                        End If
                    Next
                End If
            End If
        End If
        '*** LISTADO DE MUESTRAS *********************************************************************************
        ' SI ES ALIMENTOS ********************************************************************************
        If tipoinforme = "Alimentos" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            ' SI ES AGUA ********************************************************************************
        ElseIf tipoinforme = "Agua" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            ' SI ES CALIDAD ********************************************************************************
        ElseIf tipoinforme = "Calidad de leche" Then
            texto2 = ""
            Dim cuenta_rb As Integer = 0
            Dim cuenta_rc As Integer = 0
            Dim cuenta_comp As Integer = 0
            Dim cuenta_criosc As Integer = 0
            Dim cuenta_inhib As Integer = 0
            Dim cuenta_espor As Integer = 0
            Dim cuenta_urea As Integer = 0
            Dim cuenta_termo As Integer = 0
            Dim cuenta_psicro As Integer = 0
            Dim cuenta_criosc_criosc As Integer = 0
            Dim cuenta_caseina As Integer = 0
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each csm In lista5
                        texto2 = texto2 + csm.MUESTRA
                        If csm.RB = 1 Then
                            cuenta_rb = cuenta_rb + 1
                        End If
                        If csm.RC = 1 Then
                            cuenta_rc = cuenta_rc + 1
                        End If
                        If csm.COMPOSICION = 1 Then
                            cuenta_comp = cuenta_comp + 1
                        End If
                        If csm.CRIOSCOPIA = 1 Then
                            cuenta_criosc = cuenta_criosc + 1
                        End If
                        If csm.INHIBIDORES = 1 Then
                            cuenta_inhib = cuenta_inhib + 1
                        End If
                        If csm.ESPORULADOS = 1 Then
                            cuenta_espor = cuenta_espor + 1
                        End If
                        If csm.UREA = 1 Then
                            cuenta_urea = cuenta_urea + 1
                        End If
                        If csm.TERMOFILOS = 1 Then
                            cuenta_termo = cuenta_termo + 1
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            cuenta_psicro = cuenta_psicro + 1
                        End If
                        If csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                            cuenta_criosc_criosc = cuenta_criosc_criosc + 1
                        End If
                        If csm.CASEINA = 1 Then
                            cuenta_caseina = cuenta_caseina + 1
                        End If
                        texto2 = texto2 + " - "
                    Next
                End If
            End If
            If cuenta_rb > 0 Then
                texto3 = texto3 & cuenta_rb & " RB - "
            End If
            If cuenta_rc > 0 Then
                texto3 = texto3 & cuenta_rc & " RC - "
            End If
            If cuenta_comp > 0 Then
                texto3 = texto3 & cuenta_comp & " Comp. - "
            End If
            If cuenta_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc & " Criosc. - "
            End If
            If cuenta_inhib > 0 Then
                texto3 = texto3 & cuenta_inhib & " Inhib. - "
            End If
            If cuenta_espor > 0 Then
                texto3 = texto3 & cuenta_espor & " Espor. - "
            End If
            If cuenta_urea > 0 Then
                texto3 = texto3 & cuenta_urea & " Urea - "
            End If
            If cuenta_termo > 0 Then
                texto3 = texto3 & cuenta_termo & " Termof. - "
            End If
            If cuenta_psicro > 0 Then
                texto3 = texto3 & cuenta_psicro & " Psicro. - "
            End If
            If cuenta_criosc_criosc > 0 Then
                texto3 = texto3 & cuenta_criosc_criosc & " Criosc.(Crióscopo) - "
            End If
            If cuenta_caseina > 0 Then
                texto3 = texto3 & cuenta_caseina & " Caseina - "
            End If
            ' SI ES CONTROL LECHERO ********************************************************************************
        ElseIf tipoinforme = "Control Lechero" Then
            texto2 = ""
            ' SI ES ANTIBIOGRAMA ********************************************************************************
        ElseIf tipoinforme = "Bacteriología y Antibiograma" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            ' SI ES AMBIENTAL ********************************************************************************
        ElseIf tipoinforme = "Ambiental" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            ' SI ES PARASITOLOGÍA ********************************************************************************
        ElseIf tipoinforme = "Parasitología" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            ' SI ES PAL ********************************************************************************
        ElseIf tipoinforme = "PAL" Then
            texto2 = ""
            If Not lista10 Is Nothing Then
                If lista10.Count > 0 Then
                    For Each spal In lista10
                        texto2 = texto2 + spal.MATRICULA & " - "
                    Next
                End If
            End If
            Dim solpal As New dSolicitudPAL
            solpal.FICHA = ficha
            solpal = solpal.buscar
            If Not solpal Is Nothing Then
                ' x1hoja.Cells(fila, columna).Formula = "Vacas: " & solpal.VACAS & " - " & "Fecha extracción: " & solpal.FECHAEXT
            End If
            '********************************************************************************************************************
            ' SI ES BRUCELOSIS LECHE ********************************************************************************
        ElseIf tipoinforme = "Brucelosis en leche" Then
            texto2 = ""
            If Not listabl Is Nothing Then
                If listabl.Count > 0 Then
                    For Each sm In listabl
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
        End If
        '********************************************************************************************************************
        If tipoinforme = "Nutrición" Or tipoinforme = "Suelos" Then
            If email <> "" Then
                'CONFIGURACIÓN DEL STMP 
                _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "-]$]Mo8z1kr3")
                _SMTP.Host = "170.249.199.66"
                _SMTP.Port = 25
                _SMTP.EnableSsl = False

                ' CONFIGURACION DEL MENSAJE 
                _Message.[To].Add(LTrim(email))
                _Message.[To].Add(LTrim("envios@colaveco.com.uy"))
                'Cuenta de Correo al que se le quiere enviar el e-mail 
                _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
                'Quien lo envía 
                _Message.Subject = "Solicitud de análisis"
                'Sujeto del e-mail 
                _Message.SubjectEncoding = System.Text.Encoding.UTF8
                'Codificacion 
                _Message.Body = "Ha ingresado una solicitud con el número" & " " & ficha & vbCrLf _
                & "Fecha de recepción: " & fecha & "." & vbCrLf _
                & "A nombre de: " & nombre_productor & "." & vbCrLf _
                & "Muestras ingresadas: " & nmuestras & "." & vbCrLf _
                & "Tipo de muestra: " & muestra & "." & vbCrLf _
                & "Análisis requerido: " & tipoinforme & "." & vbCrLf _
                & "Subtipo: " & subtipoinforme & "." & vbCrLf _
                & vbCrLf _
                & texto & vbCrLf _
                & vbCrLf _
                & "Observaciones:" & vbCrLf _
                & observaciones & vbCrLf _
                & vbCrLf _
                & "En nuestro sitio web, http://www.colaveco.com.uy/gestor, puede ver el estado de su solicitud." & vbCrLf _
                & "Gracias." & vbCrLf _
                & "COLAVECO"
                'contenido del mail 
                _Message.BodyEncoding = System.Text.Encoding.UTF8 '
                _Message.Priority = System.Net.Mail.MailPriority.Normal
                _Message.IsBodyHtml = False
                ' ADICION DE DATOS ADJUNTOS ‘
                Try
                    _SMTP.Send(_Message)
                Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
                End Try
            End If
            email = ""
            nficha = ""
        Else
            If email <> "" Then
                'CONFIGURACIÓN DEL STMP 
                _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "-]$]Mo8z1kr3")
                _SMTP.Host = "170.249.199.66"
                _SMTP.Port = 25
                _SMTP.EnableSsl = False

                ' CONFIGURACION DEL MENSAJE 
                _Message.[To].Add(LTrim(email))
                _Message.[To].Add("envios@colaveco.com.uy")
                'Cuenta de Correo al que se le quiere enviar el e-mail 
                _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
                'Quien lo envía 
                _Message.Subject = "Solicitud de análisis"
                'Sujeto del e-mail 
                _Message.SubjectEncoding = System.Text.Encoding.UTF8
                'Codificacion 
                _Message.Body = "Ha ingresado una solicitud con el número" & " " & ficha & vbCrLf _
                & "Fecha/Hora de recepción: " & fecha & "." & vbCrLf _
                & "A nombre de: " & nombre_productor & "." & vbCrLf _
                & "Muestras ingresadas: " & nmuestras & "." & vbCrLf _
                & "Tipo de muestra: " & muestra & "." & vbCrLf _
                & "Análisis requerido: " & tipoinforme & "." & vbCrLf _
                & "Subtipo: " & subtipoinforme & "." & vbCrLf _
                & vbCrLf _
                & texto & vbCrLf _
                & vbCrLf _
                & "Identificación de las muestras:" & vbCrLf _
                & texto2 & vbCrLf _
                & vbCrLf _
                & "Observaciones:" & vbCrLf _
                & observaciones & vbCrLf _
                & vbCrLf _
                & "En nuestro sitio web, http://www.colaveco.com.uy/gestor, puede ver el estado de su solicitud." & vbCrLf _
                & "Gracias." & vbCrLf & vbCrLf _
                & "COLAVECO" & vbCrLf _
                & "Parque El Retiro - Nueva Helvecia - Tel/Fax: 45545311/45545975/45546838" & vbCrLf _
                & "Email: colaveco@gmail.com - web: http://www.colaveco.com.uy" & vbCrLf & vbCrLf _
                & "-------------------------------------------------------------------------------------" & vbCrLf _
                & "Cuando el cliente solicite suspender el servicio ya presupuestado y en ejecución, o una parte del mismo," & vbCrLf _
                & "los costos de las actividades ya realizadas en el momento de la suspensión deberán pagarse."
                'contenido del mail 
                _Message.BodyEncoding = System.Text.Encoding.UTF8 '
                _Message.Priority = System.Net.Mail.MailPriority.Normal
                _Message.IsBodyHtml = False
                ' ADICION DE DATOS ADJUNTOS ‘
                Try
                    _SMTP.Send(_Message)
                Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
                End Try
            End If
            email = ""
            nficha = ""
        End If
    End Sub
    Private Sub enviomail_no_se_usa_mas()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim sa As New dSolicitudAnalisis
        Dim p As New dCliente
        Dim ti As New dTipoInforme
        Dim si As New dSubInforme
        Dim tm As New dMuestras
        Dim nombre_productor As String = ""
        Dim tipo_analisis As String = ""
        Dim subtipo As String = ""
        Dim cantmuestras As String = ""
        Dim tipo_muestra As String = ""
        nficha = TextId.Text.Trim
        sa.ID = nficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            p.ID = sa.IDPRODUCTOR
            p = p.buscar
            If Not p Is Nothing Then
                nombre_productor = p.NOMBRE
            End If
            ti.ID = sa.IDTIPOINFORME
            ti = ti.buscar
            If Not ti Is Nothing Then
                tipo_analisis = ti.NOMBRE
            End If
            si.ID = sa.IDSUBINFORME
            si = si.buscar
            If Not si Is Nothing Then
                subtipo = si.NOMBRE
            End If
            If sa.NMUESTRAS = 0 Then
                cantmuestras = "-"
            Else
                cantmuestras = sa.NMUESTRAS
            End If
            tm.ID = sa.IDMUESTRA
            tm = tm.buscar
            If Not tm Is Nothing Then
                tipo_muestra = tm.NOMBRE
            End If
        End If
        If email <> "" Then
            'CONFIGURACIÓN DEL STMP 
            _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "-]$]Mo8z1kr3")
            _SMTP.Host = "170.249.199.66"
            _SMTP.Port = 25
            _SMTP.EnableSsl = False

            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com")
            _Message.[To].Add(LTrim(email))
            _Message.[To].Add("envios@colaveco.com.uy")
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Solicitud de análisis"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            _Message.Body = "A ingresado una solicitud con el número" & " " & nficha & vbCrLf _
            & "A nombre de: " & nombre_productor & "." & vbCrLf _
            & "Tipo de análisis: " & tipo_analisis & "." & vbCrLf _
            & "Subtipo: " & subtipo & "." & vbCrLf _
            & "Tipo de muestra: " & tipo_muestra & "." & vbCrLf _
            & "Muestras ingresadas: " & cantmuestras & "." & vbCrLf & vbCrLf _
            & "En nuestro sitio web, http://www.colaveco.com.uy/gestor, puede ver el estado de su solicitud." & vbCrLf _
            & "Gracias." & vbCrLf _
            & "COLAVECO"
            '_Message.Body = "Su solicitud de análisis Nº " & " " & nficha & ", " & "ha ingresado correctamente al sistema. Gracias."
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            'Dim _File As String = My.Application.Info.DirectoryPath & "archivo" 'archivo que se quiere adjuntar ‘
            'Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            '_Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                'MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""
        nficha = ""
    End Sub
    Private Sub enviosms()
        Dim num1 As String = ""
        Dim num2 As String = ""
        Dim email1 As String = ""
        Dim email2 As String = ""
        Dim sms As String = ""
        Dim sms1 As String = ""
        Dim sms2 As String = ""
        Dim cel1 As String = ""
        Dim cel2 As String = ""
        Dim largotexto As Integer = 0
        Dim celular1 As String = ""
        Dim celular2 As String = ""
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim texto As String = celular
        Dim cantcaracteres As Integer = Len(texto)
        If celular <> "" Then
            largotexto = celular.Length
        End If
        nficha = TextId.Text.Trim
        Dim posicion As Integer
        Dim posicion1 As Integer
        Dim posicion2 As Integer
        posicion = InStr(celular, ",")
        If posicion > 0 Then
            posicion1 = posicion - 1
            posicion2 = posicion + 1
            cel1 = Mid(celular, 1, posicion1)
            cel2 = Mid(celular, posicion2, largotexto)
            'If Mid(cel1, 1, 2) = "09" Then
            '    celular1 = cel1.Remove(0, 2)
            'Else
            celular1 = cel1
            'End If
            email = celular1
            num1 = Mid(celular1, 3, 1)
            If num1 = "9" Or num1 = "8" Or num1 = "1" Or num1 = "2" Then
                'ancel es numero  + pin
                sms1 = email & "@antelinfo.com.uy"
            ElseIf num1 = "3" Or num1 = "4" Or num1 = "5" Then
                'movistar es numero (sin 0 inicial + pin)
                If Mid(celular, 1, 1) = "0" Then
                    celular1 = celular.Remove(0, 1)
                End If
                email = celular1
                sms1 = email & "@sms.movistar.com.uy"
            ElseIf num1 = "6" Or num1 = "7" Then
                'claro es numero (sin 0 inicial sin pin)
                If Mid(celular, 1, 1) = "0" Then
                    celular2 = celular.Remove(0, 1)
                End If
                email = celular1
                sms1 = email & "@sms.ctimovil.com.uy"
            End If
            '*****************************************
            'If Mid(cel2, 1, 2) = "09" Then
            '    celular2 = cel2.Remove(0, 2)
            'Else
            celular2 = cel2
            'End If
            email2 = celular2
            num2 = Mid(celular2, 1, 1)
            If num2 = "9" Or num2 = "8" Or num2 = "1" Or num2 = "2" Then
                'ancel es numero (sin 09 inicial + pin)
                sms2 = email2 & "@antelinfo.com.uy"
            ElseIf num2 = "3" Or num2 = "4" Or num2 = "5" Then
                'movistar es numero (sin 0 inicial + pin)
                If Mid(celular2, 1, 1) = "0" Then
                    celular2 = celular2.Remove(0, 1)
                End If
                email2 = celular2
                sms2 = email2 & "@sms.movistar.com.uy"
            ElseIf num2 = "6" Or num2 = "7" Then
                'claro es numero (sin 0 inicial sin pin)
                If Mid(celular2, 1, 1) = "0" Then
                    celular2 = celular2.Remove(0, 1)
                End If
                email2 = celular2
                sms2 = email2 & "@sms.ctimovil.com.uy"
            End If
            sms = sms1 & "," & sms2
        Else
            'Dim celular As String = ""
            'celular = TextCelular1.Text.Trim
            nficha = TextId.Text.Trim
            'If Mid(celular, 1, 2) = "09" Then
            '    celular2 = celular.Remove(0, 2)
            'Else
            celular2 = celular
            'End If
            email = celular2
            num1 = Mid(celular2, 1, 1)
            If num1 = "9" Or num1 = "8" Or num1 = "1" Or num1 = "2" Then
                'ancel es numero (sin 09 inicial + pin)
                sms = email & "@antelinfo.com.uy"
            ElseIf num1 = "3" Or num1 = "4" Or num1 = "5" Then
                'movistar es numero (sin 0 inicial + pin)
                If Mid(celular, 1, 1) = "0" Then
                    celular2 = celular.Remove(0, 1)
                End If
                email = celular2
                sms = email & "@sms.movistar.com.uy"
            ElseIf num1 = "6" Or num1 = "7" Then
                'claro es numero (sin 0 inicial sin pin)
                If Mid(celular, 1, 1) = "0" Then
                    celular2 = celular.Remove(0, 1)
                End If
                email = celular2
                sms = email & "@sms.ctimovil.com.uy"
            End If
        End If

        Dim sa As New dSolicitudAnalisis
        Dim p As New dCliente
        Dim ti As New dTipoInforme
        Dim nombre_productor As String = ""
        Dim tipo_analisis As String = ""
        nficha = TextId.Text.Trim
        sa.ID = nficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            p.ID = sa.IDPRODUCTOR
            p = p.buscar
            If Not p Is Nothing Then
                nombre_productor = p.NOMBRE
            End If
            ti.ID = sa.IDTIPOINFORME
            ti = ti.buscar
            If Not ti Is Nothing Then
                tipo_analisis = ti.NOMBRE
            End If
        End If


        If sms <> "" Then
            'CONFIGURACIÓN DEL STMP 
            _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "-]$]Mo8z1kr3")
            _SMTP.Host = "170.249.199.66"
            _SMTP.Port = 25
            _SMTP.EnableSsl = False

            ' CONFIGURACION DEL MENSAJE 
            _Message.[To].Add(sms)
            _Message.[To].Add("envios@colaveco.com.uy")
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Su solicitud de análisis Nº " & " " & nficha & " - " & tipo_analisis & " (" & nombre_productor & ")," & "ha ingresado correctamente al sistema. Gracias. COLAVECO"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            'Dim _File As String = My.Application.Info.DirectoryPath & "archivo" 'archivo que se quiere adjuntar ‘
            'Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            '_Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                'MessageBox.Show("Mensaje enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""
        texto = ""

    End Sub
    Private Sub enviomailpulsa()

        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        nficha = TextId.Text.Trim
        Dim fichero As String = ""
        fichero = "\\192.168.1.10\E\NET\SOLICITUDES\S" & nficha & ".xls"
        If email <> "" Then
            'CONFIGURACIÓN DEL STMP 
            _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "-]$]Mo8z1kr3")
            _SMTP.Host = "170.249.199.66"
            _SMTP.Port = 25
            _SMTP.EnableSsl = False

            ' CONFIGURACION DEL MENSAJE 
            _Message.[To].Add(email)
            _Message.[To].Add("envios@colaveco.com.uy")
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Solicitud de análisis"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            _Message.Body = "Su solicitud de análisis Nº " & " " & nficha & ", " & "ha ingresado correctamente al sistema. Gracias."
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            'Dim _File As String = My.Application.Info.DirectoryPath & "archivo" 'archivo que se quiere adjuntar ‘
            'Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            '_Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                'MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""
        nficha = ""
    End Sub

    Private Sub CheckSinSolicitud_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckSinSolicitud.CheckedChanged
        If CheckSinSolicitud.Checked = True Then
            Dim ficha As Long = TextId.Text.Trim
            Dim v As New FormSinSolicitud(Usuario, ficha)
            v.ShowDialog()
        End If
    End Sub
    Private Sub ButtonAgregarCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregarCaja.Click
        Dim v As New FormCajas(Usuario)
        v.ShowDialog()
        cargarComboCajas()
    End Sub
    Private Sub ComboCajas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCajas.SelectedIndexChanged
        buscarultimoenvio()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fichero As String
        Dim dlAbrir As New System.Windows.Forms.OpenFileDialog
        dlAbrir.Filter = "Todos los archivos (*.jpg)|*.jpg"
        dlAbrir.Multiselect = False
        dlAbrir.CheckFileExists = False
        dlAbrir.Title = "Selección de fichero"
        dlAbrir.InitialDirectory = "%windir%\explorer.exe shell:::{A8A91A66-3A7D-4424-8D24-04E180695C7A}"
        dlAbrir.ShowDialog()
        If dlAbrir.FileName <> "" Then
            fichero = dlAbrir.FileName
        End If
    End Sub
    Private Sub CheckDesvio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckDesvio.CheckedChanged
        If CheckDesvio.Checked = True Then
            Dim id_ficha As Long = TextId.Text
            Dim v As New FormDescarteMuestras(Usuario, id_ficha)
            v.Show()
        End If
    End Sub

    Private Sub TextMuestras_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextMuestras.TextChanged

    End Sub

    Private Sub TextRemito_ReadOnlyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextRemito.ReadOnlyChanged

    End Sub

    Private Sub TextRemito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextRemito.TextChanged

    End Sub
End Class