Public Class FormObjGral
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
        cargarcombo()
        listar()

    End Sub
#End Region
    Private Sub calcularano()
        Dim hoy As Date = Now
        Dim ano As Integer = 0
        ano = hoy.Year
        _anio = hoy.Year
        NumericAno.Value = ano
    End Sub
    Private Sub listar()
        Dim og As New dObjGral
        Dim lista As New ArrayList
        lista = og.listarxano(_anio)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)

                For Each og In lista
                    Dim d As New dDimension
                    DataGridView1(columna, fila).Value = og.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = og.NOMBRE
                    columna = columna + 1
                    d.ID = og.IDDIMENSION
                    d = d.buscar
                    If Not d Is Nothing Then
                        DataGridView1(columna, fila).Value = d.NOMBRE
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = og.ANO
                    columna = 0
                    fila = fila + 1
                Next
                DataGridView1.Sort(DataGridView1.Columns(3), System.ComponentModel.ListSortDirection.Descending)

            End If
        End If
    End Sub
    Private Sub listarxdimension()
      
    End Sub
    Public Sub cargarcombo()
        ComboDimension.Items.Clear()
        Dim d As New dDimension
        Dim lista As New ArrayList
        lista = d.listarxano(_anio)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each d In lista
                    ComboDimension.Items.Add(d)
                Next
            End If
        End If
    End Sub

    Private Sub NumericAno_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericAno.ValueChanged
        _anio = NumericAno.Value
        cargarcombo()
        listar()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextNombre.Text = ""
        ComboDimension.Text = ""
        calcularano()
        cargarcombo()
        listar()
        ComboDimension.Focus()
    End Sub
    Private Sub guardar()

        Dim dimension As dDimension = CType(ComboDimension.SelectedItem, dDimension)
        If TextNombre.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el nombre", MsgBoxStyle.Exclamation, "Atención") : TextNombre.Focus() : Exit Sub
        Dim nombre As String = TextNombre.Text.Trim
        Dim ano As Integer = NumericAno.Value
        If TextId.Text.Trim.Length > 0 Then
            Dim og As New dObjGral
            Dim id As Long = CType(TextId.Text.Trim, Long)
            og.ID = id
            If Not dimension Is Nothing Then
                og.IDDIMENSION = dimension.ID
            Else
                MsgBox("Seleccione una dimensión", MsgBoxStyle.Exclamation, "Atención") : ComboDimension.Focus() : Exit Sub
            End If
            og.NOMBRE = nombre
            og.ANO = ano
            If (og.modificar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim og As New dObjGral
            If Not dimension Is Nothing Then
                og.IDDIMENSION = dimension.ID
            Else
                MsgBox("Seleccione una dimensión", MsgBoxStyle.Exclamation, "Atención") : ComboDimension.Focus() : Exit Sub
            End If
            og.NOMBRE = nombre
            og.ANO = ano
            If (og.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
    Public Sub cargarcombotodos2()
        ComboDimension.Items.Clear()
        Dim d As New dDimension
        Dim lista As New ArrayList
        lista = d.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each d In lista
                    ComboDimension.Items.Add(d)
                Next
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Id" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim og As New dObjGral
            id = row.Cells("Id").Value
            og.ID = id
            og = og.buscar
            If Not og Is Nothing Then
                TextId.Text = og.ID
                Dim d As dDimension
                cargarcombotodos2()
                For Each d In ComboDimension.Items
                    If d.ID = og.IDDIMENSION Then
                        ComboDimension.SelectedItem = d
                        Exit For
                    End If
                Next
                TextNombre.Text = og.NOMBRE
                NumericAno.Value = og.ANO
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Dimension" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim og As New dObjGral
            id = row.Cells("Id").Value
            og.ID = id
            og = og.buscar
            If Not og Is Nothing Then
                TextId.Text = og.ID
                Dim d As dDimension
                cargarcombotodos2()
                For Each d In ComboDimension.Items
                    If d.ID = og.IDDIMENSION Then
                        ComboDimension.SelectedItem = d
                        Exit For
                    End If
                Next
                TextNombre.Text = og.NOMBRE
                NumericAno.Value = og.ANO
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Nombre" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim og As New dObjGral
            id = row.Cells("Id").Value
            og.ID = id
            og = og.buscar
            If Not og Is Nothing Then
                TextId.Text = og.ID
                Dim d As dDimension
                cargarcombotodos2()
                For Each d In ComboDimension.Items
                    If d.ID = og.IDDIMENSION Then
                        ComboDimension.SelectedItem = d
                        Exit For
                    End If
                Next
                TextNombre.Text = og.NOMBRE
                NumericAno.Value = og.ANO
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Ano" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim og As New dObjGral
            id = row.Cells("Id").Value
            og.ID = id
            og = og.buscar
            If Not og Is Nothing Then
                TextId.Text = og.ID
                Dim d As dDimension
                cargarcombotodos2()
                For Each d In ComboDimension.Items
                    If d.ID = og.IDDIMENSION Then
                        ComboDimension.SelectedItem = d
                        Exit For
                    End If
                Next
                TextNombre.Text = og.NOMBRE
                NumericAno.Value = og.ANO
            End If
        End If
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If TextId.Text.Length > 0 Then
            Dim og As New dObjGral
            Dim id As Long = CType(TextId.Text, Long)
            og.ID = id
            If (og.eliminar(Usuario)) Then
                MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        limpiar()
        listar()
    End Sub

    Private Sub ComboDimension_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboDimension.SelectedIndexChanged

        Dim dimension As dDimension = CType(ComboDimension.SelectedItem, dDimension)
        Dim iddimension As Integer = 0
        iddimension = dimension.ID

        Dim og As New dObjGral
        Dim lista As New ArrayList
        lista = og.listarxdimension(iddimension)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)

                For Each og In lista
                    Dim d As New dDimension
                    DataGridView1(columna, fila).Value = og.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = og.NOMBRE
                    columna = columna + 1
                    d.ID = og.IDDIMENSION
                    d = d.buscar
                    If Not d Is Nothing Then
                        DataGridView1(columna, fila).Value = d.NOMBRE
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = og.ANO
                    columna = 0
                    fila = fila + 1
                Next
                DataGridView1.Sort(DataGridView1.Columns(3), System.ComponentModel.ListSortDirection.Descending)

            End If
        End If
    End Sub

    Private Sub ButtonTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTodos.Click
        ComboDimension.Text = ""
        listar()
    End Sub
End Class