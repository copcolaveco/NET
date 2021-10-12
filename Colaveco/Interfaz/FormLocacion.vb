Public Class FormLocacion
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarLista()
        limpiar()
    End Sub
    Private Sub cargarlista()
        Dim l As New dLocacion
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = l.listar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Add(lista.Count)
            End If
        End If

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each l In lista
                    DataGridView1(columna, fila).Value = l.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = l.NOMBRE
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextNombre.Text = ""
        TextNombre.Focus()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Nombre" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim l As New dLocacion
            id = row.Cells("Id").Value
            l.ID = id
            l = l.buscar()
            If Not l Is Nothing Then
                TextId.Text = l.ID
                TextNombre.Text = l.NOMBRE
            End If
        End If
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        If TextNombre.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el nombre", MsgBoxStyle.Exclamation, "Atención") : TextNombre.Focus() : Exit Sub
        Dim nombre As String = TextNombre.Text
        If TextId.Text.Trim.Length > 0 Then
            Dim l As New dLocacion
            Dim id As Long = CType(TextId.Text.Trim, Long)
            l.ID = id
            l.NOMBRE = nombre
            If (l.modificar(Usuario)) Then
                MsgBox("Locación modificada", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim l As New dLocacion
            l.NOMBRE = nombre
            If (l.guardar(Usuario)) Then
                MsgBox("Locación guardada", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        cargarlista()
    End Sub
End Class