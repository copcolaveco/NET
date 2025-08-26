Imports System.IO

Public Class FormControldeInformesPre
    Private _usuario As dUsuario
    Public Informe As Integer = 0
    Public ficha As Integer = 0
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        limpiar()
    End Sub

#End Region



    Private Sub limpiar()
        DateDesde.Value = Now
        DateHasta.Value = Now
        RadioFQ.Checked = True
        RadioMicro.Checked = False
        RadioSuelos.Checked = False
        RadioNutricion.Checked = False
        TextTotal.Text = ""
        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()
    End Sub
    'Private Sub contarcontroles()
    '    Dim cifq As New dControlInformesFQ
    '    Dim cimicro As New dControlInformesMicro
    '    Dim cinut As New dControlInformesNutricion
    '    Dim cisue As New dControlInformesSuelos
    '    Dim listafq As New ArrayList
    '    Dim listamicro As New ArrayList
    '    Dim listanut As New ArrayList
    '    Dim listasue As New ArrayList
    '    Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
    '    Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
    '    Dim fecdesde As String
    '    Dim fechasta As String
    '    fecdesde = Format(desde, "yyyy-MM-dd")
    '    fechasta = Format(hasta, "yyyy-MM-dd")
    '    listafq = cifq.listarxfecha(fecdesde, fechasta)
    '    listamicro = cimicro.listarxfecha(fecdesde, fechasta)
    '    listanut = cinut.listarxfecha(fecdesde, fechasta)
    '    listasue = cisue.listarxfecha(fecdesde, fechasta)
    '    DataGridView1.Rows.Clear()
    '    Dim fqcal As Integer = 0
    '    Dim fqcl As Integer = 0
    '    Dim microcal As Integer = 0
    '    Dim microagua As Integer = 0
    '    Dim microsp As Integer = 0
    '    Dim nut As Integer = 0
    '    Dim sue As Integer = 0
    '    Dim cantidad As Integer = 0
    '    Dim fila As Integer = 0
    '    Dim columna As Integer = 0
    '    DataGridView1.Rows.Add(1)
    '    If Not listafq Is Nothing Then
    '        If listafq.Count > 0 Then
    '            For Each cifq In listafq
    '                If cifq.TIPO = 1 Then
    '                    fqcl = fqcl + 1
    '                    cantidad = cantidad + 1
    '                ElseIf cifq.TIPO = 10 Then
    '                    fqcal = fqcal + 1
    '                    cantidad = cantidad + 1
    '                End If
    '            Next
    '        End If
    '    End If

    '    If Not listamicro Is Nothing Then
    '        If listamicro.Count > 0 Then
    '            For Each cimicro In listamicro
    '                If cimicro.TIPO = 10 Then
    '                    microcal = microcal + 1
    '                    cantidad = cantidad + 1
    '                ElseIf cimicro.TIPO = 3 Then
    '                    microagua = microagua + 1
    '                    cantidad = cantidad + 1
    '                ElseIf cimicro.TIPO = 7 Then
    '                    microsp = microsp + 1
    '                    cantidad = cantidad + 1
    '                End If
    '            Next
    '        End If
    '    End If

    '    If Not listanut Is Nothing Then
    '        If listanut.Count > 0 Then
    '            For Each cinut In listanut
    '                nut = nut + 1
    '                cantidad = cantidad + 1
    '            Next
    '        End If
    '    End If

    '    If Not listasue Is Nothing Then
    '        If listasue.Count > 0 Then
    '            For Each cisue In listasue
    '                sue = sue + 1
    '                cantidad = cantidad + 1
    '            Next
    '        End If
    '    End If

    '    DataGridView1(columna, fila).Value = fqcal
    '    columna = columna + 1
    '    DataGridView1(columna, fila).Value = fqcl
    '    columna = columna + 1
    '    DataGridView1(columna, fila).Value = microcal
    '    columna = columna + 1
    '    DataGridView1(columna, fila).Value = microagua
    '    columna = columna + 1
    '    DataGridView1(columna, fila).Value = microsp
    '    columna = columna + 1
    '    DataGridView1(columna, fila).Value = nut
    '    columna = columna + 1
    '    DataGridView1(columna, fila).Value = sue
    '    columna = columna + 1
    '    TextTotal.Text = cantidad
    'End Sub

    Private Sub contarcontroles()
        Dim desde As String = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As String = DateHasta.Value.ToString("yyyy-MM-dd")

        ' Clases
        Dim cifq As New dControlInformesFQ
        Dim cimicro As New dControlInformesMicro
        Dim cinut As New dControlInformesNutricion
        Dim cisue As New dControlInformesSuelos

        ' Listas
        Dim listafq As ArrayList = Nothing
        Dim listamicro As ArrayList = Nothing
        Dim listanut As ArrayList = Nothing
        Dim listasue As ArrayList = Nothing

        ' Contadores
        Dim fqcal As Integer = 0
        Dim fqcl As Integer = 0
        Dim microcal As Integer = 0
        Dim microagua As Integer = 0
        Dim microsp As Integer = 0
        Dim nut As Integer = 0
        Dim sue As Integer = 0
        Dim cantidad As Integer = 0

        ' Consultar SOLO lo que está filtrado
        If RadioFQ.Checked Then
            listafq = cifq.listarxfecha(desde, hasta)
        End If
        If RadioMicro.Checked Then
            listamicro = cimicro.listarxfecha(desde, hasta)
        End If
        If RadioNutricion.Checked Then
            listanut = cinut.listarxfecha(desde, hasta)
        End If
        If RadioSuelos.Checked Then
            listasue = cisue.listarxfecha(desde, hasta)
        End If

        ' Procesar FQ
        If listafq IsNot Nothing AndAlso listafq.Count > 0 Then
            For Each item As dControlInformesFQ In listafq
                If item.TIPO = 1 Then
                    fqcl += 1 : cantidad += 1
                ElseIf item.TIPO = 10 Then
                    fqcal += 1 : cantidad += 1
                End If
            Next
        End If

        ' Procesar Micro
        If listamicro IsNot Nothing AndAlso listamicro.Count > 0 Then
            For Each item As dControlInformesMicro In listamicro
                Select Case item.TIPO
                    Case 10 : microcal += 1 : cantidad += 1
                    Case 3 : microagua += 1 : cantidad += 1
                    Case 7 : microsp += 1 : cantidad += 1
                End Select
            Next
        End If

        ' Procesar Nutrición
        If listanut IsNot Nothing AndAlso listanut.Count > 0 Then
            For Each item As dControlInformesNutricion In listanut
                nut += 1 : cantidad += 1
            Next
        End If

        ' Procesar Suelos
        If listasue IsNot Nothing AndAlso listasue.Count > 0 Then
            For Each item As dControlInformesSuelos In listasue
                sue += 1 : cantidad += 1
            Next
        End If

        ' Mostrar en grilla
        DataGridView1.Rows.Clear()
        DataGridView1.Rows.Add(1)

        Dim fila As Integer = 0
        Dim columna As Integer = 0

        DataGridView1(columna, fila).Value = fqcal : columna += 1
        DataGridView1(columna, fila).Value = fqcl : columna += 1
        DataGridView1(columna, fila).Value = microcal : columna += 1
        DataGridView1(columna, fila).Value = microagua : columna += 1
        DataGridView1(columna, fila).Value = microsp : columna += 1
        DataGridView1(columna, fila).Value = nut : columna += 1
        DataGridView1(columna, fila).Value = sue : columna += 1

        TextTotal.Text = cantidad
    End Sub


    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        contarcontroles()
        If RadioFQ.Checked = True Then
            listarInformes(EnumTipoControles.FisicoQuimico)
        ElseIf RadioMicro.Checked = True Then
            listarInformes(EnumTipoControles.Microbiologia)
        ElseIf RadioSuelos.Checked = True Then
            listarInformes(EnumTipoControles.Suelos)
        ElseIf RadioNutricion.Checked = True Then
            listarInformes(EnumTipoControles.Nutricion)
        End If
    End Sub

    Private Sub listarInformes(ByVal TipoControl As Long)
        Dim desde As String = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As String = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim Control As dControlBase

        Select Case TipoControl
            Case EnumTipoControles.Efluentes
                Control = New dControlInformesEfluentes
            Case EnumTipoControles.FisicoQuimico
                Control = New dControlInformesFQ
            Case EnumTipoControles.Microbiologia
                Control = New dControlInformesMicro
            Case EnumTipoControles.Nutricion
                Control = New dControlInformesNutricion
            Case EnumTipoControles.Suelos
                Control = New dControlInformesSuelos
            Case Else
                MsgBox("Tipo de control no válido.", MsgBoxStyle.Exclamation, "Atención")
                Exit Sub
        End Select

        Dim lista As ArrayList = Control.listarxfecha(desde, hasta)

        Dim dt As New DataTable()
        dt.Columns.Add("Id", GetType(Long))
        dt.Columns.Add("Ficha", GetType(Long))
        dt.Columns.Add("Fecha", GetType(String))
        dt.Columns.Add("Tipo Informe", GetType(String))
        dt.Columns.Add("Resultado", GetType(Boolean))
        dt.Columns.Add("Coincide", GetType(Boolean))
        dt.Columns.Add("OM", GetType(Boolean))
        dt.Columns.Add("NC", GetType(Boolean))
        dt.Columns.Add("Observaciones", GetType(String))
        dt.Columns.Add("Controlador", GetType(String))

        For Each obj As dControlBase In lista
            ' Buscar nombre del controlador
            Dim u As New dUsuario
            u.ID = obj.CONTROLADOR
            u = u.buscar()
            Dim nombreControlador As String = If(u IsNot Nothing, u.NOMBRE, "")

            ' Convertir 1/0 a True/False
            dt.Rows.Add(
                obj.ID,
                obj.FICHA,
                obj.FECHA,
                obj.TIPONOMBRE,
                (obj.RESULTADO = 1),
                (obj.COINCIDE = 1),
                (obj.OM = 1),
                (obj.NC = 1),
                obj.OBSERVACIONES,
                nombreControlador
            )
        Next

        DataGridView2.DataSource = dt
    End Sub

    ' Este evento fuerza a que se registre el cambio de checkbox inmediatamente
    Private Sub DataGridView2_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView2.CurrentCellDirtyStateChanged
        If DataGridView2.IsCurrentCellDirty Then
            DataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    ' Este evento se dispara cuando cambia el valor de una celda
    Private Sub DataGridView2_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellValueChanged
        ' Evitar errores en cabeceras
        If e.RowIndex < 0 Then Exit Sub
        ficha = CLng(DataGridView2.Rows(e.RowIndex).Cells("Ficha").Value)
        Dim colName As String = DataGridView2.Columns(e.ColumnIndex).Name

        ' Solo actuar si la columna es una de las de check
        If colName = "Resultado" OrElse colName = "Coincide" OrElse colName = "OM" OrElse colName = "NC" Then
            Dim idRegistro As Long = CLng(DataGridView2.Rows(e.RowIndex).Cells("Id").Value)
            Dim nuevoValor As Boolean = CBool(DataGridView2.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

            ' Llamar a tu función
            ProcesarCambioCheck(idRegistro, colName, nuevoValor)
        End If
    End Sub

    Private Sub ProcesarCambioCheck(ByVal idRegistro As Long, ByVal colName As String, ByVal nuevoValor As Boolean)
    
        If colName = "Resultado" OrElse colName = "Coincide" OrElse colName = "OM" OrElse colName = "NC" Then

            ' Obtener el sector según el radio seleccionado
            Dim sector As String = ""
            If RadioFQ.Checked Then
                sector = "FQ"
            ElseIf RadioMicro.Checked Then
                sector = "MICRO"
            ElseIf RadioSuelos.Checked Then
                sector = "SUELO"
            ElseIf RadioNutricion.Checked Then
                sector = "NUTRICION"
            End If

            ' Procesar cambio
            ProcesarCambio(idRegistro, colName, nuevoValor, sector)
        End If
    End Sub

    Private Sub ProcesarCambio(idRegistro As Long, colName As String, nuevoValor As Boolean, sector As String)
        Dim ci = GetControlObject(sector, idRegistro)

        Select Case colName
            Case "Resultado"
                If nuevoValor Then
                    CallByName(ci, "marcarresultado", CallType.Method, Usuario)

                Else
                    CallByName(ci, "desmarcarresultado", CallType.Method, Usuario)

                End If
                GestorNuevoControl(colName, nuevoValor)
            Case "Coincide"
                If nuevoValor Then
                    CallByName(ci, "marcarcoincide", CallType.Method, Usuario)

                Else
                    CallByName(ci, "desmarcarcoincide", CallType.Method, Usuario)

                End If
                GestorNuevoControl(colName, nuevoValor)
            Case "OM"
                If nuevoValor Then
                    CallByName(ci, "marcarom", CallType.Method, Usuario)
                Else
                    CallByName(ci, "desmarcarom", CallType.Method, Usuario)
                End If
                GestorNuevoControl(colName, nuevoValor)
            Case "NC"
                If nuevoValor Then
                    CallByName(ci, "marcarnc", CallType.Method, Usuario)
                Else
                    CallByName(ci, "desmarcarnc", CallType.Method, Usuario)
                End If
                GestorNuevoControl(colName, nuevoValor)
        End Select

        ' Refrescar según el tipo de informe
        Select Case sector.ToUpper()
            Case "FQ" : listarInformes(EnumTipoControles.FisicoQuimico)
            Case "MICRO" : listarInformes(EnumTipoControles.Microbiologia)
            Case "SUELO" : listarInformes(EnumTipoControles.Suelos)
            Case "NUTRICION" : listarInformes(EnumTipoControles.Nutricion)
        End Select
    End Sub

    Public Function GestorNuevoControl(ByVal variable As String, ByVal valor As Integer)
        'GestorNuevo modificar estado Cotnrol
        Dim controlGestor As New dNGControl
        Try
            'Registro en Gestor Nuevo
            controlGestor.InformeId = ficha
            controlGestor.ControlCoincide = 1
            Select Case variable
                Case "Resultado"
                    controlGestor.ControlResultado = If(valor = 1, 1, 0)
                    controlGestor.resultadoControl()
                Case "Coincide"
                    controlGestor.ControlCoincide = If(valor = 1, 1, 0)
                    controlGestor.coincideControl()
                Case "OM"
                    controlGestor.ControlOpcMejora = If(valor = 1, 1, 0)
                    controlGestor.opcionMejoraControl()
                Case "NC"
                    controlGestor.ControlNoConformidad = If(valor = 1, 1, 0)
                    controlGestor.noConformidadControl()
            End Select
        Catch ex As Exception
        End Try
    End Function

    Private Function GetControlObject(sector As String, id As Long) As Object
        Select Case sector.ToUpper()
            Case "FQ"
                Return New dControlInformesFQ With {.ID = id}
            Case "MICRO"
                Return New dControlInformesMicro With {.ID = id}
            Case "SUELOS"
                Return New dControlInformesSuelos With {.ID = id}
            Case "NUTRICION"
                Return New dControlInformesNutricion With {.ID = id}
            Case Else
                Throw New Exception("Sector no soportado: " & sector)
        End Select
    End Function


End Class