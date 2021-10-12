Public Class FormNoAtendibles
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
        cargarusuarios()
        cargarLista()
        limpiar()
        ComboUsuario.SelectedItem = Nothing
        Dim us As dUsuario
        For Each us In ComboUsuario.Items
            If us.ID = Usuario.ID Then
                ComboUsuario.SelectedItem = us
                Exit For
            End If
        Next
    End Sub

#End Region
    Private Sub cargarusuarios()
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = u.listartodos
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each u In lista
                    ComboUsuario.Items.Add(u)
                Next
            End If
        End If
    End Sub
    Private Sub cargarlista()
        Dim p As New dNoAtendibles
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
                    DataGridView1(columna, fila).Value = p.FECHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = p.CLIENTE
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = p.ANALISIS
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        DateFecha.Value = Now
        TextCliente.Text = ""
        TextTelefono.Text = ""
        TextAnalisis.Text = ""
        TextCantidad.Text = ""
        TextObservaciones.Text = ""
        cargarlista()
        TextCliente.Focus()
    End Sub

    Private Sub guardar()
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        If TextCliente.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el cliente", MsgBoxStyle.Exclamation, "Atención") : TextCliente.Focus() : Exit Sub
        Dim cliente As String = TextCliente.Text.Trim
        Dim telefono As String = ""
        If TextTelefono.Text <> "" Then
            telefono = TextTelefono.Text.Trim
        End If
        Dim analisis As String = ""
        If TextAnalisis.Text <> "" Then
            analisis = TextAnalisis.Text.Trim
        End If
        Dim cantidad As String = ""
        If TextCantidad.Text <> "" Then
            cantidad = TextCantidad.Text.Trim
        End If
        Dim observaciones As String = ""
        If TextObservaciones.Text <> "" Then
            observaciones = TextObservaciones.Text.Trim
        End If
        Dim usuario As dUsuario = CType(ComboUsuario.SelectedItem, dUsuario)
        If TextId.Text <> "" Then
            Dim p As New dNoAtendibles
            Dim id As Long = TextId.Text.Trim
            p.ID = id
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            p.FECHA = fec
            p.CLIENTE = cliente
            p.TELEFONO = telefono
            p.ANALISIS = analisis
            p.CANTIDAD = cantidad
            p.OBSERVACIONES = observaciones
            p.USUARIO = usuario.ID
            If (p.modificar(usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim p As New dNoAtendibles
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            p.FECHA = fec
            p.CLIENTE = cliente
            p.TELEFONO = telefono
            p.ANALISIS = analisis
            p.CANTIDAD = cantidad
            p.OBSERVACIONES = observaciones
            p.USUARIO = usuario.ID
            If (p.guardar(usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub

    Private Sub ButtonGuardar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub

    Private Sub ButtonNuevo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If TextId.Text <> "" Then
            If MsgBox("El registro será eliminado, ¿desea continuar?", MsgBoxStyle.OkCancel, "Atención") = MsgBoxResult.Ok Then
                Dim p As New dNoAtendibles
                Dim id As Long = CType(TextId.Text, Long)
                p.ID = id
                If (p.eliminar(Usuario)) Then
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        cargarlista()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim p As New dNoAtendibles
            id = row.Cells("Id").Value
            p.ID = id
            p = p.buscar
            If Not p Is Nothing Then
                TextId.Text = p.ID
                DateFecha.Value = p.FECHA
                TextCliente.Text = p.CLIENTE
                TextTelefono.Text = p.TELEFONO
                TextAnalisis.Text = p.ANALISIS
                TextCantidad.Text = p.CANTIDAD
                TextObservaciones.Text = p.OBSERVACIONES
                Dim u As New dUsuario
                Dim lista As New ArrayList
                lista = u.listartodos
                If Not lista Is Nothing Then
                    If lista.Count > 0 Then
                        For Each u In lista
                            ComboUsuario.Items.Add(u)
                        Next
                    End If
                End If
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Cliente" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim p As New dNoAtendibles
            id = row.Cells("Id").Value
            p.ID = id
            p = p.buscar
            If Not p Is Nothing Then
                TextId.Text = p.ID
                DateFecha.Value = p.FECHA
                TextCliente.Text = p.CLIENTE
                TextTelefono.Text = p.TELEFONO
                TextAnalisis.Text = p.ANALISIS
                TextCantidad.Text = p.CANTIDAD
                TextObservaciones.Text = p.OBSERVACIONES
                Dim u As New dUsuario
                Dim lista As New ArrayList
                lista = u.listartodos
                If Not lista Is Nothing Then
                    If lista.Count > 0 Then
                        For Each u In lista
                            ComboUsuario.Items.Add(u)
                        Next
                    End If
                End If
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Analisis" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim p As New dNoAtendibles
            id = row.Cells("Id").Value
            p.ID = id
            p = p.buscar
            If Not p Is Nothing Then
                TextId.Text = p.ID
                DateFecha.Value = p.FECHA
                TextCliente.Text = p.CLIENTE
                TextTelefono.Text = p.TELEFONO
                TextAnalisis.Text = p.ANALISIS
                TextCantidad.Text = p.CANTIDAD
                TextObservaciones.Text = p.OBSERVACIONES
                Dim u As New dUsuario
                Dim lista As New ArrayList
                lista = u.listartodos
                If Not lista Is Nothing Then
                    If lista.Count > 0 Then
                        For Each u In lista
                            ComboUsuario.Items.Add(u)
                        Next
                    End If
                End If
            End If
        End If
    End Sub
End Class