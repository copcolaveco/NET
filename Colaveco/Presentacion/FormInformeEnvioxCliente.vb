Public Class FormInformeEnvioxCliente
    Private _usuario As dUsuario

    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        pordefecto()
    End Sub
#End Region
    

    Private Sub ButtonBuscarProductor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProductor.Click
        Dim v As New FormBuscarProductor
        v.ShowDialog()
        If Not v.Productor Is Nothing Then
            Dim pro As dProductor = v.Productor
            TextIdProductor.Text = pro.ID
            TextProductor.Text = pro.NOMBRE
        End If
    End Sub
    Private Sub pordefecto()
        RadioFecha.Checked = True
        DateDesde.Enabled = True
        DateHasta.Enabled = True
        TextIdProductor.Enabled = False
        TextProductor.Enabled = False
        ButtonBuscarProductor.Enabled = False

    End Sub
    Private Sub seleccion()
        If RadioFecha.Checked = True Then
            DateDesde.Enabled = True
            DateHasta.Enabled = True
            TextIdProductor.Enabled = False
            TextProductor.Enabled = False
            ButtonBuscarProductor.Enabled = False
        ElseIf RadioCliente.Checked = True Then
            DateDesde.Enabled = False
            DateHasta.Enabled = False
            TextIdProductor.Enabled = True
            TextProductor.Enabled = True
            ButtonBuscarProductor.Enabled = True
        ElseIf RadioFechaCliente.Checked = True Then
            DateDesde.Enabled = True
            DateHasta.Enabled = True
            TextIdProductor.Enabled = True
            TextProductor.Enabled = True
            ButtonBuscarProductor.Enabled = True
        End If
    End Sub
    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        If RadioFecha.Checked = True Then
            listarxfecha()
        ElseIf RadioCliente.Checked = True Then
            listarxcliente()
        ElseIf RadioFechaCliente.Checked = True Then
            listarxfechaxcliente()
        End If
    End Sub

    Private Sub RadioFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioFecha.CheckedChanged
        seleccion()
    End Sub

    Private Sub RadioCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioCliente.CheckedChanged
        seleccion()

    End Sub

    Private Sub RadioFechaCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioFechaCliente.CheckedChanged
        seleccion()

    End Sub
    Private Sub listarxfecha()
        Dim e As New dEnvioCajas
        Dim p As New dProductor
        Dim a As New dEmpresaT
        Dim lista As New ArrayList
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = e.listarporfecha(fecdesde, fechasta)

        DataGridView1.Rows.Clear()
        'ListPendientes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim id As Long = 0
                Dim fecha As Date
                Dim productor As Long
                Dim nomproductor As String = ""
                Dim caja As Integer
                Dim gradilla1 As Integer
                Dim gradilla2 As Integer
                Dim gradilla3 As Integer
                Dim frascos As Integer
                Dim agencia As Integer
                Dim nomagencia As String = ""
                Dim envio As String
                Dim responsable As String = ""
                Dim observaciones As String
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each e In lista
                    id = e.ID
                    fecha = e.FECHAENVIO
                    productor = e.IDPRODUCTOR
                    p.ID = e.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        nomproductor = p.NOMBRE
                    End If
                    caja = e.IDCAJA
                    gradilla1 = e.GRADILLA1
                    gradilla2 = e.GRADILLA2
                    gradilla3 = e.GRADILLA3
                    frascos = e.FRASCOS
                    agencia = e.IDEMPRESA
                    If e.IDEMPRESA <> 0 Then
                        a.ID = e.IDEMPRESA
                        a = a.buscar
                        If Not a Is Nothing Then
                            nomagencia = a.NOMBRE
                        End If
                    End If
                    envio = e.ENVIO
                    observaciones = e.OBSERVACIONES
                    DataGridView1(columna, fila).Value = id
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = fecha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = nomproductor
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = caja
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = gradilla1
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = gradilla2
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = gradilla3
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = frascos
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = nomagencia
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = envio
                    columna = columna + 1
                    Dim r As New dUsuario
                    r.ID = e.RESPONSABLE
                    r = r.buscar
                    If Not r Is Nothing Then
                        DataGridView1(columna, fila).Value = r.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    
                    DataGridView1(columna, fila).Value = observaciones
                    columna = 0
                    fila = fila + 1
                Next
                DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub
    Private Sub listarxfechaxcliente()
        Dim e As New dEnvioCajas
        Dim p As New dProductor
        Dim a As New dEmpresaT
        Dim lista As New ArrayList
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim cliente As Long = TextIdProductor.Text.Trim
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = e.listarporfechaxcliente(fecdesde, fechasta, cliente)

        DataGridView1.Rows.Clear()
        'ListPendientes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim id As Long = 0
                Dim fecha As Date
                Dim productor As Long
                Dim nomproductor As String = ""
                Dim caja As Integer
                Dim gradilla1 As Integer
                Dim gradilla2 As Integer
                Dim gradilla3 As Integer
                Dim frascos As Integer
                Dim agencia As Integer
                Dim nomagencia As String = ""
                Dim envio As String
                Dim observaciones As String
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each e In lista
                    id = e.ID
                    fecha = e.FECHAENVIO
                    productor = e.IDPRODUCTOR
                    p.ID = e.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        nomproductor = p.NOMBRE
                    End If
                    caja = e.IDCAJA
                    gradilla1 = e.GRADILLA1
                    gradilla2 = e.GRADILLA2
                    gradilla3 = e.GRADILLA3
                    frascos = e.FRASCOS
                    agencia = e.IDEMPRESA
                    If e.IDEMPRESA <> 0 Then
                        a.ID = e.IDEMPRESA
                        a = a.buscar
                        If Not a Is Nothing Then
                            nomagencia = a.NOMBRE
                        End If
                    End If
                    envio = e.ENVIO
                    observaciones = e.OBSERVACIONES
                    DataGridView1(columna, fila).Value = id
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = fecha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = nomproductor
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = caja
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = gradilla1
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = gradilla2
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = gradilla3
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = frascos
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = nomagencia
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = envio
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = observaciones
                    columna = 0
                    fila = fila + 1
                Next
                DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub
    Private Sub listarxcliente()
        Dim e As New dEnvioCajas
        Dim p As New dProductor
        Dim a As New dEmpresaT
        Dim lista As New ArrayList
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim cliente As Long = TextIdProductor.Text.Trim
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = e.listarporcliente(cliente)

        DataGridView1.Rows.Clear()
        'ListPendientes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim id As Long = 0
                Dim fecha As Date
                Dim productor As Long
                Dim nomproductor As String = ""
                Dim caja As Integer
                Dim gradilla1 As Integer
                Dim gradilla2 As Integer
                Dim gradilla3 As Integer
                Dim frascos As Integer
                Dim agencia As Integer
                Dim nomagencia As String = ""
                Dim envio As String
                Dim observaciones As String
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each e In lista
                    id = e.ID
                    fecha = e.FECHAENVIO
                    productor = e.IDPRODUCTOR
                    p.ID = e.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        nomproductor = p.NOMBRE
                    End If
                    caja = e.IDCAJA
                    gradilla1 = e.GRADILLA1
                    gradilla2 = e.GRADILLA2
                    gradilla3 = e.GRADILLA3
                    frascos = e.FRASCOS
                    agencia = e.IDEMPRESA
                    If e.IDEMPRESA <> 0 Then
                        a.ID = e.IDEMPRESA
                        a = a.buscar
                        If Not a Is Nothing Then
                            nomagencia = a.NOMBRE
                        End If
                    End If
                    envio = e.ENVIO
                    observaciones = e.OBSERVACIONES
                    DataGridView1(columna, fila).Value = id
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = fecha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = nomproductor
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = caja
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = gradilla1
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = gradilla2
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = gradilla3
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = frascos
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = nomagencia
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = envio
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = observaciones
                    columna = 0
                    fila = fila + 1
                Next
                DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        If DataGridView1.Columns(e.ColumnIndex).Name = "Envio" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim texto As String = ""
            Dim ec As New dEnvioCajas
            id = row.Cells("Id").Value
            texto = row.Cells("Envio").Value
            ec.ID = id
            ec.ENVIO = texto
            If (ec.completarenvio(Usuario)) Then
                'If (ec.marcarrecibido(Usuario)) Then
                MsgBox("Envío modificado", MsgBoxStyle.Information, "Atención")
                'listar()
                If RadioFecha.Checked = True Then
                    listarxfecha()
                ElseIf RadioCliente.Checked = True Then
                    listarxcliente()
                ElseIf RadioFechaCliente.Checked = True Then
                    listarxfechaxcliente()
                End If
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
End Class