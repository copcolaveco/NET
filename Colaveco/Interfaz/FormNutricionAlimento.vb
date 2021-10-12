Public Class FormNutricionAlimento
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
        cargarlista()
        cargarComboClase()
        limpiar()
    End Sub

#End Region
    Public Sub cargarComboClase()
        Dim nc As New dNutricionClase
        Dim lista As New ArrayList
        lista = nc.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each nc In lista
                    ComboClase.Items.Add(nc)
                Next
            End If
        End If
    End Sub
    Private Sub cargarlista()
        Dim n As New dNutricionAlimento
        Dim lista As New ArrayList
        lista = n.listar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each n In lista
                    DataGridView1(columna, fila).Value = n.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = n.NOMBRE
                    columna = columna + 1
                    Dim nc As New dNutricionClase
                    nc.ID = n.IDCLASE
                    nc = nc.buscar
                    If Not nc Is Nothing Then
                        DataGridView1(columna, fila).Value = nc.NOMBRE
                        columna = 0
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                    End If
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub


    Public Sub limpiar()
        TextId.Text = ""
        ComboClase.Text = ""
        TextNombre.Text = ""
        ComboClase.Focus()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        cargarLista()
        limpiar()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        If ComboClase.Text = "" Then MsgBox("No se ha seleccionado la clase de alimento.", MsgBoxStyle.Exclamation, "Atención") : ComboClase.Focus() : Exit Sub
        Dim idclase As dNutricionClase = CType(ComboClase.SelectedItem, dNutricionClase)
        Dim nombre As String = TextNombre.Text.Trim
        If TextId.Text.Trim.Length > 0 Then
            If TextNombre.Text.Trim.Length > 0 Then
                Dim n As New dNutricionAlimento()
                Dim id As Long = TextId.Text.Trim
                n.ID = id
                n.IDCLASE = idclase.ID
                n.NOMBRE = nombre
                If (n.modificar(Usuario)) Then
                    ' MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        Else
            If TextNombre.Text.Trim.Length > 0 Then
                Dim n As New dNutricionAlimento()
                n.IDCLASE = idclase.ID
                n.NOMBRE = nombre
                If (n.guardar(Usuario)) Then
                    'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        cargarlista()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Nombre" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim n As New dNutricionAlimento
            id = row.Cells("Id").Value
            n.ID = id
            n = n.buscar
            If Not n Is Nothing Then
                TextId.Text = n.ID
                Dim nc As dNutricionClase
                ComboClase.SelectedItem = Nothing
                For Each nc In ComboClase.Items
                    If nc.ID = n.IDCLASE Then
                        ComboClase.SelectedItem = nc
                        Exit For
                    End If
                Next
                TextNombre.Text = n.NOMBRE
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Clase" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim n As New dNutricionAlimento
            id = row.Cells("Id").Value
            n.ID = id
            n = n.buscar
            If Not n Is Nothing Then
                TextId.Text = n.ID
                Dim nc As dNutricionClase
                ComboClase.SelectedItem = Nothing
                For Each nc In ComboClase.Items
                    If nc.ID = n.IDCLASE Then
                        ComboClase.SelectedItem = nc
                        Exit For
                    End If
                Next
                TextNombre.Text = n.NOMBRE
            End If
        End If
    End Sub
End Class