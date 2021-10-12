Public Class FormBuscarCompras
    Private _compras As dCompras
    Public Property Compras() As dCompras
        Get
            Return _compras
        End Get
        Set(ByVal value As dCompras)
            _compras = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        RadioNumero.Checked = True
        ocultar_campos()
    End Sub
#End Region
    
    Private Sub limpiar()
        TextNumero.Text = ""
        TextIdProveedor.Text = ""
        TextProveedor.Text = ""
    End Sub
    Private Sub ocultar_campos()
        If RadioNumero.Checked = True Then
            TextNumero.Enabled = True
            TextIdProveedor.Enabled = False
            TextProveedor.Enabled = False
            ButtonBuscarProveedor.Enabled = False
            DateTimeDesde.Enabled = False
            DateTimeHasta.Enabled = False
        ElseIf RadioProveedor.Checked = True Then
            TextNumero.Enabled = False
            TextIdProveedor.Enabled = True
            TextProveedor.Enabled = True
            ButtonBuscarProveedor.Enabled = True
            DateTimeDesde.Enabled = False
            DateTimeHasta.Enabled = False
        Else
            TextNumero.Enabled = False
            TextIdProveedor.Enabled = False
            TextProveedor.Enabled = False
            ButtonBuscarProveedor.Enabled = False
            DateTimeDesde.Enabled = True
            DateTimeHasta.Enabled = True
        End If
    End Sub

    Private Sub listarporid()

        Dim c As New dCompras
        Dim texto As Long = TextNumero.Text.Trim
        Dim lista As New ArrayList
        lista = c.listarporid(texto)
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView1.Rows.Add(lista.Count)
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    DataGridView1(columna, fila).Value = c.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.FECHA
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub listarporproveedor()

        Dim c As New dCompras
        Dim texto As Long = TextIdProveedor.Text.Trim
        Dim lista As New ArrayList
        lista = c.listarxproveedor(texto)
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView1.Rows.Add(lista.Count)
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    DataGridView1(columna, fila).Value = c.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.FECHA
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub listarporfecha()
        Dim c As New dCompras
        Dim fechadesde As Date = DateTimeDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateTimeHasta.Value.ToString("yyyy-MM-dd")
        Dim fechad As String = Format(fechadesde, "yyyy-MM-dd")
        Dim fechah As String = Format(fechahasta, "yyyy-MM-dd")
        Dim lista As New ArrayList
        lista = c.listarxfecha(fechad, fechah)
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView1.Rows.Add(lista.Count)
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    DataGridView1(columna, fila).Value = c.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.FECHA
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click
        'ListSolicitudes.Items.Clear()
        If RadioNumero.Checked = True Then
            listarporid()
        ElseIf RadioProveedor.Checked = True Then
            listarporproveedor()
        Else
            listarporfecha()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'If DataGridView1.Columns(e.ColumnIndex).Name = "Id" Then
        '    Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        '    Dim id As Long = 0
        '    Dim c As New dCompras
        '    id = row.Cells("Id").Value
        '    c.ID = id
        '    c = c.buscar
        '    If Not c Is Nothing Then
        '        Compras = c
        '        Me.Close()
        '    End If
        'End If
        'If DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
        '    Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        '    Dim id As Long = 0
        '    Dim c As New dCompras
        '    id = row.Cells("Id").Value
        '    c.ID = id
        '    c = c.buscar
        '    If Not c Is Nothing Then
        '        Compras = c
        '        Me.Close()
        '    End If
        'End If
        'If DataGridView1.Columns(e.ColumnIndex).Name = "Proveedor" Then
        '    Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        '    Dim id As Long = 0
        '    Dim c As New dCompras
        '    id = row.Cells("Id").Value
        '    c.ID = id
        '    c = c.buscar
        '    If Not c Is Nothing Then
        '        Compras = c
        '        Me.Close()
        '    End If
        'End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Seleccionar" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCompras
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar
            If Not c Is Nothing Then
                Compras = c
                Me.Close()
            End If
        End If
    End Sub

    Private Sub ButtonBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProveedor.Click
        Dim v As New FormBuscarProveedor
        v.ShowDialog()
        If Not v.Proveedor Is Nothing Then
            Dim pro As dProveedores = v.Proveedor
            TextIdProveedor.Text = pro.ID
            TextProveedor.Text = pro.NOMBRE
        End If
    End Sub

    Private Sub RadioNumero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioNumero.CheckedChanged
        ocultar_campos()
    End Sub

    Private Sub RadioProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioProveedor.CheckedChanged
        ocultar_campos()
    End Sub

    Private Sub RadioFechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioFechas.CheckedChanged
        ocultar_campos()
    End Sub
End Class