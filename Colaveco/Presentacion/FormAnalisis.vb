Public Class FormAnalisis
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
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarLista()
        limpiar()
    End Sub

#End Region
    Private Sub limpiar()
        TextId.Text = ""
        TextNombre.Text = ""
        TextSimbolo.Text = ""
        TextCosto.Text = ""
        TextNombre.Focus()
    End Sub
    Public Sub cargarLista()
        Dim a As New dAnalisis
        Dim id As Long
        Dim nombre As String
        Dim simbolo As String
        Dim costo As Double
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = a.listar
        DataGridView1.Rows.Clear()
        DataGridView1.Rows.Add(lista.Count)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each a In lista
                    id = a.ID
                    nombre = a.NOMBRE
                    simbolo = a.SIMBOLOMONEDA
                    costo = a.COSTO
                    DataGridView1(columna, fila).Value = id
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = nombre
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = simbolo
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = costo
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim id As Long = 0
        Dim nombre As String = ""
        Dim simbolo As String = ""
        Dim costo As Double = 0
        If DataGridView1.Columns(e.ColumnIndex).Name = "Id" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            id = row.Cells("Id").Value
            nombre = row.Cells("Nombre").Value
            simbolo = row.Cells("Simbolo").Value
            costo = row.Cells("Costo").Value
            TextId.Text = Id
            TextNombre.Text = nombre
            TextSimbolo.Text = simbolo
            TextCosto.Text = costo
            TextNombre.Focus()
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Nombre" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            id = row.Cells("Id").Value
            nombre = row.Cells("Nombre").Value
            simbolo = row.Cells("Simbolo").Value
            costo = row.Cells("Costo").Value
            TextId.Text = id
            TextNombre.Text = nombre
            TextSimbolo.Text = simbolo
            TextCosto.Text = costo
            TextNombre.Focus()
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Simbolo" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            id = row.Cells("Id").Value
            nombre = row.Cells("Nombre").Value
            simbolo = row.Cells("Simbolo").Value
            costo = row.Cells("Costo").Value
            TextId.Text = id
            TextNombre.Text = nombre
            TextSimbolo.Text = simbolo
            TextCosto.Text = costo
            TextNombre.Focus()
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Costo" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            id = row.Cells("Id").Value
            nombre = row.Cells("Nombre").Value
            simbolo = row.Cells("Simbolo").Value
            costo = row.Cells("Costo").Value
            TextId.Text = id
            TextNombre.Text = nombre
            TextSimbolo.Text = simbolo
            TextCosto.Text = costo
            TextNombre.Focus()
        End If
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim nombre As String = TextNombre.Text.Trim
        Dim simbolo As String = TextSimbolo.Text.Trim
        Dim costo As Double = TextCosto.Text.Trim
        If Not DataGridView1.SelectedColumns Is Nothing And TextId.Text.Trim.Length > 0 Then
            If TextNombre.Text.Trim.Length > 0 Then
                Dim a As New dAnalisis()
                Dim id As Long = TextId.Text.Trim
                a.ID = id
                a.NOMBRE = nombre
                a.SIMBOLOMONEDA = simbolo
                a.COSTO = costo
                If (a.modificar(Usuario)) Then
                    MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        Else
            If TextNombre.Text.Trim.Length > 0 Then
                Dim a As New dAnalisis()
                a.NOMBRE = nombre
                a.SIMBOLOMONEDA = simbolo
                a.COSTO = costo
                If (a.guardar(Usuario)) Then
                    MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        cargarLista()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If Not DataGridView1.SelectedColumns Is Nothing Then
            Dim a As New dAnalisis
            Dim id As Long = CType(TextId.Text, Long)
            a.ID = id
            If (a.eliminar(Usuario)) Then
                MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        limpiar()
        cargarLista()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        cargarLista()
        limpiar()
    End Sub
End Class