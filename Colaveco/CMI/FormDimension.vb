Public Class FormDimension
    Private _usuario As dUsuario
    Private _anio As Integer
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
        calcularano()
        listar()

    End Sub
#End Region
    Private Sub listar()
        Dim d As New dDimension
        Dim lista As New ArrayList
        lista = d.listarxano(_anio)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.ColumnCount = 3
                DataGridView1.Columns(0).Name = "Id"
                DataGridView1.Columns(0).Width = 50
                DataGridView1.Columns(1).Name = "Nombre"
                DataGridView1.Columns(1).Width = 200
                DataGridView1.Columns(2).Name = "Año"
                DataGridView1.Columns(2).Width = 50
                DataGridView1.Rows.Add(lista.Count)
                For Each d In lista
                    DataGridView1(columna, fila).Value = d.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = d.NOMBRE
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = d.ANO
                    columna = 0
                    fila = fila + 1
                Next
                DataGridView1.Sort(DataGridView1.Columns(2), System.ComponentModel.ListSortDirection.Descending)

            End If
        End If
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextNombre.Text = ""
        calcularano()
        TextNombre.Focus()
    End Sub
    Private Sub calcularano()
        Dim hoy As Date = Now
        Dim ano As Integer = 0
        ano = hoy.Year
        _anio = hoy.Year
        NumericAno.Value = ano
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Id" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim d As New dDimension
            id = row.Cells("Id").Value
            d.ID = id
            d = d.buscar
            If Not d Is Nothing Then
                TextId.Text = d.ID
                TextNombre.Text = d.NOMBRE
                NumericAno.Value = d.ANO
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Nombre" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim d As New dDimension
            id = row.Cells("Id").Value
            d.ID = id
            d = d.buscar
            If Not d Is Nothing Then
                TextId.Text = d.ID
                TextNombre.Text = d.NOMBRE
                NumericAno.Value = d.ANO
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Año" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim d As New dDimension
            id = row.Cells("Id").Value
            d.ID = id
            d = d.buscar
            If Not d Is Nothing Then
                TextId.Text = d.ID
                TextNombre.Text = d.NOMBRE
                NumericAno.Value = d.ANO
            End If
        End If
    End Sub
    Private Sub guardar()
        Dim nombre As String = TextNombre.Text.Trim
        Dim ano As Integer = NumericAno.Value
        If TextId.Text.Trim.Length > 0 Then
            Dim d As New dDimension
            Dim id As Long = TextId.Text.Trim
            d.ID = id
            d.NOMBRE = nombre
            d.ANO = ano
            If (d.modificar(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim d As New dDimension
            d.NOMBRE = nombre
            d.ANO = ano
            If (d.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        limpiar()
        listar()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If TextId.Text.Length > 0 Then
            Dim d As New dDimension
            Dim id As Long = CType(TextId.Text, Long)
            d.ID = id
            If (d.eliminar(Usuario)) Then
                MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        limpiar()
        listar()
    End Sub

    Private Sub NumericAno_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericAno.ValueChanged
        _anio = NumericAno.Value
        listar()
    End Sub
End Class