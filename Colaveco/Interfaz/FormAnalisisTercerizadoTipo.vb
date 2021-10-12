Public Class FormAnalisisTercerizadoTipo
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
    Private _subinforme As dSubInforme
    Public Property Subinforme() As dSubInforme
        Get
            Return _subinforme
        End Get
        Set(ByVal value As dSubInforme)
            _subinforme = value
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
        cargarComboTipoInforme()
        cargarComboTercerizados()
        limpiar()
    End Sub

#End Region
    Private Sub cargarlista()
        Dim a As New dAnalisisTercerizadoTipo
        Dim lista As New ArrayList
        lista = a.listar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each a In lista
                    DataGridView1(columna, fila).Value = a.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.NOMBRE
                    columna = columna + 1
                    Dim ti As New dTipoInforme
                    ti.ID = a.IDTIPOINFORME
                    ti = ti.buscar
                    If Not ti Is Nothing Then
                        DataGridView1(columna, fila).Value = ti.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                 
                    Dim at As New dAnalisisTercerizadoTipo
                    at.ID = a.DEPENDE
                    at = at.buscar
                    If Not at Is Nothing Then
                        DataGridView1(columna, fila).Value = at.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = a.ORDEN
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
        ComboTipo.Text = ""
        ComboTipo.SelectedItem = Nothing
        TextMetodo.Text = ""
        TextUnidad.Text = ""
        ComboTercerizados.Text = ""
        ComboTercerizados.SelectedItem = Nothing
        TextOrden.Text = ""
        ComboTipo.Focus()
    End Sub
    Public Sub cargarComboTipoInforme()
        Dim ti As New dTipoInforme
        Dim lista As New ArrayList
        lista = ti.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ti In lista
                    ComboTipo.Items.Add(ti)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboTercerizados()
        Dim t As New dAnalisisTercerizadoTipo
        Dim lista As New ArrayList
        lista = t.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each t In lista
                    ComboTercerizados.Items.Add(t)
                Next
            End If
        End If
    End Sub
    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim nombre As String = TextNombre.Text.Trim
        Dim tipoinforme As dTipoInforme = CType(ComboTipo.SelectedItem, dTipoInforme)
        Dim metodo As String = ""
        Dim unidad As String = ""
        If TextMetodo.Text <> "" Then
            metodo = TextMetodo.Text.Trim
        End If
        If TextUnidad.Text <> "" Then
            unidad = TextUnidad.Text.Trim
        End If
        Dim tercerizado As dAnalisisTercerizadoTipo = CType(ComboTercerizados.SelectedItem, dAnalisisTercerizadoTipo)
        Dim t As Integer = 0
        If Not tercerizado Is Nothing Then
            t = tercerizado.ID
        End If
        Dim orden As Integer = 0
        If TextOrden.Text <> "" Then
            orden = TextOrden.Text
        End If
        If TextId.Text.Trim.Length > 0 Then
            If TextNombre.Text.Trim.Length > 0 Then
                Dim a As New dAnalisisTercerizadoTipo()
                Dim id As Long = TextId.Text.Trim
                a.ID = id
                If Not tipoinforme Is Nothing Then
                    a.IDTIPOINFORME = tipoinforme.ID
                End If
                a.NOMBRE = nombre
                a.METODO = metodo
                a.UNIDAD = unidad
                a.DEPENDE = t
                a.ORDEN = orden
                If (a.modificar(Usuario)) Then
                    MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        Else
            If TextNombre.Text.Trim.Length > 0 Then
                Dim a As New dAnalisisTercerizadoTipo()
                If Not tipoinforme Is Nothing Then
                    a.IDTIPOINFORME = tipoinforme.ID
                End If
                a.NOMBRE = nombre
                a.METODO = metodo
                a.UNIDAD = unidad
                a.DEPENDE = t
                a.ORDEN = orden
                If (a.guardar(Usuario)) Then
                    MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        cargarLista()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        limpiar()
        If DataGridView1.Columns(e.ColumnIndex).Name = "Id" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim a As New dAnalisisTercerizadoTipo
            id = row.Cells("Id").Value
            a.ID = id
            a = a.buscar
            If Not a Is Nothing Then
                TextId.Text = a.ID
                Dim t As dTipoInforme
                ComboTipo.SelectedItem = Nothing
                For Each t In ComboTipo.Items
                    If t.ID = a.IDTIPOINFORME Then
                        ComboTipo.SelectedItem = t
                        Exit For
                    End If
                Next
                TextNombre.Text = a.NOMBRE
                TextMetodo.Text = a.METODO
                TextUnidad.Text = a.UNIDAD
                Dim at As dAnalisisTercerizadoTipo
                ComboTercerizados.SelectedItem = Nothing
                For Each at In ComboTercerizados.Items
                    If at.ID = a.DEPENDE Then
                        ComboTercerizados.SelectedItem = at
                        Exit For
                    End If
                Next
                TextOrden.Text = a.ORDEN
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Tipo" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim a As New dAnalisisTercerizadoTipo
            id = row.Cells("Id").Value
            a.ID = id
            a = a.buscar
            If Not a Is Nothing Then
                TextId.Text = a.ID
                Dim t As dTipoInforme
                ComboTipo.SelectedItem = Nothing
                For Each t In ComboTipo.Items
                    If t.ID = a.IDTIPOINFORME Then
                        ComboTipo.SelectedItem = t
                        Exit For
                    End If
                Next
                TextNombre.Text = a.NOMBRE
                TextMetodo.Text = a.METODO
                TextUnidad.Text = a.UNIDAD
                Dim at As dAnalisisTercerizadoTipo
                ComboTercerizados.SelectedItem = Nothing
                For Each at In ComboTercerizados.Items
                    If at.ID = a.DEPENDE Then
                        ComboTercerizados.SelectedItem = at
                        Exit For
                    End If
                Next
                TextOrden.Text = a.ORDEN
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Nombre" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim a As New dAnalisisTercerizadoTipo
            id = row.Cells("Id").Value
            a.ID = id
            a = a.buscar
            If Not a Is Nothing Then
                TextId.Text = a.ID
                Dim t As dTipoInforme
                ComboTipo.SelectedItem = Nothing
                For Each t In ComboTipo.Items
                    If t.ID = a.IDTIPOINFORME Then
                        ComboTipo.SelectedItem = t
                        Exit For
                    End If
                Next
                TextNombre.Text = a.NOMBRE
                TextMetodo.Text = a.METODO
                TextUnidad.Text = a.UNIDAD
                Dim at As dAnalisisTercerizadoTipo
                ComboTercerizados.SelectedItem = Nothing
                For Each at In ComboTercerizados.Items
                    If at.ID = a.DEPENDE Then
                        ComboTercerizados.SelectedItem = at
                        Exit For
                    End If
                Next
                TextOrden.Text = a.ORDEN
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Depende" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim a As New dAnalisisTercerizadoTipo
            id = row.Cells("Id").Value
            a.ID = id
            a = a.buscar
            If Not a Is Nothing Then
                TextId.Text = a.ID
                Dim t As dTipoInforme
                ComboTipo.SelectedItem = Nothing
                For Each t In ComboTipo.Items
                    If t.ID = a.IDTIPOINFORME Then
                        ComboTipo.SelectedItem = t
                        Exit For
                    End If
                Next
                TextNombre.Text = a.NOMBRE
                TextMetodo.Text = a.METODO
                TextUnidad.Text = a.UNIDAD
                Dim at As dAnalisisTercerizadoTipo
                ComboTercerizados.SelectedItem = Nothing
                For Each at In ComboTercerizados.Items
                    If at.ID = a.DEPENDE Then
                        ComboTercerizados.SelectedItem = at
                        Exit For
                    End If
                Next
                TextOrden.Text = a.ORDEN
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class