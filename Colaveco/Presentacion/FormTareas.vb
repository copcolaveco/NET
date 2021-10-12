Public Class FormTareas
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
        cargarComboUsuarios()
        cargarComboSectores()
        cargarComboCreador()
        ComboCreador.Text = u.NOMBRE
        cargarLista()
        limpiar()
    End Sub
    Public Sub cargarComboUsuarios()
        Dim usu As New dUsuario
        Dim lista As New ArrayList
        lista = usu.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each usu In lista
                    ComboResponsable.Items.Add(usu)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboSectores()
        Dim s As New dSectores
        Dim lista As New ArrayList
        lista = s.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    ComboSector.Items.Add(s)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboCreador()
        Dim usu As New dUsuario
        Dim lista As New ArrayList
        lista = usu.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each usu In lista
                    ComboCreador.Items.Add(usu)
                Next
            End If
        End If
    End Sub
    Private Sub cargarlista()
        Dim t As New dTareas
        Dim lista As New ArrayList
        Dim idusuario As Integer = 0
        Dim idcreador As Integer = 0
        Dim idsector As Integer = 0
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        idusuario = Usuario.ID
        idcreador = Usuario.ID
        idsector = Usuario.SECTOR
        lista = t.listarxusuarioxcreador(idusuario, idcreador, idsector)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Add(lista.Count)
            End If
        End If
       
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each t In lista
                    DataGridView1(columna, fila).Value = t.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = t.DESCRIPCION
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = t.FINALIZACION
                    columna = columna + 1
                    Dim usuario As New dUsuario
                    usuario.ID = t.USUARIO
                    usuario = usuario.buscar
                    If Not usuario Is Nothing Then
                        DataGridView1(columna, fila).Value = usuario.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    usuario = Nothing
                    Dim sector As New dSectores
                    sector.ID = t.SECTOR
                    sector = sector.buscar
                    If Not sector Is Nothing Then
                        DataGridView1(columna, fila).Value = sector.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    sector = Nothing
                    Dim creador As New dUsuario
                    creador.ID = t.CREADOR
                    creador = creador.buscar
                    If Not creador Is Nothing Then
                        DataGridView1(columna, fila).Value = creador.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    creador = Nothing
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        DateFecha.Value = Now
        TextDescripcion.Text = ""
        DateVencimiento.Value = Now
        ComboResponsable.Text = ""
        ComboResponsable.SelectedItem = Nothing
        ComboSector.Text = ""
        ComboSector.SelectedItem = Nothing
        CheckRealizada.Checked = False
        cargarlista()
        TextDescripcion.Focus()
    End Sub

    Private Sub ButtonNueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNueva.Click
        limpiar()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If TextId.Text <> "" Then
            Dim id As Long = TextId.Text.Trim
            Dim t As New dTareas
            t.ID = id
            If (t.eliminar(Usuario)) Then
                MsgBox("Tarea eliminada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
            cargarlista()
        End If
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        If TextDescripcion.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado la descripción", MsgBoxStyle.Exclamation, "Atención") : TextDescripcion.Focus() : Exit Sub
        Dim descripcion As String = TextDescripcion.Text
        Dim fechavencimiento As Date = DateVencimiento.Value.ToString("yyyy-MM-dd")
        Dim responsable As dUsuario = CType(ComboResponsable.SelectedItem, dUsuario)
        Dim sector As dSectores = CType(ComboSector.SelectedItem, dSectores)
        Dim creador As dUsuario = CType(ComboCreador.SelectedItem, dUsuario)
        Dim realizada As Integer = 0
        If CheckRealizada.Checked = True Then
            realizada = 1
        Else
            realizada = 0
        End If
        If TextId.Text.Trim.Length > 0 Then
            Dim t As New dTareas
            Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fec As String
            Dim fecven As String
            fec = Format(fecha, "yyyy-MM-dd")
            fecven = Format(fechavencimiento, "yyyy-MM-dd")
            t.ID = id
            t.FECHA = fec
            t.DESCRIPCION = descripcion
            t.FINALIZACION = fecven
            If Not responsable Is Nothing Then
                t.USUARIO = responsable.ID
            Else
                t.USUARIO = -1
            End If
            If Not sector Is Nothing Then
                t.SECTOR = sector.ID
            Else
                t.SECTOR = -1
            End If
            If Not creador Is Nothing Then
                t.CREADOR = creador.ID
            Else
                t.CREADOR = -1
            End If
            t.REALIZADA = realizada
            If (t.modificar(Usuario)) Then
                MsgBox("Tarea modificada", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim t As New dTareas()
            Dim fec As String
            Dim fecven As String
            fec = Format(fecha, "yyyy-MM-dd")
            fecven = Format(fechavencimiento, "yyyy-MM-dd")
            t.FECHA = fec
            t.DESCRIPCION = descripcion
            t.FINALIZACION = fecven
            If Not responsable Is Nothing Then
                t.USUARIO = responsable.ID
            Else
                t.USUARIO = -1
            End If
            If Not sector Is Nothing Then
                t.SECTOR = sector.ID
            Else
                t.SECTOR = -1
            End If
            If Not creador Is Nothing Then
                t.CREADOR = creador.ID
            Else
                t.CREADOR = -1
            End If
            t.REALIZADA = realizada
            If (t.guardar(Usuario)) Then
                MsgBox("Tarea guardada", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Descripcion" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim t As New dTareas
            id = row.Cells("Id").Value
            t.ID = id
            t = t.buscar()
            If Not t Is Nothing Then
                TextId.Text = t.ID
                DateFecha.Value = t.FECHA
                TextDescripcion.Text = t.DESCRIPCION
                DateVencimiento.Value = t.FINALIZACION
                Dim usu As New dUsuario
                usu.ID = t.USUARIO
                usu = usu.buscar
                If Not usu Is Nothing Then
                    ComboResponsable.Text = usu.NOMBRE
                End If
                Dim sec As New dSectores
                sec.ID = t.SECTOR
                sec = sec.buscar
                If Not sec Is Nothing Then
                    ComboSector.Text = sec.NOMBRE
                End If
                Dim crea As New dUsuario
                crea.ID = t.CREADOR
                crea = crea.buscar
                If Not crea Is Nothing Then
                    ComboCreador.Text = crea.NOMBRE
                End If
                If t.REALIZADA = 1 Then
                    CheckRealizada.Checked = True
                Else
                    CheckRealizada.Checked = False
                End If
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Vencimiento" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim t As New dTareas
            id = row.Cells("Id").Value
            t.ID = id
            t = t.buscar()
            If Not t Is Nothing Then
                TextId.Text = t.ID
                DateFecha.Value = t.FECHA
                TextDescripcion.Text = t.DESCRIPCION
                DateVencimiento.Value = t.FINALIZACION
                Dim usu As New dUsuario
                usu.ID = t.USUARIO
                usu = usu.buscar
                If Not usu Is Nothing Then
                    ComboResponsable.Text = usu.NOMBRE
                End If
                Dim sec As New dSectores
                sec.ID = t.SECTOR
                sec = sec.buscar
                If Not sec Is Nothing Then
                    ComboSector.Text = sec.NOMBRE
                End If
                Dim crea As New dUsuario
                crea.ID = t.CREADOR
                crea = crea.buscar
                If Not crea Is Nothing Then
                    ComboCreador.Text = crea.NOMBRE
                End If
                If t.REALIZADA = 1 Then
                    CheckRealizada.Checked = True
                Else
                    CheckRealizada.Checked = False
                End If
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Responsable" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim t As New dTareas
            id = row.Cells("Id").Value
            t.ID = id
            t = t.buscar()
            If Not t Is Nothing Then
                TextId.Text = t.ID
                DateFecha.Value = t.FECHA
                TextDescripcion.Text = t.DESCRIPCION
                DateVencimiento.Value = t.FINALIZACION
                Dim usu As New dUsuario
                usu.ID = t.USUARIO
                usu = usu.buscar
                If Not usu Is Nothing Then
                    ComboResponsable.Text = usu.NOMBRE
                End If
                Dim sec As New dSectores
                sec.ID = t.SECTOR
                sec = sec.buscar
                If Not sec Is Nothing Then
                    ComboSector.Text = sec.NOMBRE
                End If
                Dim crea As New dUsuario
                crea.ID = t.CREADOR
                crea = crea.buscar
                If Not crea Is Nothing Then
                    ComboCreador.Text = crea.NOMBRE
                End If
                If t.REALIZADA = 1 Then
                    CheckRealizada.Checked = True
                Else
                    CheckRealizada.Checked = False
                End If
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Sector" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim t As New dTareas
            id = row.Cells("Id").Value
            t.ID = id
            t = t.buscar()
            If Not t Is Nothing Then
                TextId.Text = t.ID
                DateFecha.Value = t.FECHA
                TextDescripcion.Text = t.DESCRIPCION
                DateVencimiento.Value = t.FINALIZACION
                Dim usu As New dUsuario
                usu.ID = t.USUARIO
                usu = usu.buscar
                If Not usu Is Nothing Then
                    ComboResponsable.Text = usu.NOMBRE
                End If
                Dim sec As New dSectores
                sec.ID = t.SECTOR
                sec = sec.buscar
                If Not sec Is Nothing Then
                    ComboSector.Text = sec.NOMBRE
                End If
                Dim crea As New dUsuario
                crea.ID = t.CREADOR
                crea = crea.buscar
                If Not crea Is Nothing Then
                    ComboCreador.Text = crea.NOMBRE
                End If
                If t.REALIZADA = 1 Then
                    CheckRealizada.Checked = True
                Else
                    CheckRealizada.Checked = False
                End If
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Creador" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim t As New dTareas
            id = row.Cells("Id").Value
            t.ID = id
            t = t.buscar()
            If Not t Is Nothing Then
                TextId.Text = t.ID
                DateFecha.Value = t.FECHA
                TextDescripcion.Text = t.DESCRIPCION
                DateVencimiento.Value = t.FINALIZACION
                Dim usu As New dUsuario
                usu.ID = t.USUARIO
                usu = usu.buscar
                If Not usu Is Nothing Then
                    ComboResponsable.Text = usu.NOMBRE
                End If
                Dim sec As New dSectores
                sec.ID = t.SECTOR
                sec = sec.buscar
                If Not sec Is Nothing Then
                    ComboSector.Text = sec.NOMBRE
                End If
                Dim crea As New dUsuario
                crea.ID = t.CREADOR
                crea = crea.buscar
                If Not crea Is Nothing Then
                    ComboCreador.Text = crea.NOMBRE
                End If
                If t.REALIZADA = 1 Then
                    CheckRealizada.Checked = True
                Else
                    CheckRealizada.Checked = False
                End If
            End If
        End If
    End Sub
End Class