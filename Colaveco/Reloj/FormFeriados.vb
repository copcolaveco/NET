Public Class FormFeriados
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
        DateFecha.Value = Now
    End Sub
#End Region
  
    Private Sub guardar()
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        If TextId.Text.Length > 0 Then
            Dim f As New dFeriados
            Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            f.ID = id
            f.FECHA = fec
            If (f.modificar(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim f As New dFeriados
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            f.FECHA = fec
            If (f.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        cargarLista()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        DateFecha.Focus()
    End Sub
    Private Sub cargarLista()
        Dim f As New dFeriados
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = f.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Clear()
                DataGridView1.Rows.Add(lista.Count)
                For Each f In lista
                    DataGridView1(columna, fila).Value = f.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = f.FECHA
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim f As New dFeriados
            id = row.Cells("Id").Value
            f.ID = id
            f = f.buscar
            If Not f Is Nothing Then
                TextId.Text = f.ID
                DateFecha.Value = f.FECHA
            End If
        End If
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If TextId.Text.Length > 0 Then
            Dim f As New dFeriados
            f.ID = TextId.Text.Trim
            If (f.eliminar(Usuario)) Then
                MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
End Class