Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections
Imports System.Net.FtpWebRequest
Imports System.Net
Imports Newtonsoft.Json
Public Class FormSolicitud
    Private productorweb_com As String
    Private idproductorweb_com As Long
    Private idficha As String
    Private tipoinforme As String = ""
    Private idtipoinforme_ As Integer = 0
    Private _usuario As dUsuario
    Private email As String
    Private celular As String
    Private nficha As String
    Private idprod As Long = 0
    Private idtipoinf As Integer = 0
    Private ficha As Long = 0
    Private nroficha As Long = 0
    Private codigo As String = ""
    Private nuevaFicha As Integer = 0
    Dim idcaja As String
    Dim idCliente As Long = 0
    Dim cajasImp As String = ""

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
        'cargarComboMuestreoTecnicos()
        cargarComboAgencia()
        cargarComboCajas()
        cargarComboTecnicosMuestreo()
        limpiar()
        buscarultimaficha()
        idprod = idpro
        cbxTecnicoMuestreo.Visible = False
        cbxTecnicoSueloNutri.Visible = False
        btnImprimir.Visible = False
        If idprod <> 0 Then
            Dim pro As New dCliente
            pro.ID = idprod
            pro = pro.buscar
            If Not pro Is Nothing Then
                If pro.CONTRATO = 0 Then
                    MsgBox("El cliente no tiene contrato firmado.")
                End If
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
                If CheckMuestreo.Checked = True Then
                    cbxTecnicoMuestreo.Visible = True
                End If
            End If
        End If
    End Sub
#End Region
    Private Property ListMuestras As Object
    Private Sub buscarultimaficha()
        Dim ultimaf As New dUltimoNumero
        ultimaf = ultimaf.buscar
        TextId.Text = ultimaf.FICHAS + 1
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
    Public Sub cargarComboTecnicosMuestreo()
        Dim tecMue As New dTecnicoMuestreo
        Dim lista As New ArrayList
        lista = tecMue.listarTodos
        cbxTecnicoMuestreo.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each tecMue In lista
                    cbxTecnicoMuestreo.Items.Add(tecMue)
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
        lista = ti.listar
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
        If Not idtipoinforme Is Nothing Then
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
        End If
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        DateFechaIngreso.Value = Now()
        TextIdProductor.Text = ""
        TextProductor.Text = ""
        TextDicose.Text = ""
        ComboTipoInforme.Text = ""
        ComboSubInforme.Text = ""
        TextObservaciones.Text = ""
        TextObsInternas.Text = ""
        TextNMuestras.Text = ""
        TextKmts.Text = ""
        ComboMuestra.Text = ""
        ComboTecnico.Text = ""
        CheckSinSolicitud.Checked = False
        CheckSinConservante.Checked = False
        CheckPago.Checked = False
        TextTemperatura.Text = ""
        CheckDerramadas.Checked = False
        CheckDesvio.Checked = False
        CheckMuestreo.Checked = False
        DateMuestreo.Value = Now()
        TextId.Focus()
    End Sub
    Private Sub limpiar2()
        ComboCajas.SelectedItem = Nothing
        ComboCajas.Text = ""
        TextFrascos.Text = ""
        TextRemito.Text = ""
        TextOtros.Text = ""
        ComboAgencia.Text = ""
        CheckCajas.Checked = False
        CheckFrascos.Checked = False
        ListCajas.Items.Clear()
        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()
    End Sub
    Private Sub guardar2()
        tipoinforme = ComboTipoInforme.Text
        If TextId.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de ficha", MsgBoxStyle.Exclamation, "Atención") : TextId.Focus() : Exit Sub
        Dim id As Long = TextId.Text.Trim
        Dim na As New dNuevoAnalisis
        Dim listaana As New ArrayList
        listaana = na.listarporficha(id) 'LISTA DE MUESTRAS INGRESADAS
        Dim fechaingreso As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
        If TextIdProductor.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de productor", MsgBoxStyle.Exclamation, "Atención") : TextIdProductor.Focus() : Exit Sub
        Dim idproductor As Long = TextIdProductor.Text.Trim
        Dim idtipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        Dim idsubinforme As dSubInforme = CType(ComboSubInforme.SelectedItem, dSubInforme)

        'Tecnico Muestreo 
        Dim tecMuestreo As dTecnicoMuestreo = CType(cbxTecnicoMuestreo.SelectedItem, dTecnicoMuestreo)
        If CheckMuestreo.Checked = True And tecMuestreo Is Nothing Then
            MsgBox("Debe seleccionar un Técnico para el muestreo!")
            Exit Sub
            cbxTecnicoMuestreo.Focus()
        End If

        If idtipoinforme Is Nothing Then
            MsgBox("Debe seleccionar tipo de informe!")
            Exit Sub
            ComboTipoInforme.Focus()
        End If
        If idsubinforme Is Nothing Then
            MsgBox("Debe seleccionar subtipo de informe!")
            Exit Sub
            ComboSubInforme.Focus()
        End If
        'VERIFICA QUE SE HAYAN INGRESADO MUESTRAS ******************************************
        If idsubinforme.ID <> 22 Then
            If Not listaana Is Nothing Then
            Else
                Dim at As New dAnalisisTercerizado
                Dim listaat As New ArrayList
                listaat = at.listarporficha2(id)
                If Not listaat Is Nothing Then
                Else
                    MsgBox("Debe ingresar muestras")
                    Exit Sub
                End If
            End If
        End If
        '***********************************************************************************
        Dim observaciones As String = TextObservaciones.Text.Trim
        Dim obsinternas As String = TextObsInternas.Text.Trim
        If aguaclorada = 1 Then
            observaciones = observaciones & " - *** CLORADA ***"
            If observaciones <> "" Then
                TextObservaciones.Text = observaciones
            End If
            aguaclorada = 0
        End If
        Dim nmuestras As Integer = 0
        If TextNMuestras.Text <> "" Then
            nmuestras = TextNMuestras.Text.Trim
        End If
        If nmuestras = 0 Then
            MsgBox("Debe ingresar la cantidad de muestras!")
            Exit Sub
            TextNMuestras.Focus()
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
        Dim idfactura As Long = 0
        Dim web As Integer = 0
        Dim personal As Integer = 0
        Dim mail As Integer = 0
        Dim ultimaficha As Long = TextId.Text.Trim
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
        Dim muestreo As Integer = 0
        If CheckMuestreo.Checked = True Then
            muestreo = 1
        End If
        Dim idTecnicoMuestreo As Long

        If Not tecMuestreo Is Nothing Then
            idTecnicoMuestreo = tecMuestreo.TECNICO_MUESTREO_ID
        End If

        Dim fechamuestreo As Date = DateMuestreo.Value.ToString("yyyy-MM-dd")
        If TextId.Text.Trim.Length > 0 Then
            Dim sol As New dSolicitudAnalisis()
            Dim sw As New dSolicitudWeb
            Dim un As New dUltimoNumero

            'Sol.It 261
            If CheckMuestreo.Checked = True And Not tecMuestreo Is Nothing And ComboTipoInforme.SelectedIndex = 16 Then
                Dim solTecnMuestreo As New dSolicitudanalisis_TecMuestreo()
                solTecnMuestreo.ID_SOLICITUDANALISIS = id
                solTecnMuestreo.ID_TECNICOMUESTREO = idTecnicoMuestreo
                solTecnMuestreo.guardar()
            End If
            

            un = un.buscar
            Dim fecing As String
            fecing = Format(fechaingreso, "yyyy-MM-dd")
            sol.ID = id
            sol.FECHAINGRESO = fecing
            sol.IDPRODUCTOR = idproductor
            If Not idtipoinforme Is Nothing Then
                sol.IDTIPOINFORME = idtipoinforme.ID
            End If
            If Not idsubinforme Is Nothing Then
                sol.IDSUBINFORME = idsubinforme.ID
            End If
            sol.IDTIPOFICHA = 1
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
            sol.FECHAENVIO = fecing
            sol.PAGO = pago
            sol.KMTS = kmts
            sol.OBSINTERNAS = obsinternas
            sol.CODIGO = codigo
            sol.FECHAPROCESO = fecing
            sol.MUESTREO = muestreo
            sol.INTERPRETACION = idTecnicoMuestreo
            sol.SOLICITUDESTADOID = 2 'EnProcesso
            Dim fecmuestreo As String
            fecmuestreo = Format(fechamuestreo, "yyyy-MM-dd")
            sol.FECHAMUESTREO = fecmuestreo
            sw.FICHA = id
            sw.GESTOR = 0

            'Sol IT 423, Control por contraseña de supervisor al momento de modificar una solicitud.
            Dim solicitudAnalisis As New dSolicitudAnalisis

            If solicitudAnalisis.verificarExistenciaSolicitud(id) Then

                ' Mostrar el mensaje de advertencia
                Dim resultado As DialogResult = MessageBox.Show("Esta solicitud necesita de la autorización de un supervisor para ser modificada.", "Autorización requerida", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

                ' Si el usuario presiona OK, abrir el formulario FormConfSupervisor
                If resultado = DialogResult.OK Then
                    Dim formSupervisor As New FormConfSupervisor()
                    formSupervisor.SolicitudAnalisisId = id
                    formSupervisor.ShowDialog()

                    ' Ahora chequeamos si autorizó correctamente
                    If formSupervisor.AutorizadoCorrecto = True Then
                        ' ACA PONES TU BLOQUE DE CÓDIGO QUE MODIFICA Y GUARDA

                        If (sol.modificar(Usuario)) Then
                            If ultimaficha > un.FICHAS Then
                                un.FICHAS = ultimaficha
                                un.modificar()
                            End If

                            '---------------GestorGX
                            ' tiene que modificar y esta creando
                            Dim gestorNuevo As New dNuevoGestor
                            gestorNuevo.ID = sol.ID
                            gestorNuevo.IDPRODUCTOR = sol.IDPRODUCTOR
                            gestorNuevo.IDSUBINFORME = sol.IDSUBINFORME
                            gestorNuevo.OBSERVACIONES = sol.OBSERVACIONES
                            gestorNuevo.NMUESTRAS = sol.NMUESTRAS
                            gestorNuevo.IDMUESTRA = idmuestra.ID
                            gestorNuevo.SINCOLICITUD = sol.SINCOLICITUD
                            gestorNuevo.SINCONSERVANTE = sol.SINCONSERVANTE
                            gestorNuevo.TEMPERATURA = sol.TEMPERATURA
                            gestorNuevo.DERRAMADAS = sol.DERRAMADAS
                            gestorNuevo.DESVIOAUTORIZADO = sol.DESVIOAUTORIZADO
                            gestorNuevo.FECHAINGRESO = sol.FECHAINGRESO
                            gestorNuevo.FECHAENVIO = sol.FECHAENVIO
                            gestorNuevo.guardarNuevoGestor(Usuario)

                            '-----------------------------------

                            sw.guardar(Usuario)
                            MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                            imprimir_solicitud()
                            btnImprimir.Visible = True
                            Dim result2 = MessageBox.Show("Desea imprimir un ticket para el cliente?", "Atención!", MessageBoxButtons.YesNoCancel)
                            If result2 = DialogResult.Cancel Then
                                guardar_ticket()
                            ElseIf result2 = DialogResult.No Then
                                guardar_ticket()
                            ElseIf result2 = DialogResult.Yes Then
                                Dim result5 = MessageBox.Show("Desea imprimir un ticket para el cliente con usuario y contraseña?", "Atención!", MessageBoxButtons.YesNoCancel)
                                If result5 = DialogResult.Cancel Then
                                    imprimir_ticket()
                                ElseIf result5 = DialogResult.No Then
                                    imprimir_ticket()
                                Else
                                    imprimir_ticket_datos()
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
                                    'enviomailpulsa()
                                End If
                            End If
                            'modificarRegistro(id)
                            enviomail()
                            limpiar()
                            limpiar2()
                            ' Grabar estado de la ficha
                            Dim est As New dEstados
                            est.FICHA = id
                            est.ESTADO = 1
                            est.FECHA = fecing
                            est.guardar(Usuario)
                            est = Nothing
                            enviar_notificacion_solicitud(id)
                            '****************************
                        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")

                        End If
                Else
                    MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                ' No autorizado, no continúa
                MsgBox("Acceso no autorizado, operación cancelada.", MsgBoxStyle.Exclamation, "Atención")
            End If
        Else
                If TextIdProductor.Text.Trim.Length > 0 Then
                    Dim sol2 As New dSolicitudAnalisis()
                    Dim un2 As New dUltimoNumero
                    un2 = un.buscar
                    Dim fecing2 As String
                    fecing2 = Format(fechaingreso, "yyyy-MM-dd")
                    sol2.ID = id
                    sol2.FECHAINGRESO = fecing
                    sol2.IDPRODUCTOR = idproductor
                    If Not idtipoinforme Is Nothing Then
                        sol2.IDTIPOINFORME = idtipoinforme.ID
                    End If
                    If Not idsubinforme Is Nothing Then
                        sol2.IDSUBINFORME = idsubinforme.ID
                    End If
                    sol2.IDTIPOFICHA = 1
                    sol2.OBSERVACIONES = observaciones
                    sol2.NMUESTRAS = nmuestras
                    If Not idtecnico Is Nothing Then
                        sol2.IDTECNICO = idtecnico.ID
                    End If
                    sol2.SINCOLICITUD = sinsolicitud
                    sol2.SINCONSERVANTE = sinconservante
                    sol2.TEMPERATURA = temperatura
                    sol2.DERRAMADAS = derramadas
                    sol2.DESVIOAUTORIZADO = desvioautorizado
                    sol2.IDFACTURA = idfactura
                    sol2.WEB = web
                    sol2.PERSONAL = personal
                    sol2.EMAIL = mail
                    sol2.FECHAENVIO = fecing
                    sol2.PAGO = pago
                    sol2.KMTS = kmts
                    sol2.OBSINTERNAS = obsinternas
                    sol2.CODIGO = codigo
                    sol2.FECHAPROCESO = fecing
                    sol2.MUESTREO = muestreo
                    sol2.INTERPRETACION = idTecnicoMuestreo
                    Dim fecmuestreo2 As String
                    fecmuestreo2 = Format(fechamuestreo, "yyyy-MM-dd")
                    sol2.FECHAMUESTREO = fecmuestreo

                    If (sol2.guardar(Usuario)) Then
                        If ultimaficha > un.FICHAS Then
                            un2.FICHAS = ultimaficha
                            un2.modificar()
                        End If

                        '---------------GestorGX
                        Dim gestorNuevo As New dNuevoGestor
                        gestorNuevo.ID = sol.ID
                        gestorNuevo.IDPRODUCTOR = sol.IDPRODUCTOR
                        gestorNuevo.IDSUBINFORME = sol.IDSUBINFORME
                        gestorNuevo.OBSERVACIONES = sol.OBSERVACIONES
                        gestorNuevo.NMUESTRAS = sol.NMUESTRAS
                        gestorNuevo.IDMUESTRA = idmuestra.ID
                        gestorNuevo.SINCOLICITUD = sol.SINCOLICITUD
                        gestorNuevo.SINCONSERVANTE = sol.SINCONSERVANTE
                        gestorNuevo.TEMPERATURA = sol.TEMPERATURA
                        gestorNuevo.DERRAMADAS = sol.DERRAMADAS
                        gestorNuevo.DESVIOAUTORIZADO = sol.DESVIOAUTORIZADO
                        gestorNuevo.FECHAINGRESO = sol.FECHAINGRESO
                        gestorNuevo.FECHAENVIO = sol.FECHAENVIO
                        gestorNuevo.guardarNuevoGestor(Usuario)
                        '----------------------------------------------------


                        MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        '***IMPRESIÓN DE SOLICITUD Y TICKETS **************************************************************************************
                        imprimir_solicitud()
                        Dim result2 = MessageBox.Show("Desea imprimir un ticket para el cliente?", "Atención!", MessageBoxButtons.YesNoCancel)
                        If result2 = DialogResult.Cancel Then
                        ElseIf result2 = DialogResult.No Then
                        ElseIf result2 = DialogResult.Yes Then
                            imprimir_ticket()
                        End If
                        '*****************************************************************************************************************************
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
                        modificarRegistro(id)
                        enviomail()
                        enviar_notificacion_solicitud(id)
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                End If
            End If
        Else
        End If
        agregar_registro_facturacion()
        buscarultimaficha()
    End Sub

    Public Sub modificarRegistro(ByVal id As Integer)
        Dim idnet As Long = 0
        Dim sa_ As New dSolicitudAnalisis
        sa_.ID = id
        sa_ = sa_.buscar
        If Not sa_ Is Nothing Then
            idnet = sa_.IDPRODUCTOR
            tipoinforme = sa_.IDTIPOINFORME
            Dim c As New dCliente
            c.ID = sa_.IDPRODUCTOR
            c = c.buscar
            If Not c Is Nothing Then
                productorweb_com = c.USUARIO_WEB
                Dim pw_com As New dProductorWeb_com
                pw_com.USUARIO = productorweb_com
                pw_com = pw_com.buscar
                If Not pw_com Is Nothing Then
                    idproductorweb_com = pw_com.ID
                    '
                End If
            End If
        End If

        'enviar_notificacion_resultado()

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
        ElseIf tipoinforme = 16 Then
            carpeta = "efluentes"
        ElseIf tipoinforme = 17 Then
            carpeta = "antibiograma"
        ElseIf tipoinforme = 18 Then
            carpeta = "antibiograma"
        ElseIf tipoinforme = 19 Then
            carpeta = "agro_suelos"
        ElseIf tipoinforme = 20 Then
            carpeta = "patologia"
        ElseIf tipoinforme = 21 Then
            carpeta = "calidad_de_leche"
            tipoinforme = 10
        End If

        Dim rg As New dResultado

        Dim fechaemi2 As String
        Dim fecha_emision2 As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
        'fechaemi2 = Format(fecha_emision2, "yyyy-MM-dd")
        fechaemi2 = fecha_emision2

        rg.ficha = id
        'rg.comentarios = _comentarios
        rg.idnet_usuario = idnet
        rg.abonado = 0
        rg.fecha_creado = fechaemi2
        rg.fecha_emision = fechaemi2
        rg.path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/" & carpeta & "/" & id & ".xls"
        rg.path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/" & carpeta & "/" & id & ".pdf"
        rg.path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/" & carpeta & "/" & id & ".txt"
        rg.id_estado = 1
        rg.id_libro = id
        rg.idnet_tipo_informe = tipoinforme
        resultado.Add("resultado", rg)

        Dim parameters As String = JsonConvert.SerializeObject(resultado, Formatting.None)

        Dim status As HttpStatusCode = HttpStatusCode.ExpectationFailed
        Dim response As Byte() = PostResponse("http://colaveco-gestor.herokuapp.com/resultados", "POST", parameters, status)
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



            Dim response As HttpWebResponse = request.GetResponse()

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

    Private Sub guardar_ticket()
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
        Dim fechamuestreo As Date = DateMuestreo.Value
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
        Dim columna = 1
        x1hoja.Cells(fila, columna).rowheight = 15
        x1hoja.Cells(fila, columna).Formula = "Solicitud de análisis"
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 12
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).formula = "Nº de Ficha:" & " " & ficha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 6
        x1hoja.Cells(fila, columna).formula = "RG.ADM.54 v02 06/06/18"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignRight
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).formula = "Fecha/Hora de recepción:" & " " & fecha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Realizada por:" & " " & Usuario.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
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
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).formula = "Cliente:" & " " & nombre_productor & " " & "(" & idproductor & ")"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Muestra de:" & " " & muestra
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Muestras:" & " " & nmuestras
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        columna = 1
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        Dim cajas As String = ""
        Dim gradillas As String = ""
        Dim otros As String = ""
        x1hoja.Cells(fila, columna).formula = "Análisis requerido: " & tipoinforme & " // " & "Subinforme:" & " " & subtipoinforme
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '***  LISTADO DE ANALISIS REQUERIDOS *********************************************************************
        Dim na As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista3 As New ArrayList
        lista = na.listarporfichamuestra(ficha)
        lista3 = na3.listarporficha3(ficha)
        Dim lanalisis As String = ""
        If Not lista3 Is Nothing Then
            For Each na In lista3
                Dim l As New dListaPrecios
                l.ID = na.ANALISIS
                l = l.buscar
                lanalisis = lanalisis & l.ABREVIATURA & " - "
                l = Nothing
            Next
            If subtipoinforme = "Semen y Venereas" Then
                lanalisis = "Evaluación biológica básica"
            End If
        Else
            If subtipoinforme = "Brucelosis" Then
                lanalisis = "Brucelosis"
            End If

        End If
        '***  LISTADO DE ANALISIS TERCERIZADOS *********************************************************************
        Dim at As New dAnalisisTercerizado
        Dim listanat As New ArrayList
        Dim listaanalisist As String = ""
        listanat = at.listardistintosanalisis(ficha)
        If Not listanat Is Nothing Then
            Dim dep1 As Integer = 0
            Dim dep2 As Integer = 0
            For Each at In listanat
                Dim att As New dAnalisisTercerizadoTipo
                att.ID = at.ANALISIS
                att = att.buscar
                If att.DEPENDE <> 0 Then
                    dep1 = att.DEPENDE
                    Dim at2 As New dAnalisisTercerizadoTipo
                    at2.ID = att.DEPENDE
                    at2 = at2.buscar
                    If dep1 <> dep2 Then
                        listaanalisist = listaanalisist & at2.NOMBRE & " - "
                        at2 = Nothing
                    End If
                    dep2 = att.DEPENDE
                Else
                    listaanalisist = listaanalisist & att.NOMBRE & " - "
                End If
            Next
        End If
        If listaanalisist <> "" Then
            lanalisis = lanalisis & " / OTROS LABORATORIOS: " & listaanalisist
        End If

        x1hoja.Cells(fila, columna).rowheight = 50
        x1hoja.Cells(fila, columna).Formula = lanalisis
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '********************************************************************************************************
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        '********************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "Identificación de las muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '*** LISTADO DE MUESTRAS *********************************************************************************
        Dim lmuestras As String = ""
        If Not lista Is Nothing Then
            For Each na In lista
                lmuestras = lmuestras & na.MUESTRA & " - "
            Next
        End If
        x1hoja.Cells(fila, columna).rowheight = 50
        x1hoja.Cells(fila, columna).Formula = lmuestras
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '**********************************************************************************************************
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        '**********************************************************************************************************
        If observaciones <> "" Then
            x1hoja.Cells(fila, columna).formula = "Observaciones:"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 25
            x1hoja.Cells(fila, columna).Formula = observaciones
            x1hoja.Range("A" & fila, "G" & fila).WrapText = True
            x1hoja.Range("A" & fila, "G" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
        End If
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        '***********************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "IMPORTANTE:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).rowheight = 55
        x1hoja.Cells(fila, columna).Formula = "Ud. puede descargar los resultados desde nuestra web/app, solicite usuario y contraseña." & vbCrLf _
            & "Recuerde que los resultados quedan habilitados si el cliente no tiene facturas vencidas." & vbCrLf _
            & "Si tiene dificultades para obtener los resultados, comunicarse al 4554 5311 / 5975 / 6838 o via e-mail a colaveco@gmail.com. " _
            & "Horario de atención al público, de lunes a viernes de 8:00 a 17:00 horas." & vbCrLf _
            & "Colaveco no se hace responsable por la información proporcionada por el cliente."
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 3
        ' SEGUNDA COPIA *************************************************************************************************************************************
        x1hoja.Cells(fila, columna).rowheight = 15
        x1hoja.Cells(fila, columna).Formula = "Solicitud de análisis"
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 12
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).formula = "Nº de Ficha:" & " " & ficha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 6
        x1hoja.Cells(fila, columna).formula = "RG.ADM.54 v02 06/06/18"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignRight
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).formula = "Fecha/Hora de recepción:" & " " & fecha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Realizada por:" & " " & Usuario.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        If Not pro Is Nothing Then
            nombre_productor = pro.NOMBRE
            usucontra = pro.USUARIO_WEB
            idproductor = pro.ID
        Else
            nombre_productor = ""
        End If
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).formula = "Cliente:" & " " & nombre_productor & " " & "(" & idproductor & ")"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Muestra de:" & " " & muestra
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Muestras:" & " " & nmuestras
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        columna = 1
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Análisis requerido: " & tipoinforme & " // " & "Subinforme:" & " " & subtipoinforme
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '***  LISTADO DE ANALISIS REQUERIDOS *********************************************************************
        x1hoja.Cells(fila, columna).rowheight = 50
        x1hoja.Cells(fila, columna).Formula = lanalisis
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '********************************************************************************************************
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        '********************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "Identificación de las muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '*** LISTADO DE MUESTRAS *********************************************************************************
        x1hoja.Cells(fila, columna).rowheight = 50
        x1hoja.Cells(fila, columna).Formula = lmuestras
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '**********************************************************************************************************
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        '**********************************************************************************************************
        If observaciones <> "" Then
            x1hoja.Cells(fila, columna).formula = "Observaciones:"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 25
            x1hoja.Cells(fila, columna).Formula = observaciones
            x1hoja.Range("A" & fila, "G" & fila).WrapText = True
            x1hoja.Range("A" & fila, "G" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
        End If
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        '***********************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "COLAVECO - Parque El Retiro - Nueva helvecia - Tel/Fax 45545311 /45545975 / 45546838"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).rowheight = 55
        x1hoja.Cells(fila, columna).Formula = "Cuando el cliente solicite suspender el servicio ya presupuestado y en ejecución, o una parte del mismo," & vbCrLf _
            & "los costos de las actividades ya realizadas en el momento de la suspensión deberán pagarse." & vbCrLf _
            & "Los resultados de este análisis pueden ser utilizados y/o publicados por COLAVECO, con fines científicos, protegiendo la confidencialidad del cliente." & vbCrLf _
        & "Colaveco no se hace responsable por la información proporcionada por el cliente."
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "Firma del cliente / aclaración: ___________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        '*************************************************************************************************************
        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        x1app.DisplayAlerts = False 'NO PREGUNTA SI EL ARCHIVO EXISTE
        'x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        x1hoja.SaveAs("\\192.168.1.10\E\NET\TICKET_CLIENTES\TC" & ficha & ".xls")
        'x1app.Visible = True
        'x1libro.PrintPreview()
        x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub imprimir_ticket()
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
        Dim fechamuestreo As Date = DateMuestreo.Value
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
        Dim columna = 1
        x1hoja.Cells(fila, columna).rowheight = 15
        x1hoja.Cells(fila, columna).Formula = "Solicitud de análisis"
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 12
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).formula = "Nº de Ficha:" & " " & ficha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 6
        x1hoja.Cells(fila, columna).formula = "RG.ADM.54 v02 06/06/18"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignRight
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).formula = "Fecha/Hora de recepción:" & " " & fecha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Realizada por:" & " " & Usuario.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
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
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).formula = "Cliente:" & " " & nombre_productor & " " & "(" & idproductor & ")"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Muestra de:" & " " & muestra
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        If ComboTipoInforme.Text = "Control Lechero then" Then
            columna = 1
            x1hoja.Cells(fila, columna).formula = "Fecha de muestreo:" & " " & fechamuestreo
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 4
        End If
        x1hoja.Cells(fila, columna).formula = "Nº de Muestras:" & " " & nmuestras
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        columna = 1
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        Dim cajas As String = ""
        Dim gradillas As String = ""
        Dim otros As String = ""
        x1hoja.Cells(fila, columna).formula = "Análisis requerido: " & tipoinforme & " // " & "Subinforme:" & " " & subtipoinforme
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '***  LISTADO DE ANALISIS REQUERIDOS *********************************************************************
        Dim na As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista3 As New ArrayList
        lista = na.listarporfichamuestra(ficha)
        lista3 = na3.listarporficha3(ficha)
        Dim lanalisis As String = ""
        If Not lista3 Is Nothing Then
            For Each na In lista3
                Dim l As New dListaPrecios
                l.ID = na.ANALISIS
                l = l.buscar
                lanalisis = lanalisis & l.ABREVIATURA & " - "
                l = Nothing
            Next
            If subtipoinforme = "Semen y Venereas" Then
                lanalisis = "Evaluación biológica básica"
            End If
        Else
            If subtipoinforme = "Brucelosis" Then
                lanalisis = "Brucelosis"
            End If

        End If
        '***  LISTADO DE ANALISIS TERCERIZADOS *********************************************************************
        Dim at As New dAnalisisTercerizado
        Dim listanat As New ArrayList
        Dim listaanalisist As String = ""
        listanat = at.listardistintosanalisis(ficha)
        If Not listanat Is Nothing Then
            Dim dep1 As Integer = 0
            Dim dep2 As Integer = 0
            For Each at In listanat
                Dim att As New dAnalisisTercerizadoTipo
                att.ID = at.ANALISIS
                att = att.buscar
                If att.DEPENDE <> 0 Then
                    dep1 = att.DEPENDE
                    Dim at2 As New dAnalisisTercerizadoTipo
                    at2.ID = att.DEPENDE
                    at2 = at2.buscar
                    If dep1 <> dep2 Then
                        listaanalisist = listaanalisist & at2.NOMBRE & " - "
                        at2 = Nothing
                    End If
                    dep2 = att.DEPENDE
                Else
                    listaanalisist = listaanalisist & att.NOMBRE & " - "
                End If
            Next
        End If
        If listaanalisist <> "" Then
            lanalisis = lanalisis & " / OTROS LABORATORIOS: " & listaanalisist
        End If

        x1hoja.Cells(fila, columna).rowheight = 50
        x1hoja.Cells(fila, columna).Formula = lanalisis
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '********************************************************************************************************
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        '********************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "Identificación de las muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '*** LISTADO DE MUESTRAS *********************************************************************************
        Dim lmuestras As String = ""
        If Not lista Is Nothing Then
            For Each na In lista
                lmuestras = lmuestras & na.MUESTRA & " - "
            Next
        End If
        x1hoja.Cells(fila, columna).rowheight = 50
        x1hoja.Cells(fila, columna).Formula = lmuestras
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '**********************************************************************************************************
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        '**********************************************************************************************************

        'Codigo EMPI
        If codigo <> "" Then
            observaciones = "Codigo EMPI: (" + codigo + "), " + TextObservaciones.Text.Trim
        End If

        If observaciones <> "" Then
            x1hoja.Cells(fila, columna).formula = "Observaciones:"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 25
            x1hoja.Cells(fila, columna).Formula = observaciones
            x1hoja.Range("A" & fila, "G" & fila).WrapText = True
            x1hoja.Range("A" & fila, "G" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
        End If
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        '***********************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "IMPORTANTE:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).rowheight = 55
        x1hoja.Cells(fila, columna).Formula = "Ud. puede descargar los resultados desde nuestra web/app, solicite usuario y contraseña." & vbCrLf _
            & "Recuerde que los resultados quedan habilitados si el cliente no tiene facturas vencidas." & vbCrLf _
            & "Si tiene dificultades para obtener los resultados, comunicarse al 4554 5311 / 5975 / 6838 o via e-mail a colaveco@gmail.com. " _
            & "Horario de atención al público, de lunes a viernes de 8:00 a 17:00 horas." & vbCrLf _
            & "Colaveco no se hace responsable por la información proporcionada por el cliente."
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 3
        ' SEGUNDA COPIA *************************************************************************************************************************************
        x1hoja.Cells(fila, columna).rowheight = 15
        x1hoja.Cells(fila, columna).Formula = "Solicitud de análisis"
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 12
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).formula = "Nº de Ficha:" & " " & ficha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 6
        x1hoja.Cells(fila, columna).formula = "RG.ADM.54 v02 06/06/18"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignRight
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).formula = "Fecha/Hora de recepción:" & " " & fecha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Realizada por:" & " " & Usuario.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        If Not pro Is Nothing Then
            nombre_productor = pro.NOMBRE
            usucontra = pro.USUARIO_WEB
            idproductor = pro.ID
        Else
            nombre_productor = ""
        End If
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).formula = "Cliente:" & " " & nombre_productor & " " & "(" & idproductor & ")"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Muestra de:" & " " & muestra
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Muestras:" & " " & nmuestras
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        columna = 1
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Análisis requerido: " & tipoinforme & " // " & "Subinforme:" & " " & subtipoinforme
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '***  LISTADO DE ANALISIS REQUERIDOS *********************************************************************
        x1hoja.Cells(fila, columna).rowheight = 50
        x1hoja.Cells(fila, columna).Formula = lanalisis
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '********************************************************************************************************
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        '********************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "Identificación de las muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '*** LISTADO DE MUESTRAS *********************************************************************************
        x1hoja.Cells(fila, columna).rowheight = 50
        x1hoja.Cells(fila, columna).Formula = lmuestras
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '**********************************************************************************************************
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        '**********************************************************************************************************
        If observaciones <> "" Then
            x1hoja.Cells(fila, columna).formula = "Observaciones:"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 25
            x1hoja.Cells(fila, columna).Formula = observaciones
            x1hoja.Range("A" & fila, "G" & fila).WrapText = True
            x1hoja.Range("A" & fila, "G" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
        End If
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        '***********************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "COLAVECO - Parque El Retiro - Nueva helvecia - Tel/Fax 45545311 /45545975 / 45546838"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).rowheight = 55
        x1hoja.Cells(fila, columna).Formula = "Cuando el cliente solicite suspender el servicio ya presupuestado y en ejecución, o una parte del mismo," & vbCrLf _
            & "los costos de las actividades ya realizadas en el momento de la suspensión deberán pagarse." & vbCrLf _
            & "Los resultados de este análisis pueden ser utilizados y/o publicados por COLAVECO, con fines científicos, protegiendo la confidencialidad del cliente." & vbCrLf _
        & "Colaveco no se hace responsable por la información proporcionada por el cliente."
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "Firma del cliente / aclaración: ___________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        '*************************************************************************************************************
        x1app.DisplayAlerts = False 'NO PREGUNTA SI EL ARCHIVO EXISTE
        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        'x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        x1hoja.SaveAs("\\192.168.1.10\E\NET\TICKET_CLIENTES\TC" & ficha & ".xls")
        x1app.Visible = True
        x1libro.PrintPreview()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub imprimir_ticket_datos()
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
        Dim columna = 1
        x1hoja.Cells(fila, columna).rowheight = 15
        x1hoja.Cells(fila, columna).Formula = "Solicitud de análisis"
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 12
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).formula = "Nº de Ficha:" & " " & ficha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 6
        x1hoja.Cells(fila, columna).formula = "RG.ADM.54 v02 06/06/18"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignRight
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).formula = "Fecha/Hora de recepción:" & " " & fecha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Realizada por:" & " " & Usuario.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
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
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).formula = "Cliente:" & " " & nombre_productor & " " & "(" & idproductor & ")"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Muestra de:" & " " & muestra
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Muestras:" & " " & nmuestras
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        columna = 1
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        Dim cajas As String = ""
        Dim gradillas As String = ""
        Dim otros As String = ""
        x1hoja.Cells(fila, columna).formula = "Análisis requerido: " & tipoinforme & " // " & "Subinforme:" & " " & subtipoinforme
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '***  LISTADO DE ANALISIS REQUERIDOS *********************************************************************
        Dim na As New dNuevoAnalisis
        Dim na3 As New dNuevoAnalisis
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista3 As New ArrayList
        lista = na.listarporfichamuestra(ficha)
        lista3 = na3.listarporficha3(ficha)
        Dim lanalisis As String = ""
        If Not lista3 Is Nothing Then
            For Each na In lista3
                Dim l As New dListaPrecios
                l.ID = na.ANALISIS
                l = l.buscar
                lanalisis = lanalisis & l.ABREVIATURA & " - "
                l = Nothing
            Next
            If subtipoinforme = "Semen y Venereas" Then
                lanalisis = "Evaluación biológica básica"
            End If
        Else
            If subtipoinforme = "Brucelosis" Then
                lanalisis = "Brucelosis"
            End If

        End If
        '***  LISTADO DE ANALISIS TERCERIZADOS *********************************************************************
        Dim at As New dAnalisisTercerizado
        Dim listanat As New ArrayList
        Dim listaanalisist As String = ""
        listanat = at.listardistintosanalisis(ficha)
        If Not listanat Is Nothing Then
            Dim dep1 As Integer = 0
            Dim dep2 As Integer = 0
            For Each at In listanat
                Dim att As New dAnalisisTercerizadoTipo
                att.ID = at.ANALISIS
                att = att.buscar
                If att.DEPENDE <> 0 Then
                    dep1 = att.DEPENDE
                    Dim at2 As New dAnalisisTercerizadoTipo
                    at2.ID = att.DEPENDE
                    at2 = at2.buscar
                    If dep1 <> dep2 Then
                        listaanalisist = listaanalisist & at2.NOMBRE & " - "
                        at2 = Nothing
                    End If
                    dep2 = att.DEPENDE
                Else
                    listaanalisist = listaanalisist & att.NOMBRE & " - "
                End If
            Next
        End If
        If listaanalisist <> "" Then
            lanalisis = lanalisis & " / OTROS LABORATORIOS: " & listaanalisist
        End If
        x1hoja.Cells(fila, columna).rowheight = 50
        x1hoja.Cells(fila, columna).Formula = lanalisis
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '********************************************************************************************************
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        '********************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "Identificación de las muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '*** LISTADO DE MUESTRAS *********************************************************************************
        Dim lmuestras As String = ""
        If Not lista Is Nothing Then
            For Each na In lista
                lmuestras = lmuestras & na.MUESTRA & " - "
            Next
        End If
        x1hoja.Cells(fila, columna).rowheight = 50
        x1hoja.Cells(fila, columna).Formula = lmuestras
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '**********************************************************************************************************
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        '**********************************************************************************************************
        If observaciones <> "" Then
            x1hoja.Cells(fila, columna).formula = "Observaciones:"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 25
            x1hoja.Cells(fila, columna).Formula = observaciones
            x1hoja.Range("A" & fila, "G" & fila).WrapText = True
            x1hoja.Range("A" & fila, "G" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
        End If
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        '***********************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "IMPORTANTE:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).rowheight = 55
        x1hoja.Cells(fila, columna).Formula = "Ud. puede descargar los resultados desde nuestra web/app, solicite usuario y contraseña." & vbCrLf _
            & "Recuerde que los resultados quedan habilitados si el cliente no tiene facturas vencidas." & vbCrLf _
            & "Si tiene dificultades para obtener los resultados, comunicarse al 4554 5311 / 5975 / 6838 o via e-mail a colaveco@gmail.com. " _
            & "Horario de atención al público, de lunes a viernes de 8:00 a 17:00 horas." & vbCrLf _
            & "Colaveco no se hace responsable por la información proporcionada por el cliente."
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 8
        'x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Usuario y contraseña para ingresar al gestor de informes: " & usucontra
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 3
        ' SEGUNDA COPIA *************************************************************************************************************************************
        x1hoja.Cells(fila, columna).rowheight = 15
        x1hoja.Cells(fila, columna).Formula = "Solicitud de análisis"
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 12
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).formula = "Nº de Ficha:" & " " & ficha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 6
        x1hoja.Cells(fila, columna).formula = "RG.ADM.54 v02 06/06/18"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignRight
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).formula = "Fecha/Hora de recepción:" & " " & fecha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Realizada por:" & " " & Usuario.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        If Not pro Is Nothing Then
            nombre_productor = pro.NOMBRE
            usucontra = pro.USUARIO_WEB
            idproductor = pro.ID
        Else
            nombre_productor = ""
        End If
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).formula = "Cliente:" & " " & nombre_productor & " " & "(" & idproductor & ")"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Muestra de:" & " " & muestra
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Nº de Muestras:" & " " & nmuestras
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        columna = 1
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Análisis requerido: " & tipoinforme & " // " & "Subinforme:" & " " & subtipoinforme
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '***  LISTADO DE ANALISIS REQUERIDOS *********************************************************************
        x1hoja.Cells(fila, columna).rowheight = 50
        x1hoja.Cells(fila, columna).Formula = lanalisis
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '********************************************************************************************************
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        '********************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "Identificación de las muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '*** LISTADO DE MUESTRAS *********************************************************************************
        x1hoja.Cells(fila, columna).rowheight = 50
        x1hoja.Cells(fila, columna).Formula = lmuestras
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '**********************************************************************************************************
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        '**********************************************************************************************************
        If observaciones <> "" Then
            x1hoja.Cells(fila, columna).formula = "Observaciones:"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 25
            x1hoja.Cells(fila, columna).Formula = observaciones
            x1hoja.Range("A" & fila, "G" & fila).WrapText = True
            x1hoja.Range("A" & fila, "G" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
        End If
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        '***********************************************************************************************************
        x1hoja.Cells(fila, columna).formula = "COLAVECO - Parque El Retiro - Nueva helvecia - Tel/Fax 45545311 /45545975 / 45546838"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).rowheight = 55
        x1hoja.Cells(fila, columna).Formula = "Cuando el cliente solicite suspender el servicio ya presupuestado y en ejecución, o una parte del mismo," & vbCrLf _
            & "los costos de las actividades ya realizadas en el momento de la suspensión deberán pagarse." & vbCrLf _
            & "Los resultados de este análisis pueden ser utilizados y/o publicados por COLAVECO, con fines científicos, protegiendo la confidencialidad del cliente." & vbCrLf _
        & "Colaveco no se hace responsable por la información proporcionada por el cliente."
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 8
        'x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 1
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "Firma del cliente / aclaración: ___________________________________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        '*************************************************************************************************************
        x1app.DisplayAlerts = False 'NO PREGUNTA SI EL ARCHIVO EXISTE
        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        'x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        x1hoja.SaveAs("\\192.168.1.10\E\NET\TICKET_CLIENTES\TC" & ficha & ".xls")
        x1app.Visible = True
        x1libro.PrintPreview()
        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub listaranalisis()
        Dim l As New dListaPrecios
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = l.listarparasolicitud(idtipoinf)
        DataGridView1.Rows.Clear()
        DataGridView1.Rows.Add(lista.Count)
        If idtipoinf = 1 Then
            TextMuestras.Text = "Control lechero"
        ElseIf idtipoinf = 8 Then
            TextMuestras.Text = "Sangre"
        ElseIf idtipoinf = 15 Then
            'TextMuestras.Text = "Leche"
        Else
            TextMuestras.Text = ""
        End If
        If Not lista Is Nothing Then
            For Each l In lista
                Dim p As New dPaquetes
                p.IDPADRE = l.ID
                p = p.buscarxidpadre
                If Not p Is Nothing Then
                    DataGridView1(columna, fila).Value = l.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = l.DESCRIPCION
                    DataGridView1(columna, fila).Style.BackColor = Color.DeepSkyBlue
                    columna = 0
                    fila = fila + 1
                Else
                    DataGridView1(columna, fila).Value = l.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = l.DESCRIPCION
                    columna = 0
                    fila = fila + 1
                End If
            Next
        End If
    End Sub
    Private Sub listaranalisis2()
        Dim n As New dNuevoAnalisis
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        Dim ficha As Long = TextId.Text
        lista = n.listarporficha2(ficha)
        DataGridView2.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView2.Rows.Add(lista.Count)
            For Each n In lista
                DataGridView2(columna, fila).Value = n.ID
                columna = columna + 1
                DataGridView2(columna, fila).Value = n.MUESTRA
                Dim l As New dListaPrecios
                l.ID = n.ANALISIS
                l = l.buscar
                If Not l Is Nothing Then
                    columna = columna + 1
                    DataGridView2(columna, fila).Value = l.DESCRIPCION
                End If
                columna = 0
                fila = fila + 1
            Next
        End If
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim idtipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        If Not idtipoinforme Is Nothing Then
            Dim tipoinforme As Integer = idtipoinforme.ID
            cajasImp = ""
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

            For Each t In ListCajas.Items

                Dim caja As New dCajas
                Dim lista As New ArrayList
                lista = caja.buscarPorCodigo(t.CODIGO)
                cajasImp = cajasImp + Format$(t.CODIGO) & " - "

                If lista IsNot Nothing Then
                    If lista.Count > 0 Then

                        Dim env2 As New dEnvioCajas()
                        env2.IDCAJA = lista(0).CODIGO
                        env2 = env2.buscarultimoenvioxcaja()


                        Dim agenciaPed As dEmpresaT = CType(ComboAgencia.SelectedItem, dEmpresaT)
                        Dim reciboPed As String = TextRemito.Text.Trim
                        Dim clientePEd As Long = TextIdProductor.Text
                        Dim observacionesPed As String = TextObservaciones.Text.Trim
                        Dim fec As String
                        fec = Format(System.DateTime.Now, "yyyy-MM-dd")
                        If Not agenciaPed Is Nothing Then
                            env2.IDAGENCIA = agenciaPed.ID
                        Else
                            env2.IDAGENCIA = 8
                        End If
                        env2.FECHARECIBO = fec
                        env2.CLIENTE = clientePEd
                        env2.OBSRECIBO = observacionesPed
                        env2.RECIBIDO = 1
                        env2.CARGADA = 0

                        If (env2.marcarrecibido(Usuario)) Then

                        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                        End If
                    End If
                End If
            Next

            If tipoinforme = 10 Then
                limpio_tabla_csm()
                graba_tabla_csm()
            End If
        End If
        guardar2()
        ListCajas.Items.Clear()
    End Sub
    Private Sub enviomailpulsa()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        nficha = TextId.Text.Trim
        Dim fichero As String = ""
        fichero = "\\192.168.1.10\E\NET\SOLICITUDES\S" & nficha & ".xls"
        If email <> "" Then
            'CONFIGURACIÓN DEL STMP 
            ' Llamamos al método buscar para obtener el objeto Credenciales
            Dim objetoCredenciales As dCredenciales = dCredenciales.buscar("notificaciones")

            _SMTP.Credentials = New System.Net.NetworkCredential(objetoCredenciales.CredencialesUsuario, objetoCredenciales.CredencialesPassword)
            _SMTP.Host = objetoCredenciales.CredencialesHost
            _SMTP.Port = 25
            _SMTP.EnableSsl = False

            _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
            ' CONFIGURACION DEL MENSAJE 
            _Message.[To].Add(email)
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

    Private Sub ComboTipoInforme_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboTipoInforme.SelectedIndexChanged
        Dim idtipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        Dim ficha As Long = TextId.Text.Trim
        If Not idtipoinforme Is Nothing Then
            If idtipoinforme.ID = 1 Then
                idtipoinf = 1
                idtipoinforme_ = 1
            ElseIf idtipoinforme.ID = 3 Then
                nroficha = TextId.Text
                idtipoinf = 3
                idtipoinforme_ = 3
            ElseIf idtipoinforme.ID = 4 Then
                nroficha = TextId.Text
                idtipoinf = 4
                idtipoinforme_ = 4
                Dim v As New FormSolicitudRodeo(Usuario, nroficha)
                v.ShowDialog()
            ElseIf idtipoinforme.ID = 6 Then
                idtipoinf = 6
                idtipoinforme_ = 6
            ElseIf idtipoinforme.ID = 7 Then
                idtipoinf = 7
                idtipoinforme_ = 7
            ElseIf idtipoinforme.ID = 8 Then
                idtipoinf = 8
                idtipoinforme_ = 8
            ElseIf idtipoinforme.ID = 9 Then
                idtipoinf = 9
                idtipoinforme_ = 9
            ElseIf idtipoinforme.ID = 10 Then
                idtipoinf = 10
                idtipoinforme_ = 10
            ElseIf idtipoinforme.ID = 11 Then
                idtipoinf = 11
                idtipoinforme_ = 11
            ElseIf idtipoinforme.ID = 13 Then
                idtipoinf = 13
                idtipoinforme_ = 13
            ElseIf idtipoinforme.ID = 14 Then
                idtipoinf = 14
                idtipoinforme_ = 14
            ElseIf idtipoinforme.ID = 15 Then
                idtipoinf = 15
                idtipoinforme_ = 15
            ElseIf idtipoinforme.ID = 16 Then
                idtipoinf = 16
                idtipoinforme_ = 16
            ElseIf idtipoinforme.ID = 17 Then
                idtipoinf = 17
                idtipoinforme_ = 17
            ElseIf idtipoinforme.ID = 18 Then
                idtipoinf = 18
                idtipoinforme_ = 18
            ElseIf idtipoinforme.ID = 19 Then
                idtipoinf = 19
                idtipoinforme_ = 19
            ElseIf idtipoinforme.ID = 20 Then
                idtipoinf = 20
                idtipoinforme_ = 20
            ElseIf idtipoinforme.ID = 21 Then
                idtipoinf = 21
                idtipoinforme_ = 21
            ElseIf idtipoinforme.ID = 99 Then
                idtipoinf = 99
                idtipoinforme_ = 99
            End If
        End If
        If TextIdProductor.Text = 150 Or TextIdProductor.Text = 2705 Or TextIdProductor.Text = 4427 Then
            If idtipoinf = 7 Or idtipoinf = 11 Or idtipoinf = 10 Then
                Dim v As New FormCodigos
                v.ShowDialog()
                If v._codigo <> "" Then
                    codigo = v._codigo
                End If
            End If
        End If
        cargarComboSubInformes2()
        cargarComboMuestras()
        listaranalisis()

        '
        If Not idtipoinforme Is Nothing Then
            If idtipoinforme.ID = 13 Or idtipoinforme.ID = 14 Then
                If TextIdProductor.Text.ToString <> "" Then
                    Dim pro As New dCliente
                    idprod = TextIdProductor.Text
                    pro.ID = idprod
                    pro = pro.buscar
                    If Not pro Is Nothing Then
                        If pro.TECNICO_SUELO_NUTRI = 1 Then
                            cbxTecnicoSueloNutri.Checked = True
                            cbxTecnicoSueloNutri.Visible = True
                        Else
                            cbxTecnicoSueloNutri.Checked = False
                            cbxTecnicoSueloNutri.Visible = True
                        End If
                    End If
                End If
            Else
                cbxTecnicoSueloNutri.Visible = False
            End If
        End If

    End Sub
    Public Sub cargarComboSubInformes2()
        Dim si As New dSubInforme
        Dim lista As New ArrayList
        Dim idtipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        Dim texto As Long = idtipoinf
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
    Private Sub ButtonBuscarProductor_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProductor.Click
        If TextId.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de ficha", MsgBoxStyle.Exclamation, "Atención") : TextId.Focus() : Exit Sub
        Dim v As New FormBuscarCliente
        v.ShowDialog()
        productorweb_com = ""
        If Not v.Cliente Is Nothing Then
            Dim cli As dCliente = v.Cliente
            If cli.CONTRATO = 0 Then
                MsgBox("El cliente no tiene contrato firmado.")
            End If
            If cli.FAC_CONTADO = 1 Then
                MsgBox("Este cliente es solo CONTADO!")
            End If
            If cli.PROLESA = 1 Then
                MsgBox("Este cliente es de PROLESA!")
            End If
            If cli.INCOBRABLE = 1 Then
                MsgBox("CLIENTE INCOBRABLE!!!")
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
                    If mc.MCCVTO < fechaact Then
                        vencido = 1
                    End If
                Next
            End If
            If vencido = 1 Then
                MsgBox("El cliente tiene deuda, no se puede continuar con la solicitud.")
            End If
            '*******************************************************************************
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
            idCliente = cli.ID

            'Cargar cajas pendientes del cliente
            'listar_solicitud_cajas(idCliente)

        End If
        If TextId.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de ficha", MsgBoxStyle.Exclamation, "Atención") : TextId.Focus() : Exit Sub
        guardar()




    End Sub
    Public Sub guardar()

        If TextId.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de ficha", MsgBoxStyle.Exclamation, "Atención") : TextId.Focus() : Exit Sub
        Dim id As Long = TextId.Text.Trim
        nuevaFicha = TextId.Text.Trim
        'VERIFICA SI LA FICHA EXISTE********
        Dim s As New dSolicitudAnalisis
        Dim modifica As Integer = 0
        s.ID = id
        s = s.buscar
        If Not s Is Nothing Then
            modifica = 1
        End If
        '**********************************
        Dim fechaingreso As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
        If TextIdProductor.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de productor", MsgBoxStyle.Exclamation, "Atención") : TextIdProductor.Focus() : Exit Sub
        Dim idproductor As Long = TextIdProductor.Text.Trim
        Dim idtipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        Dim idsubinforme As dSubInforme = CType(ComboSubInforme.SelectedItem, dSubInforme)
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
        Dim idfactura As Long = 0
        Dim web As Integer = 0
        Dim personal As Integer = 0
        Dim mail As Integer = 0
        Dim sol As New dSolicitudAnalisis()
        Dim fecing As String
        fecing = Format(fechaingreso, "yyyy-MM-dd")
        sol.ID = id
        sol.FECHAINGRESO = fecing
        sol.IDPRODUCTOR = idproductor
        If Not idtipoinforme Is Nothing Then
            sol.IDTIPOINFORME = idtipoinforme.ID
        End If
        If Not idsubinforme Is Nothing Then
            sol.IDSUBINFORME = idsubinforme.ID
        End If
        sol.IDTIPOFICHA = 1
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
        sol.FECHAENVIO = fecing
        If modifica = 0 Then
            If (sol.guardar(Usuario)) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            If (sol.modificar(Usuario)) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If


    End Sub
    Private Sub TextMuestras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextMuestras.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            agregar()
        End If
    End Sub
    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If DataGridView2.Columns(e.ColumnIndex).Name = "Quitar2" Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim muestra As String = ""
            Dim muestra2 As String = ""
            id = row.Cells("Id2").Value
            muestra = row.Cells("Id2").Value
            muestra2 = row.Cells("Muestra2").Value
            Dim n As New dNuevoAnalisis
            n.ID = id
            n.eliminar(Usuario)
            If tipoinforme = "Calidad de leche" Then
                Dim csm As New dCalidadSolicitudMuestra
                csm.FICHA = ficha
                csm.MUESTRA = muestra2
                csm.eliminarxmuestra(Usuario)
            End If

            Dim sm As New dRelSolicitudMuestras
            sm.FICHA = ficha
            sm.IDMUESTRA = muestra2
            sm.eliminarxmuestra(Usuario)

            listaranalisis2()
            '*******************************************************************************
            Dim nam As New dNuevoAnalisis
            Dim nmuestras As New ArrayList
            nmuestras = nam.listarporficha(ficha)
            tipoinforme = ComboTipoInforme.Text
            If tipoinforme <> "Control lechero" Or tipoinforme <> "Serología" Then
                If Not nmuestras Is Nothing Then
                    TextNMuestras.Text = nmuestras.Count
                Else
                    TextNMuestras.Text = 0
                End If
            End If
            nam = Nothing
            nmuestras = Nothing
            '*******************************************************************************
        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        graba_tabla_csm()
        guardar2()
    End Sub
    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
        limpiar2()
        buscarultimaficha()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiar()
        limpiar2()
        buscarultimaficha()
    End Sub
    Private Sub agregar()
        ficha = TextId.Text
        Dim muestra As String = TextMuestras.Text
        Dim n2 As New dNuevoAnalisis
        n2.FICHA = ficha

        If ComboMuestra.Text = "Compost" Then
            n2.MUESTRA = "COMPOST"
        Else
            n2.MUESTRA = muestra
        End If

        n2 = n2.buscarrepetidas()
        If Not n2 Is Nothing Then
            My.Computer.Audio.Play("c:\debug\aviso.wav")
            Dim result = MessageBox.Show("La muestra ya existe, desea agregarla?", "Atención", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                Exit Sub
                n2 = Nothing
            End If
        End If
        Dim listaanalisis As New ArrayList
        Dim listaanalisis2 As New ArrayList
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(2).Value = True Then
                listaanalisis.Add(row.Cells(0).Value)
            End If
        Next
        '*******************************************************************************
        Dim lista As New ArrayList
        For indice As Integer = 0 To listaanalisis.Count - 1 Step 1
            Dim p As New dPaquetes
            Dim id As Integer = 0
            id = listaanalisis.Item(indice)
            lista = p.listarxpadre(id)
            If Not lista Is Nothing Then
                For Each p In lista
                    listaanalisis2.Add(p.IDHIJO)
                Next
            Else
                listaanalisis2.Add(id)
            End If
            p = Nothing
        Next
        Dim listaf As New ArrayList ' lista factura
        For indice As Integer = 0 To listaanalisis.Count - 1 Step 1
            Dim p As New dPaquetes
            Dim id As Integer = 0
            Dim idpadre As Integer = 0
            id = listaanalisis.Item(indice)
            p.IDPADRE = id
            p = p.buscarxidpadre
            If Not p Is Nothing Then
                listaf.Add(p.IDPADRE)
            Else
                listaf.Add(id)
            End If
            p = Nothing
        Next
        Dim naf As New dNuevoAnalisis_Factura
        For indice2 As Integer = 0 To listaf.Count - 1 Step 1
            naf.FICHA = ficha
            naf.MUESTRA = muestra
            naf.ANALISIS = listaf.Item(indice2)
            naf.guardar(Usuario)
        Next
        Dim resultado As String = ""
        Dim resultado2 As String = ""
        Dim n As New dNuevoAnalisis
        Dim sm As New dRelSolicitudMuestras()
        Dim fechaingreso As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
        Dim fecing As String
        fecing = Format(fechaingreso, "yyyy-MM-dd")
        Dim nocolaveco As Integer
        If CheckFrascos.Checked = True Then
            nocolaveco = 1
        Else
            nocolaveco = 0
        End If
        For indice As Integer = 0 To listaanalisis2.Count - 1 Step 1
            n.FICHA = ficha
            n.MUESTRA = muestra
            n.DETALLEMUESTRA = muestra
            n.TIPOINFORME = idtipoinf
            n.ANALISIS = listaanalisis2.Item(indice)
            n.RESULTADO = resultado
            n.RESULTADO2 = resultado2
            n.FECHAPROCESO = fecing
            Dim lp As New dListaPrecios
            lp.ID = listaanalisis2.Item(indice)
            lp = lp.buscar
            If Not lp Is Nothing Then
                n.ORDEN = lp.ORDEN
                n.M = lp.MOSTRAR_R
            Else
                n.ORDEN = 0
            End If
            'si el tipo de análisis es Rosa de Bengala se guarda como finalizado
            If n.ANALISIS = 235 Or n.ANALISIS = 312 Or n.ANALISIS = 313 Then
                n.FINALIZADO = 1
            End If
            sm.FICHA = ficha
            sm.FECHA = fecing
            sm.IDTIPOINFORME = idtipoinf
            sm.IDMUESTRA = muestra
            sm.NOCOLAVECO = nocolaveco
            n.guardar(Usuario)
            sm.guardar(Usuario)
            listaranalisis2()
            TextMuestras.Text = ""
            TextMuestras.Focus()
        Next
        '*******************************************************************************
        Dim nam As New dNuevoAnalisis
        Dim nmuestras As New ArrayList
        nmuestras = nam.listarporficha(ficha)
        tipoinforme = ComboTipoInforme.Text
        If tipoinforme <> "Control lechero" Or tipoinforme <> "Serología" Then
            If Not nmuestras Is Nothing Then
                TextNMuestras.Text = nmuestras.Count
            Else
                TextNMuestras.Text = 0
            End If
        End If
        nam = Nothing
        nmuestras = Nothing
        '*******************************************************************************
        n = Nothing
    End Sub

    Private Sub ButtonAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregar.Click
        agregar()
    End Sub

    Private Sub agregar_registro_facturacion()
        '*** AGREGO REGISTROS EN TABLA FACTURACION *************************************
        Dim escontrol As Integer = 0
        Dim nmuestras As Integer = 0
        Dim listaana As New ArrayList
        Dim na As New dNuevoAnalisis
        Dim naf As New dNuevoAnalisis_Factura
        Dim sa As New dSolicitudAnalisis
        Dim c As New dCliente
        Dim kmts As Double = 0
        Dim idcli As Integer = 0
        Dim listaprecio As Integer = 0
        sa.ID = ficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            idcli = sa.IDPRODUCTOR
            kmts = sa.KMTS
            nmuestras = sa.NMUESTRAS
            If sa.IDTIPOINFORME = 1 Or sa.IDTIPOINFORME = 8 Then
                escontrol = 1
            End If
        End If
        c.ID = idcli
        c = c.buscar
        If Not c Is Nothing Then
            listaprecio = c.FAC_LISTA
        End If
        listaana = naf.listardistintosanalisis(ficha)
        If Not listaana Is Nothing Then
            Dim listaana2 As New ArrayList
            Dim naf2 As New dNuevoAnalisis_Factura
            Dim idana As Integer = 0
            For Each naf In listaana
                idana = naf.ANALISIS
                listaana2 = naf2.listarxanalisis(ficha, idana)
                If Not listaana2 Is Nothing Then
                    Dim cantidad As Double = 0
                    Dim precio As Double = 0
                    Dim subtotal As Double = 0
                    Dim lp As New dListaPrecios
                    For Each naf2 In listaana2
                        lp.ID = naf2.ANALISIS
                        lp = lp.buscar
                        If listaprecio = 1 Then
                            precio = lp.PRECIO1
                        ElseIf listaprecio = 2 Then
                            If lp.PRECIO2 <> 0 Then
                                precio = lp.PRECIO2
                            Else
                                precio = lp.PRECIO1
                            End If
                        ElseIf listaprecio = 3 Then
                            If lp.PRECIO3 <> 0 Then
                                precio = lp.PRECIO3
                            Else
                                precio = lp.PRECIO1
                            End If
                        ElseIf listaprecio = 4 Then
                            If lp.PRECIO4 <> 0 Then
                                precio = lp.PRECIO4
                            Else
                                precio = lp.PRECIO1
                            End If
                        ElseIf listaprecio = 5 Then
                            If lp.PRECIO5 <> 0 Then
                                precio = lp.PRECIO5
                            Else
                                precio = lp.PRECIO1
                            End If
                        ElseIf listaprecio = 6 Then
                            If lp.PRECIO6 <> 0 Then
                                precio = lp.PRECIO6
                            Else
                                precio = lp.PRECIO1
                            End If
                        ElseIf listaprecio = 7 Then
                            If lp.PRECIO7 <> 0 Then
                                precio = lp.PRECIO7
                            Else
                                precio = lp.PRECIO1
                            End If
                        End If
                    Next
                    lp = Nothing
                    cantidad = listaana2.Count
                    subtotal = cantidad * precio
                    Dim f As New dFacturacion
                    If escontrol = 1 Then
                        cantidad = nmuestras
                        subtotal = cantidad * precio
                    End If
                    f.FICHA = ficha
                    f.CANTIDAD = cantidad
                    f.ANALISIS = idana
                    f.PRECIO = precio
                    f.SUBTOTAL = subtotal
                    f.guardar(Usuario)
                    f = Nothing
                    cantidad = 0
                End If
            Next
            naf2 = Nothing
            If kmts > 0 Then
                Dim fm As New dFacturacion
                Dim lpm As New dListaPrecios
                lpm.ID = 241
                lpm = lpm.buscar
                Dim stm As Double = 0
                stm = kmts * lpm.PRECIO1
                fm.FICHA = ficha
                fm.CANTIDAD = kmts
                fm.ANALISIS = 241
                fm.PRECIO = lpm.PRECIO1
                fm.SUBTOTAL = stm
                fm.guardar(Usuario)
                fm = Nothing
                lpm = Nothing
                Dim fm2 As New dFacturacion
                Dim lpm2 As New dListaPrecios
                lpm2.ID = 236
                lpm2 = lpm2.buscar
                Dim stm2 As Double = 0
                stm2 = nmuestras * lpm2.PRECIO1
                fm2.FICHA = ficha
                fm2.CANTIDAD = nmuestras
                fm2.ANALISIS = 236
                fm2.PRECIO = lpm2.PRECIO1
                fm2.SUBTOTAL = stm2
                fm2.guardar(Usuario)
                fm2 = Nothing
                lpm2 = Nothing
            End If
        End If
        '*******************************************************************************
        na = Nothing
        sa = Nothing
        c = Nothing
    End Sub
    Private Sub imprimir_solicitud()
        Dim nuevo_analisis As New dNuevoAnalisis
        Dim lista_analisis As New ArrayList
        Dim UNIT833 As Boolean = False
        Dim PCR As Boolean = False
        lista_analisis = nuevo_analisis.listarporficha3(nuevaFicha)
        Dim p2 As New dCliente
        'CHEQUE SI SE DEBE HACER ANALISIS CON METODO DE UNIT833
        If Not lista_analisis Is Nothing Then
            For Each nuevo_analisis In lista_analisis
                If nuevo_analisis.ANALISIS = 354 Or nuevo_analisis.ANALISIS = 393 Or nuevo_analisis.ANALISIS = 396 Or nuevo_analisis.ANALISIS = 394 Or nuevo_analisis.ANALISIS = 395 Then
                    UNIT833 = True
                    Exit For
                End If
            Next
            For Each nuevo_analisis In lista_analisis
                If nuevo_analisis.ANALISIS = 402 Or nuevo_analisis.ANALISIS = 403 Or nuevo_analisis.ANALISIS = 404 Or nuevo_analisis.ANALISIS = 405 Then
                    PCR = True
                    Exit For
                End If
            Next
        End If

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
        Dim fechamuestreo As Date = DateMuestreo.Value
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
        Dim obsinternas As String = TextObsInternas.Text.Trim
        Dim pago As Integer

        If codigo <> "" Then
            observaciones = "Codigo EMPI: (" + codigo + ") , " + TextObservaciones.Text.Trim
        End If
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
        x1hoja.Cells(fila, columna).formula = "Versión 04 del 01/10/18"
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
        If ComboTipoInforme.Text = "Control Lechero" Then
            x1hoja.Cells(fila, columna).formula = "Fecha de muestreo:" & " " & fechamuestreo
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = 1
            fila = fila + 1
        Else
            columna = 1
            fila = fila + 1
        End If
        x1hoja.Cells(fila, columna).formula = "Nº de Muestras:" & " " & nmuestras
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 4
        x1hoja.Cells(fila, columna).formula = "Realizada por:" & " " & Usuario.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Muestra de:" & " " & muestra
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
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
        Dim listasc As New ArrayList
        Dim listaso As New ArrayList
        Dim cajas As String = ""
        Dim gradillas As String = ""
        Dim otros As String = ""
        listasc = sc.listarporficha(ficha)
        listaso = so.listarporficha(ficha)
        If Not listasc Is Nothing Then
            For Each sc In listasc
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
        If Not listaso Is Nothing Then
            For Each so In listaso
                otros = otros + so.DESCRIPCION & " "
            Next
        End If
        x1hoja.Range("D10", "G11").Merge()
        x1hoja.Range("D10", "G11").WrapText = True
        x1hoja.Cells(fila, columna).formula = "Caja/s nº:" & " " & cajasImp
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Conservante:" & " " & conservante
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 3
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).formula = "Temperatura:" & " " & temperatura
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 3
        fila = fila + 3
        x1hoja.Cells(fila, columna).formula = "Otros:" & " " & otros
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila - 2
        x1hoja.Cells(fila, columna).formula = "Derramadas en el envío:" & " " & derramadas
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Desvío autorizado por el cliente:" & " " & desvio
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 3
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Tipo de informe:" & " " & tipoinforme
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        If tipoinforme = "Control Lechero" Or tipoinforme = "Calidad de leche" Then
            columna = columna + 4
            x1hoja.Cells(fila, columna).formula = "Bentley  //  Bentley 600  //  Delta 600"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = 1
        ElseIf tipoinforme = "Serología" Then
            columna = columna + 4
            x1hoja.Cells(fila, columna).formula = "Antígeno:"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = 1
        End If
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Análisis solicitado:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '***  LISTADO DE ANALISIS REQUERIDOS *********************************************************************
        Dim na As New dNuevoAnalisis
        Dim listana As New ArrayList
        Dim listaanalisis As String = ""
        Dim listaanalisis2 As String = ""
        listana = na.listardistintosanalisis(ficha)

        If Not listana Is Nothing Then
            For Each na In listana

                x1hoja.Cells(fila, columna).rowheight = 20
                x1hoja.Cells(fila, columna).Formula = listaanalisis
                x1hoja.Range("A" & fila, "G" & fila).WrapText = True
                x1hoja.Range("A" & fila, "G" & fila).Merge()
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Size = 10

                Dim cantidad As Integer = 0
                Dim listacant As New ArrayList
                listacant = na.listarxfichaxanalisis(ficha, na.ANALISIS)
                cantidad = listacant.Count
                Dim lp As New dListaPrecios
                lp.ID = na.ANALISIS
                lp = lp.buscar
                listaanalisis = lp.ABREVIATURA & " ___/___/___ - _____ " & vbCrLf
                listaanalisis2 = listaanalisis2 & cantidad & " " & lp.ABREVIATURA & " - "

                fila = fila + 1
            Next
            If subtipoinforme = "Semen y Venereas" Then
                listaanalisis = "Evaluación biológica básica"
            End If
        Else
            If subtipoinforme = "Brucelosis" Then
                listaanalisis = "Brucelosis"
            End If
        End If
        '***  LISTADO DE ANALISIS TERCERIZADOS *********************************************************************
        Dim at As New dAnalisisTercerizado
        Dim listanat As New ArrayList
        Dim listaanalisist As String = ""
        listanat = at.listardistintosanalisis(ficha)
        If Not listanat Is Nothing Then
            Dim dep1 As Integer = 0
            Dim dep2 As Integer = 0
            For Each at In listanat
                Dim att As New dAnalisisTercerizadoTipo
                att.ID = at.ANALISIS
                att = att.buscar
                If att.DEPENDE <> 0 Then
                    dep1 = att.DEPENDE
                    Dim at2 As New dAnalisisTercerizadoTipo
                    at2.ID = att.DEPENDE
                    at2 = at2.buscar
                    If dep1 <> dep2 Then
                        listaanalisist = listaanalisist & at2.NOMBRE & " - "
                        at2 = Nothing
                    End If
                    dep2 = att.DEPENDE
                Else
                    listaanalisist = listaanalisist & att.NOMBRE & " - "
                End If
            Next
        End If
        If listaanalisist <> "" Then
            listaanalisis = listaanalisis & " / OTROS LABORATORIOS: " & listaanalisist
        End If
        x1hoja.Cells(fila, columna).rowheight = 20
        x1hoja.Cells(fila, columna).Formula = listaanalisis
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2
        '***********************************************************************************************
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Enviado:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Fecha de envío: ____/____/_________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 12
        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "Responsable: ___________________________________"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 12
        fila = fila + 2
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Identificación de las muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        '*** LISTADO DE MUESTRAS *********************************************************************************
        Dim na2 As New dNuevoAnalisis
        Dim listam As New ArrayList
        Dim listamuestras As String = ""
        listam = na2.listarporfichamuestra(ficha)
        If Not listam Is Nothing Then
            For Each na2 In listam
                listamuestras = listamuestras & na2.MUESTRA & " - "
            Next
        End If
        x1hoja.Cells(fila, columna).rowheight = 80
        x1hoja.Cells(fila, columna).Formula = listamuestras
        x1hoja.Range("A" & fila, "G" & fila).WrapText = True
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1

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
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Observaciones internas:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1

        If obsinternas <> "" Then
            x1hoja.Cells(fila, columna).rowheight = 40
            x1hoja.Cells(fila, columna).Formula = obsinternas
            x1hoja.Range("A" & fila, "G" & fila).WrapText = True
            x1hoja.Range("A" & fila, "G" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 10
        End If

        fila = fila + 1
        x1hoja.Range("A" & fila, "G" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).rowheight = 2
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Observaciones para informe:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1

        If observaciones <> "" Then
            x1hoja.Cells(fila, columna).rowheight = 40
            x1hoja.Cells(fila, columna).Formula = observaciones
            x1hoja.Range("A" & fila, "G" & fila).WrapText = True
            x1hoja.Range("A" & fila, "G" & fila).Merge()
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 2
            x1hoja.Range("A" & fila, "G" & fila).Merge()
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).rowheight = 2
            fila = fila + 1
        End If

        If tipoinforme = "Calidad de leche" Or tipoinforme = "Suelos" Then
            x1hoja.Cells(fila, columna).formula = listaanalisis2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1
        End If
        If pago = 1 Then
            x1hoja.Cells(fila, columna).formula = "PAGO OK"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 14
            fila = fila + 1
        End If
        'CONTROLA SI EL CLIENTE TIENE ALGUN CONVENIO*****************************************
        Dim sa2 As New dSolicitudAnalisis
        Dim cli As Integer = 0
        Dim listaconv As String = ""
        sa2.ID = ficha
        sa2 = sa2.buscar
        If Not sa2 Is Nothing Then

            p2.ID = sa2.IDPRODUCTOR
            p2 = p2.buscar
            If Not p2 Is Nothing Then
                cli = p2.ID
                Dim cc As New dClienteConvenio
                Dim listaconvenios As New ArrayList
                listaconvenios = cc.listarporcliente(cli)
                If Not listaconvenios Is Nothing Then
                    For Each cc In listaconvenios
                        Dim c As New dConvenio
                        c.ID = cc.CONVENIO
                        c = c.buscar
                        If Not c Is Nothing Then
                            listaconv = listaconv & c.NOMBRE & " "
                        End If
                    Next
                End If
            End If
        End If
        If listaconv <> "" Then
            ''If sa2.IDTIPOINFORME = 1 Then
            x1hoja.Cells(fila, columna).formula = listaconv
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 18
            fila = fila + 1
            'End If
        End If
        If UNIT833 = True Then
            x1hoja.Cells(fila, columna).formula = "Análisis por UNIT 833"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 18
            fila = fila + 1
        End If
        If PCR = True Then
            x1hoja.Cells(fila, columna).formula = "Análisis por PCR"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 18
            fila = fila + 1
        End If
        If p2.TECNICO_SUELO_NUTRI = 1 And tipoinforme = "Suelos" Or tipoinforme = "Nutrición" Then
            x1hoja.Cells(fila, columna).formula = "Tiene Técnico para Suelo o Nutrición"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 18
        ElseIf p2.TECNICO_SUELO_NUTRI = 0 And tipoinforme = "Suelos" Or tipoinforme = "Nutrición" Then
            x1hoja.Cells(fila, columna).formula = "NO tiene Técnico para Suelo o Nutrición"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 18
        End If
        '***************************************************************************************

        x1app.DisplayAlerts = False 'NO PREGUNTA SI EL ARCHIVO EXISTE
        'x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        x1hoja.SaveAs("\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls")
        x1app.Visible = True
        x1libro.PrintPreview()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub limpio_tabla_csm()
        Dim ficha_ As Long = 0
        ficha_ = TextId.Text.Trim
        Dim csm As New dCalidadSolicitudMuestra
        csm.FICHA = ficha_
        csm.eliminar2(Usuario)
    End Sub
    Private Sub graba_tabla_csm()
        Dim id As Long = 0
        Dim ficha As Long = 0
        Dim ficha_ As Long = 0
        Dim muestra As String = ""
        Dim rb As Integer = 0
        Dim rc As Integer = 0
        Dim composicion As Integer = 0
        Dim composicion_suero As Integer = 0
        Dim crioscopia As Integer = 0
        Dim inhibidores As Integer = 0
        Dim charm As Integer = 0
        Dim esporulados As Integer = 0
        Dim urea As Integer = 0
        Dim termofilos As Integer = 0
        Dim psicrotrofos As Integer = 0
        Dim crioscopia_crioscopo As Integer = 0
        Dim caseina As Integer = 0
        Dim aflatoxina As Integer = 0
        Dim na As New dNuevoAnalisis
        Dim lista As New ArrayList
        ficha_ = TextId.Text.Trim
        lista = na.listarporfichamuestra(ficha_)
        If Not lista Is Nothing Then
            For Each na In lista
                Dim na2 As New dNuevoAnalisis
                Dim lista2 As New ArrayList
                Dim muestra_ As String = ""
                muestra_ = na.MUESTRA
                lista2 = na2.listarpormuestra(ficha_, muestra_)
                If Not lista2 Is Nothing Then
                    id = 0
                    ficha = 0
                    muestra = ""
                    rb = 0
                    rc = 0
                    composicion = 0
                    composicion_suero = 0
                    crioscopia = 0
                    inhibidores = 0
                    charm = 0
                    esporulados = 0
                    urea = 0
                    termofilos = 0
                    psicrotrofos = 0
                    crioscopia_crioscopo = 0
                    caseina = 0
                    aflatoxina = 0
                    For Each na2 In lista2
                        If na2.ANALISIS = 1 Or na2.ANALISIS = 100 Or na2.ANALISIS = 101 Or na2.ANALISIS = 410 Then
                            rb = 1
                        End If
                        If na2.ANALISIS = 2 Or na2.ANALISIS = 100 Or na2.ANALISIS = 101 Or na2.ANALISIS = 410 Then
                            rc = 1
                        End If
                        If na2.ANALISIS = 3 Or na2.ANALISIS = 100 Or na2.ANALISIS = 103 Or na2.ANALISIS = 410 Then
                            composicion = 1
                        End If
                        If na2.ANALISIS = 311 Then
                            composicion_suero = 1
                        End If
                        If na2.ANALISIS = 4 Or na2.ANALISIS = 103 Or na2.ANALISIS = 411 Then
                            crioscopia = 1
                            'Guarda Crioscopia_fichas *************************
                            Dim cf As New dCrioscopia_Fichas
                            cf.FICHA = ficha_
                            cf.MUESTRA = muestra_
                            cf.MARCA = 0
                            cf.guardar(Usuario)
                            cf = Nothing
                            '**************************************************
                        End If
                        If na2.ANALISIS = 5 Then
                            inhibidores = 1
                        End If
                        If na2.ANALISIS = 196 Then
                            charm = 1
                        End If
                        If na2.ANALISIS = 8 Then
                            esporulados = 1
                        End If
                        If na2.ANALISIS = 60 Or na2.ANALISIS = 412 Then
                            urea = 1
                        End If
                        If na2.ANALISIS = 237 Then
                            termofilos = 1
                        End If
                        If na2.ANALISIS = 61 Then
                            psicrotrofos = 1
                        End If
                        If na2.ANALISIS = 102 Then
                            crioscopia_crioscopo = 1
                        End If
                        If na2.ANALISIS = 118 Then
                            caseina = 1
                        End If
                        If na2.ANALISIS = 162 Then
                            aflatoxina = 1
                            'Guarda Micotoxinas_leche *************************
                            Dim m As New dMicotoxinasLeche
                            m.FICHA = ficha_
                            Dim fecha As Date = Now()
                            Dim _fecha As String
                            _fecha = Format(fecha, "yyyy-MM-dd")
                            m.FECHA = _fecha
                            m.MUESTRA = muestra
                            m.MARCA = 0
                            m.guardar(Usuario)
                            m = Nothing
                        End If
                    Next
                    Dim csm As New dCalidadSolicitudMuestra
                    csm.FICHA = ficha_
                    csm.MUESTRA = muestra_
                    csm.RB = rb
                    csm.RC = rc
                    csm.COMPOSICION = composicion
                    csm.COMPOSICIONSUERO = composicion_suero
                    csm.CRIOSCOPIA = crioscopia
                    csm.INHIBIDORES = inhibidores
                    csm.CHARM = charm
                    csm.ESPORULADOS = esporulados
                    csm.UREA = urea
                    csm.TERMOFILOS = termofilos
                    csm.PSICROTROFOS = psicrotrofos
                    csm.CRIOSCOPIA_CRIOSCOPO = crioscopia_crioscopo
                    csm.CASEINA = caseina
                    csm.AFLATOXINA = aflatoxina
                    csm.guardar(Usuario)
                End If
                na2 = Nothing
                lista2 = Nothing
            Next
            na = Nothing
            lista = Nothing
        End If
    End Sub
    Private Sub ButtonBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click
        limpiar()
        Dim v As New FormBuscarSolicitud(Usuario)
        v.ShowDialog()
        If Not v.SolicitudAnalisis Is Nothing Then
            Dim sol As dSolicitudAnalisis = v.SolicitudAnalisis
            TextId.Text = sol.ID
            DateFechaIngreso.Value = sol.FECHAINGRESO
            Dim p As New dCliente
            TextIdProductor.Text = sol.IDPRODUCTOR
            p.ID = Val(TextIdProductor.Text)
            p = p.buscar
            If Not p Is Nothing Then
                TextProductor.Text = p.NOMBRE
            End If
            idtipoinf = sol.IDTIPOINFORME
            ComboTipoInforme.SelectedItem = Nothing
            Dim ti As dTipoInforme
            For Each ti In ComboTipoInforme.Items
                If ti.ID = sol.IDTIPOINFORME Then
                    ComboTipoInforme.SelectedItem = ti
                    Exit For
                End If
            Next
            tipoinforme = ComboTipoInforme.Text
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
            If sol.MUESTREO = 1 Then
                CheckMuestreo.Checked = True
            Else
                CheckMuestreo.Checked = False
            End If
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
            btnImprimir.Visible = True

        End If
        If TextId.Text <> "" Then
            If TextId.Text > 0 Then
                ficha = TextId.Text.Trim
                'listar_solicitud_cajas(idCliente)
                listaranalisis2()
                '*********************************************
                Dim nam As New dNuevoAnalisis
                Dim nmuestras As New ArrayList
                nmuestras = nam.listarporficha(ficha)
                If Not nmuestras Is Nothing Then
                    TextNMuestras.Text = nmuestras.Count
                Else
                    TextNMuestras.Text = 0
                End If
                nam = Nothing
                nmuestras = Nothing
                '*********************************************
            End If
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
            'listar_solicitud_cajas(idCliente)
            TextCaja.Text = ""
            TextFrascos.Text = ""
            TextRemito.Text = ""
            ComboCajas.Focus()
        End If
    End Sub
    Private Sub marcarrecibido()
        Dim p As New dPedidos
        Dim lista As New ArrayList
        Dim id As Integer = TextId.Text.Trim
        p.ID = id
        If TextIdEnvio.Text <> "" Then
            id = TextIdEnvio.Text.Trim
        Else
            Dim e As New dEnvioCajas

            'Agregando lectores de codifos 31/7/2023

            If txtCajasTipeables.Text <> "" Then
                Dim caja As New dCajas
                caja.CODIGO = txtCajasTipeables.Text
                lista = caja.buscarPorCodigo(caja.CODIGO)

                If lista IsNot Nothing Then
                    If lista.Count > 0 Then

                        Dim env2 As New dEnvioCajas()
                        env2.IDCAJA = txtCajasTipeables.Text
                        env2 = env2.buscarultimoenvioxcaja()


                        Dim agenciaPed As dEmpresaT = CType(ComboAgencia.SelectedItem, dEmpresaT)
                        Dim reciboPed As String = TextRemito.Text.Trim
                        Dim clientePEd As Long = TextIdProductor.Text
                        Dim observacionesPed As String = TextObservaciones.Text.Trim
                        Dim fec As String
                        fec = Format(System.DateTime.Now, "yyyy-MM-dd")
                        If Not agenciaPed Is Nothing Then
                            env2.IDAGENCIA = agenciaPed.ID
                        Else
                            env2.IDAGENCIA = 8
                        End If
                        ' env2.RECIBIDO = reciboPed
                        env2.FECHARECIBO = fec
                        env2.CLIENTE = clientePEd
                        env2.OBSRECIBO = observacionesPed
                        env2.RECIBIDO = 1
                        env2.CARGADA = 0

                        If (env2.marcarrecibido(Usuario)) Then
                            MsgBox("Registro actualizado", MsgBoxStyle.Information, "Atención")
                        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                        End If

                        Dim c As New dCajas
                        'c.CODIGO = env2.IDCAJA
                        'If c.desmarcar(Usuario) Then
                        'Else
                        '    MsgBox("Caja sin desmarcar", MsgBoxStyle.Information, "Atención")
                        'End If

                        'p.marcarEnvio(p.ID, Usuario)
                        If ComboAgencia.Text = "RETIRA EN COLAVECO" Or ComboAgencia.Text = "Retira ahora" Then
                            e.IDCAJA = txtCajasTipeables.Text
                        End If
                    Else
                        MsgBox("Cadigo de caja no existe", MsgBoxStyle.Critical, "Atención")
                    End If
                Else
                    MsgBox("Cadigo de caja no existe", MsgBoxStyle.Critical, "Atención")
                End If


            ElseIf ComboCajas.Text.Trim <> "" Then

                Dim caja As New dCajas
                caja.CODIGO = ComboCajas.Text.Trim
                lista = caja.buscarPorCodigo(caja.CODIGO)

                If lista IsNot Nothing Then
                    If lista.Count > 0 Then

                        Dim env2 As New dEnvioCajas()
                        env2.IDCAJA = ComboCajas.Text.Trim
                        env2 = env2.buscarultimoenvioxcaja()


                        Dim agenciaPed As dEmpresaT = CType(ComboAgencia.SelectedItem, dEmpresaT)
                        Dim reciboPed As String = TextRemito.Text.Trim
                        Dim clientePEd As Long = TextIdProductor.Text
                        Dim observacionesPed As String = TextObservaciones.Text.Trim
                        Dim fec As String
                        fec = Format(System.DateTime.Now, "yyyy-MM-dd")
                        If Not agenciaPed Is Nothing Then
                            env2.IDAGENCIA = agenciaPed.ID
                        Else
                            env2.IDAGENCIA = 8
                        End If
                        ' env2.RECIBIDO = reciboPed
                        env2.FECHARECIBO = fec
                        env2.CLIENTE = clientePEd
                        env2.OBSRECIBO = observacionesPed
                        env2.RECIBIDO = 1
                        env2.CARGADA = 0

                        If (env2.marcarrecibido(Usuario)) Then
                            MsgBox("Registro actualizado", MsgBoxStyle.Information, "Atención")
                        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                        End If

                        Dim c As New dCajas
                        'c.CODIGO = env2.IDCAJA
                        'If c.desmarcar(Usuario) Then
                        'Else
                        '    MsgBox("Caja sin desmarcar", MsgBoxStyle.Information, "Atención")
                        'End If

                        'p.marcarEnvio(p.ID, Usuario)
                        If ComboAgencia.Text = "RETIRA EN COLAVECO" Or ComboAgencia.Text = "Retira ahora" Then
                            e.IDCAJA = txtCajasTipeables.Text
                        End If
                    Else
                        MsgBox("Cadigo de caja no existe", MsgBoxStyle.Critical, "Atención")
                    End If
                Else
                    MsgBox("Cadigo de caja no existe", MsgBoxStyle.Critical, "Atención")
                End If



                'Dim caja As New dCajas
                'caja.CODIGO = ComboCajas.Text.Trim
                'lista = caja.buscarPorCodigo(caja.CODIGO)

                'If lista IsNot Nothing Then
                '    If lista.Count > 0 Then
                '        p.marcarEnvio(p.ID, Usuario)
                '        If ComboAgencia.Text = "RETIRA EN COLAVECO" Or ComboAgencia.Text = "Retira ahora" Then
                '            e.IDCAJA = ComboCajas.Text.Trim
                '        End If
                '    Else
                '        MsgBox("Cadigo de caja no existe", MsgBoxStyle.Critical, "Atención")
                '    End If
                'Else
                '    MsgBox("Cadigo de caja no existe", MsgBoxStyle.Critical, "Atención")
                'End If

            Else
                MsgBox("Ingrese codigo de la Caja", MsgBoxStyle.Critical, "Atención")
            End If

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
        Dim env As New dEnvioCajas()
        If ComboCajas.Text.Trim.Length > 0 Or txtCajasTipeables.Text <> "" Then
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
            env.CARGADA = 0
        End If
        If (env.marcarrecibido(Usuario)) Then
            MsgBox("Caja recibida", MsgBoxStyle.Information, "Atención")
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
    End Sub
    Private Sub solicitud_caja()
        Dim ficha As Long = TextId.Text.Trim
        Dim idenvio As Long
        If TextIdEnvio.Text <> "" Then
            idenvio = TextIdEnvio.Text.Trim
        End If

        'Agregando lectores de codifos 1/8/2023
        If ComboCajas.Text.Trim <> "" Or txtCajasTipeables.Text <> "" Then
            If txtCajasTipeables.Text <> "" Then
                idcaja = txtCajasTipeables.Text
            Else
                idcaja = ComboCajas.Text.Trim
            End If
        Else : MsgBox("Error, no se completo Codigo de Caja", MsgBoxStyle.Critical, "Atención")

        End If

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
        If ComboCajas.Text.Trim.Length > 0 Or txtCajasTipeables.Text <> "" Then
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
            MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
    End Sub
    Public Sub listar_solicitud_cajas(ByVal idCliente As Integer)
        Dim sc As New dRelSolicitudCajas
        Dim ec As New dEnvioCajas
        Dim lista As New ArrayList
        lista = sc.listarCajasPendientesCliente(idCliente)
        ListCajas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ec In lista
                    ListCajas().Items.Add(ec)
                Next
            End If
        End If
    End Sub
    Private Sub ButtonAnalisisTercerizados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAnalisisTercerizados.Click
        Dim f As Long = TextId.Text.Trim
        Dim t As Integer = idtipoinf
        Dim v As New FormAnalisisTercerizados(Usuario, f, t)
        v.ShowDialog()
    End Sub

    Private Sub CheckDesvio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckDesvio.CheckedChanged
        If CheckDesvio.Checked = True Then
            Dim id_ficha As Long = TextId.Text
            Dim v As New FormDescarteMuestras(Usuario, id_ficha)
            v.Show()
        End If
    End Sub

    Private Sub ComboCajas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCajas.SelectedIndexChanged
        'buscarultimoenvio()
    End Sub
    Private Sub buscarultimoenvio()
        Dim e As New dEnvioCajas

        'Agregando lectores de codifos 1/8/2023
        If ComboCajas.Text.Trim <> "" Or txtCajasTipeables.Text <> "" Then
            If txtCajasTipeables.Text <> "" Then
                e.IDCAJA = txtCajasTipeables.Text
            Else
                e.IDCAJA = ComboCajas.Text.Trim
            End If
        Else : MsgBox("Error, no se completo Codigo de Caja", MsgBoxStyle.Critical, "Atención")

        End If

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

    Private Sub ButtonAgregarCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregarCaja.Click
        Dim v As New FormCajas(Usuario)
        v.ShowDialog()
        cargarComboCajas()
    End Sub

    Private Sub ButtonEliminarCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not ListCajas.SelectedItem Is Nothing Then
            Dim sc As New dRelSolicitudCajas
            Dim idCaja As String
            Dim indice As Integer

            Dim ec As New dEnvioCajas
            ec.IDCAJA = ListCajas.SelectedItem.IDCAJA

            ec = ec.buscarultimoenvio()
            If Not ec Is Nothing Then
                TextIdEnvio.Text = ec.ID
                TextFrascos.Text = ec.FRASCOS
                Dim c As New dCliente
                c.ID = ec.IDPRODUCTOR
            Else
                'TextGradilla1.Focus()
                TextRemito.Focus()
            End If


            Dim elementoSeleccionado As String
            elementoSeleccionado = ListCajas.SelectedItem.ToString

            ' Dividir el elemento seleccionado en palabras
            Dim palabras() As String

            ' Utilizar una expresión regular para dividir la cadena en palabras
            Dim regex As Object
            regex = CreateObject("VBScript.RegExp")
            regex.Global = True
            regex.Pattern = "\S+" ' Divide en base a espacios en blanco
            Dim primerValor As String
            Dim matches As Object
            matches = regex.Execute(elementoSeleccionado)

            ' Verificar si se encontraron coincidencias
            If matches.Count > 0 Then
                ' Obtener el primer valor (primera palabra)

                primerValor = matches(0).Value

                ' Mostrar el primer valor en un MsgBox
                MsgBox("El primer valor del elemento seleccionado es: " & primerValor)
            Else
                MsgBox("El elemento seleccionado no contiene ninguna palabra.")
            End If


            If (sc.eliminarPorIdCaja(primerValor)) Then
                desmarcarrecibido()
                MsgBox("Caja eliminada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        'limpiar2()
        'listar_solicitud_cajas(idCliente)

    End Sub
    Private Sub desmarcarrecibido()
        Dim id As Long = TextIdEnvio.Text.Trim
        Dim env As New dEnvioCajas()
        env.ID = id
        env.IDAGENCIA = 0
        env.RECIBO = "Ingreso desde nueva Solicitud"
        env.FECHARECIBO = System.DateTime.Now
        env.OBSRECIBO = ""
        env.RECIBIDO = 1
        env.CARGADA = 0
        env.IDCAJA = ListCajas.SelectedItem.IDCAJA

        If (env.marcarrecibido(Usuario)) Then
            MsgBox("Registro actualizado", MsgBoxStyle.Information, "Atención")
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If

        'Desmarque de caja 

        Dim c As New dCajas
        c.CODIGO = env.IDCAJA
        If c.desmarcar(Usuario) Then
        Else
            MsgBox("Caja sin desmarcar", MsgBoxStyle.Information, "Atención")
        End If


    End Sub

    Private Sub TextRemito_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextRemito.MouseClick

    End Sub

    Private Sub TextRemito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextRemito.TextChanged

    End Sub

    Private Sub TextOtros_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextOtros.KeyPress

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

    Private Sub ComboSubInforme_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboSubInforme.SelectedIndexChanged
        Dim fechaingreso As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
        Dim fecha As String
        fecha = Format(fechaingreso, "yyyy-MM-dd")
        If idtipoinforme_ = 3 Then
            Dim v As New FormSolicitudAgua(Usuario, nroficha, fecha)
            v.ShowDialog()
        End If
        If idtipoinforme_ = 8 Then
            Dim v As New FormSinaveleFicha(Usuario, nroficha)
            v.ShowDialog()
        End If
    End Sub

    Private Sub TextMuestras_TextChanged(sender As Object, e As EventArgs) Handles TextMuestras.TextChanged

    End Sub

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
        Dim pie_estadosolicitud As String = "En nuestro sitio web https://colavecoresults.ddns.net:8080/LabColJavaEnvironment/com.labcol.colavecologin, puede ver el estado de su solicitud."
        Dim pro As New dCliente
        Dim nombre_productor As String = ""
        pro.ID = TextIdProductor.Text.Trim
        pro = pro.buscar
        If Not pro Is Nothing Then
            nombre_productor = pro.NOMBRE
            email = pro.EMAIL
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
                ' Llamamos al método buscar para obtener el objeto Credenciales
                Dim objetoCredenciales As dCredenciales = dCredenciales.buscar("notificaciones")

                _SMTP.Credentials = New System.Net.NetworkCredential(objetoCredenciales.CredencialesUsuario, objetoCredenciales.CredencialesPassword)
                _SMTP.Host = objetoCredenciales.CredencialesHost
                _SMTP.Port = 25
                _SMTP.EnableSsl = False

                _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
                ' CONFIGURACION DEL MENSAJE 
                _Message.[To].Add(LTrim(email))
                _Message.[To].Add(LTrim("envios@colaveco.com.uy"))
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
                & "En nuestro sitio web, https://colavecoresults.ddns.net:8080/LabColJavaEnvironment/com.labcol.colavecologin, puede ver el estado de su solicitud." & vbCrLf _
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
                ' Llamamos al método buscar para obtener el objeto Credenciales
                Dim objetoCredenciales As dCredenciales = dCredenciales.buscar("notificaciones")

                _SMTP.Credentials = New System.Net.NetworkCredential(objetoCredenciales.CredencialesUsuario, objetoCredenciales.CredencialesPassword)
                _SMTP.Host = objetoCredenciales.CredencialesHost
                _SMTP.Port = 25
                _SMTP.EnableSsl = False

                _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
                ' CONFIGURACION DEL MENSAJE 
                _Message.[To].Add(LTrim(email))
                _Message.[To].Add(LTrim("envios@colaveco.com.uy"))
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
                & "En nuestro sitio web, https://colavecoresults.ddns.net:8080/LabColJavaEnvironment/com.labcol.colavecologin, puede ver el estado de su solicitud." & vbCrLf _
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

    Private Sub enviar_notificacion_solicitud(ByVal id As Integer)
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        Dim notificacion As New Dictionary(Of String, dNotificaciones)
        Dim nt As New dNotificaciones
        Dim _tipo As String = ""
        Dim _mensaje As String = ""
        Dim nuevoid As Long = 0
        Dim _detalle As String = ""
        Dim _tipoinforme As String = ""
        Dim _subtipo As String = ""
        Dim _nombrecliente As String = ""
        Dim _muestrasingresadas As String = ""
        Dim _tipomuestra As String = ""
        Dim _tiempo As String = 0
        Dim sa As New dSolicitudAnalisis
        sa.ID = id
        sa = sa.buscar
        If Not sa Is Nothing Then
            Dim ti As New dTipoInforme
            ti.ID = sa.IDTIPOINFORME
            ti = ti.buscar
            If Not ti Is Nothing Then
                _tipoinforme = ti.NOMBRE
            End If
            Dim sti As New dSubInforme
            sti.ID = sa.IDSUBINFORME
            sti = sti.buscar
            If Not sti Is Nothing Then
                _subtipo = sti.NOMBRE
            End If
            nuevoid = sa.IDPRODUCTOR
            Dim pro As New dCliente
            pro.ID = sa.IDPRODUCTOR
            pro = pro.buscar
            If Not pro Is Nothing Then
                _nombrecliente = pro.NOMBRE
            Else
                _nombrecliente = ""
            End If
            If sa.NMUESTRAS = 0 Then
                _muestrasingresadas = "n/a"
            Else
                _muestrasingresadas = sa.NMUESTRAS
            End If
            Dim m As New dMuestras
            m.ID = sa.IDMUESTRA
            m = m.buscar
            If Not m Is Nothing Then
                _tipomuestra = m.NOMBRE
            End If
        End If
        _tipo = "solicitud_creada"
        _mensaje = "Ha ingresado una solicitud de análisis de " & _tipoinforme & ", con el número " & id
        '******************************************************************************************************************************************
        Dim texto As String = ""
        Dim texto2 As String = ""
        Dim texto3 As String = ""
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
        lista4 = sm.listarporficha(idficha)
        lista5 = csm.listarporsolicitud3(idficha)
        lista6 = cs.listarporsolicitud(idficha)
        lista7 = a2.listarporsolicitud(idficha)
        lista10 = spal.listarporsolicitud(idficha)
        listanutricion = sn.listarporsolicitud(idficha)
        listasuelos = ss.listarporsolicitud(idficha)
        listabl = sm.listarporficha(idficha)
        ' SI ES PRODUCTOS LÁCTEOS ********************************************************************************
        If _tipoinforme = "Alimentos" Then
            _tiempo = "3"
            Dim sp As New dSubproducto
            Dim lista As New ArrayList
            texto = ""
            lista = sp.listarporsolicitud(idficha)
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
                            _tiempo = "5"
                        End If
                        If sp.CT = 1 Then
                            texto = texto + " - Coliformes Totales"
                        End If
                        If sp.ECOLI = 1 Then
                            texto = texto + " - E. Coli"
                        End If
                        If sp.SALMONELLA = 1 Then
                            texto = texto + " - Salmonella"
                            _tiempo = "7"
                        End If
                        If sp.LISTERIASPP = 1 Then
                            texto = texto + " - Listeria spp"
                            _tiempo = "7"
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
                            _tiempo = "7"
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
                            _tiempo = "7"
                        End If
                        If sp.CENIZAS = 1 Then
                            texto = texto + " - Cenizas"
                        End If
                    Next
                End If
            End If
            ' SI ES AGUA ********************************************************************************
        ElseIf _tipoinforme = "Agua" Then
            _tiempo = "2"
            Dim a1 As New dAgua
            texto = ""
            a1.ID = idficha
            a1 = a1.buscar()
            texto = _subtipo
            If Not a1 Is Nothing Then
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
            End If
            ' SI ES CALIDAD DE LECHE ********************************************************************************
        ElseIf _tipoinforme = "Calidad de leche" Then
            _tiempo = "1"
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
                _tiempo = "7"
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
        ElseIf _tipoinforme = "Control Lechero" Then
            _tiempo = "1"
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
        ElseIf _tipoinforme = "Bacteriología y Antibiograma" Then
            _tiempo = "3"
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
        ElseIf _tipoinforme = "Ambiental" Then
            _tiempo = "2"
            Dim ambs As New dAmbientalSolicitud
            Dim lista8 As ArrayList
            lista8 = ambs.listarporsolicitud(idficha)
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
        ElseIf _tipoinforme = "Parasitología" Then
            _tiempo = "2"
            Dim p As New dParasitologiaSolicitud
            Dim lista9 As ArrayList
            lista9 = p.listarporsolicitud(idficha)
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
        ElseIf _tipoinforme = "Nutrición" Then
            _tiempo = "4"
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
        ElseIf _tipoinforme = "Suelos" Then
            _tiempo = "2"
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
        ElseIf _tipoinforme = "Otros" Then
            _tiempo = "7"
        ElseIf _tipoinforme = "Serología" Then
            If _subtipo = "Brucelosis" Then
                _tiempo = "2"
            ElseIf _subtipo = "Serología otros" Then
                _tiempo = "10"
            End If
        ElseIf _tipoinforme = "Patología - Toxicología" Then
            _tiempo = "5"
        End If
        '*** LISTADO DE MUESTRAS *********************************************************************************
        ' SI ES PRODUCTOS LÁCTEOS ********************************************************************************
        If _tipoinforme = "Alimentos" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            ' SI ES AGUA ********************************************************************************
        ElseIf _tipoinforme = "Agua" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            ' SI ES CALIDAD ********************************************************************************
        ElseIf _tipoinforme = "Calidad de leche" Then
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
        ElseIf _tipoinforme = "Control Lechero" Then
            texto2 = ""
            ' SI ES ANTIBIOGRAMA ********************************************************************************
        ElseIf _tipoinforme = "Bacteriología y Antibiograma" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            ' SI ES AMBIENTAL ********************************************************************************
        ElseIf _tipoinforme = "Ambiental" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            ' SI ES PARASITOLOGÍA ********************************************************************************
        ElseIf _tipoinforme = "Parasitología" Then
            texto2 = ""
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each sm In lista4
                        texto2 = texto2 + sm.IDMUESTRA & " - "
                    Next
                End If
            End If
            ' SI ES BRUCELOSIS LECHE ********************************************************************************
        ElseIf _tipoinforme = "Brucelosis en leche" Then
            _tiempo = "3"
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
        _detalle = "<p><b>Fecha de recepción:</b> " + _fecha + " </p><p><b>A nombre de:</b> " + _nombrecliente + " </p><p><b>Muestras ingresadas:</b> " + _muestrasingresadas + " </p><p><b>Tipo de muestra:</b> " + _tipomuestra + " </p><p><b>Tipo de informe:</b> " + _tipoinforme + " </p><p><b>Subtipo:</b> " + _subtipo + " </p><p><b>Análisis Solicitado:</b> " + texto + " </p><p><b>Identificación de las muestras:</b> " + texto2 + " </p><p><b>Tiempo estimado de entrega:</b> " + _tiempo + " </p>"
        nt.fecha = _fecha
        nt.tipo = _tipo
        nt.mensaje = _mensaje
        nt.idnet_usuario = nuevoid
        notificacion.Add("notification", nt)
        Dim parameters As String = JsonConvert.SerializeObject(notificacion, Formatting.None)
        Dim status As HttpStatusCode = HttpStatusCode.ExpectationFailed
        Dim response As Byte() = PostResponse("http://colaveco-gestor.herokuapp.com/notifications", "POST", parameters, status)
    End Sub

    Private Sub CheckMuestreo_CheckedChanged(sender As Object, e As EventArgs) Handles CheckMuestreo.CheckedChanged
        If CheckMuestreo.Checked = True And ComboTipoInforme.SelectedIndex = 11 Then
            cbxTecnicoMuestreo.Visible = True
        Else
            cbxTecnicoMuestreo.Visible = False
        End If
    End Sub

    Private Sub cbxTecnicoSueloNutri_CheckedChanged(sender As Object, e As EventArgs) Handles cbxTecnicoSueloNutri.CheckedChanged
        Dim idtecnico As dCliente = CType(ComboTecnico.SelectedItem, dCliente)
        If cbxTecnicoSueloNutri.Checked = True Then
            idtecnico.actualizarTecnicoSueloNutri(idtecnico.ID, 1)
        Else
            idtecnico.actualizarTecnicoSueloNutri(idtecnico.ID, 0)
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        imprimir_solicitud()
    End Sub

    Private Sub txtCajasTipeables_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCajasTipeables.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            idcaja = txtCajasTipeables.Text

            Dim p As New dPedidos
            Dim lista As New ArrayList
            Dim id As Integer = TextId.Text.Trim
            p.ID = id
           
            'Agregando lectores de codifos 31/7/2023

            If txtCajasTipeables.Text <> "" Then
                Dim caja As New dCajas
                Dim listCaja As New ArrayList
                listCaja = caja.buscarPorCodigo(txtCajasTipeables.Text)

                If listCaja IsNot Nothing Then
                    If listCaja.Count > 0 Then
                        For Each ec In listCaja
                            ListCajas().Items.Add(ec)
                        Next
                    Else
                        MsgBox("Codigo de caja no existe", MsgBoxStyle.Critical, "Atención")
                    End If
                Else
                    MsgBox("Codigo de caja no existe", MsgBoxStyle.Critical, "Atención")
                End If
                txtCajasTipeables.Text = ""

            Else
                MsgBox("Ingrese codigo de la Caja", MsgBoxStyle.Critical, "Atención")
                txtCajasTipeables.Text = ""
            End If
        End If

    End Sub

    Private Sub txtCajasTipeables_TextChanged(sender As Object, e As EventArgs) Handles txtCajasTipeables.TextChanged
        'buscarultimoenvio()
    End Sub

    Private Sub ButtonImagen_Click(sender As Object, e As EventArgs) Handles ButtonImagen.Click

    End Sub

    Private Sub ListCajas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListCajas.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub AgregarALista_Click(sender As Object, e As EventArgs) Handles AgregarALista.Click
        Dim p As New dPedidos
        Dim lista As New ArrayList
        Dim id As Integer = TextId.Text.Trim
        p.ID = id
        If TextIdEnvio.Text <> "" Then
            id = TextIdEnvio.Text.Trim
        Else
            'Dim e As New dEnvioCajas

            'Agregando lectores de codifos 31/7/2023

            If txtCajasTipeables.Text <> "" Then
                Dim caja As New dCajas
                Dim listCaja As New ArrayList
                listCaja = caja.buscarPorCodigo(txtCajasTipeables.Text)

                If listCaja IsNot Nothing Then
                    If listCaja.Count > 0 Then
                        For Each ec In listCaja
                            ListCajas().Items.Add(ec)
                        Next
                    Else
                        MsgBox("Cadigo de caja no existe", MsgBoxStyle.Critical, "Atención")
                    End If
                Else
                    MsgBox("Cadigo de caja no existe", MsgBoxStyle.Critical, "Atención")
                End If
            ElseIf ComboCajas.Text.Trim <> "" Then
                Dim caja As New dCajas
                caja.CODIGO = ComboCajas.Text.Trim
                lista = caja.buscarPorCodigo(caja.CODIGO)

                If lista IsNot Nothing Then
                    If lista.Count > 0 Then
                        For Each ec In lista
                            ListCajas().Items.Add(ec)
                        Next
                    Else
                        MsgBox("Cadigo de caja no existe", MsgBoxStyle.Critical, "Atención")
                    End If
                Else
                    MsgBox("Cadigo de caja no existe", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                MsgBox("Ingrese codigo de la Caja", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub

    Private Sub EliminarDeLista_Click(sender As Object, e As EventArgs) Handles EliminarDeLista.Click
        If Not ListCajas.SelectedItem Is Nothing Then
            Dim sc As New dRelSolicitudCajas
            Dim idCaja As String
            Dim indice As Integer
            Dim ec As New dEnvioCajas
            ec.IDCAJA = ListCajas.SelectedItem.CODIGO

            If ListCajas.SelectedIndex <> -1 Then
                ' Elimina el elemento seleccionado
                ListCajas.Items.RemoveAt(ListCajas.SelectedIndex)
            Else
                ' Opcional: muestra un mensaje si no hay un elemento seleccionado
                MessageBox.Show("Por favor, selecciona un elemento para eliminar.", "Elemento no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
End Class