Public Class FormBuscarPedidos
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
    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        If RadioFecha.Checked = True Then
            listarxfecha()
        ElseIf RadioCliente.Checked = True Then
            listarxcliente()
        ElseIf RadioFechaCliente.Checked = True Then
            listarxfechaxcliente()
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
    Private Sub listarxcliente()
        Dim p As New dPedidos
        Dim pr As New dProductor
        Dim a As New dEmpresaT
        Dim lista As New ArrayList
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim cliente As Long = TextIdProductor.Text.Trim
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = p.listarporcliente(cliente)

        DataGridView1.Rows.Clear()
        'ListPendientes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim id As Long
                Dim fecha As Date
                Dim productor As Long
                Dim nomproductor As String = ""
                Dim direccion As String
                Dim telefono As String
                Dim agencia As Integer
                Dim nomagencia As String = ""
                Dim responsable As String
                Dim rc_compos As Integer
                Dim agua As Integer
                Dim sangre As Integer
                Dim esteriles As Integer
                Dim otros As Integer
                Dim observaciones As String
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each p In lista
                    id = p.ID
                    fecha = p.FECHA
                    productor = p.IDPRODUCTOR
                    pr.ID = p.IDPRODUCTOR
                    pr = pr.buscar
                    If Not pr Is Nothing Then
                        nomproductor = pr.NOMBRE
                    End If
                    direccion = p.DIRECCION
                    telefono = p.TELEFONO
                    agencia = p.IDAGENCIA
                    If p.IDAGENCIA <> 0 Then
                        a.ID = p.IDAGENCIA
                        a = a.buscar
                        If Not a Is Nothing Then
                            nomagencia = a.NOMBRE
                        End If
                    End If
                    responsable = p.RESPONSABLE
                    rc_compos = p.RC_COMPOS
                    agua = p.AGUA
                    sangre = p.SANGRE
                    esteriles = p.ESTERILES
                    otros = p.OTROS
                    observaciones = p.OBSERVACIONES
                    DataGridView1(columna, fila).Value = id
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = fecha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = nomproductor
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = direccion
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = telefono
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = nomagencia
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = responsable
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rc_compos
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = agua
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = sangre
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = esteriles
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = otros
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = observaciones
                    columna = 0
                    fila = fila + 1
                Next
                DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Descending)

            End If
        End If
    End Sub
    Private Sub listarxfecha()
        Dim p As New dPedidos
        Dim pr As New dProductor
        Dim a As New dEmpresaT
        Dim lista As New ArrayList
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        'Dim cliente As Long = TextIdProductor.Text.Trim
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = p.listarporfecha(fecdesde, fechasta)

        DataGridView1.Rows.Clear()
        'ListPendientes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim id As Long
                Dim fecha As Date
                Dim productor As Long
                Dim nomproductor As String = ""
                Dim direccion As String
                Dim telefono As String
                Dim agencia As Integer
                Dim nomagencia As String = ""
                Dim responsable As String
                Dim rc_compos As Integer
                Dim agua As Integer
                Dim sangre As Integer
                Dim esteriles As Integer
                Dim otros As Integer
                Dim observaciones As String
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each p In lista
                    id = p.ID
                    fecha = p.FECHA
                    productor = p.IDPRODUCTOR
                    pr.ID = p.IDPRODUCTOR
                    pr = pr.buscar
                    If Not pr Is Nothing Then
                        nomproductor = pr.NOMBRE
                    End If
                    direccion = p.DIRECCION
                    telefono = p.TELEFONO
                    agencia = p.IDAGENCIA
                    If p.IDAGENCIA <> 0 Then
                        a.ID = p.IDAGENCIA
                        a = a.buscar
                        If Not a Is Nothing Then
                            nomagencia = a.NOMBRE
                        End If
                    End If
                    responsable = p.RESPONSABLE
                    rc_compos = p.RC_COMPOS
                    agua = p.AGUA
                    sangre = p.SANGRE
                    esteriles = p.ESTERILES
                    otros = p.OTROS
                    observaciones = p.OBSERVACIONES
                    DataGridView1(columna, fila).Value = id
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = fecha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = nomproductor
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = direccion
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = telefono
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = nomagencia
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = responsable
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rc_compos
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = agua
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = sangre
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = esteriles
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = otros
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = observaciones
                    columna = 0
                    fila = fila + 1
                Next
                DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Descending)

            End If
        End If
    End Sub
    Private Sub listarxfechaxcliente()
        Dim p As New dPedidos
        Dim pr As New dProductor
        Dim a As New dEmpresaT
        Dim lista As New ArrayList
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim cliente As Long = TextIdProductor.Text.Trim
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = p.listarporfechaxcliente(fecdesde, fechasta, cliente)

        DataGridView1.Rows.Clear()
        'ListPendientes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim id As Long
                Dim fecha As Date
                Dim productor As Long
                Dim nomproductor As String = ""
                Dim direccion As String
                Dim telefono As String
                Dim agencia As Integer
                Dim nomagencia As String = ""
                Dim responsable As String
                Dim rc_compos As Integer
                Dim agua As Integer
                Dim sangre As Integer
                Dim esteriles As Integer
                Dim otros As Integer
                Dim observaciones As String
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each p In lista
                    id = p.ID
                    fecha = p.FECHA
                    productor = p.IDPRODUCTOR
                    pr.ID = p.IDPRODUCTOR
                    pr = pr.buscar
                    If Not pr Is Nothing Then
                        nomproductor = pr.NOMBRE
                    End If
                    direccion = p.DIRECCION
                    telefono = p.TELEFONO
                    agencia = p.IDAGENCIA
                    If p.IDAGENCIA <> 0 Then
                        a.ID = p.IDAGENCIA
                        a = a.buscar
                        If Not a Is Nothing Then
                            nomagencia = a.NOMBRE
                        End If
                    End If
                    responsable = p.RESPONSABLE
                    rc_compos = p.RC_COMPOS
                    agua = p.AGUA
                    sangre = p.SANGRE
                    esteriles = p.ESTERILES
                    otros = p.OTROS
                    observaciones = p.OBSERVACIONES
                    DataGridView1(columna, fila).Value = id
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = fecha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = nomproductor
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = direccion
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = telefono
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = nomagencia
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = responsable
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rc_compos
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = agua
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = sangre
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = esteriles
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = otros
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = observaciones
                    columna = 0
                    fila = fila + 1
                Next
                DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Descending)

            End If
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

    Private Sub ButtonBuscarProductor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProductor.Click
        Dim v As New FormBuscarProductor
        v.ShowDialog()
        If Not v.Productor Is Nothing Then
            Dim pro As dProductor = v.Productor
            TextIdProductor.Text = pro.ID
            TextProductor.Text = pro.NOMBRE
        End If
    End Sub
End Class