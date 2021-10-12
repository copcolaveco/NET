Public Class FormUnidades
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
        Dim uni As New dUnidades
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = uni.listar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Add(lista.Count)
            End If
        End If

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each uni In lista
                    If uni.ELIMINADA = 0 Then
                        DataGridView1(columna, fila).Value = uni.ID
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = uni.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = uni.ID
                        'DataGridView1(columna, fila).Style.BackColor = Color.Red
                        'DataGridView1(columna, fila).Style.ForeColor = Color.White
                        'Me.DataGridView1.Rows(e.RowIndex).DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = uni.NOMBRE
                        'DataGridView1(columna, fila).Style.BackColor = Color.Red
                        'DataGridView1(columna, fila).Style.ForeColor = Color.White
                        DataGridView1(columna, fila).Style.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
                        columna = 0
                        fila = fila + 1

                    End If
                Next
            End If
        End If
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextNombre.Text = ""
        CheckEliminada.Checked = False
        TextNombre.Focus()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Nombre" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim uni As New dUnidades
            id = row.Cells("Id").Value
            uni.ID = id
            uni = uni.buscar()
            If Not uni Is Nothing Then
                TextId.Text = uni.ID
                TextNombre.Text = uni.NOMBRE
                If uni.ELIMINADA = 0 Then
                    CheckEliminada.Checked = False
                Else
                    CheckEliminada.Checked = True
                End If
            End If
        End If
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        If TextNombre.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el nombre", MsgBoxStyle.Exclamation, "Atención") : TextNombre.Focus() : Exit Sub
        Dim nombre As String = TextNombre.Text
        Dim eliminada As Integer = 0
        If CheckEliminada.Checked = True Then
            eliminada = 1
        End If
        If TextId.Text.Trim.Length > 0 Then
            Dim uni As New dUnidades
            Dim id As Long = CType(TextId.Text.Trim, Long)
            uni.ID = id
            uni.NOMBRE = nombre
            uni.ELIMINADA = eliminada
            If (uni.modificar(Usuario)) Then
                MsgBox("Unidad modificada", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim uni As New dUnidades
            uni.NOMBRE = nombre
            uni.ELIMINADA = eliminada
            If (uni.guardar(Usuario)) Then
                MsgBox("Unidad guardada", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        cargarlista()
    End Sub
End Class