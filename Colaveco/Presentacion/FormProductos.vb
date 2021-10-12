Public Class FormProductos
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
        cargarCategorias()
        cargarUnidades()
        limpiar()
    End Sub

#End Region
    Public Sub cargarUnidades()
        Dim uni As New dUnidades
        Dim lista As New ArrayList
        lista = uni.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each uni In lista
                    ComboUnidad.Items.Add(uni)
                Next
            End If
        End If
    End Sub
    Private Sub cargarlista()
        Dim p As New dProductos
        Dim lista As New ArrayList
        lista = p.listar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each p In lista
                    DataGridView1(columna, fila).Value = p.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = p.NOMBRE
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Public Sub cargarCategorias()
        Dim c As New dCategoria
        Dim lista As New ArrayList
        lista = c.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    ComboCategoria.Items.Add(c)
                Next
            End If
        End If
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextCodigo.Text = ""
        TextNombre.Text = ""
        TextDetalle.Text = ""
        ComboUnidad.Text = ""
        ComboCategoria.Text = ""
        ComboIva.Text = 0
        cargarlista()
        TextCodigo.Focus()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        If TextCodigo.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el código", MsgBoxStyle.Exclamation, "Atención") : TextCodigo.Focus() : Exit Sub
        Dim codigo As String = TextCodigo.Text.Trim
        If TextNombre.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el nombre", MsgBoxStyle.Exclamation, "Atención") : TextNombre.Focus() : Exit Sub
        Dim nombre As String = TextNombre.Text.Trim
        Dim detalle As String = ""
        If TextDetalle.Text <> "" Then
            detalle = TextDetalle.Text.Trim
        End If
        If ComboUnidad.Text.Trim.Length = 0 Then MsgBox("Seleccione una unidad", MsgBoxStyle.Exclamation, "Atención") : ComboUnidad.Focus() : Exit Sub
        Dim unidad As dUnidades = CType(ComboUnidad.SelectedItem, dUnidades)
        If ComboCategoria.Text.Trim.Length = 0 Then MsgBox("Seleccione una categoría", MsgBoxStyle.Exclamation, "Atención") : ComboCategoria.Focus() : Exit Sub
        Dim categoria As dCategoria = CType(ComboCategoria.SelectedItem, dCategoria)
        Dim iva As Integer = 0
        If ComboIva.Text <> "" Then
            iva = ComboIva.Text
        End If

        If TextId.Text <> "" Then
            Dim p As New dProductos
            Dim id As Long = TextId.Text.Trim
            p.ID = id
            p.CODIGO = codigo
            p.NOMBRE = nombre
            p.DETALLE = detalle
            p.UNIDAD = unidad.ID
            p.CATEGORIA = categoria.ID
            p.IVA = iva
            If (p.modificar(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim p As New dProductos
            p.CODIGO = codigo
            p.NOMBRE = nombre
            p.DETALLE = detalle
            p.UNIDAD = unidad.ID
            p.CATEGORIA = categoria.ID
            p.IVA = iva
            If (p.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Nombre" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim p As New dProductos
            id = row.Cells("Id").Value
            p.ID = id
            p = p.buscar
            If Not p Is Nothing Then
                TextId.Text = p.ID
                TextCodigo.Text = p.CODIGO
                TextNombre.Text = p.NOMBRE
                TextDetalle.Text = p.DETALLE
                Dim u As dUnidades
                ComboUnidad.SelectedItem = Nothing
                For Each u In ComboUnidad.Items
                    If u.ID = p.UNIDAD Then
                        ComboUnidad.SelectedItem = u
                        Exit For
                    End If
                Next
                Dim c As dCategoria
                ComboCategoria.SelectedItem = Nothing
                For Each c In ComboCategoria.Items
                    If c.ID = p.CATEGORIA Then
                        ComboCategoria.SelectedItem = c
                        Exit For
                    End If
                Next
                ComboIva.Text = p.IVA
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBuscar.TextChanged
        Dim nombre As String = TextBuscar.Text.Trim
        DataGridView1.Rows.Clear()
        If nombre.Length > 0 Then
            Dim p As New dProductos
            Dim lista As New ArrayList
            lista = p.buscarPorNombre(nombre)
            If Not lista Is Nothing And lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each p In lista
                    DataGridView1(columna, fila).Value = p.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = p.NOMBRE
                    columna = 0
                    fila = fila + 1
                Next
            End If
        Else : DataGridView1.Rows.Clear()
        End If
    End Sub

    Private Sub ButtonTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTodos.Click
        TextBuscar.Text = ""
        cargarlista()
    End Sub

    Private Sub TextCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextCodigo.TextChanged

    End Sub
End Class