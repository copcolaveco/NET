Public Class FormSolicitudIT
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
        cargarusuarios()
        cargarprioridades()
        cargarestados()
        limpiar()
        ComboUsuario.Text = u.NOMBRE
        cargarlista()
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        DateFecha.Value = Now
        TextDescripcion.Text = ""
        ComboUsuario.Text = Usuario.NOMBRE
        ComboPrioridad.Text = "Baja"
    End Sub
    Private Sub cargarusuarios()
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = u.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each u In lista
                    ComboUsuario.Items.Add(u)
                    ComboListarUsuario.Items.Add(u)
                Next
            End If
        End If
    End Sub
    Private Sub cargarprioridades()
        
        ComboPrioridad.Items.Add("Baja")
        ComboPrioridad.Items.Add("Media")
        ComboPrioridad.Items.Add("Alta")
        
    End Sub
    Private Sub cargarestados()

        ComboListarEstado.Items.Add("Pendiente")
        ComboListarEstado.Items.Add("En proceso")
        ComboListarEstado.Items.Add("Finalizado")

    End Sub
    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        If TextDescripcion.Text.Trim.Length = 0 Then MsgBox("Debe ingresar una descripción.", MsgBoxStyle.Exclamation, "Atención") : TextDescripcion.Focus() : Exit Sub
        Dim descripcion As String = TextDescripcion.Text
        If ComboUsuario.Text.Trim.Length = 0 Then MsgBox("Debe seleccionar un solicitante.", MsgBoxStyle.Exclamation, "Atención") : ComboUsuario.Focus() : Exit Sub
        Dim solicitante As dUsuario = CType(ComboUsuario.SelectedItem, dUsuario)
        Dim prioridad As Integer = 0
        Dim estado As Integer = 1
        If ComboPrioridad.Text.Trim.Length = 0 Then MsgBox("Debe seleccionar la prioridad.", MsgBoxStyle.Exclamation, "Atención") : ComboPrioridad.Focus() : Exit Sub
        If ComboPrioridad.Text = "Baja" Then
            prioridad = 1
        ElseIf ComboPrioridad.Text = "Media" Then
            prioridad = 2
        ElseIf ComboPrioridad.Text = "Alta" Then
            prioridad = 3
        End If

        If TextId.Text.Trim.Length > 0 Then
            Dim sit As New dSolicitudesIT
            Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            sit.ID = id
            sit.FECHA = fec
            sit.DESCRIPCION = descripcion
            If Not solicitante Is Nothing Then
                sit.SOLICITANTE = solicitante.ID
            End If
            sit.PRIORIDAD = prioridad
            sit.ESTADO = estado
            If (sit.modificar(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim sit As New dSolicitudesIT()
            'Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            'sit.ID = Id
            sit.FECHA = fec
            sit.DESCRIPCION = descripcion
            If Not solicitante Is Nothing Then
                sit.SOLICITANTE = solicitante.ID
            End If
            sit.PRIORIDAD = prioridad
            sit.ESTADO = estado
            If (sit.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        cargarLista()
    End Sub
    Private Sub cargarlista()
        Dim s As New dSolicitudesIT
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = s.listar
        
        DataGridView1.Rows.Clear()

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                Dim prioridad As String = ""
                Dim estado As String = ""
                DataGridView1.Rows.Add(lista.Count)
                For Each s In lista

                    DataGridView1(columna, fila).Value = s.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.FECHA
                    columna = columna + 1
                    u.ID = s.SOLICITANTE
                    u = u.buscar
                    If Not u Is Nothing Then
                        DataGridView1(columna, fila).Value = u.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    If s.PRIORIDAD = 1 Then
                        prioridad = "Baja"
                    ElseIf s.PRIORIDAD = 2 Then
                        prioridad = "Media"
                    Else
                        prioridad = "Alta"
                    End If
                    DataGridView1(columna, fila).Value = prioridad
                    columna = columna + 1
                    If s.ESTADO = 1 Then
                        estado = "Pendiente"
                    ElseIf s.ESTADO = 2 Then
                        estado = "En proceso"
                    Else
                        estado = "Finalizado"
                    End If
                    DataGridView1(columna, fila).Value = estado
                    If estado = "Pendiente" Then
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Red
                    ElseIf estado = "En proceso" Then
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Yellow
                    Else
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Green
                    End If
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub
    Private Sub cargarlistaxEstado()
        Dim s As New dSolicitudesIT
        Dim u As New dUsuario
        Dim lista As New ArrayList
        Dim est As Integer = 0
        If ComboListarEstado.Text.Trim.Length = 0 Then MsgBox("Debe seleccionar un estado.", MsgBoxStyle.Exclamation, "Atención") : ComboListarEstado.Focus() : Exit Sub
        If ComboListarEstado.Text = "Pendiente" Then
            est = 1
        ElseIf ComboListarEstado.Text = "En proceso" Then
            est = 2
        Else
            est = 3
        End If
        lista = s.listarxestado(est)

        DataGridView1.Rows.Clear()

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                Dim prioridad As String = ""
                Dim estado As String = ""
                DataGridView1.Rows.Add(lista.Count)
                For Each s In lista

                    DataGridView1(columna, fila).Value = s.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.FECHA
                    columna = columna + 1
                    u.ID = s.SOLICITANTE
                    u = u.buscar
                    If Not u Is Nothing Then
                        DataGridView1(columna, fila).Value = u.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    If s.PRIORIDAD = 1 Then
                        prioridad = "Baja"
                    ElseIf s.PRIORIDAD = 2 Then
                        prioridad = "Media"
                    Else
                        prioridad = "Alta"
                    End If
                    DataGridView1(columna, fila).Value = prioridad
                    columna = columna + 1
                    If s.ESTADO = 1 Then
                        estado = "Pendiente"
                    ElseIf s.ESTADO = 2 Then
                        estado = "En proceso"
                    Else
                        estado = "Finalizado"
                    End If
                    DataGridView1(columna, fila).Value = estado
                    If estado = "Pendiente" Then
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Red
                    ElseIf estado = "En proceso" Then
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Yellow
                    Else
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Green
                    End If
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub
    Private Sub cargarlistaxUsuario()
        Dim s As New dSolicitudesIT
        Dim u As New dUsuario
        Dim lista As New ArrayList

        If ComboListarUsuario.Text.Trim.Length = 0 Then MsgBox("Debe seleccionar un solicitante.", MsgBoxStyle.Exclamation, "Atención") : ComboListarUsuario.Focus() : Exit Sub
        Dim solicitante As dUsuario = CType(ComboListarUsuario.SelectedItem, dUsuario)
        Dim usuario As Integer = solicitante.ID
        lista = s.listarxusuario(usuario)

        DataGridView1.Rows.Clear()

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                Dim prioridad As String = ""
                Dim estado As String = ""
                DataGridView1.Rows.Add(lista.Count)
                For Each s In lista

                    DataGridView1(columna, fila).Value = s.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.FECHA
                    columna = columna + 1
                    u.ID = s.SOLICITANTE
                    u = u.buscar
                    If Not u Is Nothing Then
                        DataGridView1(columna, fila).Value = u.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    If s.PRIORIDAD = 1 Then
                        prioridad = "Baja"
                    ElseIf s.PRIORIDAD = 2 Then
                        prioridad = "Media"
                    Else
                        prioridad = "Alta"
                    End If
                    DataGridView1(columna, fila).Value = prioridad
                    columna = columna + 1
                    If s.ESTADO = 1 Then
                        estado = "Pendiente"
                    ElseIf s.ESTADO = 2 Then
                        estado = "En proceso"
                    Else
                        estado = "Finalizado"
                    End If
                    DataGridView1(columna, fila).Value = estado
                    If estado = "Pendiente" Then
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Red
                    ElseIf estado = "En proceso" Then
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Yellow
                    Else
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Green
                    End If
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub
    Private Sub cargarlistaxEstadoUsuario()
        Dim s As New dSolicitudesIT
        Dim u As New dUsuario
        Dim lista As New ArrayList
        Dim est As Integer = 0
        If ComboListarEstado.Text = "Pendiente" Then
            est = 1
        ElseIf ComboListarEstado.Text = "En proceso" Then
            est = 2
        Else
            est = 3
        End If
        Dim solicitante As dUsuario = CType(ComboListarUsuario.SelectedItem, dUsuario)
        Dim usuario As Integer = solicitante.ID
        lista = s.listarxestadousuario(est, usuario)

        DataGridView1.Rows.Clear()

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                Dim prioridad As String = ""
                Dim estado As String = ""
                DataGridView1.Rows.Add(lista.Count)
                For Each s In lista

                    DataGridView1(columna, fila).Value = s.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.FECHA
                    columna = columna + 1
                    u.ID = s.SOLICITANTE
                    u = u.buscar
                    If Not u Is Nothing Then
                        DataGridView1(columna, fila).Value = u.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    If s.PRIORIDAD = 1 Then
                        prioridad = "Baja"
                    ElseIf s.PRIORIDAD = 2 Then
                        prioridad = "Media"
                    Else
                        prioridad = "Alta"
                    End If
                    DataGridView1(columna, fila).Value = prioridad
                    columna = columna + 1
                    If s.ESTADO = 1 Then
                        estado = "Pendiente"
                    ElseIf s.ESTADO = 2 Then
                        estado = "En proceso"
                    Else
                        estado = "Finalizado"
                    End If
                    DataGridView1(columna, fila).Value = estado
                    If estado = "Pendiente" Then
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Red
                    ElseIf estado = "En proceso" Then
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Yellow
                    Else
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Green
                    End If
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim s As New dSolicitudesIT
            Dim u As New dUsuario
            id = row.Cells("Id").Value
            s.ID = id
            s = s.buscar
            TextId.Text = s.ID
            DateFecha.Value = s.FECHA
            If s.PRIORIDAD = 1 Then
                ComboPrioridad.Text = "Baja"
            ElseIf s.PRIORIDAD = 2 Then
                ComboPrioridad.Text = "Media"
            Else
                ComboPrioridad.Text = "Alta"
            End If
            TextDescripcion.Text = s.DESCRIPCION
            u.ID = s.SOLICITANTE
            u = u.buscar
            ComboUsuario.Text = u.NOMBRE
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Solicitante" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim s As New dSolicitudesIT
            Dim u As New dUsuario
            id = row.Cells("Id").Value
            s.ID = id
            s = s.buscar
            TextId.Text = s.ID
            DateFecha.Value = s.FECHA
            If s.PRIORIDAD = 1 Then
                ComboPrioridad.Text = "Baja"
            ElseIf s.PRIORIDAD = 2 Then
                ComboPrioridad.Text = "Media"
            Else
                ComboPrioridad.Text = "Alta"
            End If
            TextDescripcion.Text = s.DESCRIPCION
            u.ID = s.SOLICITANTE
            u = u.buscar
            ComboUsuario.Text = u.NOMBRE
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Prioridad" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim s As New dSolicitudesIT
            Dim u As New dUsuario
            id = row.Cells("Id").Value
            s.ID = id
            s = s.buscar
            TextId.Text = s.ID
            DateFecha.Value = s.FECHA
            If s.PRIORIDAD = 1 Then
                ComboPrioridad.Text = "Baja"
            ElseIf s.PRIORIDAD = 2 Then
                ComboPrioridad.Text = "Media"
            Else
                ComboPrioridad.Text = "Alta"
            End If
            TextDescripcion.Text = s.DESCRIPCION
            u.ID = s.SOLICITANTE
            u = u.buscar
            ComboUsuario.Text = u.NOMBRE
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Estado" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim s As New dSolicitudesIT
            Dim u As New dUsuario
            id = row.Cells("Id").Value
            s.ID = id
            s = s.buscar
            TextId.Text = s.ID
            DateFecha.Value = s.FECHA
            If s.PRIORIDAD = 1 Then
                ComboPrioridad.Text = "Baja"
            ElseIf s.PRIORIDAD = 2 Then
                ComboPrioridad.Text = "Media"
            Else
                ComboPrioridad.Text = "Alta"
            End If
            TextDescripcion.Text = s.DESCRIPCION
            u.ID = s.SOLICITANTE
            u = u.buscar
            ComboUsuario.Text = u.NOMBRE
        End If
    End Sub

    Private Sub ButtonNueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNueva.Click
        limpiar()
    End Sub

    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        If ComboListarEstado.Text <> "" And ComboListarUsuario.Text <> "" Then
            cargarlistaxEstadoUsuario()
        Else
            If ComboListarEstado.Text <> "" Then
                cargarlistaxEstado()
            End If
            If ComboListarUsuario.Text <> "" Then
                cargarlistaxUsuario()
            End If
        End If
    End Sub

    Private Sub ButtonListarTodas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListarTodas.Click
        cargarlista()
    End Sub
End Class