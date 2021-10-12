Public Class FormOtrosLaboratorios
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
    Public Sub cargarLista()
        Dim ot As New dOtrosLaboratorios
        Dim lista As New ArrayList
        lista = ot.listar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each ot In lista
                    DataGridView1(columna, fila).Value = ot.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ot.NOMBRE
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        TextNombre.Text = ""
        TextNombre.Focus()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        cargarLista()
        limpiar()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim nombre As String = TextNombre.Text.Trim
        If TextId.Text.Trim.Length > 0 Then
            If TextNombre.Text.Trim.Length > 0 Then
                Dim ot As New dOtrosLaboratorios()
                Dim id As Long = TextId.Text.Trim
                ot.ID = id
                ot.NOMBRE = nombre
                If (ot.modificar(Usuario)) Then
                    MsgBox("Laboratorio modificado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        Else
            If TextNombre.Text.Trim.Length > 0 Then
                Dim ot As New dOtrosLaboratorios()
                ot.NOMBRE = nombre
                If (ot.guardar(Usuario)) Then
                    MsgBox("Laboratorio guardado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        cargarLista()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Id" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ot As New dOtrosLaboratorios
            id = row.Cells("Id").Value
            ot.ID = id
            ot = ot.buscar
            If Not ot Is Nothing Then
                TextId.Text = ot.ID
                TextNombre.Text = ot.NOMBRE
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Nombre" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ot As New dOtrosLaboratorios
            id = row.Cells("Id").Value
            ot.ID = id
            ot = ot.buscar
            If Not ot Is Nothing Then
                TextId.Text = ot.ID
                TextNombre.Text = ot.NOMBRE
            End If
        End If
    End Sub
End Class